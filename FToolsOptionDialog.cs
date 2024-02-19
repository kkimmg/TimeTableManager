using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Element;

namespace TimeTableManager.UI {
    /// <summary>オプションダイアログ
    /// </summary>
    public partial class FToolsOptionDialog : Form {
        /// <summary>親画面
        /// </summary>
        private FMainForm form {
            get {
                return this.Owner as FMainForm;
            }
        }
        /// <summary>コンストラクタ
        /// </summary>
        public FToolsOptionDialog() {
            InitializeComponent();
        }
        /// <summary>ＯＫ
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void BtnOK_Click(object sender, EventArgs e) {
            // 次の月を表示する
            form.NextMonthDay = (int)this.NumChangeMonth.Value;
            #region 自動設定
            IFavoriteRandomizer randomizer = form.Randomizer;
            Type type = randomizer.GetType();
            if (this.RdoWeekly.Checked) {
                form.Randomizer = new CWeeklyFavoriteRandomizer();
            } else if (this.RdoMonthly.Checked) {
                form.Randomizer = new CMonthlyFavoriteRandomizer();
            } else if (this.RdoMonthlyWeekly.Checked) {
                form.Randomizer = new CMonthlyWeeklyFavoriteRandomizer();
            } else {
                form.Randomizer = new BDefaultFavoriteRandomizer();
            }
            #endregion
            // 当時からこの日数分は自動設定しない
            form.DayAfter = (int)this.NumAutoBuf.Value;
            // 列幅の自動設定
            TimeTableManager.Component.UScheduleCalenderView.ColumnFitAuto = this.ChkAdjustCalendar.Checked;
            // エディタのリボン編集の閾値
            TimeTableManager.Component.UMultiEditor.Threshold = this.DspEditorThreshold.Value.TimeOfDay;
            // 過去の編集を可能にするかどうか
            form.IsEditHistory = this.ChkEditHistory.Checked;
            // 終了
            Dispose();
        }
        /// <summary>初期値の設定
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void ToolsOptionDialog_Shown(object sender, EventArgs e) {
            // 次の月を表示する
            this.NumChangeMonth.Value = form.NextMonthDay;
            #region 自動設定
            IFavoriteRandomizer randomizer = form.Randomizer;
            Type type = randomizer.GetType();
            if (type == typeof(CWeeklyFavoriteRandomizer)) {
                this.RdoWeekly.Checked = true;
            } else if (type == typeof(CMonthlyFavoriteRandomizer)) {
                this.RdoMonthly.Checked = true;
            } else if (type == typeof(CMonthlyWeeklyFavoriteRandomizer)) {
                this.RdoMonthlyWeekly.Checked = true;
            } else {
                this.RdoDefault.Checked = true;
            }
            #endregion
            // 当時からこの日数分は自動設定しない
            this.NumAutoBuf.Value = form.DayAfter;
            //
            this.ChkAdjustCalendar.Checked = TimeTableManager.Component.UScheduleCalenderView.ColumnFitAuto;
            //
            this.DspEditorThreshold.Value = DateTime.Today + TimeTableManager.Component.UMultiEditor.Threshold;
            //
            this.ChkEditHistory.Checked = form.IsEditHistory;
            // プラグイン
            Dictionary<ToolStripMenuItem, TimeTableManager.Plugin.IPlugin> plugins = form.Plugins;
            foreach (TimeTableManager.Plugin.IPlugin plugin in plugins.Values) {
                DataRow row = TblPlugins.NewRow();
                row["ClmPlugin"] = plugin;
                row["ClmPluginDesc"] = plugin.PluginDescription;
                TblPlugins.Rows.Add(row);
            }
        }
        /// <summary>プラグインの設定ダイアログを開く
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnConfigPlugin_Click (object sender, EventArgs e) {
            try {
                DataRowView view = (DataRowView)this.LstPlugins.SelectedItem;
                if (view != null) {
                    DataRow row = view.Row;
                    if (row != null) {
                        TimeTableManager.Plugin.IPlugin plugin = row["ClmPlugin"] as TimeTableManager.Plugin.IPlugin;
                        if (plugin != null) {
                            plugin.ShowConfigDialog(this);
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(this, ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>プラグインの設定ダイアログを開く
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void LstPlugins_DoubleClick (object sender, EventArgs e) {
            BtnConfigPlugin_Click(sender, e);
        }
    }
}