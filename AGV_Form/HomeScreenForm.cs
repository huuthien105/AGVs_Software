using AGV_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGV_Form
{
    public partial class HomeScreenForm : Form
    {
        public HomeScreenForm()
        {
            InitializeComponent();
           
           

        }
        private static DashboardForm dashboardForm = new DashboardForm();
        //private static MonitoringForm 

        private static TasksForm taksForm = new TasksForm();
       


        private void HomeScreenForm_Load(object sender, EventArgs e)
        {
            Initial_Form(dashboardForm);
            Initial_Form(taksForm);
            pnMain.Controls.Add(dashboardForm);
            dashboardForm.BringToFront();
            dashboardForm.Show();
            

        }

        private void dashoardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pnMain.Controls.Clear();
            pnMain.Controls.Add(dashboardForm);
            dashboardForm.BringToFront();
            dashboardForm.Show();

        }

        private void monitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            MonitoringForm monitoringForm = new MonitoringForm();
            Initial_Form(monitoringForm);
            pnMain.Controls.Add(monitoringForm);
            monitoringForm.BringToFront();
            monitoringForm.Show();
            if (Display.Mode == "Real Time")
                monitoringForm.Enabled = true;
            else monitoringForm.Enabled = false;
        }

        private void tasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            pnMain.Controls.Clear();
            pnMain.Controls.Add(taksForm);
            taksForm.BringToFront();
            taksForm.Show();

        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarehouseForm warehouseForm = new WarehouseForm();
            Initial_Form(warehouseForm);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(warehouseForm);
            warehouseForm.BringToFront();
            warehouseForm.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            Initial_Form(reportForm);
            pnMain.Controls.Add(reportForm);
            reportForm.BringToFront();
            reportForm.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            Initial_Form(helpForm);
            pnMain.Controls.Add(helpForm);
            helpForm.BringToFront();
            helpForm.Show();
        }

 
        public static List<string> textComStatus = new List<string>();
        public static List<Color> colorComStatus = new List<Color>();
        
            //Display.UpdateComStatus(1);
            //Display.UpdateComStatus(1, Color.Red);
            //Display.UpdateComStatus(2, Color.Green);
            //Label lbAGV = new Label();
            //lbAGV.BackColor = SystemColors.ActiveCaption;
            //lbAGV.Font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
            //System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // lbAGV.Size = new Size(50, 50);
            //lbAGV.Text = "AGV#1";//+ agvID.ToString();
            // lbAGV.TextAlign = ContentAlignment.MiddleCenter;
            //lbAGV.Name = "AGV1" ;
            // lbAGV.Location = new Point(635, 328);
            //dashboard1.
            //form1.Close();
            
        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private static void Initial_Form(Form form)
        {
            form.TopLevel = false;            
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            // Show time now
            DateTime time = DateTime.Now;
            lbTime.Text = time.ToString("dddd, MMMM dd, yyyy  |  h:mm:ss tt");
        }
    }
}
