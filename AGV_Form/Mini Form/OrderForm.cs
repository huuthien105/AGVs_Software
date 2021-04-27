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
            lstvwPalletInStock.Items.Clear();

            switch (Display.Mode)
            {
                case "Real Time":
                    lbMode.Text = "Mode: Real Time";
                    break;
                case "Simulation":

                    lbMode.Text = "Mode: Simulation";
                    Pallet.SimListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("SimPalletInfoTable");
                    foreach (Pallet pallet in Pallet.SimListPallet)
                    {
                        lstvwPalletInStock.Items.Add(pallet.Code, 0);
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.StoreTime);
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtBlock);
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtColumn.ToString());
                        lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtLevel.ToString());
                    }
                    break;
            }
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // collect all selected pallet code
            List<string> selectedPalletCode = new List<string>();
            foreach (ListViewItem item in lstvwPalletInStock.CheckedItems) selectedPalletCode.Add(item.Text);
            List<Pallet> palletSelected = new List<Pallet>();

            foreach (string palletCode in selectedPalletCode)
            {
                palletSelected.Add(Pallet.SimListPallet.Find(c => c.Code == palletCode));
            }

            foreach (Pallet pallet in palletSelected)
            {
                int agvID = 1;
                RackColumn rack = RackColumn.SimListColumn.Find(c => c.Block == pallet.AtBlock && c.Number == pallet.AtColumn);
                int pickNode = rack.AtNode;
                int pickLevel = pallet.AtLevel;

                int dropNode = Output;
                int dropLevel = 1;

                Task task = new Task("Order1", "Order", pallet.Code, agvID,
                                 pickNode, dropNode, pickLevel, dropLevel
                                 , "Waiting");
                
                int AGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
                AGV.SimListAGV[AGVindex].Tasks.Add(task);
                Task.SimListTask.Add(task);
                listViewPalletSelected.Items.Clear();
                foreach (ListViewItem item in lstvwPalletInStock.Items) item.Checked = false;
            }
        }

        private void timerListView_Tick(object sender, EventArgs e)
        {
            Display.UpdateListViewTasks(listViewTask,Task.SimListTask);
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
    }
}
