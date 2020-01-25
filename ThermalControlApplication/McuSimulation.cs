using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalControlApplication
{
    public class McuSimulation : McuControl
    {

        #region 设备控制

        #region IO

        bool[] _inputs = new bool[5];

        bool[] _outputs = new bool[5];

        /// <summary>
        /// 读取所有输出IO的状态
        /// </summary>
        /// <returns></returns>
        public new bool[] ReadAllOutputIOStatus()
        {
            return _outputs;
        }

        /// <summary>
        /// 读取所有输入IO的状态
        /// </summary>
        /// <returns></returns>
        public new bool[] ReadAllIputIOStatus()
        {
            return _inputs;
        }

        /// <summary>
        /// 设置输出IO状态
        /// </summary>
        /// <param name="index">IO索引</param>
        /// <param name="isEnable">IO状态</param>
        public new void SetOutputIOStatus(byte index, bool isEnable)
        {
            _outputs[index] = isEnable;

        }

        #endregion

        #region 温度控制

        public new double PresetTemp1 { get; set; } = 60;

        private Random random = new Random();

        private double _currenTemp1 = 30;

        public new double CurrentTemp1 
        { 
            get
            {
                _currenTemp1 += random.NextDouble() - 0.5;

                if (_currenTemp1 > PresetTemp1)
                {
                    _currenTemp1 = PresetTemp1;
                }
                else if (_currenTemp1 < 0)
                {
                    _currenTemp1 = 0;
                }
                return _currenTemp1;
            }
        }

        public new double PresetTemp2 { get; set; } = 60;


        private double _currenTemp2 = 30;

        public new double CurrentTemp2
        {
            get
            {
                _currenTemp2 += random.NextDouble() - 0.5;

                if (_currenTemp2 > PresetTemp2)
                {
                    _currenTemp2 = PresetTemp2;
                }
                else if (_currenTemp2 < 0)
                {
                    _currenTemp2 = 0;
                }
                return _currenTemp2;
            }
        }

        #endregion

        #region 系统控制

        /// <summary>
        /// 当前工作状态
        /// </summary>
        public new ushort WorkStatus
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 启动
        /// </summary>
        public new void Start()
        {

        }

        /// <summary>
        /// 停止
        /// </summary>
        public new void Stop()
        {

            
        }

        #endregion

        #endregion

    }
}
