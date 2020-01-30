using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartsDemo.Chart
{
    class ChartViewModel : Screen
    {
        public ChartViewModel()
        {
            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");
            AxisUnit = TimeSpan.TicksPerSecond;
            //AxisUnit = TimeSpan.TicksPerMillisecond * 200;
            
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            SetAxisLimits(DateTime.Now);
        }

        #region 数据模型

        private ChartValues<MeasureModel> _actualChannel1 = new ChartValues<MeasureModel>();

        /// <summary>
        /// 通道1数据模型
        /// </summary>
        public ChartValues<MeasureModel> ActualChannel1
        {
            get { return _actualChannel1; }
            set { _actualChannel1 = value; NotifyOfPropertyChange(() => ActualChannel1); }
        }

        private ChartValues<MeasureModel> _actualChannel2 = new ChartValues<MeasureModel>();

        /// <summary>
        /// 通道2数据模型
        /// </summary>
        public ChartValues<MeasureModel> ActualChannel2
        {
            get { return _actualChannel2; }
            set { _actualChannel2 = value; NotifyOfPropertyChange(() => ActualChannel2); }
        }

        private ChartValues<MeasureModel> _presetChannel1 = new ChartValues<MeasureModel>();

        /// <summary>
        /// 预设通道1
        /// </summary>
        public ChartValues<MeasureModel> PresetChannel1
        {
            get { return _presetChannel1; }
            set { _presetChannel1 = value; NotifyOfPropertyChange(() => PresetChannel1); }
        }

        private ChartValues<MeasureModel> _presetChannel2 = new ChartValues<MeasureModel>();

        /// <summary>
        /// 预设通道2
        /// </summary>
        public ChartValues<MeasureModel> PresetChannel2
        {
            get { return _presetChannel2; }
            set { _presetChannel2 = value; NotifyOfPropertyChange(() => PresetChannel2); }
        }

        #region X轴

        /// <summary>
        /// 显示当前最新值后的时间
        /// </summary>
        public int AxisAheadTime { get; set; } = 1;

        /// <summary>
        /// 显示当前最新值前的时间
        /// </summary>
        public int AxisBehindTime { get; set; } = 8;

        private double _axisMax;

        /// <summary>
        /// X轴最大值
        /// </summary>
        public double AxisMax
        {
            get { return _axisMax; }
            set { _axisMax = value; NotifyOfPropertyChange(() => AxisMax); }
        }

        private double _axisMin;

        /// <summary>
        /// X轴最小值
        /// </summary>
        public double AxisMin
        {
            get { return _axisMin; }
            set { _axisMin = value; NotifyOfPropertyChange(() => AxisMin); }
        }

        private double _axisUnit;

        /// <summary>
        /// X轴单元?
        /// </summary>
        public double AxisUnit
        {
            get { return _axisUnit; }
            set { _axisUnit = value; NotifyOfPropertyChange(() => AxisUnit); }
        }

        private double _axisStep;

        /// <summary>
        /// X轴每格的时间
        /// </summary>
        public double AxisStep
        {
            get { return _axisStep; }
            set { _axisStep = value; NotifyOfPropertyChange(() => AxisStep); }
        }

        private Func<double, string> _dateTimeFormatter;

        /// <summary>
        /// X轴时间格式化器
        /// </summary>
        public Func<double, string> DateTimeFormatter
        {
            get { return _dateTimeFormatter; }
            set { _dateTimeFormatter = value; NotifyOfPropertyChange(() => DateTimeFormatter); }
        }


        /// <summary>
        /// 设置X轴范围
        /// </summary>
        /// <param name="now"></param>
        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(AxisAheadTime).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(AxisBehindTime).Ticks; // and 8 seconds behind
        }

        #endregion

        #endregion

        #region 数据接口(应用)

        /// <summary>
        /// 预设温度值1
        /// </summary>
        public double PresetTemp1 { get; set; }

        /// <summary>
        /// 预设温度值2
        /// </summary>
        public double PresetTemp2 { get; set; }

        /// <summary>
        /// 清除通道
        /// </summary>
        public void ClearChannel()
        {
            ActualChannel1.Clear();
            ActualChannel2.Clear();
            PresetChannel1.Clear();
            PresetChannel2.Clear();

            SetAxisLimits(DateTime.Now);

        }

        /// <summary>
        /// 增加通道数据
        /// </summary>
        /// <param name="channel1">通道1</param>
        /// <param name="channel2">通道2</param>
        public void AddChannelData(double channel1, double channel2)
        {
            //复制数据
            var actualChannel1 = ActualChannel1;
            var actualChannel2 = ActualChannel2;
            var presetChannel1 = PresetChannel1;
            var presetChannel2 = PresetChannel2;

            //更新数据
            var now = DateTime.Now;
            actualChannel1.Add(new MeasureModel { DateTime = now, Value = channel1 });
            actualChannel2.Add(new MeasureModel { DateTime = now, Value = channel2 });

            presetChannel1.Add(new MeasureModel { DateTime = now, Value = PresetTemp1 });
            presetChannel2.Add(new MeasureModel { DateTime = now, Value = PresetTemp2 });

            //限制数据长度
            if (actualChannel1.Count > 15)
            {
                actualChannel1.RemoveAt(0);
            }
            if (actualChannel2.Count > 15)
            {
                actualChannel2.RemoveAt(0);
            }
            if (presetChannel1.Count > 15)
            {
                presetChannel1.RemoveAt(0);
            }
            if (presetChannel2.Count > 15)
            {
                presetChannel2.RemoveAt(0);
            }


            ActualChannel1 = actualChannel1;
            ActualChannel2 = actualChannel2;
            PresetChannel1 = presetChannel1;
            PresetChannel2 = presetChannel2;

            //更新X轴范围
            SetAxisLimits(now);


        }


        #endregion

    }
}
