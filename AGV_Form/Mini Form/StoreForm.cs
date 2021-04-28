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
    public partial class StoreForm : Form
    {
        private int Input;
        public StoreForm(int input)
        {
            InitializeComponent();
            Input = input;
        }
        private void StoreForm_Load(object sender, EventArgs e)
        {
            List<Pallet> palletsInStock = new List<Pallet>();
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
        private void btnStore_Click(object sender, EventArgs e)
        {
            int agvID = 1;
            RackColumn rack = RackColumn.SimListColumn.Find(c => c.Block == cbbBlock.Text && c.Number == Convert.ToInt32(cbbColumn.Text));
            string palletcode = txtPalletCode.Text;
            int pickNode = Input;
            int pickLevel = 1;

            int dropNode = rack.AtNode;
            int dropLevel = Convert.ToInt32(cbbLevel.Text);
            foreach(Pallet palet in Pallet.SimListPallet)
            {
                if (palet.Code.Trim() == txtPalletCode.Text)
                {
                    MessageBox.Show("Pallet has stored in stock !", "Store Pallet Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }  
                else if (palet.AtBlock == cbbBlock.Text && palet.AtColumn== Convert.ToInt32(cbbColumn.Text)&&palet.AtLevel== Convert.ToInt32(cbbLevel.Text))
                {
                    MessageBox.Show("Slot is not available !", "Store Pallet Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }    
            
            Task task = new Task("Store1", "Store", palletcode, agvID,
                                 pickNode, dropNode, pickLevel, dropLevel
                                 , "Waiting");
            Pallet pallet = new Pallet(palletcode,true,"??", cbbBlock.Text, Convert.ToInt32(cbbColumn.Text), Convert.ToInt32(cbbLevel.Text));
            int AGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
            AGV.SimListAGV[AGVindex].Tasks.Add(task);
            Task.SimListTask.Add(task);
            Pallet.SimStorePallet.Add(pallet);
        }

        private void timerListview_Tick(object sender, EventArgs e)
        {
            Display.UpdateListViewTasks(listViewTask, Task.SimListTask,RackColumn.SimListColumn);
        }

       
    }
}
