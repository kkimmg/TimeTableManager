using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Element;

namespace TimeTableManager.Component {
    public partial class UMultiEditor : UserControl {
        #region プライベート
        /// <summary>バーのドラッグドロップ等の状態
        /// </summary>
        private enum EnumBarLabelStatus {
            None,
            StartMoving,
            EndMoving,
            AllMoving,
            Creating
        }
        /// <summary>バーのドラッグドロップ等の状態
        /// </summary>
        private EnumBarLabelStatus BarLabelStatus = EnumBarLabelStatus.None;
        /// <summary>メインフォーム
        /// </summary>
        private TimeTableManager.UI.FMainForm mainForm;
        /// <summary>タイムテーブル
        /// </summary>
        private BTimeTable timeTable;
        /// <summary>選択された日付
        /// </summary>
        private List<DateTime> dates;
        /// <summary>メンバーの一覧
        /// </summary>
        private List<BMember> members;
        /// <summary>勤務シフトのラッパー
        /// </summary>
        private class PatternWrapper {
            private BPattern pattern = BPattern.NULL;
            private TimeSpan startTime = TimeSpan.Zero;
            private TimeSpan endTime = TimeSpan.Zero;
            private string notes = "";
            /// <summary>勤務シフト
            /// </summary>
            public BPattern Pattern {
                get { return pattern; }
                set { pattern = value; }
            }
            /// <summary>開始時間
            /// </summary>
            public TimeSpan StartTime {
                get {
                    return startTime;
                }
                set { startTime = value; }
            }
            /// <summary>終了時間
            /// </summary>
            public TimeSpan EndTime {
                get {
                    if (pattern == null || (pattern.BuiltIn && pattern != BPattern.MULTI)) {
                        return StartTime;
                    }
                    while (StartTime > endTime) {
                        endTime = endTime.Add(TimeSpan.FromDays(1.0));
                    }
                    return endTime;
                }
                set { endTime = value; }
            }
            /// <summary>メモ
            /// </summary>
            public string Notes {
                get {
                    return notes;
                }
                set {
                    notes = value;
                }
            }
        }
        /// <summary>勤務シフトのラッパー
        /// </summary>
        private Dictionary<BMember, PatternWrapper> Member2PatternWrapper = new Dictionary<BMember, PatternWrapper>();
        /// <summary>開始時間
        /// </summary>
        private TimeSpan TableStart;    // 開始時間
        /// <summary>終了時間
        /// </summary>
        private TimeSpan TableEnd;      // 終了時間
        /// <summary>時間領域の幅
        /// </summary>
        private float TotalHours;       // 時間領域の幅
        /// <summary>30分前
        /// </summary>
        private TimeSpan AreaStartTime; // 30分前
        private const int SplitBuffer = 5;
        private const string NewPatternName = "新しい作業用のシフト（%1）";
        private const string NewPatternNotes = "臨時用の作業時間です。";
        private const string CreatePatternMessage = "このシフトを使用するのは今回限りでよろしいですか？\n継続して利用する予定がない場合は\"はい\"、\n継続して使用する場合は\"いいえ\"を押してください。";
        private const string CreatePatternTitle = "勤務シフトの継続使用の選択";
        private int CurrentRowIndex;
        private Point StartPoint, MovingPoint;
        /// <summary>バーの編集の閾値
        /// </summary>
        private static TimeSpan threshold = new TimeSpan(0, 15, 0);
        /// <summary>バーの編集の閾値
        /// </summary>
        public static TimeSpan Threshold {
            get {
                return threshold;
            }
            set {
                threshold = value;
            }
        }
        #endregion
        /// <summary>メインフォーム
        /// </summary>
        public TimeTableManager.UI.FMainForm MainForm {
            get {
                return mainForm;
            }
            set {
                mainForm = value;
                if (mainForm != null) {
                    mainForm.OnFileOpen += new TimeTableManager.UI.FMainForm.FileOpenEventHandler(mainForm_OnFileOpen);
                    mainForm.OnViewSelectionChanged += new TimeTableManager.UI.FMainForm.ViewSelectionChangedEventHandler(mainForm_OnViewSelectionChanged);
                    mainForm.OnTimeTableAutoEdited += new TimeTableManager.UI.FMainForm.TimeTableAutoEditedEventHandler(mainForm_OnTimeTableAutoEdited);
                }
            }
        }
        /// <summary>自動設定された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnTimeTableAutoEdited (object sender, TimeTableManager.UI.TimeTableAutoEditedEventArgs e) {
            SetUpValidMembers();
            SetUpValidPatterns();
            BodyTable.Refresh();
        }
        /// <summary>編集可能
        /// 過去の編集が可能な場合は編集可能
        /// </summary>
        public bool Editable {
            get {
                bool history = (MainForm == null ? false : MainForm.IsEditHistory);
                return (EndDate >= DateTime.Today || history);
            }
        }
        /// <summary>タイムテーブル
        /// </summary>
        public BTimeTable TimeTable {
            get { return timeTable; }
            set {
                if (timeTable != value) {
                    timeTable = value;
                    if (timeTable != null) {
                        timeTable.OnMembersEdited += new BTimeTable.MembersEditedEventHandler(timeTable_OnMembersEdited);
                        timeTable.OnPatternsEdited += new BTimeTable.PatternsEditedEventHandler(timeTable_OnPatternsEdited);
                        timeTable.OnScheduleEdited += new BTimeTable.ScheduleEditedEventHandler(timeTable_OnScheduleEdited);
                        this.BodyTable.ContextMenuStrip = this.CmsBodyTable;
                    }
                }
            }
        }
        /// <summary>スケジュールが編集されたとき、表示範囲内なら表示を更新する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnScheduleEdited (object sender, EScheduleEditedEventArgs e) {
            if (StartDate <= e.Schedule.Date.Date && e.Schedule.Date.Date <= EndDate) {
                //
                SetUpMember2Pattern(e.Schedule.Member);
                //
                BodyTable.Refresh();
                //
                Refresh();
            }
        }
        /// <summary>勤務シフトが編集されたらシフトの一覧を再編集する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnPatternsEdited (object sender, EPatternsEditedEventArgs e) {
            this.SetUpValidPatterns();
            Refresh();
        }
        /// <summary>メンバーが編集されたらメンバーの一覧を再編集する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnMembersEdited (object sender, EMembersEditedEventArgs e) {
            this.SetUpValidMembers();
            Refresh();
        }
        /// <summary>選択された日付
        /// </summary>
        public List<DateTime> Dates {
            get {
                if (dates == null) {
                    // nullなら初期化
                    dates = new List<DateTime>();
                }
                return dates;
            }
            set {
                dates = value;
                this.TsmiComment.Enabled = false;
                if (dates != null) {
                    dates.Sort();
                    if (dates.Count == 0) {
                        BodyTable.RowCount = 0;
                        Members.Clear();
                        Member2PatternWrapper.Clear();
                        TblPattern.Clear();
                    } else if (dates.Count == 1) {
                        BodyTable.ReadOnly = !Editable;
                        ClmMember.ReadOnly = true;
                        //ClmBarChart.ReadOnly = true;
                        ClmBarChart.ReadOnly = false;
                        // コメントの友好化
                        if (Editable) {
                            this.TsmiComment.Enabled = true;
                        }
                    } else if (dates.Count > 1) {
                        BodyTable.ReadOnly = !Editable;
                        ClmMember.ReadOnly = true;
                        ClmBarChart.ReadOnly = true;
                    }
                }
                // メンバーの一覧の作成
                SetUpValidMembers();
                // シフトの一覧の作成
                SetUpValidPatterns();
                // 座標の計算
                CalcTimes();
                // 表示の更新
                Refresh();
            }
        }
        /// <summary>選択範囲の開始
        /// </summary>
        private DateTime StartDate {
            get {
                return Dates[0];
            }
        }
        /// <summary>選択範囲の終了
        /// </summary>
        private DateTime EndDate {
            get {
                return Dates[Dates.Count - 1];
            }
        }
        /// <summary>メンバーの一覧の作成
        /// </summary>
        private void SetUpValidMembers () {
            Members.Clear();
            Member2PatternWrapper.Clear();
            if (TimeTable != null && Dates.Count > 0) {
                // 期間中有効なメンバーのみ
                int size = TimeTable.Members.Size(true);
                for (int i = 0; i < size; i++) {
                    BMember member = TimeTable.Members[i, true];
                    if (member.IsAvailable(StartDate, EndDate)) {
                        Members.Add(member);
                        SetUpMember2Pattern(member);
                    }
                }
            }
            BodyTable.RowCount = Members.Count;
        }
        /// <summary>勤務シフトの一覧の作成
        /// </summary>
        private void SetUpValidPatterns () {
            TblPattern.Clear();
            if (TimeTable != null && Dates.Count > 0) {
                // 期間中有効なシフトのみ
                int size = TimeTable.Patterns.Size(true);
                for (int i = 0; i < size; i++) {
                    BPattern pattern = TimeTable.Patterns[i, true];
                    if (pattern.IsAvailable(StartDate, EndDate)) {
                        TblPattern.Rows.Add(pattern, pattern.Name);
                    }
                }
                TblPattern.Rows.Add(BPattern.MULTI, BPattern.MULTI.Name);
            }
        }
        /// <summary>メンバーの就業状態の作成
        /// </summary>
        /// <param name="member"></param>
        private void SetUpMember2Pattern (BMember member) {
            PatternWrapper wrapper = new PatternWrapper();
            wrapper.Pattern = BPattern.NULL;
            wrapper.StartTime = TimeSpan.MaxValue;
            wrapper.EndTime = TimeSpan.MinValue;
            if ((member == null) || (Dates.Count <= 0) || (TimeTable == null)) {
                // 存在しない
                if (member != null && Member2PatternWrapper.ContainsKey(member)) {
                    Member2PatternWrapper.Remove(member);
                }
                return;
            } else {
                // 繰り返し
                int i = 0;
                foreach (DateTime date in Dates) {
                    BScheduledDate sdate = TimeTable[date];
                    BSchedule schedule = sdate[member];
                    BPattern work = schedule.Pattern;
                    if (i == 0) {
                        // 最初のシフト
                        wrapper.Pattern = work;
                        if (work != null && !work.BuiltIn) {
                            wrapper.StartTime = work.Start;
                            wrapper.EndTime = work.End;
                            i++;
                        }
                        wrapper.Notes = schedule.Notes;
                        //wrapper.Notes = schedule["notes"];
                    } else if (wrapper.Pattern != work) {
                        if (schedule.Notes != "") {
                            // メモの追加
                            wrapper.Notes += "," + schedule.Notes;
                        }
                        // 複数選択されている
                        wrapper.Pattern = BPattern.MULTI;
                        if (work != null && !work.BuiltIn) {
                            if (wrapper.StartTime > work.Start) {
                                wrapper.StartTime = work.Start;
                            }
                            if (wrapper.EndTime < work.End) {
                                wrapper.EndTime = work.End;
                            }
                        }
                        i++;
                    }
                    
                }
                // 追加する
                if (Member2PatternWrapper.ContainsKey(member)) {
                    Member2PatternWrapper[member] = wrapper;
                } else {
                    Member2PatternWrapper.Add(member, wrapper);
                }
            }
        }
        /// <summary>メンバーの一覧
        /// </summary>
        private List<BMember> Members {
            get {
                if (members == null) {
                    // nullなら初期化
                    members = new List<BMember>();
                }
                return members;
            }
            set { members = value; }
        }
        /// <summary>ファイルがオープンされた
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnFileOpen (object sender, TimeTableManager.UI.TimeTableChangedEventArgs e) {
            if (e.TimeTable != this.TimeTable) {
                this.TimeTable = e.TimeTable;
            }
            Dates = Dates;
        }
        /// <summary>対象範囲が変更になった
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnViewSelectionChanged (object sender, TimeTableManager.UI.ESelectionChangedEventArg e) {
            if (e.TimeTable != this.TimeTable) {
                this.TimeTable = e.TimeTable;
            }
            Dates = e.SelectedDates;
        }
        /// <summary>コンストラクタ
        /// </summary>
        public UMultiEditor () {
            InitializeComponent();
            // 都合による表示
            this.ClmDsPattern.DataType = typeof(BPattern);
            this.ClmPattern.CellTemplate = new PatternCell();
            this.ClmPattern.DataSource = this.DsPatten;
            this.ClmPattern.ValueMember = "TblPattern.ClmDsPattern";
            this.ClmPattern.DisplayMember = "TblPattern.ClmPatternName";
            this.ClmPattern.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ClmPattern.DisplayStyleForCurrentCellOnly = true;
            //
            //DataGridViewCellStyle style = this.ClmBarChart.DefaultCellStyle;
            //style.SelectionBackColor = this.ClmBarChart.DefaultCellStyle.BackColor;
            //style.SelectionForeColor = this.ClmBarChart.DefaultCellStyle.ForeColor;
            //this.ClmBarChart.DefaultCellStyle = style;
        }
        /// <summary>値の取得
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellValueNeeded (object sender, DataGridViewCellValueEventArgs e) {
            if (e.RowIndex >= Members.Count) return;// 行数を超えている
            BMember member = Members[e.RowIndex];
            switch (e.ColumnIndex) {
                case 0:
                    e.Value = member.Name;
                    break;
                case 1:
                    if (Member2PatternWrapper.ContainsKey(member)) {
                        e.Value = Member2PatternWrapper[member].Pattern;
                    }
                    break;
                default:
                    if (Member2PatternWrapper.ContainsKey(member)) {
                        e.Value = Member2PatternWrapper[member].Notes;
                    }
                    break;
            }
        }
        /// <summary>値のセット
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellValuePushed (object sender, DataGridViewCellValueEventArgs e) {
            BMember member = Members[e.RowIndex];
            switch (e.ColumnIndex) {
                case 0:
                    break;
                case 1:
                    if (this.TimeTable == null) return;
                    BPattern pattern = e.Value as BPattern;
                    if (pattern == BPattern.MULTI) return;
                    foreach (DateTime date in Dates) {
                        if (date >= DateTime.Today) {
                            BScheduledDate sdate = this.TimeTable[date];
                            BSchedule sche = sdate[member];
                            sche.Pattern = pattern;
                        }
                    }
                    SetUpMember2Pattern(member);
                    break;
                case 2:
                    if (Dates.Count == 1 && StartDate >= DateTime.Today) {
                        string val = e.Value as string;
                        if (val == null) val = "";
                        if (this.TimeTable != null) {
                            DateTime date = StartDate;
                            BScheduledDate sdate = this.TimeTable[date];
                            BSchedule sche = sdate[member];
                            sche.Notes = val;
                            //sche.SetProperty("notes", val);
                            this.timeTable.NotifyScheduleEdited(sche);
                            SetUpMember2Pattern(member);
                        }
                    }
                    break;
            }
        }
        /// <summary>セルの描画
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellPainting (object sender, DataGridViewCellPaintingEventArgs e) {
            Graphics g = e.Graphics;
            if (e.ColumnIndex == 2) {
                if (e.RowIndex == -1) {
                    PaintBarColumnHeader(sender, e);
                } else {
                    PaintBarColumn(sender, e);
                }
            }
        }
        /// <summary>時間の計算
        /// </summary>
        private void CalcTimes () {
            if (TimeTable != null) {
                TableStart = TimeTable.StartTime;//new TimeSpan(TimeTable.StartTime.Hours, 0, 0);// 開始時間
                TableEnd = TimeTable.EndTime;//new TimeSpan(TimeTable.EndTime.Hours, 0, 0);    // 終了時間
                //while (TableStart > TableEnd) { TableEnd = TableEnd.Add(TimeSpan.FromDays(1.0)); }
                TimeSpan TableSpan = TableEnd - TableStart;                                // 営業時間の幅
                TotalHours = TableSpan.Hours + 1;                          // 時間領域の幅
                AreaStartTime = TableStart.Subtract(TimeSpan.FromMinutes(30.0)); // 30分前               
            }
        }
        /// <summary>ヘッダ部分の描画
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void PaintBarColumnHeader (object sender, DataGridViewCellPaintingEventArgs e) {
            if (TimeTable != null) {
                e.Paint(e.CellBounds, e.PaintParts);
                float WidthOf1Hour = e.CellBounds.Width / (TotalHours);              // １時間の幅
                float AreaStart = e.CellBounds.X + (WidthOf1Hour / 2);      // 時間領域の開始位置

                Font font = this.Font;                                      // フォント
                Brush brush = System.Drawing.Brushes.Black;                 // ブラシ

                float top = e.CellBounds.Height - font.Height;              // 立て位置
                TimeSpan work = TableStart;                                 // 初期値
                for (int i = 0; i < TotalHours; i++) {
                    // 時刻を表示する
                    float WorkX = AreaStart + (WidthOf1Hour * i);
                    string text = work.Hours.ToString("00");
                    SizeF size = e.Graphics.MeasureString(text, font);      // サイズ
                    PointF point = new PointF(WorkX - (size.Width / 2), top);
                    RectangleF rect = new RectangleF(point, size);
                    e.Graphics.DrawString(text, font, brush, rect);
                    work = work.Add(TimeSpan.FromHours(1.0));
                }
                e.Handled = true;
            }
        }
        /// <summary>バー部分の描画
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void PaintBarColumn (object sender, DataGridViewCellPaintingEventArgs e) {
            if (TimeTable != null) {
                e.Paint(e.CellBounds, e.PaintParts);
                BMember member = Members[e.RowIndex];
                PatternWrapper wrapper = Member2PatternWrapper[member];
                e.Handled = true;
                float WidthOf1Hour = e.CellBounds.Width / (TotalHours);              // １時間の幅
                float AreaStart = e.CellBounds.X + (WidthOf1Hour / 2);      // 時間領域の開始位置
                #region １時間毎の縦線
                Pen pen = Pens.LightGray;
                TimeSpan work = TableStart;                                     // 初期値
                for (int i = 0; i < TotalHours; i++) {
                    // 時刻を表示する
                    float WorkX = AreaStart + (WidthOf1Hour * i);
                    PointF point1 = new PointF(WorkX, e.CellBounds.Top);
                    PointF point2 = new PointF(WorkX, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, point1, point2);
                    work = work.Add(TimeSpan.FromHours(1.0));
                }
                #endregion
                if (wrapper.Pattern == BPattern.NULL || wrapper.Pattern == BPattern.DAYOFF) {
                    // 休みなら処理しない
                    if (BarLabelStatus == EnumBarLabelStatus.Creating && CurrentRowIndex == e.RowIndex) {
                        float WorkW = (MovingPoint.X > StartPoint.X ? MovingPoint.X - StartPoint.X : StartPoint.X - MovingPoint.X);
                        float WorkX = (MovingPoint.X > StartPoint.X ? e.CellBounds.X + StartPoint.X : e.CellBounds.X + MovingPoint.X);
                        float WorkY = e.CellBounds.Y + e.CellBounds.Height / 4;
                        float WorkH = e.CellBounds.Height / 2;
                        e.Graphics.DrawRectangle(Pens.Black, WorkX, WorkY, WorkW, WorkH);
                    }
                } else {
                    // バーチャートの描画
                    RectangleF BarRect = GetPattern2Rect(e.CellBounds, wrapper);
                    Brush BarBrush = (member.IsChief ? Brushes.Red : Brushes.Blue);
                    e.Graphics.FillRectangle(BarBrush, BarRect);
                    // バーチャートの移動中
                    if (BarLabelStatus != EnumBarLabelStatus.None && CurrentRowIndex == e.RowIndex) {
                        float WorkW = (MovingPoint.X > StartPoint.X ? MovingPoint.X - StartPoint.X : StartPoint.X - MovingPoint.X);
                        float WorkX = (MovingPoint.X > StartPoint.X ? e.CellBounds.X + StartPoint.X : e.CellBounds.X + MovingPoint.X);
                        switch (BarLabelStatus) {
                            case EnumBarLabelStatus.StartMoving:
                                WorkW = BarRect.Width + (StartPoint.X - MovingPoint.X);
                                if (WorkW >= 0) {
                                    WorkX = BarRect.X + BarRect.Width - WorkW;
                                } else {
                                    WorkW = -WorkW;
                                    WorkX = BarRect.X + BarRect.Width;
                                }
                                break;
                            case EnumBarLabelStatus.EndMoving:
                                WorkX = BarRect.X;
                                WorkW = BarRect.Width + (MovingPoint.X - StartPoint.X);
                                if (WorkW < 0) {
                                    WorkW = -WorkW;
                                    WorkX = BarRect.X - WorkW;
                                }
                                break;
                            case EnumBarLabelStatus.AllMoving:
                                WorkX = BarRect.X + (MovingPoint.X - StartPoint.X);
                                WorkW = BarRect.Width;
                                break;
                        }
                        e.Graphics.DrawRectangle(Pens.LightGray, WorkX, BarRect.Top, WorkW, BarRect.Height);
                        Brush brush = (member.IsChief ? Brushes.Green : Brushes.HotPink);
                        e.Graphics.FillRectangle(brush, WorkX, BarRect.Top + (BarRect.Height / 2), WorkW, BarRect.Height / 2);
                    }
                }
                e.PaintContent(e.ClipBounds);
            }
        }
        /// <summary>座標の計算
        /// </summary>
        /// <param name="CellBounds"></param>
        /// <param name="wrapper"></param>
        /// <returns></returns>
        private RectangleF GetPattern2Rect (Rectangle CellBounds, PatternWrapper wrapper) {
            RectangleF BarRect = CellBounds;
            float WidthOf1Hour = CellBounds.Width / (TotalHours);              // １時間の幅
            BarRect.Y += CellBounds.Height / 4;
            BarRect.Height = CellBounds.Height / 2;
            TimeSpan PatternStart = wrapper.StartTime - AreaStartTime;
            TimeSpan PatternEnd = wrapper.EndTime - AreaStartTime;
            float RangeStart = (float)(PatternStart.TotalHours * WidthOf1Hour) + BarRect.X;
            float RangeEnd = (float)(PatternEnd.TotalHours * WidthOf1Hour) + BarRect.X;
            if (BarRect.X < RangeStart && RangeStart < BarRect.Right) {
                // 計算したバーの左端がセルのセルの表示範囲内に収まっている場合（収まっていなければセルの左端のまま）
                BarRect.X = RangeStart;
            //} else if (BarRect.X > RangeStart) {
            //    BarRect.X = BarRect.X;
            } else if (RangeStart > BarRect.Right) {
                BarRect.X = BarRect.Right;
            }
            if (BarRect.X < RangeEnd && RangeEnd < BarRect.Right) {
                // １．左右が逆転していないこと
                // ２．計算したバーの右端がセルのセル表示範囲内に収まっている場合幅を計算する（収まっていなければセルの右端のまま）
                BarRect.Width = RangeEnd - BarRect.X;
            } else if (BarRect.X > RangeEnd) {
                BarRect.Width = 0;
            }
            return BarRect;
        }
        /// <summary>マウスカーソルをどうする？
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellMouseMove (object sender, DataGridViewCellMouseEventArgs e) {
            if (this.TimeTable != null && e.RowIndex >= 0 && e.ColumnIndex == 2 && Editable) {
                BMember member = this.Members[e.RowIndex];
                PatternWrapper wrapper = Member2PatternWrapper[member];
                if (wrapper.Pattern != null && (!wrapper.Pattern.BuiltIn || wrapper.Pattern == BPattern.MULTI) && BarLabelStatus == EnumBarLabelStatus.None) {
                    Rectangle CellBounds1 = BodyTable.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Rectangle CellBounds2 = new Rectangle(new Point(0, 0), CellBounds1.Size);
                    RectangleF rect = GetPattern2Rect(CellBounds2, wrapper);
                    if (rect.Top < e.Y && e.Y < rect.Bottom) {
                        if (rect.X - SplitBuffer < e.X && e.X < rect.X + SplitBuffer) {
                            // 左端
                            this.Cursor = Cursors.VSplit;
                        } else if (rect.Right - SplitBuffer < e.X && e.X < rect.Right + SplitBuffer) {
                            // 右端
                            this.Cursor = Cursors.VSplit;
                        } else if (rect.X < e.X && e.X < rect.Right) {
                            // 内部
                            this.Cursor = Cursors.Hand;
                        } else {
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
                if (BarLabelStatus != EnumBarLabelStatus.None) {
                    MovingPoint = e.Location;
                    BodyTable.Refresh();
                }
            }
        }
        /// <summary>マウスダウン時ステータスを更新する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellMouseDown (object sender, DataGridViewCellMouseEventArgs e) {
            this.BarLabelStatus = EnumBarLabelStatus.None;
            CurrentRowIndex = e.RowIndex;
            if (this.TimeTable != null && CurrentRowIndex >= 0 && e.ColumnIndex == 2 && Editable) {
                BMember member = this.Members[CurrentRowIndex];
                PatternWrapper wrapper = Member2PatternWrapper[member];
                Rectangle CellBounds1 = BodyTable.GetCellDisplayRectangle(e.ColumnIndex, CurrentRowIndex, false);
                if (wrapper.Pattern != null && (!wrapper.Pattern.BuiltIn || wrapper.Pattern == BPattern.MULTI)) {
                    Rectangle CellBounds2 = new Rectangle(new Point(0, 0), CellBounds1.Size);
                    RectangleF rect = GetPattern2Rect(CellBounds2, wrapper);
                    if (rect.Top < e.Y && e.Y < rect.Bottom) {
                        if (rect.X - SplitBuffer < e.X && e.X < rect.X + SplitBuffer) {
                            // 左端
                            this.BarLabelStatus = EnumBarLabelStatus.StartMoving;
                        } else if (rect.Right - SplitBuffer < e.X && e.X < rect.Right + SplitBuffer) {
                            // 右端
                            this.BarLabelStatus = EnumBarLabelStatus.EndMoving;
                        } else if (rect.X < e.X && e.X < rect.Right) {
                            // 内部
                            this.BarLabelStatus = EnumBarLabelStatus.AllMoving;
                        }
                    }
                } else {
                    this.BarLabelStatus = EnumBarLabelStatus.Creating;
                }
                StartPoint = e.Location;
                MovingPoint = e.Location;
            }
        }
        /// <summary>閾値の半分
        /// </summary>
        private double Half {
            get {
                return Threshold.TotalHours / 2.0;
            }
        }
        /// <summary>マウスがあがったとき、バーチャートを更新する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellMouseUp (object sender, DataGridViewCellMouseEventArgs e) {
            EnumBarLabelStatus CurrentStatus = BarLabelStatus;
            BarLabelStatus = EnumBarLabelStatus.None;
            if (CurrentStatus != EnumBarLabelStatus.None && e.RowIndex >= 0) {

                //
                Rectangle CellBounds1 = BodyTable.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                //
                float MovingSpan0 = e.X - StartPoint.X;
                float MovingSpan1 = (e.X > StartPoint.X ? MovingSpan0 : -MovingSpan0);
                TimeSpan Span = GetXSpan2TimeSpan(CellBounds1.Width, StartPoint.X, e.X);
                if ((Span > TimeSpan.Zero ? Span.TotalHours > Half : Span.TotalHours < -Half)) {
                    Rectangle CellBounds2 = new Rectangle(new Point(0, 0), CellBounds1.Size);
                    BMember member = this.Members[e.RowIndex];
                    PatternWrapper wrapper;
                    TimeSpan SpanStart = TimeSpan.Zero, SpanEnd = TimeSpan.Zero, SpanRest = TimeSpan.Zero;
                    switch (CurrentStatus) {
                        case EnumBarLabelStatus.StartMoving:
                            wrapper = this.Member2PatternWrapper[member];
                            SpanStart = GetX2TimeSpan(CellBounds1.Width, e.X, TableStart);
                            SpanEnd = wrapper.EndTime;
                            SpanRest = wrapper.Pattern.Rest;
                            break;
                        case EnumBarLabelStatus.EndMoving:
                            wrapper = this.Member2PatternWrapper[member];
                            SpanStart = wrapper.StartTime;
                            SpanEnd = GetX2TimeSpan(CellBounds1.Width, e.X, TableStart);
                            SpanRest = wrapper.Pattern.Rest;
                            break;
                        case EnumBarLabelStatus.AllMoving:
                            wrapper = this.Member2PatternWrapper[member];
                            SpanStart = wrapper.StartTime + Span;
                            SpanEnd = wrapper.EndTime + Span;
                            SpanRest = wrapper.Pattern.Rest;
                            break;
                        case EnumBarLabelStatus.Creating:
                            SpanStart = GetX2TimeSpan(CellBounds1.Width, StartPoint.X, TableStart);
                            SpanEnd = GetX2TimeSpan(CellBounds1.Width, e.X, TableStart);
                            break;
                    }
                    if (SpanStart > SpanEnd) {
                        // スワップ
                        TimeSpan Swap = SpanStart;
                        SpanStart = SpanEnd;
                        SpanEnd = Swap;
                    }
                    //
                    CreatePattern(member, SpanStart, SpanEnd, TimeSpan.Zero);
                }
            }
            BodyTable.Refresh();
        }
        /// <summary>X座標からテーブル（列）上の時間へ変換する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="X"></param>
        /// <param name="StartOffset"></param>
        /// <returns></returns>
        private TimeSpan GetX2TimeSpan (float width, float X, TimeSpan StartOffset) {
            float WidthOf1Hour = width / TotalHours;              // １時間の幅
            float AreaStart = WidthOf1Hour / 2;                   // 時間領域の開始位置
            float sabun = (X - AreaStart) / WidthOf1Hour;
            return StartOffset + TimeSpan.FromHours(sabun);
        }
        /// <summary>X座標（差）からテーブル（列）上の時間へ変換する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="X1"></param>
        /// <param name="X2"></param>
        /// <returns></returns>
        private TimeSpan GetXSpan2TimeSpan (float width, float X1, float X2) {
            float WidthOf1Hour = width / TotalHours;              // １時間の幅
            float sabun = (X2 - X1) / WidthOf1Hour;
            return TimeSpan.FromHours(sabun);
        }
        /// <summary>勤務シフトを作成する
        /// </summary>
        /// <param name="member"></param>
        /// <param name="Span1"></param>
        /// <param name="Span2"></param>
        /// <param name="Rest"></param>
        private void CreatePattern (BMember member, TimeSpan Span1, TimeSpan Span2, TimeSpan Rest) {
            double dSpan1 = (long)(Span1.TotalHours / UMultiEditor.Threshold.TotalHours);
            double dSpan2 = (long)(Span2.TotalHours / UMultiEditor.Threshold.TotalHours);
            double dSpan3 = dSpan2 - dSpan1;
            BPattern newpattern = this.TimeTable.Patterns.CreatePattern();
            //newpattern.Name = "新しい作業用のシフト（" + dates[0].ToShortDateString() + (dates.Count <= 1 ? "" : "～" + dates[dates.Count - 1].ToShortDateString()) + "）";
            newpattern.Name = NewPatternName.Replace("%1", dates[0].ToShortDateString() + (dates.Count <= 1 ? "" : "～" + dates[dates.Count - 1].ToShortDateString()));
            newpattern.Start = TimeSpan.FromHours(dSpan1 * UMultiEditor.Threshold.TotalHours);
            newpattern.Scope = TimeSpan.FromHours(dSpan3 * UMultiEditor.Threshold.TotalHours);
            newpattern.Rest = Rest;
            newpattern.Notes = NewPatternNotes;
            newpattern.Created = dates[0];
            TimeTableManager.UI.FPatternDialog dialog = new TimeTableManager.UI.FPatternDialog();
            dialog.Pattern = newpattern;
            if (dialog.ShowDialog(MainForm) == DialogResult.OK) {
                TimeTable.Patterns.AddPattern(dialog.Pattern);
                foreach (DateTime date in dates) {
                    if (date >= DateTime.Today) {
                        BScheduledDate sdate = TimeTable[date];
                        sdate[member].Pattern = dialog.Pattern;
                    }
                }
                // 臨時用のみかどうか
                if (TimeTable.Patterns.Size() >= TimeTableManager.UI.FMainForm.MaxItemCount || MessageBox.Show(this.MainForm, CreatePatternMessage, CreatePatternTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                    newpattern.SetAvailable(false, dates[dates.Count - 1]);
                }
            }
        }
        /// <summary>ダブルクリック時の処理
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellMouseDoubleClick (object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                BMember member = this.Members[e.RowIndex];
                switch (e.ColumnIndex) {
                    case 0:
                        // メンバーの修正
                        TimeTableManager.UI.FMemberDialog dialogM = new TimeTableManager.UI.FMemberDialog();
                        dialogM.Member = member;
                        if (dialogM.ShowDialog(this.MainForm) == DialogResult.OK) {
                            Refresh();
                        }
                        break;
                    case 1:
                        // シフトの修正
                        PatternWrapper wrapper = Member2PatternWrapper[member];
                        BPattern pattern = wrapper.Pattern;
                        if (pattern != null && !pattern.BuiltIn) {
                            TimeTableManager.UI.FPatternDialog dialogP = new TimeTableManager.UI.FPatternDialog();
                            dialogP.Pattern = pattern;
                            if (dialogP.ShowDialog(this.MainForm) == DialogResult.OK) {
                                Refresh();
                            }
                        }
                        break;
                    case 2:
                        // コメントの追加・修正
                        if (Dates.Count == 1 && Editable) {
                            BodyTable.CurrentCell = BodyTable[e.ColumnIndex, e.RowIndex];
                            BodyTable.BeginEdit(true);
                        }
                        break;
                }
            } else {
            }
        }
        /// <summary>メンバーの追加
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiAddMember_Click (object sender, EventArgs e) {
            if (this.TimeTable == null) return;
            if (this.TimeTable.Members.Size() >= TimeTableManager.UI.FMainForm.MaxItemCount) return;
            BMember member = this.TimeTable.Members.CreateMember(true);
            TimeTableManager.UI.FMemberDialog dialog = new TimeTableManager.UI.FMemberDialog();
            dialog.Member = member;
            if (dialog.ShowDialog(this.MainForm) == DialogResult.OK) {
                this.TimeTable.Members.AddMember(member);
            }
        }
        /// <summary>メンバーの修正
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiEditMember_Click (object sender, EventArgs e) {
            BMember member = this.Members[CurrentRowIndex];
            TimeTableManager.UI.FMemberDialog dialog = new TimeTableManager.UI.FMemberDialog();
            dialog.Member = member;
            if (dialog.ShowDialog(this.MainForm) == DialogResult.OK) {
                //SetUpMember2Pattern(member);
                Refresh();
            }
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiRemoveMember_Click (object sender, EventArgs e) {
            BMember member = this.Members[CurrentRowIndex];
            TimeTableManager.UI.FMemberDialog dialog = new TimeTableManager.UI.FMemberDialog();
            dialog.Member = member;
            member.SetAvailable(false, StartDate.AddDays(-1.0));
            if (dialog.ShowDialog(this.MainForm) == DialogResult.OK) {
                this.timeTable.Members.DelMember(member);
                //SetUpValidMembers();
            } else {
                member.SetAvailable(true);
            }
        }
        /// <summary>勤務シフトの追加
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiAddPattern_Click (object sender, EventArgs e) {
            if (this.TimeTable == null) return;
            if (this.TimeTable.Patterns.Size() >= TimeTableManager.UI.FMainForm.MaxItemCount) return;
            BPattern pattern = this.TimeTable.Patterns.CreatePattern(true);
            TimeTableManager.UI.FPatternDialog dialog = new TimeTableManager.UI.FPatternDialog();
            dialog.Pattern = pattern;
            if (dialog.ShowDialog(this.MainForm) == DialogResult.OK) {
                this.TimeTable.Patterns.AddPattern(pattern);
            }
        }
        /// <summary>勤務シフトの修正
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiEditPattern_Click (object sender, EventArgs e) {
            BMember member = this.Members[CurrentRowIndex];
            PatternWrapper wrapper = Member2PatternWrapper[member];
            BPattern pattern = wrapper.Pattern;
            if (pattern != null && !pattern.BuiltIn) {
                TimeTableManager.UI.FPatternDialog dialog = new TimeTableManager.UI.FPatternDialog();
                dialog.Pattern = pattern;
                if (dialog.ShowDialog(this.MainForm) == DialogResult.OK) {
                    Refresh();
                }
            }
        }
        /// <summary>勤務シフトの削除
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiRemovePattern_Click (object sender, EventArgs e) {
            BMember member = this.Members[CurrentRowIndex];
            PatternWrapper wrapper = Member2PatternWrapper[member];
            BPattern pattern = wrapper.Pattern;
            if (pattern != null && !pattern.BuiltIn) {
                TimeTableManager.UI.FPatternDialog dialog = new TimeTableManager.UI.FPatternDialog();
                dialog.Pattern = pattern;
                pattern.SetAvailable(false, StartDate.AddDays(-1.0));
                if (dialog.ShowDialog(this.MainForm) == DialogResult.OK) {
                    this.TimeTable.Patterns.DelPattern(pattern);
                    SetUpValidMembers();
                    Refresh();
                } else {
                    pattern.SetAvailable(true);
                }
            }
        }
        /// <summary>コメントの追加・修正
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TsmiComment_Click (object sender, EventArgs e) {
            if (Dates.Count == 1 && Editable) {
                //Member member = this.Members[this.CurrentRowIndex];
                //DateTime date = dates[0];
                //Schedule schedule = this.TimeTable[date][member];
                //string comment = schedule.Notes;
                //comment = InputBox.Show(MainForm, comment);
                //if (!comment.Equals(schedule.Notes)) {
                //    schedule.Notes = comment;
                //    BodyTable.Refresh();
                //}
                BodyTable.CurrentCell = BodyTable[2, CurrentRowIndex];
                BodyTable.BeginEdit(true);
            }
        }
        /// <summary>セルの編集可能
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BodyTable_CellEnter (object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 1) {
                if (Editable && e.RowIndex >= 0) {
                    BodyTable.BeginEdit(true);
                }
            }
        }
    }
}
