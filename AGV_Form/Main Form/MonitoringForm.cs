using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGV_Form
{
    public partial class MonitoringForm : Form
    {
        public MonitoringForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Communication.SetLinePosPacket sendFrame = new Communication.SetLinePosPacket();

            sendFrame.Header = new byte[2] { 0xAA, 0xFF };
            sendFrame.FunctionCode = 0xAD;
            sendFrame.AGVID = 0x01;
            sendFrame.Kp = Convert.ToSingle("0.5");
            sendFrame.Ki = Convert.ToSingle("0.0005");
            sendFrame.Kd = Convert.ToSingle("0.05");
            sendFrame.CheckSum = new byte[2];
            //  sendFrame.unNecessary = 0;

            // calculate check sum
            //CRC16_Calculator(sendFrame.ToArrayCRC(), sendFrame.CheckSum);

            //sendFrame.CheckSum = crc;
            sendFrame.EndOfFrame = new byte[2] { 0x0A, 0x0D };
            if (!Communication.SerialPort.IsOpen) return;
            try { Communication.SerialPort.Write(sendFrame.ToArray(), 0, sendFrame.ToArray().Length); }
            catch { };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string fullpath = "N,0,N,46,E,50,N,8,W,3,S,11,G,N,0";
            string fullpath = "N,0,S,25,N,4,W,0,S,21,E,24,G,C,0";
            Communication.SendPathData(fullpath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Communication.SetSpeedPacket sendFrame = new Communication.SetSpeedPacket();

            sendFrame.Header = new byte[2] { 0xAA, 0xFF };
            sendFrame.CheckSum = new byte[2];
            sendFrame.FunctionCode = 0xAC;
            sendFrame.AGVID = 0x01;
            sendFrame.Kp = Convert.ToSingle("2.0");
            sendFrame.Ki = Convert.ToSingle("2.0");
            sendFrame.Kd = Convert.ToSingle("0.015");
            sendFrame.Velocity = Convert.ToSingle("15.0");
            // calculate check sum
            //sCRC16_Calculator(sendFrame.ToArrayCRC(), sendFrame.CheckSum);
            //   sendFrame.CheckSum = crc;           
            sendFrame.EndOfFrame = new byte[2] { 0x0A, 0x0D };
            if (!Communication.SerialPort.IsOpen) return;
            try { Communication.SerialPort.Write(sendFrame.ToArray(), 0, sendFrame.ToArray().Length); }
            catch { };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fullpath = "N,0,N,46,E,50,N,8,W,4,S,25,G,N,0";
            //string fullpath = "N,0,S,11,N,3,W,0,S,42,E,46,G,N,0";
            Communication.SendPathData(fullpath);
        }
    }
}
