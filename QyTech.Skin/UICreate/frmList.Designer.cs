﻿namespace QyTech.SkinForm.UICreate
{
    partial class frmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scDgv = new System.Windows.Forms.SplitContainer();
            this.scQuery = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsPbr = new System.Windows.Forms.ToolStripProgressBar();
            this.qyDgvList = new QyTech.SkinForm.Controls.qyDgv();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scDgv)).BeginInit();
            this.scDgv.Panel1.SuspendLayout();
            this.scDgv.Panel2.SuspendLayout();
            this.scDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scQuery)).BeginInit();
            this.scQuery.Panel2.SuspendLayout();
            this.scQuery.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qyDgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // scDgv
            // 
            this.scDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDgv.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scDgv.Location = new System.Drawing.Point(0, 28);
            this.scDgv.Name = "scDgv";
            this.scDgv.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDgv.Panel1
            // 
            this.scDgv.Panel1.Controls.Add(this.scQuery);
            // 
            // scDgv.Panel2
            // 
            this.scDgv.Panel2.Controls.Add(this.qyDgvList);
            this.scDgv.Size = new System.Drawing.Size(800, 422);
            this.scDgv.SplitterDistance = 102;
            this.scDgv.TabIndex = 5;
            // 
            // scQuery
            // 
            this.scQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scQuery.Location = new System.Drawing.Point(0, 0);
            this.scQuery.Name = "scQuery";
            this.scQuery.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.scQuery.Panel1MinSize = 0;
            // 
            // scQuery.Panel2
            // 
            this.scQuery.Panel2.Controls.Add(this.toolStrip1);
            this.scQuery.Panel2MinSize = 0;
            this.scQuery.Size = new System.Drawing.Size(800, 102);
            this.scQuery.SplitterDistance = 69;
            this.scQuery.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsPbr});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 29);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.AutoSize = false;
            this.tsbAdd.Enabled = false;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(55, 25);
            this.tsbAdd.Text = "新增";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.AutoSize = false;
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Image = global::QyTech.SkinForm.Resources.edit_16;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(55, 25);
            this.tsbEdit.Text = "修改";
            this.tsbEdit.ToolTipText = "修改";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(55, 25);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 26);
            this.toolStripLabel1.Text = "          ";
            // 
            // tsPbr
            // 
            this.tsPbr.Name = "tsPbr";
            this.tsPbr.Size = new System.Drawing.Size(200, 26);
            this.tsPbr.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tsPbr.ToolTipText = "0/100";
            this.tsPbr.Visible = false;
            this.tsPbr.MouseHover += new System.EventHandler(this.tsPbr_MouseHover);
            // 
            // qyDgvList
            // 
            this.qyDgvList.AllowUserToAddRows = false;
            this.qyDgvList.AllowUserToDeleteRows = false;
            this.qyDgvList.AllowUserToResizeColumns = false;
            this.qyDgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.qyDgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.qyDgvList.BackgroundColor = System.Drawing.Color.White;
            this.qyDgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qyDgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.qyDgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qyDgvList.Location = new System.Drawing.Point(0, 0);
            this.qyDgvList.Name = "qyDgvList";
            this.qyDgvList.RowTemplate.Height = 23;
            this.qyDgvList.Size = new System.Drawing.Size(800, 316);
            this.qyDgvList.TabIndex = 10;
            this.qyDgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.qyDgvList_CellClick);
            this.qyDgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.qyDgvList_CellValueChanged);
            this.qyDgvList.CurrentCellDirtyStateChanged += new System.EventHandler(this.qyDgvList_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scDgv);
            this.Name = "frmList";
            this.Text = "frmList";
            this.Controls.SetChildIndex(this.scDgv, 0);
            this.scDgv.Panel1.ResumeLayout(false);
            this.scDgv.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDgv)).EndInit();
            this.scDgv.ResumeLayout(false);
            this.scQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scQuery)).EndInit();
            this.scQuery.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qyDgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer scDgv;
        public System.Windows.Forms.SplitContainer scQuery;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        protected System.Windows.Forms.ToolStripButton tsbEdit;
        protected System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        protected System.Windows.Forms.ToolStripProgressBar tsPbr;
        protected Controls.qyDgv qyDgvList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}