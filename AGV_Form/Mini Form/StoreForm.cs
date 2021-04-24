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
        public StoreForm()
        {
            InitializeComponent();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            int agvID = 1;
            RackColumn rack = RackColumn.SimListColumn.Find(c => c.Block == cbbBlock.Text && c.Number == Convert.ToInt32(cbbColumn.Text));
            string palletcode = txtPalletCode.Text;
            int pickNode = 53;
            int pickLevel = 1;

            int dropNode = rack.AtNode;
            int dropLevel = Convert.ToInt32(cbbLevel.Text);

            label4.Text = dropNode.ToString();
            label6.Text = dropLevel.ToString();
            label7.Text = rack.Block.ToString();
            Task task = new Task("Store1", "Store", palletcode, agvID,
                                 pickNode, dropNode, pickLevel, dropLevel
                                 , "Waiting");
            Pallet pallet = new Pallet(palletcode,true,"??", cbbBlock.Text, Convert.ToInt32(cbbColumn.Text), Convert.ToInt32(cbbLevel.Text));
            int AGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == agvID; });
            AGV.SimListAGV[AGVindex].Tasks.Add(task);
            Task.SimListTask.Add(task);
            Pallet.SimStorePallet.Add(pallet);
        }
    }
}
