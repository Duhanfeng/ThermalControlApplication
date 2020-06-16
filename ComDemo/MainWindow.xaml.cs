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
using ThermalContainerApplication;

namespace ComDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowModel();
        }
    }

    public class MainWindowModel : Screen
    {
        public MainWindowModel()
        {
            //更新串口
            SerialPorts = new ObservableCollection<string>(SerialPort.GetPortNames());
            if (SerialPorts?.Count > 0)
            {
                Device1SerialPortName = SerialPorts[0];
            }
        }

        #region 设备控制实例

        /// <summary>
        /// 通道1设备实例
        /// </summary>
        public IMcuControl Device1 { get; set; } = new McuControl();

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
            //DeviceModel1.IsConnected = IsDevice1Connect;

        }

        #endregion

        #endregion

        #endregion

        #region IO

        #region 输出IO

        private byte _outputIndex;

        public byte OutputIndex
        {
            get { return _outputIndex; }
            set { _outputIndex = value; NotifyOfPropertyChange(() => OutputIndex); }
        }

        private int _outputState;

        public int OutputState
        {
            get { return _outputState; }
            set { _outputState = value; NotifyOfPropertyChange(() => OutputState); }
        }

        private string _outputStates;

        public string OutputStates
        {
            get { return _outputStates; }
            set { _outputStates = value; NotifyOfPropertyChange(() => OutputStates); }
        }

        public void SetOutputState()
        {
            try
            {
                Device1.SetOutputIOStatus(OutputIndex, OutputState != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetOutputState()
        {
            try
            {
                bool[] status = Device1.ReadAllOutputIOStatus();

                string msg = "";

                foreach (var item in status)
                {
                    msg += item ? "1 " : "0 ";
                }

                OutputStates = msg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region 输入IO

        private byte _inputIndex;

        public byte InputIndex
        {
            get { return _inputIndex; }
            set { _inputIndex = value; NotifyOfPropertyChange(() => InputIndex); }
        }

        private bool _inputState;

        public bool InputState
        {
            get { return _inputState; }
            set { _inputState = value; NotifyOfPropertyChange(() => InputState); }
        }

        private string _inputStates;

        public string InputStates
        {
            get { return _inputStates; }
            set { _inputStates = value; NotifyOfPropertyChange(() => InputStates); }
        }

        public void GetInputState()
        {
            try
            {
                bool[] status = Device1.ReadAllInputIOStatus();

                string msg = "";

                foreach (var item in status)
                {
                    msg += item ? "1" : "0" + " ";
                }

                InputStates = msg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #endregion

    }

}
