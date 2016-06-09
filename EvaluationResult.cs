using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.Evaluation {
    /// <summary>
    /// 評価結果
    /// </summary>
    public enum EvaluationResult {
        OK,
        NOTICE,
        WARNING,
        ERROR
    }
    /// <summary>
    /// 評価内容
    /// </summary>
    public class CEvaluationItem: IComparable {
        private static long currentid = 0;
        public static long NextID {
            get {
                if (currentid == long.MaxValue) currentid = 0;
                return ++currentid;
            }
        }
        private readonly long id;
        private readonly EvaluationResult result;
        private readonly CScheduledDate sdate;
        private readonly string message;
        public CEvaluationItem (EvaluationResult Result, CScheduledDate Date, string Message) {
            id = CEvaluationItem.NextID;
            result = Result;
            sdate = Date;
            message = Message;
        }
        public long Id {
            get {
                return id;
            }
        }
        public EvaluationResult Result {
            get {
                return result;
            }
        }
        public CScheduledDate Date {
            get {
                return sdate;
            }
        }
        public string Message {
            get {
                return message;
            }
        }


        #region IComparable メンバ
        int IComparable.CompareTo (object obj) {
            if (obj is CEvaluationItem) {
                CEvaluationItem item = (CEvaluationItem)obj;
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
