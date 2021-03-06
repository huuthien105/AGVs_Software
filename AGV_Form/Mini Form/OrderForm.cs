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
    public partial class OrderForm : Form
    {
        public OrderForm(int output)
        {
            InitializeComponent();
            Output = output;
        }
        private int Output;
        private void OrderForm_Load(object sender, EventArgs e)
        {

            List<Pallet> palletsInStock = new List<Pallet>();
            Pallet.SimListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("SimPalletInfoTable");
            Pallet.ListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("PalletInfoTable");
            RefreshListviewPallet();

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // collect all selected pallet code
            List<string> selectedPalletCode = new List<string>();
            foreach (ListViewItem item in lstvwPalletInStock.CheckedItems) selectedPalletCode.Add(item.Text);
            List<Pallet> palletSelected = new List<Pallet>();

            foreach (string palletCode in selectedPalletCode)
            {
                switch (Display.Mode)
                {
                    case "Real Time":
                        palletSelected.Add(Pallet.ListPallet.Find(c => c.Code == palletCode));
                        break;
                    case "Simulation":
                        palletSelected.Add(Pallet.SimListPallet.Find(c => c.Code == palletCode));

                        break;
                }
               
            }

            foreach (Pallet pallet in palletSelected)
            {
                
                RackColumn rack = RackColumn.ListColumn.Find(c => c.Block == pallet.AtBlock && c.Number == pallet.AtColumn);
                int agvID = 0;
                if (Display.Mode == "Simulation")
                    agvID = Task.AutoSelectAGV(AGV.SimListAGV, rack.AtNode);
                else if (Display.Mode == "Real Time")
                    agvID = Task.AutoSelectAGV(AGV.ListAGV, rack.AtNode);
                string taskname = null;
                int pickNode = rack.AtNode;
                int pickLevel = pallet.AtLevel;

                int dropNode = Output;
                int dropLevel = 1;
                switch (Display.Mode)
                {
                    case "Real Time":
                        taskname = "Order " + Task.OrderIndex.ToString();
                        Task.OrderIndex++;
                        break;
                    case "Simulation":
                        taskname = "Order " + Task.SimOrderIndex.ToString();
                        Task.SimOrderIndex++;

                        break;
                }



                Task task = new Task(taskname, "Order", pallet.Code, agvID,
                                 pickNode, dropNode, pickLevel, dropLevel
                                 , "Waiting");
                switch (Display.Mode)
                {
                    case "Real Time":
                      
                        int AGVindex = AGV.ListAGV.FindIndex(a => { return a.ID == agvID; });
                        AGV.ListAGV[AGVindex].Tasks.Add(task);
                        Task.ListTask.Add(task);
                        break;
                    case "Simulation":
                        
                        int SimAGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
                        AGV.SimListAGV[SimAGVindex].Tasks.Add(task);
                        Task.SimListTask.Add(task);

                        break;
                }
                
                listViewPalletSelected.Items.Clear();

                foreach (ListViewItem item in lstvwPalletInStock.Items)
                {
                    if(item.Checked)
                    lstvwPalletInStock.Items.Remove(item);
                } 
            }
            
        }

        private void timerListView_Tick(object sender, EventArgs e)
        {

            switch (Display.Mode)
            {
                case "Real Time":
                    Display.UpdateListViewTasks(listViewTask, Task.ListTask);
                    break;
                case "Simulation":
                    Display.UpdateListViewTasks(listViewTask, Task.SimListTask);

                    break;
            }
           
            // collect pallet in stock
            
        }

        private void lstvwPalletInStock_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            listViewPalletSelected.Items.Clear();

            foreach (ListViewItem item in lstvwPalletInStock.CheckedItems)
            {

                listViewPalletSelected.Items.Add(item.Text, 0);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            switch (Display.Mode)
            {
                case "Real Time":
                    table = DBUtility.GetPalletInfoFromDB<DataTable>("PalletInfoTable");
                    break;
                case "Simulation":
                    table = DBUtility.GetPalletInfoFromDB<DataTable>("SimPalletInfoTable");

                    break;
            }
           
            string filter = null;
            switch (cbbFilter.Text)
            {
                case "Code":
                    filter = "PalletCode";
                    break;
                case "Name":
                    filter = "PalletName";
                    break;
                case "Block":
                    filter = "AtBlock";
                    break;
            }
            string searchQuery = filter + "='" + txtName.Text + "'";
            
            try
            {
                DataRow[] result = table.Select(searchQuery);
                lstvwPalletInStock.Items.Clear();
                for (int i = 0; i < result.Length; i++)
                {
                    lstvwPalletInStock.Items.Add(result[i][0].ToString(), 0);
                    lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(result[i][1].ToString().Trim());
                    lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(result[i][3].ToString().Trim());
                    lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(result[i][4].ToString() + "-" + result[i][5].ToString() + "-" + result[i][6].ToString());
                }
            }
            catch 
            {
                lstvwPalletInStock.Items.Clear();
            }
               
           

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListviewPallet();
        }
        private void RefreshListviewPallet()
        {
            lstvwPalletInStock.Items.Clear();

            switch (Display.Mode)
            {
                case "Real Time":
                    lbMode.Text = "Mode: Real Time";
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

                    lbMode.Text = "Mode: Simulation";
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbbTaskRemove.Text)) return;
            if (Display.Mode == "Real Time")
            {
                Task taskRemove = Task.ListTask.Find(a => a.Name == cbbTaskRemove.Text);
                if (taskRemove.Status == "Waiting")
                {
                    Task.ListTask.Remove(taskRemove);
                    int AGVindex = AGV.ListAGV.FindIndex(a => { return a.ID == taskRemove.AGVID; });
                    AGV.ListAGV[AGVindex].Tasks.Remove(taskRemove);
                    MessageBox.Show("Remove " + taskRemove.Name.ToString() + " Successful !", "Remove Task",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable Remove " + taskRemove.Name.ToString() + " Because Task is doing !", "Remove Task",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Remove " + taskRemove.Name.ToString() + " Successful !", "Remove Task",
                                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable Remove " + taskRemove.Name.ToString() + " Because Task is doing !", "Remove Task",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cbbTaskRemove.Text = "";
        }

        private void cbbTaskRemove_Click(object sender, EventArgs e)
        {

            cbbTaskRemove.Items.Clear();
            switch (Display.Mode)
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
    }
}
