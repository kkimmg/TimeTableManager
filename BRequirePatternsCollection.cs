using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;
namespace TimeTableManager.ElementCollection {
    /// <summary>人員配置の一覧
    /// </summary>
	public class BRequirePatternsCollection:BAbstractElement {
		/// <summary>スケジュール全て 
        /// </summary>
		override public BTimeTable TimeTable {
			get {
				return parent;
			}
			
		}
		/// <summary>すべての人員配置 
        /// </summary>
		private List<BRequirePatterns> allrequires;
		/// <summary>有効な人員配置 
        /// </summary>
        private List<BRequirePatterns> availables;
		/// <summary>スケジュールすべて 
        /// </summary>
		private BTimeTable parent;
		/// <summary>有効な人数のコレクション
        /// </summary>
		public BRequirePatternsCollection(BTimeTable parent):base() {
			this.parent = parent;
            availables = new List<BRequirePatterns>();
            allrequires = new List<BRequirePatterns>();
            // ビルトインの追加
            AddRequirePatterns(BRequirePatterns.NULL);
            AddRequirePatterns(BRequirePatterns.DAYOFF);
		}
		/// <summary>人員配置の追加
        /// </summary>
		public virtual void  AddRequirePatterns(BRequirePatterns AddingValue) {
            // すでに登録済みならIDを再交付
            while (GetByIDorNull(AddingValue.ObjectID) != null && TimeTable != null) {
                AddingValue.ObjectID = NextID;
            }
            // 本体
			allrequires.Add(AddingValue);
			if (AddingValue.Removed == null) {
				availables.Add(AddingValue);
			}
            if (TimeTable != null) {
                TimeTable.NotifyRequirePatternssEdited(EnumTimeTableElementEventTypes.ElementAdded, AddingValue);
            }
		}
		/// <summary>人員配置の作成
        /// </summary>
		public virtual BRequirePatterns CreateRequirePatterns() {
			BRequirePatterns ret = new BRequirePatterns(TimeTable.Patterns, this);
			return ret;
		}
        /// <summary>人員配置の作成
        /// </summary>
        public virtual BRequirePatterns CreateRequirePatterns(bool init) {
            BRequirePatterns ret = CreateRequirePatterns();
            if (init) {
                ret.Name = "新しい人員配置";
            }
            return ret;
        }
		/// <summary>人員配置の削除
        /// </summary>
		public virtual void  DelRequirePatterns(BRequirePatterns requirepatterns) {
			requirepatterns.SetAvailable(false);
			if (requirepatterns.Removed != null) {
				availables.Remove(requirepatterns);
                if (TimeTable != null) {
                    TimeTable.NotifyRequirePatternssEdited(EnumTimeTableElementEventTypes.ElementRemoved, requirepatterns);
                }
			}
		}
		/// <summary>人員配置の削除
        /// </summary>
		public virtual void  DelRequirePatterns(BRequirePatterns requirepatterns, bool complete) {
			if (!complete) {
				DelRequirePatterns(requirepatterns);
			} else {
				if (requirepatterns.Removed != null) {
					int sz = parent.Size();
					for (int i = 0; i < sz; i++) {
						BRequirePatterns work = parent[i].Require;
						if (work != null && work.Equals(requirepatterns)) {
							parent[i].Require = null;
						}
					}
                    allrequires.Remove(requirepatterns);
                    if (TimeTable != null) {
                        TimeTable.NotifyRequirePatternssEdited(EnumTimeTableElementEventTypes.ElementRemovedForce, requirepatterns);
                    }
				}
			}
		}
		/// <summary>日付を指定して人員配置の削除
        /// </summary>
		public virtual void  DelRequirePatterns(BRequirePatterns requirepatterns, System.DateTime remove) {
			requirepatterns.SetAvailable(false, remove);
			if (requirepatterns.Removed != null) {
				availables.Remove(requirepatterns);
			}
		}
		/// <summary>人員配置の取得 有効な人員配置のうちn番目の有効人数
        /// </summary>
		private BRequirePatterns Get_Renamed(int n) {
			return availables[n];
		}
		/// <summary>人員配置の取得 有効な人員配置のうちn番目の有効人数
        /// </summary>
		private BRequirePatterns Get_Renamed(int n, bool force) {
			if (!force) {
				return Get_Renamed(n);
			}
			return allrequires[n];
		}
		/// <summary>IDを指定した人員配置の取得 IDを指定して有効・無効にかかわらず人員配置を取得します
        /// </summary>
		public virtual BRequirePatterns GetByID(long n) {
            // ビルトインのもの
            if (n == BRequirePatterns.NULL.ObjectID) return BRequirePatterns.NULL;
            if (n == BRequirePatterns.DAYOFF.ObjectID) return BRequirePatterns.DAYOFF;
            // ここから検索
			BRequirePatterns work = new BRequirePatterns(TimeTable.Patterns, this);
			work.ObjectID = n;
			int i = allrequires.BinarySearch(work);
            if (i < 0) {
                return BRequirePatterns.NULL;
            }
			return allrequires[i];
		}
        /// <summary>IDを指定した人員配置の取得 IDを指定して有効・無効にかかわらず人員配置を取得します
        /// </summary>
        public virtual BRequirePatterns GetByIDorNull (long n) {
            // ここから検索
            BRequirePatterns work = new BRequirePatterns(TimeTable.Patterns, this);
            work.ObjectID = n;
            int i = allrequires.BinarySearch(work);
            return (i >= 0 ? allrequires[i] : null);
        }
		/// <summary>人員配置の復活
        /// </summary>
		public virtual void  RescueRequirePatterns(BRequirePatterns requirepatterns) {
			if (requirepatterns.Removed != null) {
				requirepatterns.SetAvailable(true);
				//UPGRADE_TODO: .NET で メソッド 'java.util.List.add' に相当するメンバは、異なる値を返す可能性があります。 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				availables.Add(requirepatterns);
			}
		}
		/// <summary>このコレクションのサイズ
        /// </summary>
		public virtual int Size() {
			return availables.Count;
		}
		/// <summary>このコレクションのサイズ
        /// </summary>
		public virtual int Size(bool force) {
			if (!force) {
				return Size();
			}
			return allrequires.Count;
		}
		/// <summary>人員配置
		/// </summary>
		public BRequirePatterns this[int i] {
			get {
				return this.Get_Renamed(i);
			}
		}
		/// <summary>人員配置
		/// </summary>
		public BRequirePatterns this[int i, bool force] {
			get {
				return this.Get_Renamed(i, force);
			}
		}
		/// <summary>人員配置
		/// </summary>
		public BRequirePatterns GetByName(string name) {
			BRequirePatterns ret = null;
			for (int i = 0; i < Size(true); i++) {
				if (this[i, true].Name == name) {
					ret = this[i, true];
					break;
				}
			}
			return ret;
		}
	}
}