using BaseApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCA6416Api;

namespace TCA6416TesterApp
{
    public partial class Form1 : Form
    {
        byte slaveAddress = 1;
        TCA6416[] tca6416 = new TCA6416[2];
        BaseApi.I2CBase m_i2c;

        public Form1()
        {
            InitializeComponent();
            
        } 

        private void btnReadFromRegister0_Click(object sender, EventArgs e)
        {             
                //tca6416.ReadFromRegister(TCA6416.Command.InputPort0);       //Return type should be byte or byte[]            
        }

        private void btnReadFromRegister1_Click(object sender, EventArgs e)
        {             
              //tca6416.ReadFromRegister(TCA6416.Command.InputPort1);       //Return type should be byte or byte[]            
        }

        private void btnOnOff9_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb1.On = !ledBulb1.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT0, ledBulb1.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_i2c = new I2CMCP2221();
                tca6416[0] = new TCA6416(m_i2c, 0x20); // L
                tca6416[1] = new TCA6416(m_i2c, 0x21); // H

                tca6416[0].SetIODirection(TCA6416.PORT_DIRECTION.OUTPUT, TCA6416.PORTS.PORT0, TCA6416.IO_BITS.ALL_BITS);
                tca6416[0].SetIODirection(TCA6416.PORT_DIRECTION.OUTPUT, TCA6416.PORTS.PORT1, TCA6416.IO_BITS.ALL_BITS);

                tca6416[1].SetIODirection(TCA6416.PORT_DIRECTION.OUTPUT, TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT0 |
                                                            TCA6416.IO_BITS.BIT1 | TCA6416.IO_BITS.BIT2 |
                                                            TCA6416.IO_BITS.BIT4 | TCA6416.IO_BITS.BIT5 |
                                                            TCA6416.IO_BITS.BIT6 | TCA6416.IO_BITS.BIT7);

                tca6416[1].SetIODirection(TCA6416.PORT_DIRECTION.OUTPUT, TCA6416.PORTS.PORT1, TCA6416.IO_BITS.ALL_BITS);
                tca6416[1].SetIODirection(TCA6416.PORT_DIRECTION.INPUT, TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT3);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff1_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb32.On = !ledBulb32.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT0, ledBulb32.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn10_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb2.On = !ledBulb2.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT1, ledBulb1.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSenseCmd_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb3.On = !ledBulb3.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT2, ledBulb1.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnExtInCmd_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb4.On = !ledBulb4.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT3, ledBulb1.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnEventOut_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb8.On = !ledBulb8.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT4, ledBulb8.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void BtnMcuReset_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb6.On = !ledBulb6.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT6, ledBulb6.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnPowerOnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb5.On = !ledBulb5.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT7, ledBulb5.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnBatC1_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb16.On = !ledBulb16.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT0, ledBulb16.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnBatC2_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb15.On = !ledBulb15.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT1, ledBulb15.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnBatC3_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb14.On = !ledBulb14.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT2, ledBulb14.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnBatC4_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb13.On = !ledBulb13.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT3, ledBulb13.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnChargeCmd1_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb12.On = !ledBulb12.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT4, ledBulb12.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnChargeCmd2_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb11.On = !ledBulb11.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT5, ledBulb11.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnChargeCmd3_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb10.On = !ledBulb10.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT6, ledBulb10.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnChargeCmd4_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb9.On = !ledBulb9.On;
                tca6416[1].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT7, ledBulb9.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff2_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb31.On = !ledBulb31.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT1, ledBulb31.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff3_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb30.On = !ledBulb30.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT2, ledBulb30.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff4_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb29.On = !ledBulb29.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT3, ledBulb29.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff5_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb28.On = !ledBulb28.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT4, ledBulb28.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff6_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb27.On = !ledBulb27.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT5, ledBulb27.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff7_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb26.On = !ledBulb26.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT6, ledBulb26.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnOnOff8_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb25.On = !ledBulb25.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT0, TCA6416.IO_BITS.BIT7, ledBulb25.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn1_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb24.On = !ledBulb24.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT0, ledBulb24.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn2_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb23.On = !ledBulb23.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT1, ledBulb21.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn3_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb22.On = !ledBulb22.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT2, ledBulb22.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn4_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb21.On = !ledBulb21.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT3, ledBulb21.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb20.On = !ledBulb20.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT4, ledBulb20.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn6_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb19.On = !ledBulb19.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT5, ledBulb19.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLoadOn7_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb18.On = !ledBulb18.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT6, ledBulb18.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnLoadOn8_Click(object sender, EventArgs e)
        {
            try
            {
                ledBulb17.On = !ledBulb17.On;
                tca6416[0].WriteIO(TCA6416.PORTS.PORT1, TCA6416.IO_BITS.BIT7, ledBulb17.On);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
