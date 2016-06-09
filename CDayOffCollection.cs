using System;
using TimeTableManager.Element;
using System.Collections;
using System.Collections.Generic;

namespace TimeTableManager.ElementCollection {
	/// <summary>
	/// DayOffCollection の概要の説明です。
	/// </summary>
	public class CDayOffCollection:CAbstractElement {
		/// <summary>タイムテーブル
        /// </summary>
		private CTimeTable root;
		/// <summary>休日の内部配列
        /// </summary>
		private List<CDayOff> DayOffs;
	    /// <summary>コンストラクタ
	    /// </summary>
	    /// <param name="parent"></param>
		public CDayOffCollection(CTimeTable parent) {
			// 
			// TODO: コンストラクタ ロジックをここに追加してください。
			//
			root = parent;
            DayOffs = new List<CDayOff>();
		}
		/// <summary>休日
		/// </summary>
		public CDayOff this[int n] {
			get {
				return DayOffs[n];
			}
		}
		/// <summary>名前から取得
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public CDayOff GetByName (string name) {
			CDayOff ret = null;
			for (int i = 0; i < Count; i++) {
				if (this[i].Name == name) {
					ret = this[i];
					break;
				}
			}
			return ret;
		}
		/// <summary>タイムテーブル
		/// </summary>
		public override CTimeTable TimeTable {
			get {
				return root;
			}
		}
		/// <summary>サイズ
		/// </summary>
		public int Count {
			get {
				return DayOffs.Count;
			}
		}
        /// <summary>サイズ
        /// </summary>
        /// <returns>登録されている休日の数</returns>
        public int Size() {
            return Count;
        }
		/// <summary>休日を追加する
		/// </summary>
		public void AddDayOff(CDayOff dayoff) {
			this.DayOffs.Add(dayoff);
            if (TimeTable != null) {
                TimeTable.NotifyDayOffsEdited(EnumTimeTableElementEventTypes.ElementAdded, dayoff);
            }
		}
		/// <summary>休日の作成
		/// </summary>
		public CDayOff CreateDayOff() {
			CDayOff RetValue = new CDayOff(this);
			return RetValue;
		}
        /// <summary>新しい休日の作成（初期化つき）
        /// </summary>
        /// <param name="init"></param>
        /// <returns></returns>
        public CDayOff CreateDayOff(bool init) {
            CDayOff RetValue = CreateDayOff();
            if (init) {
                RetValue.Name = "新しい休日";
                RetValue.StartDate = System.DateTime.Today;
                RetValue.EndDate = System.DateTime.Today;
            }
            return RetValue;
        }
		/// <summary>休日の削除
		/// </summary>
		public void DeleteDayOff(int n) {
            CDayOff doff = DayOffs[n];
            DeleteDayOff(doff);
		}
		/// <summary>休日の削除
		/// </summary>
		public void DeleteDayOff(CDayOff dayoff) {
			DayOffs.Remove(dayoff);
            if (TimeTable != null) {
                TimeTable.NotifyDayOffsEdited(EnumTimeTableElementEventTypes.ElementRemoved, dayoff);
            }
		}
		/// <summary>これは休日か？
		/// </summary>
		public bool IsDayOff(DateTime date) {
			foreach (CDayOff day in this.DayOffs) {
				if (date >= day.StartDate && date <= day.EndDate) {
					return true;
				}
			}
			return false;
		}

	}
}
