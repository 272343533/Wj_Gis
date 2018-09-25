namespace TDObject.UI
{
    partial class FrmUserManaNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManaNew));
            this.qyBtn_Search1 = new QyTech.SkinForm.Component.qyBtn_Search();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scForm)).BeginInit();
            this.scForm.Panel2.SuspendLayout();
            this.scForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDgv)).BeginInit();
            this.scDgv.Panel1.SuspendLayout();
            this.scDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scQuery)).BeginInit();
            this.scQuery.Panel1.SuspendLayout();
            this.scQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.scForm.Size = new System.Drawing.Size(832, 422);
            this.scForm.SplitterDistance = 226;
            // 
            // splitContainer2
            // 
            this.scDgv.Size = new System.Drawing.Size(602, 422);
            // 
            // splitContainer3
            // 
            // 
            // splitContainer3.Panel1
            // 
            this.scQuery.Panel1.Controls.Add(this.txtLName);
            this.scQuery.Panel1.Controls.Add(this.label1);
            this.scQuery.Panel1.Controls.Add(this.qyBtn_Search1);
            this.scQuery.Size = new System.Drawing.Size(602, 102);
            // 
            // qyBtn_Search1
            // 
            this.qyBtn_Search1.Image = ((System.Drawing.Image)(resources.GetObject("qyBtn_Search1.Image")));
            this.qyBtn_Search1.Location = new System.Drawing.Point(323, 27);
            this.qyBtn_Search1.Name = "qyBtn_Search1";
            this.qyBtn_Search1.Size = new System.Drawing.Size(75, 23);
            this.qyBtn_Search1.TabIndex = 0;
            this.qyBtn_Search1.Text = "刷新";
            this.qyBtn_Search1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.qyBtn_Search1.UseVisualStyleBackColor = true;
            this.qyBtn_Search1.Click += new System.EventHandler(this.qyBtn_Search1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "用户名";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(100, 29);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(207, 21);
            this.txtLName.TabIndex = 25;
            // 
            // FrmUserManaNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Name = "FrmUserManaNew";
            this.Text = "FrmUserManaNew";
            this.Load += new System.EventHandler(this.FrmUserManaNew_Load);
            this.scForm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scForm)).EndInit();
            this.scForm.ResumeLayout(false);
            this.scDgv.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDgv)).EndInit();
            this.scDgv.ResumeLayout(false);
            this.scQuery.Panel1.ResumeLayout(false);
            this.scQuery.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scQuery)).EndInit();
            this.scQuery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QyTech.SkinForm.Component.qyBtn_Search qyBtn_Search1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLName;
    }
}