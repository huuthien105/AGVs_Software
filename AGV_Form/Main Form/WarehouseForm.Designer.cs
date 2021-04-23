
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseForm));
            this.dgvNodeInfo = new System.Windows.Forms.DataGridView();
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.tpNodeInfo = new System.Windows.Forms.TabPage();
            this.tpPalletInfo = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvPalletInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeInfo)).BeginInit();
            this.myTabControl.SuspendLayout();
            this.tpNodeInfo.SuspendLayout();
            this.tpPalletInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalletInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNodeInfo
            // 
            this.dgvNodeInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNodeInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNodeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodeInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvNodeInfo.Name = "dgvNodeInfo";
            this.dgvNodeInfo.ReadOnly = true;
            this.dgvNodeInfo.Size = new System.Drawing.Size(565, 639);
            this.dgvNodeInfo.TabIndex = 0;
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.tpNodeInfo);
            this.myTabControl.Controls.Add(this.tpPalletInfo);
            this.myTabControl.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.myTabControl.Location = new System.Drawing.Point(12, 12);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(1303, 677);
            this.myTabControl.TabIndex = 3;
            // 
            // tpNodeInfo
            // 
            this.tpNodeInfo.Controls.Add(this.dgvNodeInfo);
            this.tpNodeInfo.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.tpNodeInfo.ImageIndex = 0;
            this.tpNodeInfo.Location = new System.Drawing.Point(4, 28);
            this.tpNodeInfo.Name = "tpNodeInfo";
            this.tpNodeInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpNodeInfo.Size = new System.Drawing.Size(1295, 645);
            this.tpNodeInfo.TabIndex = 0;
            this.tpNodeInfo.Text = "Node Map Information";
            this.tpNodeInfo.UseVisualStyleBackColor = true;
            // 
            // tpPalletInfo
            // 
            this.tpPalletInfo.Controls.Add(this.btnDelete);
            this.tpPalletInfo.Controls.Add(this.btnUpdate);
            this.tpPalletInfo.Controls.Add(this.dgvPalletInfo);
            this.tpPalletInfo.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.tpPalletInfo.ImageIndex = 1;
            this.tpPalletInfo.Location = new System.Drawing.Point(4, 28);
            this.tpPalletInfo.Name = "tpPalletInfo";
            this.tpPalletInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPalletInfo.Size = new System.Drawing.Size(1295, 645);
            this.tpPalletInfo.TabIndex = 1;
            this.tpPalletInfo.Text = "Pallet Information";
            this.tpPalletInfo.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.btnDelete.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(582, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 27);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.btnUpdate.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(582, 28);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 27);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // dgvPalletInfo
            // 
            this.dgvPalletInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPalletInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPalletInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalletInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvPalletInfo.Name = "dgvPalletInfo";
            this.dgvPalletInfo.ReadOnly = true;
            this.dgvPalletInfo.Size = new System.Drawing.Size(565, 437);
            this.dgvPalletInfo.TabIndex = 0;
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myTabControl);
            this.Name = "WarehouseForm";
            this.Text = "WarehouseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeInfo)).EndInit();
            this.myTabControl.ResumeLayout(false);
            this.tpNodeInfo.ResumeLayout(false);
            this.tpPalletInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalletInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNodeInfo;
        private System.Windows.Forms.TabControl myTabControl;
        private System.Windows.Forms.TabPage tpNodeInfo;
        private System.Windows.Forms.TabPage tpPalletInfo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvPalletInfo;
    }
}