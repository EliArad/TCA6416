using Dln;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseApi
{
    public class DiolanI2CController : I2CBase,  IDisposable
    {

        
        Device m_device;
        Dln.I2cMaster.Port m_i2c;

        byte m_slaveAddress;
        protected bool m_connected = false;
        protected bool m_dlnError = false;

        // some fields that require cleanup
        private bool disposed = false; // to detect redundant calls

        Diolan m_dln;

        public DiolanI2CController()
        {
            
            m_dln = new Diolan();
            m_device = m_dln.DiolanDevice;
            Connect(0);
        }

        public DiolanI2CController(byte slaveAddress)
        {
            m_slaveAddress = slaveAddress;
            m_dln = new Diolan();
            m_device = m_dln.DiolanDevice;
            Connect(0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                }

                // shared cleanup logic
                disposed = true;
            }
        }

        ~DiolanI2CController()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Connect(int i2cPort)
        {
            lock (this)
            {
                try
                {
                    
                    int portCount = m_device.I2cMaster.Ports.Count;
                    if (portCount == 0)
                    {
                        throw (new SystemException("Current DLN-series adapter doesn't support I2C Master interface."));
                    }
                    m_i2c = m_device.I2cMaster.Ports[i2cPort];

                    //i2c.MaxReplyCount = 1;
                    Console.WriteLine("Device ID: " + m_device.ID);

 
                    Console.WriteLine("Frequency: " + m_i2c.Frequency);
                    m_i2c.Enabled = true;
                    m_connected = true;

                }
                catch (Exception err)
                {
                    throw (new SystemException(err.Message));
                }
            }
        }
         
        public  string GetVersion()
        {
            return Library.Version.ToString();
        }
        public override void Write(byte[] data)
        {
            lock (this)
            {
                try
                {                    
                    if (m_connected == false)
                        throw (new SystemException("Not connected"));
                    m_i2c.Write(m_slaveAddress, data);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Write error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Write(byte slaveAddress, byte[] data)
        {
            lock (this)
            {
                try
                {
                    if (m_connected == false)
                        throw (new SystemException("Not connected"));
                    m_i2c.Write(slaveAddress, data);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Write error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Write(byte sla, byte data)
        {
            lock (this)
            {
                try
                {
                    if (m_connected == false)
                        throw (new SystemException("Not connected"));
                    byte[] d = { data };
                    m_i2c.Write(sla, d);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Write error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Write(byte data)
        {
            lock (this)
            {
                try
                {
                    if (m_connected == false)
                        throw (new SystemException("Not connected"));
                    byte[] d = { data };
                    m_i2c.Write(m_slaveAddress, d);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Write error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Write(int memoryAddressLength, int memoryAddress, byte[] data)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
            }
        }
        public override void Write(int memoryAddressLength, int memoryAddress, byte[] data, int dataSize)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    m_i2c.Write(m_slaveAddress, 0, 0, data, dataSize);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Write error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }
        public override void Write(int memoryAddressLength, int memoryAddress, byte[] data, int dataOffset, int dataSize)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    m_i2c.Write(m_slaveAddress, 0, 0, data, dataOffset, dataSize);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Write error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override byte Read()
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    byte[] data = { 0 };
                    m_i2c.Read(m_slaveAddress, data);
                    m_dlnError = false;
                    return data[0];
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override byte Read(byte slaveAddress)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    byte[] data = { 0 };
                    m_i2c.Read(slaveAddress, data);
                    m_dlnError = false;
                    return data[0];
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    throw (new SystemException(err.Message));
                }
            }
        }
        
        public override void Read(byte[] data)
        {
            lock (this)
            {
                if (m_connected == false)
                    return;
                try
                {
                    m_i2c.Read(m_slaveAddress, data);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Read(byte slaveAddress , byte[] data)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    m_i2c.Read(slaveAddress, data);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Read(byte[] data, int index, int size)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    m_i2c.Read(m_slaveAddress, 0, 0, data, 0, size);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Read error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public override void Read(byte slaveAddress , byte[] data, int index, int size)
        {
            lock (this)
            {
                if (m_connected == false)
                    throw (new SystemException("Not connected"));
                try
                {
                    m_i2c.Read(slaveAddress, 0, 0, data, 0, size);
                    m_dlnError = false;
                }
                catch (Exception err)
                {
                    m_dlnError = true;
                    string str = string.Format("Diolan Read error at {0}", DateTime.Now);
                    throw (new SystemException(err.Message));
                }
            }
        }

        public bool GetError()
        {
            return m_dlnError;
        }
        public override void Close()
        {
            lock (this)
            {
                try
                {
                    // Disconnect from DLN server
                    Library.DisconnectAll();
                    m_connected = false;

                }
                catch (Exception err)
                {
                    throw (new SystemException(err.Message));
                }
            }
        }
    }
}
