using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Component;
using TimeTableManager.Element;

namespace TimeTableManager.Component {
    /// <summary>パーシャルクラス
    /// </summary>
    public partial class UScheduleCalenderView : UserControl {
        #region プライベート
        private TimeTableManager.Element.BTimeTable timeTable;
        private TimeTableManager.UI.FMainForm mainForm;
        private DateTime startDate, endDate;
        private List<ShiftComboBoxColumn> columns1;
        private Dictionary<BMember, ShiftComboBoxColumn> columns2;
        private static bool columnFitAuto = true;
        private static UScheduleCalenderView singleton;
        /// <summary>選択された日付
        /// </summary>
        private List<DateTime> selectedDates = new List<DateTime>();
        #endregion
        /// <summary>列の幅調整モード
        /// </summary>
        public static bool ColumnFitAuto {
            get { return UScheduleCalenderView.columnFitAuto; }
            set { 
                UScheduleCalenderView.columnFitAuto = value;
                if (singleton != null) {
                    singleton.SetColumnsFillAuto(value);
                }
            }
        }
        /// <summary>メインフォーム
        /// </summary>
        public TimeTableManager.UI.FMainForm MainForm {
            get { return mainForm; }
            set {
                mainForm = value;
                if (mainForm != null) {
                    mainForm.OnFileOpen += new TimeTableManager.UI.FMainForm.FileOpenEventHandler(mainForm_OnFileOpen);
                    mainForm.OnTimeTableAutoEdited += new TimeTableManager.UI.FMainForm.TimeTableAutoEditedEventHandler(mainForm_OnTimeTableAutoEdited);
                }
            }
        }
        /// <summary>列の幅調整モード
        /// </summary>
        /// <param name="auto"></param>
        public void SetColumnsFillAuto(bool auto) {
            if (auto) {
                if (CalenderView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.Fill) {
                    CalenderView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            } else {
                if (CalenderView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.None) {
                    CalenderView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }
            }
        }
        /// <summary>ファイルオープンによる
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnFileOpen(object sender, TimeTableManager.UI.TimeTableChangedEventArgs e) {
            NotifyDisplayPeriodChanged();
            //if (MainForm != null) {
            //    MainForm.ViewSelectionChanged(selectedDates);
            //}
        }
        /// <summary>自動設定が走りました
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnTimeTableAutoEdited(object sender, TimeTableManager.UI.TimeTableAutoEditedEventArgs e) {
            this.CalenderView.Refresh();
        }
        /// <summary>グリッド？
        /// </summary>
        public DataGridView Grid {
            get {
                return this.CalenderView;
            }
        }
        /// <summary>メンバー列の数
        /// </summary>
        public int MemberColumnCount {
            get {
                return columns1.Count;
            }
        }
        /// <summary>列のメンバー
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public BMember GetColumnMember(int index) {
            return columns1[index].Member;
        }
        /// <summary>カレント行インデックス
        /// </summary>
        public int CurrentRowIndex {
            get {
                DataGridViewRow row = CalenderView.CurrentRow;
                if (row == null) {
                    return 0;
                }
                return row.Index;
            }
        }
        /// <summary>カレント行日付
        /// </summary>
        public DateTime CurrentRowDate {
            get {
                return GetDateFromRowIndex(CurrentRowIndex);
            }
        }
        /// <summary>選択されている？
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsSelected(int index) {
            bool ret = false;
            foreach (DataGridViewRow row in CalenderView.SelectedRows) {
                if (row.Index == index) {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        /// <summary>タイムテーブル
        /// </summary>
        public BTimeTable TimeTable {
            get { return timeTable; }
            set {
                timeTable = value;
                if (timeTable != null) {
                    timeTable.OnScheduleEdited += new BTimeTable.ScheduleEditedEventHandler(timeTable_OnScheduleEdited);
                    timeTable.OnScheduleDateRequirePatternsEdited += new BTimeTable.ScheduleDateRequirePatternsEditedEventHandler(timeTable_OnScheduleDateRequirePatternsEdited);
                    timeTable.OnMembersEdited += new BTimeTable.MembersEditedEventHandler(timeTable_OnMembersEdited);
                }
                // 不要な列の削除
                columns1.Clear();
                columns2.Clear();
                List<DataGridViewColumn> collist = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn column in CalenderView.Columns) {
                    if (column is ShiftComboBoxColumn) {
                        collist.Add(column);
                    }
                }
                foreach (DataGridViewColumn column in collist) {
                    CalenderView.Columns.Remove(column);
                }
            }
        }
        /// <summary>メンバーが更新された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnMembersEdited (object sender, EMembersEditedEventArgs e) {
            if (columns2.ContainsKey(e.Source)) {
                ShiftComboBoxColumn column = columns2[e.Source];
                column.HeaderText = e.Source.Name;
            }
        }
        /// <summary>人員配置が変更になった
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnScheduleDateRequirePatternsEdited(object sender, EScheduleDateRequirePatternsEditedEventArgs e) {
            if (this.StartDate <= e.ScheduledDate.Date && e.ScheduledDate.Date.Date <= this.EndDate) {
                this.CalenderView.Refresh();
            }
        }
        /// <summary>スケジュール日が変更になった
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnScheduleEdited(object sender, EScheduleEditedEventArgs e) {
            if (this.StartDate <= e.Schedule.Date.Date && e.Schedule.Date.Date <= this.EndDate) {
                this.CalenderView.Refresh();
            }
        }
        /// <summary>カレンダーの開始日
        /// </summary>
        public DateTime StartDate {
            get {
                if (startDate > endDate) {
                    DateTime swap = startDate;
                    startDate = endDate;
                    endDate = swap;
                }
                return startDate;
            }
            set { startDate = value; }
        }
        /// <summary>カレンダーの終了日
        /// </summary>
        public DateTime EndDate {
            get {
                if (startDate > endDate) {
                    DateTime swap = startDate;
                    startDate = endDate;
                    endDate = swap;
                }
                return endDate;
            }
            set { endDate = value; }
        }
        /// <summary> 行数の取得
        /// </summary>
        public void NotifyDisplayPeriodChanged() {
            //CalenderView.CurrentCellChanged;
            // 行数の獲得
            int row = 0;
            TimeSpan span = EndDate - StartDate;
            row = span.Days + 1;
            this.CalenderView.RowCount = row;
            //
            if (TimeTable != null) {
                // 人員配置の候補作成
                ResetRequires();
                // シフトの候補作成
                ResetPatterns();
                // 列の再構成
                ResetMembers();
                // イベント発生
                if (OnDisplayPeriodChanged != null) {
                    DisplayPeriodChangedEventArgs e = new DisplayPeriodChangedEventArgs(StartDate, EndDate);
                    OnDisplayPeriodChanged(this, e);
                }
                if (MainForm != null) {
                    // 選択リストの作成
                    List<DateTime> workList = new List<DateTime>();
                    for (int i = 0; i < CalenderView.SelectedRows.Count; i++) {
                        DataGridViewRow row2 = CalenderView.SelectedRows[i];
                        DateTime date = this.GetDateFromRowIndex(row2.Index);
                        workList.Add(date);
                    }
                    // 選択されていなかったら現在行を追加する
                    if (workList.Count == 0) {
                        workList.Add(CurrentRowDate);
                    } else {
                        workList.Sort();
                    }
                    selectedDates = workList;
                    MainForm.ViewSelectionChanged(SelectedDates);
                }
            } else {
                // タイムテーブルが設定されていない
                EndDate = StartDate;
                this.CalenderView.RowCount = 0;
            }
        }
        /// <summary>人員配置の一覧
        /// </summary>
        private void ResetRequires() {
            if (timeTable == null) return;
            ResetRequires(CurrentRowDate);
        }
        /// <summary>人員配置の一覧
        /// </summary>
        private void ResetRequires(DateTime currentdate) {
            if (timeTable == null) return;
            TblRequireComboBox.Clear();
            TimeTableManager.ElementCollection.BRequirePatternsCollection requires = TimeTable.Requires;
            int size = requires.Size(true);
            for (int i = 0; i < size; i++) {
                BRequirePatterns require = requires[i, true];
                if (require.IsAvailable(currentdate)) {
                    TblRequireComboBox.Rows.Add(require, require.Name);
                }
            }
        }
        /// <summary>勤務シフトの一覧
        /// </summary>
        private void ResetPatterns() {
            if (timeTable == null) return;
            ResetPatterns(CurrentRowDate);
        }
        /// <summary>勤務シフトの一覧
        /// </summary>
        private void ResetPatterns(DateTime currentdate) {
            if (timeTable == null) return;
            TblPatternComboBox.Clear();
            TimeTableManager.ElementCollection.BPatternCollection Patterns = TimeTable.Patterns;
            int size = Patterns.Size(true);
            for (int i = 0; i < size; i++) {
                BPattern Pattern = Patterns[i, true];
                if (Pattern.IsAvailable(currentdate)) {
                    TblPatternComboBox.Rows.Add(Pattern, Pattern.Name);
                }
            }
        }
        /// <summary>メンバー列の再作成
        /// </summary>
        private void ResetMembers() {
            CalenderView.Enabled = false;
            TimeTableManager.ElementCollection.BMemberCollection Members = TimeTable.Members;
            // 不要な列の削除
            int workcount = 0;
            while (workcount < columns1.Count) {
                ShiftComboBoxColumn column = columns1[workcount];
                BMember member = column.Member;
                if (member.TimeTable != this.TimeTable) {
                    // 異なるタイムテーブルのメンバー
                    CalenderView.Columns.Remove(column);
                    columns1.Remove(column);
                    columns2.Remove(member);
                } else {
                    if (member.IsAvailable(StartDate, EndDate)) {
                        // 有効なら無視する
                        workcount++;
                    } else {
                        // 無効なら削除する
                        CalenderView.Columns.Remove(column);
                        columns1.Remove(column);
                        columns2.Remove(member);
                    }
                }
            }
            for (int i = 0; i < Members.Size(true); i++) {
                BMember member = Members[i, true];
                if (member.IsAvailable(StartDate, EndDate)) {
                    // 列が必要なら追加
                    ShiftComboBoxColumn column;
                    if (columns2.ContainsKey(member)) {
                        column = columns2[member];
                        //column.CellTemplate = new PatternCell();
                        if (column.Index != i + 2) {
                            CalenderView.Columns.Remove(column);
                            columns2.Remove(member);
                            columns1.Remove(column);
                            // 列
                            column = new ShiftComboBoxColumn();
                            column.CellTemplate = new PatternCell();
                            column.Member = member;
                            column.DataSource = this.DsPatternComboBox;
                            column.DisplayMember = "TblPatternComboBox.ClmPatternNameComboBox";
                            column.HeaderText = member.Name;
                            column.Name = "MEMBER" + member.ObjectID.ToString();
                            column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                            column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                            column.ValueMember = "TblPatternComboBox.ClmPatternComboBox";
                            column.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                            column.DisplayStyleForCurrentCellOnly = true;
                            columns2.Add(member, column);
                            if (i < columns1.Count) {
                                columns1.Insert(i, column);
                                CalenderView.Columns.Insert(i + 2, column);
                            } else {
                                columns1.Add(column);
                                CalenderView.Columns.Add(column);
                            }
                        }
                    } else {
                        column = new ShiftComboBoxColumn();
                        column.CellTemplate = new PatternCell();
                        column.Member = member;
                        column.DataSource = this.DsPatternComboBox;
                        column.DisplayMember = "TblPatternComboBox.ClmPatternNameComboBox";
                        column.HeaderText = member.Name;
                        column.Name = "MEMBER" + member.ObjectID.ToString();
                        column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                        column.ValueMember = "TblPatternComboBox.ClmPatternComboBox";
                        column.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                        column.DisplayStyleForCurrentCellOnly = true;
                        CalenderView.Columns.Add(column);
                        columns1.Add(column);
                        columns2.Add(member, column);
                    }
                } else {
                    // 列が不要なら削除
                    ShiftComboBoxColumn column;
                    if (columns2.ContainsKey(member)) {
                        column = columns2[member];
                        //CalenderView.Columns.Remove(column);
                        columns2.Remove(member);
                        columns1.Remove(column);
                    }
                }
                //*/
            }
            CalenderView.Enabled = true;
            //CalenderView.EndEdit();
        }
        /// <summary>コンストラクタ
        /// とりあえず、開始時点では今月の始まりからおわりまで
        /// </summary>
        public UScheduleCalenderView() {
            InitializeComponent();
            UScheduleCalenderView.singleton = this;
            // 日付セル
            this.DateColumn.CellTemplate = new DateCell();
            // データ型（人員配置）
            ClmRequireOfRequireCombo.DataType = typeof(BRequirePatterns);
            RequirePatternColumn.CellTemplate = new RequirePatternsCell();
            try {
                System.Windows.Forms.DataGridViewCellStyle RequirePatternsCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
                this.RequirePatternColumn.DataSource = this.DsRequireComboBox;
                RequirePatternsCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                this.RequirePatternColumn.DefaultCellStyle = RequirePatternsCellStyle;
                this.RequirePatternColumn.DisplayMember = "TblRequireComboBox.ClmRequireOfRequireNameCombo";
                this.RequirePatternColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                this.RequirePatternColumn.DisplayStyleForCurrentCellOnly = true;
                this.RequirePatternColumn.HeaderText = "人員配置";
                this.RequirePatternColumn.Name = "RequirePatternColumn";
                this.RequirePatternColumn.ValueMember = "TblRequireComboBox.ClmRequireOfRequireCombo";
            } catch { }
            // データ型（シフト）
            ClmPatternComboBox.DataType = typeof(BPattern);
            // 変数
            columns1 = new List<ShiftComboBoxColumn>();
            columns2 = new Dictionary<BMember, ShiftComboBoxColumn>();
            // 初期化
            DateTime today = System.DateTime.Today;
            StartDate = new DateTime(today.Year, today.Month, 1);
            EndDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            NotifyDisplayPeriodChanged();
        }
        /// <summary>行インデックスから日付への変換
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <returns></returns>
        private DateTime GetDateFromRowIndex(int RowIndex) {
            return StartDate.AddDays(RowIndex);
        }
        /// <summary>値要求
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void CalenderView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            if (TimeTable == null) return;
            DateTime date = GetDateFromRowIndex(e.RowIndex);
            if (e.ColumnIndex == 0) {
                // 日付
                e.Value = date;
            } else {
                BScheduledDate sdate = TimeTable[date];
                if (e.ColumnIndex == 1) {
                    // 人員配置
                    e.Value = sdate.Require;
                } else {
                    // メンバー｜｜シフト
                    int index = e.ColumnIndex - 2;
                    if (index < columns1.Count) {
                        ShiftComboBoxColumn col = columns1[index];
                        BMember member = col.Member;
                        if (member != null) {
                            BSchedule schedule = sdate[member];
                            e.Value = schedule.Pattern;
                        }
                    }
                }
            }
        }
        /// <summary>値設定
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void CalenderView_CellValuePushed(object sender, DataGridViewCellValueEventArgs e) {
            if (TimeTable == null) return;
            DateTime date = GetDateFromRowIndex(e.RowIndex);
            if (e.ColumnIndex == 0) {
                // 日付
                //e.Value = date;
            } else {
                BScheduledDate sdate = TimeTable[date];
                if (e.ColumnIndex == 1) {
                    // 人員配置
                    sdate.Require = e.Value as BRequirePatterns;
                } else {
                    // メンバー｜｜シフト
                    int index = e.ColumnIndex - 2;
                    if (index < columns1.Count) {
                        ShiftComboBoxColumn col = columns1[index];
                        BMember member = col.Member;
                        if (member != null) {
                            BSchedule schedule = sdate[member];
                            schedule.Pattern = e.Value as BPattern;
                        }
                    }
                }
            }
        }
        /// <summary>選択された日付の終わり
        /// </summary>
        public DateTime MaximumSelection {
            get {
                DateTime maximumSelection;// = this.EndDate;
                if (selectedDates.Count == 0) {
                    maximumSelection = this.EndDate;
                } else {
                    maximumSelection = selectedDates[selectedDates.Count - 1];
                }
                return maximumSelection;
            }
        }
        /// <summary>選択された日付の始まり
        /// </summary>
        public DateTime MinimumSelection {
            get {
                DateTime minimumSelection;// = this.EndDate;
                if (selectedDates.Count == 0) {
                    minimumSelection = this.StartDate;
                } else {
                    minimumSelection = selectedDates[0];
                }
                return minimumSelection;
            }
        }
        /// <summary>選択された日付の日数
        /// </summary>
        public int SelectedDateCount {
            get {
                return selectedDates.Count;
            }
        }
        /// <summary>選択された日付
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DateTime SelectedDate(int i) {
            return selectedDates[i];
        }
        /// <summary>選択された日付
        /// </summary>
        public List<DateTime> SelectedDates {
            get { return selectedDates; }
        }
        /// <summary>選択された内容の変更
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void CalenderView_CurrentCellChanged(object sender, EventArgs e) {
            if (CalenderView.CurrentCell == null) return;
            int wColIndex = CalenderView.CurrentCell.ColumnIndex;
            int wRowIndex = CalenderView.CurrentCell.RowIndex;
            DateTime date = this.GetDateFromRowIndex(wRowIndex);
            bool history = (MainForm == null ? true : !MainForm.IsEditHistory);
            if (date < DateTime.Today && history) {
                CalenderView.ReadOnly = true;
            } else {
                CalenderView.ReadOnly = false;
                if (wColIndex == 0) {
                    // 日付列は無条件に読取専用
                    CalenderView.ReadOnly = true;
                }
            }
        }
        /// <summary>行が変わったよー
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void CalenderView_RowEnter(object sender, DataGridViewCellEventArgs e) {
            DateTime currentDate = this.GetDateFromRowIndex(e.RowIndex);
            ResetRequires(currentDate);
            ResetPatterns(currentDate);
        }
        /// <summary>選択された内容の変更
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void CalenderView_SelectionChanged(object sender, EventArgs e) {
            // 選択リストの作成
            List<DateTime> workList = new List<DateTime>();
            for (int i = 0; i < CalenderView.SelectedRows.Count; i++) {
                DataGridViewRow row = CalenderView.SelectedRows[i];
                DateTime date = this.GetDateFromRowIndex(row.Index);
                workList.Add(date);
            }
            // 選択されていなかったら現在行を追加する
            if (workList.Count == 0) {
                workList.Add(CurrentRowDate);
            } else {
                workList.Sort();
            }
            // 行レベルの変更があった場合のみイベントを発生する
            int count = workList.Count;
            bool changed = false;
            if (selectedDates.Count != count) {
                // 選択行数が違えばイベント発生
                changed = true;
            } else if (selectedDates[0] != workList[0]) {
                // 最初が違う
                changed = true;
            } else if (selectedDates[count - 1] != workList[count - 1]) {
                // 終わりが違う
                changed = true;
            }
            if (changed) {
                // イベント発生本体
                selectedDates = workList;
                if (MainForm != null) {
                    MainForm.ViewSelectionChanged(selectedDates);
                }
            }
        }
        /// <summary>表示期間が変更になった
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        /// <returns></returns>
        public delegate void DisplayPeriodChangedEventHandler(object sender, DisplayPeriodChangedEventArgs e);
        /// <summary>表示期間が変更になった
        /// </summary>
        public event DisplayPeriodChangedEventHandler OnDisplayPeriodChanged;
        /// <summary>この日付を選択する
        /// </summary>
        /// <param name="date">選択する日付</param>
        public void Select(DateTime date) {
            TimeSpan span = date - StartDate;
            int rowi = span.Days;
            CalenderView.Rows[rowi].Selected = true;
            CalenderView.CurrentCell = CalenderView.Rows[rowi].Cells[0];
        }

    }
    /// <summary>人員配置をあらわすセル
    /// </summary>
    public class RequirePatternsCell : System.Windows.Forms.DataGridViewComboBoxCell {
        /// <summary>値の設定時
        /// </summary>
        /// <param name="formattedValue"></param>
        /// <param name="cellStyle"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="valueTypeConverter"></param>
        /// <returns></returns>
        public override object ParseFormattedValue(
                 object formattedValue,
                 DataGridViewCellStyle cellStyle,
                 TypeConverter formattedValueTypeConverter,
                 TypeConverter valueTypeConverter) {
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
        /// <summary>値の取得時
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object GetFormattedValue(
              object value, int rowIndex,
              ref DataGridViewCellStyle cellStyle,
              TypeConverter valueTypeConverter,
              TypeConverter formattedValueTypeConverter,
              DataGridViewDataErrorContexts context) {
            BRequirePatterns ret = null;
            if (value != null && value is BRequirePatterns) {
                ret = value as BRequirePatterns;
            }
            return (ret == null) ? "" : ret.Name;
        }
    }
    /// <summary>勤務シフトをあらわすセル
    /// </summary>
    public class PatternCell : System.Windows.Forms.DataGridViewComboBoxCell {
        /// <summary>値の設定時
        /// </summary>
        /// <param name="formattedValue"></param>
        /// <param name="cellStyle"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="valueTypeConverter"></param>
        /// <returns></returns>
        public override object ParseFormattedValue(
                 object formattedValue,
                 DataGridViewCellStyle cellStyle,
                 TypeConverter formattedValueTypeConverter,
                 TypeConverter valueTypeConverter) {
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
        /// <summary>値の取得時
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object GetFormattedValue(
              object value, int rowIndex,
              ref DataGridViewCellStyle cellStyle,
              TypeConverter valueTypeConverter,
              TypeConverter formattedValueTypeConverter,
              DataGridViewDataErrorContexts context) {
            string ret = "";
            if (value != null && value is BPattern) {
                ret = (value as BPattern).Name;
            }
            return ret;
        }
    }
    /// <summary>数値をあらわすセル
    /// </summary>
    public class DateCell : System.Windows.Forms.DataGridViewTextBoxCell {
        /// <summary>値の設定時
        /// </summary>
        /// <param name="formattedValue"></param>
        /// <param name="cellStyle"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="valueTypeConverter"></param>
        /// <returns></returns>
        public override object ParseFormattedValue(
                 object formattedValue,
                 DataGridViewCellStyle cellStyle,
                 TypeConverter formattedValueTypeConverter,
                 TypeConverter valueTypeConverter) {
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
        /// <summary>値の取得時
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object GetFormattedValue(
              object value, int rowIndex,
              ref DataGridViewCellStyle cellStyle,
              TypeConverter valueTypeConverter,
              TypeConverter formattedValueTypeConverter,
              DataGridViewDataErrorContexts context) {
            string ret = null;
            if (value != null && value is DateTime) {
                DateTime date = (DateTime)value;
                ret = date.ToString("MM月dd日");
                if (date.DayOfWeek == DayOfWeek.Sunday) {
                    cellStyle.ForeColor = Color.Red;
                } else if (date.DayOfWeek == DayOfWeek.Saturday) {
                    cellStyle.ForeColor = Color.Blue;
                }
            }
            return (ret == null) ? "" : ret;
        }
    }
    /// <summary>表示する期間が変更になった
    /// </summary>
    public class DisplayPeriodChangedEventArgs : EventArgs {
        private readonly DateTime start, end;
        /// <summary>表示期間の開始
        /// </summary>
        public DateTime Start {
            get { return start; }
        }
        /// <summary>表示期間の終了
        /// </summary>
        public DateTime End {
            get { return end; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="Start">開始</param>
        /// <param name="End">終了</param>
        public DisplayPeriodChangedEventArgs(DateTime Start, DateTime End) {
            this.start = Start;
            this.end = End;
        }
    }
    /// <summary>勤務シフトコンボボックス
    /// </summary>
    class ShiftComboBoxColumn : DataGridViewComboBoxColumn {
        private BMember member;
        /// <summary>メンバー
        /// </summary>
        public BMember Member {
            get { return member; }
            set {
                member = value;
                this.HeaderText = member.Name;
            }
        }
    }
}
