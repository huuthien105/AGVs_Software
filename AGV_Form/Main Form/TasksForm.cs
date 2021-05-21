using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGV_Form
{
    public partial class TasksForm : Form
    {
        public TasksForm()
        {
            InitializeComponent();
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {

            Pallet.ListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("PalletInfoTable");
            Pallet.SimListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("SimPalletInfoTable");
            DataTable table = new DataTable();
            if (Display.Mode == "Real Time")
            {
                cbbModeList.SelectedItem = "Real Time";
                table = DBUtility.GetHisTaskFromDB<DataTable>("HistoryTask");
            } 
            else
            {
                cbbModeList.SelectedItem = "Simulation";
                table = DBUtility.GetHisTaskFromDB<DataTable>("SimHistoryTask");
            }
               

            RefreshListviewPallet();

            RefeshListTaskRemove();
            
            dgvHistoryTask.DataSource = table;
            dgvHistoryTask.Columns[0].Width = 70;
            dgvHistoryTask.Columns[1].Width = 60;
            dgvHistoryTask.Columns[2].Width = 250;
            dgvHistoryTask.Columns[3].Width = 70;
            dgvHistoryTask.Columns[4].Width = 60;
            dgvHistoryTask.Columns[5].Width = 50;
            dgvHistoryTask.Columns[6].Width = 80;
            dgvHistoryTask.Columns[7].Width = 80;

        }
        private void RefeshListTaskRemove()
        {
            cbbTaskRemove.Items.Clear();
            switch (cbbModeList.Text)
            {
                case "Real Time":
                    // Update data in listView AGVs
                    foreach (Task task in Task.ListTask)
                    {
                        cbbTaskRemove.Items.Add(task.Name);
                    }
                    break;
                case "Simulation":
                    // Update data in listView AGVs
                    foreach (Task task in Task.SimListTask)
                    {
                        cbbTaskRemove.Items.Add(task.Name);
                    }



                    break;
            }
        }
        private void RefreshListviewPallet()
        {
            lstvwPalletInStock.Items.Clear();

            switch (cbbModeList.Text)
            {
                case "Real Time":
                    
                    Pallet.ListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("PalletInfoTable");
                    foreach (Pallet pallet in Pallet.ListPallet)
                    {
                        lstvwPalletInStock.Items.Add(pallet.Code, 0);
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.Name.Trim());
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.StoreTime.Trim());
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtBlock + "-" + pallet.AtColumn.ToString() + "-" + pallet.AtLevel.ToString());
                    }
                    break;
                case "Simulation":

                   
                    Pallet.SimListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("SimPalletInfoTable");
                    foreach (Pallet pallet in Pallet.SimListPallet)
                    {
                        lstvwPalletInStock.Items.Add(pallet.Code, 0);
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.Name.Trim());
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.StoreTime.Trim());
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtBlock + "-" + pallet.AtColumn.ToString() + "-" + pallet.AtLevel.ToString());
                    }
                    break;
            }
        }

        private void timerListview_Tick(object sender, EventArgs e)
        {
            switch (cbbModeList.Text)
            {
                case "Real Time":
                    // Update data in listView AGVs
                    Display.UpdateListViewTasks(listViewTasks, Task.ListTask);


                    break;
                case "Simulation":
                    // Update data in listView AGVs
                    
                    Display.UpdateListViewTasks(listViewTasks, Task.SimListTask);
                    // Update location of AGV icon (label)
                    //Display.UpdateListViewTasks(listViewTasks, Task.SimListTask);


                    break;
            }
        }

        private void cbbModeList_SelectedIndexChanged(object sender, EventArgs e)
        {

            RefreshListviewPallet();
            // Update task in Task Remove
            RefeshListTaskRemove();
            DataTable table = new DataTable();
            if (cbbModeList.Text == "Real Time")
            {             
                table = DBUtility.GetHisTaskFromDB<DataTable>("HistoryTask");
            }
            else
            {              
                table = DBUtility.GetHisTaskFromDB<DataTable>("SimHistoryTask");
            }
            dgvHistoryTask.DataSource = table;
        }

        private void ckbAutoSelectSlot_CheckedChanged(object sender, EventArgs e)
        {
            string Slot = "";
            if (cbbModeList.Text == "Simulation")
                Slot = Task.AutoSelecSlotPallet(Pallet.SimListPallet.Concat(Pallet.SimStorePallet).ToList());
            else if (cbbModeList.Text == "Real Time")
                Slot = Task.AutoSelecSlotPallet(Pallet.ListPallet.Concat(Pallet.StorePallet).ToList());
            if (ckbAutoSelectSlot.Checked)
            {

                string[] arrSlot = Slot.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                cbbBlock.Text = arrSlot[0];
                cbbColumn.Text = arrSlot[1];
                cbbLevel.Text = arrSlot[2];
                cbbBlock.Enabled = false;
                cbbColumn.Enabled = false;
                cbbLevel.Enabled = false;
            }
            else
            {
                cbbBlock.Enabled = true;
                cbbColumn.Enabled = true;
                cbbLevel.Enabled = true;
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPalletCode.Text) || String.IsNullOrEmpty(txtPalletName.Text) ||
            String.IsNullOrEmpty(cbbBlock.Text) || String.IsNullOrEmpty(cbbColumn.Text) || String.IsNullOrEmpty(cbbLevel.Text)
            || String.IsNullOrEmpty(cbbStoreNode.Text))
            {
                MessageBox.Show(" Please enter correct Pallet informarion !", "Pallet Information ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int agvID = 0;
            if (cbbModeList.Text == "Simulation")
                agvID = Task.AutoSelectAGV(AGV.SimListAGV, Convert.ToInt32(cbbStoreNode.Text));
            else if (cbbModeList.Text == "Real Time")
                agvID = Task.AutoSelectAGV(AGV.ListAGV, Convert.ToInt32(cbbStoreNode.Text));
            RackColumn rack = RackColumn.ListColumn.Find(c => c.Block == cbbBlock.Text && c.Number == Convert.ToInt32(cbbColumn.Text));
            string palletcode = txtPalletCode.Text;
            string palletName = txtPalletName.Text;
            string taskname = null;
            int pickNode = Convert.ToInt32(cbbStoreNode.Text);
            int pickLevel = 1;

            int dropNode = rack.AtNode;
            int dropLevel = Convert.ToInt32(cbbLevel.Text);
            switch (cbbModeList.Text)
            {
                case "Real Time":
                    taskname = "Store " + Task.StoreIndex.ToString();
                    Task.StoreIndex++;
                    foreach (Pallet palet in Pallet.ListPallet)
                    {
                        if (palet.Code.Trim() == txtPalletCode.Text)
                        {
                            MessageBox.Show("Pallet has stored in stock !", "Store Pallet Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (palet.AtBlock == cbbBlock.Text && palet.AtColumn == Convert.ToInt32(cbbColumn.Text) && palet.AtLevel == Convert.ToInt32(cbbLevel.Text))
                        {
                            MessageBox.Show("Slot is not available !", "Store Pallet Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;
                case "Simulation":
                    taskname = "Store " + Task.SimStoreIndex.ToString();
                    Task.SimStoreIndex++;
                    foreach (Pallet palet in Pallet.SimListPallet)
                    {
                        if (palet.Code.Trim() == txtPalletCode.Text)
                        {
                            MessageBox.Show("Pallet has stored in stock !", "Store Pallet Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (palet.AtBlock == cbbBlock.Text && palet.AtColumn == Convert.ToInt32(cbbColumn.Text) && palet.AtLevel == Convert.ToInt32(cbbLevel.Text))
                        {
                            MessageBox.Show("Slot is not available !", "Store Pallet Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;
            }


            Task task = new Task(taskname, "Store", palletcode, agvID,
                                 pickNode, dropNode, pickLevel, dropLevel
                                 , "Waiting");
            Pallet pallet = new Pallet(palletcode, palletName, true, "??", cbbBlock.Text, Convert.ToInt32(cbbColumn.Text), Convert.ToInt32(cbbLevel.Text));
            switch (cbbModeList.Text)
            {
                case "Real Time":
                    int AGVindex = AGV.ListAGV.FindIndex(a => { return a.ID == agvID; });
                    AGV.ListAGV[AGVindex].Tasks.Add(task);
                    Task.ListTask.Add(task);
                    Pallet.StorePallet.Add(pallet);
                    cbbTaskRemove.Items.Add(task.Name);
                    break;
                case "Simulation":
                    int SimAGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
                    AGV.SimListAGV[SimAGVindex].Tasks.Add(task);
                    Task.SimListTask.Add(task);
                    Pallet.SimStorePallet.Add(pallet);
                    cbbTaskRemove.Items.Add(task.Name);
                    break;
            }
            txtPalletCode.Text = "";
            txtPalletName.Text = "";
            ckbAutoSelectSlot.Checked = false;
            cbbBlock.Enabled = true;
            cbbBlock.Text = "";
            cbbColumn.Enabled = true;
            cbbColumn.Text = "";
            cbbLevel.Enabled = true;
            cbbLevel.Text = "";
            cbbStoreNode.Text = "";
        }

        private void btnFindPallet_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            switch (cbbModeList.Text)
            {
                case "Real Time":
                    table = DBUtility.GetPalletInfoFromDB<DataTable>("PalletInfoTable");
                    break;
                case "Simulation":
                    table = DBUtility.GetPalletInfoFromDB<DataTable>("SimPalletInfoTable");

                    break;
            }
            string filter = null;
            switch (cbbType.Text)
            {
                case "Code":
                    filter = "PalletCode";
                    break;
                case "Name":
                    filter = "PalletName";
                    break;
                case "Block":
                    filter = "Location";
                    break;
            }
            string searchQuery = filter + "='" + txtDetail.Text + "'";
            try
            {
                DataRow[] result = table.Select(searchQuery);
                txtPalletOrder.Text = result[0][0].ToString();               
            }
            catch 
            {
                txtPalletOrder.Clear();
                
            }
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPalletOrder.Text)|| String.IsNullOrEmpty(cbbOrderNode.Text))
            {
                MessageBox.Show(" Please enter correct Pallet informarion !", "Pallet Information ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Pallet pallet;
            string taskname = null;
            if (cbbModeList.Text == "Real Time")
            {
                pallet = Pallet.ListPallet.Find(c => c.Code == txtPalletOrder.Text);
                taskname = "Order " + Task.OrderIndex.ToString();
                Task.OrderIndex++;
            }
            
            else
            {
                taskname = "Order " + Task.SimOrderIndex.ToString();
                Task.SimOrderIndex++;
                pallet = Pallet.SimListPallet.Find(c => c.Code == txtPalletOrder.Text);
            }
                

          
            RackColumn rack = RackColumn.ListColumn.Find(c => c.Block == pallet.AtBlock && c.Number == pallet.AtColumn);
            //Debug.WriteLine(rack.AtNode.ToString());
            int agvID = 0;
            if (cbbModeList.Text == "Simulation")
                agvID = Task.AutoSelectAGV(AGV.SimListAGV, rack.AtNode);
            else if (cbbModeList.Text == "Real Time")
                agvID = Task.AutoSelectAGV(AGV.ListAGV, rack.AtNode);
            //Debug.WriteLine(agvID.ToString());
            int pickNode = rack.AtNode;
            int pickLevel = pallet.AtLevel;

            int dropNode = Convert.ToInt32(cbbOrderNode.Text);
            int dropLevel = 1;

            Task task = new Task(taskname, "Order", pallet.Code, agvID,
                             pickNode, dropNode, pickLevel, dropLevel
                             , "Waiting");
            switch (cbbModeList.Text)
            {
                case "Real Time":
                    int AGVindex = AGV.ListAGV.FindIndex(a => { return a.ID == agvID; });
                    AGV.ListAGV[AGVindex].Tasks.Add(task);
                    Task.ListTask.Add(task);
                    cbbTaskRemove.Items.Add(task.Name);
                    break;
                case "Simulation":
                    int SimAGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
                    AGV.SimListAGV[SimAGVindex].Tasks.Add(task);
                    Task.SimListTask.Add(task);
                    cbbTaskRemove.Items.Add(task.Name);
                    break;
            }
            txtPalletOrder.Clear();
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            if(cbbModeList.Text== "Real Time")
            {
                Task taskRemove = Task.ListTask.Find(a=>a.Name == cbbTaskRemove.Text);
                if(taskRemove.Status == "Waiting")
                {
                    Task.ListTask.Remove(taskRemove);
                    int AGVindex = AGV.ListAGV.FindIndex(a => { return a.ID == taskRemove.AGVID; });
                    AGV.ListAGV[AGVindex].Tasks.Remove(taskRemove);
                    MessageBox.Show("Remove " + taskRemove.Name.ToString() + " Successful !", "Remove Task",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                Task taskRemove = Task.SimListTask.Find(a => a.Name == cbbTaskRemove.Text);
                if (taskRemove.Status == "Waiting")
                {
                    Task.SimListTask.Remove(taskRemove);
                    int SimAGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == taskRemove.AGVID; });
                    AGV.SimListAGV[SimAGVindex].Tasks.Remove(taskRemove);
                    MessageBox.Show("Remove "+taskRemove.Name.ToString()+ " Successful !", "Remove Task",
                                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            cbbTaskRemove.Text = "";
            RefreshListviewPallet();
            RefeshListTaskRemove();
        }
        private void SearchTask()
        {
            DataTable table = new DataTable();
            DataRow[] result;
            string searchQuery = null;
            switch (cbbModeList.Text)
            {
                case "Real Time":
                    table = DBUtility.GetHisTaskFromDB<DataTable>("HistoryTask");
                    //dgvPalletInfo.DataSource = table;
                     searchQuery = cbbHisFilter.Text + "='" + txtName.Text + "'";
                     result = table.Select(searchQuery);
                    //result[0][1].ToString();
                    listviewSearch.Items.Clear();
                    for (int i = 0; i < result.Length; i++)
                    {
                        listviewSearch.Items.Add(result[i][0].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][1].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][2].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][3].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][4].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][5].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][6].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][7].ToString());
                    }
                    break;
                case "Simulation":

                    table = DBUtility.GetHisTaskFromDB<DataTable>("SimHistoryTask");
                    //dgvPalletInfo.DataSource = table;
                     searchQuery = cbbHisFilter.Text + "='" + txtName.Text + "'";
                     result = table.Select(searchQuery);
                    //result[0][1].ToString();
                    listviewSearch.Items.Clear();
                    for (int i = 0; i < result.Length; i++)
                    {
                        listviewSearch.Items.Add(result[i][0].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][1].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][2].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][3].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][4].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][5].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][6].ToString());
                        listviewSearch.Items[listviewSearch.Items.Count - 1].SubItems.Add(result[i][7].ToString());
                    }
                    break;
            }
        }

        private void btnHisSearch_Click(object sender, EventArgs e)
        {
            SearchTask();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listviewSearch.Items.Clear();
        }
    }
}
