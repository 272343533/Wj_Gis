namespace TDObject.UI
{
    partial class frmLtdTotalInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv11 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.clnItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRegionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv11)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv11
            // 
            this.dgv11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv11.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnItemName,
            this.clnRegionCode,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.clnDetail});
            this.dgv11.Location = new System.Drawing.Point(12, 45);
            this.dgv11.Name = "dgv11";
            this.dgv11.ReadOnly = true;
            this.dgv11.RowTemplate.Height = 23;
            this.dgv11.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv11.Size = new System.Drawing.Size(961, 341);
            this.dgv11.TabIndex = 5;
            this.dgv11.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv11_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(413, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "地块明细信息";
            // 
            // clnItemName
            // 
            this.clnItemName.DataPropertyName = "LtdName";
            this.clnItemName.Frozen = true;
            this.clnItemName.HeaderText = "企业名称";
            this.clnItemName.Name = "clnItemName";
            this.clnItemName.ReadOnly = true;
            this.clnItemName.Width = 300;
            // 
            // clnRegionCode
            // 
            this.clnRegionCode.DataPropertyName = "RegionCode";
            this.clnRegionCode.HeaderText = "地块编号";
            this.clnRegionCode.Name = "clnRegionCode";
            this.clnRegionCode.ReadOnly = true;
            this.clnRegionCode.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RegionArea";
            this.dataGridViewTextBoxColumn4.HeaderText = "占地面积";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FloorArea";
            this.dataGridViewTextBoxColumn6.HeaderText = "建筑占地面积";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BuildingArea";
            this.dataGridViewTextBoxColumn7.HeaderText = "建筑面积";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // clnDetail
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "详情";
            this.clnDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.clnDetail.HeaderText = "操作";
            this.clnDetail.Name = "clnDetail";
            this.clnDetail.ReadOnly = true;
            this.clnDetail.Text = "";
            this.clnDetail.Width = 50;
            // 
            // frmLtdTotalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 398);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv11);
            this.Name = "frmLtdTotalInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地块信息";
            this.Load += new System.EventHandler(this.frmLtdTotalInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRegionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn clnDetail;
    }
}