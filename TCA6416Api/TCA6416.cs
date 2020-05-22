using BaseApi;
using BitField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCA6416Api
{
    public class TCA6416
    {
        [BitFieldNumberOfBitsAttribute(8)]
        public struct CommandRegister : IBitField
        {
            [BitFieldInfo(0, 1)]
            public byte B0 { get; set; }
            [BitFieldInfo(1, 1)]
            public byte B1 { get; set; }
            [BitFieldInfo(2, 1)]
            public byte B2 { get; set; }
            [BitFieldInfo(3, 2)]
            public byte B3 { get; set; }
            [BitFieldInfo(4, 2)]
            public byte B4 { get; set; }
            [BitFieldInfo(5, 1)]
            public byte B5 { get; set; }
            [BitFieldInfo(6, 1)]
            public byte B6 { get; set; }
            [BitFieldInfo(7, 1)]
            public byte B7 { get; set; }

        }

        public enum PORTS
        {
            PORT0,
            PORT1
        }

        public enum IO_BITS
        {
            BIT0 = 1,
            BIT1 = 2,
            BIT2 = 4,
            BIT3 = 0x8,
            BIT4 = 0x10,
            BIT5 = 0x20,
            BIT6 = 0x40,
            BIT7 = 0x80,
            ALL_BITS = 0xFF
        }

        public enum PORT_DIRECTION
        {
            OUTPUT,
            INPUT
        }

        public enum Command
        {
            InputPort0,
            InputPort1,
            OutputPort0,
            OutputPort1,
            PolarityInversion0,
            PolarityInversion1,
            Configuration0,
            Configuration1
        };

        CommandRegister m_cmdReg = new CommandRegister();

        BaseApi.I2CBase m_i2c;
        byte m_slaveAddress = 0;

        public TCA6416(byte slaveAddress)
        {
           
            m_i2c = new DiolanI2CController(slaveAddress);
        }

        public TCA6416(BaseApi.I2CBase i2c, byte slaveAddress)
        {
            m_slaveAddress = slaveAddress;
            m_i2c = i2c;
        }

        private void SetCommand(Command command)
        {
            m_cmdReg.B7 = 0;
            m_cmdReg.B6 = 0;
            m_cmdReg.B5 = 0;
            m_cmdReg.B4 = 0;
            m_cmdReg.B3 = 0;

            switch (command)
            {
                case Command.InputPort0:
                    m_cmdReg.B2 = 0;
                    m_cmdReg.B1 = 0;
                    m_cmdReg.B0 = 0;
                    break;
                case Command.InputPort1:
                    m_cmdReg.B2 = 0;
                    m_cmdReg.B1 = 0;
                    m_cmdReg.B0 = 1;
                    break;
                case Command.OutputPort0:
                    m_cmdReg.B2 = 0;
                    m_cmdReg.B1 = 1;
                    m_cmdReg.B0 = 0;
                    break;
                case Command.OutputPort1:
                    m_cmdReg.B2 = 0;
                    m_cmdReg.B1 = 1;
                    m_cmdReg.B0 = 1;
                    break;
                case Command.PolarityInversion0:
                    m_cmdReg.B2 = 1;
                    m_cmdReg.B1 = 0;
                    m_cmdReg.B0 = 0;
                    break;
                case Command.PolarityInversion1:
                    m_cmdReg.B2 = 1;
                    m_cmdReg.B1 = 0;
                    m_cmdReg.B0 = 1;
                    break;
                case Command.Configuration0:
                    m_cmdReg.B2 = 1;
                    m_cmdReg.B1 = 1;
                    m_cmdReg.B0 = 0;
                    break;
                case Command.Configuration1:
                    m_cmdReg.B2 = 1;
                    m_cmdReg.B1 = 1;
                    m_cmdReg.B0 = 1;
                    break;
                default:
                    break;
            }
        }

        private void Write(Command command, IO_BITS dataPort)
        {
            //Populating the commands bits
            SetCommand(command);

            //Format: 0:Address, 1:Command, 2:Port Data
            byte[] data = { 0, 0 };
            data[0] = m_cmdReg.ToUInt8();
            data[1] &= Convert.ToByte(dataPort);

            m_i2c.Write(m_slaveAddress, data);
        }

        private void Write(Command command, byte dataPort)
        {
            //Populating the commands bits
            SetCommand(command);

            //Format: 0:Address, 1:Command, 2:Port Data
            byte[] data = { 0, 0 };
            data[0] = m_cmdReg.ToUInt8();
            data[1] = dataPort;

            m_i2c.Write(m_slaveAddress, data);
        }

        private void Write(Command command, bool dataPort)
        {
            //Populating the commands bits
            SetCommand(command);

            //Format: 0:Address, 1:Command, 2:Port Data
            byte[] data = { 0, 0 };
            data[0] = m_cmdReg.ToUInt8();
            data[1] = Convert.ToByte(dataPort);

            m_i2c.Write(m_slaveAddress, data);
        }

        private void Write(Command command, byte dataPort0, byte dataPort1)
        {
            //Populating the commands bits
            SetCommand(command);

            //Format: 0:Address, 1:Command, 2:Port0 Data, 3:Port1 Data
            byte[] data = { 0, 0, 0 };
            data[0] = m_cmdReg.ToUInt8();
            data[1] = dataPort0;
            data[2] = dataPort1;

            m_i2c.Write(m_slaveAddress, data);
        }

        public void ReadFromRegister(Command command)
        {
            //Populating the commands bits
            SetCommand(command);

            //Dummy data is sent for clock pulse
            byte dataByte0 = 0x00;
            byte dataByte1 = 0x00;

            //Format: 0:Address, 1:Command, 2:Data Byte, 3:Data Byte
            byte[] data = { 0, 0, 0 };
            data[0] = m_cmdReg.ToUInt8();
            data[1] = dataByte0;
            data[2] = dataByte1;

            m_i2c.Read(m_slaveAddress, data);
        }

        private void ReadFromRegister(Command command, byte dataByte0, byte dataByte1)
        {
            //Populating the commands bits
            SetCommand(command);

            //Format: 0:Address, 1:Command, 2:Data Byte, 3:Data Byte
            byte[] data = { 0, 0, 0 };
            data[0] = m_cmdReg.ToUInt8();
            data[1] = dataByte0;
            data[2] = dataByte1;

            m_i2c.Read(m_slaveAddress, data);
        }

        private void ReadInputPortRegister(byte[] data)
        {
            //Fills the desired length with dummy value
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0x00;
            }

            //Format: 0:Address, 1..n:Data Bytes
            m_i2c.Read(m_slaveAddress, data);
        }

        public void SetPortDirection(PORT_DIRECTION dir, PORTS port)
        {
            switch (port)
            {
                case PORTS.PORT0:
                    switch (dir)
                    {
                        case PORT_DIRECTION.OUTPUT:
                            SetCommand(Command.OutputPort0);
                            break;
                        case PORT_DIRECTION.INPUT:
                            SetCommand(Command.InputPort0);
                            break;
                        default:
                            break;
                    }
                    break;
                case PORTS.PORT1:
                    switch (dir)
                    {
                        case PORT_DIRECTION.OUTPUT:
                            SetCommand(Command.OutputPort1);
                            break;
                        case PORT_DIRECTION.INPUT:
                            SetCommand(Command.InputPort1);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetIODirection(PORT_DIRECTION dir, PORTS port, IO_BITS bits)
        {
            switch (port)
            {
                case PORTS.PORT0:
                    switch (dir)
                    {
                        case PORT_DIRECTION.OUTPUT:
                            Write(Command.OutputPort0, bits);
                            break;
                        case PORT_DIRECTION.INPUT:
                            Write(Command.InputPort0, bits);
                            break;
                        default:
                            break;
                    }
                    break;
                case PORTS.PORT1:
                    switch (dir)
                    {
                        case PORT_DIRECTION.OUTPUT:
                            Write(Command.OutputPort1, bits);
                            break;
                        case PORT_DIRECTION.INPUT:
                            Write(Command.InputPort1, bits);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

         
        byte[] m_portVal = new byte[2];

        public void WriteIO(PORTS port , IO_BITS b, bool val)
        {
          
            switch (port)
            {
                case PORTS.PORT0:
                {
                    if (val == true)
                       m_portVal[0] |= (byte)b;
                    else
                        m_portVal[0] &= (byte)(~(byte)b);
                    Write(Command.OutputPort0, m_portVal[0]);
                }
                break;
                case PORTS.PORT1:
                {
                    if (val == true)
                        m_portVal[1] |= (byte)b;
                    else
                        m_portVal[1] &= (byte)(~(byte)b);
                    Write(Command.OutputPort1, m_portVal[1]);
                }
                break;
                default:
                    break;
            }
        }
        public void SetIO(PORTS port, IO_BITS b)
        {
            switch (port)
            {
                case PORTS.PORT0:
                {                    
                    Write(Command.OutputPort0, b);
                }
                break;
                case PORTS.PORT1:
                    Write(Command.OutputPort1, b);
                    break;
                default:
                    break;
            }
        }

        public void WriteIO(PORTS port, bool value)
        {
            switch (port)
            {
                case PORTS.PORT0:
                {
                    Write(Command.OutputPort0, value);
                }
                break;
                case PORTS.PORT1:
                    Write(Command.OutputPort1, value);
                    break;
                default:
                    break;
            }
        }

        public void SetIO(PORTS port, byte data)
        {
            switch (port)
            {
                case PORTS.PORT0:
                    Write(Command.OutputPort0, data);
                    break;
                case PORTS.PORT1:
                    Write(Command.OutputPort1, data);
                    break;
                default:
                    break;
            }
        }
    }
}
