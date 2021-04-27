using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace AGV_Form
{
    public delegate void SerialConnectionHander(bool open);
    class Communication
    {

        public event SerialConnectionHander IsConnected;
        private static SerialPort _serialPort = new SerialPort();
        public static SerialPort SerialPort
        {
            get { return _serialPort; }
            set
            {

                _serialPort = value;
            }

        }

        public static void SendPathData(string fullpath)
        {
            PathInfoSendPacket sendFrame = new PathInfoSendPacket();
            byte[] arrPathFrame = new byte[15];
            //string fullpath = "N,0,N,46,E,50,N,8,W,3,S,11,G,N,0";
            //string fullpath = "N,0,S,11,N,3,W,0,S,42,E,46,G,N,0";
            string[] path = fullpath.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            arrPathFrame[0] = (byte)path[0][0];
            arrPathFrame[1] = Convert.ToByte(path[1]);
            arrPathFrame[2] = (byte)path[0][0];
            arrPathFrame[13] = (byte)path[0][0];
            arrPathFrame[14] = Convert.ToByte(path[14]);
            for (int i = 3; i < 13; i++)
            {
                if (i % 2 == 0) arrPathFrame[i] = (byte)path[i][0];
                else
                {
                    arrPathFrame[i] = Convert.ToByte(path[i]);
                }


            }
            // set frame to send as struct
            // note: send reversed Header and End-of-frame because of Intel processors (in my laptop) use little endian
            sendFrame.Header = new byte[2] { 0xAA, 0xFF };
            sendFrame.FunctionCode = 0xA1;
            sendFrame.AGVID = 0x01;
            sendFrame.PathByteCount = Convert.ToByte(arrPathFrame.Length);
            sendFrame.Path = arrPathFrame;
            //sendFrame.CheckSum = 0xFFFF;
            sendFrame.EndOfFrame = new byte[2] { 0x0A, 0x0D };
            try { Communication.SerialPort.Write(sendFrame.ToArray(), 0, sendFrame.ToArray().Length); }
            catch { };
        }




        /* Path information packet (send):
    * Header		    2 byte  -> 0xFFAA
    * FunctionCode	    1 byte  -> 0xA1
    * AGVID 		    1 byte
    * Path Byte Count  1 byte
    * Path             (dynamic)
    * CheckSum	        2 byte  -> sum of bytes from Header to Path
    * EndOfFrame	    2 byte  -> 0x0D0A
    */
        public struct PathInfoSendPacket
        {
            public byte[] Header;
            public byte FunctionCode;
            public byte AGVID;
            public byte PathByteCount;
            public byte[] Path;
            //public ushort CheckSum;
            public byte[] EndOfFrame;

            // Convert Structs to Byte Arrays
            public byte[] ToArray()
            {
                var stream = new System.IO.MemoryStream();
                var writer = new System.IO.BinaryWriter(stream);

                writer.Write(this.Header);
                writer.Write(this.FunctionCode);
                writer.Write(this.AGVID);
                writer.Write(this.PathByteCount);
                writer.Write(this.Path);
                // writer.Write(this.CheckSum);
                writer.Write(this.EndOfFrame);

                return stream.ToArray();
            }
        }

        public struct SetSpeedPacket
        {
            public byte[] Header;
            public byte FunctionCode;
            public byte AGVID;
            public float Kp;
            public float Ki;
            public float Kd;
            public float Velocity;
            public byte[] CheckSum;
            //  public ushort CheckSum;
            public byte[] EndOfFrame;

            // Convert Structs to Byte Arrays
            public byte[] ToArray()
            {
                var stream = new System.IO.MemoryStream();
                var writer = new System.IO.BinaryWriter(stream);

                writer.Write(this.Header);
                writer.Write(this.FunctionCode);
                writer.Write(this.AGVID);
                writer.Write(this.Kp);
                writer.Write(this.Ki);
                writer.Write(this.Kd);
                writer.Write(this.Velocity);
                writer.Write(this.CheckSum);
                //   writer.Write(this.CheckSum);
                writer.Write(this.EndOfFrame);

                return stream.ToArray();
            }
            public byte[] ToArrayCRC()
            {
                var stream1 = new System.IO.MemoryStream();
                var writer1 = new System.IO.BinaryWriter(stream1);


                writer1.Write(this.FunctionCode);
                writer1.Write(this.AGVID);
                writer1.Write(this.Kp);
                writer1.Write(this.Ki);
                writer1.Write(this.Kd);
                writer1.Write(this.Velocity);
                //   writer.Write(this.CheckSum);

                return stream1.ToArray();
            }
        }
        public struct SetLinePosPacket
        {
            public byte[] Header;
            public byte FunctionCode;
            public byte AGVID;
            public float Kp;
            public float Ki;
            public float Kd;
            public byte[] CheckSum;
            // public float unNecessary;
            public byte[] EndOfFrame;
            // Convert Structs to Byte Arrays
            public byte[] ToArray()
            {
                var stream = new System.IO.MemoryStream();
                var writer = new System.IO.BinaryWriter(stream);

                writer.Write(this.Header);
                writer.Write(this.FunctionCode);
                writer.Write(this.AGVID);
                writer.Write(this.Kp);
                writer.Write(this.Ki);
                writer.Write(this.Kd);
                writer.Write(this.CheckSum);
                //    writer.Write(this.unNecessary);
                //  writer.Write(this.CheckSum);
                writer.Write(this.EndOfFrame);

                return stream.ToArray();
            }
            public byte[] ToArrayCRC()
            {
                var stream1 = new System.IO.MemoryStream();
                var writer1 = new System.IO.BinaryWriter(stream1);


                writer1.Write(this.FunctionCode);
                writer1.Write(this.AGVID);
                writer1.Write(this.Kp);
                writer1.Write(this.Ki);
                writer1.Write(this.Kd);
                //   writer.Write(this.CheckSum);


                return stream1.ToArray();
            }
        }
    }
}
