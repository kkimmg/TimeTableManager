using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TimeTableManager.UI {
    /// <summary>
    /// DisplayCalendarDialog の概要の説明です。
    /// </summary>
    public class FDisplayCalendarDialog : System.Windows.Forms.Form {
        private System.Windows.Forms.DateTimePicker txtStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtEnd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnCurrMonth;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>コンストラクタ
        /// </summary>
        public FDisplayCalendarDialog () {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose (bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent () {
            this.txtStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnCurrMonth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(80, 16);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(120, 19);
            this.txtStart.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "表示期間";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "～";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(240, 16);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(120, 19);
            this.txtEnd.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(200, 48);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(280, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "キャンセル";
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Location = new System.Drawing.Point(8, 48);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(48, 23);
            this.btnPrevMonth.TabIndex = 6;
            this.btnPrevMonth.Text = "先月";
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(120, 48);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(48, 23);
            this.btnNextMonth.TabIndex = 7;
            this.btnNextMonth.Text = "来月";
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnCurrMonth
            // 
            this.btnCurrMonth.Location = new System.Drawing.Point(64, 48);
            this.btnCurrMonth.Name = "btnCurrMonth";
            this.btnCurrMonth.Size = new System.Drawing.Size(48, 23);
            this.btnCurrMonth.TabIndex = 8;
            this.btnCurrMonth.Text = "今月";
            this.btnCurrMonth.Click += new System.EventHandler(this.btnCurrMonth_Click);
            // 
            // DisplayCalendarDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(368, 77);
            this.ControlBox = false;
            this.Controls.Add(this.btnCurrMonth);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayCalendarDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "表示範囲の指定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        private void btnOK_Click (object sender, System.EventArgs e) {

        }

        private void btnPrevMonth_Click (object sender, System.EventArgs e) {
            DateTime today = DateTime.Today;
            DateTime first = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            DateTime last = first.AddMonths(1).AddDays(-1);
            this.txtStart.Value = first;
            this.txtEnd.Value = last;
        }

        private void btnCurrMonth_Click (object sender, System.EventArgs e) {
            DateTime today = DateTime.Today;
            DateTime first = new DateTime(today.Year, today.Month, 1);
            DateTime last = first.AddMonths(1).AddDays(-1);
            this.txtStart.Value = first;
            this.txtEnd.Value = last;
        }

        private void btnNextMonth_Click (object sender, System.EventArgs e) {
            DateTime today = DateTime.Today;
            DateTime first = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            DateTime last = first.AddMonths(1).AddDays(-1);
            this.txtStart.Value = first;
            this.txtEnd.Value = last;
        }

        /// <summary>
        /// 表示期間の開始
        /// </summary>
        public DateTime StartDate {
            get {
                return this.txtStart.Value;
            }
            set {
                this.txtStart.Value = value;
            }
        }

        /// <summary>
        /// 表示期間の終了
        /// </summary>
        public DateTime EndDate {
            get {
                return this.txtEnd.Value;
            }
            set {
                this.txtEnd.Value = value;
            }
        }
    }
}
