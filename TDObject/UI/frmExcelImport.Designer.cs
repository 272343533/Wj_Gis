namespace TDObject.UI
{
    partial class frmExcelImport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.qyBtn_Map = new QyTech.SkinForm.Controls.qyBtn();
            this.qyBtnSearch = new QyTech.SkinForm.Controls.qyBtn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.qyBtnFile = new QyTech.SkinForm.Controls.qyBtn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvExcel = new QyTech.SkinForm.Controls.qyDgv();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvImported = new QyTech.SkinForm.Controls.qyDgv();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvUnImported = new QyTech.SkinForm.Controls.qyDgv();
            this.qyBtnImport = new QyTech.SkinForm.Controls.qyBtn();
            this.pbrExcelImport = new QyTech.SkinForm.Controls.qyPbr();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.qyBtnQueryDb = new QyTech.SkinForm.Controls.qyBtn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.qyDgv_Table = new QyTech.SkinForm.Controls.qyDgv();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImported)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnImported)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qyDgv_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // qyBtn_Map
            // 
            this.qyBtn_Map.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.qyBtn_Map.Location = new System.Drawing.Point(125, 490);
            this.qyBtn_Map.Name = "qyBtn_Map";
            this.qyBtn_Map.Size = new System.Drawing.Size(58, 23);
            this.qyBtn_Map.TabIndex = 39;
            this.qyBtn_Map.Text = "列对应";
            this.qyBtn_Map.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.qyBtn_Map.UseVisualStyleBackColor = true;
            this.qyBtn_Map.Click += new System.EventHandler(this.qyBtn_Map_Click);
            // 
            // qyBtnSearch
            // 
            this.qyBtnSearch.Location = new System.Drawing.Point(262, 39);
            this.qyBtnSearch.Name = "qyBtnSearch";
            this.qyBtnSearch.Size = new System.Drawing.Size(79, 23);
            this.qyBtnSearch.TabIndex = 38;
            this.qyBtnSearch.Text = "显示数据";
            this.qyBtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.qyBtnSearch.UseVisualStyleBackColor = true;
            this.qyBtnSearch.Click += new System.EventHandler(this.qyBtnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(88, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(550, 21);
            this.textBox1.TabIndex = 36;
            // 
            // qyBtnFile
            // 
            this.qyBtnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qyBtnFile.Location = new System.Drawing.Point(644, 15);
            this.qyBtnFile.Name = "qyBtnFile";
            this.qyBtnFile.Size = new System.Drawing.Size(101, 23);
            this.qyBtnFile.TabIndex = 37;
            this.qyBtnFile.Text = "选择Excel文件";
            this.qyBtnFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.qyBtnFile.UseVisualStyleBackColor = true;
            this.qyBtnFile.Click += new System.EventHandler(this.qyBtnFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "Excel文件名";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(13, 57);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(732, 424);
            this.tabControl2.TabIndex = 40;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvExcel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(724, 398);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Excel数据";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.AllowUserToResizeColumns = false;
            this.dgvExcel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvExcel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExcel.BackgroundColor = System.Drawing.Color.White;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExcel.Location = new System.Drawing.Point(3, 3);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.RowTemplate.Height = 23;
            this.dgvExcel.Size = new System.Drawing.Size(718, 392);
            this.dgvExcel.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvImported);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(724, 398);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "数据库数据";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvImported
            // 
            this.dgvImported.AllowUserToAddRows = false;
            this.dgvImported.AllowUserToDeleteRows = false;
            this.dgvImported.AllowUserToResizeColumns = false;
            this.dgvImported.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvImported.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvImported.BackgroundColor = System.Drawing.Color.White;
            this.dgvImported.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImported.Location = new System.Drawing.Point(3, 3);
            this.dgvImported.Name = "dgvImported";
            this.dgvImported.RowTemplate.Height = 23;
            this.dgvImported.Size = new System.Drawing.Size(718, 392);
            this.dgvImported.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvUnImported);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(724, 398);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "未导入数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvUnImported
            // 
            this.dgvUnImported.AllowUserToAddRows = false;
            this.dgvUnImported.AllowUserToDeleteRows = false;
            this.dgvUnImported.AllowUserToResizeColumns = false;
            this.dgvUnImported.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvUnImported.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUnImported.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnImported.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnImported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnImported.Location = new System.Drawing.Point(0, 0);
            this.dgvUnImported.Name = "dgvUnImported";
            this.dgvUnImported.RowTemplate.Height = 23;
            this.dgvUnImported.Size = new System.Drawing.Size(724, 398);
            this.dgvUnImported.TabIndex = 3;
            // 
            // qyBtnImport
            // 
            this.qyBtnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.qyBtnImport.Location = new System.Drawing.Point(662, 494);
            this.qyBtnImport.Name = "qyBtnImport";
            this.qyBtnImport.Size = new System.Drawing.Size(92, 23);
            this.qyBtnImport.TabIndex = 41;
            this.qyBtnImport.Text = "导入数据库";
            this.qyBtnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.qyBtnImport.UseVisualStyleBackColor = true;
            this.qyBtnImport.Click += new System.EventHandler(this.qyBtnImport_Click);
            // 
            // pbrExcelImport
            // 
            this.pbrExcelImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrExcelImport.Location = new System.Drawing.Point(13, 480);
            this.pbrExcelImport.Name = "pbrExcelImport";
            this.pbrExcelImport.Size = new System.Drawing.Size(731, 13);
            this.pbrExcelImport.TabIndex = 42;
            this.pbrExcelImport.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "选择要导入的数据表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "选择Sheet";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 20);
            this.comboBox1.TabIndex = 46;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkDel
            // 
            this.chkDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDel.AutoSize = true;
            this.chkDel.Checked = true;
            this.chkDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDel.Location = new System.Drawing.Point(482, 497);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(144, 16);
            this.chkDel.TabIndex = 48;
            this.chkDel.Text = "导入数据包含已有数据";
            this.chkDel.UseVisualStyleBackColor = true;
            // 
            // qyBtnQueryDb
            // 
            this.qyBtnQueryDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.qyBtnQueryDb.Location = new System.Drawing.Point(14, 490);
            this.qyBtnQueryDb.Name = "qyBtnQueryDb";
            this.qyBtnQueryDb.Size = new System.Drawing.Size(68, 23);
            this.qyBtnQueryDb.TabIndex = 49;
            this.qyBtnQueryDb.Text = "查看";
            this.qyBtnQueryDb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.qyBtnQueryDb.UseVisualStyleBackColor = true;
            this.qyBtnQueryDb.Click += new System.EventHandler(this.qyBtnQueryDb_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.qyDgv_Table);
            this.splitContainer1.Panel1.Controls.Add(this.qyBtnQueryDb);
            this.splitContainer1.Panel1.Controls.Add(this.qyBtn_Map);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.qyBtnImport);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.chkDel);
            this.splitContainer1.Panel2.Controls.Add(this.qyBtnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.pbrExcelImport);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel2.Controls.Add(this.qyBtnFile);
            this.splitContainer1.Size = new System.Drawing.Size(981, 521);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 51;
            // 
            // qyDgv_Table
            // 
            this.qyDgv_Table.AllowUserToDeleteRows = false;
            this.qyDgv_Table.AllowUserToResizeColumns = false;
            this.qyDgv_Table.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.qyDgv_Table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.qyDgv_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qyDgv_Table.BackgroundColor = System.Drawing.Color.White;
            this.qyDgv_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qyDgv_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column2,
            this.Column1});
            this.qyDgv_Table.Location = new System.Drawing.Point(3, 33);
            this.qyDgv_Table.Name = "qyDgv_Table";
            this.qyDgv_Table.RowTemplate.Height = 23;
            this.qyDgv_Table.Size = new System.Drawing.Size(214, 444);
            this.qyDgv_Table.TabIndex = 0;
            this.qyDgv_Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.qyDgv_Table_CellClick);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "bsT_Id";
            this.Column3.HeaderText = "bsT_Id";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TName";
            this.Column2.HeaderText = "表名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Desp";
            this.Column1.HeaderText = "数据表名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Desp";
            this.dataGridViewTextBoxColumn1.HeaderText = "数据表";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TName";
            this.dataGridViewTextBoxColumn2.HeaderText = "表名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // frmExcelImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 549);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmExcelImport";
            this.Text = "frmExcelImport";
            this.Load += new System.EventHandler(this.frmExcelImport_Load);
            this.Shown += new System.EventHandler(this.frmExcelImport_Shown);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImported)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnImported)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qyDgv_Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QyTech.SkinForm.Controls.qyBtn qyBtn_Map;
        private QyTech.SkinForm.Controls.qyBtn qyBtnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private QyTech.SkinForm.Controls.qyBtn qyBtnFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private QyTech.SkinForm.Controls.qyDgv dgvExcel;
        private System.Windows.Forms.TabPage tabPage5;
        private QyTech.SkinForm.Controls.qyBtn qyBtnImport;
        private QyTech.SkinForm.Controls.qyPbr pbrExcelImport;
        private System.Windows.Forms.TabPage tabPage2;
        private QyTech.SkinForm.Controls.qyDgv dgvImported;
        private QyTech.SkinForm.Controls.qyDgv dgvUnImported;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkDel;
        private QyTech.SkinForm.Controls.qyBtn qyBtnQueryDb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private QyTech.SkinForm.Controls.qyDgv qyDgv_Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}