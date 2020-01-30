using Caliburn.Micro;
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
    /// McuControl.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceControl : UserControl
    {
        private DeviceControlViewModel _model;

        public DeviceControl()
        {
            InitializeComponent();

            _model = new DeviceControlViewModel();
            DataContext = _model;
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

        /// <summary>
        /// 设备名
        /// </summary>
        public string DeviceName 
        { 
            get
            {
                return _model.DeviceName;
            }
            set
            {
                _model.DeviceName = value;
            }
        }
    }

    public class DeviceControlViewModel : Screen
    {
        #region 初始化

        /// <summary>
        /// 定时器
        /// </summary>
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        /// <summary>
        /// 创建MainWindowViewModel新实例
        /// </summary>
        public DeviceControlViewModel()
        {
            //启动定时器
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
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
                //假如设备已连接,则查询相关数据
                if (IsConnected)
                {
                    ActualTemp = McuControl?.ActualTemp ?? -1;

                    //读取IO状态
                    var inputs = McuControl?.ReadAllInputIOStatus();
                    var outputs = McuControl?.ReadAllOutputIOStatus();

                    SetAllInputs(inputs);
                    SetAllOutputs(outputs);
                }
            }
            catch (Exception)
            {

            }

        }

        #endregion

        #region 设备控制实例

        /// <summary>
        /// 单片机控制实例
        /// </summary>
        public IMcuControl McuControl { get; set; }

        #endregion

        #region 全局

        private int _polingTime = 500;

        /// <summary>
        /// 轮询间隔
        /// </summary>
        public int PolingTime
        {
            get { return _polingTime; }
            set 
            {
                if (value < 200)
                {
                    value = 200;
                }

                _polingTime = value; 
                NotifyOfPropertyChange(() => PolingTime);

                dispatcherTimer.Stop();
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(value);
                dispatcherTimer.Start();
            }
        }

        #endregion

        #region 设备控制

        #region 通信

        private string _serialPortName;

        /// <summary>
        /// 设备串口
        /// </summary>
        public string SerialPortName
        {
            get { return _serialPortName; }
            set { _serialPortName = value; NotifyOfPropertyChange(() => SerialPortName); }
        }

        private string _connectName = "连接";

        /// <summary>
        /// 设备连接按键名
        /// </summary>
        public string ConnectName
        {
            get { return _connectName; }
            set { _connectName = value; NotifyOfPropertyChange(() => ConnectName); }
        }

        private bool _isConnected = false;

        /// <summary>
        /// 设备连接标志
        /// </summary>
        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; NotifyOfPropertyChange(() => IsConnected); }
        }

        #endregion

        #region 设备状态

        private string _deviceName = "通道X";

        /// <summary>
        /// 设备名
        /// </summary>
        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

        private string _workStatus = "未连接";

        /// <summary>
        /// 设备工作状态
        /// </summary>
        public string WorkStatus
        {
            get { return _workStatus; }
            set { _workStatus = value; NotifyOfPropertyChange(() => WorkStatus); }
        }

        private double _actualTemp;

        /// <summary>
        /// 设备实际温度值
        /// </summary>
        public double ActualTemp
        {
            get { return _actualTemp; }
            set { _actualTemp = value; NotifyOfPropertyChange(() => ActualTemp); }
        }

        #endregion

        #region 温度模式

        private bool _isMultiStepMode;

        /// <summary>
        /// 多段模式标志
        /// </summary>
        public bool IsMultiStepMode
        {
            get { return _isMultiStepMode; }
            set { _isMultiStepMode = value; NotifyOfPropertyChange(() => IsMultiStepMode); }
        }

        /// <summary>
        /// 设置设备为单段模式
        /// </summary>
        public void SetOneStepModel()
        {
            if (McuControl != null)
            {
                IsMultiStepMode = false;
                McuControl.TempMode = 0;
            }

        }

        /// <summary>
        /// 设置设备为多段模式
        /// </summary>
        public void SetMultiStepModel()
        {
            if (McuControl != null)
            {
                IsMultiStepMode = true;
                McuControl.TempMode = 1;
            }
            
        }

        /// <summary>
        /// 设置多段设置
        /// </summary>
        public void ConfigMultiStepMode()
        {
            MultiStepSettingWindow window = new MultiStepSettingWindow();
            window.DeviceName = DeviceName;
            window.Show();
        }

        private double _presetTemp;

        /// <summary>
        /// 预设温度值
        /// </summary>
        public double PresetTemp
        {
            get { return _presetTemp; }
            set { _presetTemp = value; NotifyOfPropertyChange(() => PresetTemp); }
        }

        /// <summary>
        /// 设置设备预设温度值
        /// </summary>
        /// <param name="temp">温度值(摄氏度)</param>
        public void SetPresetTemp()
        {
            if (McuControl == null)
            {
                return;
            }

            if (PresetTemp < -30)
            {
                PresetTemp = -30;
            }
            if (PresetTemp > 90)
            {
                PresetTemp = 90;
            }

            //写入数据
            McuControl.PresetTemp = PresetTemp;
        }

        #endregion

        #region IO

        #region 输入IO

        private bool _input0State;

        /// <summary>
        /// 设备输入0状态
        /// </summary>
        public bool Input0State
        {
            get { return _input0State; }
            set { _input0State = value; NotifyOfPropertyChange(() => Input0State); }
        }

        private bool _input1State;

        /// <summary>
        /// 设备输入1状态
        /// </summary>
        public bool Input1State
        {
            get { return _input1State; }
            set { _input1State = value; NotifyOfPropertyChange(() => Input1State); }
        }

        private bool _input2State;

        /// <summary>
        /// 设备输入2状态
        /// </summary>
        public bool Input2State
        {
            get { return _input2State; }
            set { _input2State = value; NotifyOfPropertyChange(() => Input2State); }
        }

        private bool _input3State;

        /// <summary>
        /// 设备输入3状态
        /// </summary>
        public bool Input3State
        {
            get { return _input3State; }
            set { _input3State = value; NotifyOfPropertyChange(() => Input3State); }
        }

        private bool _input4State;

        /// <summary>
        /// 设备输入4状态
        /// </summary>
        public bool Input4State
        {
            get { return _input4State; }
            set { _input4State = value; NotifyOfPropertyChange(() => Input4State); }
        }

        #endregion

        #region 输出IO

        private bool _output0State;

        /// <summary>
        /// 设备输出0状态
        /// </summary>
        public bool Output0State
        {
            get { return _output0State; }
            set { _output0State = value; NotifyOfPropertyChange(() => Output0State); }
        }

        private bool _output1State;

        /// <summary>
        /// 设备输出1状态
        /// </summary>
        public bool Output1State
        {
            get { return _output1State; }
            set { _output1State = value; NotifyOfPropertyChange(() => Output1State); }
        }

        private bool _output2State;

        /// <summary>
        /// 设备输出2状态
        /// </summary>
        public bool Output2State
        {
            get { return _output2State; }
            set { _output2State = value; NotifyOfPropertyChange(() => Output2State); }
        }

        private bool _output3State;

        /// <summary>
        /// 设备输出3状态
        /// </summary>
        public bool Output3State
        {
            get { return _output3State; }
            set { _output3State = value; NotifyOfPropertyChange(() => Output3State); }
        }

        private bool _output4State;

        /// <summary>
        /// 设备输出4状态
        /// </summary>
        public bool Output4State
        {
            get { return _output4State; }
            set { _output4State = value; NotifyOfPropertyChange(() => Output4State); }
        }

        /// <summary>
        /// 翻转输出IO0
        /// </summary>
        public void SetOutput0()
        {
            McuControl?.SetOutputIOStatus(0, Output0State);

        }

        /// <summary>
        /// 翻转输出IO1
        /// </summary>
        public void SetOutput1()
        {
            McuControl?.SetOutputIOStatus(1, Output1State);

        }

        /// <summary>
        /// 翻转输出IO2
        /// </summary>
        public void SetOutput2()
        {
            McuControl?.SetOutputIOStatus(2, Output2State);

        }

        /// <summary>
        /// 翻转输出IO3
        /// </summary>
        public void SetOutput3()
        {
            McuControl?.SetOutputIOStatus(3, Output3State);

        }

        /// <summary>
        /// 翻转输出IO4
        /// </summary>
        public void SetOutput4()
        {
            McuControl?.SetOutputIOStatus(4, Output4State);

        }

        #endregion

        /// <summary>
        /// 设置所有的输入
        /// </summary>
        /// <param name="inputs"></param>
        private void SetAllInputs(bool[] inputs)
        {
            Input0State = (inputs.Length > 0) ? inputs[0] : false;
            Input1State = (inputs.Length > 1) ? inputs[1] : false;
            Input2State = (inputs.Length > 2) ? inputs[2] : false;
            Input3State = (inputs.Length > 3) ? inputs[3] : false;
            Input4State = (inputs.Length > 4) ? inputs[4] : false;
        }

        /// <summary>
        /// 设置所有的输入
        /// </summary>
        /// <param name="inputs"></param>
        private void SetAllOutputs(bool[] outputs)
        {
            Output0State = (outputs.Length > 0) ? outputs[0] : false;
            Output1State = (outputs.Length > 1) ? outputs[1] : false;
            Output2State = (outputs.Length > 2) ? outputs[2] : false;
            Output3State = (outputs.Length > 3) ? outputs[3] : false;
            Output4State = (outputs.Length > 4) ? outputs[4] : false;
        }

        #endregion

        #region 控制

        private bool _isStart;

        /// <summary>
        /// 开始标志位
        /// </summary>
        public bool IsStart
        {
            get { return _isStart; }
            set { _isStart = value; NotifyOfPropertyChange(() => IsStart); }
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            McuControl?.Start();
            IsStart = true;

        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            McuControl?.Stop();
            IsStart = false;
        }

        #endregion

        #endregion

    }

}
