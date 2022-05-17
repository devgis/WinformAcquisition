
// Type: Trand.WinAPI.DrawGraph
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Drawing;
using System.Windows.Forms;

namespace Trand.WinAPI
{
  public class DrawGraph
  {
    public void BrokenLineGraph(Panel panel, int[] array, float distance, int interval, Color color, Brush b)
    {
      Graphics graphics = panel.CreateGraphics();
      int num1 = panel.Height - 5;
      Pen pen1 = new Pen(color);
      Pen pen2 = new Pen(b);
      int num2 = 3;
      float num3 = (float) ((double) array[0] + 1.0 * (double) distance + 1.0);
      float num4 = (float) (num1 - array[0] * interval - 1);
      graphics.DrawEllipse(pen2, num3, num4, (float) num2, (float) num2);
      graphics.FillEllipse(b, num3, num4, (float) num2, (float) num2);
      for (int index = 1; index < array.Length; ++index)
      {
        graphics.DrawLine(pen1, num3, num4, (float) array[index] + (float) (index + 1) * distance, (float) (num1 - array[index] * interval));
        graphics.DrawEllipse(pen2, (float) array[index] + (float) (index + 1) * distance, (float) (num1 - array[index] * interval), (float) num2, (float) num2);
        graphics.FillEllipse(b, (float) array[index] + (float) (index + 1) * distance, (float) (num1 - array[index] * interval), (float) num2, (float) num2);
        num3 = (float) ((double) array[index] + (double) (index + 1) * (double) distance + 1.0);
        num4 = (float) (num1 - array[index] * interval - 1);
      }
    }

    public void BrokenLineGraph(Panel panel, float[] array, float distance, int interval, Color color, Brush b)
    {
      Graphics graphics = panel.CreateGraphics();
      int num1 = panel.Height - 5;
      Pen pen1 = new Pen(color);
      Pen pen2 = new Pen(b);
      int num2 = 3;
      float num3 = (float) ((double) array[0] + 1.0 * (double) distance + 1.0);
      float num4 = (float) ((double) num1 - (double) array[0] * (double) interval - 1.0);
      graphics.DrawEllipse(pen2, num3, num4, (float) num2, (float) num2);
      graphics.FillEllipse(b, num3, num4, (float) num2, (float) num2);
      for (int index = 1; index < array.Length; ++index)
      {
        graphics.DrawLine(pen1, num3, num4, array[index] + (float) (index + 1) * distance, (float) num1 - array[index] * (float) interval);
        graphics.DrawEllipse(pen2, array[index] + (float) (index + 1) * distance, (float) num1 - array[index] * (float) interval, (float) num2, (float) num2);
        graphics.FillEllipse(b, array[index] + (float) (index + 1) * distance, (float) num1 - array[index] * (float) interval, (float) num2, (float) num2);
        num3 = (float) ((double) array[index] + (double) (index + 1) * (double) distance + 1.0);
        num4 = (float) ((double) num1 - (double) array[index] * (double) interval - 1.0);
      }
    }

    public void BarGraph(Panel panel, int[] array, int width, float distance, int interval, Color color, Brush b)
    {
      Graphics graphics = panel.CreateGraphics();
      int num = panel.Height - 5;
      Pen pen = new Pen(b);
      int x = 5;
      for (int index = 0; index < array.Length; ++index)
      {
        graphics.DrawRectangle(pen, x, num - array[index] * interval, width, num - (num - array[index] * interval));
        graphics.FillRectangle(b, x, num - array[index] * interval, width, num - (num - array[index] * interval));
        x += width + interval;
      }
    }

    public void BarGraph(Panel panel, float[] array, int width, float distance, int interval, Color color, Brush b)
    {
      Graphics graphics = panel.CreateGraphics();
      int num1 = panel.Height - 5;
      Pen pen = new Pen(b);
      int num2 = 5;
      for (int index = 0; index < array.Length; ++index)
      {
        graphics.DrawRectangle(pen, (float) num2, (float) num1 - array[index] * (float) interval, (float) width, (float) num1 - ((float) num1 - array[index] * (float) interval));
        graphics.FillRectangle(b, (float) num2, (float) num1 - array[index] * (float) interval, (float) width, (float) num1 - ((float) num1 - array[index] * (float) interval));
        num2 += width + interval;
      }
    }

    private void DrawPies(Graphics AGraphics, Rectangle ARect, params DrawGraph.PieInfo[] APies)
    {
      if (AGraphics == null)
        return;
      uint num = 0U;
      for (int index = 0; index < APies.Length; ++index)
      {
        DrawGraph.PieInfo pieInfo = APies[index];
        num += pieInfo.Number;
      }
      float startAngle = 0.0f;
      int y = 0;
      int x = ARect.Width + 10;
      for (int index = 0; index < APies.Length; ++index)
      {
        DrawGraph.PieInfo pieInfo = APies[index];
        if ((int) pieInfo.Number != 0)
        {
          float sweepAngle = (float) (pieInfo.Number / num) * 360f;
          AGraphics.FillPie((Brush) new SolidBrush(pieInfo.Color), ARect, startAngle, sweepAngle);
          AGraphics.DrawRectangle(new Pen(pieInfo.Color), x, y, 10, 5);
          AGraphics.FillRectangle((Brush) new SolidBrush(pieInfo.Color), x, y, 20, 10);
          AGraphics.DrawString(pieInfo.Text, new Font("微软雅黑", 10f), Brushes.Black, new PointF((float) (x + 20), (float) (y - 5)));
          startAngle += sweepAngle;
          y += 15;
        }
      }
    }

    public void DrawPie(int width, int height, Control c, params DrawGraph.PieInfo[] APies)
    {
      Graphics graphics = c.CreateGraphics();
      this.DrawPies(graphics, new Rectangle(0, 0, width, height), APies);
      graphics.Dispose();
    }

    public struct PieInfo
    {
      public Color Color;
      public uint Number;
      public string Text;

      public PieInfo(Color AColor, uint ANumber, string AString)
      {
        this.Color = AColor;
        this.Number = ANumber;
        this.Text = AString;
      }
    }
  }
}
