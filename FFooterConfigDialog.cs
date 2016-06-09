using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Printing;

namespace TimeTableManager.UI {
    /// <summary>印刷フッタの設定ダイアログ
    /// </summary>
    public partial class FFooterConfigDialog : Form {
        /// <summary>
        /// タイムテーブル
        /// </summary>
        private TimeTableManager.Element.CTimeTable timeTable;
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public TimeTableManager.Element.CTimeTable TimeTable {
            get { return timeTable; }
            set { timeTable = value; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        public FFooterConfigDialog () {
            InitializeComponent();
        }
        /// <summary>
        /// フォントの選択
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnFont_Click (object sender, EventArgs e) {
            dlgFont.ShowDialog(this);
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnOK_Click (object sender, EventArgs e) {
            CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentFooter.RIT_FONT, dlgFont.Font);
            TimeTable[CPrintDocumentFooter.RIT_FORMAT] = cmbFormat.Text;
            TimeTable[CPrintDocumentFooter.RIT_COLUMN] = nupColumnCount.Value.ToString();
        }
        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnCancel_Click (object sender, EventArgs e) {
            Dispose();
        }
        /// <summary>
        /// 初期値
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void FooterConfigDialog_Shown (object sender, EventArgs e) {
            dlgFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentFooter.RIT_FONT);
            // 書式
            string format = TimeTable[CPrintDocumentFooter.RIT_FORMAT];
            if (format == null) {
                format = CPrintDocumentFooter.RID_FORMAT_DEFAULT;
            } else if (format.Trim().Length == 0) {
                format = CPrintDocumentFooter.RID_FORMAT_DEFAULT;
            }
            cmbFormat.Text = format;
            // 列数
            string column = TimeTable[CPrintDocumentFooter.RIT_COLUMN];
            int icolumn = CPrintDocumentFooter.RIT_COLUMN_DEFAULT;
            if (column != null) {
                if (!(int.TryParse(column, out icolumn))) {
                    icolumn = CPrintDocumentFooter.RIT_COLUMN_DEFAULT;
                }
            }
            nupColumnCount.Value = icolumn;
        }
    }
}