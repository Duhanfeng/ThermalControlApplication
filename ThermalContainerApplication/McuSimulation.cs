using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalContainerApplication
{
    public class McuSimulation : IMcuControl
    {
        #region Modbus

        /// <summary>
        /// 串口
        /// </summary>
        public string SerialPortName { get; set; }

        /// <summary>
        /// 从机地址
        /// </summary>
        public byte SlaveAddress { get; set; }

        #endregion
        #region 设备控制

        #region IO

        bool[] _inputs = new bool[5];

        bool[] _outputs = new bool[5];

        /// <summary>
        /// 读取所有输出IO的状态
        /// </summary>
        /// <returns></returns>
        public bool[] ReadAllOutputIOStatus()
        {
            return _outputs;
        }

        /// <summary>
        /// 读取所有输入IO的状态
        /// </summary>
        /// <returns></returns>
        public bool[] ReadAllInputIOStatus()
        {
            return _inputs;
        }

        /// <summary>
        /// 设置输出IO状态
        /// </summary>
        /// <param name="index">IO索引</param>
        /// <param name="isEnable">IO状态</param>
        public void SetOutputIOStatus(byte index, bool isEnable)
        {
            _outputs[index] = isEnable;

            Console.WriteLine($"O[{index}]={isEnable}");
        }

        #endregion

        #region 温度控制

        public ushort _tempMode = 0;

        public ushort TempMode
        {
            get
            {
                return _tempMode;
            }
            set
            {
                _tempMode = value;
                Console.WriteLine($"温度模式:{value}");
            }
        }

        /// <summary>
        /// 目标温度(摄氏度)
        /// </summary>
        public double TargetTemp
        {
            get
            {
                return SingleStepTemp;
            }
        }

        /// <summary>
        /// 目标保温时间(分钟)
        /// </summary>
        public double TargetKeepWarmTime { get; } = 20;

        private Random random = new Random();

        private double _currenTemp1 = 30;

        public double ActualTemp
        {
            get
            {
                _currenTemp1 += random.NextDouble() - 0.5;

                if (_currenTemp1 > 90)
                {
                    _currenTemp1 = 90;
                }
                else if (_currenTemp1 < -20)
                {
                    _currenTemp1 = -20;
                }
                return _currenTemp1;
            }
        }

        private double _presetTemp = 60;


        public double SingleStepTemp
        {
            get
            {
                return _presetTemp;
            }
            set
            {
                _presetTemp = value;
                Console.WriteLine($"预设温度:{value}");
            }
        }

        /// <summary>
        /// 多段模式当前段
        /// </summary>
        public ushort CurrentStep
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// 多段模式段数
        /// </summary>
        public ushort MultiStepCount { get; set; }

        /// <summary>
        /// 设置多段数据
        /// </summary>
        /// <param name="tempSteps"></param>
        public void SetMultiStep(IList<TempStepData> tempSteps)
        {
            MultiStepCount = (ushort)tempSteps.Count;
            Console.WriteLine($"设置多段:({tempSteps.Count}段)");
            foreach (var item in tempSteps)
            {
                Console.WriteLine($"    温度:{item.Temp}  保温时间:{item.KeepWarmTime}");   
            }
        }

        #endregion

        #region 系统控制

        /// <summary>
        /// 当前工作状态
        /// </summary>
        public EWorkStatus WorkStatus { get; private set; } = EWorkStatus.Ready;

        private bool _isStart = false;

        /// <summary>
        /// 启动标志
        /// </summary>
        public bool IsStart
        {
            get
            {
                return _isStart;
            }
            set
            {
                WorkStatus = value ? EWorkStatus.Running : EWorkStatus.Ready;
                Console.WriteLine(value ? "启动" : "停止");
            }
        }

        #endregion

        #endregion
    }
}
