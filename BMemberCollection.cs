using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;
namespace TimeTableManager.ElementCollection {
    /// <summary>
    /// 優先順位によるソート発生器
    /// </summary>
    class BPriorityComparer : IComparer<BMember> {
        #region IComparer メンバ

        public int Compare (BMember x, BMember y) {
            BMember member1 = x as BMember;
            BMember member2 = y as BMember;
            return member1.Priority - member2.Priority;
        }

        #endregion
    }
    /// <summary>メンバーの一覧
    /// </summary>
    public class BMemberCollection : BAbstractElement {
        /// <summary>リフレッシュの多重処理防止
        /// </summary>
        private bool InRefresh = false;
        /// <summary>スケジュール全て 
        /// </summary>
        override public BTimeTable TimeTable {
            get {
                return parent;
            }

        }
        /// <summary>現在有効なメンバー（優先順位順） 
        /// </summary>
        private List<BMember> availables;
        /// <summary>すべてのメンバー（キー順） 
        /// </summary>
        private List<BMember> members;
        /// <summary>スケジュール </summary>
        private BTimeTable parent;
        /// <summary>すべてのメンバー（優先順位順） 
        /// </summary>
        private List<BMember> priorities;
        /// <summary>メンバーコレクション
        /// </summary>
        /// <param name="parent">スケジュール</param>
        public BMemberCollection (BTimeTable parent)
            : base() {
            this.parent = parent;
            members = new List<BMember>();
            availables = new List<BMember>();
            priorities = new List<BMember>();
        }
        /// <summary>メンバーの追加
        /// </summary>
        /// <param name="member">追加するメンバー</param>
        public virtual void AddMember (BMember member) {
            // メンバーIDがすでに交付済みならIDを変更する
            while (GetByID(member.ObjectID) != null && TimeTable != null) {
                member.ObjectID = NextID;
            }
            // 追加本番
            members.Add(member);
            priorities.Add(member);
            if (member.Removed == null) {
                availables.Add(member);
            }
            Refresh();
            // イベント発生
            if (TimeTable != null) {
                TimeTable.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementAdded, member);
            }
        }
        /// <summary>内部コレクションの再ソート
        /// </summary>
        public void Refresh () {
            if (!InRefresh) {
                InRefresh = true;
                members.Sort();
                priorities.Sort(new BPriorityComparer());
                availables.Sort(new BPriorityComparer());
                InRefresh = false;
            }
        }
        /// <summary>優先順位の再設定
        /// </summary>
        public void RefreshPriority () {
            Refresh();
            InRefresh = true;
            for (int i = 0; i < priorities.Count; i++) {
                BMember member = priorities[i];
                member.Priority = i + 1;
            }
            InRefresh = false;
            Refresh();
        }
        /// <summary>メンバーの作成
        /// </summary>
        /// <returns>新しいメンバー</returns>
        public virtual BMember CreateMember () {
            return new BMember(this);
        }
        /// <summary>メンバーの作成（初期化機能つき）
        /// </summary>
        /// <returns>新しいメンバー</returns>
        public virtual BMember CreateMember (bool init) {
            BMember ret = CreateMember();
            if (init) {
                ret.Name = "新しいメンバー";
                int size = TimeTable.Patterns.Size(true);
                for (int i = 0; i < size; i++) {
                    BPattern pattern = TimeTable.Patterns[i, true];
                    if (pattern.Removed == null && !pattern.BuiltIn) {
                        ret.AddPattern(pattern);
                    }
                }
                ret.SetAvailableDay(BTimeTable.tMonday, true);
                ret.SetAvailableDay(BTimeTable.tTuesday, true);
                ret.SetAvailableDay(BTimeTable.tWednesday, true);
                ret.SetAvailableDay(BTimeTable.tThursday, true);
                ret.SetAvailableDay(BTimeTable.tFriday, true);
                ret.SetAvailableDay(BTimeTable.tSaturday, true);
                ret.SetAvailableDay(BTimeTable.tSunday, true);
                ret.Priority = GetLastPriority(true) + 1; ;
            }
            return ret;
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="member">削除するメンバー</param>
        public virtual void DelMember (BMember member) {
            member.SetAvailable(false);
            availables.Remove(member);
            if (TimeTable != null) {
                TimeTable.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementRemoved, member);
            }
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="member">削除するメンバー</param>
        /// <param name="complete">完全削除かどうか</param>
        public virtual void DelMember (BMember member, bool complete) {
            if (!complete) {
                // 削除
                DelMember(member);
            } else {
                if (member.Removed != null) {
                    members.Remove(member);
                    //System.out.println("完全削除１：" + member.getName());
                    // 完全削除
                    int sz = parent.Size();
                    for (int i = 0; i < sz; i++) {
                        //System.out.println("完全削除２：" + member.getName());
                        BScheduledDate sdate = parent[i];
                        sdate.MakeMembers();
                    }
                    if (TimeTable != null) {
                        TimeTable.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementRemoved, member);
                    }
                } else {
                    DelMember(member, false);
                }
            }
            Refresh();
        }
        /// <summary>メンバーの取得
        /// </summary>
        /// <param name="n">n番目のメンバー</param>
        /// <returns>メンバー</returns>
        private BMember GetMember (int n) {
            return availables[n];
        }
        /// <summary>メンバーの取得
        /// </summary>
        /// <param name="n">n番目のメンバー</param>
        /// <param name="force">削除されたものも含む</param>
        /// <returns>メンバー</returns>
        private BMember GetMember (int n, bool force) {
            BMember ret = null;
            if (force) {
                ret = priorities[n];
            } else {
                ret = GetMember(n);
            }
            return ret;
        }
        /// <summary>メンバーの取得（IDによる）
        /// </summary>
        /// <param name="n">メンバーのObjectID</param>
        /// <returns>メンバー</returns>
        public virtual BMember GetByID (long n) {
            BMember work = new BMember(this, n);
            int id = members.BinarySearch(work);
            return (id >= 0 ? members[id] : null);
        }
        /// <summary>最後の優先順位
        /// </summary>
        /// <returns>最後の優先順位</returns>
        public virtual int GetLastPriority () {
            return GetLastPriority(false);
        }
        /// <summary>最後の優先順位
        /// </summary>
        /// <returns>最後の優先順位</returns>
        public virtual int GetLastPriority (bool force) {
            int ret = 0;
            if (force) {
                int sz = priorities.Count - 1;
                if (sz >= 0) {
                    ret = ((BMember)priorities[sz]).Priority;
                }
            } else {
                int sz = availables.Count - 1;
                if (sz >= 0) {
                    ret = ((BMember)availables[sz]).Priority;
                }
            }
            return ret;
        }
        /// <summary>メンバーの復活
        /// </summary>
        /// <param name="member">復活するメンバー</param>
        public virtual void RescueMember (BMember member) {
            member.SetAvailable(true);
            availables.Add(member);
            Refresh();
            parent.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementRescued, member);
        }
        /// <summary>メンバー数（有効なもののみ）
        /// </summary>
        /// <returns></returns>
        public virtual int Size () {
            return availables.Count;
        }
        /// <summary>メンバー数
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        public virtual int Size (bool force) {
            if (force)
                return members.Count;
            return Size();
        }
        /// <summary>メンバーの取得
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public BMember this[int i] {
            get {
                return GetMember(i);
            }
        }
        /// <summary>メンバーの取得
        /// </summary>
        /// <param name="i">i番目</param>
        /// <param name="force">削除済みのアイテムを含む</param>
        /// <returns></returns>
        public BMember this[int i, bool force] {
            get {
                return GetMember(i, force);
            }
        }
        /// <summary>名前から取得する
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BMember GetByName (string name) {
            BMember ret = null;
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