using Caliburn.Micro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ThermalContainerApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// 按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tb = sender as TextBox;
                BindingExpression be = tb.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
            }
        }

        /// <summary>
        /// 失去焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            BindingExpression be = tb.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

    }

    /// <summary>
    /// 主窗口显示模型
    /// </summary>
    public class MainWindowViewModel : Screen
    {

#if false

        
        #region 通道1

        #region 通信

        private string _channel1SerialPortName;

        /// <summary>
        /// 通道1串口
        /// </summary>
        public string Channel1SerialPortName
        {
            get { return _channel1SerialPortName; }
            set { _channel1SerialPortName = value; NotifyOfPropertyChange(() => Channel1SerialPortName); }
        }

        private string _channel1ConnectName = "连接";

        /// <summary>
        /// 通道1连接按键名
        /// </summary>
        public string Channel1ConnectName
        {
            get { return _channel1ConnectName; }
            set { _channel1ConnectName = value; NotifyOfPropertyChange(() => Channel1ConnectName); }
        }

        private bool _isChannel1Connected = false;

        /// <summary>
        /// 通道1连接标志
        /// </summary>
        public bool IsChannel1Connected
        {
            get { return _isChannel1Connected; }
            set { _isChannel1Connected = value; NotifyOfPropertyChange(() => IsChannel1Connected); }
        }

        #endregion

        #region 设备状态

        private string _channel1WorkStatus = "未连接";

        /// <summary>
        /// 通道1工作状态
        /// </summary>
        public string Channel1WorkStatus
        {
            get { return _channel1WorkStatus; }
            set { _channel1WorkStatus = value; NotifyOfPropertyChange(() => Channel1WorkStatus); }
        }

        private double _channel1ActualTemp;

        /// <summary>
        /// 通道1实际温度值
        /// </summary>
        public double Channel1ActualTemp
        {
            get { return _channel1ActualTemp; }
            set { _channel1ActualTemp = value; NotifyOfPropertyChange(() => Channel1ActualTemp); }
        }

        #endregion

        #region 温度模式

        private bool _isChannel1MultiStepMode;

        public bool IsChannel1MultiStepMode
        {
            get { return _isChannel1MultiStepMode; }
            set { _isChannel1MultiStepMode = value; NotifyOfPropertyChange(() => IsChannel1MultiStepMode); }
        }

        /// <summary>
        /// 设置通道1为单段模式
        /// </summary>
        public void SetChannel1OneStepModel()
        {
            IsChannel1MultiStepMode = false;
            Channel1Mcu.TempMode = 0;
        }

        /// <summary>
        /// 设置通道1为多段模式
        /// </summary>
        public void SetChannel1MultiStepModel()
        {
            IsChannel1MultiStepMode = true;
            Channel1Mcu.TempMode = 1;
        }

        private double _channel1PresetTemp;

        /// <summary>
        /// 预设温度值
        /// </summary>
        public double Channel1PresetTemp
        {
            get { return _channel1PresetTemp; }
            set { _channel1PresetTemp = value; NotifyOfPropertyChange(() => Channel1PresetTemp); }
        }


        /// <summary>
        /// 设置通道1预设温度值
        /// </summary>
        /// <param name="temp">温度值(摄氏度)</param>
        public void SetChannel1PresetTemp()
        {
            if (Channel1PresetTemp < -30)
            {
                Channel1PresetTemp = -30;
            }
            if (Channel1PresetTemp > 90)
            {
                Channel1PresetTemp = 90;
            }

            //写入数据
            Channel1Mcu.PresetTemp = Channel1PresetTemp;
        }

        #endregion

        #region IO

        #region 输入IO

        private bool _channel1Input0State;

        /// <summary>
        /// 通道1输入0状态
        /// </summary>
        public bool Channel1Input0State
        {
            get { return _channel1Input0State; }
            set { _channel1Input0State = value; NotifyOfPropertyChange(() => Channel1Input0State); }
        }

        private bool _channel1Input1State;

        /// <summary>
        /// 通道1输入1状态
        /// </summary>
        public bool Channel1Input1State
        {
            get { return _channel1Input1State; }
            set { _channel1Input1State = value; NotifyOfPropertyChange(() => Channel1Input1State); }
        }

        private bool _channel1Input2State;

        /// <summary>
        /// 通道1输入2状态
        /// </summary>
        public bool Channel1Input2State
        {
            get { return _channel1Input2State; }
            set { _channel1Input2State = value; NotifyOfPropertyChange(() => Channel1Input2State); }
        }

        private bool _channel1Input3State;

        /// <summary>
        /// 通道1输入3状态
        /// </summary>
        public bool Channel1Input3State
        {
            get { return _channel1Input3State; }
            set { _channel1Input3State = value; NotifyOfPropertyChange(() => Channel1Input3State); }
        }

        private bool _channel1Input4State;

        /// <summary>
        /// 通道1输入4状态
        /// </summary>
        public bool Channel1Input4State
        {
            get { return _channel1Input4State; }
            set { _channel1Input4State = value; NotifyOfPropertyChange(() => Channel1Input4State); }
        }

        #endregion

        #region 输出IO

        private bool _channel1Output0State;

        /// <summary>
        /// 通道1输出0状态
        /// </summary>
        public bool Channel1Output0State
        {
            get { return _channel1Output0State; }
            set { _channel1Output0State = value; NotifyOfPropertyChange(() => Channel1Output0State); }
        }

        private bool _channel1Output1State;

        /// <summary>
        /// 通道1输出1状态
        /// </summary>
        public bool Channel1Output1State
        {
            get { return _channel1Output1State; }
            set { _channel1Output1State = value; NotifyOfPropertyChange(() => Channel1Output1State); }
        }

        private bool _channel1Output2State;

        /// <summary>
        /// 通道1输出2状态
        /// </summary>
        public bool Channel1Output2State
        {
            get { return _channel1Output2State; }
            set { _channel1Output2State = value; NotifyOfPropertyChange(() => Channel1Output2State); }
        }

        private bool _channel1Output3State;

        /// <summary>
        /// 通道1输出3状态
        /// </summary>
        public bool Channel1Output3State
        {
            get { return _channel1Output3State; }
            set { _channel1Output3State = value; NotifyOfPropertyChange(() => Channel1Output3State); }
        }

        private bool _channel1Output4State;

        /// <summary>
        /// 通道1输出4状态
        /// </summary>
        public bool Channel1Output4State
        {
            get { return _channel1Output4State; }
            set { _channel1Output4State = value; NotifyOfPropertyChange(() => Channel1Output4State); }
        }

        /// <summary>
        /// 翻转输出IO0
        /// </summary>
        public void SetChannel1Output0()
        {
            Channel1Mcu.SetOutputIOStatus(0, Channel1Output0State);

        }

        /// <summary>
        /// 翻转输出IO1
        /// </summary>
        public void SetChannel1Output1()
        {
            Channel1Mcu.SetOutputIOStatus(1, Channel1Output1State);

        }

        /// <summary>
        /// 翻转输出IO2
        /// </summary>
        public void SetChannel1Output2()
        {
            Channel1Mcu.SetOutputIOStatus(2, Channel1Output2State);

        }

        /// <summary>
        /// 翻转输出IO3
        /// </summary>
        public void SetChannel1Output3()
        {
            Channel1Mcu.SetOutputIOStatus(3, Channel1Output3State);

        }

        /// <summary>
        /// 翻转输出IO4
        /// </summary>
        public void SetChannel1Output4()
        {
            Channel1Mcu.SetOutputIOStatus(4, Channel1Output4State);

        }

        #endregion

        /// <summary>
        /// 设置所有的输入
        /// </summary>
        /// <param name="inputs"></param>
        private void SetChannel1AllInputs(bool[] inputs)
        {
            Channel1Input0State = (inputs.Length > 0) ? inputs[0] : false;
            Channel1Input1State = (inputs.Length > 1) ? inputs[1] : false;
            Channel1Input2State = (inputs.Length > 2) ? inputs[2] : false;
            Channel1Input3State = (inputs.Length > 3) ? inputs[3] : false;
            Channel1Input4State = (inputs.Length > 4) ? inputs[4] : false;
        }

        /// <summary>
        /// 设置所有的输入
        /// </summary>
        /// <param name="inputs"></param>
        private void SetChannel1AllOutputs(bool[] outputs)
        {
            Channel1Output0State = (outputs.Length > 0) ? outputs[0] : false;
            Channel1Output1State = (outputs.Length > 1) ? outputs[1] : false;
            Channel1Output2State = (outputs.Length > 2) ? outputs[2] : false;
            Channel1Output3State = (outputs.Length > 3) ? outputs[3] : false;
            Channel1Output4State = (outputs.Length > 4) ? outputs[4] : false;
        }

        #endregion

        /// <summary>
        /// 连接通道1串口
        /// </summary>
        public void ConnectChannel1Serial()
        {
            if (_isChannel1Connected)
            {
                //停止定时器

                IsChannel1Connected = false;
                Channel1ConnectName = "连接";
            }
            else
            {
                //设置串口号
                Channel1Mcu.SerialPortName = Channel1SerialPortName;

                //获取数据以验证连接是否成功
                try
                {
                    Channel1WorkStatus = Channel1Mcu.WorkStatus.ToString();
                    Channel1ActualTemp = Channel1Mcu.ActualTemp;
                }
                catch (Exception)
                {
                    MessageBox.Show("通信超时,请检查串口号是否正常!");
                    return;
                }

                //开启线程轮询

                IsChannel1Connected = true;
                Channel1ConnectName = "断开";

            }

        }

        #endregion

#endif

        #region 初始化

        /// <summary>
        /// 定时器
        /// </summary>
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        /// <summary>
        /// 创建MainWindowViewModel新实例
        /// </summary>
        public MainWindowViewModel()
        {
            DeviceModel1.McuControl = Device1;
            DeviceModel2.McuControl = Device2;

            //更新串口
            SerialPorts = new ObservableCollection<string>(SerialPort.GetPortNames());
            if (SerialPorts?.Count > 0)
            {
                Device1SerialPortName = SerialPorts[0];
                Device2SerialPortName = SerialPorts[0];
            }

            //启动定时器
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(2000);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        /// <summary>
        /// 定时器回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ////假如通道1已连接,则查询相关数据
                //if (IsChannel1Connected)
                //{
                //    Channel1ActualTemp = Channel1Mcu.ActualTemp;

                //    //读取IO状态
                //    var inputs = Channel1Mcu.ReadAllInputIOStatus();
                //    var outputs = Channel1Mcu.ReadAllOutputIOStatus();

                //    SetChannel1AllInputs(inputs);
                //    SetChannel1AllOutputs(outputs);
                //}
            }
            catch (Exception)
            {

            }




        }

        #endregion


        #region 设备控制实例

        /// <summary>
        /// 通道1设备实例
        /// </summary>
        public IMcuControl Device1 { get; set; } = new McuSimulation();

        /// <summary>
        /// 通道2设备实例
        /// </summary>
        public IMcuControl Device2 { get; set; } = new McuSimulation();

        #endregion

        #region 通信

        private int _polingTime = 500;

        /// <summary>
        /// 轮询间隔
        /// </summary>
        public int PolingTime
        {
            get { return _polingTime; }
            set { _polingTime = value; NotifyOfPropertyChange(() => PolingTime); }
        }

        #region 串口

        private ObservableCollection<string> _serialPorts;

        /// <summary>
        /// 串口集合
        /// </summary>
        public ObservableCollection<string> SerialPorts
        {
            get { return _serialPorts; }
            set { _serialPorts = value; NotifyOfPropertyChange(() => SerialPorts); }
        }

        #region 设备1

        private string _device1SerialPortName;

        /// <summary>
        /// 设备1串口
        /// </summary>
        public string Device1SerialPortName
        {
            get { return _device1SerialPortName; }
            set { _device1SerialPortName = value; NotifyOfPropertyChange(() => Device1SerialPortName); }
        }

        private bool _isDevice1Connect;

        /// <summary>
        /// 设备1连接标志
        /// </summary>
        public bool IsDevice1Connect
        {
            get { return _isDevice1Connect; }
            set { _isDevice1Connect = value; NotifyOfPropertyChange(() => IsDevice1Connect); }
        }

        /// <summary>
        /// 连接设备1
        /// </summary>
        public void ConnectDevice1()
        {
            if (IsDevice1Connect)
            {
                IsDevice1Connect = false;
            }
            else
            {
                //设置串口号
                Device1.SerialPortName = Device1SerialPortName;

                //获取数据以验证连接是否成功
                try
                {
                    var workStatus = Device1.WorkStatus;
                }
                catch (Exception)
                {
                    MessageBox.Show("通信超时,请检查串口号是否正常!");
                    return;
                }

                IsDevice1Connect = true;
            }

            //设置用户控件的连接状态
            DeviceModel1.IsConnected = IsDevice1Connect;

        }

        #endregion

        #region 设备2

        private string _device2SerialPortName;

        /// <summary>
        /// 设备2串口
        /// </summary>
        public string Device2SerialPortName
        {
            get { return _device2SerialPortName; }
            set { _device2SerialPortName = value; NotifyOfPropertyChange(() => Device2SerialPortName); }
        }

        private bool _isDevice2Connect;

        /// <summary>
        /// 设备2连接标志
        /// </summary>
        public bool IsDevice2Connect
        {
            get { return _isDevice2Connect; }
            set { _isDevice2Connect = value; NotifyOfPropertyChange(() => IsDevice2Connect); }
        }

        /// <summary>
        /// 连接设备1
        /// </summary>
        public void ConnectDevice2()
        {
            if (IsDevice2Connect)
            {
                IsDevice2Connect = false;
            }
            else
            {
                //设置串口号
                Device2.SerialPortName = Device2SerialPortName;

                //获取数据以验证连接是否成功
                try
                {
                    var workStatus = Device2.WorkStatus;
                }
                catch (Exception)
                {
                    MessageBox.Show("通信超时,请检查串口号是否正常!");
                    return;
                }

                IsDevice2Connect = true;
            }

            //设置用户控件的连接状态
            DeviceModel2.IsConnected = IsDevice2Connect;

        }

        #endregion

        #endregion

        #endregion

        #region 设备控制控件模型

        private DeviceControlViewModel _deviceModel1 = new DeviceControlViewModel();

        /// <summary>
        /// 设备1数据模型
        /// </summary>
        public DeviceControlViewModel DeviceModel1
        {
            get { return _deviceModel1; }
            set { _deviceModel1 = value; NotifyOfPropertyChange(() => SerialPorts); }
        }

        private DeviceControlViewModel _deviceModel2 = new DeviceControlViewModel();

        /// <summary>
        /// 设备2数据模型
        /// </summary>
        public DeviceControlViewModel DeviceModel2
        {
            get { return _deviceModel2; }
            set { _deviceModel2 = value; NotifyOfPropertyChange(() => DeviceModel2); }
        }

        #endregion

    }
}
