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
    /// MultiStepSettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MultiStepSettingWindow : MetroWindow
    {
        public MultiStepSettingWindow()
        {
            InitializeComponent();

            DataContext = new MultiStepSettingWindowViewModel();
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
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class MultiStepSettingWindowViewModel : Screen
    {

        #region 事件

        #endregion

        #region 配置参数

        private double _temp = 60;

        /// <summary>
        /// 温度(单位:摄氏度)
        /// </summary>
        public double Temp
        {
            get { return _temp; }
            set { _temp = value; NotifyOfPropertyChange(() => Temp); }
        }

        private double _keepWarmTime = 30;

        /// <summary>
        /// 保温时间(单位:分钟)
        /// </summary>
        public double KeepWarmTime
        {
            get { return _keepWarmTime; }
            set { _keepWarmTime = value; NotifyOfPropertyChange(() => KeepWarmTime); }
        }

        private ObservableCollection<TempStepData> _multiStepList = new ObservableCollection<TempStepData>();

        /// <summary>
        /// 多段设置列表
        /// </summary>
        public ObservableCollection<TempStepData> MultiStepList
        {
            get { return _multiStepList; }
            set { _multiStepList = value; NotifyOfPropertyChange(() => MultiStepList); }
        }

        #endregion

        #region 列表增删改查

        /// <summary>
        /// 增加
        /// </summary>
        public void Add()
        {
            MultiStepList.Add(new TempStepData(Temp, KeepWarmTime));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            if (index < 0)
            {
                MessageBox.Show("未选择有效项!");
                return;
            }
            MultiStepList.RemoveAt(index);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="index"></param>
        public void Insert(int index)
        {
            if (index < 0)
            {
                MessageBox.Show("未选择有效项!");
                return;
            }
            MultiStepList.Insert(index + 1, new TempStepData(Temp, KeepWarmTime));
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            MultiStepList.Clear();
        }

        #endregion

        #region 确认/取消

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        {
            //触发事件
        }


        #endregion
    }
}
