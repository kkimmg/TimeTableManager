using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Element;

namespace TimeTableManager.Printing {
    /// <summary>ページインデックス
    /// </summary>
    public class BPageIndex {
        #region プライベート
        /// <summary>プレビューの終了日</summary>
        private DateTime end;
        /// <summary>プレビューの開始日</summary>
        private DateTime start;
        /// <summary>開始メンバー</summary>
        private int memberStartIndex;
        /// <summary>終了メンバー</summary>
        private int memberEndIndex;
        /// <summary>
        /// 有効なメンバーの一覧
        /// </summary>
        private List<BMember> members = new List<BMember>();
        /// <summary>
        /// ドキュメント
        /// </summary>
        private BPrintDocumentBody document;
        /// <summary>
        /// 次のページ
        /// </summary>
        private Boolean hasMorePage = false;
        #endregion
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public BPageIndex () {
        }
        /// <summary>
        /// ページを計算する
        /// </summary>
        /// <returns></returns>
        public Boolean CalcPage () {
            Boolean ret = false;
            // 日付によるインデックス
            TimeSpan Span = document.End - start;
            int Days = Span.Days;
            if (document.MaxDates == 0) {
                end = document.End;
            } else if (Days < document.MaxDates) {
                end = document.End;
            } else {
                TimeSpan work = new TimeSpan(document.MaxDates, 0, 0, 0);
                end = start + work;
                ret = true;
            }
            if (document.Monthly) {
                if (start.Year < end.Year || start.Month < end.Month) {
                    int day = DateTime.DaysInMonth(start.Year, start.Month);
                    end = new DateTime(start.Year, start.Month, day);
                    ret = true;
                }
            }
            // メンバーによるインデックス
            //int work = 0;
            int work1 = document.GetMemberCount();
            int work2 = document.MaxMember;
            if (work2 == 0) {
                // 列数制限なし
                memberEndIndex = work1 - 1;
            } else if (work1 <= work2) {
                // 列数は制限を超える
                memberEndIndex = work1 - 1;
            } else {
                // 列数が制限以内
                memberEndIndex = work2 - 1 + memberStartIndex;//work1 - work2 - 1 + memberStartIndex;
                if (memberEndIndex < work1 - 1) {
                    // メンバー数は最大に達していない
                    ret = true;
                } else {
                    // メンバー数は最大に達した
                    memberEndIndex = work1 - 1;
                }
            }
            for (int i = memberStartIndex; i <= memberEndIndex; i++) {
                // のこり（かもしれない）メンバーを追加する
                members.Add(document.GetMember(i));
            }
            // 終了
            hasMorePage = ret;
            return ret;
        }
        /// <summary>
        /// メンバーの取得
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public BMember GetMember (int i) {
            return members[i];
        }
        /// <summary>
        /// メンバー数
        /// </summary>
        /// <returns></returns>
        public int MemberCount {
            get {
                return members.Count;
            }
        }
        /// <summary>
        /// 日数
        /// </summary>
        public int DateCount {
            get {
                TimeSpan span = End - Start;
                return span.Days + 1;
            }
        }
        /// <summary>プレビューの開始日</summary>
        public DateTime Start {
            get { return start; }
            set { start = value; }
        }
        /// <summary>プレビューの終了日</summary>
        public DateTime End {
            get { return end; }
            set { end = value; }
        }
        /// <summary>開始メンバー</summary>
        public int MemberStartIndex {
            get { return memberStartIndex; }
            set { memberStartIndex = value; }
        }
        /// <summary>終了メンバー</summary>
        public int MemberEndIndex {
            get { return memberEndIndex; }
            set { memberEndIndex = value; }
        }
        /// <summary>
        /// ドキュメント
        /// </summary>
        public BPrintDocumentBody Document {
            get { return document; }
            set { document = value; }
        }
        /// <summary>
        /// 次のページ
        /// </summary>
        public Boolean HasMorePage {
            get { return hasMorePage; }
        }
    }
}
