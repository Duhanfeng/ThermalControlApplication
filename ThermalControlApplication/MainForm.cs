using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThermalControlApplication
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 单片机控制接口
        /// </summary>
        /// public McuControl McuControl { get; set; } = new McuControl();
        public McuSimulation McuControl { get; set; } = new McuSimulation();
        
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 界面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateSerialPort();
            UpdateConnectStatus(false);
        }

        #region 串口

        /// <summary>
        /// 刷新串口
        /// </summary>
        private void UpdateSerialPort()
        {
            //更新串口
            var portNames = SerialPort.GetPortNames();

            SerialComboBox.Items.Clear();
            foreach (var item in portNames)
            {
                SerialComboBox.Items.Add(item);
            }

            if (SerialComboBox.Items.Count > 0)
            {
                SerialComboBox.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 更新串口按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSerialButton_Click(object sender, EventArgs e)
        {
            UpdateSerialPort();
        }

        /// <summary>
        /// 串口选择项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox?.SelectedIndex >= 0)
            {
                McuControl.SerialPortName = comboBox.SelectedItem as string;
            }

        }

        #endregion

        #region 定时刷新

        /// <summary>
        /// 连接状态
        /// </summary>
        private bool _isConnected = false;

        /// <summary>
        /// 更新连接状态
        /// </summary>
        private void UpdateConnectStatus(bool isConnected)
        {
            _isConnected = isConnected;
            SerialComboBox.Enabled = !isConnected;
            UpdateSerialButton.Enabled = !isConnected;
            PolingTimeTextBox.Enabled = !isConnected;
            ConnectButton.Enabled = !isConnected;
            DisconnectButton.Enabled = isConnected;

            ControlGroupBox.Enabled = isConnected;

            //设置更新定时器状态
            UpdateTimer.Enabled = isConnected;

        }

        /// <summary>
        /// 连接(开启定时刷新)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            int polingTime = 0;
            if (!int.TryParse(PolingTimeTextBox.Text, out polingTime))
            {
                PolingTimeTextBox.Text = "1000";
                MessageBox.Show("轮询间隔输入框数据异常!");
                return;
            }
            UpdateTimer.Interval = polingTime;

            //获取设备数据以测试连接性
            try
            {
                PresetTemp1TextBox.Text = McuControl.PresetTemp1.ToString("F3");
                PresetTemp2TextBox.Text = McuControl.PresetTemp2.ToString("F3");
            }
            catch (Exception)
            {
                UpdateConnectStatus(false);
                MessageBox.Show("通信超时,请检查串口号是否正常!");
                return;
            }

            UpdateConnectStatus(true);

        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            UpdateConnectStatus(false);
        }

        /// <summary>
        /// 定时器事件(定时更新界面)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //读取工作状态
            var workStatus = McuControl.WorkStatus;

            //读取通道1温度值(实际值)
            var temp1 = McuControl.CurrentTemp1;

            //读取通道2温度值(实际值)
            var temp2 = McuControl.CurrentTemp2;

            //读取IO状态
            var inputs = McuControl.ReadAllIputIOStatus();
            var outputs = McuControl.ReadAllOutputIOStatus();

            //刷新控件
            CurrentTemp1TextBox.Text = temp1.ToString("F3");
            CurrentTemp2TextBox.Text = temp2.ToString("F3");
            if (outputs.Length >= 5)
            {
                Output0CheckBox.Checked = outputs[0];
                Output1CheckBox.Checked = outputs[1];
                Output2CheckBox.Checked = outputs[2];
                Output3CheckBox.Checked = outputs[3];
                Output4CheckBox.Checked = outputs[4];
            }
            if (inputs.Length >= 5)
            {
                Input0CheckBox.Checked = inputs[0];
                Input1CheckBox.Checked = inputs[1];
                Input2CheckBox.Checked = inputs[2];
                Input3CheckBox.Checked = inputs[3];
                Input4CheckBox.Checked = inputs[4];
            }

        }

        #endregion

        #region 单片机控制

        /// <summary>
        /// 输出按键点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputCheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            byte index = byte.Parse(checkBox?.Tag as string);
            McuControl.SetOutputIOStatus(index, !checkBox.Checked);
        }

        /// <summary>
        /// 预设温度1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresetTemp1Button_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (!double.TryParse(PresetTemp1TextBox.Text, out temp))
            {
                PresetTemp1TextBox.Text = "60.000";
                MessageBox.Show("输入框数据异常!");
                return;
            }
            McuControl.PresetTemp1 = temp;

        }

        /// <summary>
        /// 预设温度2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresetTemp2Button_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (!double.TryParse(PresetTemp2TextBox.Text, out temp))
            {
                PresetTemp2TextBox.Text = "60.000";
                MessageBox.Show("输入框数据异常!");
                return;
            }
            McuControl.PresetTemp2 = temp;

        }

        #endregion

    }
}
