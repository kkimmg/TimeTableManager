using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;
namespace TimeTableManager.ElementCollection {
    /// <summary>人員配置の一覧
    /// </summary>
	public class CRequirePatternsCollection:CAbstractElement {
		/// <summary>スケジュール全て 
        /// </summary>
		override public CTimeTable TimeTable {
			get {
				return parent;
			}
			
		}
		/// <summary>すべての人員配置 
        /// </summary>
		private List<CRequirePatterns> allrequires;
		/// <summary>有効な人員配置 
        /// </summary>
        private List<CRequirePatterns> availables;
		/// <summary>スケジュールすべて 
        /// </summary>
		private CTimeTable parent;
		/// <summary>有効な人数のコレクション
        /// </summary>
		public CRequirePatternsCollection(CTimeTable parent):base() {
			this.parent = parent;
            availables = new List<CRequirePatterns>();
            allrequires = new List<CRequirePatterns>();
            // ビルトインの追加
            AddRequirePatterns(CRequirePatterns.NULL);
            AddRequirePatterns(CRequirePatterns.DAYOFF);
		}
		/// <summary>人員配置の追加
        /// </summary>
		public virtual void  AddRequirePatterns(CRequirePatterns AddingValue) {
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
		public virtual CRequirePatterns CreateRequirePatterns() {
			CRequirePatterns ret = new CRequirePatterns(TimeTable.Patterns, this);
			return ret;
		}
        /// <summary>人員配置の作成
        /// </summary>
        public virtual CRequirePatterns CreateRequirePatterns(bool init) {
            CRequirePatterns ret = CreateRequirePatterns();
            if (init) {
                ret.Name = "新しい人員配置";
            }
            return ret;
        }
		/// <summary>人員配置の削除
        /// </summary>
		public virtual void  DelRequirePatterns(CRequirePatterns requirepatterns) {
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
		public virtual void  DelRequirePatterns(CRequirePatterns requirepatterns, bool complete) {
			if (!complete) {
				DelRequirePatterns(requirepatterns);
			} else {
				if (requirepatterns.Removed != null) {
					int sz = parent.Size();
					for (int i = 0; i < sz; i++) {
						CRequirePatterns work = parent[i].Require;
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
		public virtual void  DelRequirePatterns(CRequirePatterns requirepatterns, System.DateTime remove) {
			requirepatterns.SetAvailable(false, remove);
			if (requirepatterns.Removed != null) {
				availables.Remove(requirepatterns);
			}
		}
		/// <summary>人員配置の取得 有効な人員配置のうちn番目の有効人数
        /// </summary>
		private CRequirePatterns Get_Renamed(int n) {
			return availables[n];
		}
		/// <summary>人員配置の取得 有効な人員配置のうちn番目の有効人数
        /// </summary>
		private CRequirePatterns Get_Renamed(int n, bool force) {
			if (!force) {
				return Get_Renamed(n);
			}
			return allrequires[n];
		}
		/// <summary>IDを指定した人員配置の取得 IDを指定して有効・無効にかかわらず人員配置を取得します
        /// </summary>
		public virtual CRequirePatterns GetByID(long n) {
            // ビルトインのもの
            if (n == CRequirePatterns.NULL.ObjectID) return CRequirePatterns.NULL;
            if (n == CRequirePatterns.DAYOFF.ObjectID) return CRequirePatterns.DAYOFF;
            // ここから検索
			CRequirePatterns work = new CRequirePatterns(TimeTable.Patterns, this);
			work.ObjectID = n;
			int i = allrequires.BinarySearch(work);
            if (i < 0) {
                return CRequirePatterns.NULL;
            }
			return allrequires[i];
		}
        /// <summary>IDを指定した人員配置の取得 IDを指定して有効・無効にかかわらず人員配置を取得します
        /// </summary>
        public virtual CRequirePatterns GetByIDorNull (long n) {
            // ここから検索
            CRequirePatterns work = new CRequirePatterns(TimeTable.Patterns, this);
            work.ObjectID = n;
            int i = allrequires.BinarySearch(work);
            return (i >= 0 ? allrequires[i] : null);
        }
		/// <summary>人員配置の復活
        /// </summary>
		public virtual void  RescueRequirePatterns(CRequirePatterns requirepatterns) {
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
		public CRequirePatterns this[int i] {
			get {
				return this.Get_Renamed(i);
			}
		}
		/// <summary>人員配置
		/// </summary>
		public CRequirePatterns this[int i, bool force] {
			get {
				return this.Get_Renamed(i, force);
			}
		}
		/// <summary>人員配置
		/// </summary>
		public CRequirePatterns GetByName(string name) {
			CRequirePatterns ret = null;
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