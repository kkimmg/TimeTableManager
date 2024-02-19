using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Element;

namespace TimeTableManager.Component {
    /// <summary>乱数化されたスケジュール日の表示／編集コンポーネント
    /// </summary>
    public partial class UFavoriteEditor : UserControl {
        private TimeTableManager.UI.FMainForm mainForm;
        private BTimeTable timeTable;
        private List<BMember> members;
        private List<BPattern> patterns;
        private BScheduledDate sdate;
        /// <summary>乱数化されたスケジュール日の表示／編集コンポーネント
        /// </summary>
        public UFavoriteEditor () {
            InitializeComponent();
            // コレクションの初期化
            members = new List<BMember>();
            patterns = new List<BPattern>();
            // データ型の設定
            ClmMember.DataType = typeof(BMember);
            ClmPattern.DataType = typeof(BPattern);
            //
        }
        /// <summary>メインフォーム
        /// </summary>
        public TimeTableManager.UI.FMainForm MainForm {
            get { return mainForm; }
            set {
                mainForm = value;
                if (mainForm != null) {
                    mainForm.OnFileOpen += new TimeTableManager.UI.FMainForm.FileOpenEventHandler(mainForm_OnFileOpen);
                    mainForm.OnCurrentDateChanged += new TimeTableManager.UI.FMainForm.CurrentDateChangedEventHandler(mainForm_OnCurrentDateChanged);
                    mainForm.OnTimeTableAutoEdited += new TimeTableManager.UI.FMainForm.TimeTableAutoEditedEventHandler(mainForm_OnTimeTableAutoEdited);
                }
            }
        }
        /// <summary>タイムテーブルが自動編集された
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベントオブジェクト</param>
        void mainForm_OnTimeTableAutoEdited(object sender, TimeTableManager.UI.TimeTableAutoEditedEventArgs e) {
            if (Date != null) {
                if (e.StartDate <= Date.Date && Date.Date <= e.EndDate) {
                    MemberPatternView.Refresh();
                    PatternMemberView.Refresh();
                }
            }
        }
        /// <summary>タイムテーブルがオープンされた
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベントオブジェクト</param>
        void mainForm_OnFileOpen (object sender, TimeTableManager.UI.TimeTableChangedEventArgs e) {
            this.TimeTable = e.TimeTable;
        }
        /// <summary>スケジュール日の選択が変更された
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベントオブジェクト</param>
        void mainForm_OnCurrentDateChanged (object sender, TimeTableManager.UI.ECurrentDateChangedArgs e) {
            this.Date = e.ScheduleDate;
        }
        /// <summary>タイムテーブル
        /// </summary>
        public BTimeTable TimeTable {
            get { return timeTable; }
            set {
                if (timeTable != value) {
                    timeTable = value;
                    this.Date = this.Date;
                    timeTable.OnScheduleEdited += new BTimeTable.ScheduleEditedEventHandler(timeTable_OnScheduleEdited);
                }                
            }
        }
        /// <summary>スケジュールが編集された
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベントオブジェクト</param>
        void timeTable_OnScheduleEdited (object sender, EScheduleEditedEventArgs e) {
            Date = e.Schedule.Date;
        }
        /// <summary>
        /// 日付の設定
        /// </summary>
        public BScheduledDate Date {
            get {
                return sdate;
            }
            set {
                sdate = value;
                if (TimeTable == null && sdate != null) {
                    TimeTable = sdate.TimeTable;
                }
                if (TimeTable != null && sdate != null) {
                    RebuildMembers();
                    RebuildPatterns();
                }
                MemberPatternView.Refresh();
                PatternMemberView.Refresh();
                SetSplitterDistance();
                if (sdate != null && sdate.Date < DateTime.Today) {
                    MemberPatternView.ReadOnly = true;
                    LeftMemberColumn.ReadOnly = true;
                    PatternMemberView.ReadOnly = true;
                    RightPatternColumn.ReadOnly = true;
                } else {
                    MemberPatternView.ReadOnly = false;
                    PatternMemberView.ReadOnly = false;
                }
            }
        }
        /// <summary>メンバーの再作成
        /// </summary>
        private void RebuildMembers () {
            for (int i = PatternMemberView.Columns.Count - 1; i > 0; i--) {
                PatternMemberView.Columns.RemoveAt(i);
            }
            DsMembers.Clear();
            members.Clear();
            TblMembers.Rows.Add(BMember.NULL, BMember.NULL.Name);
            int j = 0;
            for (int i = 0; i < TimeTable.Members.Size(true); i++) {
                BMember member = TimeTable.Members[i, true];
                if (member.IsAvailable(sdate.Date) && !member.BuiltIn) {
                    members.Add(member);
                    // データセットの設定
                    TblMembers.Rows.Add(member, member.Name);
                    // 列の設定
                    DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                    column.CellTemplate = new MemberCell();
                    column.DataSource = this.DsMembers;
                    column.DisplayMember = "TblMembers.ClmMemberName";
                    column.HeaderText = (++j) + "番目";
                    column.Name = "MEMBER" + i.ToString();
                    column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                    column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                    column.ValueMember = "TblMembers.ClmMember";
                    column.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                    column.DisplayStyleForCurrentCellOnly = true;
                    PatternMemberView.Columns.Add(column);
                }
            }
            //TblMembers.Rows.Add(null, "選択無し");
            MemberPatternView.RowCount = members.Count;
            //PatternMemberView.ColumnCount = members.Count + 1;
        }
        /// <summary>勤務シフトの再作成
        /// </summary>
        private void RebuildPatterns () {
            for (int i = MemberPatternView.Columns.Count - 1; i > 0; i--) {
                MemberPatternView.Columns.RemoveAt(i);
            }
            DsPattern.Clear();
            patterns.Clear();
            int j = 0;
            for (int i = 0; i < TimeTable.Patterns.Size(true); i++) {
                BPattern pattern = TimeTable.Patterns[i, true];
                    if (pattern.IsAvailable(sdate.Date) && !pattern.BuiltIn) {
                        patterns.Add(pattern);
                        // データセットの設定
                        TblPatterns.Rows.Add(pattern, pattern.Name);
                        // 列の設定
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.CellTemplate = new PatternCell();
                        column.DataSource = this.DsPattern;
                        column.DisplayMember = "TblPatterns.ClmPatternName";
                        column.HeaderText = (++j) + "番目";
                        column.Name = "PATTERN" + i.ToString();
                        column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                        column.ValueMember = "TblPatterns.ClmPattern";
                        column.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                        column.DisplayStyleForCurrentCellOnly = true;
                        MemberPatternView.Columns.Add(column);
                    } else if (pattern.BuiltIn) {
                        // データセットの設定
                        TblPatterns.Rows.Add(pattern, pattern.Name);
                    }
            }

            PatternMemberView.RowCount = patterns.Count;
        }
        /// <summary>
        /// すぷリッターの位置設定
        /// </summary>
        private void SetSplitterDistance () {
            float l = members.Count;
            float r = patterns.Count;
            float t = l + r;
            float w = 0;
            if (t == 0) {
                w = this.ClientSize.Width / 2;
            } else {
                w = this.ClientSize.Width * (r / t);
            }
            this.splitContainer1.SplitterDistance = (int)w;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void FavoriteEditor2_Layout (object sender, LayoutEventArgs e) {
            //this.splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            SetSplitterDistance();
        }

        private void MemberPatternView_CellValueNeeded (object sender, DataGridViewCellValueEventArgs e) {
            if (e.RowIndex >= this.members.Count) return; // 行数オーバー
            BMember member = members[e.RowIndex];
            if (e.ColumnIndex == 0) {
                // 1列目はメンバー
                e.Value = member.Name;
            } else {
                // 2列目以降は好みの順番（シフト）
                int index = e.ColumnIndex - 1;
                BPattern pattern = sdate.GetMembersPattern(member, index);
                e.Value = pattern;
            }
        }

        private void MemberPatternView_CellValuePushed (object sender, DataGridViewCellValueEventArgs e) {
            BMember member = members[e.RowIndex];
            if (e.ColumnIndex == 0) {
                // 1列目はメンバー（なにもしない）
            } else {
                // 2列目以降は好みの順番（シフト）
                int index = e.ColumnIndex - 1;
                if (e.Value is BPattern) {
                    BPattern pattern = e.Value as BPattern;
                    sdate.SetPatternRank(member, pattern, index);
                }
            }
        }

        private void PatternMemberView_CellValueNeeded (object sender, DataGridViewCellValueEventArgs e) {
            if (e.RowIndex >= this.patterns.Count) return; // 行数オーバー
            BPattern pattern = patterns[e.RowIndex];
            if (e.ColumnIndex == 0) {
                // 一列目はシフト
                e.Value = pattern.Name;
            } else {
                // 2列目以降は好みの順番（シフト）
                int index = e.ColumnIndex - 1;
                BMember member = sdate.GetPatternsMember(pattern, index);
                e.Value = member;
            }
        }

        private void PatternMemberView_CellValuePushed (object sender, DataGridViewCellValueEventArgs e) {
            BPattern pattern = patterns[e.RowIndex];
            if (e.ColumnIndex == 0) {
                // 一列目はシフト（なにもしない）
            } else {
                // 2列目以降は好みの順番（シフト）
                int index = e.ColumnIndex - 1;
                if (e.Value is BMember) {
                    BMember member = e.Value as BMember;
                    sdate.SetMemberRank(pattern, member, index);
                }
            }
        }

        private void FavoriteEditor2_Resize (object sender, EventArgs e) {
            //this.splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            SetSplitterDistance();
        }
    }
    /// <summary>
    /// メンバーをあらわすセル
    /// </summary>
    public class MemberCell : System.Windows.Forms.DataGridViewComboBoxCell {
        /// <summary>
        /// 値の設定時
        /// </summary>
        /// <param name="formattedValue"></param>
        /// <param name="cellStyle"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="valueTypeConverter"></param>
        /// <returns></returns>
        public override object ParseFormattedValue (
                 object formattedValue,
                 DataGridViewCellStyle cellStyle,
                 TypeConverter formattedValueTypeConverter,
                 TypeConverter valueTypeConverter) {
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
        /// <summary>
        /// 値の取得時
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object GetFormattedValue (
              object value, int rowIndex,
              ref DataGridViewCellStyle cellStyle,
              TypeConverter valueTypeConverter,
              TypeConverter formattedValueTypeConverter,
              DataGridViewDataErrorContexts context) {
            BMember ret = null;
            if (value != null && value is BMember) {
                ret = value as BMember;
            }
            return (ret == null) ? "" : ret.Name;
        }
    }
 
}
