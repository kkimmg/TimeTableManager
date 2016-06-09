using System;
using System.Xml;
using TimeTableManager.Element;

namespace TimeTableManager.IO {
    /// <summary>
    /// Domに保存する
    /// </summary>
    public class CSaver {
        /// <summary>日付の保存形式
        /// </summary>
        public const string DATEFORMAT = "yyyy/MM/dd";
        /// <summary>コンストラクタ
        /// </summary>
        public CSaver () {
            // 
            // TODO: コンストラクタ ロジックをここに追加してください。
            //
        }
        /// <summary>セーブメイン
        /// </summary>
        public void Save(string file, CTimeTable ret) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "", "yes");
            doc.InsertBefore(declaration, doc.DocumentElement);
            XmlElement rNode = doc.CreateElement("scheduleall");
            doc.AppendChild(rNode);
            // シフト
            rNode.AppendChild(SavePatterns(doc, ret));
            // メンバー
            rNode.AppendChild(SaveMembers(doc, ret));
            // 人員配置
            rNode.AppendChild(SaveRequirePatterns(doc, ret));
            // 休日
            rNode.AppendChild(SaveDayOffs(doc, ret));
            #region 営業開始時間
            XmlElement startNode = doc.CreateElement("starttime");
            startNode.InnerText = ret.StartTime.ToString();
            rNode.AppendChild(startNode);
            #endregion
            #region 営業終了時間
            XmlElement endNode = doc.CreateElement("endtime");
            endNode.InnerText = ret.EndTime.ToString();
            rNode.AppendChild(endNode);
            #endregion
            #region 営業時間
            XmlElement aroundNode = doc.CreateElement("around");
            aroundNode.InnerText = ret.Around.ToString();
            rNode.AppendChild(aroundNode);
            #endregion
            #region デフォルトの人員配置
            if (ret.DefaultRequire != null && ret.DefaultRequire != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("default_require");
                defaultNode.InnerText = ret.DefaultRequire.ObjectID.ToString();
                rNode.AppendChild(defaultNode);
            }
            #endregion
            #region デフォルトの人員配置（曜日ごと）
            CRequirePatterns work = null;
            work = ret.GetDefaultRequire(System.DayOfWeek.Monday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "0");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            work = ret.GetDefaultRequire(System.DayOfWeek.Tuesday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "1");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            work = ret.GetDefaultRequire(System.DayOfWeek.Wednesday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "2");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            work = ret.GetDefaultRequire(System.DayOfWeek.Thursday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "3");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            work = ret.GetDefaultRequire(System.DayOfWeek.Friday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "4");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            work = ret.GetDefaultRequire(System.DayOfWeek.Saturday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "5");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            work = ret.GetDefaultRequire(System.DayOfWeek.Sunday);
            if (work != null && work != CRequirePatterns.NULL) {
                XmlElement defaultNode = doc.CreateElement("defaultRequireweekday");
                defaultNode.SetAttribute("weekday", "6");
                defaultNode.SetAttribute("require", work.ObjectID.ToString());
                rNode.AppendChild(defaultNode);
            }
            #endregion
            #region 順番
            XmlElement seqNode = doc.CreateElement("sequence");
            seqNode.InnerText = ret.CurrentID.ToString();
            rNode.AppendChild(seqNode);
            #endregion
            #region 直下のプロパティ
            foreach (string key in ret) {
                XmlElement propelement = doc.CreateElement("property");
                propelement.SetAttribute("key", key);
                propelement.InnerText = ret[key];
                rNode.AppendChild(propelement);
            }
            #endregion
            // 日付
            SaveScheduledDate(doc, rNode, ret);
            ///////////////
            doc.Save(file);
        }
        /// <summary>勤務シフトのセーブ
        /// </summary>
        public XmlElement SavePatterns (XmlDocument doc, CTimeTable all) {
            XmlElement element = doc.CreateElement("patterns");
            SaveTmElement(doc, element, all.Patterns);
            for (int i = 0; i < all.Patterns.Size(true); i++) {
                CPattern pattern = all.Patterns[i, true];
                if (!pattern.BuiltIn) {
                    XmlElement pNode = doc.CreateElement("pattern");
                    SaveTmElement(doc, pNode, pattern);
                    pNode.SetAttribute("name", pattern.Name);
                    pNode.SetAttribute("start", pattern.Start.ToString());
                    pNode.SetAttribute("end", pattern.End.ToString());
                    pNode.SetAttribute("scope", pattern.Scope.ToString());
                    pNode.SetAttribute("rest", pattern.Rest.ToString());
                    element.AppendChild(pNode);
                }
            }
            return element;
        }
        /// <summary>休日のセーブ
        /// </summary>
        public XmlElement SaveDayOffs (XmlDocument doc, CTimeTable all) {
            XmlElement element = doc.CreateElement("dayoffs");
            SaveTmElement(doc, element, all.DayOffs);
            for (int i = 0; i < all.DayOffs.Size(); i++) {
                CDayOff dayoff = all.DayOffs[i];
                XmlElement pNode = doc.CreateElement("dayoff");
                SaveTmElement(doc, pNode, dayoff);
                pNode.SetAttribute("name", dayoff.Name);
                pNode.SetAttribute("start", dayoff.StartDate.ToString(CSaver.DATEFORMAT));
                pNode.SetAttribute("end", dayoff.EndDate.ToString(CSaver.DATEFORMAT));
                element.AppendChild(pNode);
            }
            return element;
        }
        /// <summary>メンバーのセーブ
        /// </summary>
        public XmlElement SaveMembers (XmlDocument doc, CTimeTable all) {
            XmlElement element = doc.CreateElement("members");
            SaveTmElement(doc, element, all.Members);
            for (int i = 0; i < all.Members.Size(true); i++) {
                CMember member = all.Members[i, true];
                XmlElement pNode = doc.CreateElement("member");
                SaveTmElement(doc, pNode, member);
                pNode.SetAttribute("name", member.Name);
                pNode.SetAttribute("chief", member.IsChief.ToString());
                pNode.SetAttribute("expectedwork", member.ExpectedWork.ToString());
                pNode.SetAttribute("expectedrest", member.ExpectedRest.ToString());
                pNode.SetAttribute("priority", member.Priority.ToString());
                //
                for (int j = 0; j < member.PatternSize; j++) {
                    CPattern pattern = member[j];
                    XmlElement nNode = doc.CreateElement("pattern");
                    nNode.SetAttribute("id", pattern.ObjectID.ToString());
                    pNode.AppendChild(nNode);
                }
                #region 稼働日
                pNode.SetAttribute("avl-monday", member.IsAvailableDay(CTimeTable.tMonday).ToString());
                pNode.SetAttribute("avl-tuesday", member.IsAvailableDay(CTimeTable.tTuesday).ToString());
                pNode.SetAttribute("avl-wednesday", member.IsAvailableDay(CTimeTable.tWednesday).ToString());
                pNode.SetAttribute("avl-thursday", member.IsAvailableDay(CTimeTable.tThursday).ToString());
                pNode.SetAttribute("avl-friday", member.IsAvailableDay(CTimeTable.tFriday).ToString());
                pNode.SetAttribute("avl-saturday", member.IsAvailableDay(CTimeTable.tSaturday).ToString());
                pNode.SetAttribute("avl-sunday", member.IsAvailableDay(CTimeTable.tSunday).ToString());
                #endregion
                #region 連続稼働日数と空白時間
                pNode.SetAttribute("continuas", member.Continuas.ToString());
                pNode.SetAttribute("spacetime", member.Spacetime.ToString());
                #endregion
                //
                element.AppendChild(pNode);
            }
            return element;
        }
        /// <summary>人員配置のセーブ
        /// </summary>
        public XmlElement SaveRequirePatterns (XmlDocument doc, CTimeTable all) {
            XmlElement element = doc.CreateElement("requires");
            SaveTmElement(doc, element, all.Requires);
            for (int i = 0; i < all.Requires.Size(true); i++) {
                CRequirePatterns require = all.Requires[i, true];
                if (!require.BuiltIn) {
                    XmlElement pNode = doc.CreateElement("require");
                    SaveTmElement(doc, pNode, require);
                    pNode.SetAttribute("name", require.Name);
                    // シフトごとの人数
                    for (int j = 0; j < require.Size(); j++) {
                        CPattern pattern = require.GetPattern(j);
                        int needs = require.GetRequire(pattern);
                        if (needs > 0) {
                            XmlElement nNode = doc.CreateElement("pattern");
                            nNode.SetAttribute("patternid", pattern.ObjectID.ToString());
                            nNode.SetAttribute("requirenums", needs.ToString());
                            pNode.AppendChild(nNode);
                        }
                    }
                    // エレメントを追加
                    element.AppendChild(pNode);
                }
            }
            return element;
        }
        /// <summary>日付のセーブ
        /// </summary>
        public void SaveScheduledDate (XmlDocument doc, XmlElement rNode, CTimeTable all) {
            for (int i = 0; i < all.Size(); i++) {
                bool edited = false;
                CScheduledDate sdate = all[i];
                XmlElement pNode = doc.CreateElement("scheduleddate");
                SaveTmElement(doc, pNode, sdate);
                // 日付がもっとも大事？
                pNode.SetAttribute("date", sdate.Date.ToString(CSaver.DATEFORMAT));
                // 人員配置
                if (sdate.Require != null && sdate.Require != CRequirePatterns.NULL) {
                    pNode.SetAttribute("require", sdate.Require.ObjectID.ToString());
                    if (sdate.Require != all.GetDefaultRequire(sdate.Date.DayOfWeek)) {
                        edited = true;
                    }
                }
                // メンバーごとのスケジュール（シフトとメモ）
                for (int j = 0; j < sdate.ValidMemberSize; j++) {
                    CSchedule schedule = sdate[j];
                    XmlElement nNode = doc.CreateElement("schedule");
                    SaveTmElement(doc, nNode, schedule);
                    if ((schedule.Member != null && schedule.Member != CMember.NULL && schedule.Pattern != null && schedule.Pattern != CPattern.NULL) || (schedule.Notes.Trim() != "")) {
                        nNode.SetAttribute("member", schedule.Member.ObjectID.ToString());
                        nNode.SetAttribute("pattern", schedule.Pattern.ObjectID.ToString());
                        edited = true;
                        pNode.AppendChild(nNode);
                    }
                }
                if (edited) {
                    // 変更されている場合のみ
                    rNode.AppendChild(pNode);
                }
            }
        }
        /// <summary>エレメントのセーブ
        /// </summary>
        public void SaveTmElement (XmlDocument doc, XmlElement element, ITimeTableElement obj) {
            element.SetAttribute("id", obj.ObjectID.ToString());
            element.SetAttribute("available", (obj.Removed == null ? "TRUE" : "FALSE"));
            element.SetAttribute("created", obj.Created.ToString(CSaver.DATEFORMAT));
            if (obj.Removed != null) {
                element.SetAttribute("removed", ((DateTime)obj.Removed).ToString(CSaver.DATEFORMAT));
            }
            // プロパティ
            foreach (string key in obj) {
                //propelement.SetAttribute("value", obj.GetProperty(key));
                string proptext = obj.GetProperty(key);
                if (proptext != "") {
                    XmlElement propelement = doc.CreateElement("property");
                    propelement.SetAttribute("key", key);
                    propelement.InnerText = proptext;
                    element.AppendChild(propelement);
                }
            }
            // メモ
            if (obj.Notes.Trim() != "") {
                XmlElement noteelement = doc.CreateElement("notes");
                noteelement.InnerText = obj.Notes;
                element.AppendChild(noteelement);
            }
        }
    }

}
