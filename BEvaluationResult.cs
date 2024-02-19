using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Element;

namespace TimeTableManager.Evaluation {
    /// <summary>
    /// 評価結果
    /// </summary>
    public enum EEvaluationResult {
        /// <summary>問題なし</summary>
        OK,
        /// <summary>注意</summary>
        NOTICE,
        /// <summary>警告</summary>
        WORNING,
        /// <summary>エラー</summary>
        ERROR
    }
    /// <summary>
    /// 評価内容
    /// </summary>
    public class BEvaluationItem: IComparable {
        private static long currentid = 0;
        /// <summary>次のIDを発布する
        /// </summary>
        public static long NextID {
            get {
                if (currentid == long.MaxValue) currentid = 0;
                return ++currentid;
            }
        }
        private readonly long id;
        private readonly EEvaluationResult result;
        private readonly BScheduledDate sdate;
        private readonly string message;
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="Result">評価結果</param>
        /// <param name="Date">日付</param>
        /// <param name="Message">メッセージ</param>
        public BEvaluationItem (EEvaluationResult Result, BScheduledDate Date, string Message) {
            id = BEvaluationItem.NextID;
            result = Result;
            sdate = Date;
            message = Message;
        }
        /// <summary>ID
        /// </summary>
        public long Id {
            get {
                return id;
            }
        }
        /// <summary>評価結果
        /// </summary>
        public EEvaluationResult Result {
            get {
                return result;
            }
        }
        /// <summary>日付
        /// </summary>
        public BScheduledDate Date {
            get {
                return sdate;
            }
        }
        /// <summary>メッセージ
        /// </summary>
        public string Message {
            get {
                return message;
            }
        }


        #region IComparable メンバ
        int IComparable.CompareTo (object obj) {
            if (obj is BEvaluationItem) {
                BEvaluationItem item = (BEvaluationItem)obj;
                if (item.Id > Id) {
                    return 1;
                } else if (item.Id < Id) {
                    return -1;
                } else {
                    return 0;
                }
            }
            return 0;
        }
        #endregion
    }
}
