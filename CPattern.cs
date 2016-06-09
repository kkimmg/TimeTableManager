using System;
using TimeTableManager.ElementCollection;
namespace TimeTableManager.Element {
    /// <summary>勤務シフト
    /// </summary>
	public class CPattern:CAbstractElement {
        /// <summary>一日中</summary>
        public static readonly TimeSpan AllDay = new TimeSpan(24, 0, 0);
        /// <summary>ゼロ時間</summary>
        public static readonly TimeSpan ZeroDay = TimeSpan.Zero;//new TimeSpan(0, 0, 0);
        /// <summary>休日</summary>
        public static readonly CPattern DAYOFF = new NOWORK_PATTERN();
        /// <summary>複数選択されている場合</summary>
        public static readonly CPattern MULTI = new MULTI_PATTERN();
        /// <summary>ナル値の替わり</summary>
        public static readonly CPattern NULL = new NULL_PATTERN();
		/// <summary>勤務シフト名 </summary>
		private string name;
		/// <summary>親オブジェクト(シフトコレクション) </summary>
		private CPatternCollection parent;
        /// <summary>開始時間</summary>
        private TimeSpan start;
        /// <summary>開始から終了まで</summary>
        private TimeSpan scope = TimeSpan.Zero;//new TimeSpan(0, 0, 0, 0);
		/// <summary>休憩時間</summary>
        private TimeSpan rest = TimeSpan.Zero;//new TimeSpan(0, 0, 0, 0);		
		/// <summary>
		/// シフト名
		/// </summary>
		virtual public string Name {
			get {
				return name;
			}			
			set {
				this.name = value;
			}			
		}
		/// <summary>
		/// 休憩時間
		/// </summary>
		virtual public TimeSpan Rest {
			get {
				return rest;
			}
			
			set {
				if (rest < AllDay) {
					rest = value;
				}
			}
			
		}
		/// <summary>
		/// タイムテーブル
		/// </summary>
		override public CTimeTable TimeTable {
			get {
                if (parent == null) return null;
				return parent.TimeTable;
			}
			
		}
		/// <summary>
		/// 期間の取得
		/// </summary>
		virtual public TimeSpan Scope {
            set {
                scope = value;
            }
			get {
				return scope;
			}
			
		}
		/// <summary>
		/// 開始時刻
		/// </summary>
		virtual public TimeSpan Start {
			get {
				return start;
			}			
			set {
				start = value;
			}			
		}
        /// <summary>
        /// 終了時刻
        /// </summary>
        virtual public TimeSpan End {
            get {
                return Start + Scope;
            }
        }
		/// <returns>
		/// 日付を超えているかどうか
		/// </returns>
		virtual public bool Over {
			get {
				bool ret = false;
				if (Scope > AllDay) {
					ret = true;
				}
				return ret;
			}			
		}
		/// <summary>
		/// シフト（コンストラクタ）
		/// </summary>
		public CPattern(CPatternCollection collection):base() {
			this.parent = collection;
		}
		/// <summary>
		/// シフト（コンストラクタ）
		/// </summary>
		public CPattern(CPatternCollection parent, int id):this(parent) {
			ObjectID = id;
		}
	}
    /// <summary>休みシフト(-9999)
    /// </summary>
	public class NOWORK_PATTERN : CPattern {
        /// <summary>コンストラクタ
        /// </summary>
		public NOWORK_PATTERN():base(null) {
		}
		/// <summary>
		/// シフト名
		/// </summary>
		override public string Name {
			get {
				return "休み";
			}
		}
		/// <summary>
		/// 休憩時間
		/// </summary>
		override public TimeSpan Rest {
			get {
				return CPattern.ZeroDay;
			}
		}
		/// <summary>
		/// 期間の取得
		/// </summary>
		override public TimeSpan Scope {
			get {
				return CPattern.ZeroDay;
			}
			
		}
		/// <summary>
		/// 開始時刻
		/// </summary>
		override public TimeSpan Start {
			get {
				return TimeSpan.MinValue;
			}			
		}
    	/// <returns>
		/// 日付を超えているかどうか
		/// </returns>
		override public bool Over {
			get {
				return false;
			}			
		}
        /// <summary>オブジェクトIDのオーバーライド
        /// </summary>
		public override long ObjectID {
			get {
				return -9999;
			}
			set {
			}
		}
        /// <summary>ビルトインオブジェクトのオーバーライド
        /// </summary>
        public override bool BuiltIn {
            get {
                return true;
            }
        }
        /// <summary>作成日は日付の最小値
        /// </summary>
        public override DateTime Created {
            get {
                return DateTime.MinValue;
            }
        }
        /// <summary>常に削除されない
        /// </summary>
        public override DateTime? Removed {
            get {
                return null;
            }
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="now">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime now) {
            return true;
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="param0">日付にかかわらない</param>
        /// <param name="param1">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime param0, DateTime param1) {
            return true;
        }
	}
    /// <summary>複数シフト(-9998)
    /// </summary>
    public class MULTI_PATTERN : CPattern {
        /// <summary>コンストラクタ
        /// </summary>
        public MULTI_PATTERN ()
            : base(null) {
        }
        /// <summary>
        /// シフト名
        /// </summary>
        override public string Name {
            get {
                return "複数選択されています";
            }
        }
        /// <summary>
        /// 休憩時間
        /// </summary>
        override public TimeSpan Rest {
            get {
                return CPattern.ZeroDay;
            }
        }
        /// <summary>
        /// 期間の取得
        /// </summary>
        override public TimeSpan Scope {
            get {
                return CPattern.ZeroDay;
            }
        }
        /// <summary>
        /// 開始時刻
        /// </summary>
        override public TimeSpan Start {
            get {
                return TimeSpan.MinValue;
            }
        }
        /// <returns>
        /// 日付を超えているかどうか
        /// </returns>
        override public bool Over {
            get {
                return false;
            }
        }
        /// <summary>オブジェクトIDのオーバーライド
        /// </summary>
        public override long ObjectID {
            get {
                return -9998;
            }
            set {
            }
        }
        /// <summary>ビルトインオブジェクトのオーバーライド
        /// </summary>
        public override bool BuiltIn {
            get {
                return true;
            }
        }
        /// <summary>作成日は日付の最小値
        /// </summary>
        public override DateTime Created {
            get {
                return DateTime.MinValue;
            }
        }
        /// <summary>常に削除されない
        /// </summary>
        public override DateTime? Removed {
            get {
                return null;
            }
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="now">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime now) {
            return true;
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="param0">日付にかかわらない</param>
        /// <param name="param1">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime param0, DateTime param1) {
            return true;
        }
    }
    /// <summary>NULLシフト(-10000)
    /// </summary>
    public class NULL_PATTERN : CPattern {
        /// <summary>コンストラクタ
        /// </summary>
        public NULL_PATTERN ()
            : base(null) {
        }
        /// <summary>
        /// シフト名
        /// </summary>
        override public string Name {
            get {
                return "";
            }
        }
        /// <summary>
        /// 休憩時間
        /// </summary>
        override public TimeSpan Rest {
            get {
                return CPattern.ZeroDay;
            }
        }
        /// <summary>
        /// 期間の取得
        /// </summary>
        override public TimeSpan Scope {
            get {
                return CPattern.ZeroDay;
            }
        }
        /// <summary>
        /// 開始時刻
        /// </summary>
        override public TimeSpan Start {
            get {
                return TimeSpan.MinValue;
            }
        }
        /// <returns>
        /// 日付を超えているかどうか
        /// </returns>
        override public bool Over {
            get {
                return false;
            }
        }
        /// <summary>オブジェクトIDのオーバーライド
        /// </summary>
        public override long ObjectID {
            get {
                return -10000;
            }
            set {
            }
        }
        /// <summary>ビルトインオブジェクトのオーバーライド
        /// </summary>
        public override bool BuiltIn {
            get {
                return true;
            }
        }
        /// <summary>作成日は日付の最小値
        /// </summary>
        public override DateTime Created {
            get {
                return DateTime.MinValue;
            }
        }
        /// <summary>常に削除されない
        /// </summary>
        public override DateTime? Removed {
            get {
                return null;
            }
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="now">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime now) {
            return true;
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="param0">日付にかかわらない</param>
        /// <param name="param1">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime param0, DateTime param1) {
            return true;
        }
    }

}