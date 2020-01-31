using Caliburn.Micro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ThermalContainerApplication
{
    /// <summary>
    /// ReportWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ReportWindow : MetroWindow
    {
        private ReportWindowViewModel _model;

        public ReportWindow()
        {
            InitializeComponent();

            _model = new ReportWindowViewModel();
            DataContext = _model;
        }

        public ReportWindow(IList<ReportBaseData> reports1, IList<ReportBaseData> reports2) : this()
        {
            _model.Device1Reports = new ObservableCollection<ReportBaseData>(reports1);
            _model.Device2Reports = new ObservableCollection<ReportBaseData>(reports2);
        }
    }

    public class ReportBaseData
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        
        ///// <summary>
        ///// 结束时间
        ///// </summary>
        //public DateTime EndTime { get; set; }

        /// <summary>
        /// 工作状态
        /// </summary>
        public EWorkStatus WorkStatus { get; set; }

        /// <summary>
        /// 设置的温度值(单位:度)
        /// </summary>
        public double Temp { get; set; }

        /// <summary>
        /// 保温时间(单位:分钟)
        /// </summary>
        public double KeepWarmTime { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

    }

    public class ReportWindowViewModel : Screen
    {
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
        /// 创建ReportWindowViewModel新实例
        /// </summary>
        public ReportWindowViewModel()
        {

        }

        /// <summary>
        /// 创建ReportWindowViewModel新实例
        /// </summary>
        /// <param name="reports1">报告数据</param>
        public ReportWindowViewModel(IList<ReportBaseData> reports1, IList<ReportBaseData> reports2)
        {
            Device1Reports = new ObservableCollection<ReportBaseData>(reports1);
            Device2Reports = new ObservableCollection<ReportBaseData>(reports2);
        }

    }
}
