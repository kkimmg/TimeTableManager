using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;

namespace TimeTableManager.ElementCollection {
    /// <summary>パターンの一覧
    /// </summary>
	public class BPatternCollection:BAbstractElement {
		/// <summary>スケジュール全て 
        /// </summary>
		override public BTimeTable TimeTable {
			get {
				return parent;
			}
			
		}
		/// <summary>有効なシフト 
        /// </summary>
        private List<BPattern> availables;
		/// <summary>スケジュール 
        /// </summary>
		private BTimeTable parent;
		/// <summary>すべてのシフト 
        /// </summary>
		private List<BPattern> patterns; // = new Vector();
		/// <summary>勤務シフトコレクションの作成
		/// </summary>
		public BPatternCollection(BTimeTable parent):base() {
			this.parent = parent;
			availables = new List<BPattern>();
			patterns = new List<BPattern>();
            // ビルトインの追加
            AddPattern(BPattern.NULL);
            AddPattern(BPattern.DAYOFF);
            //AddPattern(Pattern.Multi);
		}
        /// <summary>勤務シフトの追加
        /// </summary>
        /// <param name="pattern"></param>
		public virtual void  AddPattern(BPattern pattern) {
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
		public virtual BPattern CreatePattern() {
			return new BPattern(this);
		}
        /// <summary>勤務シフトの作成
        /// </summary>
        /// <returns></returns>
        public virtual BPattern CreatePattern(bool init) {
            BPattern ret = new BPattern(this);
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
		public virtual void  DelPattern(BPattern pattern) {
			pattern.SetAvailable(false);
			if (pattern.Removed != null) {
				availables.Remove(pattern);
				// 人員配置から削除
				BRequirePatternsCollection requires = parent.Requires;
				for (int i = 0; i < requires.Size(true); i++) {
					BRequirePatterns require = requires[i, true];
					require.SetRequire(pattern, 0);
				}
				// メンバーから削除
				BMemberCollection members = parent.Members;
				for (int i = 0; i < members.Size(true); i++) {
					BMember member = members[i, true];
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
		public virtual void  DelPattern(BPattern pattern, bool complete) {
			if (!complete) {
				DelPattern(pattern);
			} else {
                // 完全に削除する
				if (pattern.Removed != null) {
                    patterns.Remove(pattern);
					// スケジュールから削除
					int sz = parent.Size();
					for (int i = 0; i < sz; i++) {
						BScheduledDate wkDate = parent[i];
						int sz2 = wkDate.ValidMemberSize;
						for (int j = 0; j < sz2; j++) {
							BSchedule scd = wkDate[j];
							if (scd != null) {
								BPattern pat = scd.Pattern;
								if (pat != null && pat.Equals(pattern)) {
									scd.Pattern = BPattern.NULL;
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
		private BPattern GetPattern(int n) {
			return (BPattern) availables[n];
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="n"></param>
        /// <param name="force"></param>
        /// <returns></returns>
		private BPattern GetPattern(int n, bool force) {
			if (force)
				return patterns[n];
			return GetPattern(n);
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
		public virtual BPattern GetByID(long n) {
            // ビルトインのもの
            if (n == BPattern.NULL.ObjectID) return BPattern.NULL;
            if (n == BPattern.DAYOFF.ObjectID) return BPattern.DAYOFF;
            if (n == BPattern.MULTI.ObjectID) return BPattern.MULTI;
            // 検索する
			BPattern work = new BPattern(this);
			work.ObjectID = n;
			int i = patterns.BinarySearch(work);
            if (i < 0) {
                return BPattern.NULL;
            }
			return patterns[i];
		}
        /// <summary>勤務シフトの取得（なかったらヌル）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private BPattern GetByIDorNull (long n) {
            // 検索する
            BPattern work = new BPattern(this);
            work.ObjectID = n;
            int i = patterns.BinarySearch(work);
            return (i >= 0 ? patterns[i] : null);
        }
        /// <summary>勤務シフトの復活
        /// </summary>
        /// <param name="pattern"></param>
		public virtual void  RescuePattern(BPattern pattern) {
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
		public BPattern this[int i] {
			get {
				return GetPattern(i);
			}
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="i"></param>
        /// <param name="force"></param>
        /// <returns></returns>
		public BPattern this[int i, bool force] {
			get {
				return GetPattern(i, force);
			}
		}
        /// <summary>勤務シフトの取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		public BPattern GetByName (string name) {
			BPattern ret = null;
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