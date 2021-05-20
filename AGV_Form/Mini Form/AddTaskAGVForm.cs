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
    public partial class AddTaskAGVForm : Form
    {
        public AddTaskAGVForm()
        {
            InitializeComponent();
        }
        private List<Task> listOldTask = new List<Task>();
        private List<Task> listNewTask = new List<Task>();
        private static int indexTask = 1;
        private void AddTaskAGVForm_Load(object sender, EventArgs e)
        {
            switch (Display.Mode)
            {
                case "Real Time":
                    // Create a copy of current ListTask
                    listOldTask = new List<Task>(Task.ListTask);
                    // Put existing Task in ListTask and listViewTask
                    foreach (Task task in Task.ListTask)
                    {
                        listViewTask.Items.Add(task.Name, 0);
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.Type);
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.PalletCode);
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("AGV#" + task.AGVID.ToString());
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.PickNode.ToString() + "-" + task.PickLevel.ToString());
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.DropNode.ToString() + "-" + task.DropLevel.ToString());
                    }
                    break;
                case "Simulation":
                    // Create a copy of current SimListTask
                   listOldTask = new List<Task>(Task.SimListTask);
                    txtTaskName.Text = "Collision " + indexTask.ToString();
                    txtPalletCode.Text = "Collision " + indexTask.ToString();                 
                    // Put existing Task in SimListTask and listViewTask
                    foreach (Task task in Task.SimListTask)
                    {
                        listViewTask.Items.Add(task.Name, 0);
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.Type);
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.PalletCode);
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("AGV#" + task.AGVID.ToString());
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.PickNode.ToString() + "-" + task.PickLevel.ToString());
                        listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.DropNode.ToString() + "-" + task.DropLevel.ToString());
                    }
                    break;
            }
        }

        

        

        private void cbbAGV_Click(object sender, EventArgs e)
        {
            // Display AGV in combobox if AGV exist
            cbbAGV.Items.Clear();
            switch (Display.Mode)
            {
                case "Real Time":
                    AGV.ListAGV.ForEach(agv => cbbAGV.Items.Add("AGV#" + agv.ID));
                    break;
                case "Simulation":
                    AGV.SimListAGV.ForEach(agv => cbbAGV.Items.Add("AGV#" + agv.ID));
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTaskName.Text) || String.IsNullOrEmpty(cbbType.Text) ||
               String.IsNullOrEmpty(txtPalletCode.Text) || String.IsNullOrEmpty(cbbAGV.Text) ||
               String.IsNullOrEmpty(txtPickNode.Text) || String.IsNullOrEmpty(txtDropNode.Text))
                return;
            // Check whether TaskName exist in old and new list or not
            string[] agvID = cbbAGV.Text.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            int dropNode = Convert.ToInt32(txtDropNode.Text);
            int pickNode = Convert.ToInt32(txtPickNode.Text);
            if(RackColumn.ListColumn.FindIndex(p=>p.AtNode ==pickNode)==-1)
            {
                MessageBox.Show("Please select Pick Node in Rack Collumn", "Warning",
                                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPickNode.Clear();
                return;
            }
            if (RackColumn.ListColumn.FindIndex(p => p.AtNode == dropNode) == -1)
            {
                MessageBox.Show("Please select Drop Node in Rack Collumn", "Warning",
                                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDropNode.Clear();
                return;
            }

            Task task = new Task(txtTaskName.Text, cbbType.Text, txtPalletCode.Text,
                                 Convert.ToInt16(agvID[1]), Convert.ToInt16(txtPickNode.Text), Convert.ToInt16(txtDropNode.Text),
                                 Convert.ToInt16(txtLevelPick.Text), Convert.ToInt16(txtLevelDrop.Text), "Waiting");
            // Put new Task in listView
            listViewTask.Items.Add(task.Name, 0);
            listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.Type);
            listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.PalletCode);
            listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("AGV#" + task.AGVID.ToString());
            listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.PickNode.ToString() + "-" + task.PickLevel.ToString());
            listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.DropNode.ToString() + "-" + task.DropLevel.ToString());
            listNewTask.Add(task);
            int AGVindex = AGV.SimListAGV.FindIndex(a => { return a.ID == Convert.ToInt16(agvID[1]); });
            AGV.SimListAGV[AGVindex].Tasks.Add(task);
            Task.SimListTask.Add(task);
            // Clear textBox for next adding
            indexTask++;
            txtTaskName.Text = "Collision " + indexTask.ToString();
            txtPalletCode.Text = "Collision " + indexTask.ToString();
            cbbAGV.Text = "";
            txtPickNode.Clear();
            txtDropNode.Clear();
        }

        private void cbbTaskName_Click(object sender, EventArgs e)
        {
            cbbTaskName.Items.Clear();
            foreach (Task task in Task.SimListTask)
            {
                cbbTaskName.Items.Add(task.Name);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbbTaskName.Text) == false)
            {
                List<Task> listAll = Task.SimListTask;
                Task taskToRemove = listAll.Find(t => { return t.Name == cbbTaskName.Text; });
                foreach(AGV agv in AGV.SimListAGV)
                {
                    if (agv.Tasks.Contains(taskToRemove))
                        agv.Tasks.Remove(taskToRemove);
                }    

                if (listAll.Contains(taskToRemove))
                    listAll.Remove(taskToRemove);
                listViewTask.Items.Clear();
                foreach (Task task in Task.SimListTask)
                {
                    listViewTask.Items.Add(task.Name, 0);
                    listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.Type);
                    listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add(task.PalletCode);
                    listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("AGV#" + task.AGVID.ToString());
                    listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.PickNode.ToString() + "-" + task.PickLevel.ToString());
                    listViewTask.Items[listViewTask.Items.Count - 1].SubItems.Add("Node " + task.DropNode.ToString() + "-" + task.DropLevel.ToString());
                }
                
            }
        }
    }
}
