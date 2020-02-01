using Caliburn.Micro;
using DhfLib.Infrastructure;
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
using ThermalContainerApplication.Chart;

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
        #region 初始化

        /// <summary>
        /// 更新图表定时器
        /// </summary>
        private DispatcherTimer _updateChartTimer = new DispatcherTimer();

        /// <summary>
        /// 更新时间定时器
        /// </summary>
        private DispatcherTimer _updateDateTimer = new DispatcherTimer();

        /// <summary>
        /// 创建MainWindowViewModel新实例
        /// </summary>
        public MainWindowViewModel()
        {
            DeviceModel1.McuControl = Device1;
            DeviceModel2.McuControl = Device2;

            DeviceModel1.DeviceName = "通道1";
            DeviceModel2.DeviceName = "通道2";

            //更新串口
            SerialPorts = new ObservableCollection<string>(SerialPort.GetPortNames());
            if (SerialPorts?.Count > 0)
            {
                Device1SerialPortName = SerialPorts[0];
                Device2SerialPortName = SerialPorts[0];
            }

            //启动更新图表定时器
            _updateChartTimer.Interval = TimeSpan.FromSeconds(2);
            _updateChartTimer.Tick += UpdateChartTimer_Tick;
            _updateChartTimer.Start();

            //启动更新日期定时器
            _updateDateTimer.Interval = TimeSpan.FromSeconds(1);
            _updateDateTimer.Tick += UpdateDateTimer_Tick;
            _updateDateTimer.Start();

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            ChartLimitSeconds = 30 * 60;
            ChartStepSeconds = 3 * 60;
            ChartUpdateSeconds = 10;
            UpdateChartConfig();
        }

        /// <summary>
        /// 设备1工作状态
        /// </summary>
        private EWorkStatus _device1WorkStatus = EWorkStatus.Unconnect;

        /// <summary>
        /// 设备2工作状态
        /// </summary>
        private EWorkStatus _device2WorkStatus = EWorkStatus.Unconnect;

        /// <summary>
        /// 更新时间定时器回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDateTimer_Tick(object sender, EventArgs e)
        {
            NowDate = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss");

            if (IsDevice1Connect)
            {
                var mode = DeviceModel1;
                var status = mode.WorkStatus;
                if (_device1WorkStatus != status)
                {
                    _device1WorkStatus = status;

                    //增加消息
                    Message = $"{mode.DeviceName} {EnumHelper.GetDescription(status)}";
                    Device1Reports.Add(new ReportBaseData { StartTime = DateTime.Now, WorkStatus = status, Temp = mode.TargetTemp, KeepWarmTime = mode.TargetKeepWarmTime, Message = Message }); ;
                }

            }
            if (IsDevice2Connect)
            {
                var mode = DeviceModel2;
                var status = mode.WorkStatus;
                if (_device2WorkStatus != status)
                {
                    _device2WorkStatus = status;

                    //增加消息
                    Message = $"{mode.DeviceName} {EnumHelper.GetDescription(status)}";
                    Device2Reports.Add(new ReportBaseData { StartTime = DateTime.Now, WorkStatus = status, Temp = mode.TargetTemp, KeepWarmTime = mode.TargetKeepWarmTime, Message = Message }); ;
                }
            }

        }

        /// <summary>
        /// 更新图表定时器回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateChartTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                double actualTemp1 = 0;
                double actualTemp2 = 0;

                if (IsDevice1Connect)
                {
                    ChartViewModel.PresetTemp1 = DeviceModel1.TargetTemp;
                    actualTemp1 = DeviceModel1.ActualTemp;
                }
                if (IsDevice2Connect)
                {
                    ChartViewModel.PresetTemp2 = DeviceModel2.TargetTemp;
                    actualTemp2 = DeviceModel2.ActualTemp;
                }

                if (IsDevice1Connect || IsDevice2Connect)
                {
                    ChartViewModel.AddChannelData(actualTemp1, actualTemp2);
                }

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

        #region 其他

        private string _nowDate;

        /// <summary>
        /// 当前时间
        /// </summary>
        public string NowDate
        {
            get { return _nowDate; }
            set { _nowDate = value; NotifyOfPropertyChange(() => NowDate); }
        }

        private ObservableCollection<ReportBaseData> _device1Reports = new ObservableCollection<ReportBaseData>();

        /// <summary>
        /// 设备1报告
        /// </summary>
        public ObservableCollection<ReportBaseData> Device1Reports
        {
            get { return _device1Reports; }
            set { _device1Reports = value; NotifyOfPropertyChange(() => Device1Reports); }
        }

        private ObservableCollection<ReportBaseData> _device2Reports = new ObservableCollection<ReportBaseData>();

        /// <summary>
        /// 设备2报告
        /// </summary>
        public ObservableCollection<ReportBaseData> Device2Reports
        {
            get { return _device2Reports; }
            set { _device2Reports = value; NotifyOfPropertyChange(() => Device2Reports); }
        }

        /// <summary>
        /// 显示报告
        /// </summary>
        public void ShowReport()
        {
            var window = new ReportWindow(Device1Reports, Device2Reports);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private string _message;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; NotifyOfPropertyChange(() => Message); }
        }

        #endregion

        #region 图表控件模型

        private TemperatureChartViewModel _chartViewModel = new TemperatureChartViewModel();

        /// <summary>
        /// 图表控件模型实例
        /// </summary>
        public TemperatureChartViewModel ChartViewModel
        {
            get { return _chartViewModel; }
            set { _chartViewModel = value; NotifyOfPropertyChange(() => ChartViewModel); }
        }

        private long _chartLimitSeconds = 30 * 60;

        /// <summary>
        /// 图表X轴显示时长(单位S)
        /// </summary>
        public long ChartLimitSeconds
        {
            get { return _chartLimitSeconds; }
            set { _chartLimitSeconds = value; NotifyOfPropertyChange(() => ChartLimitSeconds); }
        }

        private long _chartStepSeconds = 60;

        /// <summary>
        /// 图表单格时长(单位:S)
        /// </summary>
        public long  ChartStepSeconds
        {
            get { return _chartStepSeconds; }
            set { _chartStepSeconds = value; NotifyOfPropertyChange(() => ChartStepSeconds); }
        }

        private int _chartUpdateSeconds = 5;

        /// <summary>
        /// 图表更新时间(单位:S)
        /// </summary>
        public int ChartUpdateSeconds
        {
            get { return _chartUpdateSeconds; }
            set { _chartUpdateSeconds = value; NotifyOfPropertyChange(() => ChartUpdateSeconds); }
        }

        /// <summary>
        /// 更新图表配置
        /// </summary>
        public void UpdateChartConfig()
        {
            ChartViewModel.ChartLimitSeconds = ChartLimitSeconds;
            ChartViewModel.ChartStepSeconds = ChartStepSeconds;
            ChartViewModel.ChartUpdateSeconds = ChartUpdateSeconds;
            _updateChartTimer.Stop();
            _updateChartTimer.Interval = TimeSpan.FromSeconds(ChartUpdateSeconds);
            _updateChartTimer.Start();
        }

        #endregion
    }
}
