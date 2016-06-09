using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;
namespace TimeTableManager.ElementCollection {
    /// <summary>
    /// 優先順位によるソート発生器
    /// </summary>
    class CPriorityComparer : IComparer<CMember> {
        #region IComparer メンバ

        public int Compare (CMember x, CMember y) {
            CMember member1 = x as CMember;
            CMember member2 = y as CMember;
            return member1.Priority - member2.Priority;
        }

        #endregion
    }
    /// <summary>メンバーの一覧
    /// </summary>
    public class CMemberCollection : CAbstractElement {
        /// <summary>リフレッシュの多重処理防止
        /// </summary>
        private bool InRefresh = false;
        /// <summary>スケジュール全て 
        /// </summary>
        override public CTimeTable TimeTable {
            get {
                return parent;
            }

        }
        /// <summary>現在有効なメンバー（優先順位順） 
        /// </summary>
        private List<CMember> availables;
        /// <summary>すべてのメンバー（キー順） 
        /// </summary>
        private List<CMember> members;
        /// <summary>スケジュール </summary>
        private CTimeTable parent;
        /// <summary>すべてのメンバー（優先順位順） 
        /// </summary>
        private List<CMember> priorities;
        /// <summary>メンバーコレクション
        /// </summary>
        /// <param name="parent">スケジュール</param>
        public CMemberCollection (CTimeTable parent)
            : base() {
            this.parent = parent;
            members = new List<CMember>();
            availables = new List<CMember>();
            priorities = new List<CMember>();
        }
        /// <summary>メンバーの追加
        /// </summary>
        /// <param name="member">追加するメンバー</param>
        public virtual void AddMember (CMember member) {
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
                priorities.Sort(new CPriorityComparer());
                availables.Sort(new CPriorityComparer());
                InRefresh = false;
            }
        }
        /// <summary>優先順位の再設定
        /// </summary>
        public void RefreshPriority () {
            Refresh();
            InRefresh = true;
            for (int i = 0; i < priorities.Count; i++) {
                CMember member = priorities[i];
                member.Priority = i + 1;
            }
            InRefresh = false;
            Refresh();
        }
        /// <summary>メンバーの作成
        /// </summary>
        /// <returns>新しいメンバー</returns>
        public virtual CMember CreateMember () {
            return new CMember(this);
        }
        /// <summary>メンバーの作成（初期化機能つき）
        /// </summary>
        /// <returns>新しいメンバー</returns>
        public virtual CMember CreateMember (bool init) {
            CMember ret = CreateMember();
            if (init) {
                ret.Name = "新しいメンバー";
                int size = TimeTable.Patterns.Size(true);
                for (int i = 0; i < size; i++) {
                    CPattern pattern = TimeTable.Patterns[i, true];
                    if (pattern.Removed == null && !pattern.BuiltIn) {
                        ret.AddPattern(pattern);
                    }
                }
                ret.SetAvailableDay(CTimeTable.tMonday, true);
                ret.SetAvailableDay(CTimeTable.tTuesday, true);
                ret.SetAvailableDay(CTimeTable.tWednesday, true);
                ret.SetAvailableDay(CTimeTable.tThursday, true);
                ret.SetAvailableDay(CTimeTable.tFriday, true);
                ret.SetAvailableDay(CTimeTable.tSaturday, true);
                ret.SetAvailableDay(CTimeTable.tSunday, true);
                ret.Priority = GetLastPriority(true) + 1; ;
            }
            return ret;
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="member">削除するメンバー</param>
        public virtual void DelMember (CMember member) {
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
        public virtual void DelMember (CMember member, bool complete) {
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
                        CScheduledDate sdate = parent[i];
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
        private CMember GetMember (int n) {
            return availables[n];
        }
        /// <summary>メンバーの取得
        /// </summary>
        /// <param name="n">n番目のメンバー</param>
        /// <param name="force">削除されたものも含む</param>
        /// <returns>メンバー</returns>
        private CMember GetMember (int n, bool force) {
            CMember ret = null;
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
        public virtual CMember GetByID (long n) {
            CMember work = new CMember(this, n);
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
                    ret = ((CMember)priorities[sz]).Priority;
                }
            } else {
                int sz = availables.Count - 1;
                if (sz >= 0) {
                    ret = ((CMember)availables[sz]).Priority;
                }
            }
            return ret;
        }
        /// <summary>メンバーの復活
        /// </summary>
        /// <param name="member">復活するメンバー</param>
        public virtual void RescueMember (CMember member) {
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
        public CMember this[int i] {
            get {
                return GetMember(i);
            }
        }
        /// <summary>メンバーの取得
        /// </summary>
        /// <param name="i">i番目</param>
        /// <param name="force">削除済みのアイテムを含む</param>
        /// <returns></returns>
        public CMember this[int i, bool force] {
            get {
                return GetMember(i, force);
            }
        }
        /// <summary>名前から取得する
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CMember GetByName (string name) {
            CMember ret = null;
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