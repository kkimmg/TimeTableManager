using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TimeTableManager;
using TimeTableManager.Element;
using TimeTableManager.Component;
using TimeTableManager.UI;
using TimeTableManager.IO;
using TimeTableManager.Plugin;

namespace TimeTableManager.UI {
    /// <summary>
    /// メイン画面
    /// </summary>
    public partial class FMainForm : System.Windows.Forms.Form {
        /// <summary>テキストをタブ区切りに変換するクラス
        /// </summary>
        private class ClipBoardObject {
            private ArrayList Rows = new ArrayList();
            /// <summary>コンストラクタ
            /// </summary>
            public ClipBoardObject(string text) {
                string token = "";
                string s;
                ArrayList Columns = new ArrayList();
                for (int i = 0; i < text.Length; i++) {
                    s = text.Substring(i, 1);
                    if (s == "\t") {
                        // タブで列の区切り
                        Columns.Add(token);
                        token = "";
                    } else if (s == "\n") {
                        // 改行は行の区切りですわね
                        Columns.Add(token);
                        token = "";
                        Rows.Add(Columns);
                        Columns = new ArrayList();
                    } else if (s == "\r") {
                        //
                    } else {
                        // それ以外はトークン作成
                        token = token + s;
                    }
                }
                if (token != "") {
                    Columns.Add(token);
                    token = "";
                }
                if (Columns.Count > 0) {
                    Rows.Add(Columns);
                }
            }
            /// <summary>文字列
            /// </summary>
            public string this[int column, int row] {
                get {
                    return ((ArrayList)Rows[row])[column] as string;
                }
            }
            /// <summary>行数
            /// </summary>
            public int GetRowCount() {
                return Rows.Count;
            }
            /// <summary>列数
            /// </summary>
            public int GetColumnCount(int row) {
                return ((ArrayList)Rows[row]).Count;
            }
        }
        #region 確認メッセージ
        private const string ConfirmMessage1 = "自動設定してよろしいですか？";
        private const string ConfirmMessage2 = "再設定してよろしいですか？";
        private const string ConfirmMessage3 = "人員配置が登録されていないため自動設定できません。";
        private const string ConfirmTitle1 = "全て自動";
        private const string ConfirmTitle2 = "行を自動";
        private const string ReadErrorMessage = "%1を読み込むことができませんでした。\nファイルが存在しないか、タイムテーブルファイルではありません。";
        private const string ReadErrorTitle = "ファイルを開く";
        private const string SaveErrorMessage = "%1を保存できませんでした。";
        private const string SaveErrorTitle = "ファイルを保存する";
        /// <summary>営業時間の変更ダイアログのメッセージ</summary>
        public const string title0 = "営業時間の更新";
        /// <summary>営業時間の変更ダイアログのメッセージ</summary>
        public const string message0 = "勤務シフトに合わせて営業時間を修正しますか？";
        /// <summary>営業時間の変更ダイアログのメッセージ</summary>
        public const string message1 = "開始時間%1→%2";
        /// <summary>営業時間の変更ダイアログのメッセージ</summary>
        public const string message2 = "終了時間%1→%2";
        #endregion
        /// <summary>タイムテーブルは編集済み？
        /// </summary>
        public bool TimeTableEdited {
            get {
                return timeTableEdited;
            }
            set {
                if (!timeTableEdited && value == true) {
                    this.Text = this.Text + "(編集中)";
                }
                timeTableEdited = value;
            }
        }
        /// <summary>ランダム化する装置
        /// </summary>
        public TimeTableManager.IFavoriteRandomizer Randomizer {
            get {
                if (randomizer == null) {
                    randomizer = new TimeTableManager.Element.CDefaultFavoriteRandomizer();
                }
                return this.randomizer;
            }
            set {
                this.randomizer = value;
            }
        }
        /// <summary>編集中のタイムテーブル
        /// </summary>
        public CTimeTable TimeTable {
            get { return timeTable; }
            set { timeTable = value; }
        }
        /// <summary>編集中のタイムテーブルのファイル名
        /// </summary>
        public string FileName {
            get {
                if (fileName == null) fileName = "";
                return fileName;
            }
            set {
                fileName = value;
            }
        }
        /// <summary>この以後は次の月にする
        /// </summary>
        public int NextMonthDay {
            get {
                return nextMonthDay;
            }
            set {
                nextMonthDay = value;
            }
        }
        /// <summary>当日からこの日数分は自動設定しない
        /// </summary>
        public int DayAfter {
            get {
                return (randomizer != null ? randomizer.DayAfter : 0);
            }
            set {
                if (randomizer != null) {
                    randomizer.DayAfter = value;
                }
            }
        }
        /// <summary>過去の編集を可能にする
        /// </summary>
        private bool isEditHistory = false;
        /// <summary>スプラッシュウインドウ
        /// </summary>
        private FSplashScreen splash;
        /// <summary>過去の編集を可能にする
        /// </summary>
        public bool IsEditHistory {
            get {
                return isEditHistory;
            }
            set {
                isEditHistory = value;
            }
        }
        /// <summary>自動設定のキャンセルダイアログ
        /// </summary>
        private FCancelDialog cancelDialog;
        /// <summary>自動設定のキャンセルダイアログ
        /// </summary>
        private FCancelDialog CancelDialog {
            get { return cancelDialog; }
            set { cancelDialog = value; }
        }
        /// <summary>いはゆるシングルトン
        /// </summary>
        private static FMainForm instance;
        /// <summary>アイテム数の上限</summary>
        public const int MaxItemCount = 1000;
        /// <summary>いはゆるシングルトン
        /// </summary>
        public static FMainForm Instance {
            get {
                return FMainForm.instance;
            }
        }
        /// <summary>最近使用したファイル
        /// </summary>
        public List<String> Recents {
            get {
                return recents;
            }
        }
        /// <summary>プラグインの一覧
        /// </summary>
        private Dictionary<ToolStripMenuItem, TimeTableManager.Plugin.IPlugin> plugins;
        /// <summary>プラグインの一覧
        /// </summary>
        public Dictionary<ToolStripMenuItem, TimeTableManager.Plugin.IPlugin> Plugins {
            get {
                if (plugins == null) {
                    plugins = new Dictionary<ToolStripMenuItem ,TimeTableManager.Plugin.IPlugin>();
                }
                return plugins;
            }
        }
        /// <summary>コンストラクタ
        /// </summary>
        public FMainForm() {
            this.FileName = "";
            //
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                foreach (string arg in args) {
                    FileName = arg;
                }
            }
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();
            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
            // 各コンポーネントのメインフォーム設定
            this.ScheduleViewer1.MainForm = this;
            this.multiEditor1.MainForm = this;
            this.checkList1.MainForm = this;
            // 表示期間の対応
            this.ScheduleViewer1.OnDisplayPeriodChanged += new TimeTableManager.Component.UScheduleCalenderView.DisplayPeriodChangedEventHandler(ScheduleViewer1_OnDisplayPeriodChanged);
            // シングルトンの設定
            FMainForm.instance = this;
            // ファイル関連処理のイベント対応
            this.OnFileOpen += new FileOpenEventHandler(FMainForm_OnFileOpen);
            this.OnFileSave += new FileSaveEventHandler(FMainForm_OnFileSave);
            // 最近使ったファイルのリスト作成
            recents = new System.Collections.Generic.List<string>();
            resentItems = new System.Collections.Generic.List<MenuItem>();
            // プラグインの一覧作成
            MakePluginList();
            // 最近使ったファイルを開く
            ReadUserSettings();
            // とりあえず最初は最小化？なんつって
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>ファイルを保存しました
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void FMainForm_OnFileSave(object sender, TimeTableChangedEventArgs e) {
            this.TimeTableEdited = false;
            this.Text = "タイムテーブルエディタ" + "(" + FileName + ")";
            this.MainStatus.Text = FileName + "に保存しました。";
        }
        /// <summary>ファイルを開きました。
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void FMainForm_OnFileOpen(object sender, TimeTableChangedEventArgs e) {
            this.TimeTableEdited = false;
            this.Text = "タイムテーブルエディタ" + "(" + FileName + ")";
            this.MainStatus.Text = FileName + "を開きました。";
        }
        /// <summary>ユーザーごとの設定の読み取り
        /// </summary>
        private void ReadUserSettings() {
            // 最近使ったファイル
            recents.Clear();
            for (int i = 0; i < 10; i++) {
                string propname = "Resent" + i.ToString();
                string filename = Properties.Settings.Default[propname] as string;
                if (filename != null) {
                    if (filename.Trim().Length > 0) {
                        recents.Add(filename);
                    }
                }
            }
            // ランダマイザ関連
            string strrand1 = Properties.Settings.Default["RANDOMIZER"] as string;
            if (strrand1 == CWeeklyFavoriteRandomizer.RANDNAME) {
                // 週替わり
                Randomizer = new CWeeklyFavoriteRandomizer();
            } else if (strrand1 == CMonthlyFavoriteRandomizer.RANDNAME) {
                // 月替わり
                Randomizer = new CMonthlyFavoriteRandomizer();
            } else if (strrand1 == CMonthlyWeeklyFavoriteRandomizer.RANDNAME) {
                // 月週替わり
                Randomizer = new CMonthlyWeeklyFavoriteRandomizer();
            } else {
                // とりあえず何もしない（初期設定してあるはずだから）
            }
            // XX日以内は自動設定しない
            this.DayAfter = (int)Properties.Settings.Default["DAYAFTER"];
            // 過去の編集を可能にするか？
            this.IsEditHistory = (bool)Properties.Settings.Default["EditHistory"];
            // デフォルト表示
            this.NextMonthDay = (int)Properties.Settings.Default["NEXTMONTH"];
        }
        /// <summary>選択行
        /// </summary>
        public void ResetSelection() {
            selectedDates.Clear();
            DataGridView grid = ScheduleViewer1.Grid;
            //DataTable table = ScheduleViewer1.Table;
            int n = ScheduleViewer1.Grid.BindingContext[grid.DataSource, grid.DataMember].Count;
            for (int i = 0; i < n; i++) {
                //行が選択されているか調べる
                if (ScheduleViewer1.IsSelected(i)) {
                    //選択されていればその行番号を表示する
                    DateTime date = ScheduleViewer1.StartDate.AddDays(i);
                    selectedDates.Add(TimeTable[date]);
                }
            }
        }
        /// <summary>ファイルを開く
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniOpen_Click(object sender, System.EventArgs e) {
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK) {
                OpenFile(this.openFileDialog1.FileName);
            } else {
                SetStatusMessage("キャンセルされました。");
            }
        }
        /// <summary>ファイルを開く
        /// </summary>
        /// <param name="pFileName">ファイル名</param>
        private void OpenFile(string pFileName) {
            CLoader saveload = new CLoader();
            CTimeTable CurrentValue = TimeTable;
            try {
                TimeTable = saveload.Load(pFileName);
            } catch {
                MessageBox.Show(this, ReadErrorMessage.Replace("%1", pFileName), ReadErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // 読取エラーがあった場合、元の値に戻す
                TimeTable = CurrentValue;
                return;
            }
            this.FileName = pFileName;
            TimeTable.ScheduleEditedEvnetIsValid = false;
            TimeTable.OnScheduleDateRequirePatternsEdited += new CTimeTable.ScheduleDateRequirePatternsEditedEventHandler(timeTable_OnScheduleDateRequirePatternsEdited);
            TimeTable.OnScheduleEdited += new CTimeTable.ScheduleEditedEventHandler(timeTable_OnScheduleEdited);
            TimeTable.OnMembersEdited += new CTimeTable.MembersEditedEventHandler(timeTable_OnMembersEdited);
            TimeTable.OnPatternsEdited += new CTimeTable.PatternsEditedEventHandler(timeTable_OnPatternsEdited);
            TimeTable.OnPropertyChanged += new CTimeTable.PropertyChangeEventHandler(timeTable_OnPropertyChanged);
            TimeTable.OnRequirePatternssEdited += new CTimeTable.RequirePatternssEditedEventHandler(timeTable_OnRequirePatternssEdited);
            TimeTable.Refresh();
            DateTime today = System.DateTime.Today;
            DateTime date1 = new DateTime(today.Year, today.Month, 1);
            DateTime date2 = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            if (NextMonthDay > 0 && today.Day >= NextMonthDay) {
                date1 = date1.AddMonths(1);
                date2 = date2.AddMonths(1);
            }
            System.Console.WriteLine(date1);
            ScheduleViewer1.TimeTable = TimeTable;
            ScheduleViewer1.StartDate = date1;
            ScheduleViewer1.EndDate = date2;
            ScheduleViewer1.Grid.RowEnter -= new DataGridViewCellEventHandler(Grid_RowEnter);
            ScheduleViewer1.NotifyDisplayPeriodChanged();
            ScheduleViewer1.Grid.RowEnter += new DataGridViewCellEventHandler(Grid_RowEnter);
            this.CurrentDateChanged();
            //
            //this.Text = "タイムテーブルエディタ" + "(" + FileName + ")";
            //
            //scheduleEditor1.Date = timeTable[date1];
            SetStatusMessage(this.FileName + "を開きました。");
            //
            ResetResent(pFileName);
            // イベント再実行
            TimeTable.ScheduleEditedEvnetIsValid = true;
            //
            if (OnFileOpen != null) {
                TimeTableChangedEventArgs e = new TimeTableChangedEventArgs(TimeTable, pFileName);
                OnFileOpen(this, e);
            }
        }
        /// <summary>人員配置が編集されたらタイムテーブルが編集されたことにする
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnScheduleDateRequirePatternsEdited(object sender, EScheduleDateRequirePatternsEditedEventArgs e) {
            TimeTableEdited = true;
        }
        /// <summary>人員配置が編集されたらタイムテーブルが編集されたことにする
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnRequirePatternssEdited(object sender, ERequirePatternssEditedEventArgs e) {
            TimeTableEdited = true;
        }
        /// <summary>プロパティ変更でタイムテーブルが編集されたことにする
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnPropertyChanged(object sender, TimeTableManager.Element.EPropertyChangedEventArgs e) {
            TimeTableEdited = true;
        }
        /// <summary>パターンが編集されたときタイムテーブルが編集されたことにする
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnPatternsEdited(object sender, EPatternsEditedEventArgs e) {
            TimeTableEdited = true;
        }
        /// <summary>メンバーが編集されたときタイムテーブルが編集されたことにする
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnMembersEdited(object sender, EMembersEditedEventArgs e) {
            TimeTableEdited = true;
        }
        /// <summary>行が変わった
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void Grid_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (this.TimeTable != null) {
                DateTime date = ScheduleViewer1.StartDate.AddDays(e.RowIndex);
                this.CurrentDateChanged(date);
            }
        }
        /// <summary>スケジュールが変更されました
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void timeTable_OnScheduleEdited(object sender, EScheduleEditedEventArgs e) {
            TimeTableEdited = true;
        }
        /// <summary>設定表示
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniConfig_Click(object sender, System.EventArgs e) {
            if (TimeTable != null) {
                FScheduleConfigDialog sfd = new FScheduleConfigDialog();
                sfd.TimeTable = TimeTable;
                if (sfd.ShowDialog(this) == DialogResult.OK) {
                    ScanPatternStartEnd();
                    TimeTableEdited = true;
                    ScheduleViewer1.NotifyDisplayPeriodChanged();
                    this.CurrentDateChanged();
                }
            } else {
                this.MainStatus.Text = "タイムテーブルが選択されていません。";
            }
        }
        /// <summary>勤務シフトとタイムテーブルの開始・終了をスキャンする
        /// </summary>
        private void ScanPatternStartEnd () {
            bool change = false;
            TimeSpan start = this.TimeTable.StartTime;
            TimeSpan end = start + this.TimeTable.Around;
            int sz = this.TimeTable.Patterns.Size();
            for (int i = 0; i < sz; i++) {
                CPattern pattern = this.TimeTable.Patterns[i];
                if (!pattern.BuiltIn) {
                    if (start > pattern.Start) {
                        start = pattern.Start;
                        change = true;
                    }
                    if (end < pattern.End) {
                        end = pattern.End;
                        change = true;
                    }
                }
            }
            // 変更があれば確認して反映するかもしれない
            if (change) {
                string m1 = message1.Replace("%1", this.TimeTable.StartTime.ToString()).Replace("%2", start.ToString());
                string m2 = message2.Replace("%1", this.TimeTable.EndTime.ToString()).Replace("%2", end.ToString());
                if (MessageBox.Show(this, message0 + "\n" + m1 + "\n" + m2, title0, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                    this.TimeTable.StartTime = start;
                    this.TimeTable.EndTime = end;
                }
            }
        }
        /// <summary>期間設定 
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniPeriod_Click (object sender, System.EventArgs e) {
            if (this.TimeTable != null) {
                FDisplayCalendarDialog dcd = new FDisplayCalendarDialog();
                dcd.StartDate = this.ScheduleViewer1.StartDate;
                dcd.EndDate = this.ScheduleViewer1.EndDate;
                if (dcd.ShowDialog(this) == DialogResult.OK) {
                    ScheduleViewer1.StartDate = dcd.StartDate;
                    ScheduleViewer1.EndDate = dcd.EndDate;
                    ScheduleViewer1.NotifyDisplayPeriodChanged();
                    this.CurrentDateChanged();
                    SetStatusMessage(
                        ScheduleViewer1.StartDate.ToString("yyyy/MM/dd") +
                        "～" +
                        ScheduleViewer1.EndDate.ToString("yyyy/MM/dd"));
                } else {
                    SetStatusMessage("キャンセルされました。");
                }
            } else {
                SetStatusMessage("タイムテーブルが選択されていません。");
            }
        }
        /// <summary>自動設定１（全体）
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniAutoAll1_Click(object sender, System.EventArgs e) {
            if (TimeTable == null) { 
                return; 
            }
            if (TimeTable.Requires.Size() <= 0) {
                MessageBox.Show(this, ConfirmMessage3, ConfirmTitle1, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(this, ConfirmMessage1, ConfirmTitle1, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) {
                return;
            }
            TimeSpan ttotal = (this.ScheduleViewer1.EndDate - this.ScheduleViewer1.StartDate);
            if (TimeTable.Members.Size(true) > 9 ||
                TimeTable.Patterns.Size(true) > 9 ||
                ttotal.Days > 31) {
                AutoAllBackGround();
            } else {
                AutoAllForeGround();
            }
        }
        /// <summary>フォアグラウンドで実行する
        /// </summary>
        private void AutoAllForeGround() {
            TimeTable.ScheduleEditedEvnetIsValid = false;
            // ランダム化
            Randomizer.AutoAllwithChief(this.TimeTable, this.ScheduleViewer1.StartDate, this.ScheduleViewer1.EndDate);
            // ここまで
            DateTime work = this.ScheduleViewer1.StartDate;
            while (!(work > this.ScheduleViewer1.EndDate)) {
                if (work >= DateTime.Today) {
                    CScheduledDate date = this.TimeTable[work];
                    //Randomizer.AutoAllwithChief(date);
                    date.Auto();
                }
                work = work.AddDays(1);
            }
            TimeTable.ScheduleEditedEvnetIsValid = true;
            //this.ScheduleViewer1.Refresh();
            TimeTableEdited = true;
            TimeTableAutoEditedEventArgs timeTableAutoEditedEventArgs = new TimeTableAutoEditedEventArgs(this.TimeTable, TimeTableAutoEditType.Auto, this.ScheduleViewer1.StartDate, this.ScheduleViewer1.EndDate);
            OnTimeTableAutoEdited(this, timeTableAutoEditedEventArgs);
        }
        /// <summary>バックグラウンドで実行する
        /// </summary>
        private void AutoAllBackGround() {
            if (CancelDialog != null) {
                try {
                    if (CancelDialog.Worker.IsBusy) {
                        CancelDialog.Worker.CancelAsync();
                    }
                } catch {
                }
                return;
            }
            TimeTable.ScheduleEditedEvnetIsValid = false;
            CancelDialog = new FCancelDialog();
            BackgroundWorker bg = CancelDialog.Worker;
            CancelDialog.Show(this);
            bg.DoWork += new DoWorkEventHandler(bg_DoWorkAll);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompletedAll);
            bg.RunWorkerAsync();
        }
        /// <summary>バックグラウンド実行の本体
        /// </summary>
        /// <param name="sender">ワーカー</param>
        /// <param name="e">イベントオブジェクト</param>
        void bg_DoWorkAll(object sender, DoWorkEventArgs e) {
            TimeSpan ttotal = (this.ScheduleViewer1.EndDate - this.ScheduleViewer1.StartDate);
            int itotal = ttotal.Days;
            int row = 0;
            // ここまで
            DateTime work = this.ScheduleViewer1.StartDate;
            while (!(work > this.ScheduleViewer1.EndDate)) {
                if (CancelDialog.Worker.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
                CancelDialog.Worker.ReportProgress(row * 100 / itotal); 
                if (work >= DateTime.Today) {
                    CScheduledDate date = this.TimeTable[work];
                    Randomizer.AutoAllwithChief(this.TimeTable, work);
                    date.Auto();
                }
                work = work.AddDays(1);
                row++;
            }
        }
        /// <summary>バックグラウンド実行の終了処理
        /// </summary>
        /// <param name="sender">ワーカー</param>
        /// <param name="e">イベントオブジェクト</param>
        void bg_RunWorkerCompletedAll (object sender, RunWorkerCompletedEventArgs e) {
            TimeTable.ScheduleEditedEvnetIsValid = true;
            TimeTableEdited = true;
            TimeTableAutoEditedEventArgs timeTableAutoEditedEventArgs = new TimeTableAutoEditedEventArgs(this.TimeTable, TimeTableAutoEditType.Auto, this.ScheduleViewer1.StartDate, this.ScheduleViewer1.EndDate);
            OnTimeTableAutoEdited(this, timeTableAutoEditedEventArgs);
            CancelDialog.Dispose();
            CancelDialog = null;
        }
        /// <summary>自動設定１（行）
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniAutoRow1_Click(object sender, System.EventArgs e) {
            if (TimeTable == null) {
                return; 
            }
            if (TimeTable.Requires.Size() <= 0) {
                MessageBox.Show(this, ConfirmMessage3, ConfirmTitle2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(this, ConfirmMessage1, ConfirmTitle2, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) {
                return;
            }
            TimeSpan ttotal = (this.ScheduleViewer1.EndDate - this.ScheduleViewer1.StartDate);
            if (TimeTable.Members.Size(true) > 9 ||
                TimeTable.Patterns.Size(true) > 9 ||
                ttotal.Days > 31) {
                AutoRowBackGround();
            } else {
                AutoRowForeGround();
            }
        }
        /// <summary>フォアグラウンドで実行する
        /// </summary>
        private void AutoRowForeGround () {
            TimeTable.ScheduleEditedEvnetIsValid = false;
            int row = 0;
            //DataGridView grid = this.ScheduleViewer1.Grid;
            DateTime today = DateTime.Today;
            if (this.DayAfter > 0) {
                today = DateTime.Today.AddDays(DayAfter);
            }
            DateTime work = this.ScheduleViewer1.StartDate;
            DateTime WorkStart = work, WorkEnd = work; bool ok = false;
            while (!(work > this.ScheduleViewer1.EndDate)) {
                if (work >= today && (ScheduleViewer1.IsSelected(row) || row == this.ScheduleViewer1.CurrentRowIndex)) {
                    CScheduledDate date = this.TimeTable[work];
                    Randomizer.AutoAllwithChief(this.TimeTable, work);
                    date.Auto();
                    if (!ok) {
                        WorkStart = work;
                        ok = true;
                    }
                    WorkEnd = work;
                }
                work = work.AddDays(1);
                row++;
            }
            TimeTable.ScheduleEditedEvnetIsValid = true;
            //this.ScheduleViewer1.Refresh();
            if (ok) {
                TimeTableEdited = true;
                TimeTableAutoEditedEventArgs timeTableAutoEditedEventArgs = new TimeTableAutoEditedEventArgs(this.TimeTable, TimeTableAutoEditType.Auto, WorkStart, WorkEnd);
                OnTimeTableAutoEdited(this, timeTableAutoEditedEventArgs);
            }
        }
        /// <summary>バックグラウンドで実行する
        /// </summary>
        private void AutoRowBackGround () {
            if (CancelDialog != null) {
                try {
                    if (CancelDialog.Worker.IsBusy) {
                        CancelDialog.Worker.CancelAsync();
                    }
                } catch {
                }
                return;
            }
            TimeTable.ScheduleEditedEvnetIsValid = false;
            CancelDialog = new FCancelDialog();
            BackgroundWorker bg = CancelDialog.Worker;
            CancelDialog.Show(this);
            bg.DoWork += new DoWorkEventHandler(bg_DoWorkRow);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompletedRow);
            bg.RunWorkerAsync();
        }
        /// <summary>バックグラウンド実行の本体
        /// </summary>
        /// <param name="sender">ワーカー</param>
        /// <param name="e">イベントオブジェクト</param>
        void bg_DoWorkRow (object sender, DoWorkEventArgs e) {
            TimeSpan ttotal = (this.ScheduleViewer1.EndDate - this.ScheduleViewer1.StartDate);
            int itotal = ttotal.Days;
            int row = 0;
            DateTime today = DateTime.Today;
            if (this.DayAfter > 0) {
                today = DateTime.Today.AddDays(DayAfter);
            }
            DateTime work = this.ScheduleViewer1.StartDate;
            while (!(work > this.ScheduleViewer1.EndDate)) {
                if (CancelDialog.Worker.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
                CancelDialog.Worker.ReportProgress(row * 100 / itotal);
                if (work >= today && (ScheduleViewer1.IsSelected(row) || row == this.ScheduleViewer1.CurrentRowIndex)) {
                    CScheduledDate date = this.TimeTable[work];
                    Randomizer.AutoAllwithChief(this.TimeTable, work);
                    date.Auto();
                }
                work = work.AddDays(1);
                row++;
            }
        }
        /// <summary>バックグラウンド実行の終了処理
        /// </summary>
        /// <param name="sender">ワーカー</param>
        /// <param name="e">イベントオブジェクト</param>
        void bg_RunWorkerCompletedRow (object sender, RunWorkerCompletedEventArgs e) {
            TimeTable.ScheduleEditedEvnetIsValid = true;
            TimeTableEdited = true;
            TimeTableAutoEditedEventArgs timeTableAutoEditedEventArgs = new TimeTableAutoEditedEventArgs(this.TimeTable, TimeTableAutoEditType.Auto, this.ScheduleViewer1.StartDate, this.ScheduleViewer1.EndDate);
            OnTimeTableAutoEdited(this, timeTableAutoEditedEventArgs);
            CancelDialog.Dispose();
            CancelDialog = null;
        }
        /// <summary>上書き保存する
        /// </summary>
        private void MniSave_Click(object sender, System.EventArgs e) {
            if (this.FileName != "") {
                CSaver saver = new CSaver();
                try {
                    saver.Save(this.FileName, this.TimeTable);
                }
                catch {
                    MessageBox.Show(this, SaveErrorMessage.Replace("%1", FileName), SaveErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //
                if (OnFileSave != null) {
                    TimeTableChangedEventArgs ev = new TimeTableChangedEventArgs(TimeTable, FileName);
                    OnFileSave(this, ev);
                }
                SetStatusMessage("上書き保存しました。");
                ResetResent(FileName);
            } else {
                this.MniSaveAs_Click(sender, e);
            }
        }
        /// <summary>名前を付けて保存
        /// </summary>
        private void MniSaveAs_Click(object sender, System.EventArgs e) {
            if (this.TimeTable != null) {
                if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK) {
                    CSaver saveload = new CSaver();
                    TimeTable.Refresh();
                    string FileName = this.saveFileDialog1.FileName;
                    try {
                        saveload.Save(FileName, TimeTable);
                    }
                    catch
                    {
                        MessageBox.Show(this, SaveErrorMessage.Replace("%1", FileName), SaveErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //
                    if (OnFileSave != null) {
                        TimeTableChangedEventArgs ev = new TimeTableChangedEventArgs(TimeTable, FileName);
                        OnFileSave(this, ev);
                    }
                    SetStatusMessage(FileName + "に保存しました。");
                    // リセットリセントなんつって。
                    ResetResent(FileName);
                } else {
                    SetStatusMessage("キャンセルされました。");
                }
            }
        }
        /// <summary>最近使ったファイルを更新する
        /// </summary>
        /// <param name="FileName">ファイル名</param>
        private void ResetResent(string FileName) {
            for (int i = 0; i < recents.Count; i++) {
                if (recents[i] == FileName) {
                    recents.RemoveAt(i);
                }
            }
            recents.Add(FileName);
            while (recents.Count > 10) {
                recents.Remove(recents[0]);
            }
        }
        /// <summary>行クリア
        /// </summary>
        private void MniDel_Click(object sender, System.EventArgs e) {
            if (TimeTable == null) return;
            TimeTable.ScheduleEditedEvnetIsValid = false;
            int row = 0;
            //DataGridView grid = this.ScheduleViewer1.Grid;
            DateTime work = this.ScheduleViewer1.StartDate;
            DateTime WorkStart = work, WorkEnd = work; bool ok = false;
            while (!(work > this.ScheduleViewer1.EndDate)) {
                if (work >= DateTime.Today && (ScheduleViewer1.IsSelected(row) || row == ScheduleViewer1.CurrentRowIndex)) {
                    CScheduledDate date = this.TimeTable[work];
                    date.Require = null;
                    int l = date.ValidMemberSize;
                    for (int i = 0; i < l; i++) {
                        date[i].Pattern = null;
                    }
                    if (!ok) {
                        WorkStart = work;
                        ok = true;
                    }
                    WorkEnd = work;
                }
                work = work.AddDays(1);
                row++;
            }
            TimeTable.ScheduleEditedEvnetIsValid = true;
            if (ok) {
                TimeTableEdited = true;
                TimeTableAutoEditedEventArgs timeTableAutoEditedEventArgs = new TimeTableAutoEditedEventArgs(this.TimeTable, TimeTableAutoEditType.Del, WorkStart, WorkEnd);
                OnTimeTableAutoEdited(this, timeTableAutoEditedEventArgs);
                this.ScheduleViewer1.Refresh();
                SetStatusMessage("クリアしました。");
            }
        }
        /// <summary>コピー処理
        /// </summary>
        private void MniCopy_Click(object sender, System.EventArgs e) {
            if (TimeTable == null) return;
            int row = 0;
            string AllText;
            //DataGridView grid = this.ScheduleViewer1.Grid;
            //DataTable table = this.ScheduleViewer1.Table;
            ArrayList members = new ArrayList();
            // 日付・人員配置・メンバー名・・・・
            string RowText = "日付\t人員配置";
            for (int i = 0; i < this.ScheduleViewer1.MemberColumnCount; i++) {
                // このときメンバーを動的は配列に確保する
                CMember member = this.ScheduleViewer1.GetColumnMember(i);
                members.Add(member);
                RowText += "\t" + member.Name;
            }
            AllText = RowText;
            DateTime work = this.ScheduleViewer1.StartDate;
            while (!(work > this.ScheduleViewer1.EndDate)) {
                if ((ScheduleViewer1.IsSelected(row) || row == ScheduleViewer1.CurrentRowIndex)) {
                    // 日付が選択されている
                    AllText += "\n";
                    CScheduledDate date = this.TimeTable[work];
                    RowText = date.Date.ToLongDateString() + "\t";
                    if (date.Require != null) {
                        // 人員配置
                        RowText += date.Require.Name;
                    }
                    for (int i = 0; i < members.Count; i++) {
                        // シフト
                        RowText += "\t";
                        CMember member = this.ScheduleViewer1.GetColumnMember(i);
                        CSchedule schedule = date[member];
                        if (schedule != null) {
                            CPattern pattern = schedule.Pattern;
                            if (pattern != null) {
                                RowText += pattern.Name;
                            }
                        }
                    }
                    AllText += RowText;
                }
                work = work.AddDays(1);
                row++;
            }
            // クリップボードにコピーする
            System.Windows.Forms.Clipboard.SetDataObject(AllText);
        }
        /// <summary>貼り付け
        /// </summary>
        private void MniPaste_Click(object sender, System.EventArgs e) {
            if (TimeTable == null) return;
            TimeTable.ScheduleEditedEvnetIsValid = false;
            CSchedule sche = null;
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(DataFormats.Text)) {
                string text = (string)data.GetData(DataFormats.Text);
                ClipBoardObject clip = new ClipBoardObject(text);
                ArrayList members = new ArrayList();
                if (clip.GetRowCount() > 0) {
                    int cnt = clip.GetColumnCount(0);
                    if (cnt > 0) {
                        int RowStart = 0;
                        int ColStart = 0;
                        string c00 = clip[0, 0];
                        #region 行と列の開始状況をチェックする
                        if (c00 == "日付" || c00 == "人員配置") {
                            RowStart = 1;
                            ColStart = 1;
                            // ヘッダ付き
                            for (int i = 1; i < cnt; i++) {
                                CMember member = this.TimeTable.Members.GetByName(clip[i, 0]);
                                if (member != null) {
                                    members.Add(member);
                                }
                            }
                        } else if (this.TimeTable.Members.GetByName(c00) != null) {
                            RowStart = 1;
                            ColStart = 0;
                            // ヘッダ付き
                            for (int i = 0; i < cnt; i++) {
                                CMember member = this.TimeTable.Members.GetByName(clip[i, 0]);
                                if (member != null) {
                                    members.Add(member);
                                }
                            }
                        } else {
                            RowStart = 0;
                            ColStart = 0;
                            for (int i = 0; i < this.ScheduleViewer1.MemberColumnCount; i++) {
                                // このときメンバーを動的は配列に確保する
                                CMember member = this.ScheduleViewer1.GetColumnMember(i);
                                members.Add(member);
                            }
                        }
                        #endregion
                        #region 貼り付け
                        int row = 0;
                        DataGridView grid = this.ScheduleViewer1.Grid;
                        DateTime work = this.ScheduleViewer1.StartDate;
                        DateTime WorkStart = work, WorkEnd = work; bool ok = false;
                        int j = RowStart;
                        while ((!(work > this.ScheduleViewer1.EndDate)) && j < clip.GetRowCount()) {
                            if ((ScheduleViewer1.IsSelected(row) || row >= ScheduleViewer1.CurrentRowIndex) && work >= DateTime.Today) {
                                // 日付が選択されている
                                int l = 0;
                                for (int k = ColStart; k < clip.GetColumnCount(j) && l < members.Count; k++) {
                                    string cell = clip[k, j];
                                    CScheduledDate sdate = this.TimeTable[work];
                                    CRequirePatterns req;
                                    CPattern pat;
                                    if (k == 0) {
                                        #region 1列目
                                        if (RowStart == 1 && clip[k, 0] == "日付") {
                                            // １列目が日付固定は何もしない
                                        } else if (RowStart == 1 && clip[k, 0] == "人員配置") {
                                            #region 人員配置
                                            req = this.TimeTable.Requires.GetByName(cell);
                                            if (req != null) {
                                                // 通常
                                                sdate.Require = req;
                                            } else if (cell == CRequirePatterns.DAYOFF.Name) {
                                                // 休み
                                                sdate.Require = CRequirePatterns.DAYOFF;
                                            } else if (cell == "") {
                                                // 未設定
                                                sdate.Require = null;
                                            } else {
                                                // 完全なエラー
                                                return;
                                            }
                                            #endregion
                                        } else if (RowStart == 1) {
                                            #region 開始行が１で列がメンバー名で始まる
                                            pat = this.TimeTable.Patterns.GetByName(cell);
                                            CMember member = members[l] as CMember;
                                            if (pat != null) {
                                                // シフト
                                                sche = sdate[member];
                                                sche.Pattern = pat;
                                                l++;
                                            } else if (cell == CPattern.DAYOFF.Name) {
                                                // 休み
                                                sche = sdate[member];
                                                sche.Pattern = CPattern.DAYOFF;
                                                l++;
                                            } else if (cell == "") {
                                                // 未設定
                                                sche = sdate[member];
                                                sche.Pattern = null;
                                                l++;
                                            }
                                            #endregion
                                        } else {
                                            #region 最初の列からメンバー名またはヘッダがない
                                            req = this.TimeTable.Requires.GetByName(cell);
                                            if (req != null) {
                                                // 人員配置
                                                sdate.Require = req;
                                            } else {
                                                // シフト
                                                pat = this.TimeTable.Patterns.GetByName(cell);
                                                if (pat != null) {
                                                    CMember member = members[l] as CMember;
                                                    sche = sdate[member];
                                                    sche.Pattern = pat;
                                                    l++;
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion
                                    } else if (k == 1 && RowStart == 1 && clip[k, 0] == "人員配置") {
                                        #region ２番目の列が人員配置固定
                                        req = this.TimeTable.Requires.GetByName(cell);
                                        if (req != null) {
                                            // 通常
                                            sdate.Require = req;
                                        } else if (cell == CRequirePatterns.DAYOFF.Name) {
                                            // 休み
                                            sdate.Require = CRequirePatterns.DAYOFF;
                                        } else if (cell == "") {
                                            // 未設定
                                            sdate.Require = null;
                                        } else {
                                            // 完全なエラー
                                            return;
                                        }
                                        #endregion
                                    } else {
                                        #region 3番目以降の列
                                        pat = this.TimeTable.Patterns.GetByName(cell);
                                        if (pat != null) {
                                            // 通常のシフト
                                            CMember member = members[l] as CMember;
                                            sche = sdate[member];
                                            sche.Pattern = pat;
                                            l++;
                                        } else if (cell == CPattern.DAYOFF.Name) {
                                            // 休みシフト
                                            CMember member = members[l] as CMember;
                                            sche = sdate[member];
                                            sche.Pattern = CPattern.DAYOFF;
                                            l++;
                                        } else if (cell == "") {
                                            // 未設定
                                            CMember member = members[l] as CMember;
                                            sche = sdate[member];
                                            sche.Pattern = null;
                                            l++;
                                        } else {
                                            // 人員配置かもしれない
                                            req = this.TimeTable.Requires.GetByName(cell);
                                            if (req != null) {
                                                // 人員配置
                                                sdate.Require = req;
                                            } else if (cell == CRequirePatterns.DAYOFF.Name) {
                                                // 休み
                                                sdate.Require = CRequirePatterns.DAYOFF;
                                            } else {
                                                // 完全なエラー
                                                return;
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                if (!ok) {
                                    WorkStart = work;
                                    ok = true;
                                }
                                WorkEnd = work;
                                j++;
                            }
                            work = work.AddDays(1);
                            row++;
                        }
                        #endregion
                        if (ok) {
                            TimeTableEdited = true;
                            TimeTableAutoEditedEventArgs timeTableAutoEditedEventArgs = new TimeTableAutoEditedEventArgs(this.TimeTable, TimeTableAutoEditType.Del, WorkStart, WorkEnd);
                            OnTimeTableAutoEdited(this, timeTableAutoEditedEventArgs);
                            this.ScheduleViewer1.Refresh();
                            SetStatusMessage("貼り付けました。");
                        }
                        grid.Refresh();
                    }
                }
            }
            TimeTable.ScheduleEditedEvnetIsValid = true;
            if (sche != null) {
                TimeTable.NotifyScheduleEdited(sche);
            }
        }
        /// <summary>印刷プレビュー
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniPreview_Click(object sender, EventArgs e) {
            this.ttmPrintDocumentSt11.TimeTable = this.TimeTable;
            this.ttmPrintDocumentSt11.Start = this.ScheduleViewer1.StartDate;
            this.ttmPrintDocumentSt11.End = this.ScheduleViewer1.EndDate;
            this.printPreviewDialog1.Document = ttmPrintDocumentSt11;
            try {
                this.printPreviewDialog1.ShowDialog();
            } catch {
                //
            }
        }
        /// <summary>印刷
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniPrint_Click(object sender, EventArgs e) {
            this.ttmPrintDocumentSt11.TimeTable = this.TimeTable;
            this.ttmPrintDocumentSt11.Start = this.ScheduleViewer1.StartDate;
            this.ttmPrintDocumentSt11.End = this.ScheduleViewer1.EndDate;
            //ttmPrintDocumentSt11.Print();
            if (this.printDialog1.ShowDialog(this) == DialogResult.OK) {
                ttmPrintDocumentSt11.Print();
            }
        }
        /// <summary>ステータスバーにメッセージを表示する
        /// </summary>
        public static void SetMessage(string text) {
            FMainForm.Instance.SetStatusMessage(text);
        }
        /// <summary>ステータスバーにメッセージを表示する
        /// </summary>
        public void SetStatusMessage(string text) {
            MainStatus.Text = text;
        }
        /// <summary>最近使ったファイルって作り直せる？
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MnuFile_Popup(object sender, EventArgs e) {
            //    // クリア
            //    for (int i = 0; i < resentItems.Count; i++) {
            //        ToolStripMenuItem item = resentItems[i];
            //        mnuFile.ToolStripMenuItems.Remove(item);
            //    }
            //    resentItems.Clear();
            //    // 再作成
            //    for (int i = recents.Count - 1; i >= 0 ; i--) {
            //        ToolStripMenuItem item = new ToolStripMenuItem((recents.Count - i) + ":" + recents[i]);
            //        mnuFile.ToolStripMenuItems.Add(item);
            //        resentItems.Add(item);
            //        item.Tag = recents[i];
            //        item.Click += new EventHandler(mniRecentFile_Click);
            //    }
        }
        /// <summary>最近使ったファイルを開く
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniRecentFile_Click(object sender, EventArgs e) {
            if (sender is ToolStripMenuItem) {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                string filename = item.Tag as string;
                OpenFile(filename);
            }
        }
        /// <summary>終了時の保存
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void FMainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.TimeTableEdited) {
                DialogResult res = MessageBox.Show(this, FileName + "は編集されています。保存しますか？", "未保存の変更があります。", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) {
                    MniSave_Click(this, e);
                } else if (res == DialogResult.Cancel) {
                    e.Cancel = true;
                    return;
                }
            }
            // 最近使ったファイル
            for (int i = 0; i < recents.Count; i++) {
                Properties.Settings.Default["Resent" + i.ToString()] = recents[i];
            }
            // ランダマイザ
            Properties.Settings.Default["RANDOMIZER"] = Randomizer.Name;
            Properties.Settings.Default["DAYAFTER"] = DayAfter;
            // 次の月
            Properties.Settings.Default["NEXTMONTH"] = NextMonthDay;
            // ウィンドウステータス
            if (this.WindowState == FormWindowState.Maximized) {
                Properties.Settings.Default["WindowMaximized"] = true;
            } else {
                Properties.Settings.Default["WindowMaximized"] = false;
                if (this.WindowState == FormWindowState.Normal) {
                    Properties.Settings.Default["WindowSize"] = this.Size;
                }
            }
            // 上下を分け隔てる横の棒
            Properties.Settings.Default["SplitterDistance"] = SptBody.SplitterDistance;
            // 列幅の自動設定
            Properties.Settings.Default["ColumnFitAuto"] = TimeTableManager.Component.UScheduleCalenderView.ColumnFitAuto;
            // エディタのリボン編集の閾値
            Properties.Settings.Default["Threshold"] = TimeTableManager.Component.UMultiEditor.Threshold;
            // 過去の編集を可能とするか？
            Properties.Settings.Default["EditHistory"] = IsEditHistory;
            // 保存
            Properties.Settings.Default.Save();
        }
        /// <summary>初回起動時
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void FMainForm_Shown(object sender, EventArgs e) {
            // デフォルトで最後に開いたファイルを開く
            if (FileName != "") {
                OpenFile(FileName);
            } else {
                if (recents.Count > 0) {
                    OpenFile(recents[recents.Count - 1]);
                } else {
                    NewFile();
                }
            }
            // ウインドウサイズと横棒の位置の復元
            bool max = (bool)Properties.Settings.Default["WindowMaximized"];
            if (max) {
                this.WindowState = FormWindowState.Maximized;
                this.SptBody.SplitterDistance = (int)Properties.Settings.Default["SplitterDistance"];
            } else {
                this.Size = (Size)Properties.Settings.Default["WindowSize"];
                this.WindowState = FormWindowState.Normal;
                this.SptBody.SplitterDistance = (int)Properties.Settings.Default["SplitterDistance"];
            }
            // 列幅の自動設定
            TimeTableManager.Component.UScheduleCalenderView.ColumnFitAuto = (bool)Properties.Settings.Default["ColumnFitAuto"];
            // エディタのリボン編集の閾値
            TimeTableManager.Component.UMultiEditor.Threshold = (TimeSpan)Properties.Settings.Default["Threshold"];
            // スプラッシュを閉じる
            if (splash != null && splash.Visible) {
                splash.Close();
                splash.Dispose();
                splash = null;
            }
        }
        /// <summary>印刷設定
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniPrintSetting_Click(object sender, EventArgs e) {
            this.pageSetupDialog1.ShowDialog(this);
        }
        /// <summary>カレントの日付が変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void CurrentDateChangedEventHandler(object sender, ECurrentDateChangedArgs e);
        /// <summary>カレントの日付が変更されたイベント
        /// </summary>
        public event CurrentDateChangedEventHandler OnCurrentDateChanged;
        /// <summary>カレントの日付が変更された
        /// </summary>
        public void CurrentDateChanged(DateTime date) {
            if (OnCurrentDateChanged != null) {
                if (this.TimeTable != null) {
                    //DateTime date = ScheduleViewer1.CurrentRowDate;
                    CScheduledDate source = this.TimeTable[date];
                    ECurrentDateChangedArgs e = new ECurrentDateChangedArgs(source);
                    OnCurrentDateChanged(this, e);
                }
            }
        }
        /// <summary>ビューの選択行が変わったときのイベント処理対応
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        public delegate void ViewSelectionChangedEventHandler(object sender, ESelectionChangedEventArg e);
        /// <summary>ビューの選択行が変わったときのイベント処理対応
        /// </summary>
        public event ViewSelectionChangedEventHandler OnViewSelectionChanged;
        /// <summary>ビューの選択行が変わりました
        /// </summary>
        /// <param name="source"></param>
        public void ViewSelectionChanged(List<DateTime> source) {
            if (OnViewSelectionChanged != null) {
                if (TimeTable != null) {
                    ESelectionChangedEventArg e = new ESelectionChangedEventArg(source, TimeTable);
                    OnViewSelectionChanged(this, e);
                    //
                    if (MinimumSelection == MaximumSelection) {
                        tabMultiEdit.Text = MinimumSelection.ToString("MM/dd");
                    } else {
                        tabMultiEdit.Text = MinimumSelection.ToString("MM/dd") + "～" + MaximumSelection.ToString("MM/dd");
                    }
                }
            }
        }
        /// <summary>カレントの日付が変更された
        /// </summary>
        private void CurrentDateChanged() {
            DateTime date = ScheduleViewer1.CurrentRowDate;
            CurrentDateChanged(date);
        }
        /// <summary>選択された日付の始まり
        /// </summary>
        public DateTime MinimumSelection {
            get {
                return ScheduleViewer1.MinimumSelection;
            }
        }
        /// <summary>選択された日付の終わり
        /// </summary>
        public DateTime MaximumSelection {
            get {
                return ScheduleViewer1.MaximumSelection;
            }
        }
        /// <summary>選択された日付の日数
        /// </summary>
        public int SelectedDateCount {
            get {
                return ScheduleViewer1.SelectedDateCount;
            }
        }
        /// <summary>選択された日付
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DateTime SelectedDate(int i) {
            return ScheduleViewer1.SelectedDate(i);
        }
        /// <summary>選択された日付
        /// </summary>
        public List<DateTime> SelectedDates {
            get {
                return ScheduleViewer1.SelectedDates;
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
        /// <summary>表示期間が変更になった
        /// </summary>
        private void ScheduleViewer1_OnDisplayPeriodChanged(object sender, DisplayPeriodChangedEventArgs e) {
            if (OnDisplayPeriodChanged != null) {
                OnDisplayPeriodChanged(sender, e);
            }
        }
        /// <summary>ファイルが開いたとき 
        /// </summary>
        public delegate void FileOpenEventHandler(object sender, TimeTableChangedEventArgs e);
        /// <summary>ファイルが開いたとき 
        /// </summary>
        public event FileOpenEventHandler OnFileOpen;
        /// <summary>ファイルを保存したとき
        /// </summary>
        public delegate void FileSaveEventHandler(object sender, TimeTableChangedEventArgs e);
        /// <summary>ファイルを保存したとき
        /// </summary>
        public event FileSaveEventHandler OnFileSave;
        /// <summary>新規作成
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniNew_Click(object sender, EventArgs e) {
            NewFile();
        }
        /// <summary>新規作成
        /// </summary>
        private void NewFile() {
            this.FileName = "";
            TimeTable = new CTimeTable();
            TimeTable.ScheduleEditedEvnetIsValid = false;
            TimeTable.OnScheduleEdited += new CTimeTable.ScheduleEditedEventHandler(timeTable_OnScheduleEdited);
            DateTime today = System.DateTime.Today;
            DateTime date1 = new DateTime(today.Year, today.Month, 1);
            DateTime date2 = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            System.Console.WriteLine(date1);
            ScheduleViewer1.TimeTable = TimeTable;
            ScheduleViewer1.StartDate = date1;
            ScheduleViewer1.EndDate = date2;
            ScheduleViewer1.Grid.RowEnter -= new DataGridViewCellEventHandler(Grid_RowEnter);
            ScheduleViewer1.NotifyDisplayPeriodChanged();
            ScheduleViewer1.Grid.RowEnter += new DataGridViewCellEventHandler(Grid_RowEnter);
            this.CurrentDateChanged();
            //
            //scheduleEditor1.Date = timeTable[date1];
            TimeTable.ScheduleEditedEvnetIsValid = true;
            //
            if (OnFileOpen != null) {
                TimeTableChangedEventArgs ev = new TimeTableChangedEventArgs(TimeTable, FileName);
                OnFileOpen(this, ev);
            }
            //
            this.Text = "タイムテーブルエディタ" + "(新規作成)";
            this.MainStatus.Text = "新規作成しました。";
        }
        /// <summary>終了
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniQuit_Click(object sender, EventArgs e) {
            Dispose();
        }
        /// <summary>切り取り
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniCut_Click(object sender, EventArgs e) {
            if (TimeTable == null) return;
            // とりあえずコピーして削除
            TimeTable.ScheduleEditedEvnetIsValid = false;
            MniCopy_Click(sender, e);
            MniDel_Click(sender, e);
            TimeTable.ScheduleEditedEvnetIsValid = true;
        }
        /// <summary>切り取り
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TbbCut_Click(object sender, EventArgs e) {
            MniCut_Click(sender, e);
        }
        /// <summary>最近使用したファイル
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniRecentFile_Click_1(object sender, EventArgs e) {
            string recent = FResentFileDialog.ShowRecents(this);
            if (recent != "") {
                OpenFile(recent);
            }
        }
        /// <summary>ビューの特定の日付を選択する
        /// </summary>
        /// <param name="date">選択する日付</param>
        public void SetSelectedDate(DateTime date) {
            ScheduleViewer1.Select(date);
        }
        /// <summary>タイムテーブルが自動編集されました
        /// </summary>
        public event TimeTableAutoEditedEventHandler OnTimeTableAutoEdited;
        /// <summary>タイムテーブルが自動編集されました
        /// </summary>
        /// <param name="sender">タイムテーブル</param>
        /// <param name="e">発生したイベント</param>
        public delegate void TimeTableAutoEditedEventHandler(object sender, TimeTableAutoEditedEventArgs e);
        /// <summary>オプションダイアログ
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniOption_Click(object sender, EventArgs e) {
            FToolsOptionDialog tod = new FToolsOptionDialog();
            tod.ShowDialog(this);
        }
        /// <summary>ヘルプを表示する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniHelpContents_Click (object sender, EventArgs e) {
            Help.ShowHelp(this, @"TimeTableManager.chm");
        }
        /// <summary>ヘルプを表示する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MniHelpIndex_Click (object sender, EventArgs e) {
            Help.ShowHelpIndex(this, @"TimeTableManager.chm");
        }
        /// <summary>ヘルプを表示する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void TbbHelp_Click (object sender, EventArgs e) {
            Help.ShowHelp(this, @"TimeTableManager.chm");
        }
        /// <summary>初期起動時スプラッシュウインドウを表示する
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void FMainForm_Load (object sender, EventArgs e) {
            splash = new FSplashScreen();
            splash.Show(this);
        }
        /// <summary>バージョン情報
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void MniHelpVersion_Click (object sender, EventArgs e) {
            FAboutBox aboutbox = new FAboutBox();
            aboutbox.ShowDialog(this);
        }
        /// <summary>エクスポートする
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void MniExport_Click (object sender, EventArgs e) {
            FCSVExport export = new FCSVExport();
            export.TimeTable = this.TimeTable;
            export.StartDate = this.ScheduleViewer1.StartDate;
            export.EndDate = this.ScheduleViewer1.EndDate;
            export.Show(this);
        }
        /// <summary>プラグインの一覧を作成する
        /// </summary>
        private void MakePluginList () {
            int k = 0;
            try {
                string[] files = System.IO.Directory.GetFiles(Application.StartupPath + @"\PlugIns", "*.dll");
                foreach (string file in files) {
                    try {
                        System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFrom(file);
                        Type[] tps = ass.GetTypes();
                        foreach (Type typ in tps) {
                            if (typ.IsClass && typ.IsPublic && !typ.IsAbstract) {
                                Type chk = typ.GetInterface(typeof(IPlugin).FullName);
                                if (chk != null) {
                                    System.Reflection.ConstructorInfo con = typ.GetConstructor(Type.EmptyTypes);
                                    if (con != null && con.IsPublic) {
                                        IPlugin plugin = (IPlugin)con.Invoke(null);
                                        plugin.BindMainWindow(this);
                                        // メニューに追加する
                                        ToolStripMenuItem MniPluginItem = new ToolStripMenuItem();
                                        MniPluginItem.Text = plugin.PluginDescription;
                                        Plugins.Add(MniPluginItem, plugin);
                                        MniPluginItem.Name = plugin.PluginName;
                                        MniPluginItem.Click += new EventHandler(MniPluginItem_Click);
                                        if (plugin.IsMenuItem) {
                                            MniPlugin.DropDownItems.Add(MniPluginItem);
                                            k++;
                                        }
                                    }
                                }
                            }
                        }
                    } catch {
                    }
                }
            } catch {
                try {
                    if (!System.IO.Directory.Exists(Application.StartupPath + @"\PlugIns")) {
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\PlugIns");
                    }
                } catch {
                }
            }
            if (k == 0) {
                MniPlugin.Visible = false;
            } else {
                MniPlugin.Visible = true;
            }
        }
        /// <summary>プラグインを実行する
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        void MniPluginItem_Click (object sender, EventArgs e) {
            try {
                ToolStripMenuItem MniPluginItem = sender as ToolStripMenuItem;
                IPlugin plugin = Plugins[MniPluginItem];
                plugin.DoSomething(TimeTable, this.ScheduleViewer1.StartDate, this.ScheduleViewer1.EndDate);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    /// <summary>タイムテーブルが変更になった
    /// </summary>
    public class TimeTableChangedEventArgs : EventArgs {
        private readonly string fileName;
        /// <summary>変更されたファイル名
        /// </summary>
        public string FileName {
            get { return fileName; }
        }
        private readonly CTimeTable timeTable;
        /// <summary>変更されたタイムテーブル
        /// </summary>
        public CTimeTable TimeTable {
            get { return timeTable; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="source">タイムテーブル</param>
        /// <param name="name">ファイル名</param>
        public TimeTableChangedEventArgs(CTimeTable source, string name) {
            this.timeTable = source;
            this.fileName = name;
        }
    }
    /// <summary>イベントタイプ
    /// </summary>
    public enum TimeTableAutoEditType {
        /// <summary>自動化された</summary>
        Auto,
        /// <summary>自動化された</summary>
        Randomized,
        /// <summary>貼り付けされた</summary>
        Paste,
        /// <summary>切り取りされた</summary>
        Cut,
        /// <summary>クリアされた</summary>
        Del
    }
    /// <summary>タイムテーブルが自動設定された
    /// </summary>
    public class TimeTableAutoEditedEventArgs : EventArgs {
        private readonly CTimeTable timeTable;
        private readonly TimeTableAutoEditType type;
        private readonly DateTime startDate, endDate;
        /// <summary>自動設定されたタイムテーブル
        /// </summary>
        public CTimeTable TimeTable {
            get { return timeTable; }
        }
        /// <summary>イベントタイプ
        /// </summary>
        public TimeTableAutoEditType Type {
            get { return type; }
        }
        /// <summary>自動設定の開始
        /// </summary>
        public DateTime StartDate {
            get { return startDate; }
        }
        /// <summary>自動設定の終了
        /// </summary>
        public DateTime EndDate {
            get { return endDate; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="source">イベントの発生元（タイムテーブル）</param>
        /// <param name="Type">イベント種別</param>
        /// <param name="StartDate">イベントの開始日</param>
        /// <param name="EndDate">イベントの終了日</param>
        public TimeTableAutoEditedEventArgs(CTimeTable source, TimeTableAutoEditType Type, DateTime StartDate, DateTime EndDate) {
            this.timeTable = source;
            this.type = Type;
            this.startDate = StartDate;
            this.endDate = EndDate;
        }
    }
}
