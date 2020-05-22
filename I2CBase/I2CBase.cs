using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApi
{
    public abstract class I2CBase
    {

        public abstract void Write(byte[] data);
        public abstract void Write(byte slaveAddress, byte[] data);
        public abstract void Write(byte data);
        public abstract void Write(byte slaveAddress, byte data);
        public abstract void Write(int memoryAddressLength, int memoryAddress, byte[] data);
        public abstract void Write(int memoryAddressLength, int memoryAddress, byte[] data, int dataSize);
        public abstract void Write(int memoryAddressLength, int memoryAddress, byte[] data, int dataOffset, int dataSize);
        public abstract byte Read();
        public abstract byte Read(byte slaveAddress);
        public abstract void Read(byte[] data);
        public abstract void Read(byte slaveAddress, byte[] data);
        public abstract void Read(byte[] data, int index, int size);
        public abstract void Read(byte slaveAddress, byte[] data, int index, int size);
        public abstract void Close();

    }
}
