using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalContainerApplication.Chart
{
    public class MeasureModel
    {
        /// <summary>
        /// 时间(X轴)
        /// </summary>
        public DateTime DateTime { get; set; }
        
        /// <summary>
        /// 显示值(Y值)
        /// </summary>
        public double Value { get; set; }
    }
}
