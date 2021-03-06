﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DhfLib.Communication;

namespace ThermalControlApplication
{
    public class TempStepData
    {
        /// <summary>
        /// 设置的温度值(单位:度)
        /// </summary>
        public double Temp { get; set; }

        /// <summary>
        /// 保温时间
        /// </summary>
        public int KeepTime { get; set; }

        public TempStepData()
        {

        }

        public TempStepData(double temp, int keepTime)
        {
            Temp = temp;
            KeepTime = keepTime;
        }

    }

    public class McuControl
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

        /// <summary>
        /// 工作状态地址(只读)
        /// </summary>
        private readonly ushort WorkStatusAddress = 0x00;

        /// <summary>
        /// 温度模式
        /// </summary>
        private readonly ushort TempModeAddress = 0x02;

        /// <summary>
        /// 预设温度1地址(读写)
        /// </summary>
        private readonly ushort PresetTemp1Address = 0x04;

        /// <summary>
        /// 当前温度1地址(只读)
        /// </summary>
        private readonly ushort CurrentTemp1Address = 0x06;

        /// <summary>
        /// 预设温度2地址(读写)
        /// </summary>
        private readonly ushort PresetTemp2Address = 0x08;

        /// <summary>
        /// 当前温度2地址(只读)
        /// </summary>
        private readonly ushort CurrentTemp2Address = 0x0A;

        /// <summary>
        /// 多段温度段数
        /// </summary>
        private readonly ushort MultiStepCountAddress = 0x0C;

        /// <summary>
        /// 多段温度温度起始地址(0x10-0x4F)
        /// </summary>
        private readonly ushort MultiStepTempStartAddress = 0x10;

        /// <summary>
        /// 多段温度保温时间起始地址(0x40-0x7F)
        /// </summary>
        private readonly ushort MultiStepTimeStartAddress = 0x40;

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
        public bool[] ReadAllIputIOStatus()
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
        /// 预设温度1
        /// </summary>
        public double PresetTemp1 
        { 
            get
            {
                return ReadDouble(SlaveAddress, PresetTemp1Address, 1000);
            }
            set
            {
                WriteDouble(SlaveAddress, PresetTemp1Address, 1000, value);
            }
        }

        /// <summary>
        /// 当前温度1
        /// </summary>
        public double CurrentTemp1 
        { 
            get
            {
                return ReadDouble(SlaveAddress, CurrentTemp1Address, 1000);
            }
        }

        /// <summary>
        /// 预设温度2
        /// </summary>
        public double PresetTemp2
        {
            get
            {
                return ReadDouble(SlaveAddress, PresetTemp2Address, 1000);
            }
            set
            {
                WriteDouble(SlaveAddress, PresetTemp2Address, 1000, value);
            }
        }

        /// <summary>
        /// 当前温度2
        /// </summary>
        public double CurrentTemp2
        {
            get
            {
                return ReadDouble(SlaveAddress, CurrentTemp2Address, 1000);
            }
        }

        /// <summary>
        /// 设置多段数据
        /// </summary>
        /// <param name="tempSteps"></param>
        public void SetMultiStep(IList<TempStepData> tempSteps)
        {
            //写入段数
            WriteInt(SlaveAddress, MultiStepCountAddress, tempSteps.Count);

            for (int i = 0; i < tempSteps.Count; i++)
            {
                //写入温度值
                WriteDouble(SlaveAddress, (ushort)(MultiStepTempStartAddress + i * 2), 1000, tempSteps[i].Temp);
                
                //写入保温时间
                WriteInt(SlaveAddress, (ushort)(MultiStepTimeStartAddress + i * 2), tempSteps[i].KeepTime);
            }

        }

        #endregion

        #region 系统控制

        /// <summary>
        /// 当前工作状态
        /// </summary>
        public ushort WorkStatus
        {
            get
            {
                return modbusRtu.ReadRegister(SlaveAddress, WorkStatusAddress);
            }
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {

            modbusRtu.WriteCoil(SlaveAddress, RunningControlCoilAddress, true);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {

            modbusRtu.WriteCoil(SlaveAddress, RunningControlCoilAddress, false);
        }

        #endregion

        #endregion

    }
}
