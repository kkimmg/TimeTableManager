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
        /// <summary>コンストラクタ
        /// </summary>
		public FRequirePatternsDialog() {
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
            //this.ClmPattern.DataType = typeof(TimeTableManager.Element.Pattern);
            //this.ClmRequireNum.DataType = typeof(int);
            //this.WeekDayColumn.DataType = typeof(System.DayOfWeek);
			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
            this.clmRequireNumDataGridViewComboBoxColumn.CellTemplate = new NumericCell();
            this.clmRequireNumDataGridViewComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		}
        /// <summary>人員配置
        /// </summary>
        private BRequirePatterns require;
		/// <summary>人員配置
		/// </summary>
		public BRequirePatterns Require {
			get {
				return require;
			}
			set {
				this.require = value;
				//SetValues();
			}
		}
		/// <summary>人員配置からコントロールに値をセットする
		/// </summary>
		private void RequirePatterns2Components() {
			this.TxtRequireName.Text = this.require.Name;   // 名前
						// 人員配置の展開
			BTimeTable table = this.require.TimeTable;
			for (int i = 0; i < table.Patterns.Size(true); i++) {
				BPattern pattern = table.Patterns[i, true];
				int needs = this.require.GetRequire(pattern);
				if (!pattern.BuiltIn && (pattern.Removed == null || needs > 0)) {
					DataRow row = this.TblRequires.NewRow();
					row["ClmPattern"] = pattern;
					row["ClmPatternName"] = pattern.Name;
					row["ClmRequireNum"] = needs;
					this.TblRequires.Rows.Add(row);
				}
			}
			this.ResetTotalCount();
            this.txtNote.Text = this.require.Notes;   // メモ
            this.txtCreated.Value = this.require.Created;   // 作成日
            if (this.require.Removed != null && this.require.Removed > this.txtRemoved.MinDate) {
                this.txtRemoved.Value = (DateTime)this.require.Removed; // 削除日
            }
		}
        /// <summary>コントロールから人員配置に値をセットする
        /// </summary>
        private void Components2RequirePatterns() {
            this.Require.Name = this.TxtRequireName.Text;   // 名前
            foreach (DataRow row in this.TblRequires.Rows) {
                // 人員配置
                BPattern pattern = (BPattern)row["ClmPattern"];
                int curr = (int)row["ClmRequireNum"];
                this.require.SetRequire(pattern, curr);
            }
            this.Require.Notes = txtNote.Text;              // メモ
            this.Require.Created = txtCreated.Value.Date;        // 作成日
            if (Require.Removed != null) {
                this.Require.Removed = txtRemoved.Value.Date;    // 削除日
            }
        }
        /// <summary>合計人数を更新する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
		private void RequiresList_Validated(object sender, System.EventArgs e) {
			this.ResetTotalCount();
		}
        /// <summary>合計人数を更新する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
		private void RequiresList_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			this.ResetTotalCount();
		}
        /// <summary>合計人数を更新する
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
		private void DvRequires_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e) {
			this.ResetTotalCount();
		}
		/// <summary>合計人数を更新する
        /// </summary>
        private void ResetTotalCount () {
			int curr;
			int total = 0;
			foreach (DataRow row in this.TblRequires.Rows) {
				curr = (int)row["ClmRequireNum"];
				total += curr;
				//System.Console.WriteLine("現在の人数：" + curr + ":" + total);
			}
			this.lblTotal.Text = total.ToString();
            //
            if (Require != null) {
                clmRequireNumDataGridViewComboBoxColumn.Items.Clear();
                int sizew = this.Require.TimeTable.Members.Size(true);
                for (int i = 0; i <= sizew || i <= 10; i++) {
                    clmRequireNumDataGridViewComboBoxColumn.Items.Add(i);
                }
                if (sizew < total) {
                    lblTotal.ForeColor = Color.Red;
                } else {
                    lblTotal.ForeColor = Color.Black;
                }
            }
		}
        /// <summary>OK
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnOK_Click (object sender, System.EventArgs e) {
            Components2RequirePatterns();
		}
        /// <summary>初期表示
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void RequirePatternsDialog_Shown (object sender, EventArgs e) {
            RequirePatterns2Components();
            // 表示など
            bool available = (Require.Removed == null);
            this.TxtRequireName.Enabled = available;
            this.RequiresList.Enabled = available;
            this.txtNote.Enabled = available;
            this.txtCreated.Enabled = available;
            this.lblRemoved.Visible = !available;
            this.txtRemoved.Visible = !available;
            this.txtRemoved.Enabled = !available;
        }
	}
    /// <summary>数値をあらわすセル
    /// </summary>
    class NumericCell : System.Windows.Forms.DataGridViewComboBoxCell {
        /// <summary>値の設定時
        /// </summary>
        /// <param name="formattedValue"></param>
        /// <param name="cellStyle"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="valueTypeConverter"></param>
        /// <returns></returns>
        public override object ParseFormattedValue (
                 object formattedValue,
                 DataGridViewCellStyle cellStyle,
                 TypeConverter formattedValueTypeConverter,
                 TypeConverter valueTypeConverter) {
            string str = formattedValue.ToString();
            int ret = 0;
            if (!int.TryParse(str, out ret)) {
                ret = 0;
            }
            return ret;
        }
        /// <summary>値の取得時
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object GetFormattedValue (
              object value, int rowIndex,
              ref DataGridViewCellStyle cellStyle,
              TypeConverter valueTypeConverter,
              TypeConverter formattedValueTypeConverter,
              DataGridViewDataErrorContexts context) {
            int ret = 0;
            if (value != null) {
                if (value is int) {
                    ret = (int)value;
                } else if (!int.TryParse(value.ToString(), out ret)) {
                    ret = 0;
                }
            }
            return (value == null) ? "0" : ret.ToString();
        }
    }
}
