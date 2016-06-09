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
        private CTimeTable timeTable;
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public CTimeTable TimeTable {
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
            CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentHeader.RIT_LEFTFONT, dlgLeftFont.Font);
            CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentHeader.RIT_CENTERFONT, dlgCenterFont.Font);
            CPrintDocumentBody.SetFont(TimeTable, CPrintDocumentHeader.RIT_RIGHTFONT, dlgRightFont.Font);
            TimeTable[CPrintDocumentHeader.RIT_LEFTTEXT] = cmbLeftText.Text;
            TimeTable[CPrintDocumentHeader.RIT_CENTERTEXT] = cmbCenterText.Text;
            TimeTable[CPrintDocumentHeader.RIT_RIGHTTEXT] = cmbRightText.Text;
            TimeTable[CPrintDocumentHeader.RIT_DATEFORMAT] = cmbDateFormat.Text;
            TimeTable[CPrintDocumentHeader.RIT_PAGEFORMAT] = txtPageFormat.Text;
            TimeTable[CPrintDocumentHeader.RIT_PAGEALLFORMAT] = txtPageAllFormat.Text;
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
            dlgLeftFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentHeader.RIT_LEFTFONT);
            string LeftText = TimeTable[CPrintDocumentHeader.RIT_LEFTTEXT];
            if (LeftText != null) {
                cmbLeftText.Text = LeftText;
            } else {
                cmbLeftText.Text = CPrintDocumentHeader.RIT_LEFTTEXT_DEFAULT;
            }
            // 中央
            dlgCenterFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentHeader.RIT_CENTERFONT);
            string CenterText = TimeTable[CPrintDocumentHeader.RIT_CENTERTEXT];
            if (CenterText != null) {
                cmbCenterText.Text = CenterText;
            } else {
                cmbCenterText.Text = CPrintDocumentHeader.RIT_CENTERTEXT_DEFAULT;
            }
            // 右
            dlgRightFont.Font = CPrintDocumentBody.GetFont(TimeTable, CPrintDocumentHeader.RIT_RIGHTFONT);
            string RightText = TimeTable[CPrintDocumentHeader.RIT_RIGHTTEXT];
            if (RightText != null) {
                cmbRightText.Text = RightText;
            } else {
                cmbRightText.Text = CPrintDocumentHeader.RIT_RIGHTTEXT_DEFAULT;
            }
            // 日付フォーマット
            string dateformat = TimeTable[CPrintDocumentHeader.RIT_DATEFORMAT];
            if (dateformat != null) {
                cmbDateFormat.Text = dateformat;
            } else {
                cmbDateFormat.Text = CPrintDocumentHeader.RIT_DATEFORMAT_DEFAULT;
            }
            // ページ
            string pageformt = TimeTable[CPrintDocumentHeader.RIT_PAGE];
            if (pageformt != null) {
                txtPageFormat.Text = pageformt;
            } else {
                txtPageFormat.Text = "";
            }
            // 全ページ
            string pageallformt = TimeTable[CPrintDocumentHeader.RIT_PAGEALL];
            if (pageallformt != null) {
                txtPageAllFormat.Text = pageallformt;
            } else {
                txtPageAllFormat.Text = "";
            }
        }


    }
}