using Dln;
using System;
 

namespace BaseApi
{
    public class Diolan
    {
        protected Device m_device;
        Connection m_connection;
        protected uint m_ID;
        protected uint m_SN;

        public Diolan(string sim)
        {

        }
        public Diolan()
        {
            // Connect to DLN server
            m_connection = Library.Connect("localhost", Connection.DefaultPort);

            // Open device
            if (Device.Count() == 0)
            {
                throw (new SystemException("No DLN-series adapters have been detected."));
            }
            m_device = Device.Open();
            m_ID = m_device.ID;
            m_SN = m_device.SN;
        }
        public Diolan(uint SN)
        { // Connect to DLN server
            m_connection = Library.Connect("localhost", Connection.DefaultPort);

            // Open device
            if (Device.Count() == 0)
            {
                throw (new SystemException("No DLN-series adapters have been detected."));
            }
            m_device = Device.OpenBySn(SN);
            m_ID = m_device.ID;
            m_SN = m_device.SN;
        }
      
        public uint SN
        {
            get
            {
                return m_SN;
            }
        }
        public uint ID
        {
            get
            {
                return m_ID;
            }
        }
        public virtual void Close()
        {
            Library.Disconnect(m_connection);
        }
        public virtual Device DiolanDevice
        {
            get
            {
                return m_device;
            }
        }
    }
}
