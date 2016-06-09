using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TimeTableManager.Component;
using TimeTableManager.Element;
using TimeTableManager.Printing;

namespace TimeTableManager.UI {
    /// <summary>
    /// ScheduleConfigDialog の概要の説明です。
    /// </summary>
    public partial class FScheduleConfigDialog : System.Windows.Forms.Form {
        private CTimeTable timeTable;
        private CTimeTable.DayOffsEditedEventHandler doeehandler;
        private CTimeTable.MembersEditedEventHandler moeehandler;
        private CTimeTable.PatternsEditedEventHandler peeehandler;
        private CTimeTable.RequirePatternssEditedEventHandler rpeehandler;
        /// <summary>コンストラクタ
        /// </summary>
        public FScheduleConfigDialog() {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();
            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
            #region データ型
            this.MemberColumn.DataType = typeof(TimeTableManager.Element.CMember);
            this.PatternColumn.DataType = typeof(TimeTableManager.Element.CPattern);
            this.DayOffColumn.DataType = typeof(TimeTableManager.Element.CDayOff);
            this.RequirePatternsColumn.DataType = typeof(TimeTableManager.Element.CRequirePatterns);
            this.ClmRM.DataType = typeof(TimeTableManager.Element.CMember);
            this.ClmRP.DataType = typeof(TimeTableManager.Element.CPattern);
            this.ClmRD.DataType = typeof(TimeTableManager.Element.CDayOff);
            this.ClmRR.DataType = typeof(TimeTableManager.Element.CRequirePatterns);
            //this.DayOffStartColumn.DataType = typeof(System.DateTime);
            //this.DayOffEndColumn.DataType = typeof(System.DateTime);
            //this.WeekDayColumn.DataType = typeof(System.DayOfWeek);
            #endregion
        }
        /// <summary>OK処理
        /// </summary>
        private void btnOK_Click(object sender, System.EventArgs e) {
            #region デフォルト
            {
                this.timeTable.StartTime = this.txtStartTime.Value - txtStartTime.MinDate;
                this.timeTable.EndTime = this.txtEndTime.Value - txtEndTime.MinDate;
                this.timeTable.DefaultRequire = this.cmbDefaultRequire.SelectedValue as CRequirePatterns;
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Monday, this.cmbMondayRequire.SelectedValue as CRequirePatterns);
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Tuesday, this.cmbTuesdayRequire.SelectedValue as CRequirePatterns);
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Wednesday, this.cmbWednesdayRequire.SelectedValue as CRequirePatterns);
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Thursday, this.cmbThursdayRequire.SelectedValue as CRequirePatterns);
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Friday, this.cmbFridayRequire.SelectedValue as CRequirePatterns);
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Saturday, this.cmbSaturdayRequire.SelectedValue as CRequirePatterns);
                this.timeTable.SetDefaultRequire(System.DayOfWeek.Sunday, this.cmbSundayRequire.SelectedValue as CRequirePatterns);
            }
            #endregion
            #region 印刷形式
            {
                // ヘッダーフォント
                CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentBody.RIT_HEADERFONT, dlgHeaderFont.Font);
                // 日付のフォント
                CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentBody.RIT_DATEFONT, dlgDateFont.Font);
                TimeTable[CPrintDocumentBody.RIT_DATEFORMAT] = cmbBodyFormat.Text;
                // 本体のフォント
                CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentBody.RIT_BODYFONT, dlgBodyFont.Font);
                // 人員配置を表示する
                TimeTable[CPrintDocumentBody.RIT_ISDISPLAYREQUIRE] = chkDisplayRequire.Checked.ToString();
                // 月で改ページ
                TimeTable[CPrintDocumentBody.RIT_ISMONTHLY] = chkMonthly.Checked.ToString();
                // 行数
                TimeTable[CPrintDocumentBody.RIT_ROWCOUNT] = nupBreakRow.Value.ToString();
                // 列数
                TimeTable[CPrintDocumentBody.RIT_COLUMNCOUNT] = nupBreakColumn.Value.ToString();
                // イメージプリント
                TimeTable[CPrintDocumentBody.RIT_IMAGEPRINT] = chkImage.Checked.ToString();
            }
            #endregion
        }
        /// <summary>ダブルクリックでシフトの修正
        /// </summary>
        private void lstPatterns_DoubleClick(object sender, EventArgs e) {
            DataRowView view = (DataRowView)this.lstPatterns.SelectedItem;
            CPattern pattern = view.Row["PatternColumn"] as CPattern;
            if (pattern != null) {
                FPatternDialog dialog = new FPatternDialog();
                dialog.Pattern = pattern;
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    view.Row["PatternName"] = pattern.Name;
                }
            }
        }
        /// <summary>コンボボックス等の初期値をセットする
        /// </summary>
        private void ScheduleConfigDialog_VisibleChanged(object sender, System.EventArgs e) {
            //if (this.Visible) {
            //    SetInitialValues();
            //}
        }
        /// <summary>初期値の設定
        /// </summary>
        private void SetInitialValues() {
            if (timeTable != null) {
                #region 曜日設定（リストボックス）
                {
                    DayOfWeek dow;
                    DataRow row;
                    dow = DayOfWeek.Monday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "月曜日";
                    this.WeekDayTable.Rows.Add(row);
                    dow = DayOfWeek.Tuesday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "火曜日";
                    this.WeekDayTable.Rows.Add(row);
                    dow = DayOfWeek.Wednesday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "水曜日";
                    this.WeekDayTable.Rows.Add(row);
                    dow = DayOfWeek.Thursday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "木曜日";
                    this.WeekDayTable.Rows.Add(row);
                    dow = DayOfWeek.Friday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "金曜日";
                    this.WeekDayTable.Rows.Add(row);
                    dow = DayOfWeek.Saturday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "土曜日";
                    this.WeekDayTable.Rows.Add(row);
                    dow = DayOfWeek.Sunday;
                    row = this.WeekDayTable.NewRow();
                    row["WeekDayColumn"] = dow;
                    row["WeekDayName"] = "日曜日";
                    this.WeekDayTable.Rows.Add(row);
                }
                #endregion
                // 営業時間
                txtStartTime.Value = txtStartTime.MinDate + timeTable.StartTime;
                txtEndTime.Value = txtStartTime.Value + timeTable.Around;
                #region デフォルトの人員配置
                SetupDefaultRequireComobs();
                #endregion
                #region シフト
                RebuildPatternList();
                #endregion
                #region メンバー
                RebuildMemberList();
                #endregion
                #region 休日
                RebuildHollyDayList();
                #endregion
                #region 人員配置
                RebuildRequireList();
                #endregion
                #region 印刷設定
                {
                    string work = null;
                    bool bork = false;
                    int iork = 0;
                    // ヘッダフォント
                    dlgHeaderFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentBody.RIT_HEADERFONT);
                    // 日付のフォント
                    dlgDateFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentBody.RIT_DATEFONT);
                    work = TimeTable[CPrintDocumentBody.RIT_DATEFORMAT];
                    if (work != null) {
                        cmbBodyFormat.Text = work;
                    } else {
                        cmbBodyFormat.Text = CPrintDocumentBody.RIT_DATEFORMAT_DEFAULT;
                    }
                    // 本体のフォント
                    dlgBodyFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentBody.RIT_BODYFONT);
                    // 人員配置を表示する
                    work = TimeTable[CPrintDocumentBody.RIT_ISDISPLAYREQUIRE];
                    bork = CPrintDocumentBody.RIT_ISDISPLAYREQUIRE_DEFAULT;
                    if (work != null) {
                        if (!(bool.TryParse(work, out bork))) {
                            bork = CPrintDocumentBody.RIT_ISDISPLAYREQUIRE_DEFAULT;
                        }
                    }
                    chkDisplayRequire.Checked = bork;
                    // 月で改ページ
                    work = TimeTable[CPrintDocumentBody.RIT_ISMONTHLY];
                    bork = CPrintDocumentBody.RIT_ISMONTHLY_DEFAULT;
                    if (work != null) {
                        if (!(bool.TryParse(work, out bork))) {
                            bork = CPrintDocumentBody.RIT_ISMONTHLY_DEFAULT;
                        }
                    }
                    chkMonthly.Checked = bork;
                    // 行数
                    work = TimeTable[CPrintDocumentBody.RIT_ROWCOUNT];
                    iork = 0;
                    if (work != null) {
                        if (!(int.TryParse(work, out iork))) {
                            iork = 0;
                        }
                    }
                    nupBreakRow.Value = iork;
                    // 列数
                    work = TimeTable[CPrintDocumentBody.RIT_COLUMNCOUNT];
                    iork = 0;
                    if (work != null) {
                        if (!(int.TryParse(work, out iork))) {
                            iork = 0;
                        }
                    }
                    nupBreakColumn.Value = iork;
                    // イメージプリント
                    work = TimeTable[CPrintDocumentBody.RIT_IMAGEPRINT];
                    bork = CPrintDocumentBody.RIT_IMAGEPRINT_DEFAULT;
                    if (work != null) {
                        if (!(bool.TryParse(work, out bork))) {
                            bork = CPrintDocumentBody.RIT_IMAGEPRINT_DEFAULT;
                        }
                    }
                    chkImage.Checked = bork;
                }
                #endregion
                #region 削除済みのアイテム
                RebuildRemovedItems();
                #endregion
            }
        }
        /// <summary>人員配置コンボボックスの再設定
        /// </summary>
        private void SetupDefaultRequireComobs() {
            #region デフォルトの人員配置
            SetUpDefaultRequireTable(DefaultTable);
            SetUpDefaultRequireTable(MondayTable);
            SetUpDefaultRequireTable(TuesdayTable);
            SetUpDefaultRequireTable(WednesdayTable);
            SetUpDefaultRequireTable(ThursdayTable);
            SetUpDefaultRequireTable(FridayTable);
            SetUpDefaultRequireTable(SaturdayTable);
            SetUpDefaultRequireTable(SundayTable);
            #endregion
            #region デフォルトの人員配置（その２）
            SetUpDefaultRequireCombo(DefaultTable, cmbDefaultRequire, timeTable.DefaultRequire);
            SetUpDefaultRequireCombo(DefaultTable, cmbMondayRequire, timeTable.GetDefaultRequire(DayOfWeek.Monday));
            SetUpDefaultRequireCombo(DefaultTable, cmbTuesdayRequire, timeTable.GetDefaultRequire(DayOfWeek.Tuesday));
            SetUpDefaultRequireCombo(DefaultTable, cmbWednesdayRequire, timeTable.GetDefaultRequire(DayOfWeek.Wednesday));
            SetUpDefaultRequireCombo(DefaultTable, cmbThursdayRequire, timeTable.GetDefaultRequire(DayOfWeek.Thursday));
            SetUpDefaultRequireCombo(DefaultTable, cmbFridayRequire, timeTable.GetDefaultRequire(DayOfWeek.Friday));
            SetUpDefaultRequireCombo(DefaultTable, cmbSaturdayRequire, timeTable.GetDefaultRequire(DayOfWeek.Saturday));
            SetUpDefaultRequireCombo(DefaultTable, cmbSundayRequire, timeTable.GetDefaultRequire(DayOfWeek.Sunday));
            #endregion
        }
        /// <summary>人員配置テーブルをセットアップする
        /// </summary>
        /// <param name="table"></param>
        private void SetUpDefaultRequireTable(DataTable table) {
            table.Clear();
            int size = timeTable.Requires.Size(true);
            for (int i = 0; i < size; i++) {
                CRequirePatterns require = timeTable.Requires[i, true];
                if (require.Removed == null) {
                    object[] rowdata = { require, require.Name };
                    table.Rows.Add(rowdata);
                }
            }
        }
        /// <summary>人員配置コンボボックスをセットアップする
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="combo">コンボボックス</param>
        /// <param name="require">人員配置</param>
        private void SetUpDefaultRequireCombo(DataTable table, ComboBox combo, CRequirePatterns require) {
            int i = 0;
            foreach (DataRow drv in table.Rows) {
                if (drv[0] == require) {
                    combo.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }
        /// <summary>勤務シフトの処理
        /// </summary>
        private void PatternToolBar_Click(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
            if (e.Button == this.btnAddPattern) {
                if (timeTable.Patterns.Size() >= FMainForm.MaxItemCount) {
                    MessageBox.Show(this, "勤務シフトは%1個までしか登録できません。".Replace("%1", FMainForm.MaxItemCount.ToString()), "勤務シフトの追加の上限", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                FPatternDialog dialog = new FPatternDialog();
                dialog.Pattern = timeTable.Patterns.CreatePattern(true);
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    timeTable.Patterns.AddPattern(dialog.Pattern);
                    // 一覧の更新
                    RebuildPatternList();
                    // すべてのメンバーに追加する？
                    int j = timeTable.Members.Size(true);
                    if (j > 0 && MessageBox.Show(this, "すべてのメンバーに対して有効にしますか？", "勤務シフトの追加", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        for (int i = 0; i < j; i++) {
                            CMember member = timeTable.Members[i, true];
                            if (member.Removed == null && !member.BuiltIn) {
                                member.AddPattern(dialog.Pattern);
                            }
                        }
                    }
                }
            } else if (e.Button == this.btnEditPattern) {
                DataRowView view = (DataRowView)this.lstPatterns.SelectedItem;
                CPattern pattern = view.Row["PatternColumn"] as CPattern;
                if (pattern != null) {
                    FPatternDialog dialog = new FPatternDialog();
                    dialog.Pattern = pattern;
                    if (dialog.ShowDialog(this) == DialogResult.OK) {
                        // 一覧の更新
                        RebuildPatternList();
                    }
                }
            } else if (e.Button == this.btnDeletePattern) {
                DataRowView view = (DataRowView)this.lstPatterns.SelectedItem;
                CPattern pattern = view.Row["PatternColumn"] as CPattern;
                if (pattern != null) {
                    FPatternDialog dialog = new FPatternDialog();
                    dialog.Pattern = pattern;
                    pattern.SetAvailable(false);
                    if (dialog.ShowDialog(this) == DialogResult.OK) {
                        timeTable.Patterns.DelPattern(pattern);
                        // 一覧の更新
                        RebuildPatternList();
                    } else {
                        pattern.SetAvailable(true);
                    }
                }
            }
        }
        /// <summary>勤務シフトリストの再作成
        /// </summary>
        private void RebuildPatternList() {
            this.PatternTable.Clear();
            int patsize = timeTable.Patterns.Size(true);
            for (int i = 0; i < patsize; i++) {
                CPattern pat = timeTable.Patterns[i, true];
                if (!pat.BuiltIn && pat.Removed == null) {
                    DataRow row = this.PatternTable.NewRow();
                    row["PatternColumn"] = pat;
                    row["PatternName"] = pat.Name;
                    this.PatternTable.Rows.Add(row);
                }
            }
        }
        /// <summary>メンバーのツールバー処理
        /// </summary>
        private void MemberToolBar_Click(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
            if (e.Button == this.BtnAddMember) {
                #region 追加
                if (timeTable.Members.Size() >= FMainForm.MaxItemCount) {
                    MessageBox.Show(this, "メンバーは%1人までしか登録できません。".Replace("%1", FMainForm.MaxItemCount.ToString()), "メンバーの追加の上限", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                CMember workval = timeTable.Members.CreateMember(true);
                FMemberDialog dialog = new FMemberDialog();
                dialog.Member = workval;//sAll.Members.CreateMember()
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    timeTable.Members.AddMember(dialog.Member);
                    // 一覧の更新
                    RebuildMemberList();
                }
                #endregion
            } else if (e.Button == this.BtnEditMember) {
                #region 修正
                DataRowView view = (DataRowView)this.lstMembers.SelectedItem;
                CMember Member = view.Row["MemberColumn"] as CMember;
                if (Member != null) {
                    FMemberDialog dialog = new FMemberDialog();
                    dialog.Member = Member;
                    if (dialog.ShowDialog(this) == DialogResult.OK) {
                        view.Row["MemberName"] = Member.Name;
                        // 一覧の更新
                        RebuildMemberList();
                    }
                }
                #endregion
            } else if (e.Button == this.BtnDeleteMember) {
                #region 削除
                DataRowView view = (DataRowView)this.lstMembers.SelectedItem;
                CMember Member = view.Row["MemberColumn"] as CMember;
                if (Member != null) {
                    //if (MessageBox.Show(this, Member.Name + "を削除しますか？", "メンバーの削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                    FMemberDialog dialog = new FMemberDialog();
                    Member.SetAvailable(false);
                    dialog.Member = Member;
                    if (dialog.ShowDialog(this) == DialogResult.OK) {
                        timeTable.Members.DelMember(Member);
                        // 一覧の更新
                        RebuildMemberList();
                    } else {
                        Member.SetAvailable(true);
                    }
                }
                #endregion
            }
        }
        /// <summary>メンバーリストの再作成
        /// </summary>
        private void RebuildMemberList() {
            this.MemberTable.Clear();
            int memsize = timeTable.Members.Size(true);
            for (int i = 0; i < memsize; i++) {
                CMember mem = timeTable.Members[i, true];
                if (mem.Removed == null) {
                    DataRow row = this.MemberTable.NewRow();
                    row["MemberColumn"] = mem;
                    row["MemberName"] = mem.Name;
                    this.MemberTable.Rows.Add(row);
                }
            }
        }
        /// <summary>ダブルクリックでメンバーの修正
        /// </summary>
        private void lstMembers_DoubleClick(object sender, EventArgs e) {
            DataRowView view = (DataRowView)this.lstMembers.SelectedItem;
            CMember Member = view.Row["MemberColumn"] as CMember;
            if (Member != null) {
                FMemberDialog dialog = new FMemberDialog();
                dialog.Member = Member;
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    view.Row["MemberName"] = Member.Name;
                    // 一覧の更新
                    this.MemberTable.Clear();
                    int memsize = timeTable.Members.Size();
                    for (int i = 0; i < memsize; i++) {
                        CMember mem = timeTable.Members[i];
                        DataRow row = this.MemberTable.NewRow();
                        row["MemberColumn"] = mem;
                        row["MemberName"] = mem.Name;
                        this.MemberTable.Rows.Add(row);
                    }
                }
            }
        }
        /// <summary>休日リストの再作成
        /// </summary>
        private void RebuildHollyDayList() {
            this.DayOffTable.Clear();
            int offsize = timeTable.DayOffs.Size();
            for (int i = 0; i < offsize; i++) {
                CDayOff off = timeTable.DayOffs[i];
                DataRow row = this.DayOffTable.NewRow();
                row["DayOffColumn"] = off;
                row["DayOffNameColumn"] = off.Name;
                row["DayOffStartColumn"] = off.StartDate;
                row["DayOffEndColumn"] = off.EndDate;
                this.DayOffTable.Rows.Add(row);
            }
        }
        /// <summary>休日のツールバー処理
        /// </summary>
        private void HollyDayToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
            if (e.Button == this.TbbAddDayOff) {
                if (timeTable.DayOffs.Size() >= FMainForm.MaxItemCount) {
                    MessageBox.Show(this, "休日は%1個までしか登録できません。".Replace("%1", FMainForm.MaxItemCount.ToString()), "休日の追加の上限", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                // 日付の追加 
                TimeTableManager.UI.FDayOffDialog dialog = new FDayOffDialog();
                dialog.DayOff = this.timeTable.DayOffs.CreateDayOff(true);
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    // 休日の追加
                    this.timeTable.DayOffs.AddDayOff(dialog.DayOff);
                    // 一覧の再作成
                    RebuildHollyDayList();
                }
            } else if (e.Button == this.TbbEditDayOff) {
                // 日付の修正 
                TimeTableManager.UI.FDayOffDialog dialog = new FDayOffDialog();
                DataRowView view = (DataRowView)this.DayOffList.SelectedItem;
                DataRow row = view.Row;
                dialog.DayOff = row["DayOffColumn"] as CDayOff;
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    // 一覧の再作成
                    RebuildHollyDayList();
                }
            } else if (e.Button == this.TbbRemoveDayOff) {
                // 日付の削除
                TimeTableManager.UI.FDayOffDialog dialog = new FDayOffDialog();
                DataRowView view = (DataRowView)this.DayOffList.SelectedItem;
                DataRow row = view.Row;
                CDayOff dayoff = row["DayOffColumn"] as CDayOff;
                string message = "休日：" + dayoff.Name + "(" +
                    (dayoff.StartDate == dayoff.EndDate ?
                    dayoff.StartDate.ToShortDateString() :
                    dayoff.StartDate.ToShortDateString() + "～" + dayoff.EndDate.ToShortDateString())
                + ")を削除してよろしいですか？";
                if (MessageBox.Show(this, message, "休日の削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    dayoff.SetAvailable(false);
                    timeTable.DayOffs.DeleteDayOff(dayoff);
                    // 一覧の再作成
                    RebuildHollyDayList();
                }
            }
        }
        /// <summary>人員配置リストの再作成
        /// </summary>
        private void RebuildRequireList() {
            this.RequirePatternsTable.Clear();
            int reqsize = timeTable.Requires.Size(true);
            for (int i = 0; i < reqsize; i++) {
                CRequirePatterns req = timeTable.Requires[i, true];
                if (!req.BuiltIn && req.Removed == null) {
                    DataRow row = this.RequirePatternsTable.NewRow();
                    row["RequirePatternsColumn"] = req;
                    row["RequirePatternsName"] = req.Name;
                    this.RequirePatternsTable.Rows.Add(row);
                }
            }
        }
        /// <summary>人員配置のツールバー処理
        /// </summary>
        private void RequiresToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
            if (e.Button == this.TbbAddRequires) {
                if (timeTable.Requires.Size() >= FMainForm.MaxItemCount) {
                    MessageBox.Show(this, "人員配置は%1個までしか登録できません。".Replace("%1", FMainForm.MaxItemCount.ToString()), "人員配置の追加の上限", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                // 人員配置の追加 
                TimeTableManager.UI.FRequirePatternsDialog dialog = new FRequirePatternsDialog();
                dialog.Require = this.timeTable.Requires.CreateRequirePatterns(true);
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    //
                    this.timeTable.Requires.AddRequirePatterns(dialog.Require);
                    // 一覧の再作成
                    RebuildRequireList();
                }
            } else if (e.Button == this.TbbEditRequires) {
                // 人員配置の修正 
                TimeTableManager.UI.FRequirePatternsDialog dialog = new FRequirePatternsDialog();
                DataRowView view = (DataRowView)this.lstRequirePatterns.SelectedItem;
                DataRow row = view.Row;
                CRequirePatterns require = row["RequirePatternsColumn"] as CRequirePatterns;
                dialog.Require = require;
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    // 一覧の再作成
                    RebuildRequireList();
                }
            } else if (e.Button == this.TbbDelRequires) {
                // 人員配置の削除
                TimeTableManager.UI.FRequirePatternsDialog dialog = new FRequirePatternsDialog();
                DataRowView view = (DataRowView)this.lstRequirePatterns.SelectedItem;
                DataRow row = view.Row;
                CRequirePatterns require = row["RequirePatternsColumn"] as CRequirePatterns;
                require.SetAvailable(false);
                dialog.Require = require;
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    // 削除
                    timeTable.Requires.DelRequirePatterns(require);
                    // 一覧の再作成
                    RebuildRequireList();
                } else {
                    // 復活
                    require.SetAvailable(true);
                }
            }

        }
        /// <summary>ダブルクリックでシフトの修正
        /// </summary>
        private void lstRequirePatterns_DoubleClick(object sender, EventArgs e) {
            // 日付の修正 
            TimeTableManager.UI.FRequirePatternsDialog dialog = new FRequirePatternsDialog();
            DataRowView view = (DataRowView)this.lstRequirePatterns.SelectedItem;
            DataRow row = view.Row;
            dialog.Require = row["RequirePatternsColumn"] as CRequirePatterns;
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                //
                row["RequirePatternsColumn"] = dialog.Require;
                row["RequirePatternsName"] = dialog.Require.Name;
            }
        }
        /// <summary>メンバーの優先度を上げる
        /// </summary>
        private void BtnMemberUp_Click(object sender, System.EventArgs e) {
            DataRowView view = (DataRowView)this.lstMembers.SelectedItem;
            CMember member = view.Row["MemberColumn"] as CMember;
            if (member != null) {
                CMember prev = null;
                for (int i = 0; i < timeTable.Members.Size(); i++) {
                    CMember work = timeTable.Members[i];
                    if (work.Priority < member.Priority) {
                        prev = work;
                    }
                }
                if (prev != null) {
                    int k = member.Priority;
                    int l = prev.Priority;
                    member.Priority = l;
                    prev.Priority = k;
                    // メンバー
                    this.MemberTable.Rows.Clear();
                    int memsize = timeTable.Members.Size();
                    for (int i = 0; i < memsize; i++) {
                        CMember mem = timeTable.Members[i];
                        DataRow row = this.MemberTable.NewRow();
                        row["MemberColumn"] = mem;
                        row["MemberName"] = mem.Name;
                        this.MemberTable.Rows.Add(row);
                        if (member == mem) {
                            this.lstMembers.SelectedIndex = i;
                        }
                    }
                    this.TimeTable.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementEdited, member);
                }
            }
        }
        /// <summary>メンバーの優先度を下げる
        /// </summary>
        private void BtnMemberDown_Click(object sender, System.EventArgs e) {
            DataRowView view = (DataRowView)this.lstMembers.SelectedItem;
            CMember member = view.Row["MemberColumn"] as CMember;
            if (member != null) {
                CMember prev = null;
                for (int i = 0; i < timeTable.Members.Size(); i++) {
                    CMember work = timeTable.Members[i];
                    if (work.Priority > member.Priority) {
                        prev = work;
                        break;
                    }
                }
                if (prev != null) {
                    int k = member.Priority;
                    int l = prev.Priority;
                    member.Priority = l;
                    prev.Priority = k;
                    // メンバー
                    this.MemberTable.Rows.Clear();
                    int memsize = timeTable.Members.Size();
                    for (int i = 0; i < memsize; i++) {
                        CMember mem = timeTable.Members[i];
                        DataRow row = this.MemberTable.NewRow();
                        row["MemberColumn"] = mem;
                        row["MemberName"] = mem.Name;
                        this.MemberTable.Rows.Add(row);
                        if (member == mem) {
                            this.lstMembers.SelectedIndex = i;
                        }
                    }
                    this.TimeTable.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementEdited, member);
                }
            }
        }
        /// <summary>タイムテーブルの設定／取得
        /// </summary>
        public CTimeTable TimeTable {
            get {
                return timeTable;
            }
            set {
                this.timeTable = value;
                doeehandler = new CTimeTable.DayOffsEditedEventHandler(timeTable_OnDayOffsEdited);
                timeTable.OnDayOffsEdited += doeehandler;
                moeehandler = new CTimeTable.MembersEditedEventHandler(timeTable_OnMembersEdited);
                timeTable.OnMembersEdited += moeehandler;
                peeehandler = new CTimeTable.PatternsEditedEventHandler(timeTable_OnPatternsEdited);
                timeTable.OnPatternsEdited += peeehandler;
                rpeehandler = new CTimeTable.RequirePatternssEditedEventHandler(timeTable_OnRequirePatternssEdited);
                timeTable.OnRequirePatternssEdited += rpeehandler;
            }
        }
        /// <summary>イベント参照の削除
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void ScheduleConfigDialog_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                timeTable.OnDayOffsEdited -= doeehandler;
            } catch { }
            try {
                timeTable.OnMembersEdited -= moeehandler;
            } catch { }
            try {
                timeTable.OnPatternsEdited -= peeehandler;
            } catch { }
            try {
                timeTable.OnRequirePatternssEdited -= rpeehandler;
            } catch { }
        }
        /// <summary>キャンセルが押されてもすでに変更されているので反映させる
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnRequirePatternssEdited(object sender, ERequirePatternssEditedEventArgs e) {
            btnCancel.DialogResult = DialogResult.OK;
            SetupDefaultRequireComobs();
            if (e.Type == EnumTimeTableElementEventTypes.ElementRemoved || e.Type == EnumTimeTableElementEventTypes.ElementRemovedForce) {
                RebuildRemovedItems();
            } else if (e.Type == EnumTimeTableElementEventTypes.ElementRescued) {
                RebuildRemovedItems();
                RebuildRequireList();
            }
        }
        /// <summary>キャンセルが押されてもすでに変更されているので反映させる
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnPatternsEdited(object sender, EPatternsEditedEventArgs e) {
            btnCancel.DialogResult = DialogResult.OK;
            if (e.Type == EnumTimeTableElementEventTypes.ElementRemoved || e.Type == EnumTimeTableElementEventTypes.ElementRemovedForce) {
                RebuildRemovedItems();
            } else if (e.Type == EnumTimeTableElementEventTypes.ElementRescued) {
                RebuildRemovedItems();
                RebuildPatternList();
            }
        }
        /// <summary>キャンセルが押されてもすでに変更されているので反映させる
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnMembersEdited(object sender, EMembersEditedEventArgs e) {
            btnCancel.DialogResult = DialogResult.OK;
            if (e.Type == EnumTimeTableElementEventTypes.ElementRemoved || e.Type == EnumTimeTableElementEventTypes.ElementRemovedForce) {
                RebuildRemovedItems();
            } else if (e.Type == EnumTimeTableElementEventTypes.ElementRescued) {
                RebuildRemovedItems();
                RebuildMemberList();
            }
        }
        /// <summary>キャンセルが押されてもすでに変更されているので反映させる
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnDayOffsEdited(object sender, EDayOffsEditedEventArgs e) {
            btnCancel.DialogResult = DialogResult.OK; ;
        }
        /// <summary>最初に表示された時のイベント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void ScheduleConfigDialog_Shown(object sender, EventArgs e) {
            SetInitialValues();
        }
        /// <summary>ヘッダー部の設定
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnPrintHeaderConfig_Click(object sender, EventArgs e) {
            FHeaderConfigDialog hcd = new FHeaderConfigDialog();
            hcd.TimeTable = TimeTable;
            hcd.ShowDialog(this);
        }
        /// <summary>フッターの設定
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnPrintFooterConfig_Click(object sender, EventArgs e) {
            FFooterConfigDialog fcd = new FFooterConfigDialog();
            fcd.TimeTable = TimeTable;
            fcd.ShowDialog(this);
        }
        /// <summary>ヘッダーのフォント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnHeaderFont_Click(object sender, EventArgs e) {
            dlgHeaderFont.ShowDialog(this);
        }
        /// <summary>日付のフォント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnDateFont_Click(object sender, EventArgs e) {
            dlgDateFont.ShowDialog(this);
        }
        /// <summary>本体のフォント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnBodyFont_Click(object sender, EventArgs e) {
            dlgBodyFont.ShowDialog(this);
        }
        /// <summary>休日の修正（リストのダブルクリック時）
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void DayOffList_DoubleClick(object sender, EventArgs e) {
            // 日付の修正 
            TimeTableManager.UI.FDayOffDialog dialog = new FDayOffDialog();
            DataRowView view = (DataRowView)this.DayOffList.SelectedItem;
            DataRow row = view.Row;
            dialog.DayOff = row["DayOffColumn"] as CDayOff;
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                //
                row["DayOffColumn"] = dialog.DayOff;
                row["DayOffNameColumn"] = dialog.DayOff.Name;
                row["DayOffStartColumn"] = dialog.DayOff.StartDate;
                row["DayOffEndColumn"] = dialog.DayOff.EndDate;
            }
        }
        /// <summary>削除済みアイテムの再編集
        /// </summary>
        private void RebuildRemovedItems() {
            int size;
            // メンバー
            TblRemovedMembers.Clear();
            size = timeTable.Members.Size(true);
            for (int i = 0; i < size; i++) {
                CMember member= timeTable.Members[i, true];
                if (member.Removed != null) {
                    object[] rowdata = { member, member.Name };
                    TblRemovedMembers.Rows.Add(rowdata);
                }
            }
            // シフト
            TblRemovedPatterns.Clear();
            size = timeTable.Patterns.Size(true);
            for (int i = 0; i < size; i++) {
                CPattern pattern = timeTable.Patterns[i, true];
                if (pattern.Removed != null) {
                    object[] rowdata = { pattern, pattern.Name };
                    TblRemovedPatterns.Rows.Add(rowdata);
                }
            }
            // 人員配置
            TblRemovedRequires.Clear();
            size = timeTable.Requires.Size(true);
            for (int i = 0; i < size; i++) {
                CRequirePatterns require = timeTable.Requires[i, true];
                if (require.Removed != null) {
                    object[] rowdata = { require, require.Name };
                    TblRemovedRequires.Rows.Add(rowdata);
                }
            }
        }
        /// <summary>メンバーの復活
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BtnResqMember_Click(object sender, EventArgs e) {
            CMember member = CmbRemovedMember.SelectedValue as CMember;
            if (member != null && timeTable.Members.Size() < FMainForm.MaxItemCount) {
                timeTable.Members.RescueMember(member);
            }
        }
        /// <summary>勤務シフトの復活
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BtnResqPattern_Click(object sender, EventArgs e) {
            CPattern pattern = CmbRemovedPattern.SelectedValue as CPattern;
            if (pattern != null && timeTable.Patterns.Size() < FMainForm.MaxItemCount) {
                timeTable.Patterns.RescuePattern(pattern);
            }
        }
        /// <summary>人員配置の復活
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BtnResqRequire_Click(object sender, EventArgs e) {
            CRequirePatterns require = CmbRemovedRequires.SelectedValue as CRequirePatterns;
            if (require != null && timeTable.Requires.Size() < FMainForm.MaxItemCount) {
                timeTable.Requires.RescueRequirePatterns(require);
            }
        }
        /// <summary>インポートダイアログを表示する
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnImport_Click (object sender, EventArgs e) {
            if (DlgImportFile.ShowDialog(this) == DialogResult.OK) {
                TimeTableManager.IO.CLoader loader = new TimeTableManager.IO.CLoader();
                CTimeTable source = loader.Load(DlgImportFile.FileName);
                FImportDialog DlgImport = new FImportDialog();
                DlgImport.SourceName = DlgImportFile.FileName;
                DlgImport.Source = source;
                DlgImport.Target = TimeTable;
                DlgImport.ShowDialog(this);
            }
        }
        /// <summary>古いアイテムを削除する 
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnRemoveOldItem_Click (object sender, EventArgs e) {
            // 古いアイテムを消す前にバックアップを作成する？
            DialogResult dr = MessageBox.Show(this, "古いデータを削除する前にファイルをバックアップすることをお勧めします。\nバックアップしますか？", "バックアップを推奨", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Cancel) {
                // キャンセル
                return;
            } else if (dr == DialogResult.Yes) {
                // 作成する
                string prefix = "BKUP" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".125";
                saveFileDialog1.FileName = prefix;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK) {
                    TimeTableManager.IO.CSaver saver = new TimeTableManager.IO.CSaver();
                    saver.Save(saveFileDialog1.FileName, TimeTable);
                } else {
                    // これもキャンセル
                    return;
                }
            }
            // 古いアイテムを削除する
            RemoveItems();
        }
        /// <summary>
        /// 実際に古いアイテムを削除する
        /// </summary>
        private void RemoveItems () {
            double add = Decimal.ToDouble(NudPrevDate.Value);
            DateTime deldate = DateTime.Today.AddDays(-add);
            #region 日付
            List<CScheduledDate> rdates = new List<CScheduledDate>();
            for (int i = 0; i < TimeTable.Size(); i++) {
                CScheduledDate sdate = TimeTable[i];
                if (sdate.Date <= deldate) {
                    rdates.Add(sdate);
                }
            }
            for (int i = 0; i < rdates.Count; i++) {
                TimeTable.Dates.DelScheduledDate(rdates[i]);
            }
            #endregion
            #region 休日
            List<CDayOff> rdayoffs = new List<CDayOff>();
            for (int i = 0; i < TimeTable.DayOffs.Size(); i++) {
                CDayOff off = TimeTable.DayOffs[i];
                if (off.Removed != null) {
                    if (off.Removed <= deldate) {
                        rdayoffs.Add(off);
                    }
                }
            }
            for (int i = 0; i < rdayoffs.Count; i++) {
                TimeTable.DayOffs.DeleteDayOff(rdayoffs[i]);
            }
            #endregion
            #region 削除済みメンバー
            List<CMember> rmembers = new List<CMember>();
            for (int i = 0; i < TimeTable.Members.Size(true); i++) {
                CMember member = TimeTable.Members[i, true];
                if (member.Removed != null) {
                    if (member.Removed <= deldate) {
                        rmembers.Add(member);
                    }
                }
            }
            for (int i = 0; i < rmembers.Count; i++) {
                TimeTable.Members.DelMember(rmembers[i], true);
            }
            #endregion
            #region 削除済み人員配置
            List<CPattern> rpatterns = new List<CPattern>();
            for (int i = 0; i < TimeTable.Patterns.Size(true); i++) {
                CPattern pattern = TimeTable.Patterns[i, true];
                if (pattern.Removed != null) {
                    if (pattern.Removed <= deldate) {
                        rpatterns.Add(pattern);
                    }
                }
            }
            for (int i = 0; i < rpatterns.Count; i++) {
                TimeTable.Patterns.DelPattern(rpatterns[i], true);
            }
            #endregion
            #region 削除済み勤務シフト
            List<CRequirePatterns> rrequiress = new List<CRequirePatterns>();
            for (int i = 0; i < TimeTable.Requires.Size(true); i++) {
                CRequirePatterns requires = TimeTable.Requires[i, true];
                if (requires.Removed != null) {
                    if (requires.Removed <= deldate) {
                        rrequiress.Add(requires);
                    }
                }
            }
            for (int i = 0; i < rrequiress.Count; i++) {
                TimeTable.Requires.DelRequirePatterns(rrequiress[i], true);
            }
            #endregion
        }
    }
}
