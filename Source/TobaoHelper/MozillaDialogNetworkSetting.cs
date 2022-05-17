
// Type: TobaoHelper.MozillaDialogNetworkSetting
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TobaoHelper
{
  public class MozillaDialogNetworkSetting : Form
  {
    private IContainer components;
    private Button button1;
    private Button button2;
    private Button button3;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private RadioButton radioButton3;
    private GroupBox groupBox1;
    private RadioButton radioButton4;
    private Panel panel1;
    private CheckBox checkBox1;
    private NumericUpDown numericUpDown1;
    private Label label2;
    private TextBox textBox1;
    private Label label1;
    private CheckBox checkBox2;
    private RadioButton radioButton6;
    private RadioButton radioButton5;
    private NumericUpDown numericUpDown4;
    private Label label7;
    private TextBox textBox4;
    private Label label8;
    private NumericUpDown numericUpDown3;
    private Label label5;
    private TextBox textBox3;
    private Label label6;
    private NumericUpDown numericUpDown2;
    private Label label3;
    private TextBox textBox2;
    private Label label4;
    private TextBox textBox5;
    private Label label9;
    private Button button4;
    private TextBox textBox6;
    private RadioButton radioButton7;
    private Label label10;
    private CheckBox checkBox3;

    public MozillaDialogNetworkSetting()
    {
      this.InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void radioButton4_Click(object sender, EventArgs e)
    {
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
      this.panel1.Enabled = this.radioButton4.Checked;
      this.textBox6.Enabled = this.radioButton7.Checked;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void button3_Click(object sender, EventArgs e)
    {
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      this.panel1.Enabled = this.radioButton4.Checked;
      this.textBox6.Enabled = this.radioButton7.Checked;
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      this.panel1.Enabled = this.radioButton4.Checked;
      this.textBox6.Enabled = this.radioButton7.Checked;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      this.panel1.Enabled = this.radioButton4.Checked;
      this.textBox6.Enabled = this.radioButton7.Checked;
    }

    private void radioButton7_CheckedChanged(object sender, EventArgs e)
    {
      this.panel1.Enabled = this.radioButton4.Checked;
      this.textBox6.Enabled = this.radioButton7.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 488);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 487);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 488);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 27);
            this.button3.TabIndex = 3;
            this.button3.Text = "帮助(&H)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 24);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "不使用代理(&Y)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 49);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(190, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "自动检测此网络的代理设置(&W)";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(9, 74);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(139, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "使用系统代理设置(&U)";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.radioButton7);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Size = new System.Drawing.Size(420, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置访问国际互联网的代理";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(305, 405);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 26);
            this.button4.TabIndex = 25;
            this.button4.Text = "重新载入(&E)";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(39, 408);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(256, 23);
            this.textBox6.TabIndex = 24;
            // 
            // radioButton7
            // 
            this.radioButton7.AccessibleDescription = "";
            this.radioButton7.AccessibleName = "";
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(9, 388);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(157, 21);
            this.radioButton7.TabIndex = 23;
            this.radioButton7.Text = "自动代理配置（P&AC）：";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.radioButton6);
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.numericUpDown4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(11, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 259);
            this.panel1.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "例如:.mozilla.org,.net.nz,192.168.1.0/24";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(28, 177);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(363, 58);
            this.textBox5.TabIndex = 21;
            this.textBox5.Text = "localhost,127.0.0.1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "不使用代理：(&N)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(301, 129);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 21);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "远程 &DNS";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AccessibleDescription = "";
            this.radioButton6.AccessibleName = "";
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(208, 129);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(83, 21);
            this.radioButton6.TabIndex = 18;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "SOCKS &v5";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AccessibleDescription = "";
            this.radioButton5.AccessibleName = "";
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(115, 129);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(83, 21);
            this.radioButton5.TabIndex = 17;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "SOC&KS v4";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(338, 101);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(53, 23);
            this.numericUpDown4.TabIndex = 16;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "端口：(&T)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(115, 101);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(148, 23);
            this.textBox4.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "SO&CKS 代理：";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(338, 76);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(53, 23);
            this.numericUpDown3.TabIndex = 12;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "端口：(&R)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(115, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 23);
            this.textBox3.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "&FTP 代理：";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(338, 50);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(53, 23);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "端口：(&O)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 23);
            this.textBox2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "SS&L 代理：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(125, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "为所有协议使用相同代理(&S)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(338, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 23);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口：(&P)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "HTTP 代理：(&X)";
            // 
            // radioButton4
            // 
            this.radioButton4.AccessibleDescription = "";
            this.radioButton4.AccessibleName = "";
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(9, 100);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(130, 21);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "手动配置代理：(&M)";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            this.radioButton4.Click += new System.EventHandler(this.radioButton4_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(21, 460);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(219, 21);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "如果密码已保存，不提示身份验证(&I)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // MozillaDialogNetworkSetting
            // 
            this.ClientSize = new System.Drawing.Size(445, 549);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MozillaDialogNetworkSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
