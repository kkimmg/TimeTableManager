using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TimeTableManager.UI {
    /// <summary>
    /// PatternDialog の概要の説明です。
    /// </summary>
    public partial class FPatternDialog : System.Windows.Forms.Form {
        #region コンポーネント変数
        private System.Windows.Forms.DateTimePicker txtRemoved;
        private System.Windows.Forms.Label lblRemoved;
        private System.Windows.Forms.DateTimePicker txtCreated;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtStart;
        private System.Windows.Forms.DateTimePicker txtEnd;
        private System.Windows.Forms.DateTimePicker txtRest;
        private System.Windows.Forms.TextBox txtName;
        #endregion
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private Label label6;
        private TextBox txtNotes;
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
            this.txtRemoved = new System.Windows.Forms.DateTimePicker();
            this.lblRemoved = new System.Windows.Forms.Label();
            this.txtCreated = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.DateTimePicker();
            this.txtRest = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtRemoved
            // 
            this.txtRemoved.Enabled = false;
            this.txtRemoved.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtRemoved.Location = new System.Drawing.Point(240, 147);
            this.txtRemoved.Name = "txtRemoved";
            this.txtRemoved.Size = new System.Drawing.Size(112, 19);
            this.txtRemoved.TabIndex = 6;
            this.txtRemoved.Visible = false;
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.Location = new System.Drawing.Point(192, 147);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(41, 12);
            this.lblRemoved.TabIndex = 20;
            this.lblRemoved.Text = "削除日";
            this.lblRemoved.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblRemoved.Visible = false;
            // 
            // txtCreated
            // 
            this.txtCreated.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCreated.Location = new System.Drawing.Point(56, 147);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Size = new System.Drawing.Size(112, 19);
            this.txtCreated.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "キャンセル";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(192, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "作成日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "勤務シフト";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "勤務時間";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtStart
            // 
            this.txtStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtStart.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtStart.Location = new System.Drawing.Point(80, 32);
            this.txtStart.Name = "txtStart";
            this.txtStart.ShowUpDown = true;
            this.txtStart.Size = new System.Drawing.Size(112, 19);
            this.txtStart.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "休憩時間";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "～";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEnd
            // 
            this.txtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtEnd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtEnd.Location = new System.Drawing.Point(240, 32);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ShowUpDown = true;
            this.txtEnd.Size = new System.Drawing.Size(112, 19);
            this.txtEnd.TabIndex = 2;
            // 
            // txtRest
            // 
            this.txtRest.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtRest.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtRest.Location = new System.Drawing.Point(80, 56);
            this.txtRest.Name = "txtRest";
            this.txtRest.ShowUpDown = true;
            this.txtRest.Size = new System.Drawing.Size(112, 19);
            this.txtRest.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(80, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(272, 19);
            this.txtName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "メモ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNotes
            // 
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNotes.Location = new System.Drawing.Point(80, 82);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(272, 59);
            this.txtNotes.TabIndex = 4;
            // 
            // PatternDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 202);
            this.ControlBox = false;
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRemoved);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRest);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.txtRemoved);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatternDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "勤務シフトのプロパティ";
            this.Shown += new System.EventHandler(this.PatternDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


    }
}
