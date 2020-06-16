using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalContainerApplication.Chart
{
    public class TemperatureChartViewModel : Screen
    {
        public TemperatureChartViewModel()
        {
            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //设置时间格式化器
            //DateTimeFormatter = value => new DateTime((long)value).ToString("HH:mm");
            AxisUnit = TimeSpan.TicksPerSecond;
            //AxisUnit = TimeSpan.TicksPerMillisecond * 200;
            
            AxisStep = TimeSpan.FromMinutes(1).Ticks;
            //AxisStep = TimeSpan.FromSeconds(1).Ticks;

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
        /// 轴数据更新时间
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

        public string DateTimeFormatter(double value)
        {
            return new DateTime((long)value).ToString("HH:mm");
        }

        /// <summary>
        /// 设置X轴范围
        /// </summary>
        /// <param name="now"></param>
        private void SetAxisLimits(DateTime now)
        {
            //AxisMax = now.Ticks + TimeSpan.FromSeconds(AxisAheadTime).Ticks; // lets force the axis to be 1 second ahead
            //AxisMin = now.Ticks - TimeSpan.FromSeconds(AxisBehindTime).Ticks; // and 8 seconds behind

            AxisMax = now.Ticks + TimeSpan.FromSeconds(AxisAheadTime).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(AxisBehindTime).Ticks; // and 8 seconds behind

        }

        #endregion

        #endregion

        #region 图表设置

        private long _chartLimitSeconds = 30 * 60;

        /// <summary>
        /// 图表X轴显示时长(单位S)
        /// </summary>
        public long ChartLimitSeconds
        {
            get { return _chartLimitSeconds; }
            set { _chartLimitSeconds = value; NotifyOfPropertyChange(() => ChartLimitSeconds); AxisBehindTime = (int)(value * 0.9); AxisAheadTime = (int)(value * 0.1); }
        }

        private long _chartStepSeconds = 60;

        /// <summary>
        /// 图表单格时长(单位:S)
        /// </summary>
        public long ChartStepSeconds
        {
            get { return _chartStepSeconds; }
            set { _chartStepSeconds = value; NotifyOfPropertyChange(() => ChartStepSeconds); AxisStep = TimeSpan.FromSeconds(value).Ticks;}
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
        /// 图表最大点数
        /// </summary>
        public int ChartMaxPointCount
        {
            get
            {
                int count = (int)(ChartLimitSeconds / ChartUpdateSeconds);

                return count;
            }
        }

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
        /// 更新X轴
        /// </summary>
        private void UpdateXAxis(DateTime now)
        {
            SetAxisLimits(now);

            if (PresetChannel1.Count == 0)
            {
                PresetChannel1.Add(new MeasureModel(new DateTime((long)AxisMin), PresetTemp1));
                PresetChannel1.Add(new MeasureModel(new DateTime((long)AxisMax), PresetTemp1));
            }
            else
            {
                PresetChannel1[0].DateTime = new DateTime((long)AxisMin);
                PresetChannel1[0].Value = PresetTemp1;
                PresetChannel1[1].DateTime = new DateTime((long)AxisMax);
                PresetChannel1[1].Value = PresetTemp1;
            }

            if (PresetChannel2.Count == 0)
            {
                PresetChannel2.Add(new MeasureModel(new DateTime((long)AxisMin), PresetTemp2));
                PresetChannel2.Add(new MeasureModel(new DateTime((long)AxisMax), PresetTemp2));
            }
            else
            {
                PresetChannel2[0].DateTime = new DateTime((long)AxisMin);
                PresetChannel2[0].Value = PresetTemp2;
                PresetChannel2[1].DateTime = new DateTime((long)AxisMax);
                PresetChannel2[1].Value = PresetTemp2;
            }

        }

        /// <summary>
        /// 增加通道数据
        /// </summary>
        /// <param name="channel1">通道1</param>
        /// <param name="channel2">通道2</param>
        public void AddChannelData(double channel1, double channel2)
        {
            //更新数据
            var now = DateTime.Now;

            //ChartValues<MeasureModel> actualChannel1 = new ChartValues<MeasureModel>(ActualChannel1);
            //ChartValues<MeasureModel> actualChannel2 = new ChartValues<MeasureModel>(ActualChannel2);
            //actualChannel1.Add(new MeasureModel { DateTime = now, Value = channel1 });
            //actualChannel2.Add(new MeasureModel { DateTime = now, Value = channel2 });

            ////限制数据长度
            //if (actualChannel1.Count > ChartMaxPointCount)
            //{
            //    actualChannel1.RemoveAt(0);
            //}
            //if (actualChannel2.Count > ChartMaxPointCount)
            //{
            //    actualChannel2.RemoveAt(0);
            //}
            //ActualChannel1 = actualChannel1;
            //ActualChannel2 = actualChannel2;

            ActualChannel1.Add(new MeasureModel { DateTime = now, Value = channel1 });
            ActualChannel2.Add(new MeasureModel { DateTime = now, Value = channel2 });

            //限制数据长度
            if (ActualChannel1.Count > ChartMaxPointCount)
            {
                ActualChannel1.RemoveAt(0);
            }
            if (ActualChannel2.Count > ChartMaxPointCount)
            {
                ActualChannel2.RemoveAt(0);
            }

            //更新X轴范围
            UpdateXAxis(now);
        }

        #endregion

    }
}
