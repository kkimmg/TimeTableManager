using System;
using TimeTableManager.Element;
namespace TimeTableManager {
    /// <summary>タイムテーブルを構成する要素の共通部分
    /// </summary>
	public abstract class BAbstractElement : ITimeTableElement, IComparable {
		/// <summary>ヌル日付の代わり
		/// </summary>
        public static readonly DateTime? NullDate = null;
		/// <summary>作成日
		/// </summary>
		private System.DateTime created = DateTime.Now;
		/// <summary>オブジェクトID
		/// </summary>
		private long objectID;
		/// <summary>プロパティ
		/// </summary>
		protected internal System.Collections.Specialized.NameValueCollection properties;
		/// <summary>削除日
		/// </summary>
		private System.DateTime? removed = NullDate;
        /// <summary>コンストラクタ
        /// </summary>
		public BAbstractElement() {
			properties = new System.Collections.Specialized.NameValueCollection();
		}
        /// <summary>作成日
        /// </summary>
		virtual public System.DateTime Created {
			get {
				return created;
			}
			set {
				this.created = value;
			}
			
		}
        /// <summary>次のID
        /// </summary>
		virtual public long NextID {
			get {
				return TimeTable.NextID;
			}
		}
        /// <summary>プロパティのキーの一覧
        /// </summary>
        /// <returns>プロパティのキーの一覧</returns>
		virtual public System.Collections.IEnumerator GetEnumerator() {
			return properties.Keys.GetEnumerator();
		}
		/// <summary>削除日
		/// </summary>
        virtual public System.DateTime? Removed {
			get {
				return removed;
			}
			set {
				this.removed = value;
			}
			
		}
        /// <summary>プロパティ
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>値</returns>
		public virtual string GetProperty(string key) {
			return (properties[key] == null)?"":properties[key].Trim();
		}
        /// <summary>このエレメントは有効か？
        /// </summary>
        /// <param name="now">日付</param>
        /// <returns></returns>
		public virtual bool IsAvailable(System.DateTime now) {
			bool comp = true;   // 基本は有効
            if (removed == null) {
                // 削除されていない
                comp = true;
            } else if (removed == NullDate) {
                // 削除されていない
				comp = true;
			} else {
                // 削除されてるが指定日よりあとの日付
				comp = (now <= Removed);
			}
            // 指定日より前に作成されている
			comp &= (Created <= now);
			return comp;
			
		}
        /// <summary>このエレメントは有効か？
        /// </summary>
        /// <param name="param0">開始</param>
        /// <param name="param1">終了</param>
        /// <returns></returns>
        public virtual bool IsAvailable(System.DateTime param0, System.DateTime param1) {
            if (IsAvailable(param0)) return true;
            if (IsAvailable(param1)) return true;
            return (Created <= param0 && param1 <= Removed);
        }
        /// <summary>このエレメントは有効かどうかを設定する
        /// </summary>
        /// <param name="available">有効／無効の設定</param>
		public virtual void  SetAvailable(bool available) {
			SetAvailable(available, System.DateTime.Now);
		}
        /// <summary>このエレメントは有効かどうかを設定する
        /// </summary>
        /// <param name="available">有効／無効の設定</param>
        /// <param name="removed">無効になった日付</param>
        public virtual void  SetAvailable(bool available, System.DateTime removed) {
			if (!available) {
                if (this.removed == NullDate) {
                    this.removed = removed;
                }
			} else {
				this.removed = NullDate;
			}
		}
        /// <summary>プロパティのセット
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="pValue">値</param>
		public virtual void SetProperty(string key, string pValue) {
			properties[key] = pValue;
		}
        /// <summary>タイムテーブル
        /// </summary>
		public abstract BTimeTable TimeTable {
			get;
		}
        /// <summary>比較する
        /// </summary>
        /// <param name="obj">比較対照</param>
        /// <returns>1:thisが大きい,2:objが大きい,0:等しい</returns>
		public int CompareTo(object obj) {
			ITimeTableElement o = obj as ITimeTableElement;
            int ret = 0;
            if (ObjectID > o.ObjectID) {
                ret = 1;
            } else if (ObjectID < o.ObjectID) {
                ret = -1;
            }
			return ret;
		}
        /// <summary>オブジェクトID
        /// </summary>
		public virtual long ObjectID {
			get {
				if (objectID <= 0 && !BuiltIn) objectID = NextID;
				return objectID;
			}
			set {
				objectID = value;
			}
		}
		/// <summary>プロパティ
		/// </summary>
		public string this[string key] {
			get {
				return GetProperty(key);
			}
			set {
				SetProperty(key, value);
			}
		}
        /// <summary>メモ
        /// </summary>
        private string notes;
        /// <summary>メモ
        /// </summary>
        public virtual string Notes {
            get {
                if (notes == null) return "";
                return notes.Trim();
                //string notes = GetProperty("notes");
                //return notes;
            }
            set {
                notes = value;
                //SetProperty("notes", value);
            }
        }
        /// <summary>これはビルトインオブジェクトですか？
        /// </summary>
        public virtual bool BuiltIn {
            get {
                return false;
            }
        }
	}
}