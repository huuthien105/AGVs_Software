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
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // collect pallet in stock
            List<Pallet> palletsInStock = new List<Pallet>();
            Pallet.SimListPallet = DBUtility.GetPalletInfoFromDB<List<Pallet>>("SimPalletInfoTable");
            foreach (Pallet pallet in Pallet.SimListPallet)
            {
                lstvwPalletInStock.Items.Add(pallet.Code,0);
                lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.StoreTime);
                lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtBlock);
                lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtColumn.ToString());
                lstvwPalletInStock.Items[lstvwPalletInStock.Items.Count - 1].SubItems.Add(pallet.AtLevel.ToString());
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
                palletSelected.Add(Pallet.SimListPallet.Find(c=> c.Code == palletCode));
            }

            foreach(Pallet pallet in palletSelected)
            {
                int agvID = 1;
                RackColumn rack = RackColumn.SimListColumn.Find(c => c.Block == pallet.AtBlock && c.Number ==pallet.AtColumn);
                int pickNode = rack.AtNode;
                int pickLevel =  pallet.AtLevel ;

                int dropNode = 52;
                int dropLevel = 1;

                Task task = new Task("Order", "Output", pallet.Code, agvID,
                                 pickNode, dropNode, pickLevel, dropLevel
                                 , "Waiting");
                int AGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
                AGV.SimListAGV[AGVindex].Tasks.Add(task);
                Task.SimListTask.Add(task);
            }
        }
    }
}
