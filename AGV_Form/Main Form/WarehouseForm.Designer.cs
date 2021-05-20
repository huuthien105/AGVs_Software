
namespace AGV_Form
{
    partial class WarehouseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.tpPalletInfo = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbRealTotalPallet = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvRealPalletInfo = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbRealTotalTask = new System.Windows.Forms.Label();
            this.dgvRealHisTaskInfo = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lbSimTotalPallet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvSimPalletInfo = new System.Windows.Forms.DataGridView();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lbSimTotalTask = new System.Windows.Forms.Label();
            this.dgvSimHisTaskInfo = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbNumSimListAGV = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSimListAGV = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbNumAGV = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvListAGV = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvNodeInfoPage2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvNodeInfoPage1 = new System.Windows.Forms.DataGridView();
            this.lbMode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.myTabControl.SuspendLayout();
            this.tpPalletInfo.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealPalletInfo)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealHisTaskInfo)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimPalletInfo)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimHisTaskInfo)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimListAGV)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAGV)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeInfoPage2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeInfoPage1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.tpPalletInfo);
            this.myTabControl.Controls.Add(this.tabPage1);
            this.myTabControl.Controls.Add(this.tabPage2);
            this.myTabControl.Controls.Add(this.tabPage3);
            this.myTabControl.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.myTabControl.HotTrack = true;
            this.myTabControl.Location = new System.Drawing.Point(16, 41);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(1325, 623);
            this.myTabControl.TabIndex = 3;
            this.myTabControl.SelectedIndexChanged += new System.EventHandler(this.myTabControl_SelectedIndexChanged);
            // 
            // tpPalletInfo
            // 
            this.tpPalletInfo.Controls.Add(this.groupBox6);
            this.tpPalletInfo.Controls.Add(this.groupBox7);
            this.tpPalletInfo.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.tpPalletInfo.ImageIndex = 1;
            this.tpPalletInfo.Location = new System.Drawing.Point(4, 28);
            this.tpPalletInfo.Name = "tpPalletInfo";
            this.tpPalletInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPalletInfo.Size = new System.Drawing.Size(1317, 591);
            this.tpPalletInfo.TabIndex = 1;
            this.tpPalletInfo.Text = "Real Time Pallet Information ";
            this.tpPalletInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.BackColor = System.Drawing.Color.Lavender;
            this.groupBox6.Controls.Add(this.lbRealTotalPallet);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.dgvRealPalletInfo);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Navy;
            this.groupBox6.Location = new System.Drawing.Point(2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1296, 291);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Infomation Pallet in Stock";
            // 
            // lbRealTotalPallet
            // 
            this.lbRealTotalPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRealTotalPallet.AutoSize = true;
            this.lbRealTotalPallet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRealTotalPallet.ForeColor = System.Drawing.Color.Navy;
            this.lbRealTotalPallet.Location = new System.Drawing.Point(1034, 266);
            this.lbRealTotalPallet.Name = "lbRealTotalPallet";
            this.lbRealTotalPallet.Size = new System.Drawing.Size(18, 20);
            this.lbRealTotalPallet.TabIndex = 12;
            this.lbRealTotalPallet.Text = "0";
            this.lbRealTotalPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(952, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Total Pallet:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRealPalletInfo
            // 
            this.dgvRealPalletInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRealPalletInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRealPalletInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRealPalletInfo.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgvRealPalletInfo.Location = new System.Drawing.Point(6, 27);
            this.dgvRealPalletInfo.Name = "dgvRealPalletInfo";
            this.dgvRealPalletInfo.ReadOnly = true;
            this.dgvRealPalletInfo.RowHeadersWidth = 30;
            this.dgvRealPalletInfo.Size = new System.Drawing.Size(940, 259);
            this.dgvRealPalletInfo.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.BackColor = System.Drawing.Color.Lavender;
            this.groupBox7.Controls.Add(this.lbRealTotalTask);
            this.groupBox7.Controls.Add(this.dgvRealHisTaskInfo);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.Navy;
            this.groupBox7.Location = new System.Drawing.Point(3, 299);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1295, 289);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "History Pallet Import/Export:";
            // 
            // lbRealTotalTask
            // 
            this.lbRealTotalTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRealTotalTask.AutoSize = true;
            this.lbRealTotalTask.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRealTotalTask.ForeColor = System.Drawing.Color.Navy;
            this.lbRealTotalTask.Location = new System.Drawing.Point(1031, 262);
            this.lbRealTotalTask.Name = "lbRealTotalTask";
            this.lbRealTotalTask.Size = new System.Drawing.Size(18, 20);
            this.lbRealTotalTask.TabIndex = 14;
            this.lbRealTotalTask.Text = "0";
            this.lbRealTotalTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRealHisTaskInfo
            // 
            this.dgvRealHisTaskInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRealHisTaskInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRealHisTaskInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRealHisTaskInfo.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvRealHisTaskInfo.Location = new System.Drawing.Point(3, 25);
            this.dgvRealHisTaskInfo.Name = "dgvRealHisTaskInfo";
            this.dgvRealHisTaskInfo.ReadOnly = true;
            this.dgvRealHisTaskInfo.RowHeadersWidth = 30;
            this.dgvRealHisTaskInfo.Size = new System.Drawing.Size(942, 257);
            this.dgvRealHisTaskInfo.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(951, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Total Task:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1317, 591);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Simulation Pallet Information ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.BackColor = System.Drawing.Color.Lavender;
            this.groupBox8.Controls.Add(this.lbSimTotalPallet);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.dgvSimPalletInfo);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.Navy;
            this.groupBox8.Location = new System.Drawing.Point(2, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1296, 291);
            this.groupBox8.TabIndex = 42;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Infomation Pallet in Stock";
            // 
            // lbSimTotalPallet
            // 
            this.lbSimTotalPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSimTotalPallet.AutoSize = true;
            this.lbSimTotalPallet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSimTotalPallet.ForeColor = System.Drawing.Color.Navy;
            this.lbSimTotalPallet.Location = new System.Drawing.Point(1034, 266);
            this.lbSimTotalPallet.Name = "lbSimTotalPallet";
            this.lbSimTotalPallet.Size = new System.Drawing.Size(18, 20);
            this.lbSimTotalPallet.TabIndex = 12;
            this.lbSimTotalPallet.Text = "0";
            this.lbSimTotalPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(952, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total Pallet:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSimPalletInfo
            // 
            this.dgvSimPalletInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSimPalletInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSimPalletInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSimPalletInfo.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvSimPalletInfo.Location = new System.Drawing.Point(6, 27);
            this.dgvSimPalletInfo.Name = "dgvSimPalletInfo";
            this.dgvSimPalletInfo.ReadOnly = true;
            this.dgvSimPalletInfo.RowHeadersWidth = 30;
            this.dgvSimPalletInfo.Size = new System.Drawing.Size(940, 259);
            this.dgvSimPalletInfo.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.BackColor = System.Drawing.Color.Lavender;
            this.groupBox9.Controls.Add(this.lbSimTotalTask);
            this.groupBox9.Controls.Add(this.dgvSimHisTaskInfo);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Navy;
            this.groupBox9.Location = new System.Drawing.Point(3, 299);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1295, 289);
            this.groupBox9.TabIndex = 41;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "History Pallet Import/Export:";
            // 
            // lbSimTotalTask
            // 
            this.lbSimTotalTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSimTotalTask.AutoSize = true;
            this.lbSimTotalTask.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSimTotalTask.ForeColor = System.Drawing.Color.Navy;
            this.lbSimTotalTask.Location = new System.Drawing.Point(1031, 262);
            this.lbSimTotalTask.Name = "lbSimTotalTask";
            this.lbSimTotalTask.Size = new System.Drawing.Size(18, 20);
            this.lbSimTotalTask.TabIndex = 14;
            this.lbSimTotalTask.Text = "0";
            this.lbSimTotalTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSimHisTaskInfo
            // 
            this.dgvSimHisTaskInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSimHisTaskInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSimHisTaskInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSimHisTaskInfo.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvSimHisTaskInfo.Location = new System.Drawing.Point(3, 25);
            this.dgvSimHisTaskInfo.Name = "dgvSimHisTaskInfo";
            this.dgvSimHisTaskInfo.ReadOnly = true;
            this.dgvSimHisTaskInfo.RowHeadersWidth = 30;
            this.dgvSimHisTaskInfo.Size = new System.Drawing.Size(942, 257);
            this.dgvSimHisTaskInfo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(951, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Total Task:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1317, 591);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "List AGVs";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.Lavender;
            this.groupBox5.Controls.Add(this.lbNumSimListAGV);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.dgvSimListAGV);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(649, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(859, 544);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Simulation AGV List";
            // 
            // lbNumSimListAGV
            // 
            this.lbNumSimListAGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNumSimListAGV.AutoSize = true;
            this.lbNumSimListAGV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumSimListAGV.ForeColor = System.Drawing.Color.Navy;
            this.lbNumSimListAGV.Location = new System.Drawing.Point(110, 24);
            this.lbNumSimListAGV.Name = "lbNumSimListAGV";
            this.lbNumSimListAGV.Size = new System.Drawing.Size(18, 20);
            this.lbNumSimListAGV.TabIndex = 10;
            this.lbNumSimListAGV.Text = "0";
            this.lbNumSimListAGV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(15, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number AGV:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSimListAGV
            // 
            this.dgvSimListAGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSimListAGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSimListAGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvSimListAGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSimListAGV.DefaultCellStyle = dataGridViewCellStyle30;
            this.dgvSimListAGV.Location = new System.Drawing.Point(9, 49);
            this.dgvSimListAGV.Name = "dgvSimListAGV";
            this.dgvSimListAGV.ReadOnly = true;
            this.dgvSimListAGV.Size = new System.Drawing.Size(622, 456);
            this.dgvSimListAGV.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Lavender;
            this.groupBox4.Controls.Add(this.lbNumAGV);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dgvListAGV);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(3, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(640, 544);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Real Time AGV List";
            // 
            // lbNumAGV
            // 
            this.lbNumAGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNumAGV.AutoSize = true;
            this.lbNumAGV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumAGV.ForeColor = System.Drawing.Color.Navy;
            this.lbNumAGV.Location = new System.Drawing.Point(107, 24);
            this.lbNumAGV.Name = "lbNumAGV";
            this.lbNumAGV.Size = new System.Drawing.Size(18, 20);
            this.lbNumAGV.TabIndex = 10;
            this.lbNumAGV.Text = "0";
            this.lbNumAGV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number AGV:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvListAGV
            // 
            this.dgvListAGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListAGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListAGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvListAGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListAGV.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgvListAGV.Location = new System.Drawing.Point(9, 49);
            this.dgvListAGV.Name = "dgvListAGV";
            this.dgvListAGV.ReadOnly = true;
            this.dgvListAGV.Size = new System.Drawing.Size(622, 456);
            this.dgvListAGV.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1317, 591);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Node Information";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Lavender;
            this.groupBox3.Controls.Add(this.dgvNodeInfoPage2);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(639, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(627, 585);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "From Node 29 To Node 56";
            // 
            // dgvNodeInfoPage2
            // 
            this.dgvNodeInfoPage2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNodeInfoPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNodeInfoPage2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodeInfoPage2.Location = new System.Drawing.Point(17, 26);
            this.dgvNodeInfoPage2.Name = "dgvNodeInfoPage2";
            this.dgvNodeInfoPage2.ReadOnly = true;
            this.dgvNodeInfoPage2.Size = new System.Drawing.Size(580, 534);
            this.dgvNodeInfoPage2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.dgvNodeInfoPage1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 585);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From Node 1 To Node 28";
            // 
            // dgvNodeInfoPage1
            // 
            this.dgvNodeInfoPage1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNodeInfoPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNodeInfoPage1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodeInfoPage1.Location = new System.Drawing.Point(17, 26);
            this.dgvNodeInfoPage1.Name = "dgvNodeInfoPage1";
            this.dgvNodeInfoPage1.ReadOnly = true;
            this.dgvNodeInfoPage1.Size = new System.Drawing.Size(580, 534);
            this.dgvNodeInfoPage1.TabIndex = 2;
            // 
            // lbMode
            // 
            this.lbMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.Crimson;
            this.lbMode.Location = new System.Drawing.Point(302, 11);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(465, 27);
            this.lbMode.TabIndex = 12;
            this.lbMode.Text = "Welcome to My Warehouse Database !";
            this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.lbMode);
            this.groupBox2.Location = new System.Drawing.Point(-4, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1364, 694);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(16, 658);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tab: Warehouse";
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myTabControl);
            this.Controls.Add(this.groupBox2);
            this.Name = "WarehouseForm";
            this.Text = "WarehouseForm";
            this.Load += new System.EventHandler(this.WarehouseForm_Load);
            this.myTabControl.ResumeLayout(false);
            this.tpPalletInfo.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealPalletInfo)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealHisTaskInfo)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimPalletInfo)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimHisTaskInfo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimListAGV)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAGV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeInfoPage2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeInfoPage1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl myTabControl;
        private System.Windows.Forms.TabPage tpPalletInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvNodeInfoPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvNodeInfoPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvListAGV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbNumAGV;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbNumSimListAGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvSimListAGV;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvRealHisTaskInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvRealPalletInfo;
        private System.Windows.Forms.Label lbRealTotalPallet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbRealTotalTask;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lbSimTotalPallet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvSimPalletInfo;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lbSimTotalTask;
        private System.Windows.Forms.DataGridView dgvSimHisTaskInfo;
        private System.Windows.Forms.Label label11;
    }
}