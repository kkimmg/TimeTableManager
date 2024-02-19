using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Element;

namespace TimeTableManager.UI {
    /// <summary>CSVエクスポートダイアログ
    /// </summary>
    public partial class FCSVExport : Form {
        /// <summary>タイムテーブル
        /// </summary>
        private TimeTableManager.Element.BTimeTable timeTable;
        /// <summary>開始日、終了日
        /// </summary>
        private DateTime startDate, endDate;
        /// <summary>タイムテーブル
        /// </summary>
        public TimeTableManager.Element.BTimeTable TimeTable {
            get { return timeTable; }
            set { timeTable = value; }
        }
        /// <summary>開始日
        /// </summary>
        public DateTime StartDate {
            get { return startDate;  }
            set { startDate = value; }
        }
        /// <summary>終了日
        /// </summary>
        public DateTime EndDate {
            get { return endDate; }
            set { endDate = value; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        public FCSVExport () {
            InitializeComponent();
            // カスタムコード
            DataRow dr = TblOutputItems.NewRow();
            dr[ClmItem] = EnmCSVItem.ItmDate;
            dr[ClmItemHead] = "日付";
            TblOutputItems.Rows.Add(dr);
            //
            dr = TblOutputItems.NewRow();
            dr[ClmItem] = EnmCSVItem.ItmRequireName;
            dr[ClmItemHead] = "人員配置";
            TblOutputItems.Rows.Add(dr);
            //
            dr = TblOutputItems.NewRow();
            dr[ClmItem] = EnmCSVItem.ItmPatternName;
            dr[ClmItemHead] = "勤務シフト名";
            TblOutputItems.Rows.Add(dr);
            //
            dr = TblOutputItems.NewRow();
            dr[ClmItem] = EnmCSVItem.ItmPatternStart;
            dr[ClmItemHead] = "勤務シフトの開始";
            TblOutputItems.Rows.Add(dr);
            //
            dr = TblOutputItems.NewRow();
            dr[ClmItem] = EnmCSVItem.ItmPatternLength;
            dr[ClmItemHead] = "勤務シフトの長さ";
            TblOutputItems.Rows.Add(dr);
            //
            dr = TblOutputItems.NewRow();
            dr[ClmItem] = EnmCSVItem.ItmPatternEnd;
            dr[ClmItemHead] = "勤務シフトの終了";
            TblOutputItems.Rows.Add(dr);
            //
            for (int i = 0; i < TblOutputItems.Rows.Count; i++) {
                LstItemList.SetItemChecked(i, true);
            }
        }
        /// <summary>参照／テキストボックスにファイル名を設定する
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnOutFile_Click(object sender, EventArgs e) {
            DialogResult dr = saveFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                TxtOutFile.Text = saveFileDialog1.FileName;
            }
        }
        /// <summary>閉じる
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnCancel_Click(object sender, EventArgs e) {
            Dispose();
        }
        /// <summary>CSVに列を出力する
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        public delegate string OutputColumnMethod(DateTime date, BMember member, bool head);
        /// <summary>出力実行
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnExport_Click(object sender, EventArgs e) {
            if (TxtOutFile.Text.Trim().Length == 0) {
                // ファイル名が指定されていなければ指定させる
                DialogResult dr = saveFileDialog1.ShowDialog(this);
                if (dr == DialogResult.OK) {
                    TxtOutFile.Text = saveFileDialog1.FileName;
                } else {
                    return;
                }
            }
            List<OutputColumnMethod> items1 = new List<OutputColumnMethod>();
            List<OutputColumnMethod> items2 = new List<OutputColumnMethod>();
            #region 列一覧の作成
            foreach (System.Data.DataRowView view in this.LstItemList.CheckedItems) {
                // そのあとで有効なものを追加する
                EnmCSVItem item = (EnmCSVItem)view.Row["ClmItem"];
                switch (item) {
                    case EnmCSVItem.ItmDate:
                        items1.Add(new OutputColumnMethod(ReturnDate));
                        break;
                    case EnmCSVItem.ItmRequireName:
                        items1.Add(new OutputColumnMethod(ReturnRequireName));
                        break;
                    case EnmCSVItem.ItmPatternName:
                        items2.Add(new OutputColumnMethod(ReturnPatternName));
                        break;
                    case EnmCSVItem.ItmPatternStart:
                        items2.Add(new OutputColumnMethod(ReturnPatternStart));
                        break;
                    case EnmCSVItem.ItmPatternLength:
                        items2.Add(new OutputColumnMethod(ReturnPatternLength));
                        break;
                    case EnmCSVItem.ItmPatternEnd:
                        items2.Add(new OutputColumnMethod(ReturnPatternEnd));
                        break;
                    default:
                        break;
                }
            }
            #endregion
            try {
                // ファイルオープン
                System.IO.StreamWriter writer = new System.IO.StreamWriter(TxtOutFile.Text.Trim());
                string RowText = "";
                #region メンバー一覧の作成
                List<BMember> members = new List<BMember>();
                for (int i = 0; i < TimeTable.Members.Size(true); i++) {
                    BMember member = TimeTable.Members[i, true];
                    if (member.IsAvailable(StartDate, EndDate)) {
                        members.Add(member);
                    }
                }
                #endregion
                #region 見出しの作成
                for (int i = 0; i < items1.Count; i++) {
                    RowText += items1[i](DateTime.Now, null, true) + ",";
                }
                foreach (BMember member in members) {
                    for (int i = 0; i < items2.Count; i++) {
                        RowText += items2[i](DateTime.Now, member, true) + ",";
                    }
                }
                writer.WriteLine(RowText);
                #endregion
                #region 各行の作成
                DateTime date = StartDate;
                while (!(date > EndDate)) {
                    RowText = "";
                    for (int i = 0; i < items1.Count; i++) {
                        RowText += items1[i](date, null, false) + ",";
                    }
                    foreach (BMember member in members) {
                        for (int i = 0; i < items2.Count; i++) {
                            RowText += items2[i](date, member, false) + ",";
                        }
                    }
                    writer.WriteLine(RowText);
                    // 次へ
                    date = date.AddDays(1.0);
                }
                #endregion
                // 終了
                writer.Close();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Dispose();
        }
        /// <summary>日付を返す
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        private string ReturnDate(DateTime date, BMember member, bool head) {
            if (head) return "日付";
            return date.ToLongDateString();
        }
        /// <summary>値のカンマとダブルクォーテーションを変換する
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private string ConvertColumn (string column) {
            string ret = column.Replace(",", "\",").Replace("\"", "\"\"");
            if (!ret.Equals(column)) {
                ret = "\"" + ret + "\"";
            }
            return ret;
        }
        /// <summary>人員配置名を返す
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        private string ReturnRequireName(DateTime date, BMember member, bool head) {
            if (head) return "人員配置";
            BScheduledDate sdate = TimeTable[date];
            BRequirePatterns rq = sdate.Require;
            if (rq == null) return "";
            return ConvertColumn(rq.Name);
        }
        /// <summary>勤務シフト名を返す
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        private string ReturnPatternName(DateTime date, BMember member, bool head) {
            if (head) return member.Name + "の勤務シフト";
            BScheduledDate sdate = TimeTable[date];
            BSchedule schdule = sdate[member];
            if (schdule == null) return "";
            BPattern pattern = schdule.Pattern;
            if (pattern == null) return "";
            return ConvertColumn(pattern.Name);
        }
        /// <summary>勤務シフト開始を返す
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        private string ReturnPatternStart(DateTime date, BMember member, bool head) {
            if (head) return member.Name + "のシフト開始";
            BScheduledDate sdate = TimeTable[date];
            BSchedule schdule = sdate[member];
            if (schdule == null) return "";
            BPattern pattern = schdule.Pattern;
            if (pattern == null) return "";
            if (pattern.BuiltIn) return "";
            DateTime ret = date.Date + pattern.Start;
            return ret.ToLongDateString() + " " + ret.ToLongTimeString();
        }
        /// <summary>勤務シフトの長さを返す
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        private string ReturnPatternLength(DateTime date, BMember member, bool head) {
            if (head) return member.Name + "の勤務時間";
            BScheduledDate sdate = TimeTable[date];
            BSchedule schdule = sdate[member];
            if (schdule == null) return TimeSpan.Zero.ToString();
            BPattern pattern = schdule.Pattern;
            if (pattern == null) return TimeSpan.Zero.ToString();
            if (pattern.BuiltIn) return TimeSpan.Zero.ToString();
            return pattern.Scope.ToString();
        }
        /// <summary>勤務シフトの終了を返す
        /// </summary>
        /// <param name="date"></param>
        /// <param name="member"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        private string ReturnPatternEnd(DateTime date, BMember member, bool head) {
            if (head) return member.Name + "のシフト終了";
            BScheduledDate sdate = TimeTable[date];
            BSchedule schdule = sdate[member];
            if (schdule == null) return "";
            BPattern pattern = schdule.Pattern;
            if (pattern == null) return "";
            if (pattern.BuiltIn) return "";
            DateTime ret = date.Date + pattern.End;
            return ret.ToLongDateString() + " " + ret.ToLongTimeString();
        }
    }
    /// <summary>CSV出力アイテム
    /// </summary>
    public enum EnmCSVItem {
        /// <summary>日付</summary>
        ItmDate,
        /// <summary>人員配置名称</summary>
        ItmRequireName,
        /// <summary>勤務シフト名</summary>
        ItmPatternName,
        /// <summary>勤務シフト開始</summary>
        ItmPatternStart,
        /// <summary>勤務シフトの長さ</summary>
        ItmPatternLength,
        /// <summary>勤務シフトの終了</summary>
        ItmPatternEnd
    }
}