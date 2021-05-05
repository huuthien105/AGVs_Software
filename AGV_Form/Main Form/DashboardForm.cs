using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGV_Form
{
    public partial class DashboardForm : Form
    {
        

        public DashboardForm()
        {
            InitializeComponent();
            LoadLabel();
            Communication.SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.SerialPort_ReceiveData);
        }

        private void SerialPort_ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            Communication.GetDataRecieve();
        }

        public static int delay = 0;
        private void DashboardForm_Load(object sender, EventArgs e)
        {
           
            switch (Display.Mode)
            {
                case "Real Time":
                    rdbtnRealTime.Checked = true;
                    rdbtnSimulation.Checked = false;
                    break;
                case "Simulation":
                    rdbtnRealTime.Checked = false;
                    rdbtnSimulation.Checked = true;
                    foreach (AGV agv in AGV.SimListAGV)
                    {
                        pnFloor.Controls.Add(Display.SimLabelPalletInAGV[agv.ID]);
                        Display.SimLabelPalletInAGV[agv.ID].BringToFront();
                    }
                    break;
            }

            

            //AGV.ListPathOfAGV[2] = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, 54, 30);
        }
        private void btnCOMSetting_Click(object sender, EventArgs e)
        {
            COMSetting form = new COMSetting();
            form.ShowDialog();
            if (Communication.SerialPort.IsOpen)
            {
                lbStatusCOM.Text = Communication.SerialPort.PortName + " Connected.";
            }
            else
            {
                lbStatusCOM.Text = "Please setting COM !";

            }
        }

        private void rdbtnSimulation_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnSimulation.Checked)
            {
                lbModeStatus.Text = "Simulation Mode.";
                Display.Mode = "Simulation";
                foreach (AGV agv in AGV.ListAGV)
                {
                    Label label = Display.LabelAGV[agv.ID];
                    pnFloor.Controls.Remove(label);
                    //label.Dispose();
                }
                    foreach (AGV agv in AGV.SimListAGV)
                {                   
                    pnFloor.Controls.Add(Display.SimLabelAGV[agv.ID]);
                }
                Pallet.SimListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("SimPalletInfoTable");

                // Display Pallet in Navigation Map
                foreach (Pallet pallet in Pallet.ListPallet)
                {
                    Display.DeleteLabelPallet(pallet);


                }

                foreach (Pallet pallet in Pallet.SimListPallet)
                {

                    Display.UpdateLabelPallet(pallet);
                    
                        
                }
            }
        }

        private void rdbtnRealTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnRealTime.Checked)
            {
                lbModeStatus.Text = "Realtime Mode.";
                Display.Mode = "Real Time";
                foreach (AGV agv in AGV.SimListAGV)
                {
                    //Label label = pnFloor.Controls.OfType<Label>().FirstOrDefault(lb => lb.Name == "AGV" + agv.ID.ToString());
                    Label label = Display.SimLabelAGV[agv.ID];
                    pnFloor.Controls.Remove(label);
                    //label.Dispose();
                }
                foreach (AGV agv in AGV.ListAGV)
                {
                    pnFloor.Controls.Add(Display.LabelAGV[agv.ID]);
                }

                Pallet.ListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("PalletInfoTable");
                foreach (Pallet pallet in Pallet.SimListPallet)
                {

                    Display.DeleteLabelPallet(pallet);


                }
                foreach (Pallet pallet in Pallet.ListPallet)
                {
                    Display.UpdateLabelPallet(pallet);

                }

            }
        }

        private void timerListview_Tick(object sender, EventArgs e)
        {
            delay++;
            switch (Display.Mode)
            {
                case "Real Time":
                    // Update data in listView AGVs
                    Display.UpdateListViewAGVs(listViewAGVs, AGV.ListAGV);

                    // Do something here

                    break;
                case "Simulation":
                    // Update data in listView AGVs
                    Display.UpdateListViewAGVs(listViewAGVs, AGV.SimListAGV);
                    Display.UpdateListViewTasks(listViewTask, Task.SimListTask);
                    // Update location of AGV icon (label)
                    //Display.UpdateListViewTasks(listViewTasks, Task.SimListTask);


                    break;
            }
            Collision.DetectColission();
            label19.Text = Math.Round(Collision.dis1,2).ToString();
            label20.Text = Math.Round(Collision.dis2,2).ToString();

        }
        private void pnFloor_Paint(object sender, PaintEventArgs e)
        {
            // Draw lines with Points is got by Display.AddPath function
            Graphics graphic = pnFloor.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 4);
            graphic.DrawLines(pen, Display.Points);
            graphic.Dispose();
        }



        

        private void AddAGV_Click(object sender, EventArgs e)
        {
            // Clone a list for ListAGV (amazing way to clone a reference type)
            List<AGV> oldSimListAGV = new List<AGV>();
            switch (Display.Mode)
            {
                case "Real Time":
                    AGV.ListAGV.ForEach((a) =>
                    {
                        oldSimListAGV.Add(new AGV(a.ID, a.CurrentNode, a.CurrentOrient, a.DistanceToCurrentNode, a.Status));
                    });
                    break;
                case "Simulation":
                    AGV.SimListAGV.ForEach((a) =>
                    {
                        oldSimListAGV.Add(new AGV(a.ID, a.CurrentNode, a.CurrentOrient, a.DistanceToCurrentNode, a.Status));
                    });
                    break;
            }
            using (AddRemoveAGVForm AddRemoveForm = new AddRemoveAGVForm())
            {
                AddRemoveForm.ShowDialog();
            }
            //foreach (AGV agv in oldSimListAGV)
            //{
             //   Display.RemoveLabelAGV(pnFloor, agv.ID);
           // }
            switch (Display.Mode)
            {
                case "Real Time":
                    foreach (AGV agv in AGV.ListAGV)
                    {
                        pnFloor.Controls.Add(Display.LabelAGV[agv.ID]);
                        Display.LabelAGV[agv.ID].BringToFront();
                        pnFloor.Controls.Add(Display.LabelPalletInAGV[agv.ID]);
                        Display.LabelPalletInAGV[agv.ID].BringToFront();
                    }
                    break;
                case "Simulation":
                    foreach (AGV agv in AGV.SimListAGV)
                    {
                        
                        pnFloor.Controls.Add(Display.SimLabelAGV[agv.ID]);
                        Display.SimLabelAGV[agv.ID].BringToFront();
                        pnFloor.Controls.Add(Display.SimLabelPalletInAGV[agv.ID]);
                        Display.SimLabelPalletInAGV[agv.ID].BringToFront();
                    }
                    break;
            }
            
        }

        private void timerSimAGV_Tick(object sender, EventArgs e)
        {
            //listViewTask.Items.Clear();
            switch (Display.Mode)
            {
                case "Real Time":
                    foreach (AGV agv in AGV.ListAGV)
                    {
                        
                       

                    }
                    break;
                case "Simulation":
                    foreach (AGV agv in AGV.SimListAGV)
                    {
                        Task.SimUpdatePathFromTaskOfAGVs(agv);
                        Display.SimUpdatePositionAGV(agv.ID, agv.Velocity,pnFloor, Display.SimLabelAGV[agv.ID],Display.SimLabelPalletInAGV[agv.ID]);
                       
                        
                        if(agv.HavePallet)
                            Display.SimLabelPalletInAGV[agv.ID].Visible = true;
                        else
                            Display.SimLabelPalletInAGV[agv.ID].Visible = false;
                    }
                    break;
            }


           
            
        }

       

        

        

        private void button6_Click(object sender, EventArgs e)
        {
            AddTaskAGVForm AddTaskForm = new AddTaskAGVForm();                
            AddTaskForm.Show();            
        }

        private void cntxMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            List<string> strItems = new List<string>();
            switch (Display.Mode)
            {
                case "Real Time":
                    AGV.ListAGV.ForEach(a => strItems.Add("AGV#" + a.ID.ToString()));
                    break;
                case "Simulation":
                    AGV.SimListAGV.ForEach(a => strItems.Add("AGV#" + a.ID.ToString()));
                    break;
            }
            showPathToolStripMenuItem.DropDownItems.Clear();
            foreach (string items in strItems)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items, imgList.Images[0]);
                showPathToolStripMenuItem.DropDownItems.Add(item);
                item.Click += new EventHandler(AGVDrawPath_Click);
                //Timer timerDrawPath = new Timer();
               // timerDrawPath.Tick += new EventHandler(AGVDrawPath_Click()); 

            }


        }
        private void AGVDrawPath_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string[] arrItem = item.Text.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            int agvID = Convert.ToInt16(arrItem[1]);
            
            switch (Display.Mode)
            {
                case "Real Time":
                    int i = AGV.ListAGV.FindIndex(a => a.ID == agvID);
                    if (AGV.ListAGV[i].Path.Count == 0) return;
                    //Display.AddPath(pnFloor, AGV.ListAGV[i].Path[0], Color.Blue, 4);
                    break;
                case "Simulation":
                    int j = AGV.SimListAGV.FindIndex(a => a.ID == agvID);
                    if (AGV.SimListAGV[j].Path.Count == 0) return;

                    Display.AddPath(pnFloor, AGV.SimListAGV[j].Path[0],Node.ListNode, Color.Blue, 4);
                    break;
            }
        }
        
        
        private void hidePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Display.Points = new Point[] { new Point(), new Point() };
            
            pnFloor.Refresh();
        }

        

       

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnPause.BackColor = Color.DodgerBlue;
            btnRun.BackColor = Color.LightSteelBlue;
            switch (Display.Mode)
            {
                case "Real Time":
                   
                    break;
                case "Simulation":
                    timerSimAGV.Enabled = false;
                    break;
            }
           
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.BackColor = Color.DodgerBlue;
            btnPause.BackColor = Color.LightSteelBlue;
            switch (Display.Mode)
            {
                case "Real Time":
                    AGV agv = AGV.ListAGV[0];
                    string pick, drop;
                    if (AGV.ListAGV[0].Tasks.Count == 0) return;
                    Task currentTask = AGV.ListAGV[0].Tasks[0];


                    agv.Path.Add(Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.CurrentNode, agv.Tasks[0].PickNode));
                    agv.Path.Add(Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.Tasks[0].PickNode, agv.Tasks[0].DropNode));
                    AGV.FullPathOfAGV[agv.ID] = "N-0-" + agv.CurrentOrient.ToString() + "-" + Navigation.GetNavigationFrame(agv.Path[0], Node.MatrixNodeOrient) + "-N-0";
                    Communication.SendPathData(AGV.FullPathOfAGV[agv.ID]);
                    
                    label19.Text = AGV.FullPathOfAGV[agv.ID];
                    break;
                case "Simulation":
                    timerSimAGV.Enabled = true;
                    break;
            }
        }

        private void btnOrder1_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(51);

            orderForm.Show();
        }

        private void btnOrder2_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(52);

            orderForm.Show();
        }




        private void btnStore1_Click(object sender, EventArgs e)
        {
            StoreForm storeForm = new StoreForm(53);
            storeForm.Show();
        }

        private void btnStore2_Click(object sender, EventArgs e)
        {
            StoreForm storeForm = new StoreForm(54);
            storeForm.Show();
        }
        private void LoadLabel()
        {
            // Load Pallet Label Block A
            Display.ASlotLabel[0, 0] = lbA11;
            Display.ASlotLabel[0, 1] = lbA12;
            Display.ASlotLabel[0, 2] = lbA13;

            Display.ASlotLabel[1, 0] = lbA21;
            Display.ASlotLabel[1, 1] = lbA22;
            Display.ASlotLabel[1, 2] = lbA23;

            Display.ASlotLabel[2, 0] = lbA31;
            Display.ASlotLabel[2, 1] = lbA32;
            Display.ASlotLabel[2, 2] = lbA33;

            Display.ASlotLabel[3, 0] = lbA41;
            Display.ASlotLabel[3, 1] = lbA42;
            Display.ASlotLabel[3, 2] = lbA43;

            Display.ASlotLabel[4, 0] = lbA51;
            Display.ASlotLabel[4, 1] = lbA52;
            Display.ASlotLabel[4, 2] = lbA53;

            Display.ASlotLabel[5, 0] = lbA61;
            Display.ASlotLabel[5, 1] = lbA62;
            Display.ASlotLabel[5, 2] = lbA63;
            // Load Pallet Label Block B
            Display.BSlotLabel[0, 0] = lbB11;
            Display.BSlotLabel[0, 1] = lbB12;
            Display.BSlotLabel[0, 2] = lbB13;

            Display.BSlotLabel[1, 0] = lbB21;
            Display.BSlotLabel[1, 1] = lbB22;
            Display.BSlotLabel[1, 2] = lbB23;

            Display.BSlotLabel[2, 0] = lbB31;
            Display.BSlotLabel[2, 1] = lbB32;
            Display.BSlotLabel[2, 2] = lbB33;

            Display.BSlotLabel[3, 0] = lbB41;
            Display.BSlotLabel[3, 1] = lbB42;
            Display.BSlotLabel[3, 2] = lbB43;

            Display.BSlotLabel[4, 0] = lbB51;
            Display.BSlotLabel[4, 1] = lbB52;
            Display.BSlotLabel[4, 2] = lbB53;

            Display.BSlotLabel[5, 0] = lbB61;
            Display.BSlotLabel[5, 1] = lbB62;
            Display.BSlotLabel[5, 2] = lbB63;
            // Load Pallet Label Block C
            Display.CSlotLabel[0, 0] = lbC11;
            Display.CSlotLabel[0, 1] = lbC12;
            Display.CSlotLabel[0, 2] = lbC13;

            Display.CSlotLabel[1, 0] = lbC21;
            Display.CSlotLabel[1, 1] = lbC22;
            Display.CSlotLabel[1, 2] = lbC23;

            Display.CSlotLabel[2, 0] = lbC31;
            Display.CSlotLabel[2, 1] = lbC32;
            Display.CSlotLabel[2, 2] = lbC33;

            Display.CSlotLabel[3, 0] = lbC41;
            Display.CSlotLabel[3, 1] = lbC42;
            Display.CSlotLabel[3, 2] = lbC43;

            Display.CSlotLabel[4, 0] = lbC51;
            Display.CSlotLabel[4, 1] = lbC52;
            Display.CSlotLabel[4, 2] = lbC53;

            Display.CSlotLabel[5, 0] = lbC61;
            Display.CSlotLabel[5, 1] = lbC62;
            Display.CSlotLabel[5, 2] = lbC63;
            // Load Pallet Label Block D
            Display.DSlotLabel[0, 0] = lbD11;
            Display.DSlotLabel[0, 1] = lbD12;
            Display.DSlotLabel[0, 2] = lbD13;

            Display.DSlotLabel[1, 0] = lbD21;
            Display.DSlotLabel[1, 1] = lbD22;
            Display.DSlotLabel[1, 2] = lbD23;

            Display.DSlotLabel[2, 0] = lbD31;
            Display.DSlotLabel[2, 1] = lbD32;
            Display.DSlotLabel[2, 2] = lbD33;

            Display.DSlotLabel[3, 0] = lbD41;
            Display.DSlotLabel[3, 1] = lbD42;
            Display.DSlotLabel[3, 2] = lbD43;

            Display.DSlotLabel[4, 0] = lbD51;
            Display.DSlotLabel[4, 1] = lbD52;
            Display.DSlotLabel[4, 2] = lbD53;

            Display.DSlotLabel[5, 0] = lbD61;
            Display.DSlotLabel[5, 1] = lbD62;
            Display.DSlotLabel[5, 2] = lbD63;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display.wait = 1;
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string fullpath = "N-0-S-11-N-3-W-0-S-42-E-46-G-N-0";
            //AGV agv = AGV.ListAGV[0];
            //string pick, drop;
            //Task currentTask = AGV.ListAGV[0].Tasks[0];
            //string send;
            //agv.Path.Add(Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.CurrentNode, agv.Tasks[0].PickNode));
            //send = "N-0-" + agv.CurrentOrient.ToString() + "-" + Navigation.GetNavigationFrame(agv.Path[0], Node.MatrixNodeOrient) + "-N-0";
            //send.Trim();
            //Communication.SendPathData(fullpath);
            //label19.Text = send;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display.wait = 0;
            //AGV agv = AGV.ListAGV[0];
            //string pick, drop;

            //string send;
            //Task currentTask = AGV.ListAGV[0].Tasks[0];
            //if (currentTask.PickLevel == 1 || currentTask.PickLevel == 2 || currentTask.PickLevel == 3)
            //{
            //    pick = "P-" + currentTask.PickLevel.ToString() + "-";
            //}
            //else
            //{
            //    pick = "N-0-";
            //}
            //if (currentTask.DropLevel == 1 || currentTask.DropLevel == 2 || currentTask.DropLevel == 3)
            //{
            //    drop = "-D-" + currentTask.DropLevel.ToString() ;
            //}
            //else
            //{
            //    drop = "-N-0";
            //}
            //agv.Path.Add(Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.Tasks[0].PickNode, agv.Tasks[0].DropNode));
            //send = pick + "S" + "-" + Navigation.GetNavigationFrame(agv.Path[1], Node.MatrixNodeOrient) + drop;
            //label20.Text = send;
            ////send.Trim();
            /////Communication.SendPathData(send);
            //agv.Path.Clear();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            int agvID = 1;
            AGV agv = AGV.SimListAGV.Find(p => p.ID == agvID);
            if(agv.Status == "Stop")
            {
                
                List<int> path = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.CurrentNode, 55);
                AGV.FullPathOfAGV[agvID] = Navigation.GetNavigationFrame(path, Node.MatrixNodeOrient);
                AGV.SimListAGV[0].Path.Add(path);
            }
            //agv.PathCopmpleted = 4;
        }
    }
}
