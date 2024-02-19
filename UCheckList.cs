using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TimeTableManager.Element;
using TimeTableManager.Evaluation;

namespace TimeTableManager.Component {
    /// <summary>チェックリストのパーシャルクラス
    /// </summary>
    public partial class UCheckList : UserControl {
        /// <summary>
        /// チェック処理再実行フラグ
        /// </summary>
        private bool contwrk = false;
        /// <summary>
        /// ループの開始、終了、表示の開始
        /// </summary>
        private DateTime LoopStart, LoopEnd, ViewStart;
        /// <summary>
        /// 評価の一覧？
        /// </summary>
        private Dictionary<BScheduledDate, BEvaluation1Day> items = new Dictionary<BScheduledDate, BEvaluation1Day>();
        #region タイムテーブルについて
        private BTimeTable timeTable;
        /// <summary>タイムテーブル
        /// </summary>
        public BTimeTable TimeTable {
            get {
                return timeTable;
            }
            set {
                timeTable = value;
                if (timeTable != null) {
                    timeTable.OnScheduleDateRequirePatternsEdited += new BTimeTable.ScheduleDateRequirePatternsEditedEventHandler(root_OnScheduleDateRequirePatternsEdited);
                    timeTable.OnScheduleEdited += new BTimeTable.ScheduleEditedEventHandler(root_OnScheduleEdited);
                    timeTable.EvaluationItems.Clear();
                }
            }
        }
        private List<BEvaluationItem> ItemList {
            get {
                return TimeTable.EvaluationItems;
            }
        }
        #endregion
        #region メインフォームについて
        TimeTableManager.UI.FMainForm mainForm;
        /// <summary>親画面
        /// </summary>
        public TimeTableManager.UI.FMainForm MainForm {
            get { return mainForm; }
            set { 
                mainForm = value;
                if (mainForm != null) {
                    mainForm.OnDisplayPeriodChanged += new TimeTableManager.UI.FMainForm.DisplayPeriodChangedEventHandler(mainForm_OnDisplayPeriodChanged);
                    mainForm.OnTimeTableAutoEdited += new TimeTableManager.UI.FMainForm.TimeTableAutoEditedEventHandler(mainForm_OnTimeTableAutoEdited);
                    mainForm.OnFileOpen += new TimeTableManager.UI.FMainForm.FileOpenEventHandler(mainForm_OnFileOpen);
                }
            }
        }


        #endregion
        /// <summary>コンストラクタ
        /// </summary>
        public UCheckList () {
            InitializeComponent();
            //
            this.ClmResultType.CellTemplate = new PriorityCell();
        }
        /// <summary>クリア
        /// </summary>
        private void Clear() {
            if (TimeTable != null) {
                ItemList.Clear();
            }
            items.Clear();
        }
        /// <summary>チェック処理のスレッド処理
        /// </summary>
        private void Run() {
            if (backgroundWorker1.IsBusy) {
                backgroundWorker1.CancelAsync();
                contwrk = true;
            } else {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        /// <summary>チェック処理の実体
        /// </summary>
        /// <param name="bw"></param>
        private void RunCheck (BackgroundWorker bw) {
            if (mainForm == null) return;
            if (TimeTable == null) return;
            DateTime work = (LoopStart >= DateTime.Today ? LoopStart : DateTime.Today);
            while (work <= LoopEnd && bw.CancellationPending != true) {
                BScheduledDate sdate = TimeTable[work.Date];
                if (items.ContainsKey(sdate)) {
                    BEvaluation1Day e1d = items[sdate];
                    e1d.Check();
                } else {
                    BEvaluation1Day e1d = new BEvaluation1Day(sdate);
                    items.Add(sdate, e1d);
                    e1d.Check();
                }
                work = work.AddDays(1);
                Thread.Sleep(10);
            }
            //
        }
        /// <summary>スケジュールが変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void root_OnScheduleEdited (object sender, EScheduleEditedEventArgs e) {
            LoopStart = e.Schedule.Date.Date;
            Run();
        }
        /// <summary>スケジュールの人員配置が変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void root_OnScheduleDateRequirePatternsEdited (object sender, EScheduleDateRequirePatternsEditedEventArgs e) {
            LoopStart = e.ScheduledDate.Date;
            Run();
        }
        /// <summary>タイムテーブルが変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnFileOpen (object sender, TimeTableManager.UI.TimeTableChangedEventArgs e) {
            TimeTable = e.TimeTable;
            Clear();
            Run();
        }
        /// <summary>表示期間が変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnDisplayPeriodChanged (object sender, DisplayPeriodChangedEventArgs e) {
            Clear();
            LoopStart = e.Start.Date;
            ViewStart = e.Start.Date;
            LoopEnd = e.End.Date;
            Run();
        }
        /// <summary>自動設定された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        void mainForm_OnTimeTableAutoEdited(object sender, TimeTableManager.UI.TimeTableAutoEditedEventArgs e) {
            Clear();
            Run();
        }
        /// <summary>値を表示する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void ListGrid_CellValueNeeded (object sender, DataGridViewCellValueEventArgs e) {
            if (TimeTable == null) return;
            List<BEvaluationItem> lst = TimeTable.EvaluationItems;
            int row = e.RowIndex;
            if (row >= lst.Count) return;
            BEvaluationItem item = lst[row];
            if (e.ColumnIndex == 0) {
                //switch (item.Result) {
                //    case EvaluationResult.NOTICE:
                //        e.Value = "低";
                //        break;
                //    case EvaluationResult.WORNING:
                //        e.Value = "中";
                //        break;
                //    case EvaluationResult.ERROR:
                //        e.Value = "高";
                //        break;
                //}
                e.Value = item;
            } else if (e.ColumnIndex == 1) {
                e.Value = item.Date.Date.ToShortDateString();
            } else {
                e.Value = item.Message;
            }
        }
        /// <summary>スレッド開始
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void backgroundWorker1_DoWork (object sender, DoWorkEventArgs e) {
            BackgroundWorker bw = sender as BackgroundWorker;
            RunCheck(bw);
        }
        /// <summary>スレッド完了（必要ならスレッド再起動）
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void backgroundWorker1_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            ListGrid.RowCount = TimeTable.EvaluationItems.Count;
            if (contwrk) {
                ListGrid.Refresh();
                contwrk = false;
                Run();
            } else {
                ListGrid.Refresh();
            }
        }
        /// <summary>日付を選択できる？
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void ListGrid_CellDoubleClick (object sender, DataGridViewCellEventArgs e) {
            List<BEvaluationItem> lst = TimeTable.EvaluationItems;
            int row = e.RowIndex;
            if (row >= 0 && row < lst.Count) {
                BEvaluationItem item = lst[row];
                this.MainForm.SetSelectedDate(item.Date.Date);
            }
        }
    }
    /// <summary>優先順位をあらわすセル
    /// </summary>
    public class PriorityCell : System.Windows.Forms.DataGridViewTextBoxCell {
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
            if (value != null && value is BEvaluationItem) {
                BEvaluationItem item = value as BEvaluationItem;
                switch (item.Result) {
                    case EEvaluationResult.NOTICE:
                        ret = "低";
                        break;
                    case EEvaluationResult.WORNING:
                        ret = "中";
                        cellStyle.ForeColor = Color.Yellow;
                        break;
                    case EEvaluationResult.ERROR:
                        ret = "高";
                        cellStyle.ForeColor = Color.Red;
                        break;
                }
            }
            return (ret == null) ? "" : ret;
        }
    }
}
