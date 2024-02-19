using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TimeTableManager;
using TimeTableManager.Element;
using TimeTableManager.Component;
using TimeTableManager.UI;
using TimeTableManager.IO;

namespace TimeTableManager.UI {
    public partial class FMainForm : System.Windows.Forms.Form {
        private ImageList imageList1;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripMenuItem MnuFile;
        private ToolStripMenuItem MnuAutoSetting;
        private ToolStripMenuItem MniTool;
        private ToolStripMenuItem MniSaveAs;
        private ToolStripMenuItem MniSave;
        private ToolStripMenuItem MniPrintPreview;
        private ToolStripMenuItem MniPrint;
        private ToolStripMenuItem MniPerind;
        private ToolStripMenuItem MniPaste;
        private ToolStripMenuItem MniOption;
        private ToolStripMenuItem MniOpen;
        private ToolStripMenuItem MniNew;
        private ToolStripMenuItem MniHelpVersion;
        private ToolStripMenuItem MniHelp;
        private ToolStripMenuItem MniExit;
        private ToolStripMenuItem MniEdit;
        private ToolStripMenuItem MniCut;
        private ToolStripMenuItem MniCopy;
        private ToolStripMenuItem MniConfigTimeTable;
        private ToolStripMenuItem MniAutoSelected;
        private ToolStripMenuItem MniAutoAll;
        private ToolStripContentPanel ContentPanel;
        private ToolStripContainer toolStripContainer2;
        private ToolStripContainer toolStripContainer1;
        private ToolStripButton TbbSave;
        private ToolStripButton TbbPrint;
        private ToolStripButton TbbPaste;
        private ToolStripButton TbbOpen;
        private ToolStripButton TbbNew;
        private ToolStripButton TbbCut;
        private ToolStripButton TbbCopy;
        private ToolStripButton TbbConfig;
        private ToolStripButton TbbCalendar;
        private ToolStripButton TbbAutoRow;
        private ToolStripButton TbbAutoAll;
        private ToolStrip TsrTimeTable;
        private ToolStrip TsrGeneral;
        private TabPage tabMultiEdit;
        private TabControl tabMain;
        private System.Windows.Forms.StatusBar MainStatus;
        private System.Windows.Forms.SplitContainer SptBody;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.IContainer components;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
        private PageSetupDialog pageSetupDialog1;
        private UScheduleCalenderView ScheduleViewer1;
        private MenuStrip MnuMainMenu;
        private TabPage tabEvaluation;
        private UCheckList checkList1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem MniRecentFile;
        private TimeTableManager.Printing.BPrintDocumentBody ttmPrintDocumentSt11;
        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMainForm));
            TimeTableManager.Printing.BPrintDocumentFooter cPrintDocumentFooter1 = new TimeTableManager.Printing.BPrintDocumentFooter();
            TimeTableManager.Printing.BPrintDocumentHeader cPrintDocumentHeader1 = new TimeTableManager.Printing.BPrintDocumentHeader();
            this.panelMain = new System.Windows.Forms.Panel();
            this.SptBody = new System.Windows.Forms.SplitContainer();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMultiEdit = new System.Windows.Forms.TabPage();
            this.multiEditor1 = new TimeTableManager.Component.UMultiEditor();
            this.tabEvaluation = new System.Windows.Forms.TabPage();
            this.checkList1 = new TimeTableManager.Component.UCheckList();
            this.ScheduleViewer1 = new TimeTableManager.Component.UScheduleCalenderView();
            this.panelBody = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MainStatus = new System.Windows.Forms.StatusBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.MnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MniNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MniOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MniSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MniSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MniPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.MniPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MniRecentFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MniEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MniCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MniCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MniPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.MniClearRow = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAutoSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MniAutoAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MniAutoSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.MniPerind = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.MniConfigTimeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.MniTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MniExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MniOption = new System.Windows.Forms.ToolStripMenuItem();
            this.MniPlugin = new System.Windows.Forms.ToolStripMenuItem();
            this.MniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MniHelpVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.TsrGeneral = new System.Windows.Forms.ToolStrip();
            this.TbbNew = new System.Windows.Forms.ToolStripButton();
            this.TbbOpen = new System.Windows.Forms.ToolStripButton();
            this.TbbSave = new System.Windows.Forms.ToolStripButton();
            this.TbbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.TbbCut = new System.Windows.Forms.ToolStripButton();
            this.TbbCopy = new System.Windows.Forms.ToolStripButton();
            this.TbbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.TsrTimeTable = new System.Windows.Forms.ToolStrip();
            this.TbbAutoAll = new System.Windows.Forms.ToolStripButton();
            this.TbbAutoRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.TbbCalendar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.TbbConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.ttmPrintDocumentSt11 = new TimeTableManager.Printing.BPrintDocumentBody();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SptBody)).BeginInit();
            this.SptBody.Panel1.SuspendLayout();
            this.SptBody.Panel2.SuspendLayout();
            this.SptBody.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabMultiEdit.SuspendLayout();
            this.tabEvaluation.SuspendLayout();
            this.MnuMainMenu.SuspendLayout();
            this.TsrGeneral.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.TsrTimeTable.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.SptBody);
            this.panelMain.Controls.Add(this.panelBody);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(784, 490);
            this.panelMain.TabIndex = 0;
            // 
            // SptBody
            // 
            this.SptBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SptBody.Location = new System.Drawing.Point(0, 0);
            this.SptBody.Name = "SptBody";
            this.SptBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SptBody.Panel1
            // 
            this.SptBody.Panel1.Controls.Add(this.tabMain);
            // 
            // SptBody.Panel2
            // 
            this.SptBody.Panel2.Controls.Add(this.ScheduleViewer1);
            this.SptBody.Size = new System.Drawing.Size(784, 490);
            this.SptBody.SplitterDistance = 185;
            this.SptBody.TabIndex = 0;
            this.SptBody.TabStop = false;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMultiEdit);
            this.tabMain.Controls.Add(this.tabEvaluation);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(784, 185);
            this.tabMain.TabIndex = 4;
            // 
            // tabMultiEdit
            // 
            this.tabMultiEdit.Controls.Add(this.multiEditor1);
            this.tabMultiEdit.Location = new System.Drawing.Point(4, 22);
            this.tabMultiEdit.Name = "tabMultiEdit";
            this.tabMultiEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiEdit.Size = new System.Drawing.Size(776, 159);
            this.tabMultiEdit.TabIndex = 2;
            this.tabMultiEdit.Text = "複数";
            this.tabMultiEdit.UseVisualStyleBackColor = true;
            // 
            // multiEditor1
            // 
            this.multiEditor1.AutoScroll = true;
            this.multiEditor1.Dates = ((System.Collections.Generic.List<System.DateTime>)(resources.GetObject("multiEditor1.Dates")));
            this.multiEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiEditor1.Location = new System.Drawing.Point(3, 3);
            this.multiEditor1.MainForm = null;
            this.multiEditor1.Name = "multiEditor1";
            this.multiEditor1.Size = new System.Drawing.Size(770, 153);
            this.multiEditor1.TabIndex = 0;
            this.multiEditor1.TimeTable = null;
            // 
            // tabEvaluation
            // 
            this.tabEvaluation.Controls.Add(this.checkList1);
            this.tabEvaluation.Location = new System.Drawing.Point(4, 22);
            this.tabEvaluation.Name = "tabEvaluation";
            this.tabEvaluation.Padding = new System.Windows.Forms.Padding(3);
            this.tabEvaluation.Size = new System.Drawing.Size(776, 159);
            this.tabEvaluation.TabIndex = 3;
            this.tabEvaluation.Text = "評価";
            this.tabEvaluation.UseVisualStyleBackColor = true;
            // 
            // checkList1
            // 
            this.checkList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkList1.Location = new System.Drawing.Point(3, 3);
            this.checkList1.MainForm = null;
            this.checkList1.Name = "checkList1";
            this.checkList1.Size = new System.Drawing.Size(770, 153);
            this.checkList1.TabIndex = 0;
            this.checkList1.TimeTable = null;
            // 
            // ScheduleViewer1
            // 
            this.ScheduleViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleViewer1.EndDate = new System.DateTime(2024, 2, 1, 0, 0, 0, 0);
            this.ScheduleViewer1.Location = new System.Drawing.Point(0, 0);
            this.ScheduleViewer1.MainForm = null;
            this.ScheduleViewer1.Name = "ScheduleViewer1";
            this.ScheduleViewer1.Size = new System.Drawing.Size(784, 301);
            this.ScheduleViewer1.StartDate = new System.DateTime(2006, 6, 1, 0, 0, 0, 0);
            this.ScheduleViewer1.TabIndex = 1;
            this.ScheduleViewer1.TimeTable = null;
            // 
            // panelBody
            // 
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(784, 490);
            this.panelBody.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "125";
            this.openFileDialog1.Filter = "スケジュール設定ファイル(*.125)|*.125|xmlファイル(*.xml)|*.xml|全てのファイル|*.*";
            // 
            // MainStatus
            // 
            this.MainStatus.Location = new System.Drawing.Point(0, 490);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(784, 22);
            this.MainStatus.TabIndex = 2;
            this.MainStatus.Text = "タイムテーブルが選択されていません。";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "125";
            this.saveFileDialog1.Filter = "スケジュール設定ファイル(*.125)|*.125|xmlファイル(*.xml)|*.xml|全てのファイル|*.*";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // MnuMainMenu
            // 
            this.MnuMainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MniEdit,
            this.MnuAutoSetting,
            this.MniTool,
            this.MniPlugin,
            this.MniHelp});
            this.MnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.MnuMainMenu.Name = "MnuMainMenu";
            this.MnuMainMenu.Size = new System.Drawing.Size(784, 24);
            this.MnuMainMenu.TabIndex = 5;
            this.MnuMainMenu.Text = "メインメニュー";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniNew,
            this.MniOpen,
            this.toolStripSeparator2,
            this.MniSave,
            this.MniSaveAs,
            this.toolStripSeparator3,
            this.MniPrint,
            this.MniPrintPreview,
            this.toolStripSeparator5,
            this.MniRecentFile,
            this.toolStripSeparator4,
            this.MniExit});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(67, 20);
            this.MnuFile.Text = "ファイル(&F)";
            this.MnuFile.DropDownOpening += new System.EventHandler(this.MnuFile_Popup);
            // 
            // MniNew
            // 
            this.MniNew.Image = ((System.Drawing.Image)(resources.GetObject("MniNew.Image")));
            this.MniNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniNew.Name = "MniNew";
            this.MniNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MniNew.Size = new System.Drawing.Size(184, 22);
            this.MniNew.Text = "新規作成(&N)";
            this.MniNew.Click += new System.EventHandler(this.MniNew_Click);
            // 
            // MniOpen
            // 
            this.MniOpen.Image = ((System.Drawing.Image)(resources.GetObject("MniOpen.Image")));
            this.MniOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniOpen.Name = "MniOpen";
            this.MniOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MniOpen.Size = new System.Drawing.Size(184, 22);
            this.MniOpen.Text = "開く(&O)";
            this.MniOpen.Click += new System.EventHandler(this.MniOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // MniSave
            // 
            this.MniSave.Image = ((System.Drawing.Image)(resources.GetObject("MniSave.Image")));
            this.MniSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniSave.Name = "MniSave";
            this.MniSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MniSave.Size = new System.Drawing.Size(184, 22);
            this.MniSave.Text = "上書き保存(&S)";
            this.MniSave.Click += new System.EventHandler(this.MniSave_Click);
            // 
            // MniSaveAs
            // 
            this.MniSaveAs.Name = "MniSaveAs";
            this.MniSaveAs.Size = new System.Drawing.Size(184, 22);
            this.MniSaveAs.Text = "名前を付けて保存(&A)";
            this.MniSaveAs.Click += new System.EventHandler(this.MniSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // MniPrint
            // 
            this.MniPrint.Image = ((System.Drawing.Image)(resources.GetObject("MniPrint.Image")));
            this.MniPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniPrint.Name = "MniPrint";
            this.MniPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.MniPrint.Size = new System.Drawing.Size(184, 22);
            this.MniPrint.Text = "印刷(&P)";
            this.MniPrint.Click += new System.EventHandler(this.MniPrint_Click);
            // 
            // MniPrintPreview
            // 
            this.MniPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("MniPrintPreview.Image")));
            this.MniPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniPrintPreview.Name = "MniPrintPreview";
            this.MniPrintPreview.Size = new System.Drawing.Size(184, 22);
            this.MniPrintPreview.Text = "印刷プレビュー(&V)";
            this.MniPrintPreview.Click += new System.EventHandler(this.MniPreview_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(181, 6);
            // 
            // MniRecentFile
            // 
            this.MniRecentFile.Name = "MniRecentFile";
            this.MniRecentFile.Size = new System.Drawing.Size(184, 22);
            this.MniRecentFile.Text = "最近使用したファイル";
            this.MniRecentFile.Click += new System.EventHandler(this.MniRecentFile_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
            // 
            // MniExit
            // 
            this.MniExit.Name = "MniExit";
            this.MniExit.Size = new System.Drawing.Size(184, 22);
            this.MniExit.Text = "終了(&X)";
            this.MniExit.Click += new System.EventHandler(this.MniQuit_Click);
            // 
            // MniEdit
            // 
            this.MniEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniCut,
            this.MniCopy,
            this.MniPaste,
            this.toolStripSeparator8,
            this.MniClearRow});
            this.MniEdit.Name = "MniEdit";
            this.MniEdit.Size = new System.Drawing.Size(57, 20);
            this.MniEdit.Text = "編集(&E)";
            // 
            // MniCut
            // 
            this.MniCut.Image = ((System.Drawing.Image)(resources.GetObject("MniCut.Image")));
            this.MniCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniCut.Name = "MniCut";
            this.MniCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MniCut.Size = new System.Drawing.Size(170, 22);
            this.MniCut.Text = "切り取り(&T)";
            this.MniCut.Click += new System.EventHandler(this.MniCut_Click);
            // 
            // MniCopy
            // 
            this.MniCopy.Image = ((System.Drawing.Image)(resources.GetObject("MniCopy.Image")));
            this.MniCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniCopy.Name = "MniCopy";
            this.MniCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MniCopy.Size = new System.Drawing.Size(170, 22);
            this.MniCopy.Text = "コピー(&C)";
            this.MniCopy.Click += new System.EventHandler(this.MniCopy_Click);
            // 
            // MniPaste
            // 
            this.MniPaste.Image = ((System.Drawing.Image)(resources.GetObject("MniPaste.Image")));
            this.MniPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MniPaste.Name = "MniPaste";
            this.MniPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MniPaste.Size = new System.Drawing.Size(170, 22);
            this.MniPaste.Text = "貼り付け(&P)";
            this.MniPaste.Click += new System.EventHandler(this.MniPaste_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(167, 6);
            // 
            // MniClearRow
            // 
            this.MniClearRow.Image = ((System.Drawing.Image)(resources.GetObject("MniClearRow.Image")));
            this.MniClearRow.Name = "MniClearRow";
            this.MniClearRow.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MniClearRow.Size = new System.Drawing.Size(170, 22);
            this.MniClearRow.Text = "行クリア";
            this.MniClearRow.Click += new System.EventHandler(this.MniDel_Click);
            // 
            // MnuAutoSetting
            // 
            this.MnuAutoSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniAutoAll,
            this.MniAutoSelected,
            this.toolStripSeparator10,
            this.MniPerind,
            this.toolStripSeparator9,
            this.MniConfigTimeTable});
            this.MnuAutoSetting.Name = "MnuAutoSetting";
            this.MnuAutoSetting.Size = new System.Drawing.Size(115, 20);
            this.MnuAutoSetting.Text = "タイムテーブルの設定";
            // 
            // MniAutoAll
            // 
            this.MniAutoAll.Name = "MniAutoAll";
            this.MniAutoAll.Size = new System.Drawing.Size(179, 22);
            this.MniAutoAll.Text = "表示範囲を自動設定";
            this.MniAutoAll.Click += new System.EventHandler(this.MniAutoAll1_Click);
            // 
            // MniAutoSelected
            // 
            this.MniAutoSelected.Name = "MniAutoSelected";
            this.MniAutoSelected.Size = new System.Drawing.Size(179, 22);
            this.MniAutoSelected.Text = "選択範囲を自動設定";
            this.MniAutoSelected.Click += new System.EventHandler(this.MniAutoRow1_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(176, 6);
            // 
            // MniPerind
            // 
            this.MniPerind.Name = "MniPerind";
            this.MniPerind.Size = new System.Drawing.Size(179, 22);
            this.MniPerind.Text = "表示期間";
            this.MniPerind.Click += new System.EventHandler(this.MniPeriod_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(176, 6);
            // 
            // MniConfigTimeTable
            // 
            this.MniConfigTimeTable.Name = "MniConfigTimeTable";
            this.MniConfigTimeTable.Size = new System.Drawing.Size(179, 22);
            this.MniConfigTimeTable.Text = "タイムテーブルの設定";
            this.MniConfigTimeTable.Click += new System.EventHandler(this.MniConfig_Click);
            // 
            // MniTool
            // 
            this.MniTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniExport,
            this.MniOption});
            this.MniTool.Name = "MniTool";
            this.MniTool.Size = new System.Drawing.Size(60, 20);
            this.MniTool.Text = "ツール(&T)";
            // 
            // MniExport
            // 
            this.MniExport.Name = "MniExport";
            this.MniExport.Size = new System.Drawing.Size(134, 22);
            this.MniExport.Text = "エクスポート";
            this.MniExport.Click += new System.EventHandler(this.MniExport_Click);
            // 
            // MniOption
            // 
            this.MniOption.Name = "MniOption";
            this.MniOption.Size = new System.Drawing.Size(134, 22);
            this.MniOption.Text = "オプション(&O)";
            this.MniOption.Click += new System.EventHandler(this.MniOption_Click);
            // 
            // MniPlugin
            // 
            this.MniPlugin.Name = "MniPlugin";
            this.MniPlugin.Size = new System.Drawing.Size(67, 20);
            this.MniPlugin.Text = "追加機能";
            // 
            // MniHelp
            // 
            this.MniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniHelpVersion});
            this.MniHelp.Name = "MniHelp";
            this.MniHelp.Size = new System.Drawing.Size(65, 20);
            this.MniHelp.Text = "ヘルプ(&H)";
            // 
            // MniHelpVersion
            // 
            this.MniHelpVersion.Name = "MniHelpVersion";
            this.MniHelpVersion.Size = new System.Drawing.Size(167, 22);
            this.MniHelpVersion.Text = "バージョン情報(&A)...";
            this.MniHelpVersion.Click += new System.EventHandler(this.MniHelpVersion_Click);
            // 
            // TsrGeneral
            // 
            this.TsrGeneral.Dock = System.Windows.Forms.DockStyle.None;
            this.TsrGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TbbNew,
            this.TbbOpen,
            this.TbbSave,
            this.TbbPrint,
            this.toolStripSeparator,
            this.TbbCut,
            this.TbbCopy,
            this.TbbPaste,
            this.toolStripSeparator1});
            this.TsrGeneral.Location = new System.Drawing.Point(3, 0);
            this.TsrGeneral.Name = "TsrGeneral";
            this.TsrGeneral.Size = new System.Drawing.Size(185, 25);
            this.TsrGeneral.TabIndex = 6;
            this.TsrGeneral.Text = "一般";
            // 
            // TbbNew
            // 
            this.TbbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbNew.Image = ((System.Drawing.Image)(resources.GetObject("TbbNew.Image")));
            this.TbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbNew.Name = "TbbNew";
            this.TbbNew.Size = new System.Drawing.Size(23, 22);
            this.TbbNew.Text = "新規作成(&N)";
            this.TbbNew.Click += new System.EventHandler(this.MniNew_Click);
            // 
            // TbbOpen
            // 
            this.TbbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbOpen.Image = ((System.Drawing.Image)(resources.GetObject("TbbOpen.Image")));
            this.TbbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbOpen.Name = "TbbOpen";
            this.TbbOpen.Size = new System.Drawing.Size(23, 22);
            this.TbbOpen.Text = "開く(&O)";
            this.TbbOpen.Click += new System.EventHandler(this.MniOpen_Click);
            // 
            // TbbSave
            // 
            this.TbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbSave.Image = ((System.Drawing.Image)(resources.GetObject("TbbSave.Image")));
            this.TbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbSave.Name = "TbbSave";
            this.TbbSave.Size = new System.Drawing.Size(23, 22);
            this.TbbSave.Text = "上書き保存(&S)";
            this.TbbSave.Click += new System.EventHandler(this.MniSave_Click);
            // 
            // TbbPrint
            // 
            this.TbbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("TbbPrint.Image")));
            this.TbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbPrint.Name = "TbbPrint";
            this.TbbPrint.Size = new System.Drawing.Size(23, 22);
            this.TbbPrint.Text = "印刷(&P)";
            this.TbbPrint.Click += new System.EventHandler(this.MniPrint_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // TbbCut
            // 
            this.TbbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbCut.Image = ((System.Drawing.Image)(resources.GetObject("TbbCut.Image")));
            this.TbbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbCut.Name = "TbbCut";
            this.TbbCut.Size = new System.Drawing.Size(23, 22);
            this.TbbCut.Text = "切り取り(&U)";
            this.TbbCut.Click += new System.EventHandler(this.TbbCut_Click);
            // 
            // TbbCopy
            // 
            this.TbbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbCopy.Image = ((System.Drawing.Image)(resources.GetObject("TbbCopy.Image")));
            this.TbbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbCopy.Name = "TbbCopy";
            this.TbbCopy.Size = new System.Drawing.Size(23, 22);
            this.TbbCopy.Text = "コピー(&C)";
            this.TbbCopy.Click += new System.EventHandler(this.MniCopy_Click);
            // 
            // TbbPaste
            // 
            this.TbbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbPaste.Image = ((System.Drawing.Image)(resources.GetObject("TbbPaste.Image")));
            this.TbbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbPaste.Name = "TbbPaste";
            this.TbbPaste.Size = new System.Drawing.Size(23, 22);
            this.TbbPaste.Text = "貼り付け(&P)";
            this.TbbPaste.Click += new System.EventHandler(this.MniPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelMain);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.MainStatus);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 512);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 537);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.TsrGeneral);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.TsrTimeTable);
            // 
            // TsrTimeTable
            // 
            this.TsrTimeTable.Dock = System.Windows.Forms.DockStyle.None;
            this.TsrTimeTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TbbAutoAll,
            this.TbbAutoRow,
            this.toolStripSeparator13,
            this.TbbCalendar,
            this.toolStripSeparator14,
            this.TbbConfig});
            this.TsrTimeTable.Location = new System.Drawing.Point(188, 0);
            this.TsrTimeTable.Name = "TsrTimeTable";
            this.TsrTimeTable.Size = new System.Drawing.Size(116, 25);
            this.TsrTimeTable.TabIndex = 7;
            this.TsrTimeTable.Text = "タイムテーブルの設定";
            // 
            // TbbAutoAll
            // 
            this.TbbAutoAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbAutoAll.Image = ((System.Drawing.Image)(resources.GetObject("TbbAutoAll.Image")));
            this.TbbAutoAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbAutoAll.Name = "TbbAutoAll";
            this.TbbAutoAll.Size = new System.Drawing.Size(23, 22);
            this.TbbAutoAll.Text = "全て自動";
            this.TbbAutoAll.Click += new System.EventHandler(this.MniAutoAll1_Click);
            // 
            // TbbAutoRow
            // 
            this.TbbAutoRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbAutoRow.Image = ((System.Drawing.Image)(resources.GetObject("TbbAutoRow.Image")));
            this.TbbAutoRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbAutoRow.Name = "TbbAutoRow";
            this.TbbAutoRow.Size = new System.Drawing.Size(23, 22);
            this.TbbAutoRow.Text = "行を自動";
            this.TbbAutoRow.Click += new System.EventHandler(this.MniAutoRow1_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // TbbCalendar
            // 
            this.TbbCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbCalendar.Image = ((System.Drawing.Image)(resources.GetObject("TbbCalendar.Image")));
            this.TbbCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbCalendar.Name = "TbbCalendar";
            this.TbbCalendar.Size = new System.Drawing.Size(23, 22);
            this.TbbCalendar.Text = "表示期間";
            this.TbbCalendar.Click += new System.EventHandler(this.MniPeriod_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // TbbConfig
            // 
            this.TbbConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbbConfig.Image = ((System.Drawing.Image)(resources.GetObject("TbbConfig.Image")));
            this.TbbConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbbConfig.Name = "TbbConfig";
            this.TbbConfig.Size = new System.Drawing.Size(23, 22);
            this.TbbConfig.Text = "設定";
            this.TbbConfig.Click += new System.EventHandler(this.MniConfig_Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.AutoScroll = true;
            this.toolStripContainer2.ContentPanel.Controls.Add(this.toolStripContainer1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(784, 537);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(784, 561);
            this.toolStripContainer2.TabIndex = 7;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.MnuMainMenu);
            // 
            // ttmPrintDocumentSt11
            // 
            this.ttmPrintDocumentSt11.DateColumnWidth = 80F;
            this.ttmPrintDocumentSt11.DocumentName = "TimeTableDocument";
            this.ttmPrintDocumentSt11.End = new System.DateTime(((long)(0)));
            cPrintDocumentFooter1.Document = null;
            cPrintDocumentFooter1.TimeTable = null;
            this.ttmPrintDocumentSt11.Footer = cPrintDocumentFooter1;
            cPrintDocumentHeader1.Document = null;
            cPrintDocumentHeader1.Page = null;
            cPrintDocumentHeader1.TimeTable = null;
            this.ttmPrintDocumentSt11.Header = cPrintDocumentHeader1;
            this.ttmPrintDocumentSt11.RequireColumnWidth = 80F;
            this.ttmPrintDocumentSt11.Start = new System.DateTime(((long)(0)));
            this.ttmPrintDocumentSt11.TableHeaderHight = 25F;
            this.ttmPrintDocumentSt11.TimeTable = null;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.ttmPrintDocumentSt11;
            this.printDialog1.UseEXDialog = true;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.ttmPrintDocumentSt11;
            // 
            // FMainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "タイムテーブルエディタ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMainForm_FormClosing);
            this.Load += new System.EventHandler(this.FMainForm_Load);
            this.Shown += new System.EventHandler(this.FMainForm_Shown);
            this.panelMain.ResumeLayout(false);
            this.SptBody.Panel1.ResumeLayout(false);
            this.SptBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SptBody)).EndInit();
            this.SptBody.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMultiEdit.ResumeLayout(false);
            this.tabEvaluation.ResumeLayout(false);
            this.MnuMainMenu.ResumeLayout(false);
            this.MnuMainMenu.PerformLayout();
            this.TsrGeneral.ResumeLayout(false);
            this.TsrGeneral.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.TsrTimeTable.ResumeLayout(false);
            this.TsrTimeTable.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private UMultiEditor multiEditor1;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem MniClearRow;
        /// <summary>タイムテーブルは編集済み？
        /// </summary>
        private bool timeTableEdited = false;
        /// <summary>ランダム化する装置
        /// </summary>
        private TimeTableManager.IFavoriteRandomizer randomizer;
        /// <summary>編集中のタイムテーブル
        /// </summary>
        private BTimeTable timeTable;
        /// <summary>編集中のタイムテーブルのファイル名
        /// </summary>
        private string fileName;
        /// <summary>最近使ったファイル
        /// </summary>
        private System.Collections.Generic.List<string> recents;
        /// <summary>最近使ったファイル
        /// </summary>
        private System.Collections.Generic.List<MenuItem> resentItems;
        /// <summary>うーむ
        /// </summary>
        private List<BScheduledDate> selectedDates = new List<BScheduledDate>();
        /// <summary>この以後は次の月にする
        /// </summary>
        private int nextMonthDay = 0;
        private ToolStripMenuItem MniExport;
        private ToolStripMenuItem MniPlugin;
    }
}
