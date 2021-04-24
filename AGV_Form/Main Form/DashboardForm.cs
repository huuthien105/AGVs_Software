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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }
        int x = 300;
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            
            
            
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
                
            }
        }

        private void timerListview_Tick(object sender, EventArgs e)
        {

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
                    // Update location of AGV icon (label)
                    Display.UpdateListViewTasks(listViewTasks, Task.SimListTask);


                    break;
            }
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
                    }
                    break;
                case "Simulation":
                    foreach (AGV agv in AGV.SimListAGV)
                    {
                        
                        pnFloor.Controls.Add(Display.SimLabelAGV[agv.ID]);
                    }
                    break;
            }
            
        }

        private void timerSimAGV_Tick(object sender, EventArgs e)
        {
            listViewTasks.Items.Clear();
            
            foreach(AGV agv in AGV.SimListAGV)
            {
                Task.SimUpdatePathFromTaskOfAGVs(agv);
                Display.SimLabelAGV[agv.ID].Location = Display.SimUpdatePositionAGV(agv.ID, 1);
                    
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
            timerSimAGV.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.BackColor = Color.DodgerBlue;
            btnPause.BackColor = Color.LightSteelBlue;
            timerSimAGV.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            
                orderForm.Show();
            
        }
    }
}
