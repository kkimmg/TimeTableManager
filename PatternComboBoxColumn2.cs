using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.Component {
	/// <summary>
	/// Class1 の概要の説明です。
	/// </summary>
	public class PatternComboBoxColumn2 : DataGridColumnStyle {
		internal ScheduleEditor view;
		internal ScheduledDate  sdate;
		//internal Member member;
		// コンボボックス
		public ScheduleComboBox comboBox1 = new ScheduleComboBox();
		public virtual ScheduleComboBox InCombo {
			get {
				return comboBox1;
			}
			set {
				comboBox1 = value;
			}
		}
		// 編集中？
		private bool isEditing;
		// コンストラクタ
		public PatternComboBoxColumn2() : base() {
			InCombo.Visible = false;
		}
		// 編集プロシージャを中断する要求
		protected override void Abort(int rowNum) {
			isEditing = false;
			InCombo.SelectedValueChanged -= new EventHandler(InCombo_ValueChanged);
			Invalidate();
		}
		// 編集プロシージャを完了する要求
		protected override bool Commit (CurrencyManager dataSource, int rowNum) {
			InCombo.Bounds = Rectangle.Empty; 
			InCombo.SelectedValueChanged -= new EventHandler(InCombo_ValueChanged); 			
			if (!isEditing) return true; 			
			isEditing = false; 			
			try {
				object value = ComboBox_SelectedValue;
				SetColumnValueAtRow(dataSource, rowNum, value);
			} catch (Exception) {
				Abort(rowNum);
				return false;
			} 			
			Invalidate();
			return true;
		} 		
		// 値を編集するためにセルを準備
		protected override void Edit( CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) {
			//comboBox1 = new ScheduleComboBox();
			ScheduledDate sdate = view.Date;
			DateTime date = sdate.Date;
			Member member = view.ScheduleDateTable.Rows[rowNum][0] as Member;
			object value = GetColumnValueAtRow(source, rowNum);
			if (cellIsVisible && date.CompareTo(DateTime.Now) >= 0) {
				InCombo.Name = "CellEditor";
				InCombo.Schedule = sdate[member];
				InCombo.Bounds = new Rectangle (bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4);
				//ComboBox_SelectedValue = value;// 初期値は自分で設定するので・・
				InCombo.Visible = true;
				InCombo.SelectedValueChanged += new EventHandler(InCombo_ValueChanged);
			} else {
				//ComboBox_SelectedValue = value;// 初期値は自分で設定するので・・
				InCombo.Visible = false;
			} 			
			if (InCombo.Visible) DataGridTableStyle.DataGrid.Invalidate(bounds);
		} 
		/// <summary>
		/// コンボボックスの値
		/// ここをオーバーライドする
		/// </summary>
		public virtual object ComboBox_SelectedValue {
			get {
				Pattern ret = null;
				System.Data.DataRowView drv = (System.Data.DataRowView)InCombo.SelectedItem;
				if (drv != null) {
					ret = drv.Row["ScheduleColumn"] as Pattern;
				}
				return ret;
			}
			set {
				//InCombo.SelectedValue = value;
			}
		}
		// 自動サイズ
		protected override Size GetPreferredSize( Graphics g, object value) {
			return new Size(100, InCombo.PreferredHeight + 4);
		} 		
		// 行の最小の高さ
		protected override int GetMinimumHeight() {
			return InCombo.PreferredHeight + 4;
		} 		
		// 列のサイズを自動的に変更するために使用する高さ
		protected override int GetPreferredHeight(Graphics g, object value) {
			return InCombo.PreferredHeight + 4;
		} 	
		// お絵かき
		protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum) {
			Paint(g, bounds, source, rowNum, false);
		}
		// お絵かき
		protected override void Paint( Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight) {
			Paint( g,bounds, source, rowNum, Brushes.Red, Brushes.Blue, alignToRight);
		}
		// お絵かき
		protected override void Paint( Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight) {
			object value = GetColumnValueAtRow(source, rowNum);
			Rectangle rect = bounds;
			g.FillRectangle(backBrush,rect);
			rect.Offset(0, 2);
			rect.Height -= 2;
			g.DrawString(getValueText(rowNum), this.DataGridTableStyle.DataGrid.Font, foreBrush, rect);
		}
		// 表示するテキスト
		protected virtual string getValueText (int rowNum) {
			sdate = view.Date;
			DateTime date = sdate.Date;
			//ScheduledDate sdate = view.sAll[date];
			Member member = view.ScheduleDateTable.Rows[rowNum][0] as Member;
			Schedule scl = sdate[member];
			Pattern obj = scl.Pattern;
			if (obj == null) return "";
			return obj.Name;
		}
		// グリッドの設定
		protected override void SetDataGridInColumn(DataGrid value) {
			base.SetDataGridInColumn(value);
			if (InCombo.Parent != null) {
				InCombo.Parent.Controls.Remove (InCombo);
			}
			if (value != null) {
				value.Controls.Add(InCombo);
			}
		} 		
		// コンボボックスの値が変更された
		private void InCombo_ValueChanged(object sender, EventArgs e) {
			this.isEditing = true;
			base.ColumnStartedEditing(InCombo);
		}
	}
}
