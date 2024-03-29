using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using TimeTableManager.Element;

namespace TimeTableManager.Printing {
    /// <summary>印刷フッタ
    /// </summary>
    public class BPrintDocumentFooter {
        /// <summary>印刷機能のプロパティキー</summary>
        public const string RIT_FONT = "Printing.Footer.Font.Font";
        /// <summary>印刷機能のプロパティキー</summary>
        public const string RIT_COLUMN = "Printing.Footer.Int.Column";
        /// <summary>印刷機能のプロパティキー</summary>
        public const string RIT_FORMAT = "Printing.Footer.String.Format";
        /// <summary>印刷機能のデフォルト</summary>
        public const int RIT_COLUMN_DEFAULT = 2;
        /// <summary>印刷機能のデフォルト</summary>
        public const string RID_FORMAT_DEFAULT = "HH:mm";
        #region プライベート宣言
        /// <summary>高さ
        /// </summary>
        private float height = 0;
        /// <summary>色
        /// </summary>
        private Brush brush = Brushes.Black;
        /// <summary>タイムテーブル
        /// </summary>
        private BTimeTable timeTable;
        /// <summary>ドキュメント
        /// </summary>
        private BPrintDocumentBody document;
        #endregion
        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnCount {
            get {
                string column = TimeTable[BPrintDocumentFooter.RIT_COLUMN];
                int icolumn = BPrintDocumentFooter.RIT_COLUMN_DEFAULT;
                if (column != null) {
                    if (!(int.TryParse(column, out icolumn))) {
                        icolumn = BPrintDocumentFooter.RIT_COLUMN_DEFAULT;
                    }
                }
                return icolumn;
            }
        }
        /// <summary>
        /// ドキュメント
        /// </summary>
        public BPrintDocumentBody Document {
            get { return document; }
            set { document = value; }
        }
        /// <summary>
        /// 書式
        /// </summary>
        public string Format {
            get {
                // 書式
                string format = TimeTable[BPrintDocumentFooter.RIT_FORMAT];
                if (format == null) {
                    format = BPrintDocumentFooter.RID_FORMAT_DEFAULT;
                } else if (format.Trim().Length == 0) {
                    format = BPrintDocumentFooter.RID_FORMAT_DEFAULT;
                }
                return format;
            }
        }
        /// <summary>
        /// ブラシ
        /// </summary>        
        public Brush Brush {
            get { return brush; }
            set { brush = value; }
        }
        /// <summary>
        /// 左側フォント
        /// </summary>
        public Font Font {
            get {
                return BPrintDocumentBody.GetFont(TimeTable, RIT_FONT);
            }
        }
        /// <summary>
        /// 高さ
        /// </summary>
        public float Height {
            set {
                height = value;
            }
        }
        /// <summary>パターンの一覧
        /// </summary>
        public List<BPattern> Patterns {
            get {
                List<BPattern> ret = new List<BPattern>();
                int size = timeTable.Patterns.Size(true);
                for (int i = 0; i < size; i++) {
                    BPattern pattern = timeTable.Patterns[i, true];
                    if (!pattern.BuiltIn && pattern.IsAvailable(Document.Start, Document.End)) {
                        ret.Add(pattern);
                    }
                }
                return ret;
            }
        }
        /// <summary>
        /// 高さ
        /// </summary>
        /// <param name="g">グラフィックスオブジェクト</param>
        /// <returns>フッタの高さ</returns>
        public float GetHeight (Graphics g) {
            if (timeTable == null) return 0F;
            // 列数＊たて数＊(文字の高さ + 間隔)
            List<BPattern> patterns = Patterns;
            int PatternCount = patterns.Count;
            int row = 0, column = 0;
            float work = 0;
            float RowHeiht = 0;
            for (int count = 0; count < PatternCount; count++) {
                BPattern pattern = patterns[count];
                string text = pattern.Name + ":" + pattern.Start.ToString() + "～" + pattern.End.ToString();
                SizeF size = g.MeasureString(text, Font);
                if (column >= ColumnCount) {
                    // 改行
                    work += RowHeiht + 2;
                    row++;
                    column = 0;
                    RowHeiht = 0;
                }
                if (column == 0) {
                    RowHeiht = size.Height;
                } else if (RowHeiht < size.Height) {
                    RowHeiht = size.Height;
                }
                column++;
            }
            work += RowHeiht;
            return (height > work ? height : work);
        }
        /// <summary>描画
        /// </summary>
        /// <param name="g">グラフィックスオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public void Paint (Graphics g, PrintPageEventArgs e) {
            //Graphics g = e.Graphics;
            Rectangle mar = e.MarginBounds;
            float left = mar.Left;
            float bottom = mar.Bottom;
            float width = e.MarginBounds.Width;//e.PageSettings.PrintableArea.Width;
            float fheig = GetHeight(g);
            float top = bottom - fheig;
            // 作業用の列幅
            float ColumnWidth = width / ColumnCount;
            float LeftWidth = ColumnWidth / 2;
            float RigtWidth = ColumnWidth - LeftWidth;
            // 列数＊たて数
            List<BPattern> patterns = Patterns;
            int PatternCount = patterns.Count;
            int row = 0, column = 0;
            float work = 0;
            float RowHeiht = 0;
            // ":"のサイズ
            SizeF size2 = g.MeasureString(":", Font);
            for (int count = 0; count < PatternCount; count++) {
                BPattern pattern = patterns[count];
                // 行高さ設定
                SizeF size1 = g.MeasureString(pattern.Name, Font);
                //SizeF size2 = g.MeasureString(":", Font);
                DateTime wStart = DateTime.Today + pattern.Start;
                DateTime wEnd = DateTime.Today + pattern.End;
                string TimeText = wStart.ToString(Format) + "～" + wEnd.ToString(Format);
                SizeF size3 = g.MeasureString(TimeText, Font);
                SizeF size = size3;
                if (size.Height < size2.Height) {
                    size.Height = size2.Height;
                } else if (size.Height < size1.Height) {
                    size.Height = size1.Height;
                }
                if (column >= ColumnCount) {
                    // 改行
                    work += RowHeiht + 2;
                    row++;
                    column = 0;
                    RowHeiht = 0;
                }
                // 文字列をはいてみる (シフト名":"開始～終了)
                RectangleF rectf1 = new RectangleF(left + ColumnWidth * column, top + work, LeftWidth, size.Height);
                g.DrawString(pattern.Name, Font, Brush, rectf1);
                RectangleF rectf2 = new RectangleF(rectf1.Right, top + work, size2.Width, size.Height);
                g.DrawString(":", Font, Brush, rectf2);
                RectangleF rectf3 = new RectangleF(rectf2.Right, top + work, RigtWidth, size.Height);
                g.DrawString(TimeText, Font, Brush, rectf3);
                // 行の高さ設定
                if (column == 0) {
                    RowHeiht = size.Height;
                } else if (RowHeiht < size.Height) {
                    RowHeiht = size.Height;
                }
                column++;
            }
        }
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public BTimeTable TimeTable {
            get { return timeTable; }
            set {
                timeTable = value;
                if (timeTable != null) {
                }
            }
        }
    }
}
