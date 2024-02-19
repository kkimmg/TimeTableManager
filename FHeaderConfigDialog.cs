using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Element;
using TimeTableManager.Printing;

namespace TimeTableManager.UI {
    /// <summary>印刷ヘッダの設定ダイアログ
    /// </summary>
    public partial class FHeaderConfigDialog : Form {
        /// <summary>
        /// タイムテーブル
        /// </summary>
        private BTimeTable timeTable;
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public BTimeTable TimeTable {
            get { return timeTable; }
            set { timeTable = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FHeaderConfigDialog () {
            InitializeComponent();
        }
        /// <summary>
        /// 左側のフォント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnLeftFont_Click (object sender, EventArgs e) {
            dlgLeftFont.ShowDialog(this);
        }
        /// <summary>
        /// 中央のフォント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnCenterFont_Click (object sender, EventArgs e) {
            dlgCenterFont.ShowDialog(this);
        }
        /// <summary>
        /// 右側のフォント
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnRightFont_Click (object sender, EventArgs e) {
            dlgRightFont.ShowDialog(this);
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnOK_Click (object sender, EventArgs e) {
            BPrintDocumentBody.SetFont(TimeTable, BPrintDocumentHeader.RIT_LEFTFONT, dlgLeftFont.Font);
            BPrintDocumentBody.SetFont(TimeTable, BPrintDocumentHeader.RIT_CENTERFONT, dlgCenterFont.Font);
            BPrintDocumentBody.SetFont(TimeTable, BPrintDocumentHeader.RIT_RIGHTFONT, dlgRightFont.Font);
            TimeTable[BPrintDocumentHeader.RIT_LEFTTEXT] = cmbLeftText.Text;
            TimeTable[BPrintDocumentHeader.RIT_CENTERTEXT] = cmbCenterText.Text;
            TimeTable[BPrintDocumentHeader.RIT_RIGHTTEXT] = cmbRightText.Text;
            TimeTable[BPrintDocumentHeader.RIT_DATEFORMAT] = cmbDateFormat.Text;
            TimeTable[BPrintDocumentHeader.RIT_PAGEFORMAT] = txtPageFormat.Text;
            TimeTable[BPrintDocumentHeader.RIT_PAGEALLFORMAT] = txtPageAllFormat.Text;
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
        /// 初期値の設定
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void HeaderConfigDialog_Shown (object sender, EventArgs e) {
            // 左
            dlgLeftFont.Font = BPrintDocumentBody.GetFont(TimeTable, BPrintDocumentHeader.RIT_LEFTFONT);
            string LeftText = TimeTable[BPrintDocumentHeader.RIT_LEFTTEXT];
            if (LeftText != null) {
                cmbLeftText.Text = LeftText;
            } else {
                cmbLeftText.Text = BPrintDocumentHeader.RIT_LEFTTEXT_DEFAULT;
            }
            // 中央
            dlgCenterFont.Font = BPrintDocumentBody.GetFont(TimeTable, BPrintDocumentHeader.RIT_CENTERFONT);
            string CenterText = TimeTable[BPrintDocumentHeader.RIT_CENTERTEXT];
            if (CenterText != null) {
                cmbCenterText.Text = CenterText;
            } else {
                cmbCenterText.Text = BPrintDocumentHeader.RIT_CENTERTEXT_DEFAULT;
            }
            // 右
            dlgRightFont.Font = BPrintDocumentBody.GetFont(TimeTable, BPrintDocumentHeader.RIT_RIGHTFONT);
            string RightText = TimeTable[BPrintDocumentHeader.RIT_RIGHTTEXT];
            if (RightText != null) {
                cmbRightText.Text = RightText;
            } else {
                cmbRightText.Text = BPrintDocumentHeader.RIT_RIGHTTEXT_DEFAULT;
            }
            // 日付フォーマット
            string dateformat = TimeTable[BPrintDocumentHeader.RIT_DATEFORMAT];
            if (dateformat != null) {
                cmbDateFormat.Text = dateformat;
            } else {
                cmbDateFormat.Text = BPrintDocumentHeader.RIT_DATEFORMAT_DEFAULT;
            }
            // ページ
            string pageformt = TimeTable[BPrintDocumentHeader.RIT_PAGE];
            if (pageformt != null) {
                txtPageFormat.Text = pageformt;
            } else {
                txtPageFormat.Text = "";
            }
            // 全ページ
            string pageallformt = TimeTable[BPrintDocumentHeader.RIT_PAGEALL];
            if (pageallformt != null) {
                txtPageAllFormat.Text = pageallformt;
            } else {
                txtPageAllFormat.Text = "";
            }
        }


    }
}