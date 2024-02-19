using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TimeTableManager.Component;
using TimeTableManager.Element;
using TimeTableManager.Printing;

namespace TimeTableManager.UI {
    /// <summary>
    /// ScheduleConfigDialog の概要の説明です。
    /// </summary>
    public partial class FScheduleConfigDialog : System.Windows.Forms.Form {
        private System.Windows.Forms.TabControl tabPrint;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabPattern;
        private System.Windows.Forms.TabPage tabMember;
        private System.Windows.Forms.TabPage tabDayOffs;
        private System.Windows.Forms.TabPage tabRequirePatterns;
        private System.Windows.Forms.TabPage tabOthers;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ToolBarButton btnAddPattern;
        private System.Windows.Forms.ToolBarButton btnEditPattern;
        private System.Windows.Forms.ToolBarButton btnDeletePattern;
        private System.Windows.Forms.ListBox lstPatterns;
        private System.Data.DataSet PatternDataSet;
        private System.Data.DataTable PatternTable;
        private System.Data.DataColumn PatternColumn;
        private System.Data.DataColumn PatternNameColumn;
        private System.Data.DataSet MemberDataSet;
        private System.Data.DataTable MemberTable;
        private System.Data.DataColumn MemberColumn;
        private System.Data.DataColumn MemberNameColumn;
        private System.Data.DataSet RequirePatternsDataSet;
        private System.Data.DataTable RequirePatternsTable;
        private System.Data.DataColumn RequirePatternsColumn;
        private System.Data.DataColumn RequirePatternsNameColumn;
        private System.Windows.Forms.ListBox lstRequirePatterns;
        private System.Windows.Forms.ToolBarButton BtnAddMember;
        private System.Windows.Forms.ToolBarButton BtnEditMember;
        private System.Windows.Forms.ToolBarButton BtnDeleteMember;
        private System.Windows.Forms.ListBox lstMembers;
        private System.Windows.Forms.ToolBar MemberToolBar;
        private System.Windows.Forms.ToolBar PatternToolBar;
        private System.Windows.Forms.ToolBar HollyDayToolBar;
        private System.Data.DataSet WeekDateSet;
        private System.Data.DataTable WeekDayTable;
        private System.Data.DataColumn WeekDayColumn;
        private System.Data.DataColumn WeekDayNameColumn;
        private System.Windows.Forms.ListBox DayOffList;
        private System.Data.DataSet DayOffDataSet;
        private System.Data.DataTable DayOffTable;
        private System.Data.DataColumn DayOffColumn;
        private System.Windows.Forms.ToolBarButton TbbAddDayOff;
        private System.Windows.Forms.ToolBarButton TbbRemoveDayOff;
        private System.Windows.Forms.ToolBarButton TbbEditDayOff;
        private System.Data.DataColumn DayOffNameColumn;
        private System.Data.DataColumn DayOffStartColumn;
        private System.Data.DataColumn DayOffEndColumn;
        private System.Windows.Forms.ToolBar RequiresToolBar;
        private System.Windows.Forms.ToolBarButton TbbAddRequires;
        private System.Windows.Forms.ToolBarButton TbbEditRequires;
        private System.Windows.Forms.ToolBarButton TbbDelRequires;
        private System.Windows.Forms.Button BtnMemberDown;
        private System.Windows.Forms.Button BtnMemberUp;
        private TabPage tabPrintPage;
        private TabPage tabPage1;
        private Button btnPrintHeaderConfig;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnPrintFooterConfig;
        private CheckBox chkImage;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label14;
        private Button btnDateFont;
        private ComboBox cmbBodyFormat;
        private Button btnHeaderFont;
        private Button btnBodyFont;
        private CheckBox chkDisplayRequire;
        private CheckBox chkMonthly;
        private Label label12;
        private NumericUpDown nupBreakRow;
        private Label label13;
        private FontDialog dlgHeaderFont;
        private FontDialog dlgDateFont;
        private FontDialog dlgBodyFont;
        private Label label15;
        private DataSet DefaultDataSet;
        private DataTable DefaultTable;
        private DataColumn DefaultRequireColumn;
        private DataColumn DefaultRequireNameColumn;
        private DataTable MondayTable;
        private DataColumn MonRequireColumn;
        private DataColumn MonRequireNameColumn;
        private DataTable TuesdayTable;
        private DataTable WednesdayTable;
        private DataTable ThursdayTable;
        private DataTable FridayTable;
        private DataTable SaturdayTable;
        private DataTable SundayTable;
        private DataColumn TueRequireColumn;
        private DataColumn TueRequireNameColumn;
        private DataColumn WedRequireColumn;
        private DataColumn WedRequireNameColumn;
        private DataColumn ThuRequireColumn;
        private DataColumn ThuRequireNameColumn;
        private DataColumn FriRequireColumn;
        private DataColumn FriRequireNameColumn;
        private DataColumn SatRequireColumn;
        private DataColumn SatRequireNameColumn;
        private DataColumn SunRequireColumn;
        private DataColumn SunRequireNameColumn;
        private ImageList IconImages;
        private IContainer components;
        private NumericUpDown nupBreakColumn;


        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FScheduleConfigDialog));
            this.tabPrint = new System.Windows.Forms.TabControl();
            this.tabPattern = new System.Windows.Forms.TabPage();
            this.lstPatterns = new System.Windows.Forms.ListBox();
            this.PatternDataSet = new System.Data.DataSet();
            this.PatternTable = new System.Data.DataTable();
            this.PatternColumn = new System.Data.DataColumn();
            this.PatternNameColumn = new System.Data.DataColumn();
            this.PatternToolBar = new System.Windows.Forms.ToolBar();
            this.btnAddPattern = new System.Windows.Forms.ToolBarButton();
            this.btnEditPattern = new System.Windows.Forms.ToolBarButton();
            this.btnDeletePattern = new System.Windows.Forms.ToolBarButton();
            this.IconImages = new System.Windows.Forms.ImageList(this.components);
            this.tabMember = new System.Windows.Forms.TabPage();
            this.lstMembers = new System.Windows.Forms.ListBox();
            this.MemberDataSet = new System.Data.DataSet();
            this.MemberTable = new System.Data.DataTable();
            this.MemberColumn = new System.Data.DataColumn();
            this.MemberNameColumn = new System.Data.DataColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnMemberDown = new System.Windows.Forms.Button();
            this.BtnMemberUp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MemberToolBar = new System.Windows.Forms.ToolBar();
            this.BtnAddMember = new System.Windows.Forms.ToolBarButton();
            this.BtnEditMember = new System.Windows.Forms.ToolBarButton();
            this.BtnDeleteMember = new System.Windows.Forms.ToolBarButton();
            this.tabRequirePatterns = new System.Windows.Forms.TabPage();
            this.lstRequirePatterns = new System.Windows.Forms.ListBox();
            this.RequirePatternsDataSet = new System.Data.DataSet();
            this.RequirePatternsTable = new System.Data.DataTable();
            this.RequirePatternsColumn = new System.Data.DataColumn();
            this.RequirePatternsNameColumn = new System.Data.DataColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.RequiresToolBar = new System.Windows.Forms.ToolBar();
            this.TbbAddRequires = new System.Windows.Forms.ToolBarButton();
            this.TbbEditRequires = new System.Windows.Forms.ToolBarButton();
            this.TbbDelRequires = new System.Windows.Forms.ToolBarButton();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSundayRequire = new System.Windows.Forms.ComboBox();
            this.DefaultDataSet = new System.Data.DataSet();
            this.DefaultTable = new System.Data.DataTable();
            this.DefaultRequireColumn = new System.Data.DataColumn();
            this.DefaultRequireNameColumn = new System.Data.DataColumn();
            this.MondayTable = new System.Data.DataTable();
            this.MonRequireColumn = new System.Data.DataColumn();
            this.MonRequireNameColumn = new System.Data.DataColumn();
            this.TuesdayTable = new System.Data.DataTable();
            this.TueRequireColumn = new System.Data.DataColumn();
            this.TueRequireNameColumn = new System.Data.DataColumn();
            this.WednesdayTable = new System.Data.DataTable();
            this.WedRequireColumn = new System.Data.DataColumn();
            this.WedRequireNameColumn = new System.Data.DataColumn();
            this.ThursdayTable = new System.Data.DataTable();
            this.ThuRequireColumn = new System.Data.DataColumn();
            this.ThuRequireNameColumn = new System.Data.DataColumn();
            this.FridayTable = new System.Data.DataTable();
            this.FriRequireColumn = new System.Data.DataColumn();
            this.FriRequireNameColumn = new System.Data.DataColumn();
            this.SaturdayTable = new System.Data.DataTable();
            this.SatRequireColumn = new System.Data.DataColumn();
            this.SatRequireNameColumn = new System.Data.DataColumn();
            this.SundayTable = new System.Data.DataTable();
            this.SunRequireColumn = new System.Data.DataColumn();
            this.SunRequireNameColumn = new System.Data.DataColumn();
            this.cmbFridayRequire = new System.Windows.Forms.ComboBox();
            this.cmbSaturdayRequire = new System.Windows.Forms.ComboBox();
            this.cmbDefaultRequire = new System.Windows.Forms.ComboBox();
            this.cmbWednesdayRequire = new System.Windows.Forms.ComboBox();
            this.cmbTuesdayRequire = new System.Windows.Forms.ComboBox();
            this.cmbThursdayRequire = new System.Windows.Forms.ComboBox();
            this.cmbMondayRequire = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabDayOffs = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DayOffList = new System.Windows.Forms.ListBox();
            this.DayOffDataSet = new System.Data.DataSet();
            this.DayOffTable = new System.Data.DataTable();
            this.DayOffColumn = new System.Data.DataColumn();
            this.DayOffNameColumn = new System.Data.DataColumn();
            this.DayOffStartColumn = new System.Data.DataColumn();
            this.DayOffEndColumn = new System.Data.DataColumn();
            this.HollyDayToolBar = new System.Windows.Forms.ToolBar();
            this.TbbAddDayOff = new System.Windows.Forms.ToolBarButton();
            this.TbbEditDayOff = new System.Windows.Forms.ToolBarButton();
            this.TbbRemoveDayOff = new System.Windows.Forms.ToolBarButton();
            this.tabPrintPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrintFooterConfig = new System.Windows.Forms.Button();
            this.btnPrintHeaderConfig = new System.Windows.Forms.Button();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnHeaderFont = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBodyFont = new System.Windows.Forms.Button();
            this.btnDateFont = new System.Windows.Forms.Button();
            this.cmbBodyFormat = new System.Windows.Forms.ComboBox();
            this.chkDisplayRequire = new System.Windows.Forms.CheckBox();
            this.chkMonthly = new System.Windows.Forms.CheckBox();
            this.nupBreakRow = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nupBreakColumn = new System.Windows.Forms.NumericUpDown();
            this.tabOthers = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.GrpRemovedItems = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnResqPattern = new System.Windows.Forms.Button();
            this.CmbRemovedRequires = new System.Windows.Forms.ComboBox();
            this.DsRemovedItems = new System.Data.DataSet();
            this.TblRemovedMembers = new System.Data.DataTable();
            this.ClmRM = new System.Data.DataColumn();
            this.ClmRMN = new System.Data.DataColumn();
            this.TblRemovedPatterns = new System.Data.DataTable();
            this.ClmRP = new System.Data.DataColumn();
            this.ClmRPN = new System.Data.DataColumn();
            this.TblRemovedRequires = new System.Data.DataTable();
            this.ClmRR = new System.Data.DataColumn();
            this.ClmRRN = new System.Data.DataColumn();
            this.TblRemovedDayOffs = new System.Data.DataTable();
            this.ClmRD = new System.Data.DataColumn();
            this.ClmRDN = new System.Data.DataColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.CmbRemovedMember = new System.Windows.Forms.ComboBox();
            this.CmbRemovedPattern = new System.Windows.Forms.ComboBox();
            this.BtnResqMember = new System.Windows.Forms.Button();
            this.BtnResqRequire = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnImport = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.NudPrevDate = new System.Windows.Forms.NumericUpDown();
            this.BtnRemoveOldItem = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.WeekDateSet = new System.Data.DataSet();
            this.WeekDayTable = new System.Data.DataTable();
            this.WeekDayColumn = new System.Data.DataColumn();
            this.WeekDayNameColumn = new System.Data.DataColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dlgHeaderFont = new System.Windows.Forms.FontDialog();
            this.dlgDateFont = new System.Windows.Forms.FontDialog();
            this.dlgBodyFont = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DlgImportFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabPrint.SuspendLayout();
            this.tabPattern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatternTable)).BeginInit();
            this.tabMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberTable)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabRequirePatterns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequirePatternsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequirePatternsTable)).BeginInit();
            this.panel7.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MondayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayTable)).BeginInit();
            this.tabDayOffs.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DayOffDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayOffTable)).BeginInit();
            this.tabPrintPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBreakRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBreakColumn)).BeginInit();
            this.tabOthers.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.GrpRemovedItems.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsRemovedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedPatterns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedRequires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedDayOffs)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrevDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeekDateSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeekDayTable)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrint
            // 
            this.tabPrint.Controls.Add(this.tabPattern);
            this.tabPrint.Controls.Add(this.tabMember);
            this.tabPrint.Controls.Add(this.tabRequirePatterns);
            this.tabPrint.Controls.Add(this.tabGeneral);
            this.tabPrint.Controls.Add(this.tabDayOffs);
            this.tabPrint.Controls.Add(this.tabPrintPage);
            this.tabPrint.Controls.Add(this.tabOthers);
            this.tabPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrint.Location = new System.Drawing.Point(3, 3);
            this.tabPrint.Name = "tabPrint";
            this.tabPrint.SelectedIndex = 0;
            this.tabPrint.Size = new System.Drawing.Size(388, 333);
            this.tabPrint.TabIndex = 0;
            // 
            // tabPattern
            // 
            this.tabPattern.Controls.Add(this.lstPatterns);
            this.tabPattern.Controls.Add(this.PatternToolBar);
            this.tabPattern.Location = new System.Drawing.Point(4, 22);
            this.tabPattern.Name = "tabPattern";
            this.tabPattern.Size = new System.Drawing.Size(380, 307);
            this.tabPattern.TabIndex = 1;
            this.tabPattern.Text = "勤務シフト";
            this.tabPattern.UseVisualStyleBackColor = true;
            // 
            // lstPatterns
            // 
            this.lstPatterns.DataSource = this.PatternDataSet;
            this.lstPatterns.DisplayMember = "PatternTable.PatternName";
            this.lstPatterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPatterns.ItemHeight = 12;
            this.lstPatterns.Location = new System.Drawing.Point(0, 41);
            this.lstPatterns.Name = "lstPatterns";
            this.lstPatterns.Size = new System.Drawing.Size(380, 266);
            this.lstPatterns.TabIndex = 1;
            this.lstPatterns.ValueMember = "PatternTable.PatternColumn";
            this.lstPatterns.DoubleClick += new System.EventHandler(this.lstPatterns_DoubleClick);
            // 
            // PatternDataSet
            // 
            this.PatternDataSet.DataSetName = "PatternDataSet";
            this.PatternDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.PatternDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.PatternTable});
            // 
            // PatternTable
            // 
            this.PatternTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.PatternColumn,
            this.PatternNameColumn});
            this.PatternTable.TableName = "PatternTable";
            // 
            // PatternColumn
            // 
            this.PatternColumn.Caption = "Pattern";
            this.PatternColumn.ColumnName = "PatternColumn";
            this.PatternColumn.DataType = typeof(TimeTableManager.Element.BPattern);
            // 
            // PatternNameColumn
            // 
            this.PatternNameColumn.Caption = "勤務シフト";
            this.PatternNameColumn.ColumnName = "PatternName";
            // 
            // PatternToolBar
            // 
            this.PatternToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnAddPattern,
            this.btnEditPattern,
            this.btnDeletePattern});
            this.PatternToolBar.DropDownArrows = true;
            this.PatternToolBar.ImageList = this.IconImages;
            this.PatternToolBar.Location = new System.Drawing.Point(0, 0);
            this.PatternToolBar.Name = "PatternToolBar";
            this.PatternToolBar.ShowToolTips = true;
            this.PatternToolBar.Size = new System.Drawing.Size(380, 41);
            this.PatternToolBar.TabIndex = 0;
            this.PatternToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.PatternToolBar_Click);
            // 
            // btnAddPattern
            // 
            this.btnAddPattern.ImageIndex = 0;
            this.btnAddPattern.Name = "btnAddPattern";
            this.btnAddPattern.Text = "追加";
            // 
            // btnEditPattern
            // 
            this.btnEditPattern.ImageIndex = 1;
            this.btnEditPattern.Name = "btnEditPattern";
            this.btnEditPattern.Text = "修正";
            // 
            // btnDeletePattern
            // 
            this.btnDeletePattern.ImageIndex = 2;
            this.btnDeletePattern.Name = "btnDeletePattern";
            this.btnDeletePattern.Text = "削除";
            // 
            // IconImages
            // 
            this.IconImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImages.ImageStream")));
            this.IconImages.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImages.Images.SetKeyName(0, "FrontPlus.gif");
            this.IconImages.Images.SetKeyName(1, "FrontEdit.gif");
            this.IconImages.Images.SetKeyName(2, "FrontDel.gif");
            // 
            // tabMember
            // 
            this.tabMember.Controls.Add(this.lstMembers);
            this.tabMember.Controls.Add(this.panel3);
            this.tabMember.Controls.Add(this.panel2);
            this.tabMember.Location = new System.Drawing.Point(4, 22);
            this.tabMember.Name = "tabMember";
            this.tabMember.Size = new System.Drawing.Size(380, 307);
            this.tabMember.TabIndex = 2;
            this.tabMember.Text = "メンバー";
            this.tabMember.UseVisualStyleBackColor = true;
            // 
            // lstMembers
            // 
            this.lstMembers.DataSource = this.MemberDataSet;
            this.lstMembers.DisplayMember = "MemberTable.MemberName";
            this.lstMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMembers.ItemHeight = 12;
            this.lstMembers.Location = new System.Drawing.Point(0, 40);
            this.lstMembers.Name = "lstMembers";
            this.lstMembers.Size = new System.Drawing.Size(316, 267);
            this.lstMembers.TabIndex = 2;
            this.lstMembers.ValueMember = "MemberTable.MemberColumn";
            this.lstMembers.DoubleClick += new System.EventHandler(this.lstMembers_DoubleClick);
            // 
            // MemberDataSet
            // 
            this.MemberDataSet.DataSetName = "MemberDataSet";
            this.MemberDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.MemberDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.MemberTable});
            // 
            // MemberTable
            // 
            this.MemberTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.MemberColumn,
            this.MemberNameColumn});
            this.MemberTable.TableName = "MemberTable";
            // 
            // MemberColumn
            // 
            this.MemberColumn.ColumnName = "MemberColumn";
            this.MemberColumn.DataType = typeof(TimeTableManager.Element.BMember);
            // 
            // MemberNameColumn
            // 
            this.MemberNameColumn.Caption = "メンバー名";
            this.MemberNameColumn.ColumnName = "MemberName";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnMemberDown);
            this.panel3.Controls.Add(this.BtnMemberUp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(316, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(64, 267);
            this.panel3.TabIndex = 1;
            // 
            // BtnMemberDown
            // 
            this.BtnMemberDown.Location = new System.Drawing.Point(8, 40);
            this.BtnMemberDown.Name = "BtnMemberDown";
            this.BtnMemberDown.Size = new System.Drawing.Size(48, 23);
            this.BtnMemberDown.TabIndex = 1;
            this.BtnMemberDown.Text = "Down";
            this.BtnMemberDown.Click += new System.EventHandler(this.BtnMemberDown_Click);
            // 
            // BtnMemberUp
            // 
            this.BtnMemberUp.Location = new System.Drawing.Point(8, 8);
            this.BtnMemberUp.Name = "BtnMemberUp";
            this.BtnMemberUp.Size = new System.Drawing.Size(48, 23);
            this.BtnMemberUp.TabIndex = 0;
            this.BtnMemberUp.Text = "Up";
            this.BtnMemberUp.Click += new System.EventHandler(this.BtnMemberUp_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MemberToolBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 40);
            this.panel2.TabIndex = 0;
            // 
            // MemberToolBar
            // 
            this.MemberToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.BtnAddMember,
            this.BtnEditMember,
            this.BtnDeleteMember});
            this.MemberToolBar.DropDownArrows = true;
            this.MemberToolBar.ImageList = this.IconImages;
            this.MemberToolBar.Location = new System.Drawing.Point(0, 0);
            this.MemberToolBar.Name = "MemberToolBar";
            this.MemberToolBar.ShowToolTips = true;
            this.MemberToolBar.Size = new System.Drawing.Size(380, 41);
            this.MemberToolBar.TabIndex = 0;
            this.MemberToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.MemberToolBar_Click);
            // 
            // BtnAddMember
            // 
            this.BtnAddMember.ImageIndex = 0;
            this.BtnAddMember.Name = "BtnAddMember";
            this.BtnAddMember.Text = "追加";
            // 
            // BtnEditMember
            // 
            this.BtnEditMember.ImageIndex = 1;
            this.BtnEditMember.Name = "BtnEditMember";
            this.BtnEditMember.Text = "修正";
            // 
            // BtnDeleteMember
            // 
            this.BtnDeleteMember.ImageIndex = 2;
            this.BtnDeleteMember.Name = "BtnDeleteMember";
            this.BtnDeleteMember.Text = "削除";
            // 
            // tabRequirePatterns
            // 
            this.tabRequirePatterns.Controls.Add(this.lstRequirePatterns);
            this.tabRequirePatterns.Controls.Add(this.panel7);
            this.tabRequirePatterns.Location = new System.Drawing.Point(4, 22);
            this.tabRequirePatterns.Name = "tabRequirePatterns";
            this.tabRequirePatterns.Size = new System.Drawing.Size(380, 307);
            this.tabRequirePatterns.TabIndex = 4;
            this.tabRequirePatterns.Text = "人員配置";
            this.tabRequirePatterns.UseVisualStyleBackColor = true;
            // 
            // lstRequirePatterns
            // 
            this.lstRequirePatterns.DataSource = this.RequirePatternsDataSet;
            this.lstRequirePatterns.DisplayMember = "RequirePatternsTable.RequirePatternsName";
            this.lstRequirePatterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRequirePatterns.ItemHeight = 12;
            this.lstRequirePatterns.Location = new System.Drawing.Point(0, 40);
            this.lstRequirePatterns.Name = "lstRequirePatterns";
            this.lstRequirePatterns.Size = new System.Drawing.Size(380, 267);
            this.lstRequirePatterns.TabIndex = 1;
            this.lstRequirePatterns.ValueMember = "RequirePatternsTable.RequirePatternsColumn";
            this.lstRequirePatterns.DoubleClick += new System.EventHandler(this.lstRequirePatterns_DoubleClick);
            // 
            // RequirePatternsDataSet
            // 
            this.RequirePatternsDataSet.DataSetName = "RequirePatternsDataSet";
            this.RequirePatternsDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.RequirePatternsDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.RequirePatternsTable});
            // 
            // RequirePatternsTable
            // 
            this.RequirePatternsTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.RequirePatternsColumn,
            this.RequirePatternsNameColumn});
            this.RequirePatternsTable.TableName = "RequirePatternsTable";
            // 
            // RequirePatternsColumn
            // 
            this.RequirePatternsColumn.Caption = "人員配置";
            this.RequirePatternsColumn.ColumnName = "RequirePatternsColumn";
            this.RequirePatternsColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // RequirePatternsNameColumn
            // 
            this.RequirePatternsNameColumn.Caption = "人員配置";
            this.RequirePatternsNameColumn.ColumnName = "RequirePatternsName";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.RequiresToolBar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(380, 40);
            this.panel7.TabIndex = 0;
            // 
            // RequiresToolBar
            // 
            this.RequiresToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.TbbAddRequires,
            this.TbbEditRequires,
            this.TbbDelRequires});
            this.RequiresToolBar.DropDownArrows = true;
            this.RequiresToolBar.ImageList = this.IconImages;
            this.RequiresToolBar.Location = new System.Drawing.Point(0, 0);
            this.RequiresToolBar.Name = "RequiresToolBar";
            this.RequiresToolBar.ShowToolTips = true;
            this.RequiresToolBar.Size = new System.Drawing.Size(380, 41);
            this.RequiresToolBar.TabIndex = 0;
            this.RequiresToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.RequiresToolBar_ButtonClick);
            // 
            // TbbAddRequires
            // 
            this.TbbAddRequires.ImageIndex = 0;
            this.TbbAddRequires.Name = "TbbAddRequires";
            this.TbbAddRequires.Text = "追加";
            // 
            // TbbEditRequires
            // 
            this.TbbEditRequires.ImageIndex = 1;
            this.TbbEditRequires.Name = "TbbEditRequires";
            this.TbbEditRequires.Text = "修正";
            // 
            // TbbDelRequires
            // 
            this.TbbDelRequires.ImageIndex = 2;
            this.TbbDelRequires.Name = "TbbDelRequires";
            this.TbbDelRequires.Text = "削除";
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tableLayoutPanel5);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(380, 307);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "全般";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.60535F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.39465F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(380, 307);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEndTime);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtStartTime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 44);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "営業時間";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtEndTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtEndTime.Location = new System.Drawing.Point(210, 18);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ShowUpDown = true;
            this.txtEndTime.Size = new System.Drawing.Size(80, 19);
            this.txtEndTime.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "～";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtStartTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtStartTime.Location = new System.Drawing.Point(101, 18);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ShowUpDown = true;
            this.txtStartTime.Size = new System.Drawing.Size(80, 19);
            this.txtStartTime.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 216);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "デフォルトの人員配置";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel7.Controls.Add(this.cmbSundayRequire, 1, 7);
            this.tableLayoutPanel7.Controls.Add(this.cmbFridayRequire, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.cmbSaturdayRequire, 1, 6);
            this.tableLayoutPanel7.Controls.Add(this.cmbDefaultRequire, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.cmbWednesdayRequire, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.cmbTuesdayRequire, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.cmbThursdayRequire, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.cmbMondayRequire, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 8;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(368, 198);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // cmbSundayRequire
            // 
            this.cmbSundayRequire.DataSource = this.DefaultDataSet;
            this.cmbSundayRequire.DisplayMember = "SundayTable.SunRequireNameColumn";
            this.cmbSundayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSundayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSundayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbSundayRequire.Location = new System.Drawing.Point(101, 171);
            this.cmbSundayRequire.Name = "cmbSundayRequire";
            this.cmbSundayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbSundayRequire.TabIndex = 24;
            this.cmbSundayRequire.ValueMember = "SundayTable.SunRequireColumn";
            // 
            // DefaultDataSet
            // 
            this.DefaultDataSet.DataSetName = "DefaultDataSet";
            this.DefaultDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.DefaultTable,
            this.MondayTable,
            this.TuesdayTable,
            this.WednesdayTable,
            this.ThursdayTable,
            this.FridayTable,
            this.SaturdayTable,
            this.SundayTable});
            // 
            // DefaultTable
            // 
            this.DefaultTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.DefaultRequireColumn,
            this.DefaultRequireNameColumn});
            this.DefaultTable.TableName = "DefaultTable";
            // 
            // DefaultRequireColumn
            // 
            this.DefaultRequireColumn.ColumnName = "DefaultRequireColumn";
            this.DefaultRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // DefaultRequireNameColumn
            // 
            this.DefaultRequireNameColumn.ColumnName = "DefaultRequireNameColumn";
            // 
            // MondayTable
            // 
            this.MondayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.MonRequireColumn,
            this.MonRequireNameColumn});
            this.MondayTable.TableName = "MondayTable";
            // 
            // MonRequireColumn
            // 
            this.MonRequireColumn.ColumnName = "MonRequireColumn";
            this.MonRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // MonRequireNameColumn
            // 
            this.MonRequireNameColumn.ColumnName = "MonRequireNameColumn";
            // 
            // TuesdayTable
            // 
            this.TuesdayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.TueRequireColumn,
            this.TueRequireNameColumn});
            this.TuesdayTable.TableName = "TuesdayTable";
            // 
            // TueRequireColumn
            // 
            this.TueRequireColumn.ColumnName = "TueRequireColumn";
            this.TueRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // TueRequireNameColumn
            // 
            this.TueRequireNameColumn.ColumnName = "TueRequireNameColumn";
            // 
            // WednesdayTable
            // 
            this.WednesdayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.WedRequireColumn,
            this.WedRequireNameColumn});
            this.WednesdayTable.TableName = "WednesdayTable";
            // 
            // WedRequireColumn
            // 
            this.WedRequireColumn.ColumnName = "WedRequireColumn";
            this.WedRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // WedRequireNameColumn
            // 
            this.WedRequireNameColumn.ColumnName = "WedRequireNameColumn";
            // 
            // ThursdayTable
            // 
            this.ThursdayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.ThuRequireColumn,
            this.ThuRequireNameColumn});
            this.ThursdayTable.TableName = "ThursdayTable";
            // 
            // ThuRequireColumn
            // 
            this.ThuRequireColumn.ColumnName = "ThuRequireColumn";
            this.ThuRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // ThuRequireNameColumn
            // 
            this.ThuRequireNameColumn.ColumnName = "ThuRequireNameColumn";
            // 
            // FridayTable
            // 
            this.FridayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.FriRequireColumn,
            this.FriRequireNameColumn});
            this.FridayTable.TableName = "FridayTable";
            // 
            // FriRequireColumn
            // 
            this.FriRequireColumn.ColumnName = "FriRequireColumn";
            this.FriRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // FriRequireNameColumn
            // 
            this.FriRequireNameColumn.ColumnName = "FriRequireNameColumn";
            // 
            // SaturdayTable
            // 
            this.SaturdayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.SatRequireColumn,
            this.SatRequireNameColumn});
            this.SaturdayTable.TableName = "SaturdayTable";
            // 
            // SatRequireColumn
            // 
            this.SatRequireColumn.ColumnName = "SatRequireColumn";
            this.SatRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // SatRequireNameColumn
            // 
            this.SatRequireNameColumn.ColumnName = "SatRequireNameColumn";
            // 
            // SundayTable
            // 
            this.SundayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.SunRequireColumn,
            this.SunRequireNameColumn});
            this.SundayTable.TableName = "SundayTable";
            // 
            // SunRequireColumn
            // 
            this.SunRequireColumn.ColumnName = "SunRequireColumn";
            this.SunRequireColumn.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // SunRequireNameColumn
            // 
            this.SunRequireNameColumn.ColumnName = "SunRequireNameColumn";
            // 
            // cmbFridayRequire
            // 
            this.cmbFridayRequire.DataSource = this.DefaultDataSet;
            this.cmbFridayRequire.DisplayMember = "FridayTable.FriRequireNameColumn";
            this.cmbFridayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFridayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFridayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbFridayRequire.Location = new System.Drawing.Point(101, 123);
            this.cmbFridayRequire.Name = "cmbFridayRequire";
            this.cmbFridayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbFridayRequire.TabIndex = 22;
            this.cmbFridayRequire.ValueMember = "FridayTable.FriRequireColumn";
            // 
            // cmbSaturdayRequire
            // 
            this.cmbSaturdayRequire.DataSource = this.DefaultDataSet;
            this.cmbSaturdayRequire.DisplayMember = "SaturdayTable.SatRequireNameColumn";
            this.cmbSaturdayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSaturdayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaturdayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbSaturdayRequire.Location = new System.Drawing.Point(101, 147);
            this.cmbSaturdayRequire.Name = "cmbSaturdayRequire";
            this.cmbSaturdayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbSaturdayRequire.TabIndex = 23;
            this.cmbSaturdayRequire.ValueMember = "SaturdayTable.SatRequireColumn";
            // 
            // cmbDefaultRequire
            // 
            this.cmbDefaultRequire.DataSource = this.DefaultDataSet;
            this.cmbDefaultRequire.DisplayMember = "DefaultTable.DefaultRequireNameColumn";
            this.cmbDefaultRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDefaultRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbDefaultRequire.Location = new System.Drawing.Point(101, 3);
            this.cmbDefaultRequire.Name = "cmbDefaultRequire";
            this.cmbDefaultRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbDefaultRequire.TabIndex = 17;
            this.cmbDefaultRequire.ValueMember = "DefaultTable.DefaultRequireColumn";
            // 
            // cmbWednesdayRequire
            // 
            this.cmbWednesdayRequire.DataSource = this.DefaultDataSet;
            this.cmbWednesdayRequire.DisplayMember = "WednesdayTable.WedRequireNameColumn";
            this.cmbWednesdayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbWednesdayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWednesdayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbWednesdayRequire.Location = new System.Drawing.Point(101, 75);
            this.cmbWednesdayRequire.Name = "cmbWednesdayRequire";
            this.cmbWednesdayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbWednesdayRequire.TabIndex = 20;
            this.cmbWednesdayRequire.ValueMember = "WednesdayTable.WedRequireColumn";
            // 
            // cmbTuesdayRequire
            // 
            this.cmbTuesdayRequire.DataSource = this.DefaultDataSet;
            this.cmbTuesdayRequire.DisplayMember = "TuesdayTable.TueRequireNameColumn";
            this.cmbTuesdayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTuesdayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTuesdayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbTuesdayRequire.Location = new System.Drawing.Point(101, 51);
            this.cmbTuesdayRequire.Name = "cmbTuesdayRequire";
            this.cmbTuesdayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbTuesdayRequire.TabIndex = 19;
            this.cmbTuesdayRequire.ValueMember = "TuesdayTable.TueRequireColumn";
            // 
            // cmbThursdayRequire
            // 
            this.cmbThursdayRequire.DataSource = this.DefaultDataSet;
            this.cmbThursdayRequire.DisplayMember = "ThursdayTable.ThuRequireNameColumn";
            this.cmbThursdayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbThursdayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThursdayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbThursdayRequire.Location = new System.Drawing.Point(101, 99);
            this.cmbThursdayRequire.Name = "cmbThursdayRequire";
            this.cmbThursdayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbThursdayRequire.TabIndex = 21;
            this.cmbThursdayRequire.ValueMember = "ThursdayTable.ThuRequireColumn";
            // 
            // cmbMondayRequire
            // 
            this.cmbMondayRequire.DataSource = this.DefaultDataSet;
            this.cmbMondayRequire.DisplayMember = "MondayTable.MonRequireNameColumn";
            this.cmbMondayRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMondayRequire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMondayRequire.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbMondayRequire.Location = new System.Drawing.Point(101, 27);
            this.cmbMondayRequire.Name = "cmbMondayRequire";
            this.cmbMondayRequire.Size = new System.Drawing.Size(264, 20);
            this.cmbMondayRequire.TabIndex = 18;
            this.cmbMondayRequire.ValueMember = "MondayTable.MonRequireColumn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(3, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "土曜日";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "金曜日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "木曜日";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "水曜日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "火曜日";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "月曜日";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "曜日なし";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(3, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 30);
            this.label9.TabIndex = 9;
            this.label9.Text = "日曜日";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDayOffs
            // 
            this.tabDayOffs.Controls.Add(this.panel5);
            this.tabDayOffs.Location = new System.Drawing.Point(4, 22);
            this.tabDayOffs.Name = "tabDayOffs";
            this.tabDayOffs.Size = new System.Drawing.Size(380, 307);
            this.tabDayOffs.TabIndex = 3;
            this.tabDayOffs.Text = "休日";
            this.tabDayOffs.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DayOffList);
            this.panel5.Controls.Add(this.HollyDayToolBar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 307);
            this.panel5.TabIndex = 1;
            // 
            // DayOffList
            // 
            this.DayOffList.DataSource = this.DayOffDataSet;
            this.DayOffList.DisplayMember = "DayOffTable.DayOffNameColumn";
            this.DayOffList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DayOffList.ItemHeight = 12;
            this.DayOffList.Location = new System.Drawing.Point(0, 41);
            this.DayOffList.Name = "DayOffList";
            this.DayOffList.Size = new System.Drawing.Size(380, 266);
            this.DayOffList.TabIndex = 1;
            this.DayOffList.ValueMember = "DayOffTable.DayOffColumn";
            this.DayOffList.DoubleClick += new System.EventHandler(this.DayOffList_DoubleClick);
            // 
            // DayOffDataSet
            // 
            this.DayOffDataSet.DataSetName = "DayOffDataSet";
            this.DayOffDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.DayOffDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.DayOffTable});
            // 
            // DayOffTable
            // 
            this.DayOffTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.DayOffColumn,
            this.DayOffNameColumn,
            this.DayOffStartColumn,
            this.DayOffEndColumn});
            this.DayOffTable.TableName = "DayOffTable";
            // 
            // DayOffColumn
            // 
            this.DayOffColumn.Caption = "日付";
            this.DayOffColumn.ColumnName = "DayOffColumn";
            this.DayOffColumn.DataType = typeof(TimeTableManager.Element.BDayOff);
            // 
            // DayOffNameColumn
            // 
            this.DayOffNameColumn.Caption = "休日名";
            this.DayOffNameColumn.ColumnName = "DayOffNameColumn";
            // 
            // DayOffStartColumn
            // 
            this.DayOffStartColumn.Caption = "休日の開始";
            this.DayOffStartColumn.ColumnName = "DayOffStartColumn";
            this.DayOffStartColumn.DataType = typeof(System.DateTime);
            // 
            // DayOffEndColumn
            // 
            this.DayOffEndColumn.Caption = "休日の終了";
            this.DayOffEndColumn.ColumnName = "DayOffEndColumn";
            this.DayOffEndColumn.DataType = typeof(System.DateTime);
            // 
            // HollyDayToolBar
            // 
            this.HollyDayToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.TbbAddDayOff,
            this.TbbEditDayOff,
            this.TbbRemoveDayOff});
            this.HollyDayToolBar.DropDownArrows = true;
            this.HollyDayToolBar.ImageList = this.IconImages;
            this.HollyDayToolBar.Location = new System.Drawing.Point(0, 0);
            this.HollyDayToolBar.Name = "HollyDayToolBar";
            this.HollyDayToolBar.ShowToolTips = true;
            this.HollyDayToolBar.Size = new System.Drawing.Size(380, 41);
            this.HollyDayToolBar.TabIndex = 2;
            this.HollyDayToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.HollyDayToolBar_ButtonClick);
            // 
            // TbbAddDayOff
            // 
            this.TbbAddDayOff.ImageIndex = 0;
            this.TbbAddDayOff.Name = "TbbAddDayOff";
            this.TbbAddDayOff.Text = "追加";
            // 
            // TbbEditDayOff
            // 
            this.TbbEditDayOff.ImageIndex = 1;
            this.TbbEditDayOff.Name = "TbbEditDayOff";
            this.TbbEditDayOff.Text = "修正";
            // 
            // TbbRemoveDayOff
            // 
            this.TbbRemoveDayOff.ImageIndex = 2;
            this.TbbRemoveDayOff.Name = "TbbRemoveDayOff";
            this.TbbRemoveDayOff.Text = "削除";
            // 
            // tabPrintPage
            // 
            this.tabPrintPage.Controls.Add(this.tableLayoutPanel1);
            this.tabPrintPage.Location = new System.Drawing.Point(4, 22);
            this.tabPrintPage.Name = "tabPrintPage";
            this.tabPrintPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrintPage.Size = new System.Drawing.Size(380, 307);
            this.tabPrintPage.TabIndex = 6;
            this.tabPrintPage.Text = "印刷設定";
            this.tabPrintPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnPrintFooterConfig, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPrintHeaderConfig, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkImage, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.87554F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.09013F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.30472F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.30043F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 301);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnPrintFooterConfig
            // 
            this.btnPrintFooterConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintFooterConfig.Location = new System.Drawing.Point(3, 231);
            this.btnPrintFooterConfig.Name = "btnPrintFooterConfig";
            this.btnPrintFooterConfig.Size = new System.Drawing.Size(368, 34);
            this.btnPrintFooterConfig.TabIndex = 9;
            this.btnPrintFooterConfig.Text = "フッタ部の設定";
            this.btnPrintFooterConfig.UseVisualStyleBackColor = true;
            this.btnPrintFooterConfig.Click += new System.EventHandler(this.btnPrintFooterConfig_Click);
            // 
            // btnPrintHeaderConfig
            // 
            this.btnPrintHeaderConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintHeaderConfig.Location = new System.Drawing.Point(3, 3);
            this.btnPrintHeaderConfig.Name = "btnPrintHeaderConfig";
            this.btnPrintHeaderConfig.Size = new System.Drawing.Size(368, 32);
            this.btnPrintHeaderConfig.TabIndex = 0;
            this.btnPrintHeaderConfig.Text = "ヘッダ部の設定";
            this.btnPrintHeaderConfig.UseVisualStyleBackColor = true;
            this.btnPrintHeaderConfig.Click += new System.EventHandler(this.btnPrintHeaderConfig_Click);
            // 
            // chkImage
            // 
            this.chkImage.AutoSize = true;
            this.chkImage.Location = new System.Drawing.Point(3, 271);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(85, 16);
            this.chkImage.TabIndex = 10;
            this.chkImage.Text = "イメージ印刷";
            this.chkImage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnHeaderFont, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBodyFont, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDateFont, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbBodyFormat, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkDisplayRequire, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkMonthly, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.nupBreakRow, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label13, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.nupBreakColumn, 2, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(368, 184);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(95, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "行で改ページ";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label12, 2);
            this.label12.Location = new System.Drawing.Point(3, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "日付の表現形式";
            // 
            // btnHeaderFont
            // 
            this.btnHeaderFont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderFont.Location = new System.Drawing.Point(95, 3);
            this.btnHeaderFont.Name = "btnHeaderFont";
            this.btnHeaderFont.Size = new System.Drawing.Size(86, 30);
            this.btnHeaderFont.TabIndex = 1;
            this.btnHeaderFont.Text = "見出し";
            this.btnHeaderFont.UseVisualStyleBackColor = true;
            this.btnHeaderFont.Click += new System.EventHandler(this.btnHeaderFont_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "フォント";
            // 
            // btnBodyFont
            // 
            this.btnBodyFont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBodyFont.Location = new System.Drawing.Point(279, 3);
            this.btnBodyFont.Name = "btnBodyFont";
            this.btnBodyFont.Size = new System.Drawing.Size(86, 30);
            this.btnBodyFont.TabIndex = 3;
            this.btnBodyFont.Text = "本体";
            this.btnBodyFont.UseVisualStyleBackColor = true;
            this.btnBodyFont.Click += new System.EventHandler(this.btnBodyFont_Click);
            // 
            // btnDateFont
            // 
            this.btnDateFont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDateFont.Location = new System.Drawing.Point(187, 3);
            this.btnDateFont.Name = "btnDateFont";
            this.btnDateFont.Size = new System.Drawing.Size(86, 30);
            this.btnDateFont.TabIndex = 2;
            this.btnDateFont.Text = "日付";
            this.btnDateFont.UseVisualStyleBackColor = true;
            this.btnDateFont.Click += new System.EventHandler(this.btnDateFont_Click);
            // 
            // cmbBodyFormat
            // 
            this.cmbBodyFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbBodyFormat, 2);
            this.cmbBodyFormat.FormattingEnabled = true;
            this.cmbBodyFormat.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBodyFormat.Items.AddRange(new object[] {
            "MM/dd(ddd)",
            "MM/dd",
            "MM月dd日(ddd)",
            "dd日(ddd)",
            "dd日"});
            this.cmbBodyFormat.Location = new System.Drawing.Point(187, 44);
            this.cmbBodyFormat.Name = "cmbBodyFormat";
            this.cmbBodyFormat.Size = new System.Drawing.Size(178, 20);
            this.cmbBodyFormat.TabIndex = 4;
            // 
            // chkDisplayRequire
            // 
            this.chkDisplayRequire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDisplayRequire.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.chkDisplayRequire, 3);
            this.chkDisplayRequire.Location = new System.Drawing.Point(3, 82);
            this.chkDisplayRequire.Name = "chkDisplayRequire";
            this.chkDisplayRequire.Size = new System.Drawing.Size(270, 16);
            this.chkDisplayRequire.TabIndex = 5;
            this.chkDisplayRequire.Text = "人員配置を表示する";
            this.chkDisplayRequire.UseVisualStyleBackColor = true;
            // 
            // chkMonthly
            // 
            this.chkMonthly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMonthly.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.chkMonthly, 2);
            this.chkMonthly.Location = new System.Drawing.Point(3, 118);
            this.chkMonthly.Name = "chkMonthly";
            this.chkMonthly.Size = new System.Drawing.Size(178, 16);
            this.chkMonthly.TabIndex = 6;
            this.chkMonthly.Text = "月で改ページ";
            this.chkMonthly.UseVisualStyleBackColor = true;
            // 
            // nupBreakRow
            // 
            this.nupBreakRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nupBreakRow.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nupBreakRow.Location = new System.Drawing.Point(3, 154);
            this.nupBreakRow.Name = "nupBreakRow";
            this.nupBreakRow.Size = new System.Drawing.Size(86, 19);
            this.nupBreakRow.TabIndex = 7;
            this.nupBreakRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(279, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "列で改ページ";
            // 
            // nupBreakColumn
            // 
            this.nupBreakColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nupBreakColumn.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nupBreakColumn.Location = new System.Drawing.Point(187, 154);
            this.nupBreakColumn.Name = "nupBreakColumn";
            this.nupBreakColumn.Size = new System.Drawing.Size(86, 19);
            this.nupBreakColumn.TabIndex = 8;
            this.nupBreakColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabOthers
            // 
            this.tabOthers.Controls.Add(this.tableLayoutPanel3);
            this.tabOthers.Location = new System.Drawing.Point(4, 22);
            this.tabOthers.Name = "tabOthers";
            this.tabOthers.Size = new System.Drawing.Size(380, 307);
            this.tabOthers.TabIndex = 5;
            this.tabOthers.Text = "その他";
            this.tabOthers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.GrpRemovedItems, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.00613F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.99387F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(380, 307);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // GrpRemovedItems
            // 
            this.GrpRemovedItems.Controls.Add(this.tableLayoutPanel4);
            this.GrpRemovedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpRemovedItems.Location = new System.Drawing.Point(3, 3);
            this.GrpRemovedItems.Name = "GrpRemovedItems";
            this.GrpRemovedItems.Size = new System.Drawing.Size(374, 112);
            this.GrpRemovedItems.TabIndex = 0;
            this.GrpRemovedItems.TabStop = false;
            this.GrpRemovedItems.Text = "削除されたアイテム";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.27119F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.72881F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel4.Controls.Add(this.BtnResqPattern, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.CmbRemovedRequires, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.CmbRemovedMember, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.CmbRemovedPattern, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.BtnResqMember, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnResqRequire, 2, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(368, 94);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // BtnResqPattern
            // 
            this.BtnResqPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnResqPattern.Location = new System.Drawing.Point(311, 34);
            this.BtnResqPattern.Name = "BtnResqPattern";
            this.BtnResqPattern.Size = new System.Drawing.Size(54, 25);
            this.BtnResqPattern.TabIndex = 10;
            this.BtnResqPattern.Text = "復活";
            this.BtnResqPattern.UseVisualStyleBackColor = true;
            this.BtnResqPattern.Click += new System.EventHandler(this.BtnResqPattern_Click);
            // 
            // CmbRemovedRequires
            // 
            this.CmbRemovedRequires.DataSource = this.DsRemovedItems;
            this.CmbRemovedRequires.DisplayMember = "TblRemovedRequires.ClmRRN";
            this.CmbRemovedRequires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbRemovedRequires.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRemovedRequires.FormattingEnabled = true;
            this.CmbRemovedRequires.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CmbRemovedRequires.Location = new System.Drawing.Point(84, 65);
            this.CmbRemovedRequires.Name = "CmbRemovedRequires";
            this.CmbRemovedRequires.Size = new System.Drawing.Size(221, 20);
            this.CmbRemovedRequires.TabIndex = 7;
            this.CmbRemovedRequires.ValueMember = "TblRemovedRequires.ClmRR";
            // 
            // DsRemovedItems
            // 
            this.DsRemovedItems.DataSetName = "NewDataSet";
            this.DsRemovedItems.Tables.AddRange(new System.Data.DataTable[] {
            this.TblRemovedMembers,
            this.TblRemovedPatterns,
            this.TblRemovedRequires,
            this.TblRemovedDayOffs});
            // 
            // TblRemovedMembers
            // 
            this.TblRemovedMembers.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmRM,
            this.ClmRMN});
            this.TblRemovedMembers.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmRM"}, true)});
            this.TblRemovedMembers.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmRM};
            this.TblRemovedMembers.TableName = "TblRemovedMembers";
            // 
            // ClmRM
            // 
            this.ClmRM.AllowDBNull = false;
            this.ClmRM.ColumnName = "ClmRM";
            // 
            // ClmRMN
            // 
            this.ClmRMN.ColumnName = "ClmRMN";
            // 
            // TblRemovedPatterns
            // 
            this.TblRemovedPatterns.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmRP,
            this.ClmRPN});
            this.TblRemovedPatterns.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmRP"}, true)});
            this.TblRemovedPatterns.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmRP};
            this.TblRemovedPatterns.TableName = "TblRemovedPatterns";
            // 
            // ClmRP
            // 
            this.ClmRP.AllowDBNull = false;
            this.ClmRP.ColumnName = "ClmRP";
            // 
            // ClmRPN
            // 
            this.ClmRPN.ColumnName = "ClmRPN";
            // 
            // TblRemovedRequires
            // 
            this.TblRemovedRequires.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmRR,
            this.ClmRRN});
            this.TblRemovedRequires.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmRR"}, true)});
            this.TblRemovedRequires.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmRR};
            this.TblRemovedRequires.TableName = "TblRemovedRequires";
            // 
            // ClmRR
            // 
            this.ClmRR.AllowDBNull = false;
            this.ClmRR.ColumnName = "ClmRR";
            // 
            // ClmRRN
            // 
            this.ClmRRN.ColumnName = "ClmRRN";
            // 
            // TblRemovedDayOffs
            // 
            this.TblRemovedDayOffs.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmRD,
            this.ClmRDN});
            this.TblRemovedDayOffs.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmRD"}, true)});
            this.TblRemovedDayOffs.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmRD};
            this.TblRemovedDayOffs.TableName = "TblRemovedDayOffs";
            // 
            // ClmRD
            // 
            this.ClmRD.AllowDBNull = false;
            this.ClmRD.ColumnName = "ClmRD";
            // 
            // ClmRDN
            // 
            this.ClmRDN.ColumnName = "ClmRDN";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 31);
            this.label16.TabIndex = 0;
            this.label16.Text = "メンバー";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 31);
            this.label17.TabIndex = 1;
            this.label17.Text = "勤務シフト";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(3, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 32);
            this.label19.TabIndex = 3;
            this.label19.Text = "人員配置";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbRemovedMember
            // 
            this.CmbRemovedMember.DataSource = this.DsRemovedItems;
            this.CmbRemovedMember.DisplayMember = "TblRemovedMembers.ClmRMN";
            this.CmbRemovedMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbRemovedMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRemovedMember.FormattingEnabled = true;
            this.CmbRemovedMember.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CmbRemovedMember.Location = new System.Drawing.Point(84, 3);
            this.CmbRemovedMember.Name = "CmbRemovedMember";
            this.CmbRemovedMember.Size = new System.Drawing.Size(221, 20);
            this.CmbRemovedMember.TabIndex = 4;
            this.CmbRemovedMember.ValueMember = "TblRemovedMembers.ClmRM";
            // 
            // CmbRemovedPattern
            // 
            this.CmbRemovedPattern.DataSource = this.DsRemovedItems;
            this.CmbRemovedPattern.DisplayMember = "TblRemovedPatterns.ClmRPN";
            this.CmbRemovedPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbRemovedPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRemovedPattern.FormattingEnabled = true;
            this.CmbRemovedPattern.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CmbRemovedPattern.Location = new System.Drawing.Point(84, 34);
            this.CmbRemovedPattern.Name = "CmbRemovedPattern";
            this.CmbRemovedPattern.Size = new System.Drawing.Size(221, 20);
            this.CmbRemovedPattern.TabIndex = 5;
            this.CmbRemovedPattern.ValueMember = "TblRemovedPatterns.ClmRP";
            // 
            // BtnResqMember
            // 
            this.BtnResqMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnResqMember.Location = new System.Drawing.Point(311, 3);
            this.BtnResqMember.Name = "BtnResqMember";
            this.BtnResqMember.Size = new System.Drawing.Size(54, 25);
            this.BtnResqMember.TabIndex = 8;
            this.BtnResqMember.Text = "復活";
            this.BtnResqMember.UseVisualStyleBackColor = true;
            this.BtnResqMember.Click += new System.EventHandler(this.BtnResqMember_Click);
            // 
            // BtnResqRequire
            // 
            this.BtnResqRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnResqRequire.Location = new System.Drawing.Point(311, 65);
            this.BtnResqRequire.Name = "BtnResqRequire";
            this.BtnResqRequire.Size = new System.Drawing.Size(54, 26);
            this.BtnResqRequire.TabIndex = 12;
            this.BtnResqRequire.Text = "復活";
            this.BtnResqRequire.UseVisualStyleBackColor = true;
            this.BtnResqRequire.Click += new System.EventHandler(this.BtnResqRequire_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.BtnImport);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 121);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(374, 38);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(3, 3);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(365, 23);
            this.BtnImport.TabIndex = 0;
            this.BtnImport.Text = "他のタイムテーブルからデータをインポートする";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.NudPrevDate);
            this.flowLayoutPanel3.Controls.Add(this.BtnRemoveOldItem);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 165);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(374, 139);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // NudPrevDate
            // 
            this.NudPrevDate.Location = new System.Drawing.Point(3, 3);
            this.NudPrevDate.Maximum = new decimal(new int[] {
            3660,
            0,
            0,
            0});
            this.NudPrevDate.Minimum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.NudPrevDate.Name = "NudPrevDate";
            this.NudPrevDate.Size = new System.Drawing.Size(78, 19);
            this.NudPrevDate.TabIndex = 0;
            this.NudPrevDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudPrevDate.Value = new decimal(new int[] {
            365,
            0,
            0,
            0});
            // 
            // BtnRemoveOldItem
            // 
            this.BtnRemoveOldItem.Location = new System.Drawing.Point(87, 3);
            this.BtnRemoveOldItem.Name = "BtnRemoveOldItem";
            this.BtnRemoveOldItem.Size = new System.Drawing.Size(281, 23);
            this.BtnRemoveOldItem.TabIndex = 2;
            this.BtnRemoveOldItem.Text = "日前より古いデータを削除する";
            this.BtnRemoveOldItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRemoveOldItem.UseVisualStyleBackColor = true;
            this.BtnRemoveOldItem.Click += new System.EventHandler(this.BtnRemoveOldItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(310, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(229, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // WeekDateSet
            // 
            this.WeekDateSet.DataSetName = "WeekDateSet";
            this.WeekDateSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            this.WeekDateSet.Tables.AddRange(new System.Data.DataTable[] {
            this.WeekDayTable});
            // 
            // WeekDayTable
            // 
            this.WeekDayTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.WeekDayColumn,
            this.WeekDayNameColumn});
            this.WeekDayTable.TableName = "WeekDayTable";
            // 
            // WeekDayColumn
            // 
            this.WeekDayColumn.Caption = "曜日";
            this.WeekDayColumn.ColumnName = "WeekDayColumn";
            this.WeekDayColumn.DataType = typeof(System.DayOfWeek);
            // 
            // WeekDayNameColumn
            // 
            this.WeekDayNameColumn.Caption = "曜日";
            this.WeekDayNameColumn.ColumnName = "WeekDayName";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 239);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "印刷設定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dlgHeaderFont
            // 
            this.dlgHeaderFont.AllowScriptChange = false;
            this.dlgHeaderFont.ShowEffects = false;
            // 
            // dlgDateFont
            // 
            this.dlgDateFont.AllowScriptChange = false;
            this.dlgDateFont.ShowEffects = false;
            // 
            // dlgBodyFont
            // 
            this.dlgBodyFont.AllowScriptChange = false;
            this.dlgBodyFont.ShowEffects = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tabPrint, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.4F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.6F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(394, 375);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 342);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(388, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // DlgImportFile
            // 
            this.DlgImportFile.DefaultExt = "125";
            this.DlgImportFile.Filter = "スケジュール設定ファイル(*.125)|*.125|xmlファイル(*.xml)|*.xml|全てのファイル|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "125";
            this.saveFileDialog1.Filter = "スケジュール設定ファイル(*.125)|*.125|xmlファイル(*.xml)|*.xml|全てのファイル|*.*";
            // 
            // FScheduleConfigDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(394, 375);
            this.Controls.Add(this.tableLayoutPanel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FScheduleConfigDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "タイムテーブルの設定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScheduleConfigDialog_FormClosed);
            this.Shown += new System.EventHandler(this.ScheduleConfigDialog_Shown);
            this.VisibleChanged += new System.EventHandler(this.ScheduleConfigDialog_VisibleChanged);
            this.tabPrint.ResumeLayout(false);
            this.tabPattern.ResumeLayout(false);
            this.tabPattern.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatternTable)).EndInit();
            this.tabMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MemberDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberTable)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabRequirePatterns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RequirePatternsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequirePatternsTable)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabGeneral.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MondayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayTable)).EndInit();
            this.tabDayOffs.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DayOffDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayOffTable)).EndInit();
            this.tabPrintPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBreakRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBreakColumn)).EndInit();
            this.tabOthers.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.GrpRemovedItems.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsRemovedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedPatterns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedRequires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRemovedDayOffs)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudPrevDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeekDateSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeekDayTable)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox GrpRemovedItems;
        private TableLayoutPanel tableLayoutPanel4;
        private Button BtnResqPattern;
        private ComboBox CmbRemovedRequires;
        private Label label16;
        private Label label17;
        private Label label19;
        private ComboBox CmbRemovedMember;
        private ComboBox CmbRemovedPattern;
        private Button BtnResqMember;
        private Button BtnResqRequire;
        private TableLayoutPanel tableLayoutPanel5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label9;
        private ComboBox cmbSundayRequire;
        private ComboBox cmbFridayRequire;
        private ComboBox cmbSaturdayRequire;
        private ComboBox cmbDefaultRequire;
        private ComboBox cmbWednesdayRequire;
        private ComboBox cmbTuesdayRequire;
        private ComboBox cmbThursdayRequire;
        private ComboBox cmbMondayRequire;
        private DateTimePicker txtEndTime;
        private Label label11;
        private DateTimePicker txtStartTime;
        private TableLayoutPanel tableLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataSet DsRemovedItems;
        private DataTable TblRemovedMembers;
        private DataTable TblRemovedPatterns;
        private DataTable TblRemovedRequires;
        private DataTable TblRemovedDayOffs;
        private DataColumn ClmRM;
        private DataColumn ClmRMN;
        private DataColumn ClmRP;
        private DataColumn ClmRPN;
        private DataColumn ClmRR;
        private DataColumn ClmRRN;
        private DataColumn ClmRD;
        private DataColumn ClmRDN;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button BtnImport;
        private OpenFileDialog DlgImportFile;
        private SaveFileDialog saveFileDialog1;
        private FlowLayoutPanel flowLayoutPanel3;
        private NumericUpDown NudPrevDate;
        private Button BtnRemoveOldItem;
    }
}
