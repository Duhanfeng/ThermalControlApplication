using Caliburn.Micro;
using ChartsDemo.Chart;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ChartsDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ChartViewModel _model;
        private double _trend1;
        private double _trend2;


        private void Read()
        {
            var r = new Random();

            while (true)
            {
                Thread.Sleep(1000);
                _trend1 += r.Next(-8, 10);

                if (_trend1 > 90)
                {
                    _trend1 = 90;
                }
                if (_trend1 < -20)
                {
                    _trend1 = -20;
                }

                _trend2 += r.Next(-8, 10);

                if (_trend2 > 90)
                {
                    _trend2 = 90;
                }
                if (_trend2 < -20)
                {
                    _trend2 = -20;
                }

                _model?.AddChannelData(_trend1, _trend2);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _model = TempChart.DataContext as ChartViewModel;
            _model.PresetTemp1 = 52;
            _model.PresetTemp2 = 67;

            //开测试线程
            Task.Factory.StartNew(Read);

        }
    }

    public class MainWindowViewModel : Screen
    {

    }
}
