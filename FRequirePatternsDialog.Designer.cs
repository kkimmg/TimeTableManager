using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TimeTableManager.Element;

namespace TimeTableManager.UI {

    /// <summary>
    /// RequirePatternsDialog の概要の説明です。
    /// </summary>
    public partial class FRequirePatternsDialog : System.Windows.Forms.Form {
        private System.Windows.Forms.DateTimePicker txtRemoved;
        private System.Windows.Forms.Label lblRemoved;
        private System.Windows.Forms.DateTimePicker txtCreated;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRequireName;
        private System.Windows.Forms.DataGridView RequiresList;
        private System.Data.DataSet DsRequires;
        private System.Data.DataTable TblRequires;
        private System.Data.DataColumn ClmPattern;
        private System.Data.DataColumn ClmPatternName;
        private System.Data.DataColumn ClmRequireNum;
        private System.Data.DataView DvRequires;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn clmPatternNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clmPatternDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn clmRequireNumDataGridViewComboBoxColumn;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRemoved = new System.Windows.Forms.DateTimePicker();
            this.lblRemoved = new System.Windows.Forms.Label();
            this.txtCreated = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRequireName = new System.Windows.Forms.TextBox();
            this.RequiresList = new System.Windows.Forms.DataGridView();
            this.clmPatternNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPatternDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRequireNumDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DvRequires = new System.Data.DataView();
            this.TblRequires = new System.Data.DataTable();
            this.ClmPattern = new System.Data.DataColumn();
            this.ClmPatternName = new System.Data.DataColumn();
            this.ClmRequireNum = new System.Data.DataColumn();
            this.DsRequires = new System.Data.DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RequiresList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DvRequires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRequires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRequires)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRemoved
            // 
            this.txtRemoved.Enabled = false;
            this.txtRemoved.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtRemoved.Location = new System.Drawing.Point(238, 292);
            this.txtRemoved.Name = "txtRemoved";
            this.txtRemoved.Size = new System.Drawing.Size(112, 19);
            this.txtRemoved.TabIndex = 4;
            this.txtRemoved.Visible = false;
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.Location = new System.Drawing.Point(190, 292);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(41, 12);
            this.lblRemoved.TabIndex = 26;
            this.lblRemoved.Text = "削除日";
            this.lblRemoved.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblRemoved.Visible = false;
            // 
            // txtCreated
            // 
            this.txtCreated.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCreated.Location = new System.Drawing.Point(54, 292);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Size = new System.Drawing.Size(112, 19);
            this.txtCreated.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "キャンセル";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(190, 316);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "作成日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "人員配置名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TxtRequireName
            // 
            this.TxtRequireName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TxtRequireName.Location = new System.Drawing.Point(88, 8);
            this.TxtRequireName.Name = "TxtRequireName";
            this.TxtRequireName.Size = new System.Drawing.Size(264, 19);
            this.TxtRequireName.TabIndex = 0;
            // 
            // RequiresList
            // 
            this.RequiresList.AutoGenerateColumns = false;
            this.RequiresList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPatternNameDataGridViewTextBoxColumn,
            this.clmPatternDataGridViewTextBoxColumn,
            this.clmRequireNumDataGridViewComboBoxColumn});
            this.RequiresList.DataSource = this.DvRequires;
            this.RequiresList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.RequiresList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RequiresList.Location = new System.Drawing.Point(8, 32);
            this.RequiresList.Name = "RequiresList";
            this.RequiresList.RowHeadersWidth = 15;
            this.RequiresList.RowTemplate.Height = 21;
            this.RequiresList.Size = new System.Drawing.Size(344, 160);
            this.RequiresList.TabIndex = 1;
            this.RequiresList.Validated += new System.EventHandler(this.RequiresList_Validated);
            this.RequiresList.Validating += new System.ComponentModel.CancelEventHandler(this.RequiresList_Validating);
            // 
            // clmPatternNameDataGridViewTextBoxColumn
            // 
            this.clmPatternNameDataGridViewTextBoxColumn.DataPropertyName = "ClmPatternName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmPatternNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmPatternNameDataGridViewTextBoxColumn.HeaderText = "勤務シフト";
            this.clmPatternNameDataGridViewTextBoxColumn.Name = "clmPatternNameDataGridViewTextBoxColumn";
            this.clmPatternNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.clmPatternNameDataGridViewTextBoxColumn.Width = 226;
            // 
            // clmPatternDataGridViewTextBoxColumn
            // 
            this.clmPatternDataGridViewTextBoxColumn.DataPropertyName = "ClmPattern";
            this.clmPatternDataGridViewTextBoxColumn.HeaderText = "勤務シフト（非表示）";
            this.clmPatternDataGridViewTextBoxColumn.Name = "clmPatternDataGridViewTextBoxColumn";
            this.clmPatternDataGridViewTextBoxColumn.ReadOnly = true;
            this.clmPatternDataGridViewTextBoxColumn.Visible = false;
            // 
            // clmRequireNumDataGridViewComboBoxColumn
            // 
            this.clmRequireNumDataGridViewComboBoxColumn.DataPropertyName = "ClmRequireNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            this.clmRequireNumDataGridViewComboBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmRequireNumDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.clmRequireNumDataGridViewComboBoxColumn.DisplayStyleForCurrentCellOnly = true;
            this.clmRequireNumDataGridViewComboBoxColumn.HeaderText = "人数";
            this.clmRequireNumDataGridViewComboBoxColumn.Name = "clmRequireNumDataGridViewComboBoxColumn";
            this.clmRequireNumDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRequireNumDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DvRequires
            // 
            this.DvRequires.AllowDelete = false;
            this.DvRequires.AllowNew = false;
            this.DvRequires.Table = this.TblRequires;
            this.DvRequires.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.DvRequires_ListChanged);
            // 
            // TblRequires
            // 
            this.TblRequires.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmPattern,
            this.ClmPatternName,
            this.ClmRequireNum});
            this.TblRequires.TableName = "TblRequires";
            // 
            // ClmPattern
            // 
            this.ClmPattern.Caption = "勤務シフト";
            this.ClmPattern.ColumnName = "ClmPattern";
            this.ClmPattern.DataType = typeof(TimeTableManager.Element.BPattern);
            this.ClmPattern.ReadOnly = true;
            // 
            // ClmPatternName
            // 
            this.ClmPatternName.Caption = "勤務シフト";
            this.ClmPatternName.ColumnName = "ClmPatternName";
            this.ClmPatternName.ReadOnly = true;
            // 
            // ClmRequireNum
            // 
            this.ClmRequireNum.Caption = "人数";
            this.ClmRequireNum.ColumnName = "ClmRequireNum";
            this.ClmRequireNum.DataType = typeof(int);
            this.ClmRequireNum.DefaultValue = 0;
            // 
            // DsRequires
            // 
            this.DsRequires.DataSetName = "DsRequires";
            this.DsRequires.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.DsRequires.Tables.AddRange(new System.Data.DataTable[] {
            this.TblRequires});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "合計人数";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(280, 200);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 16);
            this.lblTotal.TabIndex = 32;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn1.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ClmPattern";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn3.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn4.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn5.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn6.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn7.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "ClmRequireNum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = "0";
            this.dataGridViewComboBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewComboBoxColumn1.HeaderText = "人数";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn8.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn9.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn10.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn11.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn12.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn13.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn14.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ClmPattern";
            this.dataGridViewTextBoxColumn15.HeaderText = "勤務シフト（非表示）";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "ClmRequireNum";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = "0";
            this.dataGridViewComboBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dataGridViewComboBoxColumn2.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn2.HeaderText = "人数";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "メモ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNote
            // 
            this.txtNote.AcceptsReturn = true;
            this.txtNote.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNote.Location = new System.Drawing.Point(88, 219);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(264, 67);
            this.txtNote.TabIndex = 2;
            // 
            // RequirePatternsDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(360, 344);
            this.ControlBox = false;
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RequiresList);
            this.Controls.Add(this.TxtRequireName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRemoved);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemoved);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequirePatternsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "人員配置";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.RequirePatternsDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.RequiresList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DvRequires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRequires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRequires)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label label3;
        private TextBox txtNote;


    }
}
