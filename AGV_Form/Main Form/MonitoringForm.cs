using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;

namespace AGV_Form
{
    public partial class MonitoringForm : Form
    {
        public MonitoringForm()
        {
            InitializeComponent();
            

            if (Display.Mode == "Real Time")
            {
                InitZedGraph();
                
            }
           
            
        }
        private int tickStart;
        public static int selectedAGVID;
        private static int SelectedAGV = 0;
        private void MonitoringForm_Load(object sender, EventArgs e)
        {
            cbbAGV.Items.Clear();
            foreach (AGV agv in AGV.ListAGV)
            {
                cbbAGV.Items.Add("AGV#" + agv.ID.ToString());
            }
            if (AGV.ListAGV.Count > 0)
            {
                cbbAGV.Text = "AGV#" + AGV.ListAGV[0].ID.ToString();
                if(SelectedAGV==0)
                SelectedAGV = AGV.ListAGV[0].ID;
            }
        }
        #region Init Zed Graph Velocity And Line Track
        private void InitZedGraph()
        {
            #region Init Velocity graph
            GraphPane velocityPane = zedGraphVelocity.GraphPane;

            RollingPointPairList velocityPointBuffer = new RollingPointPairList(10000);
            LineItem velocityCurve = velocityPane.AddCurve("Value", velocityPointBuffer, Color.Red, SymbolType.None);

            RollingPointPairList setPointBuffer = new RollingPointPairList(10000);
            LineItem setPointCurve = velocityPane.AddCurve("Setpoint", setPointBuffer, Color.Blue, SymbolType.None);

            // Add titles
            velocityPane.Title.Text = "Velocity of AGV";
            velocityPane.Title.FontSpec.FontColor = Color.Navy;
            velocityPane.XAxis.Title.Text = "t (s)";
            velocityPane.XAxis.Title.FontSpec.FontColor = Color.Navy;
            velocityPane.XAxis.Title.FontSpec.IsBold = false;
            velocityPane.YAxis.Title.Text = "velocity (cm/s)";
            velocityPane.YAxis.Title.FontSpec.FontColor = Color.Navy;
            velocityPane.YAxis.Title.FontSpec.IsBold = false;

            // Add gridlines to the plot, and make them gray
            velocityPane.XAxis.MajorGrid.IsVisible = true;
            velocityPane.YAxis.MajorGrid.IsVisible = true;
            velocityPane.XAxis.MajorGrid.Color = Color.Gray;
            velocityPane.YAxis.MajorGrid.Color = Color.Gray;

            // Set scale of axis
            velocityPane.XAxis.Scale.Min = 0;
            velocityPane.XAxis.Scale.Max = 30;
            velocityPane.XAxis.Scale.MinorStep = 1;
            velocityPane.XAxis.Scale.MajorStep = 5;

            // Move the legend location
            velocityPane.Legend.Position = LegendPos.InsideTopRight;
            velocityPane.Legend.Border.IsVisible = false;
            velocityPane.Legend.Fill.IsVisible = false;
            velocityPane.Legend.IsHStack = false;

            // Make both curves thicker
            velocityCurve.Line.Width = 2.0F;
            setPointCurve.Line.Width = 2.0F;

            //// Fill the area under the curves
            //velocityCurve.Line.Fill = new Fill(Color.White, Color.FromArgb(255, 175, 175), -90F);
            //setPointCurve.Line.Fill = new Fill(Color.White, Color.FromArgb(255, 175, 175), -90F);

            // Fill the Axis and Pane backgrounds
            velocityPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), -45F);
            velocityPane.Fill = new Fill(Color.WhiteSmoke);
            velocityPane.Border.IsVisible = false;

            // Tell ZedGraph to refigure the axes since the data have changed
            zedGraphVelocity.AxisChange();
            #endregion

            #region Init Line Tracking graph
            GraphPane linetrackPane = zedGraphLineTrack.GraphPane;

            RollingPointPairList linetrackPointBuffer = new RollingPointPairList(10000);
            LineItem linetrackCurve = linetrackPane.AddCurve("Error", linetrackPointBuffer, Color.Red, SymbolType.None);
            RollingPointPairList lineStandardPointBuffer = new RollingPointPairList(10000);
            LineItem lineStandardCurve = linetrackPane.AddCurve("Lsine", lineStandardPointBuffer, Color.Blue, SymbolType.None);

            // Add titles
            linetrackPane.Title.Text = "Error of line tracking";
            linetrackPane.Title.FontSpec.FontColor = Color.Navy;
            linetrackPane.XAxis.Title.Text = "t (s)";
            linetrackPane.XAxis.Title.FontSpec.FontColor = Color.Navy;
            linetrackPane.XAxis.Title.FontSpec.IsBold = false;
            linetrackPane.YAxis.Title.Text = "Error";
            linetrackPane.YAxis.Title.FontSpec.FontColor = Color.Navy;
            linetrackPane.YAxis.Title.FontSpec.IsBold = false;

            // Add gridlines to the plot, and make them gray
            linetrackPane.XAxis.MajorGrid.IsVisible = true;
            linetrackPane.YAxis.MajorGrid.IsVisible = true;
            linetrackPane.XAxis.MajorGrid.Color = Color.Gray;
            linetrackPane.YAxis.MajorGrid.Color = Color.Gray;

            // Set scale of axis
            linetrackPane.XAxis.Scale.Min = 0;
            linetrackPane.XAxis.Scale.Max = 30;
            linetrackPane.XAxis.Scale.MinorStep = 1;
            linetrackPane.XAxis.Scale.MajorStep = 5;

            // Move the legend location
            linetrackPane.Legend.Position = LegendPos.InsideTopRight;
            linetrackPane.Legend.Border.IsVisible = false;
            linetrackPane.Legend.Fill.IsVisible = false;
            linetrackPane.Legend.IsHStack = false;

            // Make both curves thicker
            linetrackCurve.Line.Width = 2.0F;
            lineStandardCurve.Line.Width = 2.0F;

            //// Fill the area under the curves
            //linetrackCurve.Line.Fill = new Fill(Color.White, Color.FromArgb(255, 175, 175), -90F);

            // Fill the Axis and Pane backgrounds
            linetrackPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), -45F);
            linetrackPane.Fill = new Fill(Color.WhiteSmoke);
            linetrackPane.Border.IsVisible = false;

            // Tell ZedGraph to refigure the axes since the data have changed
            zedGraphLineTrack.AxisChange();
            #endregion

            tickStart = Environment.TickCount;
        }
        #endregion
        private void DrawGraph(ZedGraphControl zedGraphControl, double value1,double value2)
        {
            if (zedGraphControl.GraphPane.CurveList.Count <= 0) return;

            // time is measure in seconds
            double time = (Environment.TickCount - tickStart) / 1000.0;

            LineItem curve = zedGraphControl.GraphPane.CurveList[0] as LineItem;
            IPointListEdit pointBuffer = curve.Points as IPointListEdit;
            // add point to buffer to draw
            pointBuffer.Add(time, value1);

           
                LineItem curve1 = zedGraphControl.GraphPane.CurveList[1] as LineItem;
                IPointListEdit pointBuffer1 = curve1.Points as IPointListEdit;
                // add point to buffer to draw
                pointBuffer1.Add(time, value2);
            
           

                // make xAxis scroll
                Scale xScale = zedGraphControl.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 30.0;
            }

            // re-draw graph
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
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
           
            
        }
        private static void delay()
        {
            System.Timers.Timer timer1 = new System.Timers.Timer(10000);
            timer1.Elapsed += (sender, e) => timer1_Elapsed(sender, e);

            timer1.Start();
        }
        private static void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //string fullpath = "N,0,N,46,E,50,N,8,W,3,S,11,G,N,0";
            string fullpath = "P-2-S-53-N-49-W-44-N-37-G-D-3";
            Communication.SendPathData(fullpath);
            ((System.Timers.Timer)sender).Dispose();
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
            
        }

        private void timerGraph_Tick(object sender, EventArgs e)
        {
            AGV agv = AGV.ListAGV.Find(p => p.ID == selectedAGVID);
            if (agv == null) return;
            // Display Status
            lbIDSelected.Text = selectedAGVID.ToString();
            lbStatus.Text = agv.Status;
            lbPower.Text = "ON";
            
            lbBattery.Text = agv.Battery.ToString() + "%";
            prgrbBattery.Value = Convert.ToInt32(agv.Battery);
            try
            {
                lbOnTask.Text = agv.Tasks[0].Name;
            }
            catch { }
            //
            //Display Position AGV
            lbCurrentNode.Text = "Node "+agv.CurrentNode.ToString();
            switch(agv.CurrentOrient)
            {
                case 'E':
                    lbOrientation.Text = "East";
                    break;
                case 'W':
                    lbOrientation.Text = "West";
                    break;
                case 'S':
                    lbOrientation.Text = "South";
                    break;
                case 'N':
                    lbOrientation.Text = "North";
                    break;
            }
            
            lbDistancetoNode.Text = Math.Round(agv.DistanceToCurrentNode,2).ToString()+" cm";
            Point Location = ConvertLocationXY(agv);
            lbLocationX.Text = Location.X.ToString()+" cm";
            lbLocationY.Text = Location.Y.ToString() + " cm";
            //lbLocationX.Text = (Display.LabelAGV[agv.ID].Location.X+25 ).ToString();
            //lbLocationY.Text = (Display.LabelAGV[agv.ID].Location.Y+25 ).ToString();
            //
            //Display Path AGV
            lbFromNode.Text = agv.CurrentNode.ToString();
            int index = 0;
            int nextNode = -1;
            try
            {
                index = agv.Path[0].FindIndex(p=> p == agv.CurrentNode );
                nextNode = agv.Path[0][index + 1];
                lbToNode.Text = nextNode.ToString() ;
                
            }
            catch 
            {
                lbToNode.Text = "###";
               

            }
            string path="No Path";
            if(agv.Path.Count>0)
            {
                path = "";
                foreach (int node in agv.Path[0])
                {
                    path += node.ToString();
                    if (node != agv.Path[0][agv.Path[0].Count - 1])
                    {
                        path += "->";
                    }
                }
                RackColumn fromRack = new RackColumn(agv.Path[0][0]);
                lbFromRack.Text = fromRack.Block.ToString() + "-" + fromRack.Number.ToString();
                RackColumn toRack = new RackColumn(agv.Path[0][agv.Path[0].Count - 1]);
                lbToRack.Text = toRack.Block.ToString() + "-" + toRack.Number.ToString();

            }
            else 
            {
                lbFromRack.Text = "###";
                lbToRack.Text = "###";
            }
            lbFullPath.Text = path;


            lbVelocity.Text = Math.Round(agv.Velocity, 2).ToString();
            lbLine.Text = (agv.LinePos-1000).ToString();
            if (agv.LinePos == 1000) lbTracking.Text = "In The Middle";
            else if (agv.LinePos > 1000) lbTracking.Text = "On The Left";
            else if (agv.LinePos < 1000) lbTracking.Text = "On The Right";
            else lbTracking.Text = "##,#";
            //
            UpdateForkliftPosition(agv.LiftPos);
            lbLiftPosition.Text = agv.LiftPos.ToString();
            if(agv.HavePallet)
            {
                lbHavePallet.Text = "Yes";
                ptbGoods.Visible = true;
            }
            else
            {
                lbHavePallet.Text = "No";
                ptbGoods.Visible = false;

            }
            // Draw Graph
            DrawGraph(zedGraphVelocity,agv.Velocity,Convert.ToDouble(txtbSetVelocity.Text));
            DrawGraph(zedGraphLineTrack,agv.LinePos-1000,0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       

        private void timerView_Tick(object sender, EventArgs e)
        {

        }
        private static Point ConvertLocationXY(AGV agv)
        {
            Point Location = new Point();
            int x=0, y=0;
            List<Node> Nodes = DBUtility.GetDataFromDB<List<Node>>("NodeInfoTable");
            int pixelDistance = (int)Math.Round(agv.DistanceToCurrentNode * 2);//Display.Scale
            try
            {
                x = Nodes[agv.CurrentNode].X ;
                y = Nodes[agv.CurrentNode].Y ;
            }
            catch { }
            switch (agv.CurrentOrient)
            {
                case 'E':
                    Location = new Point(x + pixelDistance, y);

                    break;
                case 'W':
                    Location = new Point(x - pixelDistance, y);

                    break;
                case 'S':
                    Location = new Point(x, y + pixelDistance);


                    break;
                case 'N':
                    Location = new Point(x, y - pixelDistance);

                    break;
                

                   
            }
            Location.X = (int)(Location.X-40)/2;
            Location.Y = (int)(Location.Y - 40) / 2;
            return Location;
        }
        private void UpdateForkliftPosition(float position)
        {
            if (position > 100)
                position = 100;
            else if (position < 0)
                position = 0;
            int pixel = (int)((position / 100) * 260);
            int x1 = lbPosLift.Location.X;
            int y1 =349 - pixel;
            lbPosLift.Location = new Point(x1, y1);

            int x2 = ptbLift.Location.X;
            int y2 = 331 - pixel;
            ptbLift.Location = new Point(x2,y2);

            int x3 = ptbGoods.Location.X;
            int y3 = 382 - pixel;
            ptbGoods.Location = new Point(x3,y3);



        }
        
        private void cbbAGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arrID = cbbAGV.Text.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            selectedAGVID = Convert.ToInt16(arrID[1]);
            
        }

       
    }
}
