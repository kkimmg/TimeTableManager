using System;
using System.Xml;
using TimeTableManager.Element;

namespace TimeTableManager.IO {
    /// <summary>ローダー
    /// </summary>
    public class CLoader {
        /// <summary>コンストラクタ
        /// </summary>
        public CLoader () {
            // 
            // TODO: コンストラクタ ロジックをここに追加してください。
            //
        }
        /// <summary>ロードメイン
        /// </summary>
        public CTimeTable Load (string file) {
            CTimeTable ret = new CTimeTable();
            ret.ScheduleEditedEvnetIsValid = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlElement rNode = doc.DocumentElement;
            XmlElement cNode = rNode.FirstChild as XmlElement;
            while (cNode != null) {
                if (cNode.Name == "patterns") {
                    // シフト
                    LoadPatterns(cNode, ret);
                } else if (cNode.Name == "members") {
                    // メンバー
                    LoadMembers(cNode, ret);
                } else if (cNode.Name == "requires") {
                    // 人員配置
                    LoadRequirePatterns(cNode, ret);
                } else if (cNode.Name == "dayoffs") {
                    // 休日
                    LoadDayOffs(cNode, ret);
                } else if (cNode.Name == "scheduleddate") {
                    // 日付
                    LoadScheduledDate(cNode, ret);
                } else if (cNode.Name == "starttime") {
                    // 営業開始時間
                    string text = cNode.InnerText;
                    ret.StartTime = TimeSpan.Parse(text);
                } else if (cNode.Name == "endtime") {
                    // 営業終了時間
                    if (ret.Around == TimeSpan.Zero) {
                        string text = cNode.InnerText;
                        ret.EndTime = TimeSpan.Parse(text);
                    }
                } else if (cNode.Name == "around") {
                    // 営業時間
                    string text = cNode.InnerText;
                    ret.Around = TimeSpan.Parse(text);
                } else if (cNode.Name == "default_require") {
                    // デフォルトの人員配置
                    string text = cNode.InnerText;
                    int requireid = int.Parse(text);
                    if (requireid > 0) {
                        CRequirePatterns require = ret.Requires.GetByID(requireid);
                        if (require != null) {
                            ret.DefaultRequire = require;
                        }
                    }
                } else if (cNode.Name == "defaultRequireweekday") {
                    // デフォルトの人員配置（曜日ごと）
                    string text1 = cNode.GetAttribute("weekday");
                    string text2 = cNode.GetAttribute("require");
                    try {
                        int weekdayid, requireid;
                        int.TryParse(text1, out weekdayid);
                        int.TryParse(text2, out requireid);
                        //= (int.TryParse(text1,) ? int.Parse(text1) : 0);
                        //int requireid = int.Parse(text2);
                        if (weekdayid >= 0) {
                            CRequirePatterns require = ret.Requires.GetByID(requireid);
                            if (require != null) {
                                ret.SetDefaultRequire(weekdayid, require);
                            }
                        }
                    } catch {
                    }
                } else if (cNode.Name == "sequence") {
                    // 順番
                    string text = cNode.InnerText;
                    int seq = int.Parse(text);
                    ret.CurrentID = seq;
                } else if (cNode.Name == "property") {
                    //ret[cNode.GetAttribute("key")] = cNode.GetAttribute("value");
                    ret[cNode.GetAttribute("key")] = cNode.InnerText;
                }
                //
                cNode = cNode.NextSibling as XmlElement;
            }
            ret.ScheduleEditedEvnetIsValid = true;
            return ret;
        }
        /// <summary>勤務シフトのロード
        /// </summary>
        public void LoadPatterns (XmlElement element, CTimeTable all) {
            XmlElement pNode = element.FirstChild as XmlElement;
            while (pNode != null) {
                if (pNode.Name == "pattern") {
                    // シフト
                    CPattern pattern = all.Patterns.CreatePattern();
                    LoadTmElement(pNode, pattern);
                    pattern.Name = pNode.GetAttribute("name");
                    TimeSpan work1, work4, work5;
                    pattern.Start = (TimeSpan.TryParse(pNode.GetAttribute("start"), out work1) ? work1 : TimeSpan.Zero);
                    pattern.Scope = (TimeSpan.TryParse(pNode.GetAttribute("scope"), out work4) ? work4 : TimeSpan.Zero);
                    pattern.Rest = (TimeSpan.TryParse(pNode.GetAttribute("rest"), out work5) ? work5 : TimeSpan.Zero);
                    all.Patterns.AddPattern(pattern);
                }
                //
                pNode = pNode.NextSibling as XmlElement;
            }
            //all.Patterns.AddPattern(Pattern.DayOff);
        }
        /// <summary>休日のロード
        /// </summary>
        public void LoadDayOffs (XmlElement element, CTimeTable all) {
            XmlElement pNode = element.FirstChild as XmlElement;
            while (pNode != null) {
                if (pNode.Name == "dayoff") {
                    // 休日
                    CDayOff dayoff = all.DayOffs.CreateDayOff();
                    LoadTmElement(pNode, dayoff);
                    dayoff.Name = pNode.GetAttribute("name");
                    dayoff.StartDate = DateTime.Parse(pNode.GetAttribute("start"));
                    dayoff.EndDate = DateTime.Parse(pNode.GetAttribute("end"));
                    all.DayOffs.AddDayOff(dayoff);
                }
                //
                pNode = pNode.NextSibling as XmlElement;
            }
        }
        /// <summary>メンバーのロード
        /// </summary>
        public void LoadMembers (XmlElement element, CTimeTable all) {
            XmlElement pNode = element.FirstChild as XmlElement;
            while (pNode != null) {
                if (pNode.Name == "member") {
                    // メンバー
                    CMember member = all.Members.CreateMember();
                    LoadTmElement(pNode, member);
                    member.Name = pNode.GetAttribute("name");
                    #region チーフですか？
                    string sChief = pNode.GetAttribute("chief");
                    if (sChief != null) {
                        bool bChief;
                        if (bool.TryParse(sChief, out bChief)) {
                            member.IsChief = bChief;
                        }
                    }
                    #endregion
                    #region 期待される作業時間
                    TimeSpan eWork = member.ExpectedWork;
                    if (TimeSpan.TryParse(pNode.GetAttribute("expectedwork"), out eWork)) {
                        member.ExpectedWork = eWork;
                    }
                    #endregion
                    member.ExpectedRest = double.Parse(pNode.GetAttribute("expectedrest"));
                    member.Priority = int.Parse(pNode.GetAttribute("priority"));
                    #region 利用できるシフト
                    XmlElement tNode = pNode.FirstChild as XmlElement;
                    while (tNode != null) {
                        if (tNode.Name == "pattern") {
                            int patid = int.Parse(tNode.GetAttribute("id"));
                            member.AddPattern(all.Patterns.GetByID(patid));
                        }
                        //
                        tNode = tNode.NextSibling as XmlElement;
                    }
                    #endregion
                    #region 稼働日
                    bool bWork = true;
                    if (bool.TryParse(pNode.GetAttribute("avl-monday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tMonday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tMonday, true);
                    }
                    if (bool.TryParse(pNode.GetAttribute("avl-tuesday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tTuesday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tTuesday, true);
                    }
                    if (bool.TryParse(pNode.GetAttribute("avl-wednesday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tWednesday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tWednesday, true);
                    }
                    if (bool.TryParse(pNode.GetAttribute("avl-thursday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tThursday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tThursday, true);
                    }
                    if (bool.TryParse(pNode.GetAttribute("avl-friday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tFriday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tFriday, true);
                    }
                    if (bool.TryParse(pNode.GetAttribute("avl-saturday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tSaturday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tSaturday, true);
                    }
                    if (bool.TryParse(pNode.GetAttribute("avl-sunday"), out bWork)) {
                        member.SetAvailableDay(CTimeTable.tSunday, bWork);
                    } else {
                        member.SetAvailableDay(CTimeTable.tSunday, true);
                    }
                    #endregion
                    #region 稼動間隔
                    TimeSpan stpWork1 = member.Spacetime;
                    if (TimeSpan.TryParse(pNode.GetAttribute("spacetime"), out stpWork1)) {
                        member.Spacetime = stpWork1;
                    }
                    #endregion
                    #region 連続稼動
                    TimeSpan stpWork2 = member.Continuas;
                    if (TimeSpan.TryParse(pNode.GetAttribute("continuas"), out stpWork2)) {
                        member.Continuas = stpWork2;
                    }
                    #endregion
                    //
                    all.Members.AddMember(member);
                }
                //
                pNode = pNode.NextSibling as XmlElement;
            }
        }
        /// <summary>人員配置のロード
        /// </summary>
        public void LoadRequirePatterns (XmlElement element, CTimeTable all) {
            XmlElement pNode = element.FirstChild as XmlElement;
            while (pNode != null) {
                if (pNode.Name == "require") {
                    CRequirePatterns require = all.Requires.CreateRequirePatterns();
                    LoadTmElement(pNode, require);
                    require.Name = pNode.GetAttribute("name");
                    // 利用できるシフト
                    XmlElement tNode = pNode.FirstChild as XmlElement;
                    while (tNode != null) {
                        if (tNode.Name == "pattern") {
                            //
                            int patternid = int.Parse(tNode.GetAttribute("patternid"));
                            int requirenum = int.Parse(tNode.GetAttribute("requirenums"));
                            CPattern pattern = all.Patterns.GetByID(patternid);
                            require.SetRequire(pattern, requirenum);
                        }
                        //
                        tNode = tNode.NextSibling as XmlElement;
                    }
                    //
                    all.Requires.AddRequirePatterns(require);
                }
                //
                pNode = pNode.NextSibling as XmlElement;
            }
            //all.Requires.AddRequirePatterns(RequirePatterns.NOWORK);
        }
        /// <summary>日付のロード
        /// </summary>
        public void LoadScheduledDate (XmlElement element, CTimeTable all) {
            DateTime date = DateTime.Parse(element.GetAttribute("date"));
            CScheduledDate scheduleddate = all.Dates.CreateScheduledDate(date);
            if (date.Year == 2007 && date.Month == 4 && date.Day == 28) {
                System.Console.WriteLine("ここだ！");
            }
            LoadTmElement(element, scheduleddate);
            XmlAttribute req = element.Attributes["require"];
            // 人員配置
            if (req != null) {
                int wid = int.Parse(req.Value);
                CRequirePatterns reqobj = all.Requires.GetByID(wid);
                scheduleddate.Require = reqobj;
            } else {
                scheduleddate.Require = CRequirePatterns.NULL;
            }
            XmlElement pNode = element.FirstChild as XmlElement;
            while (pNode != null) {
                if (pNode.Name == "schedule") {
                    // スケジュール 
                    CSchedule schedule = scheduleddate.CreateSchedule();
                    LoadTmElement(pNode, schedule);
                    string membertxt = pNode.GetAttribute("member");
                    if (membertxt.Trim().Length > 0) {
                        int memberid = int.Parse(membertxt);
                        if (memberid > 0) {
                            schedule.Member = all.Members.GetByID(memberid);
                        }
                    }
                    string patterntxt = pNode.GetAttribute("pattern");
                    if (patterntxt.Trim().Length > 0) {
                        int patternid = int.Parse(patterntxt);
                        schedule.Pattern = all.Patterns.GetByID(patternid);
                    }
                    scheduleddate.SetSchedule(schedule);
                }
                //
                pNode = pNode.NextSibling as XmlElement;
            }
            all.Dates.AddScheduleDate(scheduleddate);
        }
        /// <summary>エレメントのロード
        /// </summary>
        public void LoadTmElement (XmlElement element, ITimeTableElement obj) {
            obj.ObjectID = long.Parse(element.GetAttribute("id"));
            string availtext = element.GetAttribute("available");
            if (availtext.ToUpper() == "TRUE") {
                obj.SetAvailable(true);
            } else {
                obj.SetAvailable(false);
            }
            obj.Created = DateTime.Parse(element.GetAttribute("created"));
            XmlAttribute att = element.Attributes["removed"];
            if (att != null) {
                obj.Removed = DateTime.Parse(att.Value);
            } else {
                obj.Removed = CAbstractElement.NullDate;
            }
            XmlElement pNode = element.FirstChild as XmlElement;
            while (pNode != null) {
                if (pNode.Name == "property") {
                    obj.SetProperty(pNode.GetAttribute("key"), pNode.InnerText);
                } else if (pNode.Name == "notes") {
                    obj.Notes = pNode.InnerText;
                }
                //
                pNode = pNode.NextSibling as XmlElement;
            }
        }
    }

}
