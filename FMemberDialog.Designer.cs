using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TimeTableManager.Element;
using TimeTableManager.ElementCollection;
namespace TimeTableManager.UI {
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
    public partial class FMemberDialog : System.Windows.Forms.Form {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRemoved;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker txtCreated;
        private System.Windows.Forms.DateTimePicker txtRemoved;
        private System.Windows.Forms.CheckedListBox LstPatterns;
        private System.Data.DataTable TblPatterns;
        private System.Data.DataColumn ClmPattern;
        private System.Data.DataColumn ClmPatternName;
        private System.Windows.Forms.NumericUpDown NumPriority;
        private System.Windows.Forms.TextBox TxtMemberName;
        private System.Windows.Forms.DateTimePicker TxtWorkTime;
        private System.Windows.Forms.TextBox TxtRest;
        private System.Data.DataSet DsPatterns;
        private System.Windows.Forms.CheckBox ChkChief;
        private GroupBox groupBox1;
        private CheckBox chkSunday;
        private CheckBox chkSaturday;
        private CheckBox chkFriday;
        private CheckBox chkThursday;
        private CheckBox chkWednesday;
        private CheckBox chkTuesday;
        private CheckBox chkMonday;
        private Label label6;
        private DateTimePicker dtpSpace;
        private Label label8;
        private NumericUpDown numContinuas;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;



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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkChief = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.NumPriority = new System.Windows.Forms.NumericUpDown();
            this.TxtMemberName = new System.Windows.Forms.TextBox();
            this.txtCreated = new System.Windows.Forms.DateTimePicker();
            this.lblRemoved = new System.Windows.Forms.Label();
            this.txtRemoved = new System.Windows.Forms.DateTimePicker();
            this.TxtWorkTime = new System.Windows.Forms.DateTimePicker();
            this.LstPatterns = new System.Windows.Forms.CheckedListBox();
            this.TblPatterns = new System.Data.DataTable();
            this.ClmPattern = new System.Data.DataColumn();
            this.ClmPatternName = new System.Data.DataColumn();
            this.DsPatterns = new System.Data.DataSet();
            this.TxtRest = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSpace = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.numContinuas = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPatterns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPatterns)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContinuas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "優先順位";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "メンバー名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ChkChief
            // 
            this.ChkChief.Location = new System.Drawing.Point(8, 133);
            this.ChkChief.Name = "ChkChief";
            this.ChkChief.Size = new System.Drawing.Size(136, 24);
            this.ChkChief.TabIndex = 2;
            this.ChkChief.Text = "チーフメンバーです";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "平均作業時間（予定）";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "休日の間隔（予定）";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "作成日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(191, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "キャンセル";
            // 
            // NumPriority
            // 
            this.NumPriority.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NumPriority.Location = new System.Drawing.Point(224, 136);
            this.NumPriority.Name = "NumPriority";
            this.NumPriority.Size = new System.Drawing.Size(48, 19);
            this.NumPriority.TabIndex = 3;
            // 
            // TxtMemberName
            // 
            this.TxtMemberName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TxtMemberName.Location = new System.Drawing.Point(80, 8);
            this.TxtMemberName.Name = "TxtMemberName";
            this.TxtMemberName.Size = new System.Drawing.Size(272, 19);
            this.TxtMemberName.TabIndex = 0;
            // 
            // txtCreated
            // 
            this.txtCreated.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCreated.Location = new System.Drawing.Point(55, 385);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Size = new System.Drawing.Size(112, 19);
            this.txtCreated.TabIndex = 14;
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.Location = new System.Drawing.Point(189, 388);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(41, 12);
            this.lblRemoved.TabIndex = 14;
            this.lblRemoved.Text = "削除日";
            this.lblRemoved.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblRemoved.Visible = false;
            // 
            // txtRemoved
            // 
            this.txtRemoved.Enabled = false;
            this.txtRemoved.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtRemoved.Location = new System.Drawing.Point(239, 385);
            this.txtRemoved.Name = "txtRemoved";
            this.txtRemoved.Size = new System.Drawing.Size(112, 19);
            this.txtRemoved.TabIndex = 15;
            this.txtRemoved.Visible = false;
            // 
            // TxtWorkTime
            // 
            this.TxtWorkTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TxtWorkTime.Location = new System.Drawing.Point(315, 261);
            this.TxtWorkTime.Name = "TxtWorkTime";
            this.TxtWorkTime.ShowUpDown = true;
            this.TxtWorkTime.Size = new System.Drawing.Size(18, 19);
            this.TxtWorkTime.TabIndex = 17;
            this.TxtWorkTime.Value = new System.DateTime(2005, 5, 12, 8, 0, 0, 0);
            this.TxtWorkTime.Visible = false;
            // 
            // LstPatterns
            // 
            this.LstPatterns.CheckOnClick = true;
            this.LstPatterns.DataSource = this.TblPatterns;
            this.LstPatterns.DisplayMember = "ClmPatternName";
            this.LstPatterns.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LstPatterns.Location = new System.Drawing.Point(8, 40);
            this.LstPatterns.Name = "LstPatterns";
            this.LstPatterns.Size = new System.Drawing.Size(344, 88);
            this.LstPatterns.TabIndex = 1;
            this.LstPatterns.ValueMember = "ClmPattern";
            // 
            // TblPatterns
            // 
            this.TblPatterns.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmPattern,
            this.ClmPatternName});
            this.TblPatterns.TableName = "TblPatterns";
            // 
            // ClmPattern
            // 
            this.ClmPattern.Caption = "勤務シフト";
            this.ClmPattern.ColumnName = "ClmPattern";
            this.ClmPattern.DataType = typeof(TimeTableManager.Element.BPattern);
            // 
            // ClmPatternName
            // 
            this.ClmPatternName.Caption = "勤務シフト";
            this.ClmPatternName.ColumnName = "ClmPatternName";
            // 
            // DsPatterns
            // 
            this.DsPatterns.DataSetName = "DsPatterns";
            this.DsPatterns.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.DsPatterns.Tables.AddRange(new System.Data.DataTable[] {
            this.TblPatterns});
            // 
            // TxtRest
            // 
            this.TxtRest.Location = new System.Drawing.Point(315, 282);
            this.TxtRest.Name = "TxtRest";
            this.TxtRest.Size = new System.Drawing.Size(18, 19);
            this.TxtRest.TabIndex = 19;
            this.TxtRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtRest.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSunday);
            this.groupBox1.Controls.Add(this.chkSaturday);
            this.groupBox1.Controls.Add(this.chkFriday);
            this.groupBox1.Controls.Add(this.chkThursday);
            this.groupBox1.Controls.Add(this.chkWednesday);
            this.groupBox1.Controls.Add(this.chkTuesday);
            this.groupBox1.Controls.Add(this.chkMonday);
            this.groupBox1.Location = new System.Drawing.Point(8, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 85);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "稼働日";
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.ForeColor = System.Drawing.Color.Red;
            this.chkSunday.Location = new System.Drawing.Point(118, 63);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(60, 16);
            this.chkSunday.TabIndex = 10;
            this.chkSunday.Text = "日曜日";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.ForeColor = System.Drawing.Color.Blue;
            this.chkSaturday.Location = new System.Drawing.Point(7, 63);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(60, 16);
            this.chkSaturday.TabIndex = 9;
            this.chkSaturday.Text = "土曜日";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(118, 41);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(60, 16);
            this.chkFriday.TabIndex = 8;
            this.chkFriday.Text = "金曜日";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(7, 41);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(60, 16);
            this.chkThursday.TabIndex = 7;
            this.chkThursday.Text = "木曜日";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(204, 18);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(60, 16);
            this.chkWednesday.TabIndex = 6;
            this.chkWednesday.Text = "水曜日";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(118, 18);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(60, 16);
            this.chkTuesday.TabIndex = 5;
            this.chkTuesday.Text = "火曜日";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(7, 19);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(60, 16);
            this.chkMonday.TabIndex = 4;
            this.chkMonday.Text = "月曜日";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "稼動間隔";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpSpace
            // 
            this.dtpSpace.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSpace.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtpSpace.Location = new System.Drawing.Point(126, 258);
            this.dtpSpace.Name = "dtpSpace";
            this.dtpSpace.ShowUpDown = true;
            this.dtpSpace.Size = new System.Drawing.Size(104, 19);
            this.dtpSpace.TabIndex = 11;
            this.dtpSpace.Value = new System.DateTime(2005, 5, 12, 8, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "連続稼働日";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numContinuas
            // 
            this.numContinuas.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numContinuas.Location = new System.Drawing.Point(126, 283);
            this.numContinuas.Name = "numContinuas";
            this.numContinuas.Size = new System.Drawing.Size(104, 19);
            this.numContinuas.TabIndex = 12;
            this.numContinuas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "メモ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNotes
            // 
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNotes.Location = new System.Drawing.Point(77, 308);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(272, 73);
            this.txtNotes.TabIndex = 13;
            // 
            // MemberDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 437);
            this.ControlBox = false;
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numContinuas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpSpace);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtRest);
            this.Controls.Add(this.lblRemoved);
            this.Controls.Add(this.TxtMemberName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstPatterns);
            this.Controls.Add(this.TxtWorkTime);
            this.Controls.Add(this.txtRemoved);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.NumPriority);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ChkChief);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "メンバーのプロパティ";
            this.Shown += new System.EventHandler(this.MemberDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPatterns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPatterns)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContinuas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label label7;
        private TextBox txtNotes;

    }
}
