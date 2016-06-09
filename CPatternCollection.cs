using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;

namespace TimeTableManager.ElementCollection {
    /// <summary>パターンの一覧
    /// </summary>
	public class CPatternCollection:CAbstractElement {
		/// <summary>スケジュール全て 
        /// </summary>
		override public CTimeTable TimeTable {
			get {
				return parent;
			}
			
		}
		/// <summary>有効なシフト 
        /// </summary>
        private List<CPattern> availables;
		/// <summary>スケジュール 
        /// </summary>
		private CTimeTable parent;
		/// <summary>すべてのシフト 
        /// </summary>
		private List<CPattern> patterns; // = new Vector();
		/// <summary>勤務シフトコレクションの作成
		/// </summary>
		public CPatternCollection(CTimeTable parent):base() {
			this.parent = parent;
			availables = new List<CPattern>();
			patterns = new List<CPattern>();
            // ビルトインの追加
            AddPattern(CPattern.NULL);
            AddPattern(CPattern.DAYOFF);
            //AddPattern(Pattern.Multi);
		}
        /// <summary>勤務シフトの追加
        /// </summary>
        /// <param name="pattern"></param>
		public virtual void  AddPattern(CPattern pattern) {
            // 存在した場合はIDを再交付
            while (GetByIDorNull(pattern.ObjectID) != null && TimeTable != null) {
                pattern.ObjectID = NextID;
            }
            // 追加本番
			patterns.Add(pattern);
			patterns.Sort();
			if (pattern.Removed == null) {
				availables.Add(pattern);
				availables.Sort();
			}
            // イベント発生
            if (TimeTable != null) {
                TimeTable.NotifyPatternsEdited(EnumTimeTableElementEventTypes.ElementAdded, pattern);
            }
		}
        /// <summary>勤務シフトの作成
        /// </summary>
        /// <returns></returns>
		public virtual CPattern CreatePattern() {
			return new CPattern(this);
		}
        /// <summary>勤務シフトの作成
        /// </summary>
        /// <returns></returns>
        public virtual CPattern CreatePattern(bool init) {
            CPattern ret = new CPattern(this);
            if (init) {
                ret.Name = "新しいシフト";
                ret.Start = TimeTable.StartTime;
                ret.Scope = TimeTable.Around;
                ret.Rest = TimeSpan.FromHours(1.0);
            }
            return ret;
        }
        /// <summary>勤務シフトの削除
        /// </summary>
        /// <param name="pattern">削除するシフト</param>
		public virtual void  DelPattern(CPattern pattern) {
			pattern.SetAvailable(false);
			if (pattern.Removed != null) {
				availables.Remove(pattern);
				// 人員配置から削除
				CRequirePatternsCollection requires = parent.Requires;
				for (int i = 0; i < requires.Size(true); i++) {
					CRequirePatterns require = requires[i, true];
					require.SetRequire(pattern, 0);
				}
				// メンバーから削除
				CMemberCollection members = parent.Members;
				for (int i = 0; i < members.Size(true); i++) {
					CMember member = members[i, true];
					member.RemovePattern(pattern);
				}
                // イベント発生
                if (TimeTable != null) {
                    TimeTable.NotifyPatternsEdited(EnumTimeTableElementEventTypes.ElementRemoved, pattern);
                }
			}
		}
        /// <summary>勤務シフトの完全削除
        /// </summary>
        /// <param name="pattern">削除するシフト</param>
        /// <param name="complete">完全に削除するかどうか</param>
		public virtual void  DelPattern(CPattern pattern, bool complete) {
			if (!complete) {
				DelPattern(pattern);
			} else {
                // 完全に削除する
				if (pattern.Removed != null) {
                    patterns.Remove(pattern);
					// スケジュールから削除
					int sz = parent.Size();
					for (int i = 0; i < sz; i++) {
						CScheduledDate wkDate = parent[i];
						int sz2 = wkDate.ValidMemberSize;
						for (int j = 0; j < sz2; j++) {
							CSchedule scd = wkDate[j];
							if (scd != null) {
								CPattern pat = scd.Pattern;
								if (pat != null && pat.Equals(pattern)) {
									scd.Pattern = CPattern.NULL;
								}
							}
						}
					}
                    if (TimeTable != null) {
                        TimeTable.NotifyPatternsEdited(EnumTimeTableElementEventTypes.ElementRemovedForce, pattern);
                    }
				}
			}
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
		private CPattern GetPattern(int n) {
			return (CPattern) availables[n];
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="n"></param>
        /// <param name="force"></param>
        /// <returns></returns>
		private CPattern GetPattern(int n, bool force) {
			if (force)
				return patterns[n];
			return GetPattern(n);
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
		public virtual CPattern GetByID(long n) {
            // ビルトインのもの
            if (n == CPattern.NULL.ObjectID) return CPattern.NULL;
            if (n == CPattern.DAYOFF.ObjectID) return CPattern.DAYOFF;
            if (n == CPattern.MULTI.ObjectID) return CPattern.MULTI;
            // 検索する
			CPattern work = new CPattern(this);
			work.ObjectID = n;
			int i = patterns.BinarySearch(work);
            if (i < 0) {
                return CPattern.NULL;
            }
			return patterns[i];
		}
        /// <summary>勤務シフトの取得（なかったらヌル）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private CPattern GetByIDorNull (long n) {
            // 検索する
            CPattern work = new CPattern(this);
            work.ObjectID = n;
            int i = patterns.BinarySearch(work);
            return (i >= 0 ? patterns[i] : null);
        }
        /// <summary>勤務シフトの復活
        /// </summary>
        /// <param name="pattern"></param>
		public virtual void  RescuePattern(CPattern pattern) {
			if (pattern.Removed != null) {
				pattern.SetAvailable(true);
				availables.Add(pattern);
				availables.Sort();
                parent.NotifyPatternsEdited(EnumTimeTableElementEventTypes.ElementRescued, pattern);
			}
		}
		/// <summary>有効なシフトの数</summary>
		public virtual int Size() {
			return availables.Count;
		}
		/// <summary>有効/無効なシフトの数</summary>
		public virtual int Size(bool force) {
			if (force)
				return patterns.Count;
			return Size();
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
		public CPattern this[int i] {
			get {
				return GetPattern(i);
			}
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="i"></param>
        /// <param name="force"></param>
        /// <returns></returns>
		public CPattern this[int i, bool force] {
			get {
				return GetPattern(i, force);
			}
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		public CPattern GetByName (string name) {
			CPattern ret = null;
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