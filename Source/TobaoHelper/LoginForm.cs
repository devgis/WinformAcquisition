
// Type: TobaoHelper.LoginForm
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using IEProxyManagment;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TrandExp.DotNet.Utils;
using ZCB_APILib;

namespace TobaoHelper
{
  public class LoginForm : Form
  {
    private ZCBApiPlugClass oZCB;
    private string szRet;
    private IContainer components;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private Button button8;
    private Button button1;
    private TextBox textBoxPWD;
    private TextBox textBoxUser;
    private Label label1;
    private TabPage tabPage2;
    private Button button3;
    private Button button2;
    private TextBox textBoxRechargeNumber;
    private TextBox textBoxRechargeUser;
    private Label label2;
    private TabPage tabPage3;
    private Button button4;
    private TextBox textBoxRegQQ;
    private TextBox textBoxConfirmRegPWD;
    private TextBox textBoxRegPWD;
    private TextBox textBoxRegEamil;
    private TextBox textBoxRegUser;
    private Label label3;
    private TabPage tabPage4;
    private Button button5;
    private TextBox textBoxChangeConfirmPWD;
    private TextBox textBoxChangeNewPWD;
    private TextBox textBoxChangePWD;
    private TextBox textBoxChangeUser;
    private Label label4;
    private TabPage tabPage5;
    private Button button6;
    private TextBox textBoxFindEmail;
    private TextBox textBoxFindUser;
    private Label label5;
    private TabPage tabPage6;
    private Button button7;
    private TextBox textBoxLeaveWord;
    private TextBox textBoxLeaveQQ;
    private TextBox textBoxLeaveUser;
    private Label label6;
    private TabPage tabPage7;
    private Button button9;
    private CheckBox checkBox1;

    public LoginForm()
    {
      this.InitializeComponent();
    }

    public static void RunCommand(string szCommand)
    {
      Process process = new Process();
      process.StartInfo.FileName = "cmd.exe";
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      process.StandardInput.WriteLine(szCommand);
      process.StandardInput.WriteLine("exit");
      process.Close();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
      LoginForm.RunCommand(string.Format("regsvr32.exe {0:%s}ZCB_API.dll /s", (object) AppDomain.CurrentDomain.BaseDirectory.ToString()));
      this.oZCB = new ZCBApiPlugClass();
      if (this.oZCB.AppInitialize("1AF782A8-0E8E-41AE-80EE-82C415EB326F", "Z1027175", 0) != 1)
      {
        int num = (int) MessageBox.Show("初始化失败");
        Environment.Exit(0);
      }
      this.Upgrade();
      this.Announcement();
      IniFile iniFile = new IniFile("config.ini");
      this.textBoxUser.Text = iniFile.ReadString("UserSettings", "User", "");
      this.textBoxPWD.Text = iniFile.ReadString("UserSettings", "PWD", "");
    }

    private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.oZCB.API_LoginOut();
      this.oZCB = (ZCBApiPlugClass) null;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.szRet = this.oZCB.API_Login(this.textBoxUser.Text, this.textBoxPWD.Text);
      if (this.szRet == "992001")
      {
        this.szRet = this.oZCB.API_GetExpTime();
        if (this.szRet.Length <= 6 || !(this.szRet.Remove(6) == "992001"))
          return;
        IniFile iniFile = new IniFile("config.ini");
        iniFile.WriteString("UserSettings", "User", this.textBoxUser.Text);
        iniFile.WriteString("UserSettings", "PWD", this.textBoxPWD.Text);
        this.DialogResult = DialogResult.OK;
      }
      else
      {
        int num = (int) MessageBox.Show(this.codeDescription(this.szRet));
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      this.szRet = this.oZCB.API_QQLogin();
      if (this.szRet.Length > 6 && this.szRet.Remove(6) == "992001")
      {
        this.szRet = this.oZCB.API_GetExpTime();
        if (this.szRet.Length <= 6 || !(this.szRet.Remove(6) == "992001"))
          return;
        int num = (int) MessageBox.Show("登录成功,到期时间:" + this.szRet.Replace("992001:", ""));
      }
      else
      {
        int num1 = (int) MessageBox.Show(this.codeDescription(this.szRet));
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.szRet = this.oZCB.API_Recharge(this.textBoxRechargeUser.Text, this.textBoxRechargeNumber.Text);
      if (this.szRet.Length > 6 && this.szRet.Remove(6) == "992001")
      {
        int num1 = (int) MessageBox.Show("充值成功,到期时间:" + this.szRet.Replace("992001:", ""));
      }
      else
      {
        int num2 = (int) MessageBox.Show(this.codeDescription(this.szRet));
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(this.codeDescription(this.oZCB.API_Register(this.textBoxRegUser.Text, this.textBoxRegEamil.Text, this.textBoxRegPWD.Text, this.textBoxConfirmRegPWD.Text, this.textBoxRegQQ.Text)));
    }

    private void tabPage4_Click(object sender, EventArgs e)
    {
    }

    private void button5_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(this.codeDescription(this.oZCB.API_ChangePWD(this.textBoxChangeUser.Text, this.textBoxChangePWD.Text, this.textBoxChangeNewPWD.Text, this.textBoxChangeConfirmPWD.Text)));
    }

    private void button6_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(this.codeDescription(this.oZCB.API_FindPassword(this.textBoxFindUser.Text, this.textBoxFindEmail.Text)));
    }

    private void button7_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(this.codeDescription(this.oZCB.API_LeaveWord(this.textBoxLeaveUser.Text, this.textBoxLeaveQQ.Text, this.textBoxLeaveWord.Text)));
    }

    private void Upgrade()
    {
      this.szRet = this.oZCB.API_Upgrade(1);
      if (this.szRet.Length <= 6 || !(this.szRet.Remove(6) == "992001"))
        return;
      this.szRet = this.szRet.Replace("992001:", "");
      string[] strArray = this.szRet.Split("|".ToCharArray());
      if (strArray[2] == "1")
      {
        if (MessageBox.Show(strArray[4], strArray[3], MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        this.oZCB.API_Upgrade(2);
        Environment.Exit(0);
      }
      else
      {
        int num = (int) MessageBox.Show(strArray[4], strArray[3], MessageBoxButtons.OK);
        this.oZCB.API_Upgrade(2);
        Environment.Exit(0);
      }
    }

    private void Announcement()
    {
      this.szRet = this.oZCB.API_Announcement();
      if (this.szRet.Length <= 6 || !(this.szRet.Remove(6) == "992001"))
        return;
      this.szRet = this.szRet.Replace("992001:", "");
      string[] strArray = this.szRet.Split("|".ToCharArray());
      int num = (int) MessageBox.Show(strArray[1], strArray[0], MessageBoxButtons.OK);
    }

    private string codeDescription(string szRet)
    {
      switch (Convert.ToInt32(szRet))
      {
        case 994031:
          return "只允许终端用户使用";
        case 994032:
          return "您的账号已经在其他机器上登录";
        case 994033:
          return "您的账号已经下线";
        case 994034:
          return "客户端异常";
        case 994035:
          return "禁止使用该接口";
        case 994036:
          return "未设置过密码";
        case 994037:
          return "安全码不正确";
        case 994041:
          return "用户名不存在";
        case 994042:
          return "软件编号不存在";
        case 994043:
          return "未绑定软件";
        case 994061:
          return "用户名格式不对";
        case 994062:
          return "密码格式不正确";
        case 994063:
          return "软件处理停用状态";
        case 995001:
          return "服务器异常";
        case 995002:
          return "邮件无法发送";
        case 995003:
          return "随机数校验失败";
        case 995004:
          return "参数错误";
        case 992001:
          return "操作成功";
        case 994001:
          return "网络异常";
        case 314041:
          return "没有新公告";
        case 414041:
          return "没有新版本";
        case 982021:
          return "软件使用时间已到";
        case 982022:
          return "客户端校验失败";
        case 304041:
          return "充值卡不存在";
        case 304101:
          return "充值卡已经使用过";
        case 304102:
          return "充值卡目前无法使用";
        case 224041:
          return "邮箱错误";
        case 234001:
          return "解绑失败";
        case 244031:
          return "留言内容非法";
        case 244032:
          return "QQ格式不正确";
        case 214041:
          return "旧密码不正确";
        case 214061:
          return "新密码不正确";
        case 214062:
          return "密码输入不一致";
        case 114041:
          return "邮箱和账号不匹配";
        case 204031:
          return "用户名或密码错误";
        case 204032:
          return "账号处于冻结状态";
        case 204033:
          return "账号未审核通过";
        case 204034:
          return "软件不允许试用";
        case 204035:
          return "已经达到本日试用次数上限";
        case 204036:
          return "登录失败";
        case 204037:
          return "会话已失效，请重新登录";
        case 204038:
          return "账号在该软件下的使用权被作者冻结了";
        case 204044:
          return "账号状态异常";
        case 102021:
          return "用户名已经存在";
        case 102022:
          return "邮箱已经存在";
        case 104062:
          return "QQ格式不正确";
        default:
          return "未定义错误返回码:" + szRet;
      }
    }

    private void button9_Click(object sender, EventArgs e)
    {
      IEProxySetting.UnsetProxy();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LoginForm));
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.checkBox1 = new CheckBox();
      this.button8 = new Button();
      this.button1 = new Button();
      this.textBoxPWD = new TextBox();
      this.textBoxUser = new TextBox();
      this.label1 = new Label();
      this.tabPage2 = new TabPage();
      this.button3 = new Button();
      this.button2 = new Button();
      this.textBoxRechargeNumber = new TextBox();
      this.textBoxRechargeUser = new TextBox();
      this.label2 = new Label();
      this.tabPage3 = new TabPage();
      this.button4 = new Button();
      this.textBoxRegQQ = new TextBox();
      this.textBoxConfirmRegPWD = new TextBox();
      this.textBoxRegPWD = new TextBox();
      this.textBoxRegEamil = new TextBox();
      this.textBoxRegUser = new TextBox();
      this.label3 = new Label();
      this.tabPage4 = new TabPage();
      this.button5 = new Button();
      this.textBoxChangeConfirmPWD = new TextBox();
      this.textBoxChangeNewPWD = new TextBox();
      this.textBoxChangePWD = new TextBox();
      this.textBoxChangeUser = new TextBox();
      this.label4 = new Label();
      this.tabPage5 = new TabPage();
      this.button6 = new Button();
      this.textBoxFindEmail = new TextBox();
      this.textBoxFindUser = new TextBox();
      this.label5 = new Label();
      this.tabPage6 = new TabPage();
      this.button7 = new Button();
      this.textBoxLeaveWord = new TextBox();
      this.textBoxLeaveQQ = new TextBox();
      this.textBoxLeaveUser = new TextBox();
      this.label6 = new Label();
      this.tabPage7 = new TabPage();
      this.button9 = new Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.tabPage7.SuspendLayout();
      this.SuspendLayout();
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Controls.Add((Control) this.tabPage4);
      this.tabControl1.Controls.Add((Control) this.tabPage5);
      this.tabControl1.Controls.Add((Control) this.tabPage6);
      this.tabControl1.Controls.Add((Control) this.tabPage7);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(470, 306);
      this.tabControl1.TabIndex = 1;
      this.tabPage1.Controls.Add((Control) this.checkBox1);
      this.tabPage1.Controls.Add((Control) this.button8);
      this.tabPage1.Controls.Add((Control) this.button1);
      this.tabPage1.Controls.Add((Control) this.textBoxPWD);
      this.tabPage1.Controls.Add((Control) this.textBoxUser);
      this.tabPage1.Controls.Add((Control) this.label1);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(462, 280);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "账号登录";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(110, 122);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(72, 16);
      this.checkBox1.TabIndex = 5;
      this.checkBox1.Text = "记住密码";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.button8.Location = new Point(214, 163);
      this.button8.Name = "button8";
      this.button8.Size = new Size(75, 23);
      this.button8.TabIndex = 4;
      this.button8.Text = "QQ登录";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button1.Location = new Point(110, 163);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "登录";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.textBoxPWD.Location = new Point(110, 79);
      this.textBoxPWD.Name = "textBoxPWD";
      this.textBoxPWD.Size = new Size(164, 21);
      this.textBoxPWD.TabIndex = 2;
      this.textBoxPWD.UseSystemPasswordChar = true;
      this.textBoxUser.Location = new Point(110, 43);
      this.textBoxUser.Name = "textBoxUser";
      this.textBoxUser.Size = new Size(164, 21);
      this.textBoxUser.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(45, 46);
      this.label1.Name = "label1";
      this.label1.Size = new Size(41, 48);
      this.label1.TabIndex = 0;
      this.label1.Text = "用户名\r\n\r\n\r\n密码";
      this.tabPage2.Controls.Add((Control) this.button3);
      this.tabPage2.Controls.Add((Control) this.button2);
      this.tabPage2.Controls.Add((Control) this.textBoxRechargeNumber);
      this.tabPage2.Controls.Add((Control) this.textBoxRechargeUser);
      this.tabPage2.Controls.Add((Control) this.label2);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(462, 280);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "账号充值";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.button3.Location = new Point(191, 145);
      this.button3.Name = "button3";
      this.button3.Size = new Size(75, 23);
      this.button3.TabIndex = 4;
      this.button3.Text = "在线充值";
      this.button3.UseVisualStyleBackColor = true;
      this.button2.Location = new Point(72, 145);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "卡号充值";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.textBoxRechargeNumber.Location = new Point(107, 74);
      this.textBoxRechargeNumber.Name = "textBoxRechargeNumber";
      this.textBoxRechargeNumber.Size = new Size(173, 21);
      this.textBoxRechargeNumber.TabIndex = 2;
      this.textBoxRechargeUser.Location = new Point(107, 44);
      this.textBoxRechargeUser.Name = "textBoxRechargeUser";
      this.textBoxRechargeUser.Size = new Size(173, 21);
      this.textBoxRechargeUser.TabIndex = 1;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(47, 47);
      this.label2.Name = "label2";
      this.label2.Size = new Size(41, 48);
      this.label2.TabIndex = 0;
      this.label2.Text = "用户名\r\n\r\n\r\n充值卡";
      this.tabPage3.Controls.Add((Control) this.button4);
      this.tabPage3.Controls.Add((Control) this.textBoxRegQQ);
      this.tabPage3.Controls.Add((Control) this.textBoxConfirmRegPWD);
      this.tabPage3.Controls.Add((Control) this.textBoxRegPWD);
      this.tabPage3.Controls.Add((Control) this.textBoxRegEamil);
      this.tabPage3.Controls.Add((Control) this.textBoxRegUser);
      this.tabPage3.Controls.Add((Control) this.label3);
      this.tabPage3.Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new Size(462, 280);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "注册账号";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.button4.Location = new Point(121, 208);
      this.button4.Name = "button4";
      this.button4.Size = new Size(75, 23);
      this.button4.TabIndex = 6;
      this.button4.Text = "注册";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.textBoxRegQQ.Location = new Point(121, 165);
      this.textBoxRegQQ.Name = "textBoxRegQQ";
      this.textBoxRegQQ.Size = new Size(166, 21);
      this.textBoxRegQQ.TabIndex = 5;
      this.textBoxConfirmRegPWD.Location = new Point(121, 132);
      this.textBoxConfirmRegPWD.Name = "textBoxConfirmRegPWD";
      this.textBoxConfirmRegPWD.Size = new Size(166, 21);
      this.textBoxConfirmRegPWD.TabIndex = 4;
      this.textBoxConfirmRegPWD.UseSystemPasswordChar = true;
      this.textBoxRegPWD.Location = new Point(121, 98);
      this.textBoxRegPWD.Name = "textBoxRegPWD";
      this.textBoxRegPWD.Size = new Size(166, 21);
      this.textBoxRegPWD.TabIndex = 3;
      this.textBoxRegPWD.UseSystemPasswordChar = true;
      this.textBoxRegEamil.Location = new Point(121, 60);
      this.textBoxRegEamil.Name = "textBoxRegEamil";
      this.textBoxRegEamil.Size = new Size(166, 21);
      this.textBoxRegEamil.TabIndex = 2;
      this.textBoxRegUser.Location = new Point(121, 28);
      this.textBoxRegUser.Name = "textBoxRegUser";
      this.textBoxRegUser.Size = new Size(166, 21);
      this.textBoxRegUser.TabIndex = 1;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(43, 30);
      this.label3.Name = "label3";
      this.label3.Size = new Size(53, 156);
      this.label3.TabIndex = 0;
      this.label3.Text = "用户名\r\n\r\n\r\n邮箱\r\n\r\n\r\n密码\r\n\r\n\r\n确认密码\r\n\r\n\r\nQQ";
      this.tabPage4.Controls.Add((Control) this.button5);
      this.tabPage4.Controls.Add((Control) this.textBoxChangeConfirmPWD);
      this.tabPage4.Controls.Add((Control) this.textBoxChangeNewPWD);
      this.tabPage4.Controls.Add((Control) this.textBoxChangePWD);
      this.tabPage4.Controls.Add((Control) this.textBoxChangeUser);
      this.tabPage4.Controls.Add((Control) this.label4);
      this.tabPage4.Location = new Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new Size(462, 280);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "修改密码";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.tabPage4.Click += new EventHandler(this.tabPage4_Click);
      this.button5.Location = new Point(131, 175);
      this.button5.Name = "button5";
      this.button5.Size = new Size(75, 23);
      this.button5.TabIndex = 5;
      this.button5.Text = "立即修改";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.textBoxChangeConfirmPWD.Location = new Point(119, 124);
      this.textBoxChangeConfirmPWD.Name = "textBoxChangeConfirmPWD";
      this.textBoxChangeConfirmPWD.Size = new Size(171, 21);
      this.textBoxChangeConfirmPWD.TabIndex = 4;
      this.textBoxChangeConfirmPWD.UseSystemPasswordChar = true;
      this.textBoxChangeNewPWD.Location = new Point(119, 88);
      this.textBoxChangeNewPWD.Name = "textBoxChangeNewPWD";
      this.textBoxChangeNewPWD.Size = new Size(171, 21);
      this.textBoxChangeNewPWD.TabIndex = 3;
      this.textBoxChangeNewPWD.UseSystemPasswordChar = true;
      this.textBoxChangePWD.Location = new Point(119, 52);
      this.textBoxChangePWD.Name = "textBoxChangePWD";
      this.textBoxChangePWD.Size = new Size(171, 21);
      this.textBoxChangePWD.TabIndex = 2;
      this.textBoxChangePWD.UseSystemPasswordChar = true;
      this.textBoxChangeUser.Location = new Point(119, 19);
      this.textBoxChangeUser.Name = "textBoxChangeUser";
      this.textBoxChangeUser.Size = new Size(171, 21);
      this.textBoxChangeUser.TabIndex = 1;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(37, 19);
      this.label4.Name = "label4";
      this.label4.Size = new Size(65, 120);
      this.label4.TabIndex = 0;
      this.label4.Text = "用户名\r\n\r\n\r\n旧密码\r\n\r\n\r\n新密码\r\n\r\n\r\n确认新密码";
      this.tabPage5.Controls.Add((Control) this.button6);
      this.tabPage5.Controls.Add((Control) this.textBoxFindEmail);
      this.tabPage5.Controls.Add((Control) this.textBoxFindUser);
      this.tabPage5.Controls.Add((Control) this.label5);
      this.tabPage5.Location = new Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Size = new Size(462, 280);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "找回密码";
      this.tabPage5.UseVisualStyleBackColor = true;
      this.button6.Location = new Point(121, 145);
      this.button6.Name = "button6";
      this.button6.Size = new Size(75, 23);
      this.button6.TabIndex = 3;
      this.button6.Text = "立即找回";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.textBoxFindEmail.Location = new Point(126, 55);
      this.textBoxFindEmail.Name = "textBoxFindEmail";
      this.textBoxFindEmail.Size = new Size(160, 21);
      this.textBoxFindEmail.TabIndex = 2;
      this.textBoxFindUser.Location = new Point(126, 23);
      this.textBoxFindUser.Name = "textBoxFindUser";
      this.textBoxFindUser.Size = new Size(160, 21);
      this.textBoxFindUser.TabIndex = 1;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(67, 23);
      this.label5.Name = "label5";
      this.label5.Size = new Size(41, 48);
      this.label5.TabIndex = 0;
      this.label5.Text = "用户名\r\n\r\n\r\n邮箱";
      this.tabPage6.Controls.Add((Control) this.button7);
      this.tabPage6.Controls.Add((Control) this.textBoxLeaveWord);
      this.tabPage6.Controls.Add((Control) this.textBoxLeaveQQ);
      this.tabPage6.Controls.Add((Control) this.textBoxLeaveUser);
      this.tabPage6.Controls.Add((Control) this.label6);
      this.tabPage6.Location = new Point(4, 22);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Size = new Size(462, 280);
      this.tabPage6.TabIndex = 5;
      this.tabPage6.Text = "留言";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.button7.Location = new Point(144, 223);
      this.button7.Name = "button7";
      this.button7.Size = new Size(75, 23);
      this.button7.TabIndex = 4;
      this.button7.Text = "发送留言";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.textBoxLeaveWord.Location = new Point(70, 100);
      this.textBoxLeaveWord.Multiline = true;
      this.textBoxLeaveWord.Name = "textBoxLeaveWord";
      this.textBoxLeaveWord.Size = new Size(245, 108);
      this.textBoxLeaveWord.TabIndex = 3;
      this.textBoxLeaveQQ.Location = new Point(70, 60);
      this.textBoxLeaveQQ.Name = "textBoxLeaveQQ";
      this.textBoxLeaveQQ.Size = new Size(245, 21);
      this.textBoxLeaveQQ.TabIndex = 2;
      this.textBoxLeaveUser.Location = new Point(70, 23);
      this.textBoxLeaveUser.Name = "textBoxLeaveUser";
      this.textBoxLeaveUser.Size = new Size(245, 21);
      this.textBoxLeaveUser.TabIndex = 1;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(14, 23);
      this.label6.Name = "label6";
      this.label6.Size = new Size(41, 84);
      this.label6.TabIndex = 0;
      this.label6.Text = "用户名\r\n\r\n\r\nQQ\r\n\r\n\r\n内容";
      this.tabPage7.Controls.Add((Control) this.button9);
      this.tabPage7.Location = new Point(4, 22);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Padding = new Padding(3);
      this.tabPage7.Size = new Size(462, 280);
      this.tabPage7.TabIndex = 6;
      this.tabPage7.Text = "异常修复";
      this.tabPage7.UseVisualStyleBackColor = true;
      this.button9.Location = new Point(141, 91);
      this.button9.Name = "button9";
      this.button9.Size = new Size(163, 70);
      this.button9.TabIndex = 0;
      this.button9.Text = "异常修复";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(470, 306);
      this.Controls.Add((Control) this.tabControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = "LoginForm";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "AliTrademanager";
      this.FormClosing += new FormClosingEventHandler(this.LoginForm_FormClosing);
      this.Load += new EventHandler(this.LoginForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      this.tabPage6.ResumeLayout(false);
      this.tabPage6.PerformLayout();
      this.tabPage7.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
