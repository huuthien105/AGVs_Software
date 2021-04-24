
namespace AGV_Form
{
    partial class StoreForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewTask = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStore = new System.Windows.Forms.Button();
            this.cbbLevel = new System.Windows.Forms.ComboBox();
            this.cbbColumn = new System.Windows.Forms.ComboBox();
            this.cbbBlock = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPalletCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.listViewTask);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(12, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 177);
            this.groupBox1.TabIndex = 34;
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
            this.listViewTask.Size = new System.Drawing.Size(571, 145);
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.Lavender;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnStore);
            this.groupBox3.Controls.Add(this.cbbLevel);
            this.groupBox3.Controls.Add(this.cbbColumn);
            this.groupBox3.Controls.Add(this.cbbBlock);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtPalletCode);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(27, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 243);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Store pallets into stock:";
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(295, 137);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(75, 36);
            this.btnStore.TabIndex = 25;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // cbbLevel
            // 
            this.cbbLevel.FormattingEnabled = true;
            this.cbbLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbbLevel.Location = new System.Drawing.Point(109, 142);
            this.cbbLevel.Name = "cbbLevel";
            this.cbbLevel.Size = new System.Drawing.Size(70, 28);
            this.cbbLevel.TabIndex = 24;
            // 
            // cbbColumn
            // 
            this.cbbColumn.FormattingEnabled = true;
            this.cbbColumn.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbbColumn.Location = new System.Drawing.Point(109, 103);
            this.cbbColumn.Name = "cbbColumn";
            this.cbbColumn.Size = new System.Drawing.Size(70, 28);
            this.cbbColumn.TabIndex = 23;
            // 
            // cbbBlock
            // 
            this.cbbBlock.FormattingEnabled = true;
            this.cbbBlock.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cbbBlock.Location = new System.Drawing.Point(109, 64);
            this.cbbBlock.Name = "cbbBlock";
            this.cbbBlock.Size = new System.Drawing.Size(70, 28);
            this.cbbBlock.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(22, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Level:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(22, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Column:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(22, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Block:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(22, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Pallet Code:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPalletCode
            // 
            this.txtPalletCode.Location = new System.Drawing.Point(109, 26);
            this.txtPalletCode.Name = "txtPalletCode";
            this.txtPalletCode.Size = new System.Drawing.Size(100, 27);
            this.txtPalletCode.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "label4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "label7";
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "StoreForm";
            this.Text = "StoreForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewTask;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPalletCode;
        private System.Windows.Forms.ComboBox cbbLevel;
        private System.Windows.Forms.ComboBox cbbColumn;
        private System.Windows.Forms.ComboBox cbbBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}