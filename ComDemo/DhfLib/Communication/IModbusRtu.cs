using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhfLib.Communication
{
    public interface IModbusRtuMaster
    {
        /// <summary>
        /// 写线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="coilAddress">线圈地址</param>
        /// <param name="value">数据</param>
        void WriteCoil(byte slaveAddress, ushort coilAddress, bool value);

        /// <summary>
        /// 写多个线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">开始地址</param>
        /// <param name="data">写入的数据</param>
        void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data);

        /// <summary>
        /// 读取线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="coilAddress">线圈地址</param>
        /// <returns>读取到的结果</returns>
        bool ReadCoil(byte slaveAddress, ushort coilAddress);

        /// <summary>
        /// 读取多个线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">开始地址</param>
        /// <param name="numberOfPoints">数量</param>
        /// <returns>读取到的结果</returns>
        bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        /// 写寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="value">数据</param>
        void WriteRegister(byte slaveAddress, ushort registerAddress, ushort value);

        /// <summary>
        /// 写寄存器(多个数据)
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">开始地址</param>
        /// <param name="data">数据</param>
        void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data);

        /// <summary>
        /// 读寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <returns>读取到的结果</returns>
        ushort ReadRegister(byte slaveAddress, ushort registerAddress);

        /// <summary>
        /// 读寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="numberOfPoints">读取的数量</param>
        /// <param name="values">数据</param>
        ushort[] ReadRegisters(byte slaveAddress, ushort registerAddress, ushort numberOfPoints);

    }
}
