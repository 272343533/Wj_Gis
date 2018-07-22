namespace TDObject.UI
{
    partial class frmLnpcQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLnpc = new System.Windows.Forms.DataGridView();
            this.btnRowSave = new System.Windows.Forms.Button();
            this.btnTableSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLnpc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLnpc
            // 
            this.dgvLnpc.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvLnpc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLnpc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLnpc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLnpc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column10,
            this.Column8,
            this.Column6,
            this.Column9,
            this.Column7});
            this.dgvLnpc.Location = new System.Drawing.Point(2, 2);
            this.dgvLnpc.Name = "dgvLnpc";
            this.dgvLnpc.RowTemplate.Height = 23;
            this.dgvLnpc.Size = new System.Drawing.Size(960, 498);
            this.dgvLnpc.TabIndex = 0;
            // 
            // btnRowSave
            // 
            this.btnRowSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRowSave.Location = new System.Drawing.Point(419, 508);
            this.btnRowSave.Name = "btnRowSave";
            this.btnRowSave.Size = new System.Drawing.Size(75, 23);
            this.btnRowSave.TabIndex = 1;
            this.btnRowSave.Text = "保存";
            this.btnRowSave.UseVisualStyleBackColor = true;
            this.btnRowSave.Click += new System.EventHandler(this.btnRowSave_Click);
            // 
            // btnTableSave
            // 
            this.btnTableSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTableSave.Location = new System.Drawing.Point(598, 508);
            this.btnTableSave.Name = "btnTableSave";
            this.btnTableSave.Size = new System.Drawing.Size(75, 23);
            this.btnTableSave.TabIndex = 2;
            this.btnTableSave.Text = "全部保存";
            this.btnTableSave.UseVisualStyleBackColor = true;
            this.btnTableSave.Visible = false;
            this.btnTableSave.Click += new System.EventHandler(this.btnTableSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "objectId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "地块编码";
            this.dataGridViewTextBoxColumn2.HeaderText = "地块编码";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "批次号";
            this.dataGridViewTextBoxColumn3.HeaderText = "批次号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "批准项目名称";
            this.dataGridViewTextBoxColumn4.HeaderText = "批准项目名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "所属行政村代码";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "所属行政村代码";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "所属行政镇代码";
            this.dataGridViewTextBoxColumn6.HeaderText = "所属行政镇代码";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "所属行政村名称";
            this.dataGridViewTextBoxColumn7.HeaderText = "所属行政村名称";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "所属行政镇名称";
            this.dataGridViewTextBoxColumn8.HeaderText = "所属行政镇名称";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "占地面积";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn9.HeaderText = "占地面积(m2)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "objectId";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "地块编码";
            this.Column2.HeaderText = "地块编码";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "批次号";
            this.Column3.HeaderText = "批次号";
            this.Column3.Name = "Column3";
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "批准年份";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column4.HeaderText = "批准年份";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "批准项目名称";
            this.Column5.HeaderText = "批准项目名称";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "占地面积";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column10.HeaderText = "占地面积(m2)";
            this.Column10.Name = "Column10";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "所属行政村名称";
            this.Column8.HeaderText = "所属行政村名称";
            this.Column8.Name = "Column8";
            this.Column8.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "所属行政村代码";
            this.Column6.HeaderText = "所属行政村代码";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "所属行政镇名称";
            this.Column9.HeaderText = "所属行政镇名称";
            this.Column9.Name = "Column9";
            this.Column9.Width = 120;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "所属行政镇代码";
            this.Column7.HeaderText = "所属行政镇代码";
            this.Column7.Name = "Column7";
            this.Column7.Width = 120;
            // 
            // frmLnpcQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 543);
            this.Controls.Add(this.btnTableSave);
            this.Controls.Add(this.btnRowSave);
            this.Controls.Add(this.dgvLnpc);
            this.Name = "frmLnpcQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "历年批次维护";
            this.Load += new System.EventHandler(this.frmLnpcQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLnpc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLnpc;
        private System.Windows.Forms.Button btnRowSave;
        private System.Windows.Forms.Button btnTableSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}