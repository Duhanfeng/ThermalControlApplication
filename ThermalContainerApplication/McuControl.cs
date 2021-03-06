﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DhfLib.Communication;

namespace ThermalContainerApplication
{
    public class TempStepData
    {
        /// <summary>
        /// 设置的温度值(单位:度)
        /// </summary>
        public double Temp { get; set; }

        /// <summary>
        /// 保温时间(单位:分钟)
        /// </summary>
        public double KeepWarmTime { get; set; }

        public TempStepData()
        {

        }

        public TempStepData(double temp, double keepWarmTime)
        {
            Temp = temp;
            KeepWarmTime = keepWarmTime;
        }

    }

    /// <summary>
    /// 工作状态
    /// </summary>
    public enum EWorkStatus
    {
        [Description("未连接")]
        Unconnect = -1,

        [Description("就绪")]
        Ready = 0,

        [Description("调整温度中")]
        Running,

        [Description("保温中")]
        KeepWarm,

        [Description("异常")]
        Error,

    }

    /// <summary>
    /// 单片机控制接口
    /// </summary>
    public interface IMcuControl
    {
        #region Modbus

        /// <summary>
        /// 串口
        /// </summary>
        string SerialPortName { get; set; }

        /// <summary>
        /// 从机地址
        /// </summary>
        byte SlaveAddress { get; set; }

        #endregion

        #region 设备控制

        #region IO

        /// <summary>
        /// 读取所有输出IO的状态
        /// </summary>
        /// <returns></returns>
        bool[] ReadAllOutputIOStatus();

        /// <summary>
        /// 读取所有输入IO的状态
        /// </summary>
        /// <returns></returns>
        bool[] ReadAllInputIOStatus();

        /// <summary>
        /// 设置输出IO状态
        /// </summary>
        /// <param name="index">IO索引</param>
        /// <param name="isEnable">IO状态</param>
        void SetOutputIOStatus(byte index, bool isEnable);

        #endregion

        #region 温度控制

        /// <summary>
        /// 温度模式(0-单段 1-多段)
        /// </summary>
        ushort TempMode { get; set; }

        /// <summary>
        /// 目标温度(摄氏度)
        /// </summary>
        double TargetTemp { get; }

        /// <summary>
        /// 目标保温时间(分钟)
        /// </summary>
        double TargetKeepWarmTime { get; }
        
        /// <summary>
        /// 当前温度
        /// </summary>
        double ActualTemp { get;}

        #region 单段温度

        /// <summary>
        /// 单段温度
        /// </summary>
        double SingleStepTemp { get; set; }

        #endregion

        #region 多段温度

        /// <summary>
        /// 多段模式当前段
        /// </summary>
        ushort CurrentStep { get; }

        /// <summary>
        /// 多段模式段数
        /// </summary>
        ushort MultiStepCount { get; set; }

        /// <summary>
        /// 设置多段数据
        /// </summary>
        /// <param name="tempSteps"></param>
        void SetMultiStep(IList<TempStepData> tempSteps);

        #endregion

        #endregion

        #region 系统控制

        /// <summary>
        /// 当前工作状态
        /// </summary>
        EWorkStatus WorkStatus { get; }

        /// <summary>
        /// 启动标志
        /// </summary>
        bool IsStart { get; set; }

        #endregion

        #endregion
    }

    public class McuControl : IMcuControl
    {
        #region Modbus

        /// <summary>
        /// modbus接口
        /// </summary>
        private ModbusRtuMaster modbusRtu = new ModbusRtuMaster();

        /// <summary>
        /// 串口
        /// </summary>
        public string SerialPortName
        {
            get
            {
                return modbusRtu.SerialPortName;
            }
            set
            {
                modbusRtu.SerialPortName = value;
            }
        }

        /// <summary>
        /// 从机地址
        /// </summary>
        public byte SlaveAddress { get; set; } = 0x01;

        #region 地址定义

        #region 线圈地址

        /// <summary>
        /// 输出IO线圈地址(读写)
        /// </summary>
        private readonly ushort OutputCoilAddress = 0x00;

        /// <summary>
        /// 输入IO线圈地址(只读)
        /// </summary>
        private readonly ushort InputCoilAddress = 0x10;

        /// <summary>
        /// 运行控制线圈地址(读写)
        /// </summary>
        private readonly ushort RunningControlCoilAddress = 0x20;

        #endregion

        #region 寄存器地址

        /// <summary>
        /// 工作状态地址(只读)
        /// </summary>
        private readonly ushort WorkStatusAddress = 0x00;

        /// <summary>
        /// 温度模式
        /// </summary>
        private readonly ushort TempModeAddress = 0x02;

        /// <summary>
        /// 目标温度地址(只读)
        /// </summary>
        private readonly ushort TargetTempAddress = 0x04;

        /// <summary>
        /// 目标保温时间地址(只读)
        /// </summary>
        private readonly ushort TargetKeepWarmTimeAddress = 0x06;

        /// <summary>
        /// 实际当前温度地址(只读)
        /// </summary>
        private readonly ushort ActualTempAddress = 0x08;

        /// <summary>
        /// 单段温度地址
        /// </summary>
        private readonly ushort SingleStepTempAddress = 0x0A;

        /// <summary>
        /// 当前段数
        /// </summary>
        private readonly ushort CurrentStepAddress = 0x0C;

        /// <summary>
        /// 多段温度段数
        /// </summary>
        private readonly ushort MultiStepCountAddress = 0x0E;

        /// <summary>
        /// 多段温度温度起始地址(0x10-0x4F)
        /// </summary>
        private readonly ushort MultiStepTempStartAddress = 0x10;

        /// <summary>
        /// 多段温度保温时间起始地址(0x50-0x8F)
        /// </summary>
        private readonly ushort MultiStepTimeStartAddress = 0x40;

        #endregion

        #endregion

        #endregion

        #region 设备控制

        /// <summary>
        /// 写入整型数据
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="value">写入的数值</param>
        private void WriteInt(byte slaveAddress, ushort registerAddress, int value)
        {
            ushort[] data = new ushort[2];
            data[0] = (ushort)(value & 0xFFFF);
            data[1] = (ushort)(value >> 16);

            //发送数据
            modbusRtu.WriteMultipleRegisters(slaveAddress, registerAddress, data);
        }

        /// <summary>
        /// 读取整型数据
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <returns>读取到的结果</returns>
        private int ReadInt(byte slaveAddress, ushort registerAddress)
        {
            var data = modbusRtu.ReadRegisters(slaveAddress, registerAddress, 2);
            if (data.Length == 2)
            {
                return (data[0] | (data[1] << 16));
            }
            return -1;
        }

        /// <summary>
        /// 写入浮点数
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="score">分数</param>
        /// <param name="value">写入的数值</param>
        private void WriteDouble(byte slaveAddress, ushort registerAddress, double score, double value)
        {
            //将数据放大1000倍,转为整型数据
            int tempValue = (int)(value * score);

            //发送数据
            WriteInt(slaveAddress, registerAddress, tempValue);
        }

        /// <summary>
        /// 读取浮点数
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="score">分数</param>
        /// <returns>读取到的结果</returns>
        private double ReadDouble(byte slaveAddress, ushort registerAddress, double score)
        {
            var data = ReadInt(slaveAddress, registerAddress);
            
            return data / score;
        }

        #region IO

        /// <summary>
        /// 读取所有输出IO的状态
        /// </summary>
        /// <returns></returns>
        public bool[] ReadAllOutputIOStatus()
        {
            return modbusRtu.ReadCoils(SlaveAddress, OutputCoilAddress, 5);
        }

        /// <summary>
        /// 读取所有输入IO的状态
        /// </summary>
        /// <returns></returns>
        public bool[] ReadAllInputIOStatus()
        {
            return modbusRtu.ReadCoils(SlaveAddress, InputCoilAddress, 5);
        }

        /// <summary>
        /// 设置输出IO状态
        /// </summary>
        /// <param name="index">IO索引</param>
        /// <param name="isEnable">IO状态</param>
        public void SetOutputIOStatus(byte index, bool isEnable)
        {
            modbusRtu.WriteCoil(SlaveAddress, (ushort)(OutputCoilAddress + index), isEnable);
        }

        #endregion

        #region 温度控制

        /// <summary>
        /// 温度模式(0-单段 1-多段)
        /// </summary>
        public ushort TempMode
        {
            get
            {
                return modbusRtu.ReadRegister(SlaveAddress, TempModeAddress);
            }
            set
            {
                modbusRtu.WriteRegister(SlaveAddress, TempModeAddress, value);
            }
        }

        /// <summary>
        /// 目标温度(摄氏度)
        /// </summary>
        public double TargetTemp
        {
            get
            {
                return ReadDouble(SlaveAddress, TargetTempAddress, 1000);
            }
        }

        /// <summary>
        /// 目标保温时间(分钟)
        /// </summary>
        public double TargetKeepWarmTime
        {
            get
            {
                return ReadDouble(SlaveAddress, TargetKeepWarmTimeAddress, 1000);
            }
        }

        /// <summary>
        /// 当前温度
        /// </summary>
        public double ActualTemp
        {
            get
            {
                return ReadDouble(SlaveAddress, ActualTempAddress, 1000);
            }
        }

        #region 单段温度

        /// <summary>
        /// 单段温度(摄氏度)
        /// </summary>
        public double SingleStepTemp
        {
            get
            {
                return ReadDouble(SlaveAddress, SingleStepTempAddress, 1000);
            }
            set
            {
                WriteDouble(SlaveAddress, SingleStepTempAddress, 1000, value);
            }
        }

        #endregion

        #region 多段温度

        /// <summary>
        /// 多段模式当前段
        /// </summary>
        public ushort CurrentStep
        {
            get
            {
                return modbusRtu.ReadRegister(SlaveAddress, CurrentStepAddress);
            }
        }

        /// <summary>
        /// 多段模式段数
        /// </summary>
        public ushort MultiStepCount
        {
            get
            {
                return modbusRtu.ReadRegister(SlaveAddress, MultiStepCountAddress);
            }
            set
            {
                modbusRtu.WriteRegister(SlaveAddress, MultiStepCountAddress, value);
            }
        }

        /// <summary>
        /// 设置多段数据
        /// </summary>
        /// <param name="tempSteps"></param>
        public void SetMultiStep(IList<TempStepData> tempSteps)
        {
            //写入段数
            MultiStepCount = (ushort)tempSteps.Count;

            for (int i = 0; i < tempSteps.Count; i++)
            {
                //写入温度值
                WriteDouble(SlaveAddress, (ushort)(MultiStepTempStartAddress + i * 2), 1000, tempSteps[i].Temp);

                //写入保温时间
                WriteDouble(SlaveAddress, (ushort)(MultiStepTimeStartAddress + i * 2), 1000, tempSteps[i].KeepWarmTime);
            }

        }

        #endregion

        #endregion

        #region 系统控制

        /// <summary>
        /// 当前工作状态
        /// </summary>
        public EWorkStatus WorkStatus
        {
            get
            {
                var value = modbusRtu.ReadRegister(SlaveAddress, WorkStatusAddress);
                return (EWorkStatus)Enum.Parse(typeof(EWorkStatus), value.ToString());
            }
        }

        /// <summary>
        /// 启动标志
        /// </summary>
        public bool IsStart 
        { 
            get
            {
                return modbusRtu.ReadCoil(SlaveAddress, RunningControlCoilAddress);
            }
            set
            {
                modbusRtu.WriteCoil(SlaveAddress, RunningControlCoilAddress, value);
            }
        }

        #endregion

        #endregion
    }
}
