namespace TDObject
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblLoad = new System.Windows.Forms.Label();
            this.pbrLoad = new System.Windows.Forms.ProgressBar();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.exButton2 = new System.Windows.Forms.Button();
            this.exButton1 = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.exLabel2 = new System.Windows.Forms.Label();
            this.exLabel1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoad.Location = new System.Drawing.Point(30, 239);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(64, 16);
            this.lblLoad.TabIndex = 8;
            this.lblLoad.Text = "Loading";
            this.lblLoad.Visible = false;
            // 
            // pbrLoad
            // 
            this.pbrLoad.Location = new System.Drawing.Point(99, 240);
            this.pbrLoad.Maximum = 50;
            this.pbrLoad.Name = "pbrLoad";
            this.pbrLoad.Size = new System.Drawing.Size(172, 15);
            this.pbrLoad.TabIndex = 7;
            this.pbrLoad.Visible = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(126, 152);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 21);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Text = "123456";
            // 
            // exButton2
            // 
            this.exButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exButton2.Location = new System.Drawing.Point(167, 197);
            this.exButton2.Name = "exButton2";
            this.exButton2.Size = new System.Drawing.Size(90, 25);
            this.exButton2.TabIndex = 5;
            this.exButton2.Text = "退出";
            this.exButton2.Click += new System.EventHandler(this.exButton2_Click);
            // 
            // exButton1
            // 
            this.exButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exButton1.Location = new System.Drawing.Point(44, 197);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(90, 25);
            this.exButton1.TabIndex = 4;
            this.exButton1.Text = "登录";
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(126, 117);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 2;
            this.tbUserName.Text = "admin";
            // 
            // exLabel2
            // 
            this.exLabel2.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exLabel2.Location = new System.Drawing.Point(58, 152);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Size = new System.Drawing.Size(72, 20);
            this.exLabel2.TabIndex = 1;
            this.exLabel2.Text = "密  码：";
            // 
            // exLabel1
            // 
            this.exLabel1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exLabel1.Location = new System.Drawing.Point(58, 117);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Size = new System.Drawing.Size(72, 20);
            this.exLabel1.TabIndex = 0;
            this.exLabel1.Text = "用户名：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 259);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "企业信息管理系统";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(217, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "V1.0";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.exButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.exButton2;
            this.ClientSize = new System.Drawing.Size(291, 259);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.pbrLoad);
            this.Controls.Add(this.exButton2);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.exLabel2);
            this.Controls.Add(this.exLabel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.ProgressBar pbrLoad;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button exButton2;
        private System.Windows.Forms.Button exButton1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label exLabel2;
        private System.Windows.Forms.Label exLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;


    }
}