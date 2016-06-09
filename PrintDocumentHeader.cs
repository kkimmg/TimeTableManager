using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.Printing {
    public class CPrintDocumentHeader {
        public const string RIT_CENTERBRUSH = "Printing.Header.Brush.CenterBrush";
        public const string RIT_LEFTBRUSH = "Printing.Header.Brush.LeftBrush";
        public const string RIT_RIGHTBRUSH = "Printing.Header.Brush.RightBrush";
        public const string RIT_CENTERFONT = "Printing.Header.Font.CenterFont";
        public const string RIT_LEFTFONT = "Printing.Header.Font.LeftFont";
        public const string RIT_RIGHTFONT = "Printing.Header.Font.RightFont";
        public const string RIT_CENTERTEXT = "Printing.Header.String.CenterText";
        public const string RIT_LEFTTEXT = "Printing.Header.String.LeftText";
        public const string RIT_RIGHTTEXT = "Printing.Header.String.RightText";
        public const string RIT_LEFTTEXT_DEFAULT = "タイムテーブル";
        public const string RIT_CENTERTEXT_DEFAULT = "{$START_DATE}～{$END_DATE}";
        public const string RIT_RIGHTTEXT_DEFAULT = "ページ：{$PAGE}";
        public const string RIT_DATEFORMAT_DEFAULT = "yyyy年MM月dd日";
        public const string RIT_DATEFORMAT = "Printing.Header.String.DateFormat";
        public const string RIT_PAGEFORMAT = "Printing.Header.String.PageFormat";
        public const string RIT_PAGEALLFORMAT = "Printing.Header.String.PageAllFormat";
        public const string RIT_START_DATE = "{$START_DATE}";
        public const string RIT_END_DATE = "{$END_DATE}";
        public const string RIT_PAGE_START_DATE = "{$PAGE_START_DATE}";
        public const string RIT_PAGE_END_DATE = "{$PAGE_END_DATE}";
        public const string RIT_PAGE = "{$PAGE}";
        public const string RIT_PAGEALL = "{$PAGE_ALL}";
        #region プライベート宣言
        /// <summary>
        /// 高さ
        /// </summary>
        private float height = 0;
        /// <summary>
        /// フォント
        /// </summary>
        //private Font leftFont, centerFont, rightFont;
        /// <summary>
        /// テキスト
        /// </summary>
        //private string leftText, centerText, rightText;
        /// <summary>
        /// 色
        /// </summary>
        private Brush leftBrush = Brushes.Black, centerBrush = Brushes.Black, rightBrush = Brushes.Black;
        /// <summary>
        /// タイムテーブル
        /// </summary>
        private CTimeTable timeTable;
        /// <summary>
        /// ページインデックス
        /// </summary>
        private CPageIndex page;
        /// <summary>
        /// ドキュメント
        /// </summary>
        private TtmPrintDocumentSt1 document;
        #endregion
        /// <summary>
        /// ページインデックス
        /// </summary>
        public CPageIndex Page {
            get { return page; }
            set { page = value; }
        }
        /// <summary>
        /// ドキュメント
        /// </summary>
        public TtmPrintDocumentSt1 Document {
            get { return document; }
            set { document = value; }
        }
        public Brush RightBrush {
            get { return rightBrush; }
            set { rightBrush = value; }
        }
        public Brush CenterBrush {
            get { return centerBrush; }
            set { centerBrush = value; }
        }
        public Brush LeftBrush {
            get { return leftBrush; }
            set { leftBrush = value; }
        }
        /// <summary>
        /// 左側フォント
        /// </summary>
        public Font LeftFont {
            get {
                return TtmPrintDocumentSt1.GetFont(TimeTable, RIT_LEFTFONT);
            }
        }
        /// <summary>
        /// 左側フォント
        /// </summary>
        public Font CenterFont {
            get {
                return TtmPrintDocumentSt1.GetFont(TimeTable, RIT_CENTERFONT);
            }
        }
        /// <summary>
        /// 左側フォント
        /// </summary>
        public Font RightFont {
            get {
                return TtmPrintDocumentSt1.GetFont(TimeTable, RIT_RIGHTFONT);
            }
        }
        private string FormatText2Text (string format) {
            string ret = format;
            // 日付フォーマット
            string dateformat = TimeTable[RIT_DATEFORMAT];
            // ページフォーマット
            string pageformat = TimeTable[RIT_PAGEFORMAT];
            // ページ合計フォーマット
            string pageallformat = TimeTable[RIT_PAGEALLFORMAT];
            // 変換-日付
            if (dateformat != null) {
                if (dateformat.Trim().Length > 0) {
                    ret = ret.Replace(RIT_START_DATE, Document.Start.ToString(dateformat));
                    ret = ret.Replace(RIT_END_DATE, Document.End.ToString(dateformat));
                    ret = ret.Replace(RIT_PAGE_START_DATE, Page.Start.ToString(dateformat));
                    ret = ret.Replace(RIT_PAGE_END_DATE, Page.End.ToString(dateformat));
                } else {
                    ret = ret.Replace(RIT_START_DATE, Document.Start.ToString(RIT_DATEFORMAT_DEFAULT));
                    ret = ret.Replace(RIT_END_DATE, Document.End.ToString(RIT_DATEFORMAT_DEFAULT));
                    ret = ret.Replace(RIT_PAGE_START_DATE, Page.Start.ToString(RIT_DATEFORMAT_DEFAULT));
                    ret = ret.Replace(RIT_PAGE_END_DATE, Page.End.ToString(RIT_DATEFORMAT_DEFAULT));
                }
            } else {
                ret = ret.Replace(RIT_START_DATE, Document.Start.ToString(RIT_DATEFORMAT_DEFAULT));
                ret = ret.Replace(RIT_END_DATE, Document.End.ToString(RIT_DATEFORMAT_DEFAULT));
                ret = ret.Replace(RIT_PAGE_START_DATE, Page.Start.ToString(RIT_DATEFORMAT_DEFAULT));
                ret = ret.Replace(RIT_PAGE_END_DATE, Page.End.ToString(RIT_DATEFORMAT_DEFAULT));
            }
            // 変換-ページ
            if (pageformat != null) {
                if (pageformat.Trim().Length > 0) {
                    ret = ret.Replace(RIT_PAGE, Document.Index.ToString(pageformat));
                } else {
                    ret = ret.Replace(RIT_PAGE, Document.Index.ToString());
                }
            } else {
                ret = ret.Replace(RIT_PAGE, Document.Index.ToString());
            }
            // 変換-ページ数
            if (pageallformat != null) {
                if (pageallformat.Trim().Length > 0) {
                    ret = ret.Replace(RIT_PAGEALL, Document.PageCount.ToString(pageallformat));
                } else {
                    ret = ret.Replace(RIT_PAGEALL, Document.PageCount.ToString());
                }
            } else {
                ret = ret.Replace(RIT_PAGEALL, Document.PageCount.ToString());
            }
            // 終了
            return ret;
        }
        /// <summary>
        /// 左側のテキスト
        /// </summary>
        public string LeftText {
            get {
                string leftText = TimeTable[RIT_LEFTTEXT];
                if (leftText == null || leftText.Trim().Length == 0) {
                    leftText = RIT_LEFTTEXT_DEFAULT;
                }
                return FormatText2Text(leftText);
            }
        }
        /// <summary>
        /// 中央のテキスト
        /// </summary>
        public string CenterText {
            get {
                string centerText = TimeTable[RIT_CENTERTEXT];
                if (centerText == null || centerText.Trim().Length == 0) {
                    centerText = RIT_CENTERTEXT_DEFAULT;
                }
                return FormatText2Text(centerText);
            }
        }
        /// <summary>
        /// 右側のテキスト
        /// </summary>
        public string RightText {
            get {
                string centerText = TimeTable[RIT_RIGHTTEXT];
                if (centerText == null || centerText.Trim().Length == 0) {
                    centerText = RIT_RIGHTTEXT_DEFAULT;
                }
                return FormatText2Text(centerText);
            }
        }
        /// <summary>
        /// 高さ
        /// </summary>
        public float Height   {
            set {
                height = value;
            }
        }
        /// <summary>
        /// 高さ
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public float GetHeight (Graphics g) {
            // 左側
            SizeF LeftSize = g.MeasureString(LeftText, LeftFont);
            // 中央
            SizeF CenterSize = g.MeasureString(CenterText, CenterFont);
            // 右側
            SizeF RightSize = g.MeasureString(RightText, RightFont);
            //
            float ret = height;
            if (ret < LeftSize.Height) ret = LeftSize.Height;
            if (ret < CenterSize.Height) ret = CenterSize.Height;
            if (ret < RightSize.Height) ret = RightSize.Height;
            //
            return ret;
        }
        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Paint (Graphics g, PrintPageEventArgs e) {
            //Graphics g = e.Graphics;
            Rectangle mar = e.MarginBounds;
            float left = mar.Left;
            float top = mar.Top;
            float width = mar.Width;//e.PageSettings.PrintableArea.Width;
            float fheig = GetHeight(g);
            // 左側
            SizeF LeftSize = g.MeasureString(LeftText, LeftFont);
            PointF LeftPoint = new PointF(left, (fheig - LeftSize.Height) + top);
            RectangleF LeftAngle = new RectangleF(LeftPoint, LeftSize);
            g.DrawString(LeftText, LeftFont, LeftBrush, LeftAngle);
            // 中央
            SizeF CenterSize = g.MeasureString(CenterText, CenterFont);
            PointF CenterPoint = new PointF(left + (width - CenterSize.Width) / 2, (fheig - CenterSize.Height) + top);
            RectangleF CenterAngle = new RectangleF(CenterPoint, CenterSize);
            g.DrawString(CenterText, CenterFont, CenterBrush, CenterAngle);
            // 右側
            SizeF RightSize = g.MeasureString(RightText, RightFont);
            PointF RightPoint = new PointF(left + (width - RightSize.Width), (fheig - RightSize.Height) + top);
            RectangleF RightAngle = new RectangleF(RightPoint, RightSize);
            g.DrawString(RightText, RightFont, RightBrush, RightAngle);
        }
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public CTimeTable TimeTable {
            get { return timeTable; }
            set { 
                timeTable = value;
                if (timeTable != null) {
                }
            }
        }

    }
}
