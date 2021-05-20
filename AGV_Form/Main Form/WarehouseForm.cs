using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AGV_Form
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            LoadNodeInforView();

            

            LoadAGVInfoView(AGV.ListAGV,dgvListAGV);
            LoadAGVInfoView(AGV.SimListAGV, dgvSimListAGV);
            LoadPalletView(dgvRealPalletInfo);
            LoadPalletView(dgvSimPalletInfo);
            LoadHistoryTaskView(dgvRealHisTaskInfo);
            LoadHistoryTaskView(dgvSimHisTaskInfo);
            lbNumAGV.Text = AGV.ListAGV.Count.ToString();
            lbNumSimListAGV.Text = AGV.SimListAGV.Count.ToString();
            lbRealTotalPallet.Text = (dgvRealPalletInfo.Rows.Count-1).ToString();
            lbSimTotalPallet.Text = (dgvSimPalletInfo.Rows.Count-1).ToString();
            lbRealTotalTask.Text = (dgvRealHisTaskInfo.Rows.Count-1).ToString();
            lbSimTotalTask.Text = (dgvSimHisTaskInfo.Rows.Count-1).ToString();

        }
        private void LoadPalletView(DataGridView dataGridView)
        {
            DataTable dataPallet = new DataTable();
            if(dataGridView== dgvRealPalletInfo)
            dataPallet = DBUtility.GetPalletInfoFromDB<DataTable>("PalletInfoTable");
            else if(dataGridView == dgvSimPalletInfo)
            dataPallet = DBUtility.GetPalletInfoFromDB<DataTable>("SimPalletInfoTable");
            dataGridView.DataSource = dataPallet;
            dataGridView.Columns[0].Width = 105;
            dataGridView.Columns[1].Width = 110;
            dataGridView.Columns[2].Width = 80;
            dataGridView.Columns[3].Width = 300;
            dataGridView.Columns[4].Width = 90;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;
        }
        private void LoadHistoryTaskView(DataGridView dataGridView)
        {
            DataTable dataTask = new DataTable();
            if (dataGridView == dgvRealHisTaskInfo)
                dataTask = DBUtility.GetHisTaskFromDB<DataTable>("HistoryTask");
            else if (dataGridView == dgvSimHisTaskInfo)
                dataTask = DBUtility.GetHisTaskFromDB<DataTable>("SimHistoryTask");
            dataGridView.DataSource = dataTask;
            dataGridView.Columns[0].Width = 110;
            dataGridView.Columns[1].Width = 80;
            dataGridView.Columns[2].Width = 300;
            dataGridView.Columns[3].Width = 90;
            dataGridView.Columns[4].Width = 70;
            dataGridView.Columns[5].Width = 60;
            dataGridView.Columns[6].Width = 90;
            dataGridView.Columns[7].Width = 90;
        }
        private void LoadAGVInfoView(List<AGV> listAGV,DataGridView gridView )
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Connection", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("Battery", typeof(string));
            dataTable.Columns.Add("Velocity", typeof(string));
            dataTable.Columns.Add("Node", typeof(int));
                 
            foreach(AGV agv in listAGV)
            {
                dataTable.Rows.Add(agv.ID, "Disconnect", agv.Status, agv.Battery.ToString() + " %", agv.Velocity.ToString() + " cm/s", agv.CurrentNode);
            }

            gridView.DataSource = dataTable;
            gridView.Columns[0].Width = 80;
            
        }
        private void LoadNodeInforView()
        {
            DataTable NodeInfo = DBUtility.GetDataFromDB<DataTable>("NodeInfoTable");
            DataTable NodeInforPage1 = NodeInfo.Clone();
            DataTable NodeInforPage2 = NodeInfo.Clone();
            DataRow[] rowsToCopy;
            rowsToCopy = NodeInfo.Select("Node<'29'");
            foreach (DataRow temp in rowsToCopy)
            {
                NodeInforPage1.ImportRow(temp);
            }
            rowsToCopy = NodeInfo.Select("Node>'28'");
            foreach (DataRow temp in rowsToCopy)
            {
                NodeInforPage2.ImportRow(temp);
            }

            dgvNodeInfoPage1.DataSource = NodeInforPage1;
            dgvNodeInfoPage2.DataSource = NodeInforPage2;
        }
        private void myTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
