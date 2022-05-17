
// Type: TobaoHelper.MainForm
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\TobaoHelper.exe

using Fiddler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using TobaoHelper.Properties;
using TobaoHelper.Taobao;
using Trand.WinAPI;
using TrandExp.DotNet.Utils;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32;
using System.Management;
using System.Text;
using System.Security.Cryptography;

namespace TobaoHelper
{
    public class MainForm : Form
    {
        private DataTable _dtMainOrders;
        private DataTable _dtMyRateList;
        private DataTable _dtTradeRecords;
        private DataSet ds;
        private SQLiteDataAdapter sdap;
        private IContainer components;
        private TabControl MaintabControl;
        private TabPage RateListTabPage;
        private TabPage AlipayOrderTabPage;
        private TabPage OrderListTabPage;
        private DataGridView dgvMainOrders;
        private TabPage AlipayTrashTabPage;
        private TabPage tabPageAdvSet;
        private Panel OrderListInfo;
        private ContextMenuStrip contextMenuStripOrderList;
        private ToolStripMenuItem toolStripMenuItemTradOk;
        private ToolStripMenuItem toolStripMenuItemOrderHide;
        private Button buttonResetOrderInfo;
        private NotifyIcon TrandNotifyIcon;
        private Button buttonQuitApp;
        private Button buttonStop;
        private Button buttonStart;
        private GroupBox groupBox2;
        private Button buttonExportSslCert;
        private Button buttonInstallSslCert;
        private Button button4;
        private Button button3;
        private Button buttonUninstallSslCert;
        private TabPage tabPageIPEm;
        private TextBox LogTextBox;
        private Label label2;
        private TextBox textBoxProxyPort;
        private Button buttonSaveProxyPort;
        private Label labelHttpMode;
        private CheckBox checkBoxAlipayRecalculate;
        private CheckBox checkBoxClearNotice;
        private CheckBox checkBoxClearAlipayRecyled;
        private CheckBox checkBoxClearLogistics;
        private Panel RateListInfo;
        private GroupBox RateListGroupBox;
        private DataGridView dgvRateList;
        private Button buttonSaveRateCount;
        private Label labelCurrentUserInfo;
        private Button buttonOnekeyWaitRate;
        private Button buttonOnekeyWaitSend;
        private Button buttonOnekeyWaitConfirm;
        private Button buttonOneKeyWaitPay;
        private Button buttonOnekeyHide;
        private Panel AlipayOrderInfo;
        private Label label14;
        private Label label23;
        private Button buttonAlipayOrderCancel;
        private TextBox textBoxAlipayOrderInAmount;
        private TextBox textBoxAlipayOrderMemo;
        private TextBox textBoxAlipayOrderName;
        private TextBox textBoxAlipayOrderDate;
        private Button buttonAlipayOrderSave;
        private CheckBox checkBoxAlipayOrderIsClearMemo;
        private TextBox textBoxAlipayOrderOutAmount;
        private CheckBox checkBoxAlipayOrderIsHide;
        private Label label27;
        private Label label28;
        private Label label26;
        private Label label25;
        private DataGridView dgvTradeRecords;
        private Panel AlipayTrashInfo;
        private Label label20;
        private Label label31;
        private Button button7;
        private Button button8;
        private DataGridView AlipayTrashGridView;
        private CheckBox checkBoxDefiningStop;
        private CheckBox checkBoxUseFakeWindow;
        private Label labelAlipayOrderNumber;
        private Label labelAlipayOrderRowId;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column18;
        private DataGridViewTextBoxColumn Column19;
        private DataGridViewTextBoxColumn Column20;
        private DataGridViewTextBoxColumn Column21;
        private DataGridViewTextBoxColumn Column22;
        private SaveFileDialog saveFileDialog;
        private TabPage tabPage1;
        private CheckBox checkBoxRemovePlaint;
        private Button buttonAlipayOnekeyHide;
        private Button buttonOnekeyReset;
        private NoFocusCueButton buttonHookLock;
        private TabPage tabPageMobile;
        private Button button9;
        private TextBox textBox6;
        private Label label30;
        private TextBox textBox5;
        private Label label29;
        private TextBox textBox4;
        private Label label24;
        private TextBox textBox3;
        private Label label22;
        private TextBox textBox2;
        private Label label21;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private Label label18;
        private Label label17;
        private Label label16;
        private TextBox textBoxRateAll;
        private TextBox textBoxHalfYear;
        private TextBox textBoxRateMonth;
        private TextBox textBoxRateWeek;
        private TextBox textBox_RateForOrderId;
        private Label labelRateType;
        private Label labelCurrentUserId;
        private Button buttonRateModify;
        private CheckBox checkBoxRateIsHide;
        private TextBox textBoxRateDateTime;
        private Label label15;
        private Label label3;
        private CheckBox checkBoxHideGrowth;
        private ComboBox comboBoxAlphaHotKeyHttps;
        private ComboBox comboBoxShiftHotKeyHttps;
        private ComboBox comboBoxAltHotKeyHttps;
        private ComboBox comboBoxCtrlHotKeyHttps;
        private ComboBox comboBoxAlphaHotKeyHttp;
        private ComboBox comboBoxShiftHotKeyHttp;
        private ComboBox comboBoxAltHotKeyHttp;
        private ComboBox comboBoxAlphaHotKeyStop;
        private ComboBox comboBoxShiftHotKeyStop;
        private ComboBox comboBoxAltHotKeyStop;
        private ComboBox comboBoxCtrlHotKeyStop;
        private ComboBox comboBoxAlphaHotKeyStart;
        private ComboBox comboBoxShiftHotKeyStart;
        private ComboBox comboBoxAltHotKeyStart;
        private ComboBox comboBoxCtrlHotKeyStart;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label10;
        private Label label12;
        private Label label36;
        private Label label8;
        private ComboBox comboBoxAlphaHotKeyHide;
        private Label label6;
        private Label label5;
        private ComboBox comboBoxShiftHotKeyHide;
        private ComboBox comboBoxAltHotKeyHide;
        private ComboBox comboBoxCtrlHotKeyHide;
        private Label label13;
        private Label label11;
        private Label label9;
        private Label label7;
        private Label label4;
        private ComboBox comboBoxCtrlHotKeyHttp;
        private CheckBox checkBoxClearListRecyledItems;
        private Label labelCurrentPageIndex;
        private Label label46;
        private GroupBox groupBox6;
        private ToolStripMenuItem 批量隐藏订单ToolStripMenuItem;
        private ToolStripMenuItem 撤销修改ToolStripMenuItem;
        private ToolStripMenuItem 一键收货ToolStripMenuItem;
        private ToolStripMenuItem 一键评价ToolStripMenuItem;
        private GroupBox groupBox4;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private TextBox textBoxRateAllForSales;
        private TextBox textBoxHalfYearForSales;
        private TextBox textBoxRateMonthForSales;
        private TextBox textBoxRateWeekForSales;
        private GroupBox groupBox5;
        private GroupBox groupBox1;
        private GroupBox groupBox7;
        private Label label51;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private GroupBox groupBox10;
        private Label label53;
        private GroupBox groupBox11;
        private Label label54;
        private GroupBox groupBox12;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox groupBox13;
        private TextBox textBox9;
        private Label label19;
        private Label label55;
        private Button button2;
        private CheckBox checkBox3;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private Label label48;
        private CheckBox checkBox4;
        private GroupBox groupBox14;
        private CheckBox checkBox5;
        private Button buttonSet;
        private Label label56;
        private Label label50;
        private System.Windows.Forms.Timer timer1;
        private CheckBox cbEnabled;
        private TextBox tbY;
        private TextBox tbX;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn editCreateDay;
        private DataGridViewTextBoxColumn sellerNickName;
        private DataGridViewTextBoxColumn editTradeStatus;
        private DataGridViewCheckBoxColumn isHide;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private Button button1;
        private CheckBox checkBox_shiming;
        private CheckBox checkBox8;
        private System.Windows.Forms.Timer timer2;
        private Label label47;

        public MainForm()
        {
            this.InitializeComponent();
            this.Text = "explorer";
            this._dtMainOrders = new DataTable("MainOrders");
            this.dgvMainOrders.DataSource = this._dtMainOrders;
            this.dgvMainOrders.ContextMenuStrip = this.contextMenuStripOrderList;
            this._dtMyRateList = new DataTable("MyRateList");
            this._dtMyRateList.Columns.Add("user_name", Type.GetType("System.String"));
            this._dtMyRateList.Columns.Add("date", Type.GetType("System.String"));
            this._dtMyRateList.Columns.Add("item_id_name", Type.GetType("System.String"));
            this._dtMyRateList.Columns.Add("id", Type.GetType("System.Int64"));
            this._dtMyRateList.Columns.Add("StatusText", Type.GetType("System.String"));
            this._dtMyRateList.Columns.Add("userid", Type.GetType("System.Int64"));
            this._dtMyRateList.Columns.Add("rate_type", Type.GetType("System.Int32"));
            this._dtMyRateList.PrimaryKey = new DataColumn[]
			{
				this._dtMyRateList.Columns["id"],
				this._dtMyRateList.Columns["rate_type"]
			};
            this.dgvRateList.DataSource = this._dtMyRateList;
            this.dgvRateList.Columns["user_name"].HeaderText = "评价人";
            this.dgvRateList.Columns["user_name"].Width = 150;
            this.dgvRateList.Columns["user_name"].ReadOnly = true;
            this.dgvRateList.Columns["user_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRateList.Columns["date"].HeaderText = "评价时间";
            this.dgvRateList.Columns["date"].Width = 150;
            this.dgvRateList.Columns["date"].ReadOnly = true;
            this.dgvRateList.Columns["date"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRateList.Columns["item_id_name"].HeaderText = "宝贝名称";
            this.dgvRateList.Columns["item_id_name"].Width = 200;
            this.dgvRateList.Columns["item_id_name"].ReadOnly = true;
            this.dgvRateList.Columns["item_id_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRateList.Columns["id"].HeaderText = "订单号";
            this.dgvRateList.Columns["id"].Width = 100;
            this.dgvRateList.Columns["id"].ReadOnly = true;
            this.dgvRateList.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRateList.Columns["StatusText"].HeaderText = "状态";
            this.dgvRateList.Columns["StatusText"].Width = 100;
            this.dgvRateList.Columns["StatusText"].ReadOnly = true;
            this.dgvRateList.Columns["StatusText"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRateList.Columns["userid"].HeaderText = "userid";
            this.dgvRateList.Columns["userid"].Visible = false;
            this.dgvRateList.Columns["rate_type"].HeaderText = "评论类型";
            this.dgvRateList.Columns["rate_type"].Visible = true;
            this.dgvRateList.Columns["rate_type"].ReadOnly = true;
            this.dgvRateList.Columns["rate_type"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this._dtTradeRecords = new DataTable("TradeRecords");
            this._dtTradeRecords.Columns.Add("number", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("date", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("name", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("memo", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("in_amount", Type.GetType("System.Double"));
            this._dtTradeRecords.Columns.Add("out_amount", Type.GetType("System.Double"));
            this._dtTradeRecords.Columns.Add("balance", Type.GetType("System.Double"));
            this._dtTradeRecords.Columns.Add("from", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("StatusText", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("userid", Type.GetType("System.Int64"));
            this._dtTradeRecords.Columns.Add("rowid", Type.GetType("System.String"));
            this._dtTradeRecords.Columns.Add("IsHide", Type.GetType("System.Boolean"));
            this._dtTradeRecords.Columns.Add("IsClearMemo", Type.GetType("System.Boolean"));
            this._dtTradeRecords.PrimaryKey = new DataColumn[]
			{
				this._dtTradeRecords.Columns["rowid"]
			};
            this.dgvTradeRecords.DataSource = this._dtTradeRecords;
            this.dgvTradeRecords.Columns["number"].HeaderText = "流水号";
            this.dgvTradeRecords.Columns["number"].Width = 100;
            this.dgvTradeRecords.Columns["number"].ReadOnly = true;
            this.dgvTradeRecords.Columns["number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["date"].HeaderText = "日期";
            this.dgvTradeRecords.Columns["date"].Width = 100;
            this.dgvTradeRecords.Columns["date"].ReadOnly = true;
            this.dgvTradeRecords.Columns["date"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["name"].HeaderText = "名称";
            this.dgvTradeRecords.Columns["name"].Width = 100;
            this.dgvTradeRecords.Columns["name"].ReadOnly = true;
            this.dgvTradeRecords.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["memo"].HeaderText = "备注";
            this.dgvTradeRecords.Columns["memo"].Width = 100;
            this.dgvTradeRecords.Columns["memo"].ReadOnly = true;
            this.dgvTradeRecords.Columns["memo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["in_amount"].HeaderText = "收入";
            this.dgvTradeRecords.Columns["in_amount"].Width = 80;
            this.dgvTradeRecords.Columns["in_amount"].ReadOnly = true;
            this.dgvTradeRecords.Columns["in_amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["out_amount"].HeaderText = "支出";
            this.dgvTradeRecords.Columns["out_amount"].Width = 80;
            this.dgvTradeRecords.Columns["out_amount"].ReadOnly = true;
            this.dgvTradeRecords.Columns["out_amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["balance"].HeaderText = "帐户余额";
            this.dgvTradeRecords.Columns["balance"].Width = 80;
            this.dgvTradeRecords.Columns["balance"].ReadOnly = true;
            this.dgvTradeRecords.Columns["balance"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["balance"].HeaderText = "帐户余额";
            this.dgvTradeRecords.Columns["balance"].Width = 100;
            this.dgvTradeRecords.Columns["balance"].ReadOnly = true;
            this.dgvTradeRecords.Columns["balance"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["StatusText"].HeaderText = "操作类型";
            this.dgvTradeRecords.Columns["StatusText"].Width = 100;
            this.dgvTradeRecords.Columns["StatusText"].ReadOnly = true;
            this.dgvTradeRecords.Columns["StatusText"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvTradeRecords.Columns["userid"].HeaderText = "userid";
            this.dgvTradeRecords.Columns["userid"].Visible = false;
            this.dgvTradeRecords.Columns["rowid"].HeaderText = "rowid";
            this.dgvTradeRecords.Columns["rowid"].Visible = false;
            this.dgvTradeRecords.Columns["IsHide"].HeaderText = "IsClearMemo";
            this.dgvTradeRecords.Columns["IsHide"].Visible = true;
            this.dgvTradeRecords.Columns["IsClearMemo"].HeaderText = "IsClearMemo";
            this.dgvTradeRecords.Columns["IsClearMemo"].Visible = true;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
            this.LoadConfig();
            TBHelper.buyerTradeManage.BindData += delegate(object sender, DataBindEventArgs e)
            {
                base.BeginInvoke(new Action(delegate
                {
                    this.labelCurrentPageIndex.Text = string.Format("{0}/{1}页  [{2}单]", e.CurrentPageIndex, e.TotalPage, e.TotalNumber);
                    DataTable data = e.Data;
                    this._dtMainOrders.Rows.Clear();
                    this._dtMainOrders.Merge(data);
                }));
            };
            this.RegisterHotKey();
            FiddlerApplication.OnNotification += delegate(object sender, NotificationEventArgs e)
            {
            };
            FiddlerApplication.Log.OnLogString += delegate(object sender, Fiddler.LogEventArgs e)
            {
                this.LogWriteLine("OnLogString is " + e.LogString);
            };
            FiddlerHelper.InitFiddlerApplication();
            this.labelHttpMode.Text = "显示网址网络协议";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.UpdateButtonStatus();
            FirefoxManage.StartDaemonFrefox();
            this.MaintabControl.TabPages.Remove(this.tabPage1);
            ReadIni();

            Control.CheckForIllegalCrossThreadCalls = false;

            this.intFlag = 1;
            this.UseFiddler();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 786)
            {
                switch (m.WParam.ToInt32())
                {
                    case 102:
                        timer1.Enabled = false;
                        File.WriteAllLines(Application.StartupPath + "\\point.ini", new string[] { tbX.Text, tbY.Text }, System.Text.Encoding.GetEncoding("gb2312"));
                        break;
                    case 103:
                        this.buttonStart.PerformClick();
                        break;
                    case 104:
                        this.buttonStop.PerformClick();
                        break;
                    case 105:
                        if (this.WindowState == FormWindowState.Minimized)
                        {
                            //显示
                            if ((VirPoint(MousePosition) && cbEnabled.Checked) || !cbEnabled.Checked)
                                WindowsAPI.SwitchToThisWindow(this.Handle, true);
                            break;
                        }
                        WindowsAPI.ShowWindow(this.Handle, 2);
                        break;
                }
            }

            if ((m.Msg == 786) && m.LParam.ToInt32() > 102)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                switch (m.WParam.ToInt32())
                {
                    case 103:
                        FiddlerApplication.Startup(8877, FiddlerCoreStartupFlags.Default);

                        break;
                    case 104:
                        FiddlerApplication.Shutdown();

                        break;
                }
            }
            base.WndProc(ref m);

        }

        private void ReadIni()
        {
            string[] info = File.ReadAllLines(Application.StartupPath + "\\point.ini", System.Text.Encoding.GetEncoding("gb2312"));
            tbX.Text = info[0];
            tbY.Text = info[1];
        }

        /// <summary>
        /// 校验坐标
        /// </summary>
        public bool VirPoint(Point point)
        {
            String[] info = File.ReadAllLines(Application.StartupPath + "\\point.ini", System.Text.Encoding.GetEncoding("gb2312"));
            if (Math.Abs(point.X - Convert.ToInt32(info[0])) < 100 && Math.Abs(point.Y - Convert.ToInt32(info[1])) < 100)
            {
                return true;
            }
            else
                return false;
        }

        public void LogWriteLine()
        {
            this.LogWrite(Environment.NewLine);
        }

        public void LogWriteLine(string msg)
        {
            this.LogWrite(msg + Environment.NewLine);
        }

        public void LogWriteLine(string msg, params object[] parameters)
        {
            this.LogWrite(msg + Environment.NewLine, parameters);
        }

        public void LogWrite(string msg, params object[] parameters)
        {
            this.LogWrite(string.Format(msg, parameters));
        }

        public void LogWrite(string msg)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new MethodInvoker(delegate
                {
                    this.LogWrite(msg);
                }));
                return;
            }
            this.LogTextBox.AppendText(msg);
            this.LogTextBox.SelectionStart = this.LogTextBox.TextLength - 1;
            this.LogTextBox.ScrollToCaret();
        }
        private void ButtonHandler(object sender, EventArgs e)
        {
            if (sender == this.buttonStart)
                this.Start();
            else if (sender == this.buttonStop)
                this.Stop();
            else if (sender == this.buttonQuitApp)
            {
                this.Stop();
                this.SaveConfig();
                this.Close();
            }
            else if (sender == this.buttonInstallSslCert)
            {
                this.Cursor = Cursors.WaitCursor;
                FiddlerHelper.InstallCertificate();
                this.Cursor = Cursors.Default;
            }
            else if (sender == this.buttonUninstallSslCert)
                FiddlerHelper.UninstallCertificate();
            else if (sender == this.buttonSaveProxyPort)
                this.SaveConfig();
            this.UpdateButtonStatus();
        }

        public void UpdateButtonStatus()
        {
            this.buttonStart.Enabled = !FiddlerApplication.IsStarted();
            this.buttonStop.Enabled = !this.buttonStart.Enabled;
            this.buttonInstallSslCert.Enabled = !CertMaker.rootCertExists();
            this.buttonUninstallSslCert.Enabled = !this.buttonInstallSslCert.Enabled;
        }

        private void SaveConfig()
        {
            IniFile iniFile = new IniFile("config.ini");
            if (this.textBoxProxyPort.Text.Trim() == "")
                iniFile.WriteInteger("Configuration", "ProxyPort", 8888);
            else
                iniFile.WriteInteger("Configuration", "ProxyPort", Convert.ToInt32(this.textBoxProxyPort.Text));
            iniFile.WriteBool("AdvanceSettings", "ClearListRecyledItems", this.checkBoxClearAlipayRecyled.Checked);
            iniFile.WriteBool("AdvanceSettings", "ClearTaoBaoListRecyledItems", this.checkBoxClearListRecyledItems.Checked);
            iniFile.WriteBool("AdvanceSettings", "ClearLogistics", this.checkBoxClearLogistics.Checked);
            iniFile.WriteBool("AdvanceSettings", "ClearNotice", this.checkBoxClearNotice.Checked);
            iniFile.WriteBool("AdvanceSettings", "UseFakeWindow", this.checkBoxUseFakeWindow.Checked);
            iniFile.WriteBool("AdvanceSettings", "AlipayRecalculate", this.checkBoxAlipayRecalculate.Checked);
            iniFile.WriteBool("AdvanceSettings", "RemovePlaint", this.checkBoxRemovePlaint.Checked);
            iniFile.WriteBool("AdvanceSettings", "DefiningStop", this.checkBoxDefiningStop.Checked);
            iniFile.WriteBool("AdvanceSettings", "HideGrowth", this.checkBoxHideGrowth.Checked);
        }

        private void InitComboboxHotKey(ComboBox senderCtrl, ComboBox senderAlt, ComboBox senderShift, ComboBox senderAlpha, string HotKeyValue)
        {
            senderCtrl.Items.Add((object)"无");
            senderCtrl.Items.Add((object)"Ctrl");
            senderAlt.Items.Add((object)"无");
            senderAlt.Items.Add((object)"Alt");
            senderShift.Items.Add((object)"无");
            senderShift.Items.Add((object)"Shift");
            for (int index = 65; index < 91; ++index)
                senderAlpha.Items.Add((object)((char)index).ToString());
            for (int index = 48; index < 58; ++index)
                senderAlpha.Items.Add((object)((char)index).ToString());
            List<string> list = Enumerable.ToList<string>((IEnumerable<string>)HotKeyValue.Split('+'));
            while (Enumerable.Count<string>((IEnumerable<string>)list) < 4)
                list.Add("无");
            string[] strArray = list.ToArray();
            senderCtrl.SelectedIndex = senderCtrl.Items.IndexOf((object)strArray[0]);
            senderAlt.SelectedIndex = senderAlt.Items.IndexOf((object)strArray[1]);
            senderShift.SelectedIndex = senderShift.Items.IndexOf((object)strArray[2]);
            senderAlpha.SelectedIndex = senderAlpha.Items.IndexOf((object)strArray[3]);
            senderCtrl.SelectedIndexChanged += new EventHandler(this.comboBoxHotKey_SelectedIndexChanged);
            senderAlt.SelectedIndexChanged += new EventHandler(this.comboBoxHotKey_SelectedIndexChanged);
            senderShift.SelectedIndexChanged += new EventHandler(this.comboBoxHotKey_SelectedIndexChanged);
            senderAlpha.SelectedIndexChanged += new EventHandler(this.comboBoxHotKey_SelectedIndexChanged);
        }

        private void LoadConfig()
        {
            this.InitComboboxHotKey(this.comboBoxCtrlHotKeyHide, this.comboBoxAltHotKeyHide, this.comboBoxShiftHotKeyHide, this.comboBoxAlphaHotKeyHide, CaptureConfiguration.HotKeys["HideKey"]);
            this.InitComboboxHotKey(this.comboBoxCtrlHotKeyStart, this.comboBoxAltHotKeyStart, this.comboBoxShiftHotKeyStart, this.comboBoxAlphaHotKeyStart, CaptureConfiguration.HotKeys["StartKey"]);
            this.InitComboboxHotKey(this.comboBoxCtrlHotKeyStop, this.comboBoxAltHotKeyStop, this.comboBoxShiftHotKeyStop, this.comboBoxAlphaHotKeyStop, CaptureConfiguration.HotKeys["StopKey"]);
            this.InitComboboxHotKey(this.comboBoxCtrlHotKeyHttp, this.comboBoxAltHotKeyHttp, this.comboBoxShiftHotKeyHttp, this.comboBoxAlphaHotKeyHttp, CaptureConfiguration.HotKeys["HttpKey"]);
            this.InitComboboxHotKey(this.comboBoxCtrlHotKeyHttps, this.comboBoxAltHotKeyHttps, this.comboBoxShiftHotKeyHttps, this.comboBoxAlphaHotKeyHttps, CaptureConfiguration.HotKeys["HttpsKey"]);
            this.textBoxProxyPort.Text = CaptureConfiguration.ProxyPort.ToString();
            this.checkBoxClearAlipayRecyled.Checked = CaptureConfiguration._advSettings.ClearListRecyledItems;
            this.checkBoxClearLogistics.Checked = CaptureConfiguration._advSettings.ClearLogistics;
            this.checkBoxClearNotice.Checked = CaptureConfiguration._advSettings.ClearNotice;
            this.checkBoxUseFakeWindow.Checked = CaptureConfiguration._advSettings.UseFakeWindow;
            this.checkBoxAlipayRecalculate.Checked = CaptureConfiguration._advSettings.AlipayRecalculate;
            this.checkBoxRemovePlaint.Checked = CaptureConfiguration._advSettings.RemovePlaint;
            this.checkBoxDefiningStop.Checked = CaptureConfiguration._advSettings.DefiningStop;
            this.checkBoxHideGrowth.Checked = CaptureConfiguration._advSettings.HideGrowth;
            this.checkBoxClearListRecyledItems.Checked = CaptureConfiguration._advSettings.ClearTaoBaoListRecyledItems;
        }

        private void SetHotKey(int key, string keyStr)
        {
            string[] strArray = keyStr.Split('+');
            uint fsModifiers = 0U;
            if (Enumerable.Count<string>((IEnumerable<string>)strArray) < 4)
                return;
            if (strArray[0].Equals("Ctrl", StringComparison.CurrentCultureIgnoreCase))
                fsModifiers |= 2U;
            if (strArray[1].Equals("Alt", StringComparison.CurrentCultureIgnoreCase))
                fsModifiers |= 1U;
            if (strArray[2].Equals("Shift", StringComparison.CurrentCultureIgnoreCase))
                fsModifiers |= 4U;
            WindowsAPI.RegisterHotKey(this.Handle, key, fsModifiers, (Keys)strArray[3][0]);
        }

        private void RegisterHotKey()
        {
            this.SetHotKey(103, CaptureConfiguration.HotKeys["StartKey"]);
            this.SetHotKey(104, CaptureConfiguration.HotKeys["StopKey"]);
            this.SetHotKey(105, CaptureConfiguration.HotKeys["HideKey"]);
            this.SetHotKey(106, CaptureConfiguration.HotKeys["HttpKey"]);
            this.SetHotKey(107, CaptureConfiguration.HotKeys["HttpsKey"]);
            WindowsAPI.RegisterHotKey(this.Handle, 102, 2, Keys.NumPad0);
        }

        private void FiddlerApplication_AfterSessionComplete(Session sess)
        {
            if (TBHelper.isFirstSslRequest && sess.fullUrl.ToLower().StartsWith("https://www.taobao.com"))
            {
                if (TBHelper.isFirstSslRequest)
                {
                    base.BeginInvoke(new Action<bool>(delegate(bool isHTTPS)
                    {
                        this.labelHttpMode.Text = (isHTTPS ? "https" : "http");
                    }), new object[]
					{
						sess.isHTTPS
					});
                }
                TBHelper.isFirstSslRequest = false;
            }
        }

        private void FiddlerApplication_BeforeRequest(Session sess)
        {
            if (!TBHelper.IncaptureSessionUrl(sess.fullUrl.ToLower()))
                return;
            sess.bBufferResponse = true;
            sess.HTTPMethodIs("CONNECT");
        }

        private void ClearUserData()
        {
            this._dtMyRateList.Rows.Clear();
            this._dtTradeRecords.Rows.Clear();
        }

        private void FiddlerApplication_BeforeResponse(Session sess)
        {
            string text = sess.fullUrl.ToLower();
            if (!TBHelper.IncaptureSessionUrl(text) || !FiddlerHelper.IsMIMEType(sess.oResponse.MIMEType) || sess.responseCode != 200 || (sess.oRequest.headers.HTTPMethod != "GET" && sess.oRequest.headers.HTTPMethod != "POST"))
            {
                return;
            }
            TBHelper.TBCookie = sess.oRequest["Cookie"];
            string text2 = sess.PathAndQuery.ToLower();
            if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm", StringComparison.CurrentCultureIgnoreCase) && text2.Contains("is_user_do_async=1"))
            {
                return;
            }
            if (text.StartsWith("https://i.taobao.com/my_taobao.htm", StringComparison.CurrentCultureIgnoreCase) && text2.Contains("is_user_do_async=1"))
            {
                return;
            }
            if (text.StartsWith("https://i.taobao.com/my_taobao_api/logistics_info.json?", StringComparison.CurrentCultureIgnoreCase) && text2.Contains("is_user_do_async=1"))
            {
                return;
            }
            if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/asyncbought.htm", StringComparison.CurrentCultureIgnoreCase) && text2.Contains("is_user_do_async=1"))
            {
                return;
            }
            if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm", StringComparison.CurrentCultureIgnoreCase) && text2.ToLower().Contains("is_user_do_async=1"))
            {
                return;
            }
            if ((text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm", StringComparison.CurrentCultureIgnoreCase) || text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/asyncRecyledItems.htm", StringComparison.CurrentCultureIgnoreCase)) && text2.Contains("is_user_do_async=1"))
            {
                return;
            }
            if (text.StartsWith("https://consumeprod.alipay.com/record/advanced.htm", StringComparison.CurrentCultureIgnoreCase) && text2.Contains("is_user_do_async=1"))
            {
                return;
            }
            TBJS_UserInfo user = null;
            if (TBHelper.IsHostWithIsLogin(text))
            {
                user = TBHelper.GetUserInfo(sess.oRequest["Cookie"]);
                if (user == null)
                {
                    return;
                }
                if (TBHelper.CurrentUserInfo.userid != user.userid)
                {
                    TBHelper.MyRate.ChangeLoginUser(TBHelper.CurrentUserInfo.userid, user.userid);
                    TBHelper.MyRate.ClearData();
                    TBHelper.alipayManage.ChangeLoginUser(TBHelper.CurrentUserInfo.userid, user.userid);
                    TBHelper.alipayManage.ClearData();
                    TBHelper.CurrentUserInfo.userid = user.userid;
                    TBHelper.CurrentUserInfo.nickname = user.nickname;
                    base.BeginInvoke(new Action(delegate
                    {
                        this.ClearUserData();
                        this.labelCurrentUserInfo.Text = string.Format("{0}", user.nickname, user.userid);
                    }));
                }
            }
            else
            {
                user = TBHelper.CurrentUserInfo;
            }
            this.LogWriteLine(string.Concat(new object[]
			{
				"响应的序号：",
				sess.id,
				"响应码:",
				sess.responseCode.ToString(),
				"服务器返回的URL地址为：",
				text
			}));
            if (text.StartsWith("https://i.taobao.com/my_taobao.htm"))
            {
                string text3 = FiddlerHelper.GetSessionHtmlText(sess);
                text3 = TBHelper.buyerTradeManage.ResolveHtmlToMyTaobao(user, text3, CaptureConfiguration._advSettings.ClearLogistics);
                sess.utilSetResponseBody(text3);
                base.BeginInvoke(new Action(delegate
                {
                    TBHelper.buyerTradeManage.GetDefaultData(user);
                }));
                return;
            }
            if (text.StartsWith("https://i.taobao.com/my_taobao_api/logistics_info.json?"))
            {
                string text4 = FiddlerHelper.GetSessionHtmlText(sess);
                text4 = TBHelper.buyerTradeManage.ResolveHtmlToLogisticsInfoJson(user, text4, CaptureConfiguration._advSettings.ClearLogistics);
                sess.utilSetResponseBody(text4);
                return;
            }
            if (text.StartsWith("https://i.taobao.com/json/my_taobao_remind_data.htm"))
            {
                string text5 = FiddlerHelper.GetSessionHtmlText(sess);
                text5 = TBHelper.buyerTradeManage.ResolveHtmlToRemindData(user, text5);
                sess.utilSetResponseBody(text5);
                return;
            }
            if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm"))
            {
                TBHelper.ListBoughtItemsCookie = sess.oRequest["Cookie"];
                string text6 = FiddlerHelper.GetSessionHtmlText(sess);
                string text7 = sess.PathAndQuery.ToLower();
                string tabCode = "";
                if (text7.Contains("tabcode=waitpay"))
                {
                    tabCode = "waitPay";
                }
                else if (text7.Contains("tabcode=waitsend"))
                {
                    tabCode = "waitSend";
                }
                else if (text7.Contains("tabcode=waitconfirm"))
                {
                    tabCode = "waitConfirm";
                }
                else if (text7.Contains("tabcode=waitrate"))
                {
                    tabCode = "waitRate";
                }
                else if (text7.Contains("tabcode=steppay"))
                {
                    tabCode = "stepPay";
                }
                text6 = TBHelper.buyerTradeManage.ResolveHtmlToBuyerTrade(user, text6, tabCode);
                sess.utilSetResponseBody(text6);
                return;
            }
            if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/asyncbought.htm"))
            {
                string text8 = sess.PathAndQuery.ToLower();
                if (text8.Contains("action=itemlist/boughtqueryaction") && text8.Contains("event_submit_do_query=1"))
                {
                    string text9 = FiddlerHelper.GetSessionHtmlText(sess);
                    text9 = TBHelper.buyerTradeManage.ResolveJsonToBuyerTrade(user, text9, "");
                    sess.utilSetResponseBody(text9);
                    return;
                }
                if (text8.Contains("action=itemlist/recyleaction") && text8.Contains("event_submit_do_delete=1") && text8.Contains("order_ids="))
                {
                    string text10 = (from c in sess.PathAndQuery.Split(new char[]
					{
						'&'
					})
                                     where c.StartsWith("order_ids")
                                     select c).FirstOrDefault<string>();
                    if (!string.IsNullOrEmpty(text10))
                    {
                        long id = long.Parse(text10.Split(new char[]
						{
							'='
						})[1].Trim());
                        TBHelper.buyerTradeManage.ActionDeleteOrder(user, id);
                        string text11 = FiddlerHelper.GetSessionHtmlText(sess);
                        text11 = TBHelper.buyerTradeManage.ResolveJsonToBuyerTrade(user, text11, "");
                        sess.utilSetResponseBody(text11);
                        return;
                    }
                }
            }
            else
            {
                if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm"))
                {
                    string text12 = FiddlerHelper.GetSessionHtmlText(sess);
                    text12 = TBHelper.buyerTradeManage.ResolveHtmlToListRecyledtems(user, text12);
                    sess.utilSetResponseBody(text12);
                    return;
                }
                if (text.StartsWith("https://buyertrade.taobao.com/trade/itemlist/asyncRecyledItems.htm".ToLower()))
                {
                    string text13 = sess.PathAndQuery.ToLower();
                    if (text13.Contains("action=itemlist/recyledqueryaction") && text13.Contains("event_submit_do_query=1"))
                    {
                        string text14 = FiddlerHelper.GetSessionHtmlText(sess);
                        text14 = TBHelper.buyerTradeManage.ResolveJsonToListRecyledtems(user, text14);
                        sess.utilSetResponseBody(text14);
                        return;
                    }
                }
                else
                {
                    if (text.StartsWith("https://rate.taobao.com/myrate.htm") || text.StartsWith("https://rate.taobao.com/user-myrate"))
                    {
                        string text15 = FiddlerHelper.GetSessionHtmlText(sess);
                        if (text.Contains("receivedorposted|0--buyerorseller|1"))
                        {
                            text15 = TBHelper.MyRate.ResolveHtmlToData(user, text15, this._dtMyRateList, 1);
                            sess.utilSetResponseBody(text15);
                        }
                        else if (text.Contains("buyerorseller|3--receivedorposted|1"))
                        {
                            text15 = TBHelper.MyRate.ResolveHtmlToData(user, text15, this._dtMyRateList, 2);
                            sess.utilSetResponseBody(text15);
                        }
                        else
                        {
                            text15 = TBHelper.MyRate.ResolveHtmlToData(user, text15, this._dtMyRateList, 1);
                            sess.utilSetResponseBody(text15);
                        }
                        base.BeginInvoke(new Action(delegate
                        {
                            this.BindRateList();
                        }));
                        return;
                    }
                    if (CaptureConfiguration._advSettings.HideGrowth && text.StartsWith("https://vip.taobao.com/ajax/growth/get_growth_record.do?"))
                    {
                        string text16 = FiddlerHelper.GetSessionHtmlText(sess);
                        text16 = TBHelper.buyerTradeManage.ResolveJsonToGrowthRecord(user, text16);
                        sess.utilSetResponseBody(text16);
                        return;
                    }
                    if (CaptureConfiguration._advSettings.ClearListRecyledItems && text.StartsWith("https://consumeprod.alipay.com/record/trashindex.htm"))
                    {
                        string text17 = FiddlerHelper.GetSessionHtmlText(sess);
                        text17 = TBHelper.alipayTrash.ResolveHtmlToData(text17);
                        sess.utilSetResponseBody(text17);
                        return;
                    }
                    if (text.StartsWith("https://my.alipay.com/tile/service/portal:recent.tile?t="))
                    {
                        string text18 = FiddlerHelper.GetSessionHtmlText(sess);
                        text18 = TBHelper.buyerTradeManage.ResolveHtmlToTradeRecords(user, sess.oRequest["Cookie"], text18);
                        sess.utilSetResponseBody(text18);
                        return;
                    }
                    if (text.StartsWith("https://consumeprod.alipay.com/record/advanced.htm"))
                    {
                        string text19 = FiddlerHelper.GetSessionHtmlText(sess);
                        text19 = TBHelper.buyerTradeManage.ResolveHtmlToTradeRecordsAdvanced(user, sess.oRequest["Cookie"], text19);
                        sess.utilSetResponseBody(text19);
                        return;
                    }
                    if (text.StartsWith("https://consumeprod.alipay.com/record/standard.htm"))
                    {
                        string text20 = FiddlerHelper.GetSessionHtmlText(sess);
                        text20 = TBHelper.buyerTradeManage.ResolveHtmlToTradeRecordsStandard(user, sess.oRequest["Cookie"], text20);
                        sess.utilSetResponseBody(text20);
                        return;
                    }
                    if (text.StartsWith("https://lab.alipay.com/consume/record/items.htm"))
                    {
                        string text21 = FiddlerHelper.GetSessionHtmlText(sess);
                        text21 = TBHelper.alipayManage.ResolveHtmlToRecordItems(TBHelper.CurrentUserInfo, text21, CaptureConfiguration._advSettings.AlipayRecalculate);
                        sess.utilSetResponseBody(text21);
                        base.BeginInvoke(new Action(delegate
                        {
                            this.BindTradeRecords();
                        }));
                        return;
                    }
                    if (CaptureConfiguration._advSettings.ClearNotice && text.StartsWith("https://notice.taobao.com/?spm=") && !text.Contains("/json/"))
                    {
                        string text22 = FiddlerHelper.GetSessionHtmlText(sess);
                        text22 = OpenshopNotice.ClearNoticeInfo(text22);
                        sess.utilSetResponseBody(text22);
                    }
                }
            }
        }

        private void Start()
        {
            this.labelHttpMode.Text = "http";
            CaptureConfiguration.ProxHost = "127.0.0.1";
            CaptureConfiguration.ProxyPort = this.textBoxProxyPort.Text.Trim() != "" ? Convert.ToInt32(this.textBoxProxyPort.Text) : 8888;
            CaptureConfiguration.ProxyRunning = true;
            CONFIG.bCaptureCONNECT = true;
            CONFIG.IgnoreServerCertErrors = true;
            CONFIG.bMITM_HTTPS = true;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.CertMaker.CleanupServerCertsOnExit", true);
            FiddlerApplication.Prefs.SetBoolPref("fiddler.CertMaker.OfferMachineTrust", true);
            FiddlerApplication.BeforeRequest += new SessionStateHandler(this.FiddlerApplication_BeforeRequest);
            FiddlerApplication.BeforeResponse += new SessionStateHandler(this.FiddlerApplication_BeforeResponse);
            FiddlerHelper.InstallCertificate();
            FiddlerApplication.Startup(CaptureConfiguration.ProxyPort, true, true, true);
        }

        private void Stop()
        {
            this.labelHttpMode.Text = "https";
            CaptureConfiguration.ProxyRunning = false;
            FiddlerApplication.BeforeRequest -= new SessionStateHandler(this.FiddlerApplication_BeforeRequest);
            FiddlerApplication.BeforeResponse -= new SessionStateHandler(this.FiddlerApplication_BeforeResponse);
            FiddlerApplication.AfterSessionComplete -= new SessionStateHandler(this.FiddlerApplication_AfterSessionComplete);
            if (FiddlerApplication.IsStarted())
                FiddlerApplication.Shutdown();
            TBHelper.MyRate.SerializeRates(TBHelper.CurrentUserInfo.userid);
            TBHelper.alipayManage.SerializeTradeRecords(TBHelper.CurrentUserInfo.userid);
        }

        private void ClearAllGridView(DataGridView grid)
        {
            for (int index1 = 0; index1 < grid.RowCount; ++index1)
            {
                for (int index2 = 0; index2 < grid.Rows[index1].Cells.Count; ++index2)
                    grid.Rows[index1].Cells[index2].Value = (object)"";
            }
            grid.RowCount = 0;
        }

        private int GetGridViewRowIndexById(DataGridView grid, long id, int index)
        {
            for (int index1 = 0; index1 < grid.RowCount - 1; ++index1)
            {
                if (Convert.ToInt64(grid.Rows[index1].Cells[index].Value) == id)
                    return index1;
            }
            return -1;
        }

        private int GetGridViewRowIndexById(DataGridView grid, string id, string field)
        {
            for (int index = 0; index < grid.RowCount - 1; ++index)
            {
                if (grid.Rows[index].Cells[field].Value.Equals((object)id))
                    return index;
            }
            return -1;
        }

        private void updateDataTable(DataTable dt)
        {
            if (this.dgvMainOrders.InvokeRequired)
                this.dgvMainOrders.Invoke((Delegate)new MainForm.updateDataTableDelegate(this.updateDataTable), (object)dt);
            else
                this._dtMainOrders.Merge(dt);
        }

        private void BindRateList()
        {
            if (this.dgvRateList.InvokeRequired)
            {
                this.dgvRateList.Invoke(new MethodInvoker(delegate
                {
                    this.BindRateList();
                }));
                return;
            }
            if (TBHelper.CurrentUserInfo == null)
            {
                return;
            }
            this._dtMyRateList = TBHelper.MyRate.GetDataSource(TBHelper.CurrentUserInfo.userid, this._dtMyRateList);
        }

        private void BindTradeRecords()
        {
            if (this.dgvTradeRecords.InvokeRequired)
            {
                this.dgvTradeRecords.Invoke(new MethodInvoker(delegate
                {
                    this.BindTradeRecords();
                }));
                return;
            }
            if (TBHelper.CurrentUserInfo == null)
            {
                return;
            }
            this._dtTradeRecords = TBHelper.alipayManage.GetDataSource(TBHelper.CurrentUserInfo.userid, this._dtTradeRecords);
        }

        private void BindTradeTrashs()
        {
        }

        private void toolStripMenuItemTradOk_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.CurrentRow == null || this.dgvMainOrders.RowCount == 0)
                return;
            int index = dataGridView.CurrentRow.Index;
            long id = Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString());
            TaobaoSQL.UpdateTradeInfo(TBHelper.CurrentUserInfo.userid.ToString(), id, Convert.ToBoolean(dataGridView.Rows[index].Cells["isHide"].Value), dataGridView.Rows[index].Cells["editCreateDay"].Value.ToString(), "交易成功");
            dataGridView.Rows[index].Cells["edittradeStatus"].Value = (object)"交易成功";
            this.buttonResetOrderInfo.Enabled = true;
        }

        private void toolStripMenuItemOrderHide_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.CurrentRow == null || this.dgvMainOrders.RowCount == 0)
                return;
            int index = dataGridView.CurrentRow.Index;
            dataGridView.Rows[index].Cells[2].Value = (object)"隐藏";
            long id = Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString());
            TaobaoSQL.UpdateTradeInfo(TBHelper.CurrentUserInfo.userid.ToString(), id, true, dataGridView.Rows[index].Cells["editCreateDay"].Value.ToString(), dataGridView.Rows[index].Cells["editTradeStatus"].Value.ToString());
            dataGridView.Rows[index].Cells["editTradeStatus"].Value = (object)"隐藏";
            dataGridView.Rows[index].Cells["isHide"].Value = (object)true;
            this.buttonResetOrderInfo.Enabled = true;
        }

        private void dataGridViewOrderList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (object)string.Format("{0}", (object)(e.Row.Index + 1));
        }

        private void TrandNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                return;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowsAPI.UnregisterHotKey(this.Handle, 103);
            WindowsAPI.UnregisterHotKey(this.Handle, 104);
            WindowsAPI.UnregisterHotKey(this.Handle, 105);
            WindowsAPI.UnregisterHotKey(this.Handle, 106);
            WindowsAPI.UnregisterHotKey(this.Handle, 107);

            DoQuit();
        }

        private void contextMenuStripOrderList_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;
            DataGridView dataGridView = this.dgvMainOrders;
            contextMenuStrip.Items[0].Visible = false;
            contextMenuStrip.Items[0].Enabled = false;
            contextMenuStrip.Items[1].Visible = false;
            contextMenuStrip.Items[1].Enabled = false;
            if (dataGridView.RowCount == 0 || dataGridView.CurrentRow == null)
            {
                e.Cancel = true;
            }
            else
            {
                int index = dataGridView.CurrentRow.Index;
                contextMenuStrip.Items[0].Enabled = TBHelper.IsTradeNotComplete(dataGridView.Rows[index].Cells["editTradeStatus"].Value.ToString());
                contextMenuStrip.Items[1].Enabled = !Convert.ToBoolean(dataGridView.Rows[index].Cells["isHide"].Value);
                contextMenuStrip.Items[0].Visible = contextMenuStrip.Items[0].Enabled;
                contextMenuStrip.Items[1].Visible = contextMenuStrip.Items[1].Enabled;
            }
        }

        private void dataGridViewRateList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (object)string.Format("{0}", (object)(e.Row.Index + 1));
        }

        private void buttonRateModify_Click(object sender, EventArgs e)
        {
            if (this.textBox_RateForOrderId.Text == "" || this.textBoxRateDateTime.Text == "")
                return;
            long id = Convert.ToInt64(this.textBox_RateForOrderId.Text);
            long userId = Convert.ToInt64(this.labelCurrentUserId.Text);
            int rateTypeId = Convert.ToInt32(this.labelRateType.Text);
            TBJS_vmRate order = TBHelper.MyRate.GetChangeRateById(userId, id, rateTypeId);
            TBJS_Rate rateById = TBHelper.MyRate.GetRateById(userId, id, rateTypeId);
            if (rateById == null)
                return;
            DataGridView grid = this.dgvRateList;
            lock (grid)
            {
                if (order == null)
                {
                    order = new TBJS_vmRate()
                    {
                        id = rateById.id,
                        userId = userId,
                        user_name = rateById.user_name,
                        item_id_name = rateById.item_id_name,
                        rate_type = rateById.rate_type
                    };
                    TBHelper.MyRate.AddChangeRate(userId, order);
                }
                order.date = this.textBoxRateDateTime.Text;
                order.IsHide = this.checkBoxRateIsHide.Checked;
                order.StatusText = order.IsHide ? "删除评价" : "";
                int local_7 = this.GetGridViewRowIndexById(grid, id, 3);
                if (local_7 == -1)
                    return;
                grid.Rows[local_7].Cells["date"].Value = (object)order.date;
                grid.Rows[local_7].Cells["StatusText"].Value = (object)order.StatusText;
            }
        }

        private void buttonSaveRateCount_Click(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.RateWeekData = this.textBoxRateWeek.Text;
            CaptureConfiguration._advSettings.RateMonth = this.textBoxRateMonth.Text;
            CaptureConfiguration._advSettings.RateHalfYear = this.textBoxHalfYear.Text;
            CaptureConfiguration._advSettings.RateAll = this.textBoxRateAll.Text;
            CaptureConfiguration._advSettings.RateWeekDataForSales = this.textBoxRateWeekForSales.Text;
            CaptureConfiguration._advSettings.RateMonthForSales = this.textBoxRateMonthForSales.Text;
            CaptureConfiguration._advSettings.RateHalfYearForSales = this.textBoxHalfYearForSales.Text;
            CaptureConfiguration._advSettings.RateAllForSales = this.textBoxRateAllForSales.Text;
        }

        private void buttonOneKeyWaitPay_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllWaitPay(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void buttonOnekeyWaitSend_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllWaitSend(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void buttonOnekeyWaitConfirm_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllWaitConfirm(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void buttonOnekeyWaitRate_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllWaitRate(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void buttonOnekeyHide_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllHide(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void buttonOnekeyReset_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllReset(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void buttonResetOrderInfo_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.CurrentRow == null || this.dgvMainOrders.RowCount == 0)
                return;
            int index = dataGridView.CurrentRow.Index;
            long id = Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString());
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.ResetSingleBuyerTrade(TBHelper.CurrentUserInfo.userid, id));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            URLMonInterop.ResetProxyInProcessToDefault();
            if (!FiddlerApplication.IsStarted())
                return;
            FiddlerApplication.Shutdown();
        }

        private static bool setMachineTrust(X509Certificate2 oRootCert)
        {
            X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            x509Store.Open(OpenFlags.ReadWrite);
            try
            {
                x509Store.Add(oRootCert);
            }
            finally
            {
                x509Store.Close();
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this._dtMainOrders.Rows.Clear();
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.ClearDataByUserId(TBHelper.CurrentUserInfo.userid));
            TBHelper.alipayManage.ClearAllData();
            TBHelper.MyRate.ClearAllData();
        }

        private void buttonExportSslCert_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "证书文件(*.crt)|*.crt";
            saveFileDialog.FileName = "火狐证书.crt";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            byte[] rawCertData = CertMaker.GetRootCertificate().GetRawCertData();
            File.WriteAllBytes(saveFileDialog.FileName, rawCertData);
        }

        private void AlipayOrderGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (object)string.Format("{0}", (object)(e.Row.Index + 1));
        }

        private void buttonAlipayOrderSave_Click(object sender, EventArgs e)
        {
            if (this.labelAlipayOrderNumber.Text == "" || this.textBoxAlipayOrderDate.Text == "" || this.textBoxAlipayOrderName.Text == "")
                return;
            DataGridView grid = this.dgvTradeRecords;
            if (grid.RowCount == 0 || grid.CurrentRow == null)
                return;
            string str = this.labelAlipayOrderRowId.Text.Trim();
            long userId = Convert.ToInt64(grid.Rows[grid.CurrentRow.Index].Cells["userid"].Value.ToString());
            TBJS_vmTradeRecord order = TBHelper.alipayManage.GetChangeTradeRecordById(userId, str);
            TBJS_TradeRecord tradeRecordById = TBHelper.alipayManage.GetTradeRecordById(userId, str);
            if (tradeRecordById == null)
                return;
            lock (grid)
            {
                if (order == null)
                {
                    order = new TBJS_vmTradeRecord()
                    {
                        rowid = tradeRecordById.rowid,
                        number = tradeRecordById.number,
                        date = tradeRecordById.date,
                        name = tradeRecordById.name,
                        memo = tradeRecordById.memo,
                        in_amount = tradeRecordById.in_amount,
                        out_amount = tradeRecordById.out_amount,
                        balance = tradeRecordById.balance,
                        from = tradeRecordById.from,
                        userId = userId
                    };
                    TBHelper.alipayManage.AddChangeTradeRecord(userId, order);
                }
                order.name = this.textBoxAlipayOrderName.Text.Trim();
                order.memo = this.textBoxAlipayOrderMemo.Text.Trim();
                order.in_amount = Convert.ToDouble(this.textBoxAlipayOrderInAmount.Text.Trim());
                order.out_amount = Convert.ToDouble(this.textBoxAlipayOrderOutAmount.Text.Trim());
                order.date = this.textBoxAlipayOrderDate.Text;
                order.IsClearMemo = this.checkBoxAlipayOrderIsClearMemo.Checked;
                order.IsHide = this.checkBoxAlipayOrderIsHide.Checked;
                order.StatusText = order.IsHide ? "删除" : "";
                this.buttonAlipayOrderSave.Enabled = false;
                int local_6 = this.GetGridViewRowIndexById(grid, str, "rowid");
                if (local_6 == -1)
                    return;
                grid.Rows[local_6].Cells["date"].Value = (object)order.date;
                grid.Rows[local_6].Cells["name"].Value = (object)order.name;
                grid.Rows[local_6].Cells["memo"].Value = (object)order.memo;
                grid.Rows[local_6].Cells["in_amount"].Value = (object)order.in_amount.ToString();
                grid.Rows[local_6].Cells["out_amount"].Value = (object)order.out_amount.ToString();
                grid.Rows[local_6].Cells["StatusText"].Value = (object)order.StatusText;
            }
        }

        private void AlipayOrderGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.RowCount == 0)
                return;
            lock (dataGridView)
            {
                string local_1 = dataGridView.Rows[e.RowIndex].Cells["rowid"].Value.ToString();
                Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells["userid"].Value.ToString());
                DataRow local_2 = this._dtTradeRecords.Rows.Find((object)local_1);
                if (local_2 == null)
                    return;
                this.labelAlipayOrderRowId.Text = local_2["rowid"].ToString();
                this.labelAlipayOrderNumber.Text = local_2["number"].ToString();
                this.textBoxAlipayOrderDate.Text = local_2["date"].ToString();
                this.textBoxAlipayOrderName.Text = local_2["name"].ToString();
                this.textBoxAlipayOrderMemo.Text = local_2["memo"].ToString();
                this.textBoxAlipayOrderInAmount.Text = local_2["in_amount"].ToString();
                this.textBoxAlipayOrderOutAmount.Text = local_2["out_amount"].ToString();
                this.checkBoxAlipayOrderIsHide.Checked = Convert.ToBoolean(local_2["IsHide"].ToString());
                this.checkBoxAlipayOrderIsClearMemo.Checked = Convert.ToBoolean(local_2["IsClearMemo"].ToString());
                this.buttonAlipayOrderSave.Enabled = true;
            }
        }

        private void AlipayOrderGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AlipayOrderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            lock (dataGridView)
            {
                if (e.RowIndex <= -1 || dataGridView.CurrentRow == null)
                    return;
                string local_1 = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                long local_2 = Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells[9].Value.ToString());
                TBJS_TradeRecord local_3 = TBHelper.alipayManage.GetTradeRecordById(local_2, local_1);
                TBJS_vmTradeRecord local_4 = TBHelper.alipayManage.GetChangeTradeRecordById(local_2, local_1);
                if (local_3 == null)
                    return;
                this.buttonAlipayOrderCancel.Enabled = local_4 != null;
            }
        }

        private void AlipayTrashGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (object)string.Format("{0}", (object)(e.Row.Index + 1));
        }

        private void checkBoxUseFakeWindow_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.UseFakeWindow = this.checkBoxUseFakeWindow.Checked;
            this.SaveConfig();
        }

        private void checkBoxRemovePlaint_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.RemovePlaint = this.checkBoxRemovePlaint.Checked;
            this.SaveConfig();
        }


        private void checkBoxDefiningStop_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.DefiningStop = this.checkBoxDefiningStop.Checked;
            this.SaveConfig();
        }

        private void checkBoxAlipayRecalculate_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.AlipayRecalculate = this.checkBoxAlipayRecalculate.Checked;
            this.SaveConfig();
        }

        private void checkBoxClearListRecyledItems_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.ClearListRecyledItems = this.checkBoxClearAlipayRecyled.Checked;
            this.SaveConfig();
        }

        private void checkBoxClearLogistics_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.ClearLogistics = this.checkBoxClearLogistics.Checked;
            this.SaveConfig();
        }

        private void checkBoxClearNotice_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.ClearNotice = this.checkBoxClearNotice.Checked;
            this.SaveConfig();
        }

        private void buttonAlipayOnekeyHide_Click(object sender, EventArgs e)
        {
            if (this.dgvTradeRecords.CurrentRow == null)
                return;
            long userId = Convert.ToInt64(this.dgvTradeRecords.Rows[this.dgvTradeRecords.CurrentRow.Index].Cells["userid"].Value.ToString());
            TBHelper.alipayManage.OneKeyAllHide(userId);
            this.BindTradeRecords();
        }

        private void OrderListGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            DataGridView dataGridView = (DataGridView)sender;
            string str = dataGridView.Rows[e.RowIndex].Cells["editCreateDay"].Value.ToString();
            string editCreateDay = e.FormattedValue.ToString();
            if (str.Equals(editCreateDay))
                return;
            long id = Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString());
            TaobaoSQL.UpdateTradeInfo(TBHelper.CurrentUserInfo.userid.ToString(), id, Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells["isHide"].Value), editCreateDay, dataGridView.Rows[e.RowIndex].Cells["editTradeStatus"].Value.ToString());
        }

        private void dgvMainOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex <= -1)
                return;
            DataGridViewRow currentRow = dataGridView.CurrentRow;
        }

        private void dgvRateList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.RowCount == 0 || dataGridView.CurrentRow == null)
                return;
            lock (dataGridView)
            {
                long local_1 = Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString());
                long local_2 = Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells["userId"].Value.ToString());
                int local_3 = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["rate_type"].Value.ToString());
                TBJS_vmRate local_4 = TBHelper.MyRate.GetGridViewRateById(local_2, local_1, local_3);
                if (local_4 == null)
                    return;
                this.textBox_RateForOrderId.Text = local_4.id.ToString();
                this.labelCurrentUserId.Text = local_4.userId.ToString();
                this.textBoxRateDateTime.Text = local_4.date;
                this.checkBoxRateIsHide.Checked = local_4.IsHide;
                this.labelRateType.Text = local_4.rate_type.ToString();
            }
        }

        private void dgvRateList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != this.dgvRateList.Rows[e.RowIndex].Cells["rate_type"].ColumnIndex)
                return;
            if (object.Equals(e.Value, (object)1))
                e.Value = (object)"来自卖家的评价";
            else
                e.Value = (object)"给他人的评价";
        }

        private void DrawNum(Graphics gr, string num, int offSetLeft)
        {
            int num1 = 56;
            if (num.Length > 2)
                num = "99+";
            Pen pen = new Pen(Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 81, 22), 5f);
            Brush brush = (Brush)new SolidBrush(Color.White);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int)byte.MaxValue, 192, 85, 33));
            Font font = new Font("FZLanTingHei-L-GBK-M", 32f, FontStyle.Regular, GraphicsUnit.Pixel);
            int y = 660;
            SizeF sizeF = gr.MeasureString(num, font);
            if (num.Length > 2)
            {
                gr.FillEllipse(brush, offSetLeft, y, num1 + 15, num1);
                gr.DrawEllipse(pen, offSetLeft, y, num1 + 15, num1);
                gr.DrawString(num, font, (Brush)solidBrush, (float)((double)(offSetLeft + num1 / 2) - (double)sizeF.Width / 2.0 + 8.0), (float)((double)(y + num1 / 2) - (double)sizeF.Height / 2.0 + 4.0));
            }
            else
            {
                gr.FillEllipse(brush, offSetLeft, y, num1, num1);
                gr.DrawEllipse(pen, offSetLeft, y, num1, num1);
                gr.DrawString(num, font, (Brush)solidBrush, (float)(offSetLeft + num1 / 2) - sizeF.Width / 2f, (float)((double)(y + num1 / 2) - (double)sizeF.Height / 2.0 + 4.0));
            }
        }

        private void DrawTime(Graphics gr, int xPos, int yPos)
        {
            gr.DrawString(DateTime.Now.ToString("hh:mm"), new Font("FZLanTingHei-L-GBK-M", 36f, FontStyle.Regular, GraphicsUnit.Pixel), (Brush)new SolidBrush(Color.FromArgb((int)byte.MaxValue, 209, 230, 235)), (float)xPos, (float)yPos);
        }

        private void DrawUserId(Graphics gr, string UserId, int xPos)
        {
            SolidBrush solidBrush = new SolidBrush(Color.White);
            Font font = new Font("FZLanTingHei-L-GBK-M", 48f, FontStyle.Regular, GraphicsUnit.Pixel);
            int num = 350;
            SizeF sizeF = gr.MeasureString(UserId, font);
            gr.DrawString(UserId, font, (Brush)solidBrush, (float)xPos - sizeF.Width, (float)num);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
                return;
            Image image1 = (Image)Resources.android;
            Image image2 = (Image)null;
            switch (this.textBox6.Text)
            {
                case "0":
                    image2 = (Image)Resources._0;
                    break;
                case "1":
                    image2 = (Image)Resources._1;
                    break;
                case "2":
                    image2 = (Image)Resources._2;
                    break;
                case "3":
                    image2 = (Image)Resources._3;
                    break;
                case "4":
                    image2 = (Image)Resources._4;
                    break;
                case "5":
                    image2 = (Image)Resources._5;
                    break;
            }
            using (Graphics gr = Graphics.FromImage(image1))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.InterpolationMode = InterpolationMode.High;
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                this.DrawUserId(gr, this.textBox1.Text, 578);
                this.DrawTime(gr, 952, 21);
                if (!this.textBox6.Text.Equals("") && image2 != null)
                    gr.DrawImage(image2, 585, 343);
                if (!this.textBox2.Text.Equals(""))
                    this.DrawNum(gr, this.textBox2.Text, 110);
                if (!this.textBox3.Text.Equals(""))
                    this.DrawNum(gr, this.textBox3.Text, 335);
                if (!this.textBox4.Text.Equals(""))
                    this.DrawNum(gr, this.textBox4.Text, 550);
                if (!this.textBox5.Text.Equals(""))
                    this.DrawNum(gr, this.textBox5.Text, 765);
            }
            Clipboard.SetImage(image1);
            int num = (int)MessageBox.Show("手机假后台图片已生成.请按Ctrl+V粘贴至QQ聊天窗口");
        }

        private void checkBoxHideGrowth_CheckedChanged(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.HideGrowth = this.checkBoxHideGrowth.Checked;
            this.SaveConfig();
        }

        private void comboBoxHotKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string str1 = string.Empty;
            IniFile iniFile = new IniFile("config.ini");
            if (comboBox.Name.Contains("Hide"))
            {
                string str2 = string.Format("{0}+{1}+{2}+{3}", (object)this.comboBoxCtrlHotKeyHide.Text, (object)this.comboBoxAltHotKeyHide.Text, (object)this.comboBoxShiftHotKeyHide.Text, (object)this.comboBoxAlphaHotKeyHide.Text);
                iniFile.WriteString("HotKey", "HideKey", str2);
            }
            else if (comboBox.Name.Contains("Start"))
            {
                string str2 = string.Format("{0}+{1}+{2}+{3}", (object)this.comboBoxCtrlHotKeyStart.Text, (object)this.comboBoxAltHotKeyStart.Text, (object)this.comboBoxShiftHotKeyStart.Text, (object)this.comboBoxAlphaHotKeyStart.Text);
                iniFile.WriteString("HotKey", "StartKey", str2);
            }
            else if (comboBox.Name.Contains("Stop"))
            {
                string str2 = string.Format("{0}+{1}+{2}+{3}", (object)this.comboBoxCtrlHotKeyStop.Text, (object)this.comboBoxAltHotKeyStop.Text, (object)this.comboBoxShiftHotKeyStop.Text, (object)this.comboBoxAlphaHotKeyStop.Text);
                iniFile.WriteString("HotKey", "StopKey", str2);
            }
            else if (comboBox.Name.Contains("Https"))
            {
                string str2 = string.Format("{0}+{1}+{2}+{3}", (object)this.comboBoxCtrlHotKeyHttps.Text, (object)this.comboBoxAltHotKeyHttps.Text, (object)this.comboBoxShiftHotKeyHttps.Text, (object)this.comboBoxAlphaHotKeyHttps.Text);
                iniFile.WriteString("HotKey", "HttpKey", str2);
            }
            else
            {
                if (!comboBox.Name.Contains("Http"))
                    return;
                string str2 = string.Format("{0}+{1}+{2}+{3}", (object)this.comboBoxCtrlHotKeyHttp.Text, (object)this.comboBoxAltHotKeyHttp.Text, (object)this.comboBoxShiftHotKeyHttp.Text, (object)this.comboBoxAlphaHotKeyHttp.Text);
                iniFile.WriteString("HotKey", "HttpsKey", str2);
            }
        }

        private void checkBoxClearListRecyledItems_CheckedChanged_1(object sender, EventArgs e)
        {
            CaptureConfiguration._advSettings.ClearTaoBaoListRecyledItems = this.checkBoxClearListRecyledItems.Checked;
            this.SaveConfig();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkBoxRemovePlaint = new System.Windows.Forms.CheckBox();
            this.MaintabControl = new System.Windows.Forms.TabControl();
            this.OrderListTabPage = new System.Windows.Forms.TabPage();
            this.dgvMainOrders = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editCreateDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellerNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editTradeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isHide = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OrderListInfo = new System.Windows.Forms.Panel();
            this.labelCurrentPageIndex = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.labelCurrentUserInfo = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.RateListTabPage = new System.Windows.Forms.TabPage();
            this.RateListGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.buttonRateModify = new System.Windows.Forms.Button();
            this.textBox_RateForOrderId = new System.Windows.Forms.TextBox();
            this.dgvRateList = new System.Windows.Forms.DataGridView();
            this.labelRateType = new System.Windows.Forms.Label();
            this.textBoxRateDateTime = new System.Windows.Forms.TextBox();
            this.labelCurrentUserId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBoxRateIsHide = new System.Windows.Forms.CheckBox();
            this.RateListInfo = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonSaveRateCount = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxRateAll = new System.Windows.Forms.TextBox();
            this.textBoxHalfYear = new System.Windows.Forms.TextBox();
            this.textBoxRateMonth = new System.Windows.Forms.TextBox();
            this.textBoxRateWeek = new System.Windows.Forms.TextBox();
            this.AlipayOrderTabPage = new System.Windows.Forms.TabPage();
            this.dgvTradeRecords = new System.Windows.Forms.DataGridView();
            this.AlipayOrderInfo = new System.Windows.Forms.Panel();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.buttonAlipayOnekeyHide = new System.Windows.Forms.Button();
            this.checkBoxAlipayOrderIsHide = new System.Windows.Forms.CheckBox();
            this.buttonAlipayOrderCancel = new System.Windows.Forms.Button();
            this.buttonAlipayOrderSave = new System.Windows.Forms.Button();
            this.checkBoxAlipayOrderIsClearMemo = new System.Windows.Forms.CheckBox();
            this.labelAlipayOrderNumber = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxAlipayOrderInAmount = new System.Windows.Forms.TextBox();
            this.textBoxAlipayOrderMemo = new System.Windows.Forms.TextBox();
            this.textBoxAlipayOrderName = new System.Windows.Forms.TextBox();
            this.textBoxAlipayOrderDate = new System.Windows.Forms.TextBox();
            this.textBoxAlipayOrderOutAmount = new System.Windows.Forms.TextBox();
            this.AlipayTrashTabPage = new System.Windows.Forms.TabPage();
            this.AlipayTrashGridView = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlipayTrashInfo = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPageAdvSet = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxUseFakeWindow = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonInstallSslCert = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonUninstallSslCert = new System.Windows.Forms.Button();
            this.buttonExportSslCert = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxClearAlipayRecyled = new System.Windows.Forms.CheckBox();
            this.checkBoxAlipayRecalculate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBoxClearListRecyledItems = new System.Windows.Forms.CheckBox();
            this.checkBoxHideGrowth = new System.Windows.Forms.CheckBox();
            this.checkBoxClearLogistics = new System.Windows.Forms.CheckBox();
            this.checkBoxClearNotice = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.buttonSaveProxyPort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProxyPort = new System.Windows.Forms.TextBox();
            this.tabPageIPEm = new System.Windows.Forms.TabPage();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tabPageMobile = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.textBoxRateAllForSales = new System.Windows.Forms.TextBox();
            this.textBoxHalfYearForSales = new System.Windows.Forms.TextBox();
            this.textBoxRateMonthForSales = new System.Windows.Forms.TextBox();
            this.textBoxRateWeekForSales = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.checkBoxDefiningStop = new System.Windows.Forms.CheckBox();
            this.labelAlipayOrderRowId = new System.Windows.Forms.Label();
            this.comboBoxAlphaHotKeyHttps = new System.Windows.Forms.ComboBox();
            this.comboBoxCtrlHotKeyHttp = new System.Windows.Forms.ComboBox();
            this.buttonResetOrderInfo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelHttpMode = new System.Windows.Forms.Label();
            this.comboBoxCtrlHotKeyHide = new System.Windows.Forms.ComboBox();
            this.comboBoxShiftHotKeyHttps = new System.Windows.Forms.ComboBox();
            this.comboBoxAltHotKeyHide = new System.Windows.Forms.ComboBox();
            this.comboBoxAlphaHotKeyHttp = new System.Windows.Forms.ComboBox();
            this.buttonOnekeyReset = new System.Windows.Forms.Button();
            this.comboBoxShiftHotKeyHide = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonOnekeyWaitRate = new System.Windows.Forms.Button();
            this.comboBoxAltHotKeyHttps = new System.Windows.Forms.ComboBox();
            this.buttonOnekeyWaitSend = new System.Windows.Forms.Button();
            this.buttonOnekeyWaitConfirm = new System.Windows.Forms.Button();
            this.buttonOnekeyHide = new System.Windows.Forms.Button();
            this.buttonOneKeyWaitPay = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.comboBoxShiftHotKeyStop = new System.Windows.Forms.ComboBox();
            this.comboBoxCtrlHotKeyHttps = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.comboBoxShiftHotKeyHttp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.comboBoxAltHotKeyHttp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.comboBoxAltHotKeyStop = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.comboBoxCtrlHotKeyStop = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxCtrlHotKeyStart = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxAltHotKeyStart = new System.Windows.Forms.ComboBox();
            this.comboBoxShiftHotKeyStart = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxAlphaHotKeyStop = new System.Windows.Forms.ComboBox();
            this.comboBoxAlphaHotKeyStart = new System.Windows.Forms.ComboBox();
            this.comboBoxAlphaHotKeyHide = new System.Windows.Forms.ComboBox();
            this.contextMenuStripOrderList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemTradOk = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderHide = new System.Windows.Forms.ToolStripMenuItem();
            this.批量隐藏订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一键收货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一键评价ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrandNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonQuitApp = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_shiming = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.label54 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.MaintabControl.SuspendLayout();
            this.OrderListTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainOrders)).BeginInit();
            this.OrderListInfo.SuspendLayout();
            this.RateListTabPage.SuspendLayout();
            this.RateListGroupBox.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateList)).BeginInit();
            this.RateListInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.AlipayOrderTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeRecords)).BeginInit();
            this.AlipayOrderInfo.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.AlipayTrashTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlipayTrashGridView)).BeginInit();
            this.AlipayTrashInfo.SuspendLayout();
            this.tabPageAdvSet.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageIPEm.SuspendLayout();
            this.tabPageMobile.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.contextMenuStripOrderList.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxRemovePlaint
            // 
            this.checkBoxRemovePlaint.AutoSize = true;
            this.checkBoxRemovePlaint.Location = new System.Drawing.Point(6, 41);
            this.checkBoxRemovePlaint.Name = "checkBoxRemovePlaint";
            this.checkBoxRemovePlaint.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRemovePlaint.TabIndex = 16;
            this.checkBoxRemovePlaint.Text = "去感叹号";
            this.checkBoxRemovePlaint.UseVisualStyleBackColor = true;
            this.checkBoxRemovePlaint.CheckedChanged += new System.EventHandler(this.checkBoxRemovePlaint_CheckedChanged);
            // 
            // MaintabControl
            // 
            this.MaintabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.MaintabControl.Controls.Add(this.OrderListTabPage);
            this.MaintabControl.Controls.Add(this.RateListTabPage);
            this.MaintabControl.Controls.Add(this.AlipayOrderTabPage);
            this.MaintabControl.Controls.Add(this.AlipayTrashTabPage);
            this.MaintabControl.Controls.Add(this.tabPageAdvSet);
            this.MaintabControl.Controls.Add(this.tabPageIPEm);
            this.MaintabControl.Controls.Add(this.tabPageMobile);
            this.MaintabControl.Controls.Add(this.tabPage1);
            this.MaintabControl.Location = new System.Drawing.Point(0, 100);
            this.MaintabControl.Multiline = true;
            this.MaintabControl.Name = "MaintabControl";
            this.MaintabControl.SelectedIndex = 0;
            this.MaintabControl.Size = new System.Drawing.Size(790, 397);
            this.MaintabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MaintabControl.TabIndex = 3;
            // 
            // OrderListTabPage
            // 
            this.OrderListTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrderListTabPage.Controls.Add(this.dgvMainOrders);
            this.OrderListTabPage.Controls.Add(this.OrderListInfo);
            this.OrderListTabPage.Location = new System.Drawing.Point(4, 49);
            this.OrderListTabPage.Name = "OrderListTabPage";
            this.OrderListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrderListTabPage.Size = new System.Drawing.Size(782, 344);
            this.OrderListTabPage.TabIndex = 0;
            this.OrderListTabPage.Text = "已买宝贝";
            this.OrderListTabPage.UseVisualStyleBackColor = true;
            // 
            // dgvMainOrders
            // 
            this.dgvMainOrders.AllowUserToAddRows = false;
            this.dgvMainOrders.AllowUserToDeleteRows = false;
            this.dgvMainOrders.AllowUserToResizeRows = false;
            this.dgvMainOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMainOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMainOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.editCreateDay,
            this.sellerNickName,
            this.editTradeStatus,
            this.isHide});
            this.dgvMainOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainOrders.Location = new System.Drawing.Point(3, 30);
            this.dgvMainOrders.MultiSelect = false;
            this.dgvMainOrders.Name = "dgvMainOrders";
            this.dgvMainOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvMainOrders.Size = new System.Drawing.Size(774, 309);
            this.dgvMainOrders.TabIndex = 0;
            this.dgvMainOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainOrders_CellClick);
            this.dgvMainOrders.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.OrderListGridView_CellValidating);
            this.dgvMainOrders.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewOrderList_RowStateChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "订单号";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Width = 188;
            // 
            // editCreateDay
            // 
            this.editCreateDay.DataPropertyName = "editCreateDay";
            this.editCreateDay.HeaderText = "交易日期 ";
            this.editCreateDay.Name = "editCreateDay";
            this.editCreateDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sellerNickName
            // 
            this.sellerNickName.DataPropertyName = "sellerNickName";
            this.sellerNickName.HeaderText = "旺旺名称";
            this.sellerNickName.Name = "sellerNickName";
            this.sellerNickName.ReadOnly = true;
            this.sellerNickName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sellerNickName.Width = 200;
            // 
            // editTradeStatus
            // 
            this.editTradeStatus.DataPropertyName = "editTradeStatus";
            this.editTradeStatus.HeaderText = "交易状态";
            this.editTradeStatus.Name = "editTradeStatus";
            this.editTradeStatus.ReadOnly = true;
            this.editTradeStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editTradeStatus.Width = 130;
            // 
            // isHide
            // 
            this.isHide.DataPropertyName = "isHide";
            this.isHide.HeaderText = "隐藏状态";
            this.isHide.Name = "isHide";
            this.isHide.ReadOnly = true;
            this.isHide.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OrderListInfo
            // 
            this.OrderListInfo.Controls.Add(this.labelCurrentPageIndex);
            this.OrderListInfo.Controls.Add(this.label47);
            this.OrderListInfo.Controls.Add(this.labelCurrentUserInfo);
            this.OrderListInfo.Controls.Add(this.label46);
            this.OrderListInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.OrderListInfo.Location = new System.Drawing.Point(3, 3);
            this.OrderListInfo.Name = "OrderListInfo";
            this.OrderListInfo.Size = new System.Drawing.Size(774, 27);
            this.OrderListInfo.TabIndex = 1;
            // 
            // labelCurrentPageIndex
            // 
            this.labelCurrentPageIndex.AutoSize = true;
            this.labelCurrentPageIndex.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentPageIndex.Location = new System.Drawing.Point(655, 8);
            this.labelCurrentPageIndex.Name = "labelCurrentPageIndex";
            this.labelCurrentPageIndex.Size = new System.Drawing.Size(83, 12);
            this.labelCurrentPageIndex.TabIndex = 21;
            this.labelCurrentPageIndex.Text = "等待获取.....";
            this.labelCurrentPageIndex.Click += new System.EventHandler(this.labelCurrentPageIndex_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.Location = new System.Drawing.Point(597, 8);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(65, 12);
            this.label47.TabIndex = 22;
            this.label47.Text = "订单数量：";
            // 
            // labelCurrentUserInfo
            // 
            this.labelCurrentUserInfo.AutoSize = true;
            this.labelCurrentUserInfo.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentUserInfo.ForeColor = System.Drawing.Color.Red;
            this.labelCurrentUserInfo.Location = new System.Drawing.Point(56, 8);
            this.labelCurrentUserInfo.Name = "labelCurrentUserInfo";
            this.labelCurrentUserInfo.Size = new System.Drawing.Size(77, 12);
            this.labelCurrentUserInfo.TabIndex = 5;
            this.labelCurrentUserInfo.Text = "刷新页面显示";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.Color.Red;
            this.label46.Location = new System.Drawing.Point(11, 8);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(53, 12);
            this.label46.TabIndex = 6;
            this.label46.Text = "淘宝名：";
            // 
            // RateListTabPage
            // 
            this.RateListTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RateListTabPage.Controls.Add(this.RateListGroupBox);
            this.RateListTabPage.Controls.Add(this.RateListInfo);
            this.RateListTabPage.Location = new System.Drawing.Point(4, 49);
            this.RateListTabPage.Name = "RateListTabPage";
            this.RateListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RateListTabPage.Size = new System.Drawing.Size(782, 344);
            this.RateListTabPage.TabIndex = 0;
            this.RateListTabPage.Text = "评价管理";
            this.RateListTabPage.UseVisualStyleBackColor = true;
            // 
            // RateListGroupBox
            // 
            this.RateListGroupBox.Controls.Add(this.groupBox14);
            this.RateListGroupBox.Controls.Add(this.buttonRateModify);
            this.RateListGroupBox.Controls.Add(this.textBox_RateForOrderId);
            this.RateListGroupBox.Controls.Add(this.dgvRateList);
            this.RateListGroupBox.Controls.Add(this.labelRateType);
            this.RateListGroupBox.Controls.Add(this.textBoxRateDateTime);
            this.RateListGroupBox.Controls.Add(this.labelCurrentUserId);
            this.RateListGroupBox.Controls.Add(this.label3);
            this.RateListGroupBox.Controls.Add(this.label15);
            this.RateListGroupBox.Controls.Add(this.checkBoxRateIsHide);
            this.RateListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RateListGroupBox.Location = new System.Drawing.Point(3, 64);
            this.RateListGroupBox.Name = "RateListGroupBox";
            this.RateListGroupBox.Size = new System.Drawing.Size(774, 275);
            this.RateListGroupBox.TabIndex = 3;
            this.RateListGroupBox.TabStop = false;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.checkBox5);
            this.groupBox14.Location = new System.Drawing.Point(619, 183);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(148, 86);
            this.groupBox14.TabIndex = 39;
            this.groupBox14.TabStop = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(6, 20);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(108, 16);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "实名身份证小图";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // buttonRateModify
            // 
            this.buttonRateModify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRateModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRateModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRateModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRateModify.Location = new System.Drawing.Point(623, 143);
            this.buttonRateModify.Name = "buttonRateModify";
            this.buttonRateModify.Size = new System.Drawing.Size(68, 34);
            this.buttonRateModify.TabIndex = 35;
            this.buttonRateModify.Text = "修改";
            this.buttonRateModify.UseVisualStyleBackColor = true;
            this.buttonRateModify.Click += new System.EventHandler(this.buttonRateModify_Click);
            // 
            // textBox_RateForOrderId
            // 
            this.textBox_RateForOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RateForOrderId.Location = new System.Drawing.Point(618, 34);
            this.textBox_RateForOrderId.Name = "textBox_RateForOrderId";
            this.textBox_RateForOrderId.ReadOnly = true;
            this.textBox_RateForOrderId.Size = new System.Drawing.Size(149, 21);
            this.textBox_RateForOrderId.TabIndex = 38;
            // 
            // dgvRateList
            // 
            this.dgvRateList.AllowUserToAddRows = false;
            this.dgvRateList.AllowUserToDeleteRows = false;
            this.dgvRateList.AllowUserToResizeRows = false;
            this.dgvRateList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRateList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRateList.Location = new System.Drawing.Point(3, 17);
            this.dgvRateList.MultiSelect = false;
            this.dgvRateList.Name = "dgvRateList";
            this.dgvRateList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvRateList.Size = new System.Drawing.Size(607, 284);
            this.dgvRateList.TabIndex = 1;
            this.dgvRateList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRateList_CellDoubleClick);
            this.dgvRateList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRateList_CellFormatting);
            this.dgvRateList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewRateList_RowStateChanged);
            // 
            // labelRateType
            // 
            this.labelRateType.AutoSize = true;
            this.labelRateType.Location = new System.Drawing.Point(536, 96);
            this.labelRateType.Name = "labelRateType";
            this.labelRateType.Size = new System.Drawing.Size(17, 12);
            this.labelRateType.TabIndex = 37;
            this.labelRateType.Text = "rb";
            this.labelRateType.Visible = false;
            // 
            // textBoxRateDateTime
            // 
            this.textBoxRateDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRateDateTime.Location = new System.Drawing.Point(619, 82);
            this.textBoxRateDateTime.Name = "textBoxRateDateTime";
            this.textBoxRateDateTime.Size = new System.Drawing.Size(149, 21);
            this.textBoxRateDateTime.TabIndex = 33;
            // 
            // labelCurrentUserId
            // 
            this.labelCurrentUserId.AutoSize = true;
            this.labelCurrentUserId.Location = new System.Drawing.Point(621, 106);
            this.labelCurrentUserId.Name = "labelCurrentUserId";
            this.labelCurrentUserId.Size = new System.Drawing.Size(47, 12);
            this.labelCurrentUserId.TabIndex = 36;
            this.labelCurrentUserId.Text = "订单号:";
            this.labelCurrentUserId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(616, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "订单号:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(616, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 32;
            this.label15.Text = "评价时间:";
            // 
            // checkBoxRateIsHide
            // 
            this.checkBoxRateIsHide.AutoSize = true;
            this.checkBoxRateIsHide.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.checkBoxRateIsHide.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkBoxRateIsHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxRateIsHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.checkBoxRateIsHide.Location = new System.Drawing.Point(623, 121);
            this.checkBoxRateIsHide.Name = "checkBoxRateIsHide";
            this.checkBoxRateIsHide.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRateIsHide.TabIndex = 34;
            this.checkBoxRateIsHide.Text = "删除评价";
            this.checkBoxRateIsHide.UseVisualStyleBackColor = true;
            // 
            // RateListInfo
            // 
            this.RateListInfo.Controls.Add(this.groupBox3);
            this.RateListInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.RateListInfo.Location = new System.Drawing.Point(3, 3);
            this.RateListInfo.Name = "RateListInfo";
            this.RateListInfo.Size = new System.Drawing.Size(774, 61);
            this.RateListInfo.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.buttonSaveRateCount);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.textBoxRateAll);
            this.groupBox3.Controls.Add(this.textBoxHalfYear);
            this.groupBox3.Controls.Add(this.textBoxRateMonth);
            this.groupBox3.Controls.Add(this.textBoxRateWeek);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(607, 50);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(277, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 23;
            this.label19.Text = "半年之前";
            // 
            // buttonSaveRateCount
            // 
            this.buttonSaveRateCount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSaveRateCount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonSaveRateCount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonSaveRateCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveRateCount.Location = new System.Drawing.Point(404, 14);
            this.buttonSaveRateCount.Name = "buttonSaveRateCount";
            this.buttonSaveRateCount.Size = new System.Drawing.Size(66, 29);
            this.buttonSaveRateCount.TabIndex = 11;
            this.buttonSaveRateCount.Text = "保存";
            this.buttonSaveRateCount.UseVisualStyleBackColor = true;
            this.buttonSaveRateCount.Click += new System.EventHandler(this.buttonSaveRateCount_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(185, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "半年";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 21;
            this.label17.Text = "月";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "周";
            // 
            // textBoxRateAll
            // 
            this.textBoxRateAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRateAll.Location = new System.Drawing.Point(334, 19);
            this.textBoxRateAll.Name = "textBoxRateAll";
            this.textBoxRateAll.Size = new System.Drawing.Size(42, 21);
            this.textBoxRateAll.TabIndex = 19;
            // 
            // textBoxHalfYear
            // 
            this.textBoxHalfYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHalfYear.Location = new System.Drawing.Point(218, 19);
            this.textBoxHalfYear.Name = "textBoxHalfYear";
            this.textBoxHalfYear.Size = new System.Drawing.Size(42, 21);
            this.textBoxHalfYear.TabIndex = 18;
            // 
            // textBoxRateMonth
            // 
            this.textBoxRateMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRateMonth.Location = new System.Drawing.Point(122, 19);
            this.textBoxRateMonth.Name = "textBoxRateMonth";
            this.textBoxRateMonth.Size = new System.Drawing.Size(42, 21);
            this.textBoxRateMonth.TabIndex = 17;
            // 
            // textBoxRateWeek
            // 
            this.textBoxRateWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRateWeek.Location = new System.Drawing.Point(37, 19);
            this.textBoxRateWeek.Name = "textBoxRateWeek";
            this.textBoxRateWeek.Size = new System.Drawing.Size(42, 21);
            this.textBoxRateWeek.TabIndex = 16;
            // 
            // AlipayOrderTabPage
            // 
            this.AlipayOrderTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlipayOrderTabPage.Controls.Add(this.dgvTradeRecords);
            this.AlipayOrderTabPage.Controls.Add(this.AlipayOrderInfo);
            this.AlipayOrderTabPage.Location = new System.Drawing.Point(4, 49);
            this.AlipayOrderTabPage.Name = "AlipayOrderTabPage";
            this.AlipayOrderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AlipayOrderTabPage.Size = new System.Drawing.Size(782, 344);
            this.AlipayOrderTabPage.TabIndex = 1;
            this.AlipayOrderTabPage.Text = "支付宝明细";
            this.AlipayOrderTabPage.UseVisualStyleBackColor = true;
            // 
            // dgvTradeRecords
            // 
            this.dgvTradeRecords.AllowUserToAddRows = false;
            this.dgvTradeRecords.AllowUserToDeleteRows = false;
            this.dgvTradeRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTradeRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTradeRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTradeRecords.Location = new System.Drawing.Point(3, 103);
            this.dgvTradeRecords.MultiSelect = false;
            this.dgvTradeRecords.Name = "dgvTradeRecords";
            this.dgvTradeRecords.ReadOnly = true;
            this.dgvTradeRecords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTradeRecords.RowTemplate.Height = 23;
            this.dgvTradeRecords.Size = new System.Drawing.Size(776, 265);
            this.dgvTradeRecords.TabIndex = 4;
            this.dgvTradeRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AlipayOrderGridView_CellClick);
            this.dgvTradeRecords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AlipayOrderGridView_CellContentClick);
            this.dgvTradeRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AlipayOrderGridView_CellDoubleClick);
            this.dgvTradeRecords.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AlipayOrderGridView_RowStateChanged);
            // 
            // AlipayOrderInfo
            // 
            this.AlipayOrderInfo.Controls.Add(this.groupBox12);
            this.AlipayOrderInfo.Controls.Add(this.labelAlipayOrderNumber);
            this.AlipayOrderInfo.Controls.Add(this.label27);
            this.AlipayOrderInfo.Controls.Add(this.label28);
            this.AlipayOrderInfo.Controls.Add(this.label26);
            this.AlipayOrderInfo.Controls.Add(this.label25);
            this.AlipayOrderInfo.Controls.Add(this.label14);
            this.AlipayOrderInfo.Controls.Add(this.label23);
            this.AlipayOrderInfo.Controls.Add(this.textBoxAlipayOrderInAmount);
            this.AlipayOrderInfo.Controls.Add(this.textBoxAlipayOrderMemo);
            this.AlipayOrderInfo.Controls.Add(this.textBoxAlipayOrderName);
            this.AlipayOrderInfo.Controls.Add(this.textBoxAlipayOrderDate);
            this.AlipayOrderInfo.Controls.Add(this.textBoxAlipayOrderOutAmount);
            this.AlipayOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlipayOrderInfo.Location = new System.Drawing.Point(3, 3);
            this.AlipayOrderInfo.Name = "AlipayOrderInfo";
            this.AlipayOrderInfo.Size = new System.Drawing.Size(774, 108);
            this.AlipayOrderInfo.TabIndex = 3;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.buttonAlipayOnekeyHide);
            this.groupBox12.Controls.Add(this.checkBoxAlipayOrderIsHide);
            this.groupBox12.Controls.Add(this.buttonAlipayOrderCancel);
            this.groupBox12.Controls.Add(this.buttonAlipayOrderSave);
            this.groupBox12.Controls.Add(this.checkBoxAlipayOrderIsClearMemo);
            this.groupBox12.Location = new System.Drawing.Point(496, -6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(275, 99);
            this.groupBox12.TabIndex = 26;
            this.groupBox12.TabStop = false;
            // 
            // buttonAlipayOnekeyHide
            // 
            this.buttonAlipayOnekeyHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAlipayOnekeyHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonAlipayOnekeyHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAlipayOnekeyHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlipayOnekeyHide.Location = new System.Drawing.Point(93, 70);
            this.buttonAlipayOnekeyHide.Name = "buttonAlipayOnekeyHide";
            this.buttonAlipayOnekeyHide.Size = new System.Drawing.Size(80, 25);
            this.buttonAlipayOnekeyHide.TabIndex = 25;
            this.buttonAlipayOnekeyHide.Text = "一键删除";
            this.buttonAlipayOnekeyHide.UseVisualStyleBackColor = true;
            this.buttonAlipayOnekeyHide.Click += new System.EventHandler(this.buttonAlipayOnekeyHide_Click);
            // 
            // checkBoxAlipayOrderIsHide
            // 
            this.checkBoxAlipayOrderIsHide.AutoSize = true;
            this.checkBoxAlipayOrderIsHide.Checked = true;
            this.checkBoxAlipayOrderIsHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlipayOrderIsHide.Location = new System.Drawing.Point(18, 46);
            this.checkBoxAlipayOrderIsHide.Name = "checkBoxAlipayOrderIsHide";
            this.checkBoxAlipayOrderIsHide.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAlipayOrderIsHide.TabIndex = 22;
            this.checkBoxAlipayOrderIsHide.Text = "删除记录";
            this.checkBoxAlipayOrderIsHide.UseVisualStyleBackColor = true;
            // 
            // buttonAlipayOrderCancel
            // 
            this.buttonAlipayOrderCancel.Enabled = false;
            this.buttonAlipayOrderCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAlipayOrderCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonAlipayOrderCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAlipayOrderCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlipayOrderCancel.Location = new System.Drawing.Point(93, 40);
            this.buttonAlipayOrderCancel.Name = "buttonAlipayOrderCancel";
            this.buttonAlipayOrderCancel.Size = new System.Drawing.Size(80, 25);
            this.buttonAlipayOrderCancel.TabIndex = 11;
            this.buttonAlipayOrderCancel.Text = "取消";
            this.buttonAlipayOrderCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAlipayOrderSave
            // 
            this.buttonAlipayOrderSave.Enabled = false;
            this.buttonAlipayOrderSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAlipayOrderSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonAlipayOrderSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAlipayOrderSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlipayOrderSave.Location = new System.Drawing.Point(93, 11);
            this.buttonAlipayOrderSave.Name = "buttonAlipayOrderSave";
            this.buttonAlipayOrderSave.Size = new System.Drawing.Size(80, 25);
            this.buttonAlipayOrderSave.TabIndex = 6;
            this.buttonAlipayOrderSave.Text = "修改";
            this.buttonAlipayOrderSave.UseVisualStyleBackColor = true;
            this.buttonAlipayOrderSave.Click += new System.EventHandler(this.buttonAlipayOrderSave_Click);
            // 
            // checkBoxAlipayOrderIsClearMemo
            // 
            this.checkBoxAlipayOrderIsClearMemo.AutoSize = true;
            this.checkBoxAlipayOrderIsClearMemo.Location = new System.Drawing.Point(18, 20);
            this.checkBoxAlipayOrderIsClearMemo.Name = "checkBoxAlipayOrderIsClearMemo";
            this.checkBoxAlipayOrderIsClearMemo.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAlipayOrderIsClearMemo.TabIndex = 5;
            this.checkBoxAlipayOrderIsClearMemo.Text = "清除备注";
            this.checkBoxAlipayOrderIsClearMemo.UseVisualStyleBackColor = true;
            // 
            // labelAlipayOrderNumber
            // 
            this.labelAlipayOrderNumber.AutoSize = true;
            this.labelAlipayOrderNumber.Location = new System.Drawing.Point(88, 13);
            this.labelAlipayOrderNumber.Name = "labelAlipayOrderNumber";
            this.labelAlipayOrderNumber.Size = new System.Drawing.Size(35, 12);
            this.labelAlipayOrderNumber.TabIndex = 23;
            this.labelAlipayOrderNumber.Text = "     ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(307, 62);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 12);
            this.label27.TabIndex = 20;
            this.label27.Text = "支出:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(52, 63);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 12);
            this.label28.TabIndex = 19;
            this.label28.Text = "收入:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(307, 37);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 12);
            this.label26.TabIndex = 18;
            this.label26.Text = "备注:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(28, 38);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 12);
            this.label25.TabIndex = 17;
            this.label25.Text = "交易名称:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "交易流水号:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(282, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 12);
            this.label23.TabIndex = 12;
            this.label23.Text = "交易时间:";
            // 
            // textBoxAlipayOrderInAmount
            // 
            this.textBoxAlipayOrderInAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAlipayOrderInAmount.Location = new System.Drawing.Point(88, 59);
            this.textBoxAlipayOrderInAmount.Name = "textBoxAlipayOrderInAmount";
            this.textBoxAlipayOrderInAmount.Size = new System.Drawing.Size(159, 21);
            this.textBoxAlipayOrderInAmount.TabIndex = 10;
            // 
            // textBoxAlipayOrderMemo
            // 
            this.textBoxAlipayOrderMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAlipayOrderMemo.Location = new System.Drawing.Point(342, 33);
            this.textBoxAlipayOrderMemo.Name = "textBoxAlipayOrderMemo";
            this.textBoxAlipayOrderMemo.Size = new System.Drawing.Size(148, 21);
            this.textBoxAlipayOrderMemo.TabIndex = 9;
            // 
            // textBoxAlipayOrderName
            // 
            this.textBoxAlipayOrderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAlipayOrderName.Location = new System.Drawing.Point(88, 34);
            this.textBoxAlipayOrderName.Name = "textBoxAlipayOrderName";
            this.textBoxAlipayOrderName.Size = new System.Drawing.Size(159, 21);
            this.textBoxAlipayOrderName.TabIndex = 8;
            // 
            // textBoxAlipayOrderDate
            // 
            this.textBoxAlipayOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAlipayOrderDate.Location = new System.Drawing.Point(342, 7);
            this.textBoxAlipayOrderDate.Name = "textBoxAlipayOrderDate";
            this.textBoxAlipayOrderDate.Size = new System.Drawing.Size(148, 21);
            this.textBoxAlipayOrderDate.TabIndex = 7;
            // 
            // textBoxAlipayOrderOutAmount
            // 
            this.textBoxAlipayOrderOutAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAlipayOrderOutAmount.Location = new System.Drawing.Point(342, 60);
            this.textBoxAlipayOrderOutAmount.Name = "textBoxAlipayOrderOutAmount";
            this.textBoxAlipayOrderOutAmount.Size = new System.Drawing.Size(148, 21);
            this.textBoxAlipayOrderOutAmount.TabIndex = 4;
            // 
            // AlipayTrashTabPage
            // 
            this.AlipayTrashTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlipayTrashTabPage.Controls.Add(this.AlipayTrashGridView);
            this.AlipayTrashTabPage.Controls.Add(this.AlipayTrashInfo);
            this.AlipayTrashTabPage.Location = new System.Drawing.Point(4, 49);
            this.AlipayTrashTabPage.Name = "AlipayTrashTabPage";
            this.AlipayTrashTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AlipayTrashTabPage.Size = new System.Drawing.Size(782, 344);
            this.AlipayTrashTabPage.TabIndex = 3;
            this.AlipayTrashTabPage.Text = "支付宝回收站";
            this.AlipayTrashTabPage.UseVisualStyleBackColor = true;
            // 
            // AlipayTrashGridView
            // 
            this.AlipayTrashGridView.AllowUserToAddRows = false;
            this.AlipayTrashGridView.AllowUserToDeleteRows = false;
            this.AlipayTrashGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AlipayTrashGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AlipayTrashGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.AlipayTrashGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlipayTrashGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22});
            this.AlipayTrashGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlipayTrashGridView.Enabled = false;
            this.AlipayTrashGridView.Location = new System.Drawing.Point(3, 91);
            this.AlipayTrashGridView.Name = "AlipayTrashGridView";
            this.AlipayTrashGridView.ReadOnly = true;
            this.AlipayTrashGridView.RowTemplate.Height = 23;
            this.AlipayTrashGridView.Size = new System.Drawing.Size(774, 248);
            this.AlipayTrashGridView.TabIndex = 5;
            this.AlipayTrashGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AlipayTrashGridView_RowStateChanged);
            // 
            // Column15
            // 
            this.Column15.HeaderText = "流水号";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "删除时间";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "名称";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "对方";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "金额";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "状态";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "操作";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "用户代号";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Visible = false;
            // 
            // AlipayTrashInfo
            // 
            this.AlipayTrashInfo.Controls.Add(this.button2);
            this.AlipayTrashInfo.Controls.Add(this.label55);
            this.AlipayTrashInfo.Controls.Add(this.textBox9);
            this.AlipayTrashInfo.Controls.Add(this.label20);
            this.AlipayTrashInfo.Controls.Add(this.label31);
            this.AlipayTrashInfo.Controls.Add(this.button7);
            this.AlipayTrashInfo.Controls.Add(this.button8);
            this.AlipayTrashInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlipayTrashInfo.Location = new System.Drawing.Point(3, 3);
            this.AlipayTrashInfo.Name = "AlipayTrashInfo";
            this.AlipayTrashInfo.Size = new System.Drawing.Size(774, 88);
            this.AlipayTrashInfo.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(415, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 24);
            this.button2.TabIndex = 24;
            this.button2.Text = "点击跳到";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(17, 51);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(401, 12);
            this.label55.TabIndex = 23;
            this.label55.Text = "为节省资源，此功能已关闭，请使用[高级功能]下的（清空支付宝回收站）";
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(70, 8);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(204, 21);
            this.textBox9.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(148, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 21;
            this.label20.Text = "流水号:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Enabled = false;
            this.label31.Location = new System.Drawing.Point(17, 13);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 12);
            this.label31.TabIndex = 16;
            this.label31.Text = "流水号:";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(543, 38);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 25);
            this.button7.TabIndex = 11;
            this.button7.Text = "删除当前页";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(543, 7);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(80, 25);
            this.button8.TabIndex = 6;
            this.button8.Text = "删除";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // tabPageAdvSet
            // 
            this.tabPageAdvSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageAdvSet.Controls.Add(this.groupBox9);
            this.tabPageAdvSet.Controls.Add(this.groupBox8);
            this.tabPageAdvSet.Controls.Add(this.groupBox7);
            this.tabPageAdvSet.Controls.Add(this.groupBox5);
            this.tabPageAdvSet.Controls.Add(this.groupBox1);
            this.tabPageAdvSet.Controls.Add(this.groupBox2);
            this.tabPageAdvSet.Location = new System.Drawing.Point(4, 49);
            this.tabPageAdvSet.Name = "tabPageAdvSet";
            this.tabPageAdvSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvSet.Size = new System.Drawing.Size(782, 344);
            this.tabPageAdvSet.TabIndex = 4;
            this.tabPageAdvSet.Text = "高级设置";
            this.tabPageAdvSet.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbY);
            this.groupBox9.Controls.Add(this.cbEnabled);
            this.groupBox9.Controls.Add(this.tbX);
            this.groupBox9.Controls.Add(this.buttonSet);
            this.groupBox9.Controls.Add(this.label50);
            this.groupBox9.Controls.Add(this.label56);
            this.groupBox9.Location = new System.Drawing.Point(536, 133);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(233, 100);
            this.groupBox9.TabIndex = 26;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "鼠标定位显示";
            // 
            // tbY
            // 
            this.tbY.BackColor = System.Drawing.Color.White;
            this.tbY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbY.Location = new System.Drawing.Point(110, 41);
            this.tbY.Name = "tbY";
            this.tbY.ReadOnly = true;
            this.tbY.Size = new System.Drawing.Size(41, 21);
            this.tbY.TabIndex = 80;
            this.tbY.Text = "0";
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(28, 20);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(48, 16);
            this.cbEnabled.TabIndex = 79;
            this.cbEnabled.Text = "启用";
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // tbX
            // 
            this.tbX.BackColor = System.Drawing.Color.White;
            this.tbX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbX.Location = new System.Drawing.Point(110, 14);
            this.tbX.Name = "tbX";
            this.tbX.ReadOnly = true;
            this.tbX.Size = new System.Drawing.Size(41, 21);
            this.tbX.TabIndex = 80;
            this.tbX.Text = "0";
            // 
            // buttonSet
            // 
            this.buttonSet.Enabled = false;
            this.buttonSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.buttonSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSet.Location = new System.Drawing.Point(86, 69);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(72, 25);
            this.buttonSet.TabIndex = 77;
            this.buttonSet.Text = "设置";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(82, 17);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(17, 12);
            this.label50.TabIndex = 75;
            this.label50.Text = "X:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(82, 44);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(17, 12);
            this.label56.TabIndex = 75;
            this.label56.Text = "Y:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBox2);
            this.groupBox8.Controls.Add(this.checkBox1);
            this.groupBox8.Controls.Add(this.checkBoxUseFakeWindow);
            this.groupBox8.Location = new System.Drawing.Point(11, 239);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(297, 100);
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "防商家设置";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "搜狗过代理";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "IE代理假窗口";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseFakeWindow
            // 
            this.checkBoxUseFakeWindow.AutoSize = true;
            this.checkBoxUseFakeWindow.Location = new System.Drawing.Point(6, 20);
            this.checkBoxUseFakeWindow.Name = "checkBoxUseFakeWindow";
            this.checkBoxUseFakeWindow.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseFakeWindow.TabIndex = 17;
            this.checkBoxUseFakeWindow.Text = "火狐代理假窗口";
            this.checkBoxUseFakeWindow.UseVisualStyleBackColor = true;
            this.checkBoxUseFakeWindow.CheckedChanged += new System.EventHandler(this.checkBoxUseFakeWindow_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonInstallSslCert);
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.buttonUninstallSslCert);
            this.groupBox7.Controls.Add(this.buttonExportSslCert);
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Location = new System.Drawing.Point(11, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(519, 100);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "证书安装";
            // 
            // buttonInstallSslCert
            // 
            this.buttonInstallSslCert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonInstallSslCert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonInstallSslCert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonInstallSslCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstallSslCert.Location = new System.Drawing.Point(283, 28);
            this.buttonInstallSslCert.Name = "buttonInstallSslCert";
            this.buttonInstallSslCert.Size = new System.Drawing.Size(80, 35);
            this.buttonInstallSslCert.TabIndex = 7;
            this.buttonInstallSslCert.Text = "安装证书";
            this.buttonInstallSslCert.UseVisualStyleBackColor = true;
            this.buttonInstallSslCert.Click += new System.EventHandler(this.ButtonHandler);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(16, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 35);
            this.button4.TabIndex = 6;
            this.button4.Text = "清理所有证书";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // buttonUninstallSslCert
            // 
            this.buttonUninstallSslCert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonUninstallSslCert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonUninstallSslCert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonUninstallSslCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUninstallSslCert.Location = new System.Drawing.Point(201, 28);
            this.buttonUninstallSslCert.Name = "buttonUninstallSslCert";
            this.buttonUninstallSslCert.Size = new System.Drawing.Size(76, 35);
            this.buttonUninstallSslCert.TabIndex = 4;
            this.buttonUninstallSslCert.Text = "清理证书";
            this.buttonUninstallSslCert.UseVisualStyleBackColor = true;
            this.buttonUninstallSslCert.Click += new System.EventHandler(this.ButtonHandler);
            // 
            // buttonExportSslCert
            // 
            this.buttonExportSslCert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonExportSslCert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonExportSslCert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonExportSslCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportSslCert.Location = new System.Drawing.Point(369, 28);
            this.buttonExportSslCert.Name = "buttonExportSslCert";
            this.buttonExportSslCert.Size = new System.Drawing.Size(83, 35);
            this.buttonExportSslCert.TabIndex = 8;
            this.buttonExportSslCert.Text = "导出证书";
            this.buttonExportSslCert.UseVisualStyleBackColor = true;
            this.buttonExportSslCert.Click += new System.EventHandler(this.buttonExportSslCert_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(117, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "清理其它";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxClearAlipayRecyled);
            this.groupBox5.Controls.Add(this.checkBoxAlipayRecalculate);
            this.groupBox5.Location = new System.Drawing.Point(314, 133);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 100);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "支付宝功能";
            // 
            // checkBoxClearAlipayRecyled
            // 
            this.checkBoxClearAlipayRecyled.AutoSize = true;
            this.checkBoxClearAlipayRecyled.Location = new System.Drawing.Point(6, 20);
            this.checkBoxClearAlipayRecyled.Name = "checkBoxClearAlipayRecyled";
            this.checkBoxClearAlipayRecyled.Size = new System.Drawing.Size(120, 16);
            this.checkBoxClearAlipayRecyled.TabIndex = 3;
            this.checkBoxClearAlipayRecyled.Text = "清空支付宝回收站";
            this.checkBoxClearAlipayRecyled.UseVisualStyleBackColor = true;
            this.checkBoxClearAlipayRecyled.CheckedChanged += new System.EventHandler(this.checkBoxClearListRecyledItems_CheckedChanged);
            // 
            // checkBoxAlipayRecalculate
            // 
            this.checkBoxAlipayRecalculate.AutoSize = true;
            this.checkBoxAlipayRecalculate.Location = new System.Drawing.Point(6, 42);
            this.checkBoxAlipayRecalculate.Name = "checkBoxAlipayRecalculate";
            this.checkBoxAlipayRecalculate.Size = new System.Drawing.Size(120, 16);
            this.checkBoxAlipayRecalculate.TabIndex = 5;
            this.checkBoxAlipayRecalculate.Text = "计算收支明细金额";
            this.checkBoxAlipayRecalculate.UseVisualStyleBackColor = true;
            this.checkBoxAlipayRecalculate.CheckedChanged += new System.EventHandler(this.checkBoxAlipayRecalculate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBoxClearListRecyledItems);
            this.groupBox1.Controls.Add(this.checkBoxRemovePlaint);
            this.groupBox1.Controls.Add(this.checkBoxHideGrowth);
            this.groupBox1.Controls.Add(this.checkBoxClearLogistics);
            this.groupBox1.Controls.Add(this.checkBoxClearNotice);
            this.groupBox1.Location = new System.Drawing.Point(11, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 100);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "淘宝功能";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(157, 63);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(84, 16);
            this.checkBox4.TabIndex = 22;
            this.checkBox4.Text = "半实名付款";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBoxClearListRecyledItems
            // 
            this.checkBoxClearListRecyledItems.AutoSize = true;
            this.checkBoxClearListRecyledItems.Location = new System.Drawing.Point(6, 20);
            this.checkBoxClearListRecyledItems.Name = "checkBoxClearListRecyledItems";
            this.checkBoxClearListRecyledItems.Size = new System.Drawing.Size(108, 16);
            this.checkBoxClearListRecyledItems.TabIndex = 21;
            this.checkBoxClearListRecyledItems.Text = "清空淘宝回收站";
            this.checkBoxClearListRecyledItems.UseVisualStyleBackColor = true;
            this.checkBoxClearListRecyledItems.CheckedChanged += new System.EventHandler(this.checkBoxClearListRecyledItems_CheckedChanged_1);
            // 
            // checkBoxHideGrowth
            // 
            this.checkBoxHideGrowth.AutoSize = true;
            this.checkBoxHideGrowth.Location = new System.Drawing.Point(6, 63);
            this.checkBoxHideGrowth.Name = "checkBoxHideGrowth";
            this.checkBoxHideGrowth.Size = new System.Drawing.Size(120, 16);
            this.checkBoxHideGrowth.TabIndex = 20;
            this.checkBoxHideGrowth.Text = "屏蔽我的成长记录";
            this.checkBoxHideGrowth.UseVisualStyleBackColor = true;
            this.checkBoxHideGrowth.CheckedChanged += new System.EventHandler(this.checkBoxHideGrowth_CheckedChanged);
            // 
            // checkBoxClearLogistics
            // 
            this.checkBoxClearLogistics.AutoSize = true;
            this.checkBoxClearLogistics.Location = new System.Drawing.Point(157, 19);
            this.checkBoxClearLogistics.Name = "checkBoxClearLogistics";
            this.checkBoxClearLogistics.Size = new System.Drawing.Size(96, 16);
            this.checkBoxClearLogistics.TabIndex = 2;
            this.checkBoxClearLogistics.Text = "屏蔽我的物流";
            this.checkBoxClearLogistics.UseVisualStyleBackColor = true;
            this.checkBoxClearLogistics.CheckedChanged += new System.EventHandler(this.checkBoxClearLogistics_CheckedChanged);
            // 
            // checkBoxClearNotice
            // 
            this.checkBoxClearNotice.AutoSize = true;
            this.checkBoxClearNotice.Location = new System.Drawing.Point(157, 40);
            this.checkBoxClearNotice.Name = "checkBoxClearNotice";
            this.checkBoxClearNotice.Size = new System.Drawing.Size(132, 16);
            this.checkBoxClearNotice.TabIndex = 4;
            this.checkBoxClearNotice.Text = "去卖家中心违规信息";
            this.checkBoxClearNotice.UseVisualStyleBackColor = true;
            this.checkBoxClearNotice.CheckedChanged += new System.EventHandler(this.checkBoxClearNotice_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label51);
            this.groupBox2.Controls.Add(this.buttonSaveProxyPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxProxyPort);
            this.groupBox2.Location = new System.Drawing.Point(536, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "代理端口";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ForeColor = System.Drawing.Color.Red;
            this.label51.Location = new System.Drawing.Point(46, 51);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(137, 12);
            this.label51.TabIndex = 6;
            this.label51.Text = "保存设置后重启软件生效";
            // 
            // buttonSaveProxyPort
            // 
            this.buttonSaveProxyPort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSaveProxyPort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.buttonSaveProxyPort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonSaveProxyPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveProxyPort.Location = new System.Drawing.Point(73, 69);
            this.buttonSaveProxyPort.Name = "buttonSaveProxyPort";
            this.buttonSaveProxyPort.Size = new System.Drawing.Size(85, 25);
            this.buttonSaveProxyPort.TabIndex = 5;
            this.buttonSaveProxyPort.Text = "保存";
            this.buttonSaveProxyPort.UseVisualStyleBackColor = true;
            this.buttonSaveProxyPort.Click += new System.EventHandler(this.ButtonHandler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前端口：";
            // 
            // textBoxProxyPort
            // 
            this.textBoxProxyPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProxyPort.Location = new System.Drawing.Point(97, 20);
            this.textBoxProxyPort.Name = "textBoxProxyPort";
            this.textBoxProxyPort.Size = new System.Drawing.Size(95, 21);
            this.textBoxProxyPort.TabIndex = 0;
            this.textBoxProxyPort.Text = "8877";
            // 
            // tabPageIPEm
            // 
            this.tabPageIPEm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageIPEm.Controls.Add(this.checkBox3);
            this.tabPageIPEm.Controls.Add(this.textBox12);
            this.tabPageIPEm.Controls.Add(this.textBox11);
            this.tabPageIPEm.Controls.Add(this.textBox10);
            this.tabPageIPEm.Controls.Add(this.label48);
            this.tabPageIPEm.Location = new System.Drawing.Point(4, 49);
            this.tabPageIPEm.Name = "tabPageIPEm";
            this.tabPageIPEm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIPEm.Size = new System.Drawing.Size(782, 344);
            this.tabPageIPEm.TabIndex = 6;
            this.tabPageIPEm.Text = "IP模拟";
            this.tabPageIPEm.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(106, 38);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(108, 16);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "开启百度伪造ip";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox12
            // 
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox12.Location = new System.Drawing.Point(106, 140);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(168, 21);
            this.textBox12.TabIndex = 3;
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox11.Location = new System.Drawing.Point(106, 104);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(168, 21);
            this.textBox11.TabIndex = 2;
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox10.Location = new System.Drawing.Point(106, 70);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(168, 21);
            this.textBox10.TabIndex = 1;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(64, 75);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(29, 84);
            this.label48.TabIndex = 0;
            this.label48.Text = "ip\r\n\r\n\r\n地区\r\n\r\n\r\n网络";
            // 
            // tabPageMobile
            // 
            this.tabPageMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMobile.Controls.Add(this.groupBox13);
            this.tabPageMobile.Controls.Add(this.pictureBox1);
            this.tabPageMobile.Location = new System.Drawing.Point(4, 49);
            this.tabPageMobile.Name = "tabPageMobile";
            this.tabPageMobile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMobile.Size = new System.Drawing.Size(782, 344);
            this.tabPageMobile.TabIndex = 9;
            this.tabPageMobile.Text = "手机淘宝P图";
            this.tabPageMobile.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.textBox4);
            this.groupBox13.Controls.Add(this.textBox3);
            this.groupBox13.Controls.Add(this.textBox2);
            this.groupBox13.Controls.Add(this.textBox1);
            this.groupBox13.Controls.Add(this.textBox6);
            this.groupBox13.Controls.Add(this.label1);
            this.groupBox13.Controls.Add(this.button9);
            this.groupBox13.Controls.Add(this.label21);
            this.groupBox13.Controls.Add(this.label30);
            this.groupBox13.Controls.Add(this.textBox5);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.label29);
            this.groupBox13.Controls.Add(this.label24);
            this.groupBox13.Location = new System.Drawing.Point(429, 8);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(256, 330);
            this.groupBox13.TabIndex = 25;
            this.groupBox13.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(84, 147);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(114, 21);
            this.textBox4.TabIndex = 18;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(84, 119);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 21);
            this.textBox3.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(84, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 21);
            this.textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(84, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 21);
            this.textBox1.TabIndex = 12;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Location = new System.Drawing.Point(84, 203);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(114, 21);
            this.textBox6.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "账号名：";
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(84, 241);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(98, 55);
            this.button9.TabIndex = 23;
            this.button9.Text = "一键制图";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(45, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 13;
            this.label21.Text = "待付：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(39, 208);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 12);
            this.label30.TabIndex = 21;
            this.label30.Text = "V等级：";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Location = new System.Drawing.Point(84, 175);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(114, 21);
            this.textBox5.TabIndex = 20;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(45, 124);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 15;
            this.label22.Text = "待发：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(45, 180);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 12);
            this.label29.TabIndex = 19;
            this.label29.Text = "待评：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(45, 152);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 17;
            this.label24.Text = "待收：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(62, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 330);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 344);
            this.tabPage1.TabIndex = 8;
            this.tabPage1.Text = "隐藏控件";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.textBoxRateAllForSales);
            this.groupBox4.Controls.Add(this.textBoxHalfYearForSales);
            this.groupBox4.Controls.Add(this.textBoxRateMonthForSales);
            this.groupBox4.Controls.Add(this.textBoxRateWeekForSales);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(174, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(429, 50);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "卖家";
            this.groupBox4.UseWaitCursor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(270, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 23;
            this.label32.Text = "半年之前";
            this.label32.UseWaitCursor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(175, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 22;
            this.label33.Text = "半年";
            this.label33.UseWaitCursor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(97, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(17, 12);
            this.label34.TabIndex = 21;
            this.label34.Text = "月";
            this.label34.UseWaitCursor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(15, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(17, 12);
            this.label35.TabIndex = 20;
            this.label35.Text = "周";
            this.label35.UseWaitCursor = true;
            // 
            // textBoxRateAllForSales
            // 
            this.textBoxRateAllForSales.Location = new System.Drawing.Point(327, 19);
            this.textBoxRateAllForSales.Name = "textBoxRateAllForSales";
            this.textBoxRateAllForSales.Size = new System.Drawing.Size(42, 21);
            this.textBoxRateAllForSales.TabIndex = 19;
            this.textBoxRateAllForSales.UseWaitCursor = true;
            // 
            // textBoxHalfYearForSales
            // 
            this.textBoxHalfYearForSales.Location = new System.Drawing.Point(208, 19);
            this.textBoxHalfYearForSales.Name = "textBoxHalfYearForSales";
            this.textBoxHalfYearForSales.Size = new System.Drawing.Size(42, 21);
            this.textBoxHalfYearForSales.TabIndex = 18;
            this.textBoxHalfYearForSales.UseWaitCursor = true;
            // 
            // textBoxRateMonthForSales
            // 
            this.textBoxRateMonthForSales.Location = new System.Drawing.Point(119, 19);
            this.textBoxRateMonthForSales.Name = "textBoxRateMonthForSales";
            this.textBoxRateMonthForSales.Size = new System.Drawing.Size(42, 21);
            this.textBoxRateMonthForSales.TabIndex = 17;
            this.textBoxRateMonthForSales.UseWaitCursor = true;
            // 
            // textBoxRateWeekForSales
            // 
            this.textBoxRateWeekForSales.Location = new System.Drawing.Point(37, 19);
            this.textBoxRateWeekForSales.Name = "textBoxRateWeekForSales";
            this.textBoxRateWeekForSales.Size = new System.Drawing.Size(42, 21);
            this.textBoxRateWeekForSales.TabIndex = 16;
            this.textBoxRateWeekForSales.UseWaitCursor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label53);
            this.groupBox10.Controls.Add(this.checkBoxDefiningStop);
            this.groupBox10.Controls.Add(this.labelAlipayOrderRowId);
            this.groupBox10.Controls.Add(this.comboBoxAlphaHotKeyHttps);
            this.groupBox10.Controls.Add(this.comboBoxCtrlHotKeyHttp);
            this.groupBox10.Controls.Add(this.buttonResetOrderInfo);
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.labelHttpMode);
            this.groupBox10.Controls.Add(this.comboBoxCtrlHotKeyHide);
            this.groupBox10.Controls.Add(this.comboBoxShiftHotKeyHttps);
            this.groupBox10.Controls.Add(this.comboBoxAltHotKeyHide);
            this.groupBox10.Controls.Add(this.comboBoxAlphaHotKeyHttp);
            this.groupBox10.Controls.Add(this.buttonOnekeyReset);
            this.groupBox10.Controls.Add(this.comboBoxShiftHotKeyHide);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.buttonOnekeyWaitRate);
            this.groupBox10.Controls.Add(this.comboBoxAltHotKeyHttps);
            this.groupBox10.Controls.Add(this.buttonOnekeyWaitSend);
            this.groupBox10.Controls.Add(this.buttonOnekeyWaitConfirm);
            this.groupBox10.Controls.Add(this.buttonOnekeyHide);
            this.groupBox10.Controls.Add(this.buttonOneKeyWaitPay);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.comboBoxShiftHotKeyStop);
            this.groupBox10.Controls.Add(this.comboBoxCtrlHotKeyHttps);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Controls.Add(this.comboBoxShiftHotKeyHttp);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.comboBoxAltHotKeyHttp);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.comboBoxAltHotKeyStop);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.comboBoxCtrlHotKeyStop);
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.comboBoxCtrlHotKeyStart);
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Controls.Add(this.comboBoxAltHotKeyStart);
            this.groupBox10.Controls.Add(this.comboBoxShiftHotKeyStart);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Location = new System.Drawing.Point(72, 24);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(577, 283);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "隐藏部分";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(172, 34);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(203, 12);
            this.label53.TabIndex = 82;
            this.label53.Text = "Ctrl          Alt           Shift";
            // 
            // checkBoxDefiningStop
            // 
            this.checkBoxDefiningStop.AutoSize = true;
            this.checkBoxDefiningStop.Location = new System.Drawing.Point(487, 239);
            this.checkBoxDefiningStop.Name = "checkBoxDefiningStop";
            this.checkBoxDefiningStop.Size = new System.Drawing.Size(84, 16);
            this.checkBoxDefiningStop.TabIndex = 19;
            this.checkBoxDefiningStop.Text = "限定性停止";
            this.checkBoxDefiningStop.UseVisualStyleBackColor = true;
            this.checkBoxDefiningStop.CheckedChanged += new System.EventHandler(this.checkBoxDefiningStop_CheckedChanged);
            // 
            // labelAlipayOrderRowId
            // 
            this.labelAlipayOrderRowId.AutoSize = true;
            this.labelAlipayOrderRowId.Location = new System.Drawing.Point(500, 268);
            this.labelAlipayOrderRowId.Name = "labelAlipayOrderRowId";
            this.labelAlipayOrderRowId.Size = new System.Drawing.Size(71, 12);
            this.labelAlipayOrderRowId.TabIndex = 24;
            this.labelAlipayOrderRowId.Text = "交易流水号:";
            // 
            // comboBoxAlphaHotKeyHttps
            // 
            this.comboBoxAlphaHotKeyHttps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlphaHotKeyHttps.FormattingEnabled = true;
            this.comboBoxAlphaHotKeyHttps.Location = new System.Drawing.Point(406, 161);
            this.comboBoxAlphaHotKeyHttps.Name = "comboBoxAlphaHotKeyHttps";
            this.comboBoxAlphaHotKeyHttps.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAlphaHotKeyHttps.TabIndex = 81;
            // 
            // comboBoxCtrlHotKeyHttp
            // 
            this.comboBoxCtrlHotKeyHttp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCtrlHotKeyHttp.FormattingEnabled = true;
            this.comboBoxCtrlHotKeyHttp.Location = new System.Drawing.Point(174, 133);
            this.comboBoxCtrlHotKeyHttp.Name = "comboBoxCtrlHotKeyHttp";
            this.comboBoxCtrlHotKeyHttp.Size = new System.Drawing.Size(57, 20);
            this.comboBoxCtrlHotKeyHttp.TabIndex = 74;
            // 
            // buttonResetOrderInfo
            // 
            this.buttonResetOrderInfo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonResetOrderInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonResetOrderInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonResetOrderInfo.Location = new System.Drawing.Point(102, 208);
            this.buttonResetOrderInfo.Name = "buttonResetOrderInfo";
            this.buttonResetOrderInfo.Size = new System.Drawing.Size(80, 25);
            this.buttonResetOrderInfo.TabIndex = 1;
            this.buttonResetOrderInfo.Text = "取消修改";
            this.buttonResetOrderInfo.UseVisualStyleBackColor = true;
            this.buttonResetOrderInfo.Click += new System.EventHandler(this.buttonResetOrderInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "显示/隐藏：";
            // 
            // labelHttpMode
            // 
            this.labelHttpMode.AutoSize = true;
            this.labelHttpMode.Location = new System.Drawing.Point(465, 268);
            this.labelHttpMode.Name = "labelHttpMode";
            this.labelHttpMode.Size = new System.Drawing.Size(29, 12);
            this.labelHttpMode.TabIndex = 4;
            this.labelHttpMode.Text = "http";
            // 
            // comboBoxCtrlHotKeyHide
            // 
            this.comboBoxCtrlHotKeyHide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCtrlHotKeyHide.FormattingEnabled = true;
            this.comboBoxCtrlHotKeyHide.Location = new System.Drawing.Point(174, 51);
            this.comboBoxCtrlHotKeyHide.Name = "comboBoxCtrlHotKeyHide";
            this.comboBoxCtrlHotKeyHide.Size = new System.Drawing.Size(57, 20);
            this.comboBoxCtrlHotKeyHide.TabIndex = 31;
            // 
            // comboBoxShiftHotKeyHttps
            // 
            this.comboBoxShiftHotKeyHttps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftHotKeyHttps.FormattingEnabled = true;
            this.comboBoxShiftHotKeyHttps.Location = new System.Drawing.Point(326, 161);
            this.comboBoxShiftHotKeyHttps.Name = "comboBoxShiftHotKeyHttps";
            this.comboBoxShiftHotKeyHttps.Size = new System.Drawing.Size(57, 20);
            this.comboBoxShiftHotKeyHttps.TabIndex = 80;
            // 
            // comboBoxAltHotKeyHide
            // 
            this.comboBoxAltHotKeyHide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAltHotKeyHide.FormattingEnabled = true;
            this.comboBoxAltHotKeyHide.Location = new System.Drawing.Point(249, 51);
            this.comboBoxAltHotKeyHide.Name = "comboBoxAltHotKeyHide";
            this.comboBoxAltHotKeyHide.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAltHotKeyHide.TabIndex = 32;
            // 
            // comboBoxAlphaHotKeyHttp
            // 
            this.comboBoxAlphaHotKeyHttp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlphaHotKeyHttp.FormattingEnabled = true;
            this.comboBoxAlphaHotKeyHttp.Location = new System.Drawing.Point(406, 133);
            this.comboBoxAlphaHotKeyHttp.Name = "comboBoxAlphaHotKeyHttp";
            this.comboBoxAlphaHotKeyHttp.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAlphaHotKeyHttp.TabIndex = 77;
            // 
            // buttonOnekeyReset
            // 
            this.buttonOnekeyReset.Location = new System.Drawing.Point(16, 239);
            this.buttonOnekeyReset.Name = "buttonOnekeyReset";
            this.buttonOnekeyReset.Size = new System.Drawing.Size(80, 25);
            this.buttonOnekeyReset.TabIndex = 7;
            this.buttonOnekeyReset.Text = "一键还原";
            this.buttonOnekeyReset.UseVisualStyleBackColor = true;
            this.buttonOnekeyReset.Click += new System.EventHandler(this.buttonOnekeyReset_Click);
            // 
            // comboBoxShiftHotKeyHide
            // 
            this.comboBoxShiftHotKeyHide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftHotKeyHide.FormattingEnabled = true;
            this.comboBoxShiftHotKeyHide.Location = new System.Drawing.Point(326, 51);
            this.comboBoxShiftHotKeyHide.Name = "comboBoxShiftHotKeyHide";
            this.comboBoxShiftHotKeyHide.Size = new System.Drawing.Size(57, 20);
            this.comboBoxShiftHotKeyHide.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(312, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 42;
            this.label12.Text = "+";
            // 
            // buttonOnekeyWaitRate
            // 
            this.buttonOnekeyWaitRate.Location = new System.Drawing.Point(185, 208);
            this.buttonOnekeyWaitRate.Name = "buttonOnekeyWaitRate";
            this.buttonOnekeyWaitRate.Size = new System.Drawing.Size(80, 25);
            this.buttonOnekeyWaitRate.TabIndex = 5;
            this.buttonOnekeyWaitRate.Text = "一键待评价";
            this.buttonOnekeyWaitRate.UseVisualStyleBackColor = true;
            this.buttonOnekeyWaitRate.Click += new System.EventHandler(this.buttonOnekeyWaitRate_Click);
            // 
            // comboBoxAltHotKeyHttps
            // 
            this.comboBoxAltHotKeyHttps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAltHotKeyHttps.FormattingEnabled = true;
            this.comboBoxAltHotKeyHttps.Location = new System.Drawing.Point(249, 161);
            this.comboBoxAltHotKeyHttps.Name = "comboBoxAltHotKeyHttps";
            this.comboBoxAltHotKeyHttps.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAltHotKeyHttps.TabIndex = 79;
            // 
            // buttonOnekeyWaitSend
            // 
            this.buttonOnekeyWaitSend.Location = new System.Drawing.Point(271, 208);
            this.buttonOnekeyWaitSend.Name = "buttonOnekeyWaitSend";
            this.buttonOnekeyWaitSend.Size = new System.Drawing.Size(80, 25);
            this.buttonOnekeyWaitSend.TabIndex = 4;
            this.buttonOnekeyWaitSend.Text = "一键待发货";
            this.buttonOnekeyWaitSend.UseVisualStyleBackColor = true;
            this.buttonOnekeyWaitSend.Click += new System.EventHandler(this.buttonOnekeyWaitSend_Click);
            // 
            // buttonOnekeyWaitConfirm
            // 
            this.buttonOnekeyWaitConfirm.Location = new System.Drawing.Point(443, 208);
            this.buttonOnekeyWaitConfirm.Name = "buttonOnekeyWaitConfirm";
            this.buttonOnekeyWaitConfirm.Size = new System.Drawing.Size(80, 25);
            this.buttonOnekeyWaitConfirm.TabIndex = 3;
            this.buttonOnekeyWaitConfirm.Text = "一键待收货";
            this.buttonOnekeyWaitConfirm.UseVisualStyleBackColor = true;
            this.buttonOnekeyWaitConfirm.Click += new System.EventHandler(this.buttonOnekeyWaitConfirm_Click);
            // 
            // buttonOnekeyHide
            // 
            this.buttonOnekeyHide.Location = new System.Drawing.Point(16, 208);
            this.buttonOnekeyHide.Name = "buttonOnekeyHide";
            this.buttonOnekeyHide.Size = new System.Drawing.Size(80, 25);
            this.buttonOnekeyHide.TabIndex = 6;
            this.buttonOnekeyHide.Text = "一键隐藏";
            this.buttonOnekeyHide.UseVisualStyleBackColor = true;
            this.buttonOnekeyHide.Click += new System.EventHandler(this.buttonOnekeyHide_Click);
            // 
            // buttonOneKeyWaitPay
            // 
            this.buttonOneKeyWaitPay.Location = new System.Drawing.Point(357, 208);
            this.buttonOneKeyWaitPay.Name = "buttonOneKeyWaitPay";
            this.buttonOneKeyWaitPay.Size = new System.Drawing.Size(80, 25);
            this.buttonOneKeyWaitPay.TabIndex = 2;
            this.buttonOneKeyWaitPay.Text = "一键待付款";
            this.buttonOneKeyWaitPay.UseVisualStyleBackColor = true;
            this.buttonOneKeyWaitPay.Click += new System.EventHandler(this.buttonOneKeyWaitPay_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(389, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 44;
            this.label10.Text = "+";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(236, 82);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(11, 12);
            this.label36.TabIndex = 41;
            this.label36.Text = "+";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(236, 109);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(11, 12);
            this.label39.TabIndex = 48;
            this.label39.Text = "+";
            // 
            // comboBoxShiftHotKeyStop
            // 
            this.comboBoxShiftHotKeyStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftHotKeyStop.FormattingEnabled = true;
            this.comboBoxShiftHotKeyStop.Location = new System.Drawing.Point(326, 105);
            this.comboBoxShiftHotKeyStop.Name = "comboBoxShiftHotKeyStop";
            this.comboBoxShiftHotKeyStop.Size = new System.Drawing.Size(57, 20);
            this.comboBoxShiftHotKeyStop.TabIndex = 72;
            // 
            // comboBoxCtrlHotKeyHttps
            // 
            this.comboBoxCtrlHotKeyHttps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCtrlHotKeyHttps.FormattingEnabled = true;
            this.comboBoxCtrlHotKeyHttps.Location = new System.Drawing.Point(174, 161);
            this.comboBoxCtrlHotKeyHttps.Name = "comboBoxCtrlHotKeyHttps";
            this.comboBoxCtrlHotKeyHttps.Size = new System.Drawing.Size(57, 20);
            this.comboBoxCtrlHotKeyHttps.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "+";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(312, 109);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(11, 12);
            this.label38.TabIndex = 49;
            this.label38.Text = "+";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(389, 109);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(11, 12);
            this.label37.TabIndex = 51;
            this.label37.Text = "+";
            // 
            // comboBoxShiftHotKeyHttp
            // 
            this.comboBoxShiftHotKeyHttp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftHotKeyHttp.FormattingEnabled = true;
            this.comboBoxShiftHotKeyHttp.Location = new System.Drawing.Point(326, 133);
            this.comboBoxShiftHotKeyHttp.Name = "comboBoxShiftHotKeyHttp";
            this.comboBoxShiftHotKeyHttp.Size = new System.Drawing.Size(57, 20);
            this.comboBoxShiftHotKeyHttp.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "+";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(236, 137);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(11, 12);
            this.label42.TabIndex = 55;
            this.label42.Text = "+";
            // 
            // comboBoxAltHotKeyHttp
            // 
            this.comboBoxAltHotKeyHttp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAltHotKeyHttp.FormattingEnabled = true;
            this.comboBoxAltHotKeyHttp.Location = new System.Drawing.Point(249, 133);
            this.comboBoxAltHotKeyHttp.Name = "comboBoxAltHotKeyHttp";
            this.comboBoxAltHotKeyHttp.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAltHotKeyHttp.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "+";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(312, 137);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(11, 12);
            this.label41.TabIndex = 56;
            this.label41.Text = "+";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(389, 137);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(11, 12);
            this.label40.TabIndex = 58;
            this.label40.Text = "+";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(236, 165);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(11, 12);
            this.label45.TabIndex = 62;
            this.label45.Text = "+";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(312, 165);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(11, 12);
            this.label44.TabIndex = 63;
            this.label44.Text = "+";
            // 
            // comboBoxAltHotKeyStop
            // 
            this.comboBoxAltHotKeyStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAltHotKeyStop.FormattingEnabled = true;
            this.comboBoxAltHotKeyStop.Location = new System.Drawing.Point(249, 105);
            this.comboBoxAltHotKeyStop.Name = "comboBoxAltHotKeyStop";
            this.comboBoxAltHotKeyStop.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAltHotKeyStop.TabIndex = 71;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "切换到Https：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(389, 165);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(11, 12);
            this.label43.TabIndex = 65;
            this.label43.Text = "+";
            // 
            // comboBoxCtrlHotKeyStop
            // 
            this.comboBoxCtrlHotKeyStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCtrlHotKeyStop.FormattingEnabled = true;
            this.comboBoxCtrlHotKeyStop.Location = new System.Drawing.Point(174, 105);
            this.comboBoxCtrlHotKeyStop.Name = "comboBoxCtrlHotKeyStop";
            this.comboBoxCtrlHotKeyStop.Size = new System.Drawing.Size(57, 20);
            this.comboBoxCtrlHotKeyStop.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "切换到Http：";
            // 
            // comboBoxCtrlHotKeyStart
            // 
            this.comboBoxCtrlHotKeyStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCtrlHotKeyStart.FormattingEnabled = true;
            this.comboBoxCtrlHotKeyStart.Location = new System.Drawing.Point(174, 77);
            this.comboBoxCtrlHotKeyStart.Name = "comboBoxCtrlHotKeyStart";
            this.comboBoxCtrlHotKeyStart.Size = new System.Drawing.Size(57, 20);
            this.comboBoxCtrlHotKeyStart.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "停止：";
            // 
            // comboBoxAltHotKeyStart
            // 
            this.comboBoxAltHotKeyStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAltHotKeyStart.FormattingEnabled = true;
            this.comboBoxAltHotKeyStart.Location = new System.Drawing.Point(249, 77);
            this.comboBoxAltHotKeyStart.Name = "comboBoxAltHotKeyStart";
            this.comboBoxAltHotKeyStart.Size = new System.Drawing.Size(57, 20);
            this.comboBoxAltHotKeyStart.TabIndex = 67;
            // 
            // comboBoxShiftHotKeyStart
            // 
            this.comboBoxShiftHotKeyStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftHotKeyStart.FormattingEnabled = true;
            this.comboBoxShiftHotKeyStart.Location = new System.Drawing.Point(326, 77);
            this.comboBoxShiftHotKeyStart.Name = "comboBoxShiftHotKeyStart";
            this.comboBoxShiftHotKeyStart.Size = new System.Drawing.Size(57, 20);
            this.comboBoxShiftHotKeyStart.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "启动：";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(3, 3);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(776, 365);
            this.LogTextBox.TabIndex = 4;
            // 
            // comboBoxAlphaHotKeyStop
            // 
            this.comboBoxAlphaHotKeyStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxAlphaHotKeyStop.FormattingEnabled = true;
            this.comboBoxAlphaHotKeyStop.Location = new System.Drawing.Point(150, 68);
            this.comboBoxAlphaHotKeyStop.Name = "comboBoxAlphaHotKeyStop";
            this.comboBoxAlphaHotKeyStop.Size = new System.Drawing.Size(48, 20);
            this.comboBoxAlphaHotKeyStop.TabIndex = 73;
            // 
            // comboBoxAlphaHotKeyStart
            // 
            this.comboBoxAlphaHotKeyStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxAlphaHotKeyStart.FormattingEnabled = true;
            this.comboBoxAlphaHotKeyStart.Location = new System.Drawing.Point(150, 40);
            this.comboBoxAlphaHotKeyStart.Name = "comboBoxAlphaHotKeyStart";
            this.comboBoxAlphaHotKeyStart.Size = new System.Drawing.Size(48, 20);
            this.comboBoxAlphaHotKeyStart.TabIndex = 69;
            // 
            // comboBoxAlphaHotKeyHide
            // 
            this.comboBoxAlphaHotKeyHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxAlphaHotKeyHide.FormattingEnabled = true;
            this.comboBoxAlphaHotKeyHide.Location = new System.Drawing.Point(150, 14);
            this.comboBoxAlphaHotKeyHide.Name = "comboBoxAlphaHotKeyHide";
            this.comboBoxAlphaHotKeyHide.Size = new System.Drawing.Size(48, 20);
            this.comboBoxAlphaHotKeyHide.TabIndex = 36;
            // 
            // contextMenuStripOrderList
            // 
            this.contextMenuStripOrderList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTradOk,
            this.toolStripMenuItemOrderHide,
            this.批量隐藏订单ToolStripMenuItem,
            this.一键收货ToolStripMenuItem,
            this.一键评价ToolStripMenuItem,
            this.撤销修改ToolStripMenuItem});
            this.contextMenuStripOrderList.Name = "contextMenuStripOrderList";
            this.contextMenuStripOrderList.Size = new System.Drawing.Size(161, 136);
            this.contextMenuStripOrderList.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOrderList_Opening);
            // 
            // toolStripMenuItemTradOk
            // 
            this.toolStripMenuItemTradOk.Name = "toolStripMenuItemTradOk";
            this.toolStripMenuItemTradOk.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemTradOk.Text = "设置为交易成功";
            this.toolStripMenuItemTradOk.Click += new System.EventHandler(this.toolStripMenuItemTradOk_Click);
            // 
            // toolStripMenuItemOrderHide
            // 
            this.toolStripMenuItemOrderHide.Name = "toolStripMenuItemOrderHide";
            this.toolStripMenuItemOrderHide.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemOrderHide.Text = "隐藏订单";
            this.toolStripMenuItemOrderHide.Click += new System.EventHandler(this.toolStripMenuItemOrderHide_Click);
            // 
            // 批量隐藏订单ToolStripMenuItem
            // 
            this.批量隐藏订单ToolStripMenuItem.Name = "批量隐藏订单ToolStripMenuItem";
            this.批量隐藏订单ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.批量隐藏订单ToolStripMenuItem.Text = "批量隐藏订单";
            this.批量隐藏订单ToolStripMenuItem.Click += new System.EventHandler(this.批量隐藏订单ToolStripMenuItem_Click);
            // 
            // 一键收货ToolStripMenuItem
            // 
            this.一键收货ToolStripMenuItem.Name = "一键收货ToolStripMenuItem";
            this.一键收货ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.一键收货ToolStripMenuItem.Text = "一键收货";
            this.一键收货ToolStripMenuItem.Click += new System.EventHandler(this.一键收货ToolStripMenuItem_Click);
            // 
            // 一键评价ToolStripMenuItem
            // 
            this.一键评价ToolStripMenuItem.Name = "一键评价ToolStripMenuItem";
            this.一键评价ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.一键评价ToolStripMenuItem.Text = "一键评价";
            this.一键评价ToolStripMenuItem.Click += new System.EventHandler(this.一键评价ToolStripMenuItem_Click);
            // 
            // 撤销修改ToolStripMenuItem
            // 
            this.撤销修改ToolStripMenuItem.Name = "撤销修改ToolStripMenuItem";
            this.撤销修改ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.撤销修改ToolStripMenuItem.Text = "一键还原";
            this.撤销修改ToolStripMenuItem.Click += new System.EventHandler(this.撤销修改ToolStripMenuItem_Click);
            // 
            // TrandNotifyIcon
            // 
            this.TrandNotifyIcon.Text = "TBHelper";
            this.TrandNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrandNotifyIcon_MouseDoubleClick);
            // 
            // buttonQuitApp
            // 
            this.buttonQuitApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonQuitApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.buttonQuitApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonQuitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuitApp.Location = new System.Drawing.Point(29, 58);
            this.buttonQuitApp.Name = "buttonQuitApp";
            this.buttonQuitApp.Size = new System.Drawing.Size(117, 30);
            this.buttonQuitApp.TabIndex = 3;
            this.buttonQuitApp.Text = "退出";
            this.buttonQuitApp.UseVisualStyleBackColor = true;
            this.buttonQuitApp.Click += new System.EventHandler(this.ButtonHandler);
            // 
            // buttonStop
            // 
            this.buttonStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.buttonStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(128, 17);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(77, 30);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonHandler);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.buttonStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Location = new System.Drawing.Point(29, 17);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(77, 30);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonHandler);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonStart);
            this.groupBox6.Controls.Add(this.buttonStop);
            this.groupBox6.Controls.Add(this.buttonQuitApp);
            this.groupBox6.Location = new System.Drawing.Point(4, -2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(246, 96);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.checkBox6);
            this.groupBox11.Controls.Add(this.checkBox7);
            this.groupBox11.Controls.Add(this.button1);
            this.groupBox11.Controls.Add(this.checkBox_shiming);
            this.groupBox11.Controls.Add(this.checkBox8);
            this.groupBox11.Controls.Add(this.label54);
            this.groupBox11.Controls.Add(this.comboBoxAlphaHotKeyHide);
            this.groupBox11.Controls.Add(this.comboBoxAlphaHotKeyStart);
            this.groupBox11.Controls.Add(this.comboBoxAlphaHotKeyStop);
            this.groupBox11.Location = new System.Drawing.Point(261, -2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(524, 95);
            this.groupBox11.TabIndex = 9;
            this.groupBox11.TabStop = false;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(375, 15);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(126, 16);
            this.checkBox6.TabIndex = 78;
            this.checkBox6.Text = "搜狗-[不使用代理]";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox7.Location = new System.Drawing.Point(232, 42);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(90, 16);
            this.checkBox7.TabIndex = 77;
            this.checkBox7.Text = "半实名付款";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(374, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 38);
            this.button1.TabIndex = 76;
            this.button1.Text = "搜狗-[不使用代理]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_shiming
            // 
            this.checkBox_shiming.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox_shiming.AutoSize = true;
            this.checkBox_shiming.Location = new System.Drawing.Point(232, 15);
            this.checkBox_shiming.Name = "checkBox_shiming";
            this.checkBox_shiming.Size = new System.Drawing.Size(72, 16);
            this.checkBox_shiming.TabIndex = 75;
            this.checkBox_shiming.Text = "使用实名";
            this.checkBox_shiming.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(232, 70);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(72, 16);
            this.checkBox8.TabIndex = 74;
            this.checkBox8.Text = "IE去代理";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(24, 20);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(113, 60);
            this.label54.TabIndex = 11;
            this.label54.Text = "显示/隐藏：Ctrl  +\r\n\r\n启动：      Alt  +\r\n\r\n停止：      Alt  +";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 499);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.MaintabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MaintabControl.ResumeLayout(false);
            this.OrderListTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainOrders)).EndInit();
            this.OrderListInfo.ResumeLayout(false);
            this.OrderListInfo.PerformLayout();
            this.RateListTabPage.ResumeLayout(false);
            this.RateListGroupBox.ResumeLayout(false);
            this.RateListGroupBox.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateList)).EndInit();
            this.RateListInfo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.AlipayOrderTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeRecords)).EndInit();
            this.AlipayOrderInfo.ResumeLayout(false);
            this.AlipayOrderInfo.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.AlipayTrashTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlipayTrashGridView)).EndInit();
            this.AlipayTrashInfo.ResumeLayout(false);
            this.AlipayTrashInfo.PerformLayout();
            this.tabPageAdvSet.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageIPEm.ResumeLayout(false);
            this.tabPageIPEm.PerformLayout();
            this.tabPageMobile.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.contextMenuStripOrderList.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        private delegate void updateDataTableDelegate(DataTable dt);

        private void labelCurrentPageIndex_Click(object sender, EventArgs e)
        {

        }

        private void 批量隐藏订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllHide(TBHelper.CurrentUserInfo.userid, ids));


        }

        private void 撤销修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllReset(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void 一键收货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllWaitConfirm(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void 一键评价ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = this.dgvMainOrders;
            if (dataGridView.RowCount == 0)
                return;
            IList<long> ids = (IList<long>)new List<long>();
            for (int index = 0; index < dataGridView.Rows.Count; ++index)
                ids.Add(Convert.ToInt64(dataGridView.Rows[index].Cells["id"].Value.ToString()));
            this._dtMainOrders.Merge(TBHelper.buyerTradeManage.OneKeyAllWaitRate(TBHelper.CurrentUserInfo.userid, ids));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (cbEnabled.Checked)
            {
                MessageBox.Show("把鼠标放到你想要的位置，按Ctrl +0 定位坐标");
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MousePosition.X.ToString() != tbX.Text)
                tbX.Text = MousePosition.X.ToString();
            if (MousePosition.Y.ToString() != tbY.Text)
                tbY.Text = MousePosition.Y.ToString();
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnabled.Checked)
            {
                buttonSet.Enabled = true;
            }
            else
            {
                buttonSet.Enabled = false;
                timer1.Enabled = false;
            }
        }

        #region devgis 新增
        private int intFlag = 0;
        private static int iSecureEndpointPort = 0x1e61;
        private string machineID;
        private static Proxy oSecureEndpoint;
        private static string sSecureEndpointHostname = "localhost";
        public bool isReged()
        {
            string str = "";
            try
            {
                if (File.Exists(Thread.GetDomain().BaseDirectory + "key.txt"))
                {
                    StreamReader reader = new StreamReader(Thread.GetDomain().BaseDirectory + "key.txt");
                    str = reader.ReadToEnd();
                    reader.Close();
                    return (str == this.makeKey());
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass class2 = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject obj2 = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            obj2.Get();
            return obj2.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        public static string getCpu()
        {
            string str = null;
            ManagementClass class2 = new ManagementClass("win32_Processor");
            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = class2.GetInstances().GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    ManagementObject current = (ManagementObject)enumerator.Current;
                    str = current.Properties["Processorid"].Value.ToString();
                }
            }
            return str;
        }
        public static string getMNum()
        {
            return (getCpu() + GetDiskVolumeSerialNumber()).Substring(0, 0x18);
        }
        public string makeKey()//制造 key
        {
            this.machineID = getMNum();
            string s = this.machineID + "heiniusoft";
            byte[] bytes = Encoding.Default.GetBytes(s);
            MD5 md = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md.ComputeHash(bytes)).Replace("-", "");
        }

        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        [DllImport("user32")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public static bool InstallCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    return false;

                if (!CertMaker.trustRootCert())
                    return false;

            }

            return true;
        }
        public static void DoQuit()
        {
            if (null != oSecureEndpoint)
            {
                oSecureEndpoint.Dispose();
            }

            FiddlerApplication.Shutdown();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            key.SetValue("ProxyEnable", 0);
            key.SetValue("ProxyServer", "");
            Thread.Sleep(500);
        }
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            DoQuit();
        }
        private void UseFiddler()
        {
            List<Session> oAllSessions = new List<Session>();
            FiddlerApplication.SetAppDisplayName("YoukuSpeed");
            FiddlerApplication.OnNotification += (sender, oNEA) => Console.WriteLine("** NotifyUser: " + oNEA.NotifyString);
            FiddlerApplication.Log.OnLogString += (sender, oLEA) => Console.WriteLine("** LogString: " + oLEA.LogString);
            InstallCertificate();

            FiddlerApplication.BeforeRequest += delegate (Session oS)
            {
                oS.bBufferResponse = true;
                Monitor.Enter(oAllSessions);
                oAllSessions.Add(oS);
                Monitor.Exit(oAllSessions);
                oS["X-AutoAuth"] = "(default)";
                if ((oS.oRequest.pipeClient.LocalPort == iSecureEndpointPort) && (oS.hostname == sSecureEndpointHostname))
                {
                    oS.utilCreateResponseAndBypassServer();
                    oS.oResponse.headers.SetStatus(200, "Ok");
                    oS.oResponse["Content-Type"] = "text/html; charset=UTF-8";
                    oS.oResponse["Cache-Control"] = "private, max-age=0";
                    oS.utilSetResponseBody("<html><body>Request for httpS://" + sSecureEndpointHostname + ":" + iSecureEndpointPort.ToString() + " received. Your request was:<br /><plaintext>" + oS.oRequest.headers.ToString());
                }
                //Console.WriteLine(">>" + oS.url);
                if (checkBox1.Checked && oS.uriContains("buyertrade.taobao.com/trade/pay.htm?") && oS.uriContains("bizOrderId="))
                {
                    oS.utilCreateResponseAndBypassServer();
                    oS.oResponse.headers.SetStatus(200, "Ok");
                    oS.oResponse["Content-Type"] = "text/html; charset=UTF-8";
                    oS.oResponse["Cache-Control"] = "private, max-age=0";
                    oS.utilSetResponseBody("<head><script>var url = location.href;var wz1 = url.indexOf(\"bizOrderId=\");var id = url.substr(wz1+11,16);location.href='http://trade.tmall.com/order/pay.htm?biz_order_id='+id;</script></head><body></body></html>");
                    return;
                }

            };
            FiddlerApplication.BeforeResponse += delegate (Session oS)
            {

                if (checkBox_shiming.Checked && oS.uriContains("https://rate.taobao.com/myrate.htm") || oS.uriContains("https://rate.taobao.com/user-myrate"))
                {
                    string text15 = oS.GetResponseBodyAsString();
                    text15 = shimingReplace(text15);
                    oS.utilSetResponseBody(text15);
                }
            };
            Console.CancelKeyPress += new ConsoleCancelEventHandler(MainForm.Console_CancelKeyPress);
            string str = "NoSAZ";
            Console.WriteLine(string.Format("Starting {0} ({1})...", FiddlerApplication.GetVersionString(), str));

            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            FiddlerCoreStartupFlags oFlags = FiddlerCoreStartupFlags.Default;
            //liyafei
            //int iListenPort = 8877;
            //FiddlerApplication.Startup(8877, oFlags);
            //FiddlerApplication.Log.LogFormat("Created endpoint listening on port {0}", new object[] { iListenPort });
            //FiddlerApplication.Log.LogFormat("Starting with settings: [{0}]", new object[] { oFlags });
            //FiddlerApplication.Log.LogFormat("Gateway: {0}", new object[] { CONFIG.UpstreamGateway.ToString() });
            oSecureEndpoint = FiddlerApplication.CreateProxyEndpoint(iSecureEndpointPort, true, sSecureEndpointHostname);
            if (null != oSecureEndpoint)
            {
                FiddlerApplication.Log.LogFormat("Created secure endpoint listening on port {0}, using a HTTPS certificate for '{1}'", new object[] { iSecureEndpointPort, sSecureEndpointHostname });
            }

        }
        public string shimingReplace(string txt)
        {
            Regex reg = new Regex(@"证信息：</dt>([\s\S]*?)</dd>");
            return reg.Replace(txt, "证信息：</dt><dd><a href='//cshall.alipay.com/hall/index.htm?sceneCode=PC_MY_ACCOUNT&problemId=77' target='_blank'><img alt='支付宝个人认证' border='0' align='absmiddle' src='//img.alicdn.com/zfb_person_small.gif' title='支付宝个人认证' /></a></dd>");

        }
        //protected override void WndProc(ref Message m)
        //{
        //    if ((m.Msg == 786) && m.LParam.ToInt32() > 102)
        //    {
        //        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
        //        switch (m.WParam.ToInt32())
        //        {
        //            case 103:
        //                FiddlerApplication.Startup(8877, FiddlerCoreStartupFlags.Default);

        //                break;
        //            case 104:
        //                FiddlerApplication.Shutdown();

        //                break;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}

        public static void WriteCommandResponse(string s)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ForegroundColor = foregroundColor;
        }

        private static string Ellipsize(string s, int iLen)
        {
            if (s.Length <= iLen)
            {
                return s;
            }
            return (s.Substring(0, iLen - 3) + "...");
        }

        private static void WriteSessionList(List<Session> oAllSessions)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Session list contains...");
            try
            {
                Monitor.Enter(oAllSessions);
                foreach (Session session in oAllSessions)
                {
                    Console.Write(string.Format("{0} {1} {2}\n{3} {4}\n\n", new object[] { session.id, session.oRequest.headers.HTTPMethod, Ellipsize(session.fullUrl, 60), session.responseCode, session.oResponse.MIMEType }));
                }
            }
            finally
            {
                Monitor.Exit(oAllSessions);
            }
            Console.WriteLine();
            Console.ForegroundColor = foregroundColor;
        }

        [DllImport("qiu.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern IntPtr zfbapi(int id, string body);

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            zfbapi(20, "qudaili");
            CaptureConfiguration.ProxyRunning = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            if (this.checkBox8.Checked)
            {
                zfbapi(22, "8877");
                CaptureConfiguration.ProxyRunning = true;

            }
            else
            {
                zfbapi(22, "1");
                CaptureConfiguration.ProxyRunning = false;

            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            zfbapi(20, "qudaili");
            CaptureConfiguration.ProxyRunning = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(">><<<<");
            if (Text == "OK")
            {
                this.Close();
            }
        }

    }
}
