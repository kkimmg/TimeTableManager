using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.Printing {
    /// <summary>
    /// 印刷マージン
    /// </summary>
    public enum PrintMargin {
        MARGIN_LEFT = 1,
        MARGIN_RIGHT = 2,
        MARGIN_TOP = 1,
        MARGIN_BOTTOM = 2,
        MARGIN_CENTER = 0,
    }
    /// <summary>
    /// 印刷ドキュメント
    /// </summary>
    public class CPrintDocumentBody : System.Drawing.Printing.PrintDocument {
        #region リテラル
        public const string RIT_IMAGEPRINT = "Printing.bool.ImagePrint";
        public const bool RIT_IMAGEPRINT_DEFAULT = false;
        public const string RIT_ISDISPLAYREQUIRE = "Printing.bool.IsDisplayRequire";
        public const bool RIT_ISDISPLAYREQUIRE_DEFAULT = true;
        public const string RIT_ISMONTHLY = "Printing.bool.IsMonthly";
        public const bool RIT_ISMONTHLY_DEFAULT = true;
        public const string RIT_ROWCOUNT = "Printing.Int.RowCount";
        public const string RIT_COLUMNCOUNT = "Printing.Int.ColumnCount";
        public const string RIT_BODYBRUSH = "Printing.Brush.BodyBrush";
        public const string RIT_DATEBRUSH = "Printing.Brush.DateBrush";
        public const string RIT_DATEBRUSHHOL = "Printing.Brush.DateBrushHol";
        public const string RIT_DATEBRUSHSAT = "Printing.Brush.DateBrushSat";
        public const string RIT_DATEBRUSHSUN = "Printing.Brush.DateBrushSun";
        public const string RIT_HEADERBRUSH = "Printing.Brush.HeaderBrush";
        public const string RIT_DATECOLUMNWIDTH = "Printing.float.DateColumnWidth";
        public const string RIT_REQUIRECOLUMNWIDTH = "Printing.float.RequireColumnWidth";
        public const string RIT_TABLEHEADERHIGHT = "Printing.float.TableHeaderHight";
        public const string RIT_BODYFONT = "Printing.Font.BodyFont";
        public const string RIT_DATEFONT = "Printing.Font.DateFont";
        public const string RIT_HEADERFONT = "Printing.Font.HeaderFont";
        public const string RIT_DATEFORMAT = "Printing.string.DateFormat";
        public const string RIT_DATEFORMAT_DEFAULT = "MM/dd(ddd)";
        public const string RIT_DATEHEADERFORMAT = "Printing.string.DateHeaderFormat";
        #endregion
        #region プライベート
        /// <summary>
        /// タイムテーブル
        /// </summary>
        private TimeTableManager.DefaultElement.CTimeTable timeTable;
        /// <summary>
        /// ページインデックス 
        /// </summary>
        private int index = 1;
        /// <summary>
        /// 開始
        /// </summary>
        private DateTime start;
        /// <summary>
        /// 終了 
        /// </summary>
        private DateTime end;
        /// <summary>
        /// ヘッダー部 
        /// </summary>
        private CPrintDocumentHeader header = new CPrintDocumentHeader();
        /// <summary>
        /// フッター部 
        /// </summary>
        private CPrintDocumentFooter footer = new CPrintDocumentFooter();
        /// <summary>
        /// 有効なメンバーの一覧
        /// </summary>
        private List<CMember> members = new List<CMember>();
        /// <summary>
        /// ページインデックス
        /// </summary>
        private List<CPageIndex> pages = new List<CPageIndex>();
        /// <summary>
        /// 日付の列の幅
        /// </summary>
        private float dateColumnWidth = 80.0F;
        /// <summary>
        /// 必要人数の列の幅
        /// </summary>
        private float requireColumnWidth = 80.0F;
        /// <summary>
        /// テーブルのヘッダー部分の高さ
        /// </summary>
        private float tableHeaderHight = 25;
        /// <summary>
        /// 行ヘッダーの色
        /// </summary>
        private Brush headerBrush = Brushes.Black;
        /// <summary>
        /// 行の色
        /// </summary>
        private Brush bodyBrush = Brushes.Black;
        /// <summary>
        /// 日付の色
        /// </summary>
        private Brush dateBrush = Brushes.Black;
        /// <summary>
        /// 日付の色（日曜日）
        /// </summary>
        private Brush dateBrushSat = Brushes.Red;
        /// <summary>
        /// 日付の色（土曜日）
        /// </summary>
        private Brush dateBrushSun = Brushes.Blue;
        /// <summary>
        /// 日付の色（休日）
        /// </summary>
        private Brush dateBrushHol = Brushes.Green;
        #endregion
        #region 印刷設定
        /// <summary>
        /// 行ヘッダーの色
        /// </summary>
        public Brush HeaderBrush {
            get { return headerBrush; }
            set { headerBrush = value; }
        }
        /// <summary>
        /// 行ヘッダーのフォント
        /// </summary>
        public Font HeaderFont {
            get {
                return GetFont(TimeTable, RIT_HEADERFONT); 
            }
        }
        /// <summary>
        /// 行の色
        /// </summary>
        public Brush BodyBrush {
            get { return bodyBrush; }
            set { bodyBrush = value; }
        }
        /// <summary>
        /// 行のフォント
        /// </summary>
        public Font BodyFont {
            get {
                return GetFont(TimeTable, RIT_BODYFONT);
            }
        }
        /// <summary>
        /// 行のフォント
        /// </summary>
        public Brush DateBrush {
            get { return dateBrush; }
            set { dateBrush = value; }
        }
        /// <summary>
        /// 日付の色（日曜日）
        /// </summary>
        public Brush DateBrushSat {
            get { return dateBrushSat; }
            set { dateBrushSat = value; }
        }
        /// <summary>
        /// 日付の色（日曜日）
        /// </summary>
        public Brush DateBrushSun {
            get { return dateBrushSun; }
            set { dateBrushSun = value; }
        }
        /// <summary>
        /// 日付の色（休日）
        /// </summary>
        public Brush DateBrushHol {
            get { return dateBrushHol; }
            set { dateBrushHol = value; }
        }
        /// <summary>
        /// 日付のフォント
        /// </summary>
        public Font DateFont {
            get {
                return GetFont(TimeTable, RIT_DATEFONT);
            }
        }
        /// <summary>
        /// 日付のフォーマット
        /// </summary>
        public string DateFormat {
            get {
                string work = TimeTable[CPrintDocumentBody.RIT_DATEFORMAT];
                if (work == null) {
                    work = CPrintDocumentBody.RIT_DATEFORMAT_DEFAULT;
                }
                return work; 
            }
        }
        /// <summary>
        /// イメージで出力する
        /// </summary>
        public bool ImagePrint {
            get {
                string work = TimeTable[CPrintDocumentBody.RIT_IMAGEPRINT];
                bool bork = CPrintDocumentBody.RIT_IMAGEPRINT_DEFAULT;
                if (work != null) {
                    if (!(bool.TryParse(work, out bork))) {
                        bork = CPrintDocumentBody.RIT_IMAGEPRINT_DEFAULT;
                    }
                }
                return bork;
            }
        }
        /// <summary>
        /// ヘッダー日付のフォーマット
        /// </summary>
        //public string DateHeaderFormat {
        //    get { return dateHeaderFormat; }
        //}
        /// <summary>
        /// 日付の列の幅
        /// </summary>
        public float DateColumnWidth {
            get { return dateColumnWidth; }
            set { dateColumnWidth = value; }
        }
        /// <summary>
        /// 必要人数の列の幅
        /// </summary>
        public float RequireColumnWidth {
            get { return requireColumnWidth; }
            set { requireColumnWidth = value; }
        }
        /// <summary>
        /// 必要人数を表示するか？
        /// </summary>
        public bool IsDisplayRequire {
            get {
                string work = TimeTable[CPrintDocumentBody.RIT_ISDISPLAYREQUIRE];
                bool bork = CPrintDocumentBody.RIT_ISDISPLAYREQUIRE_DEFAULT;
                if (work != null) {
                    if (!(bool.TryParse(work, out bork))) {
                        bork = CPrintDocumentBody.RIT_ISDISPLAYREQUIRE_DEFAULT;
                    }
                }
                return bork;
            }
        }
        /// <summary>
        /// テーブルのヘッダー部分の高さ
        /// </summary>
        public float TableHeaderHight {
            get { return tableHeaderHight; }
            set { tableHeaderHight = value; }
        }
        #endregion
        /// <summary>
        /// ヘッダー部
        /// </summary>
        public CPrintDocumentHeader Header {
            get { return header; }
            set { header = value; }
        }
        /// <summary>
        /// フッター部
        /// </summary>
        public CPrintDocumentFooter Footer {
            get { return footer; }
            set { footer = value; }
        }
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public TimeTableManager.DefaultElement.CTimeTable TimeTable {
            get {
                return timeTable;
            }
            set {
                timeTable = value;
            }
        }
        /// <summary>
        /// ページインデックス
        /// </summary>
        public int Index {
            get { return index + 1; }
        }
        /// <summary>
        /// ページ数
        /// </summary>
        public int PageCount {
            get {
                return pages.Count;
            }
        }
        /// <summary>
        /// 印刷初期化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBeginPrint (System.Drawing.Printing.PrintEventArgs e) {
            if (TimeTable == null) return;
            CachedStart = Start;
            CachedEnd = End;
            // タイムテーブルによる設定
            header.TimeTable = TimeTable;
            header.Document = this;
            footer.TimeTable = TimeTable;
            footer.Document = this;
            index = 0;
            // メンバーの一覧設定
            members.Clear();
            int z = TimeTable.Members.Size(true);
            for (int i = 0; i < z; i++) {
                CMember member = TimeTable.Members[i, true];
                if (member.IsAvailable(Start) || member.IsAvailable(End)) {
                    members.Add(member);
                }
            }
            // ページの作成
            TimeSpan ONEDAY = new TimeSpan(1, 0, 0, 0);
            pages.Clear();
            bool cont1 = true;
            DateTime k = Start;
            CPageIndex page = null;
            while (cont1) {
                int j = 0;
                bool cont2 = true;
                while (cont2) {
                    page = new CPageIndex();
                    page.Document = this;
                    page.Start = k;
                    page.MemberStartIndex = j;
                    page.CalcPage();
                    pages.Add(page);
                    j = page.MemberEndIndex + 1;
                    if (j >= members.Count) {
                        cont2 = false;
                    }
                }
                k = page.End.AddDays(1);
                if (k >= End) {
                    cont1 = false;
                }
            }
        }
        /// <summary>
        /// 印刷
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPrintPage (System.Drawing.Printing.PrintPageEventArgs e) {
            if (timeTable == null) return;

            Graphics g = e.Graphics;
            Bitmap bitmap = null;
            if (ImagePrint) {
                // イメージ印刷する
                int width = e.PageBounds.Width;
                int height = e.PageBounds.Height;
                bitmap = new Bitmap(width, height);
                g = Graphics.FromImage(bitmap);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            //Header.CenterText = CachedStart.ToString("yyyy/MM/dd") + "～" + CachedEnd.ToString("yyyy/MM/dd");
            //Header.RightText = "ページ：" + (index + 1).ToString();
            Header.Page = pages[index];
            Header.Paint(g, e);
            Footer.Paint(g, e);
            PaintBody(g, e);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            if (ImagePrint && bitmap != null) {
                // イメージ印刷する
                e.Graphics.DrawImageUnscaledAndClipped(bitmap, e.PageBounds);
            }
        }
        /// <summary>
        /// 罫線を書くペン
        /// </summary>
        private Pen pen = Pens.Black;
        /// <summary>
        /// 罫線を書くペン
        /// </summary>
        public Pen Pen {
            get { return pen; }
            set { pen = value; }
        }
        /// <summary>
        /// １ページあたりの最大のメンバー数
        /// </summary>
        public int MaxMember {
            get {
                string work = TimeTable[CPrintDocumentBody.RIT_COLUMNCOUNT];
                int iork = 0;
                if (work != null) {
                    if (!(int.TryParse(work, out iork))) {
                        iork = 0;
                    }
                }
                return iork; 
            }
        }
        /// <summary>
        /// １ページあたりの最大の日数
        /// </summary>
        public int MaxDates {
            get {
                string work = TimeTable[CPrintDocumentBody.RIT_ROWCOUNT];
                int iork = 0;
                if (work != null) {
                    if (!(int.TryParse(work, out iork))) {
                        iork = 0;
                    }
                }
                return iork;
            }
        }
        /// <summary>
        /// 月ごとに改ページする
        /// </summary>
        public Boolean Monthly {
            get {
                string work = TimeTable[CPrintDocumentBody.RIT_ISMONTHLY];
                bool bork = CPrintDocumentBody.RIT_ISMONTHLY_DEFAULT;
                if (work != null) {
                    if (!(bool.TryParse(work, out bork))) {
                        bork = CPrintDocumentBody.RIT_ISMONTHLY_DEFAULT;
                    }
                }
                return bork;
            }
        }
        /// <summary>
        /// キャッシュされた開始とスタート
        /// </summary>
        private DateTime CachedStart, CachedEnd;
        /// <summary>
        /// 印刷・ボディ部分
        /// </summary>
        /// <param name="e"></param>
        protected virtual void PaintBody (Graphics g, System.Drawing.Printing.PrintPageEventArgs e) {
            //Graphics g = e.Graphics;
            Rectangle mar = e.MarginBounds;
            RectangleF rect;
            #region 内部の箱
            {
                float itop = mar.Top + Header.GetHeight(g);
                float ibottom = mar.Bottom - Footer.GetHeight(g) - 2;
                float iheight = ibottom - itop;
                float ileft = mar.Left;
                float iwidth = mar.Width;
                float iright = ileft + iwidth;
                rect = new RectangleF(ileft, itop, iwidth, iheight);
            }
            #endregion
            //
            g.DrawRectangle(this.Pen, rect.Left, rect.Top, rect.Width, rect.Height);
            //
            CPageIndex page = pages[index];
            // 決め打ちできる罫線を引く
            float DateRight = rect.Left + RequireColumnWidth;
            g.DrawLine(this.Pen, DateRight, rect.Top, DateRight, rect.Bottom);
            DrawString(g, "日付", HeaderFont, HeaderBrush, rect.Left, DateRight, rect.Top, tableHeaderHight, PrintMargin.MARGIN_CENTER, PrintMargin.MARGIN_CENTER);
            float RequireRight = DateRight;
            if (IsDisplayRequire) {
                RequireRight += RequireColumnWidth;
                g.DrawLine(this.Pen, RequireRight, rect.Top, RequireRight, rect.Bottom);
                DrawString(g, "必要人数", HeaderFont, HeaderBrush, DateRight, RequireRight, rect.Top, tableHeaderHight, PrintMargin.MARGIN_CENTER, PrintMargin.MARGIN_CENTER);
            }
            // テーブルのヘッダ
            float TableHeadBottom = rect.Top + TableHeaderHight;
            g.DrawLine(this.Pen, rect.Left, TableHeadBottom, rect.Right, TableHeadBottom);
            // メンバー数に応じた罫線を引く
            float MemberColumnBase = (IsDisplayRequire ? RequireRight : DateRight);
            float MemberColumnSpace = rect.Right - MemberColumnBase;
            float MemberColumnWidth = MemberColumnSpace / page.MemberCount;
            for (int i = 1; i < page.MemberCount; i++) {
                float WorkLeft = MemberColumnBase + MemberColumnWidth * (i - 1);
                float WorkRight = MemberColumnBase + MemberColumnWidth * i;
                g.DrawLine(this.Pen, WorkRight, rect.Top, WorkRight, rect.Bottom);
            }
            // メンバー名
            for (int i = 0; i < page.MemberCount; i++) {
                float WorkLeft = MemberColumnBase + MemberColumnWidth * i;
                float WorkRight = MemberColumnBase + MemberColumnWidth * (i + 1);
                //
                CMember member = this.TimeTable.Members[page.MemberStartIndex + i];
                DrawString(g, member.Name, HeaderFont, HeaderBrush, WorkLeft, WorkRight, rect.Top, tableHeaderHight, PrintMargin.MARGIN_CENTER, PrintMargin.MARGIN_CENTER);
            }
            // 日数に応じた罫線を引く
            float DateRowSpace = rect.Bottom - TableHeadBottom;
            float DateRowHeight = DateRowSpace / page.DateCount;
            for (int i = 1; i < page.DateCount; i++) {
                float WorkTop = TableHeadBottom + DateRowHeight * (i - 1);
                float WorkBottom = TableHeadBottom + DateRowHeight * i;
                g.DrawLine(this.Pen, rect.Left, WorkBottom, rect.Right, WorkBottom);
            }
            // これこそ本体
            DateTime WorkDate = page.Start;
            for (int i = 0; i < page.DateCount; i++) {
                float WorkTop = TableHeadBottom + DateRowHeight * i;
                float WorkBottom = TableHeadBottom + DateRowHeight * (i + 1);
                // 日付
                DrawString(g, WorkDate.ToString(DateFormat), System.Windows.Forms.Control.DefaultFont, Brushes.Black, rect.Left, DateRight, WorkTop, DateRowHeight, PrintMargin.MARGIN_CENTER, PrintMargin.MARGIN_CENTER);
                // スケジュール日
                CScheduledDate sdate = this.TimeTable[WorkDate];
                if (IsDisplayRequire) {
                    if (sdate.Require != null) {
                        DrawString(g, sdate.Require.Name, BodyFont, BodyBrush, DateRight, RequireRight, WorkTop, DateRowHeight, PrintMargin.MARGIN_CENTER, PrintMargin.MARGIN_CENTER);
                    }
                }
                // パターン
                for (int j = 0; j < page.MemberCount; j++) {
                    float WorkLeft = MemberColumnBase + MemberColumnWidth * j;
                    float WorkRight = MemberColumnBase + MemberColumnWidth * (j + 1);
                    //
                    CMember member = this.TimeTable.Members[page.MemberStartIndex + j];
                    CSchedule schedule = sdate[member];
                    CPattern pattern = (schedule != null ? schedule.Pattern : null);
                    if (pattern != null) {
                        DrawString(g, pattern.Name, BodyFont, BodyBrush, WorkLeft, WorkRight, WorkTop, DateRowHeight, PrintMargin.MARGIN_CENTER, PrintMargin.MARGIN_CENTER);
                    }
                }
                //
                WorkDate = WorkDate.AddDays(1);
            }
            //
            e.HasMorePages = page.HasMorePage;
            //
            index++;
        }
        /// <summary>
        /// 開始
        /// </summary>
        public DateTime Start {
            get { return (start < end ? start : end); }
            set {
                start = value;
            }
        }
        /// <summary>
        /// 終了
        /// </summary>
        public DateTime End {
            get { return (end > start ? end : start); }
            set {
                end = value;
            }
        }
        /// <summary>
        /// メンバーの取得
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public CMember GetMember (int i) {
            return members[i];
        }
        /// <summary>
        /// メンバー数
        /// </summary>
        /// <returns></returns>
        public int GetMemberCount () {
            return members.Count;
        }
        /// <summary>
        /// 指定したマージンでテキストを描画する
        /// </summary>
        /// <param name="g">グラフィックス</param>
        /// <param name="text">描画するテキスト</param>
        /// <param name="font">描画するフォント</param>
        /// <param name="brush">色など</param>
        /// <param name="left">左位置</param>
        /// <param name="right">右位置</param>
        /// <param name="top">上位置</param>
        /// <param name="margin">配置</param>
        protected virtual void DrawString (Graphics g, string text, Font font, Brush brush, float left, float right, float top, PrintMargin margin) {
            System.Drawing.SizeF size = g.MeasureString(text, font);
            float TextWidth = size.Width;
            if (TextWidth > right - left) {
                // 長すぎるので縮めて再実行
                DrawString(g, text.Substring(0, text.Length - 1), font, brush, left, right, top, margin);
            } else {
                // 
                float newleft = left;
                switch (margin) {
                    case PrintMargin.MARGIN_LEFT:
                        break;
                    case PrintMargin.MARGIN_CENTER:
                        newleft += ((right - left) - size.Width) / 2;
                        break;
                    case PrintMargin.MARGIN_RIGHT:
                        newleft += (right - left) - size.Width;
                        break;
                }
                g.DrawString(text, font, brush, newleft, top);
            }
        }
        /// <summary>
        /// 指定したマージンでテキストを描画する
        /// </summary>
        /// <param name="g">グラフィックス</param>
        /// <param name="text">描画するテキスト</param>
        /// <param name="font">描画するフォント</param>
        /// <param name="brush">色など</param>
        /// <param name="left">左位置</param>
        /// <param name="right">右位置</param>
        /// <param name="top">上位置</param>
        /// <param name="height">高さ</param>
        /// <param name="vmargin">配置(横)</param>
        /// <param name="hmargin">配置(縦)</param>
        protected virtual void DrawString (Graphics g, string text, Font font, Brush brush, float left, float right, float top, float height, PrintMargin vmargin, PrintMargin hmargin) {
            System.Drawing.SizeF size = g.MeasureString(text, font);
            float newTop = top;
            switch (hmargin) {
                case PrintMargin.MARGIN_CENTER:
                    newTop += (height - size.Height) / 2;
                    break;
                case PrintMargin.MARGIN_BOTTOM:
                    newTop += (height - size.Height);
                    break;
            }
            DrawString(g, text, font, brush, left, right, newTop, vmargin);
        }

        public const string POSTFIX_FONTNAME = ".NAME";// フォント名
        public const string POSTFIX_FONTSIZE = ".SIZE";// フォントサイズ
        public const string POSTFIX_FONTSTYLE = ".STYLE";// フォントスタイル
        public const string STYLE_BOLD = "BOLD";// 太字テキスト。  
        public const string STYLE_ITALIC = "ITALIC";// 斜体テキスト。  
        public const string STYLE_REGULAR = "REGULAR";// 標準テキスト。  
        public const string STYLE_STRICKEOUT = "STRICKEOUT";// 中央に線が引かれているテキスト。  
        public const string STYLE_UNDERLINE = "UNDERLINE";// 下線付きテキスト。 
        /// <summary>
        /// タイムテーブルに登録されたフォントの取得
        /// </summary>
        /// <param name="timetable"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Font GetFont (CTimeTable timetable, string key) {
            Font font = System.Windows.Forms.Control.DefaultFont;
            string stfontname = timetable[key + POSTFIX_FONTNAME];
            string stfontsize = timetable[key + POSTFIX_FONTSIZE];
            float fontsize = font.Size;
            string stfontstyle = timetable[key + POSTFIX_FONTSTYLE];
            FontStyle fontstyle = font.Style;
            // フォントファミリー
            if (stfontname == null) {
                return font;
            } else if (stfontname.Trim().Length == 0) {
                // デフォルト
                return font;
            }
            // フォントサイズ
            if (stfontsize != null) {
                if (!(float.TryParse(stfontsize, out fontsize))) {
                    fontsize = font.Size;
                }
            }
            // フォントスタイル
            if (stfontstyle != null) {
                switch (stfontstyle) {
                    case STYLE_BOLD:
                        fontstyle = FontStyle.Bold;
                        break;
                    case STYLE_ITALIC:
                        fontstyle = FontStyle.Italic;
                        break;
                    case STYLE_REGULAR:
                        fontstyle = FontStyle.Regular;
                        break;
                    case STYLE_STRICKEOUT:
                        fontstyle = FontStyle.Strikeout;
                        break;
                    case STYLE_UNDERLINE:
                        fontstyle = FontStyle.Underline;
                        break;
                    default:
                        fontstyle = font.Style;
                        break;
                }
            }
            // 戻り値のセット 
            Font ret = font;
            try {
                ret = new Font(stfontname, fontsize, fontstyle);
            } catch {
                ret = font;
            }
            return ret;
        }
        /// <summary>
        /// タイムテーブルにフォントをセットする
        /// </summary>
        /// <param name="timetable"></param>
        /// <param name="key"></param>
        /// <param name="font"></param>
        public static void SetFont (CTimeTable timetable, string key, Font font) {
            if (font != null) {
                timetable[key + POSTFIX_FONTNAME] = font.Name;
                timetable[key + POSTFIX_FONTSIZE] = font.Size.ToString();
                switch (font.Style) {
                    case FontStyle.Bold:
                        timetable[key + POSTFIX_FONTSTYLE] = STYLE_BOLD;
                        break;
                    case FontStyle.Italic:
                        timetable[key + POSTFIX_FONTSTYLE] = STYLE_ITALIC;
                        break;
                    case FontStyle.Regular:
                        timetable[key + POSTFIX_FONTSTYLE] = STYLE_REGULAR;
                        break;
                    case FontStyle.Strikeout:
                        timetable[key + POSTFIX_FONTSTYLE] = STYLE_STRICKEOUT;
                        break;
                    case FontStyle.Underline:
                        timetable[key + POSTFIX_FONTSTYLE] = STYLE_UNDERLINE;
                        break;
                }
            } else {
                timetable[key + POSTFIX_FONTNAME] = null;
                timetable[key + POSTFIX_FONTSIZE] = null;
                timetable[key + POSTFIX_FONTSTYLE] = null;
            }
        }
    }
}
