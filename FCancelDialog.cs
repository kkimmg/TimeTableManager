using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TimeTableManager {
    /// <summary>自動設定のキャンセルダイアログ
    /// </summary>
    public partial class FCancelDialog : Form {
        /// <summary>自動設定処理
        /// </summary>
        public BackgroundWorker Worker {
            get {
                return BgSetting;
            }
        }
        /// <summary>コンストラクタ
        /// </summary>
        public FCancelDialog() {
            InitializeComponent();
        }
        /// <summary>スレッドを終了して画面を閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e) {
            BgSetting.CancelAsync();
            Dispose();
        }

        private void BgSetting_ProgressChanged (object sender, ProgressChangedEventArgs e) {
            BgProgress.Value = e.ProgressPercentage;
        }
    }
}