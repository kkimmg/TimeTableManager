using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimeTableManager.UI {
    /// <summary>最近使ったファイルダイアログ
    /// </summary>
    public partial class FResentFileDialog : Form {
        /// <summary>コンストラクタ
        /// </summary>
        public FResentFileDialog () {
            InitializeComponent();
        }
        /// <summary>選択されたファイル
        /// </summary>
        public string SelectedFile {
            get {
                return (lstResentFile.SelectedItem == null ? "": lstResentFile.SelectedItem as string);
            }
        }
        /// <summary>OKボタンが押された
        /// </summary>
        /// <param name="sender">発生元</param>
        /// <param name="e">イベント</param>
        private void BtnOK_Click (object sender, EventArgs e) {
            if (SelectedFile != "") {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        /// <summary>キャンセルボタンが押された
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnCancel_Click (object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        /// <summary>一覧がダブルクリックされた
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void lstResentFile_DoubleClick (object sender, EventArgs e) {
            BtnOK_Click(sender, e);
        }
        /// <summary>画面が表示されたとき最近使ったファイルの一覧を作成する
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void ResentFileDialog_Shown (object sender, EventArgs e) {
            this.lstResentFile.Items.Clear();
            foreach (string x in FMainForm.Instance.Recents) {
                this.lstResentFile.Items.Add(x);
            }
        }
        /// <summary>最近使ったファイルダイアログを表示する
        /// </summary>
        /// <param name="owner">親画面（メインウインドウ）</param>
        /// <returns>選択されたファイル</returns>
        public static string ShowRecents (Form owner) {
            FResentFileDialog rfd = new FResentFileDialog();
            if (rfd.ShowDialog(owner) == DialogResult.OK) {
                return rfd.SelectedFile;
            }
            return "";
        }
    }
}