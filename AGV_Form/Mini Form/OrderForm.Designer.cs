
namespace AGV_Form
{
    partial class OrderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewPalletSelected = new System.Windows.Forms.ListView();
            this.imgPallet = new System.Windows.Forms.ImageList(this.components);
            this.btnOrder = new System.Windows.Forms.Button();
            this.lstvwPalletInStock = new System.Windows.Forms.ListView();
            this.pallet_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stored_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.at_block = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.at_column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.at_level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewTask = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerListView = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbMode = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.Lavender;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.listViewPalletSelected);
            this.groupBox3.Controls.Add(this.btnOrder);
            this.groupBox3.Controls.Add(this.lstvwPalletInStock);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(12, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(649, 283);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order pallets in stock:";
            // 
            // listViewPalletSelected
            // 
            this.listViewPalletSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.listViewPalletSelected.HideSelection = false;
            this.listViewPalletSelected.Location = new System.Drawing.Point(15, 46);
            this.listViewPalletSelected.Name = "listViewPalletSelected";
            this.listViewPalletSelected.Size = new System.Drawing.Size(95, 171);
            this.listViewPalletSelected.SmallImageList = this.imgPallet;
            this.listViewPalletSelected.TabIndex = 34;
            this.listViewPalletSelected.UseCompatibleStateImageBehavior = false;
            this.listViewPalletSelected.View = System.Windows.Forms.View.SmallIcon;
            // 
            // imgPallet
            // 
            this.imgPallet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPallet.ImageStream")));
            this.imgPallet.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPallet.Images.SetKeyName(0, "icon_pallet.png");
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(51, 223);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(59, 34);
            this.btnOrder.TabIndex = 29;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lstvwPalletInStock
            // 
            this.lstvwPalletInStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvwPalletInStock.CheckBoxes = true;
            this.lstvwPalletInStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pallet_code,
            this.stored_time,
            this.at_block,
            this.at_column,
            this.at_level});
            this.lstvwPalletInStock.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lstvwPalletInStock.FullRowSelect = true;
            this.lstvwPalletInStock.HideSelection = false;
            this.lstvwPalletInStock.Location = new System.Drawing.Point(120, 26);
            this.lstvwPalletInStock.Name = "lstvwPalletInStock";
            this.lstvwPalletInStock.Size = new System.Drawing.Size(519, 246);
            this.lstvwPalletInStock.SmallImageList = this.imgPallet;
            this.lstvwPalletInStock.TabIndex = 28;
            this.lstvwPalletInStock.UseCompatibleStateImageBehavior = false;
            this.lstvwPalletInStock.View = System.Windows.Forms.View.Details;
            this.lstvwPalletInStock.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstvwPalletInStock_ItemChecked);
            // 
            // pallet_code
            // 
            this.pallet_code.Text = "Pallet Code";
            this.pallet_code.Width = 120;
            // 
            // stored_time
            // 
            this.stored_time.Text = "Stored Time";
            this.stored_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stored_time.Width = 150;
            // 
            // at_block
            // 
            this.at_block.Text = "Block";
            this.at_block.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.at_block.Width = 75;
            // 
            // at_column
            // 
            this.at_column.Text = "Column";
            this.at_column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.at_column.Width = 75;
            // 
            // at_level
            // 
            this.at_level.Text = "Level";
            this.at_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.at_level.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.listViewTask);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(12, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 177);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Of Task";
            // 
            // listViewTask
            // 
            this.listViewTask.BackColor = System.Drawing.Color.White;
            this.listViewTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewTask.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.listViewTask.HideSelection = false;
            this.listViewTask.Location = new System.Drawing.Point(15, 26);
            this.listViewTask.Name = "listViewTask";
            this.listViewTask.Size = new System.Drawing.Size(624, 145);
            this.listViewTask.TabIndex = 1;
            this.listViewTask.UseCompatibleStateImageBehavior = false;
            this.listViewTask.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Task Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "AGV";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pick Node";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Drop Node";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Pallet Code";
            this.columnHeader7.Width = 85;
            // 
            // timerListView
            // 
            this.timerListView.Enabled = true;
            this.timerListView.Interval = 200;
            this.timerListView.Tick += new System.EventHandler(this.timerListView_Tick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "Pallet Selected:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbMode);
            this.groupBox2.Location = new System.Drawing.Point(12, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(649, 44);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // lbMode
            // 
            this.lbMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lbMode.Location = new System.Drawing.Point(171, 11);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(315, 27);
            this.lbMode.TabIndex = 12;
            this.lbMode.Text = "Please select Mode !";
            this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstvwPalletInStock;
        private System.Windows.Forms.ColumnHeader pallet_code;
        private System.Windows.Forms.ColumnHeader stored_time;
        private System.Windows.Forms.ColumnHeader at_block;
        private System.Windows.Forms.ColumnHeader at_column;
        private System.Windows.Forms.ColumnHeader at_level;
        private System.Windows.Forms.ImageList imgPallet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewTask;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Timer timerListView;
        private System.Windows.Forms.ListView listViewPalletSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbMode;
    }
}