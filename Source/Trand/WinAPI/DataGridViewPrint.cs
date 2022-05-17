
// Type: Trand.WinAPI.DataGridViewPrint
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Trand.WinAPI
{
  public class DataGridViewPrint
  {
    private string title = "";
    private int titleSize = 20;
    private Brush alertBrush = (Brush) new SolidBrush(Color.Red);
    public bool isEveryPagePrintTitle = true;
    public int headerHeight = 30;
    public int topMargin = 30;
    public int cellTopMargin = 6;
    public int cellLeftMargin = 4;
    public char splitChar = '#';
    public string falseStr = "×";
    public string trueStr = "√";
    public int pageRowCount = 30;
    public int rowGap = 28;
    public int colGap = 5;
    public int leftMargin = 45;
    public Font titleFont = new Font("黑体", 24f, FontStyle.Bold);
    public Font font = new Font("宋体", 10f);
    public Font headerFont = new Font("黑体", 11f, FontStyle.Bold);
    public Font footerFont = new Font("Arial", 8f);
    public Font upLineFont = new Font("Arial", 9f, FontStyle.Bold);
    public Font underLineFont = new Font("Arial", 8f);
    public Brush brush = (Brush) new SolidBrush(Color.Black);
    public bool isAutoPageRowCount = true;
    public int buttomMargin = 80;
    public bool needPrintPageIndex = true;
    private string sTongJi01 = "";
    private string sTongJi02 = "";
    private string sTongJi03 = "";
    private Font tongJiFont = new Font("宋体", 14f);
    private Font dateFont = new Font("宋体", 12f, FontStyle.Bold);
    private DataGridView dataGridView1;
    private PrintDocument printDocument;
    private PageSetupDialog pageSetupDialog;
    private PrintPreviewDialog printPreviewDialog;
    private int currentPageIndex;
    private int rowCount;
    private int pageCount;
    private bool isCustomHeader;
    private string[] header;
    private string[] uplineHeader;
    private int[] upLineHeaderIndex;
    public bool setTongji;
    private bool isTongji;
    private string time01;
    private string time02;

    public DataGridViewPrint(DataGridView dGView, string title, string times01, string times02, string tj01, string tj02, string tj03, bool tj)
    {
      this.title = title;
      this.sTongJi01 = tj01;
      this.sTongJi02 = tj02;
      this.sTongJi03 = tj03;
      this.time01 = times01;
      this.time02 = times02;
      this.setTongji = tj;
      this.dataGridView1 = dGView;
      this.printDocument = new PrintDocument();
      this.printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
    }

    public bool setTowLineHeader(string[] upLineHeader, int[] upLineHeaderIndex)
    {
      this.uplineHeader = upLineHeader;
      this.upLineHeaderIndex = upLineHeaderIndex;
      this.isCustomHeader = true;
      return true;
    }

    public bool setHeader(string[] header)
    {
      this.header = header;
      return true;
    }

    private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
      int width1 = e.PageBounds.Width;
      int height = e.PageBounds.Height;
      this.leftMargin = 40;
      if (this.isAutoPageRowCount)
        this.pageRowCount = (height - this.topMargin - this.titleSize - 25 - this.headerFont.Height - this.headerHeight - this.buttomMargin) / this.rowGap;
      this.pageCount = this.rowCount / this.pageRowCount;
      if (this.rowCount % this.pageRowCount > 0)
        ++this.pageCount;
      if (this.setTongji && this.pageCount == 1)
      {
        this.pageRowCount = (height - this.topMargin - this.titleSize - 25 - this.headerFont.Height - this.headerHeight - this.buttomMargin - 25) / this.rowGap;
        this.pageCount = this.rowCount / this.pageRowCount;
        if (this.rowCount % this.pageRowCount > 0)
          ++this.pageCount;
      }
      string str1 = this.time01 + " — " + this.time02;
      int num1 = (int) (((double) width1 - (double) e.Graphics.MeasureString(this.title, this.titleFont).Width) / 2.0);
      int num2 = (int) (((double) width1 - (double) e.Graphics.MeasureString(str1, this.dateFont).Width) / 2.0);
      int num3 = this.topMargin;
      int num4 = this.currentPageIndex * this.pageRowCount;
      int num5 = num4 + this.pageRowCount < this.rowCount ? num4 + this.pageRowCount : this.rowCount;
      int num6 = num5 - num4;
      if (this.currentPageIndex != 0)
      {
        if (!this.isEveryPagePrintTitle)
          goto label_10;
      }
      e.Graphics.DrawString(this.title, this.titleFont, this.brush, (float) num1, (float) num3);
      e.Graphics.DrawString(str1, this.dateFont, this.brush, (float) num2, (float) (num3 + 40));
      num3 += this.titleSize + 20;
label_10:
      try
      {
        int columnCount = this.dataGridView1.ColumnCount;
        int y1 = num3 + this.rowGap;
        int x1 = this.leftMargin;
        this.DrawLine(new Point(x1, y1), new Point(x1, y1 + num6 * this.rowGap + this.headerHeight), e.Graphics);
        int index1 = -1;
        int num7 = 0;
        int index2 = -1;
        for (int index3 = 0; index3 < columnCount; ++index3)
        {
          int width2 = this.dataGridView1.Columns[index3].Width;
          if (width2 > 0)
          {
            ++index2;
            string s1 = this.header == null || this.header[index2] == "" ? this.dataGridView1.Columns[index3].Name : this.header[index2];
            if (this.isCustomHeader)
            {
              if (this.upLineHeaderIndex[index2] != index1)
              {
                if (num7 > 0 && index1 > -1)
                {
                  string str2 = this.uplineHeader[index1];
                  int num8 = (int) (((double) num7 - (double) e.Graphics.MeasureString(str2, this.upLineFont).Width) / 2.0);
                  if (num8 < 0)
                    num8 = 0;
                  e.Graphics.DrawString(str2, this.upLineFont, this.brush, (float) (x1 - num7 + num8), (float) (y1 + this.cellTopMargin / 2));
                  this.DrawLine(new Point(x1 - num7, y1 + this.headerHeight / 2), new Point(x1, y1 + this.headerHeight / 2), e.Graphics);
                  this.DrawLine(new Point(x1, y1), new Point(x1, y1 + this.headerHeight / 2), e.Graphics);
                }
                index1 = this.upLineHeaderIndex[index2];
                num7 = width2 + this.colGap;
              }
              else
                num7 += width2 + this.colGap;
            }
            int length = s1.IndexOf(this.splitChar);
            if (this.upLineHeaderIndex != null && this.upLineHeaderIndex[index2] > -1)
            {
              if (length > 0)
              {
                string s2 = s1.Substring(0, length);
                string str2 = s1.Substring(length + 1, s1.Length - length - 1);
                int num8 = (int) ((double) (width2 + this.colGap) - (double) e.Graphics.MeasureString(str2, this.upLineFont).Width);
                int num9 = (int) ((double) (this.headerHeight / 2) - (double) e.Graphics.MeasureString("a", this.underLineFont).Height);
                int num10 = 6;
                int num11 = 10;
                e.Graphics.DrawString(str2, this.underLineFont, this.brush, (float) (x1 + num10 - 4), (float) (y1 + this.headerHeight / 2));
                e.Graphics.DrawString(s2, this.underLineFont, this.brush, (float) (x1 + 2), (float) (y1 + this.headerHeight / 2 + this.cellTopMargin / 2 + num11 - 2));
                this.DrawLine(new Point(x1, y1 + this.headerHeight / 2), new Point(x1 + width2 + this.colGap, y1 + this.headerHeight), e.Graphics);
                x1 += width2 + this.colGap;
                this.DrawLine(new Point(x1, y1 + this.headerHeight / 2), new Point(x1, y1 + num6 * this.rowGap + this.headerHeight), e.Graphics);
              }
              else
              {
                e.Graphics.DrawString(s1, this.headerFont, this.brush, (float) x1, (float) (y1 + this.headerHeight / 2 + this.cellTopMargin / 2));
                x1 += width2 + this.colGap;
                this.DrawLine(new Point(x1, y1 + this.headerHeight / 2), new Point(x1, y1 + num6 * this.rowGap + this.headerHeight), e.Graphics);
              }
            }
            else if (length > 0)
            {
              string s2 = s1.Substring(0, length);
              string str2 = s1.Substring(length + 1, s1.Length - length - 1);
              int num8 = (int) ((double) (width2 + this.colGap) - (double) e.Graphics.MeasureString(str2, this.upLineFont).Width);
              int num9 = (int) ((double) this.headerHeight - (double) e.Graphics.MeasureString("a", this.underLineFont).Height);
              e.Graphics.DrawString(str2, this.headerFont, this.brush, (float) (x1 + num8 - 4), (float) (y1 + 2));
              e.Graphics.DrawString(s2, this.headerFont, this.brush, (float) (x1 + 2), (float) (y1 + num9 - 4));
              this.DrawLine(new Point(x1, y1), new Point(x1 + width2 + this.colGap, y1 + this.headerHeight), e.Graphics);
              x1 += width2 + this.colGap;
              this.DrawLine(new Point(x1, y1), new Point(x1, y1 + num6 * this.rowGap + this.headerHeight), e.Graphics);
            }
            else
            {
              e.Graphics.DrawString(s1, this.headerFont, this.brush, (float) x1, (float) (y1 + this.cellTopMargin));
              x1 += width2 + this.colGap;
              this.DrawLine(new Point(x1, y1), new Point(x1, y1 + num6 * this.rowGap + this.headerHeight), e.Graphics);
            }
          }
        }
        if (this.isCustomHeader && num7 > 0 && index1 > -1)
        {
          string str2 = this.uplineHeader[index1];
          int num8 = (int) (((double) num7 - (double) e.Graphics.MeasureString(str2, this.upLineFont).Width) / 2.0);
          if (num8 < 0)
            num8 = 0;
          e.Graphics.DrawString(str2, this.upLineFont, this.brush, (float) (x1 - num7 + num8), (float) (y1 + this.cellTopMargin / 2));
          this.DrawLine(new Point(x1 - num7, y1 + this.headerHeight / 2), new Point(x1, y1 + this.headerHeight / 2), e.Graphics);
          this.DrawLine(new Point(x1, y1), new Point(x1, y1 + this.headerHeight / 2), e.Graphics);
        }
        int x2 = x1;
        this.DrawLine(new Point(this.leftMargin, y1), new Point(x2, y1), e.Graphics);
        int y2 = y1 + this.headerHeight;
        for (int index3 = num4; index3 < num5; ++index3)
        {
          int num8 = this.leftMargin;
          for (int index4 = 0; index4 < columnCount; ++index4)
          {
            if (this.dataGridView1.Columns[index4].Width > 0)
            {
              string s = this.dataGridView1.Rows[index3].Cells[index4].Value.ToString();
              if (s == "False")
                s = this.falseStr;
              if (s == "True")
                s = this.trueStr;
              e.Graphics.DrawString(s, this.font, this.brush, (float) (num8 + this.cellLeftMargin), (float) (y2 + this.cellTopMargin));
              num8 += this.dataGridView1.Columns[index4].Width + this.colGap;
              y2 += this.rowGap * (s.Split(new char[2]
              {
                '\r',
                '\n'
              }).Length - 1);
            }
          }
          this.DrawLine(new Point(this.leftMargin, y2), new Point(x2, y2), e.Graphics);
          y2 += this.rowGap;
        }
        this.DrawLine(new Point(this.leftMargin, y2), new Point(x2, y2), e.Graphics);
        ++this.currentPageIndex;
        if (this.setTongji && this.currentPageIndex == this.pageCount)
          this.isTongji = true;
        if (this.isTongji)
        {
          int num8 = (int) (((double) width1 - (double) e.Graphics.MeasureString(this.sTongJi01, this.dateFont).Width) / 2.0);
          e.Graphics.DrawString(this.sTongJi01, this.tongJiFont, this.brush, (float) num8, (float) (y2 + 25));
          e.Graphics.DrawString(this.sTongJi02, this.tongJiFont, this.brush, (float) num8, (float) (y2 + 50));
          e.Graphics.DrawString(this.sTongJi03, this.tongJiFont, this.brush, (float) (num8 + 340), (float) (y2 + 50));
        }
        if (this.needPrintPageIndex && this.pageCount != 1)
          e.Graphics.DrawString("共 " + this.pageCount.ToString() + " 页,当前第 " + this.currentPageIndex.ToString() + " 页", this.footerFont, this.brush, (float) (width1 - 200), (float) (height - this.buttomMargin / 2 - this.footerFont.Height));
        if (this.currentPageIndex < this.pageCount)
        {
          e.HasMorePages = true;
        }
        else
        {
          e.HasMorePages = false;
          this.currentPageIndex = 0;
        }
      }
      catch
      {
      }
    }

    private void DrawLine(Point sp, Point ep, Graphics gp)
    {
      Pen pen = new Pen(Color.Black);
      gp.DrawLine(pen, sp, ep);
    }

    public PrintDocument GetPrintDocument()
    {
      return this.printDocument;
    }

    public void Print()
    {
      this.rowCount = 0;
      try
      {
        if (this.dataGridView1.DataSource.GetType().ToString() == "System.Data.DataSet")
          this.rowCount = ((DataSet) this.dataGridView1.DataSource).Tables[0].Rows.Count;
        else if (this.dataGridView1.DataSource.GetType().ToString() == "System.Data.DataView")
          this.rowCount = ((DataView) this.dataGridView1.DataSource).Count;
        this.pageSetupDialog = new PageSetupDialog();
        this.pageSetupDialog.AllowOrientation = true;
        this.pageSetupDialog.Document = this.printDocument;
        this.pageSetupDialog.Document.DefaultPageSettings.Landscape = true;
        int num1 = (int) this.pageSetupDialog.ShowDialog();
        this.printPreviewDialog = new PrintPreviewDialog();
        this.printPreviewDialog.Document = this.printDocument;
        this.printPreviewDialog.Height = 600;
        this.printPreviewDialog.Width = 800;
        this.printPreviewDialog.ClientSize = new Size(1024, 768);
        this.printPreviewDialog.PrintPreviewControl.Zoom = 1.0;
        int num2 = (int) this.printPreviewDialog.ShowDialog();
      }
      catch
      {
      }
    }
  }
}
