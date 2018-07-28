// Copyright 2012 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at <your ArcGIS install location>/DeveloperKit10.1/userestrictions.txt.
// 

namespace TDObject
{
	partial class MainForm
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
			//Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
			//Failure to do this may result in random crashes on exit due to the operating system unloading 
			//the libraries in the incorrect order. 
			ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("�˶�");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("����");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("���Ṥҵ��");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("�ʹ�����");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("�ʹ�ֵ���", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("ͬ��Ƽ���ҵ԰");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ͬ������");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("ͬ��ֵ���", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("�⽭���ÿ�����", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("������");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("������");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("���й滮");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("��ҵ��Χ");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("���ݽ���");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("����");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("��·");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("����ͼ��", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.�û�����ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.�û�����ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.�����޸�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��ѯ��ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ҵ���Ʋ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ҵ�ۺ���Ϣ��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��ѯToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.�ۺϲ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�Ʊ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�˶�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ҷ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ҵ���Ͳ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ѶToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ͳ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ڱ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�Ľ̷���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ڴ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ũ��ʳƷ�ӹ�ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͨ���豸����ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ǽ���������ƷҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ҽҩ����ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������е����������ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ֽ��ֽ��ƷҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����Ǳ�����ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ƷҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ҵ��ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ҵ����ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͳ��ɸѡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͳ��ɸѡToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.����ɸѡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����ѯ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ȫ�ۺϲ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�δ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��Ϣ�޸�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�����������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ר��ͼ���1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ͼToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��ѯ��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Maptrans = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��Ϣά��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ�ϱ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboLayerFact = new System.Windows.Forms.ComboBox();
            this.btnRefreshMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.cboLayerName = new System.Windows.Forms.ComboBox();
            this.cboTransp = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnExport1 = new System.Windows.Forms.Button();
            this.chkZlqy = new System.Windows.Forms.CheckBox();
            this.chkYdqy = new System.Windows.Forms.CheckBox();
            this.btnPrint1 = new System.Windows.Forms.Button();
            this.btnPosition1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvT2_11 = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsLtdDetailInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.��ϸ��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvT2_12 = new System.Windows.Forms.DataGridView();
            this.Column27 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn122 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn123 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn124 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn125 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn127 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn128 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn132 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn133 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdLtdDetailInfo_zl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dgvT2_21 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dgvT2_31 = new System.Windows.Forms.DataGridView();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.dgvQycc = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveQyfw = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.dgvQyxx = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnSaveFW = new System.Windows.Forms.Button();
            this.dgvFW = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvCSGH = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.Column26 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsOrg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�õط�ΧToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ݽ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Χǽդ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ⲿ�豸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ͨ·��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��·����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.�����Ա�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLtnInfo = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn83 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn84 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn91 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn93 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn94 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn98 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn99 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn101 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn102 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn103 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn104 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn106 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn107 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn108 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn109 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn110 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn111 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn112 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn113 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn114 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn115 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn116 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn117 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn119 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn120 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn121 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.����ֲ���ʾToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_11)).BeginInit();
            this.cmsLtdDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_12)).BeginInit();
            this.cmdLtdDetailInfo_zl.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_21)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_31)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQycc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQyxx)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFW)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSGH)).BeginInit();
            this.cmsOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�û�����ToolStripMenuItem1,
            this.��ҵ��ѯ��ͳ��ToolStripMenuItem,
            this.��ҵ��ѯToolStripMenuItem1,
            this.testToolStripMenuItem,
            this.������ѯToolStripMenuItem,
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem,
            this.ͼ�δ���ToolStripMenuItem,
            this.ͼ�����������ToolStripMenuItem,
            this.��ͼToolStripMenuItem,
            this.Maptrans,
            this.��ҵ��Ϣά��ToolStripMenuItem,
            this.��ҵ�ϱ�ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1276, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // �û�����ToolStripMenuItem1
            // 
            this.�û�����ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�û�����ToolStripMenuItem2,
            this.�����޸�ToolStripMenuItem});
            this.�û�����ToolStripMenuItem1.Name = "�û�����ToolStripMenuItem1";
            this.�û�����ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.�û�����ToolStripMenuItem1.Text = "�û�����";
            // 
            // �û�����ToolStripMenuItem2
            // 
            this.�û�����ToolStripMenuItem2.Name = "�û�����ToolStripMenuItem2";
            this.�û�����ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.�û�����ToolStripMenuItem2.Text = "�˺Ź���";
            this.�û�����ToolStripMenuItem2.Click += new System.EventHandler(this.�û�����ToolStripMenuItem2_Click);
            // 
            // �����޸�ToolStripMenuItem
            // 
            this.�����޸�ToolStripMenuItem.Name = "�����޸�ToolStripMenuItem";
            this.�����޸�ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.�����޸�ToolStripMenuItem.Text = "�����޸�";
            this.�����޸�ToolStripMenuItem.Click += new System.EventHandler(this.�����޸�ToolStripMenuItem_Click);
            // 
            // ��ҵ��ѯ��ͳ��ToolStripMenuItem
            // 
            this.��ҵ��ѯ��ͳ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ҵ���Ʋ�ѯToolStripMenuItem,
            this.����ҵ�ۺ���Ϣ��ѯToolStripMenuItem});
            this.��ҵ��ѯ��ͳ��ToolStripMenuItem.Name = "��ҵ��ѯ��ͳ��ToolStripMenuItem";
            this.��ҵ��ѯ��ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.��ҵ��ѯ��ͳ��ToolStripMenuItem.Text = "��ҵ��ѯ";
            // 
            // ����ҵ���Ʋ�ѯToolStripMenuItem
            // 
            this.����ҵ���Ʋ�ѯToolStripMenuItem.Name = "����ҵ���Ʋ�ѯToolStripMenuItem";
            this.����ҵ���Ʋ�ѯToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.����ҵ���Ʋ�ѯToolStripMenuItem.Text = "����ҵ���Ʋ�ѯ";
            this.����ҵ���Ʋ�ѯToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ʋ�ѯToolStripMenuItem_Click);
            // 
            // ����ҵ�ۺ���Ϣ��ѯToolStripMenuItem
            // 
            this.����ҵ�ۺ���Ϣ��ѯToolStripMenuItem.Name = "����ҵ�ۺ���Ϣ��ѯToolStripMenuItem";
            this.����ҵ�ۺ���Ϣ��ѯToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.����ҵ�ۺ���Ϣ��ѯToolStripMenuItem.Text = "����ҵ�ۺ���Ϣ��ѯ";
            this.����ҵ�ۺ���Ϣ��ѯToolStripMenuItem.Click += new System.EventHandler(this.�ۺϲ�ѯToolStripMenuItem_Click);
            // 
            // ��ҵ��ѯToolStripMenuItem1
            // 
            this.��ҵ��ѯToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�ۺϲ�ѯToolStripMenuItem,
            this.����ҵ���Ͳ�ѯToolStripMenuItem});
            this.��ҵ��ѯToolStripMenuItem1.Name = "��ҵ��ѯToolStripMenuItem1";
            this.��ҵ��ѯToolStripMenuItem1.Size = new System.Drawing.Size(128, 21);
            this.��ҵ��ѯToolStripMenuItem1.Text = "������ҵ��Ϣ��ѯ";
            // 
            // �ۺϲ�ѯToolStripMenuItem
            // 
            this.�ۺϲ�ѯToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�Ʊ�ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.�˶�ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.Ҷ��ToolStripMenuItem,
            this.�����ToolStripMenuItem});
            this.�ۺϲ�ѯToolStripMenuItem.Name = "�ۺϲ�ѯToolStripMenuItem";
            this.�ۺϲ�ѯToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�ۺϲ�ѯToolStripMenuItem.Text = "����������ѯ";
            this.�ۺϲ�ѯToolStripMenuItem.Click += new System.EventHandler(this.�ۺϲ�ѯToolStripMenuItem_Click);
            // 
            // �Ʊ�ToolStripMenuItem
            // 
            this.�Ʊ�ToolStripMenuItem.Name = "�Ʊ�ToolStripMenuItem";
            this.�Ʊ�ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�Ʊ�ToolStripMenuItem.Tag = "WJKFQ02";
            this.�Ʊ�ToolStripMenuItem.Text = "�˶�";
            this.�Ʊ�ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.����ToolStripMenuItem.Tag = "WJKFQ01";
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // �˶�ToolStripMenuItem
            // 
            this.�˶�ToolStripMenuItem.Name = "�˶�ToolStripMenuItem";
            this.�˶�ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�˶�ToolStripMenuItem.Tag = "WJKFQ06";
            this.�˶�ToolStripMenuItem.Text = "���Ṥҵ��";
            this.�˶�ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.����ToolStripMenuItem.Tag = "WJKFQ05";
            this.����ToolStripMenuItem.Text = "�ʹ�����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // Ҷ��ToolStripMenuItem
            // 
            this.Ҷ��ToolStripMenuItem.Name = "Ҷ��ToolStripMenuItem";
            this.Ҷ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.Ҷ��ToolStripMenuItem.Tag = "WJKFQ03";
            this.Ҷ��ToolStripMenuItem.Text = "ͬ��Ƽ���ҵ԰";
            this.Ҷ��ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // �����ToolStripMenuItem
            // 
            this.�����ToolStripMenuItem.Name = "�����ToolStripMenuItem";
            this.�����ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�����ToolStripMenuItem.Tag = "WJKFQ04";
            this.�����ToolStripMenuItem.Text = "ͬ������";
            this.�����ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // ����ҵ���Ͳ�ѯToolStripMenuItem
            // 
            this.����ҵ���Ͳ�ѯToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.������ѶToolStripMenuItem,
            this.��ͳ����ToolStripMenuItem,
            this.��������ToolStripMenuItem,
            this.���ڱ���ToolStripMenuItem,
            this.�Ľ̷���ToolStripMenuItem,
            this.���ڴ���ToolStripMenuItem,
            this.ũ��ʳƷ�ӹ�ҵToolStripMenuItem,
            this.ͨ���豸����ҵToolStripMenuItem,
            this.��������ҵToolStripMenuItem,
            this.�ǽ���������ƷҵToolStripMenuItem,
            this.ҽҩ����ҵToolStripMenuItem,
            this.������е����������ҵToolStripMenuItem,
            this.��ֽ��ֽ��ƷҵToolStripMenuItem,
            this.�����Ǳ�����ҵToolStripMenuItem,
            this.ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem,
            this.������ƷҵToolStripMenuItem});
            this.����ҵ���Ͳ�ѯToolStripMenuItem.Name = "����ҵ���Ͳ�ѯToolStripMenuItem";
            this.����ҵ���Ͳ�ѯToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.����ҵ���Ͳ�ѯToolStripMenuItem.Text = "����ҵ���Ͳ�ѯ";
            // 
            // ������ѶToolStripMenuItem
            // 
            this.������ѶToolStripMenuItem.Name = "������ѶToolStripMenuItem";
            this.������ѶToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.������ѶToolStripMenuItem.Text = "39�������ͨ�ź����������豸����ҵ";
            this.������ѶToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ��ͳ����ToolStripMenuItem
            // 
            this.��ͳ����ToolStripMenuItem.Name = "��ͳ����ToolStripMenuItem";
            this.��ͳ����ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.��ͳ����ToolStripMenuItem.Text = "31��ɫ����ұ����ѹ�Ӽӹ�ҵ";
            this.��ͳ����ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ��������ToolStripMenuItem
            // 
            this.��������ToolStripMenuItem.Name = "��������ToolStripMenuItem";
            this.��������ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.��������ToolStripMenuItem.Text = "17��֯ҵ";
            this.��������ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ���ڱ���ToolStripMenuItem
            // 
            this.���ڱ���ToolStripMenuItem.Name = "���ڱ���ToolStripMenuItem";
            this.���ڱ���ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.���ڱ���ToolStripMenuItem.Text = "35ר���豸����ҵ";
            this.���ڱ���ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // �Ľ̷���ToolStripMenuItem
            // 
            this.�Ľ̷���ToolStripMenuItem.Name = "�Ľ̷���ToolStripMenuItem";
            this.�Ľ̷���ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.�Ľ̷���ToolStripMenuItem.Text = "21�Ҿ�����ҵ";
            this.�Ľ̷���ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ���ڴ���ToolStripMenuItem
            // 
            this.���ڴ���ToolStripMenuItem.Name = "���ڴ���ToolStripMenuItem";
            this.���ڴ���ToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.���ڴ���ToolStripMenuItem.Text = "29�𽺺�������Ʒҵ";
            this.���ڴ���ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ũ��ʳƷ�ӹ�ҵToolStripMenuItem
            // 
            this.ũ��ʳƷ�ӹ�ҵToolStripMenuItem.Name = "ũ��ʳƷ�ӹ�ҵToolStripMenuItem";
            this.ũ��ʳƷ�ӹ�ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ũ��ʳƷ�ӹ�ҵToolStripMenuItem.Text = "13ũ��ʳƷ�ӹ�ҵ";
            this.ũ��ʳƷ�ӹ�ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ͨ���豸����ҵToolStripMenuItem
            // 
            this.ͨ���豸����ҵToolStripMenuItem.Name = "ͨ���豸����ҵToolStripMenuItem";
            this.ͨ���豸����ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ͨ���豸����ҵToolStripMenuItem.Text = "34ͨ���豸����ҵ";
            this.ͨ���豸����ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ��������ҵToolStripMenuItem
            // 
            this.��������ҵToolStripMenuItem.Name = "��������ҵToolStripMenuItem";
            this.��������ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.��������ҵToolStripMenuItem.Text = "41��������ҵ";
            this.��������ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // �ǽ���������ƷҵToolStripMenuItem
            // 
            this.�ǽ���������ƷҵToolStripMenuItem.Name = "�ǽ���������ƷҵToolStripMenuItem";
            this.�ǽ���������ƷҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.�ǽ���������ƷҵToolStripMenuItem.Text = "3�ǽ���������Ʒҵ";
            this.�ǽ���������ƷҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ҽҩ����ҵToolStripMenuItem
            // 
            this.ҽҩ����ҵToolStripMenuItem.Name = "ҽҩ����ҵToolStripMenuItem";
            this.ҽҩ����ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ҽҩ����ҵToolStripMenuItem.Text = "27ҽҩ����ҵ";
            this.ҽҩ����ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ������е����������ҵToolStripMenuItem
            // 
            this.������е����������ҵToolStripMenuItem.Name = "������е����������ҵToolStripMenuItem";
            this.������е����������ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.������е����������ҵToolStripMenuItem.Text = "38������е����������ҵ";
            this.������е����������ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ��ֽ��ֽ��ƷҵToolStripMenuItem
            // 
            this.��ֽ��ֽ��ƷҵToolStripMenuItem.Name = "��ֽ��ֽ��ƷҵToolStripMenuItem";
            this.��ֽ��ֽ��ƷҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.��ֽ��ֽ��ƷҵToolStripMenuItem.Text = "22��ֽ��ֽ��Ʒҵ";
            this.��ֽ��ֽ��ƷҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // �����Ǳ�����ҵToolStripMenuItem
            // 
            this.�����Ǳ�����ҵToolStripMenuItem.Name = "�����Ǳ�����ҵToolStripMenuItem";
            this.�����Ǳ�����ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.�����Ǳ�����ҵToolStripMenuItem.Text = "4�����Ǳ�����ҵ";
            this.�����Ǳ�����ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem
            // 
            this.ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem.Name = "ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem";
            this.ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem.Text = "23ӡˢ�ͼ�¼ý�鸴��ҵ";
            this.ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // ������ƷҵToolStripMenuItem
            // 
            this.������ƷҵToolStripMenuItem.Name = "������ƷҵToolStripMenuItem";
            this.������ƷҵToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.������ƷҵToolStripMenuItem.Text = "33������Ʒҵ";
            this.������ƷҵToolStripMenuItem.Click += new System.EventHandler(this.����ҵ���Ͳ�ѯToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ҵ��ͳ��ToolStripMenuItem,
            this.��������ͳ��ToolStripMenuItem,
            this.����ҵ����ͳ��ToolStripMenuItem,
            this.ͳ��ɸѡToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.testToolStripMenuItem.Text = "����ͳ��";
            // 
            // ����ҵ��ͳ��ToolStripMenuItem
            // 
            this.����ҵ��ͳ��ToolStripMenuItem.Name = "����ҵ��ͳ��ToolStripMenuItem";
            this.����ҵ��ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.����ҵ��ͳ��ToolStripMenuItem.Text = "����ҵ��ͳ��";
            this.����ҵ��ͳ��ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ��ͳ��ToolStripMenuItem_Click);
            // 
            // ��������ͳ��ToolStripMenuItem
            // 
            this.��������ͳ��ToolStripMenuItem.Name = "��������ͳ��ToolStripMenuItem";
            this.��������ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.��������ͳ��ToolStripMenuItem.Text = "��������ͳ��";
            this.��������ͳ��ToolStripMenuItem.Click += new System.EventHandler(this.��������ͳ��ToolStripMenuItem_Click);
            // 
            // ����ҵ����ͳ��ToolStripMenuItem
            // 
            this.����ҵ����ͳ��ToolStripMenuItem.Name = "����ҵ����ͳ��ToolStripMenuItem";
            this.����ҵ����ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.����ҵ����ͳ��ToolStripMenuItem.Text = "����ҵ����ͳ��";
            this.����ҵ����ͳ��ToolStripMenuItem.Click += new System.EventHandler(this.����ҵ����ͳ��ToolStripMenuItem_Click);
            // 
            // ͳ��ɸѡToolStripMenuItem
            // 
            this.ͳ��ɸѡToolStripMenuItem.Name = "ͳ��ɸѡToolStripMenuItem";
            this.ͳ��ɸѡToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ͳ��ɸѡToolStripMenuItem.Text = "ͳ��ɸѡ";
            this.ͳ��ɸѡToolStripMenuItem.Visible = false;
            this.ͳ��ɸѡToolStripMenuItem.Click += new System.EventHandler(this.ͳ��ɸѡToolStripMenuItem_Click);
            // 
            // ������ѯToolStripMenuItem
            // 
            this.������ѯToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ͳ��ɸѡToolStripMenuItem1,
            this.����ɸѡToolStripMenuItem,
            this.����ֲ���ʾToolStripMenuItem});
            this.������ѯToolStripMenuItem.Name = "������ѯToolStripMenuItem";
            this.������ѯToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.������ѯToolStripMenuItem.Text = "����ͳ��";
            // 
            // ͳ��ɸѡToolStripMenuItem1
            // 
            this.ͳ��ɸѡToolStripMenuItem1.Name = "ͳ��ɸѡToolStripMenuItem1";
            this.ͳ��ɸѡToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ͳ��ɸѡToolStripMenuItem1.Text = "����ά��";
            this.ͳ��ɸѡToolStripMenuItem1.Click += new System.EventHandler(this.ͳ��ɸѡToolStripMenuItem_Click);
            // 
            // ����ɸѡToolStripMenuItem
            // 
            this.����ɸѡToolStripMenuItem.Name = "����ɸѡToolStripMenuItem";
            this.����ɸѡToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.����ɸѡToolStripMenuItem.Text = "����ɸѡ";
            this.����ɸѡToolStripMenuItem.Click += new System.EventHandler(this.����ɸѡToolStripMenuItem_Click);
            // 
            // ������ҵ��ѯ��ͳ��ToolStripMenuItem
            // 
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�����ѯ����ToolStripMenuItem,
            this.��ȫ�ۺϲ�ѯToolStripMenuItem});
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Name = "������ҵ��ѯ��ͳ��ToolStripMenuItem";
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Text = "��ȫ����";
            // 
            // �����ѯ����ToolStripMenuItem
            // 
            this.�����ѯ����ToolStripMenuItem.Name = "�����ѯ����ToolStripMenuItem";
            this.�����ѯ����ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.�����ѯ����ToolStripMenuItem.Text = "�����ѯ������";
            this.�����ѯ����ToolStripMenuItem.Click += new System.EventHandler(this.�����ѯ����ToolStripMenuItem_Click);
            // 
            // ��ȫ�ۺϲ�ѯToolStripMenuItem
            // 
            this.��ȫ�ۺϲ�ѯToolStripMenuItem.Name = "��ȫ�ۺϲ�ѯToolStripMenuItem";
            this.��ȫ�ۺϲ�ѯToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.��ȫ�ۺϲ�ѯToolStripMenuItem.Text = "��ȫ�ۺϲ�ѯ";
            this.��ȫ�ۺϲ�ѯToolStripMenuItem.Click += new System.EventHandler(this.��ȫ�ۺϲ�ѯToolStripMenuItem_Click);
            // 
            // ͼ�δ���ToolStripMenuItem
            // 
            this.ͼ�δ���ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.���ݵ���ToolStripMenuItem,
            this.�������ݵ���ToolStripMenuItem,
            this.���ݵ���ToolStripMenuItem,
            this.������ҵToolStripMenuItem,
            this.��ҵ��Ϣ�޸�ToolStripMenuItem});
            this.ͼ�δ���ToolStripMenuItem.Name = "ͼ�δ���ToolStripMenuItem";
            this.ͼ�δ���ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.ͼ�δ���ToolStripMenuItem.Text = "������Ϣ����";
            // 
            // ���ݵ���ToolStripMenuItem
            // 
            this.���ݵ���ToolStripMenuItem.Name = "���ݵ���ToolStripMenuItem";
            this.���ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.���ݵ���ToolStripMenuItem.Text = "�о־��������ݵ���";
            this.���ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.���ݵ���ToolStripMenuItem_Click);
            // 
            // �������ݵ���ToolStripMenuItem
            // 
            this.�������ݵ���ToolStripMenuItem.Name = "�������ݵ���ToolStripMenuItem";
            this.�������ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.�������ݵ���ToolStripMenuItem.Text = "�������ݵ���";
            this.�������ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.�������ݵ���ToolStripMenuItem_Click);
            // 
            // ���ݵ���ToolStripMenuItem
            // 
            this.���ݵ���ToolStripMenuItem.Name = "���ݵ���ToolStripMenuItem";
            this.���ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.���ݵ���ToolStripMenuItem.Text = "���ݵ���";
            this.���ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.���ݵ���ToolStripMenuItem_Click);
            // 
            // ������ҵToolStripMenuItem
            // 
            this.������ҵToolStripMenuItem.Name = "������ҵToolStripMenuItem";
            this.������ҵToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.������ҵToolStripMenuItem.Text = "������ҵ";
            this.������ҵToolStripMenuItem.Click += new System.EventHandler(this.������ҵToolStripMenuItem_Click);
            // 
            // ��ҵ��Ϣ�޸�ToolStripMenuItem
            // 
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Name = "��ҵ��Ϣ�޸�ToolStripMenuItem";
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Text = "��ҵ��Ϣ�޸�";
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Click += new System.EventHandler(this.��ҵ��Ϣ�޸�ToolStripMenuItem_Click);
            // 
            // ͼ�����������ToolStripMenuItem
            // 
            this.ͼ�����������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem,
            this.ר��ͼ���1ToolStripMenuItem});
            this.ͼ�����������ToolStripMenuItem.Name = "ͼ�����������ToolStripMenuItem";
            this.ͼ�����������ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ͼ�����������ToolStripMenuItem.Text = "ר��ͼ���";
            // 
            // ��ǰ���巶Χ��ӡͼ��ToolStripMenuItem
            // 
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem.Name = "��ǰ���巶Χ��ӡͼ��ToolStripMenuItem";
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem.Text = "��ͼ���";
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem.Click += new System.EventHandler(this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem_Click);
            // 
            // ר��ͼ���1ToolStripMenuItem
            // 
            this.ר��ͼ���1ToolStripMenuItem.Name = "ר��ͼ���1ToolStripMenuItem";
            this.ר��ͼ���1ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ר��ͼ���1ToolStripMenuItem.Text = "ר��ͼ���1";
            this.ר��ͼ���1ToolStripMenuItem.Visible = false;
            this.ר��ͼ���1ToolStripMenuItem.Click += new System.EventHandler(this.ר��ͼ���1ToolStripMenuItem_Click);
            // 
            // ��ͼToolStripMenuItem
            // 
            this.��ͼToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem,
            this.��ҵ��ѯ��ϢToolStripMenuItem});
            this.��ͼToolStripMenuItem.Name = "��ͼToolStripMenuItem";
            this.��ͼToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.��ͼToolStripMenuItem.Text = "��ͼ";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.����ToolStripMenuItem.Text = "����������Ϣ";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ��ҵ��ѯ��ϢToolStripMenuItem
            // 
            this.��ҵ��ѯ��ϢToolStripMenuItem.Name = "��ҵ��ѯ��ϢToolStripMenuItem";
            this.��ҵ��ѯ��ϢToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.��ҵ��ѯ��ϢToolStripMenuItem.Text = "��ҵ��ѯ��Ϣ ";
            this.��ҵ��ѯ��ϢToolStripMenuItem.Click += new System.EventHandler(this.��ҵ��ѯ��ϢToolStripMenuItem_Click);
            // 
            // Maptrans
            // 
            this.Maptrans.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ͼ�����ToolStripMenuItem});
            this.Maptrans.Name = "Maptrans";
            this.Maptrans.Size = new System.Drawing.Size(72, 21);
            this.Maptrans.Text = "��ͼ���� ";
            this.Maptrans.Visible = false;
            // 
            // ͼ�����ToolStripMenuItem
            // 
            this.ͼ�����ToolStripMenuItem.Name = "ͼ�����ToolStripMenuItem";
            this.ͼ�����ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ͼ�����ToolStripMenuItem.Text = "ͼ�����";
            this.ͼ�����ToolStripMenuItem.Click += new System.EventHandler(this.ͼ�����ToolStripMenuItem_Click);
            // 
            // ��ҵ��Ϣά��ToolStripMenuItem
            // 
            this.��ҵ��Ϣά��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem});
            this.��ҵ��Ϣά��ToolStripMenuItem.Name = "��ҵ��Ϣά��ToolStripMenuItem";
            this.��ҵ��Ϣά��ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.��ҵ��Ϣά��ToolStripMenuItem.Text = "��Ϣά��";
            this.��ҵ��Ϣά��ToolStripMenuItem.Visible = false;
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Visible = false;
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ��ҵ�ϱ�ToolStripMenuItem
            // 
            this.��ҵ�ϱ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem});
            this.��ҵ�ϱ�ToolStripMenuItem.Name = "��ҵ�ϱ�ToolStripMenuItem";
            this.��ҵ�ϱ�ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.��ҵ�ϱ�ToolStripMenuItem.Text = "��ҵ�ϱ�";
            // 
            // �⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem
            // 
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem.Name = "�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem";
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem.Text = "�⽭����ҵ��ҵ��Դ��Լ��������ϱ�";
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem.Click += new System.EventHandler(this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY,
            this.tsslScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 672);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1276, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(343, 17);
            this.statusBarXY.Text = "Load a map document or a diagram into the MapControl";
            // 
            // tsslScale
            // 
            this.tsslScale.Enabled = false;
            this.tsslScale.Name = "tsslScale";
            this.tsslScale.Size = new System.Drawing.Size(131, 17);
            this.tsslScale.Text = "toolStripStatusLabel1";
            this.tsslScale.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboLayerFact);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefreshMap);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.cboLayerName);
            this.splitContainer1.Panel1.Controls.Add(this.cboTransp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.splitter3);
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.No;
            this.splitContainer1.Size = new System.Drawing.Size(1276, 619);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 8;
            // 
            // cboLayerFact
            // 
            this.cboLayerFact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLayerFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayerFact.FormattingEnabled = true;
            this.cboLayerFact.Items.AddRange(new object[] {
            "���й滮"});
            this.cboLayerFact.Location = new System.Drawing.Point(73, 169);
            this.cboLayerFact.Name = "cboLayerFact";
            this.cboLayerFact.Size = new System.Drawing.Size(21, 20);
            this.cboLayerFact.TabIndex = 16;
            this.cboLayerFact.Visible = false;
            // 
            // btnRefreshMap
            // 
            this.btnRefreshMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMap.Location = new System.Drawing.Point(204, 167);
            this.btnRefreshMap.Name = "btnRefreshMap";
            this.btnRefreshMap.Size = new System.Drawing.Size(39, 23);
            this.btnRefreshMap.TabIndex = 14;
            this.btnRefreshMap.Text = "ˢ��";
            this.btnRefreshMap.UseVisualStyleBackColor = true;
            this.btnRefreshMap.Click += new System.EventHandler(this.btnRefreshMap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "ͼ��͸��";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 207);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.53846F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.461539F));
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("����", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.Blue;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "�ڵ�1";
            treeNode1.Tag = "WJKFQ02";
            treeNode1.Text = "�˶�";
            treeNode2.Checked = true;
            treeNode2.Name = "�ڵ�2";
            treeNode2.Tag = "WJKFQ01";
            treeNode2.Text = "����";
            treeNode3.Checked = true;
            treeNode3.Name = "�ڵ�4";
            treeNode3.Tag = "WJKFQ06";
            treeNode3.Text = "���Ṥҵ��";
            treeNode4.Checked = true;
            treeNode4.Name = "�ڵ�5";
            treeNode4.Tag = "WJKFQ05";
            treeNode4.Text = "�ʹ�����";
            treeNode5.Checked = true;
            treeNode5.Name = "�ڵ�3";
            treeNode5.Tag = "WJKFQ065";
            treeNode5.Text = "�ʹ�ֵ���";
            treeNode6.Name = "�ڵ�1";
            treeNode6.Tag = "WJKFQ03";
            treeNode6.Text = "ͬ��Ƽ���ҵ԰";
            treeNode7.Checked = true;
            treeNode7.Name = "�ڵ�41";
            treeNode7.Tag = "WJKFQ04";
            treeNode7.Text = "ͬ������";
            treeNode8.Checked = true;
            treeNode8.Name = "�ڵ�0";
            treeNode8.Tag = "WJKFQ034";
            treeNode8.Text = "ͬ��ֵ���";
            treeNode9.Checked = true;
            treeNode9.Name = "�ڵ�0";
            treeNode9.Tag = "WJKFQ";
            treeNode9.Text = "�⽭���ÿ�����";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(251, 176);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.treeView2);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 208);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "����ͼ�����";
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.SystemColors.Control;
            this.treeView2.CheckBoxes = true;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.ForeColor = System.Drawing.Color.Blue;
            this.treeView2.Location = new System.Drawing.Point(3, 22);
            this.treeView2.Name = "treeView2";
            treeNode10.Checked = true;
            treeNode10.Name = "�ڵ�0";
            treeNode10.Text = "������";
            treeNode11.Checked = true;
            treeNode11.Name = "�ڵ�1";
            treeNode11.Text = "������";
            treeNode12.Name = "�ڵ�0";
            treeNode12.Text = "���й滮";
            treeNode13.Checked = true;
            treeNode13.Name = "�ڵ�2";
            treeNode13.Text = "��ҵ��Χ";
            treeNode14.Checked = true;
            treeNode14.Name = "�ڵ�3";
            treeNode14.Text = "���ݽ���";
            treeNode15.Checked = true;
            treeNode15.Name = "�ڵ�5";
            treeNode15.Text = "����";
            treeNode16.Checked = true;
            treeNode16.Name = "�ڵ�0";
            treeNode16.Text = "��·";
            treeNode17.Name = "�ڵ�1";
            treeNode17.Text = "����ͼ��";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17});
            this.treeView2.Size = new System.Drawing.Size(234, 183);
            this.treeView2.TabIndex = 1;
            this.treeView2.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterCheck);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 163);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(252, 3);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.axMapControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 163);
            this.panel2.TabIndex = 7;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl2.Location = new System.Drawing.Point(0, 0);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(252, 163);
            this.axMapControl2.TabIndex = 9;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // cboLayerName
            // 
            this.cboLayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLayerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayerName.FormattingEnabled = true;
            this.cboLayerName.Items.AddRange(new object[] {
            "���й滮"});
            this.cboLayerName.Location = new System.Drawing.Point(64, 170);
            this.cboLayerName.Name = "cboLayerName";
            this.cboLayerName.Size = new System.Drawing.Size(83, 20);
            this.cboLayerName.TabIndex = 15;
            this.cboLayerName.SelectedIndexChanged += new System.EventHandler(this.cboLayerName_SelectedIndexChanged);
            // 
            // cboTransp
            // 
            this.cboTransp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTransp.FormattingEnabled = true;
            this.cboTransp.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.cboTransp.Location = new System.Drawing.Point(153, 169);
            this.cboTransp.Name = "cboTransp";
            this.cboTransp.Size = new System.Drawing.Size(47, 20);
            this.cboTransp.TabIndex = 6;
            this.cboTransp.Text = "50";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(686, 619);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(686, 619);
            this.panel4.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.splitter4);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(686, 619);
            this.panel5.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button7);
            this.panel7.Controls.Add(this.axMapControl1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(686, 381);
            this.panel7.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Location = new System.Drawing.Point(622, 26);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 52);
            this.button7.TabIndex = 14;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(686, 381);
            this.axMapControl1.TabIndex = 3;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnFullExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnFullExtentUpdatedEventHandler(this.axMapControl1_OnFullExtentUpdated);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 381);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(686, 4);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 385);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(686, 234);
            this.panel6.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.ItemSize = new System.Drawing.Size(5, 10);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(16, 13);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(686, 234);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button14);
            this.tabPage6.Controls.Add(this.button13);
            this.tabPage6.Controls.Add(this.button10);
            this.tabPage6.Controls.Add(this.btnExport1);
            this.tabPage6.Controls.Add(this.chkZlqy);
            this.tabPage6.Controls.Add(this.chkYdqy);
            this.tabPage6.Controls.Add(this.btnPrint1);
            this.tabPage6.Controls.Add(this.btnPosition1);
            this.tabPage6.Controls.Add(this.splitContainer2);
            this.tabPage6.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage6.Location = new System.Drawing.Point(14, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(668, 226);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "1";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button14.Location = new System.Drawing.Point(294, 190);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(52, 23);
            this.button14.TabIndex = 10;
            this.button14.Text = "ȫѡ";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button13.Location = new System.Drawing.Point(343, 190);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 9;
            this.button13.Text = "ȫȡ��";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button10.Location = new System.Drawing.Point(483, 190);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 7;
            this.button10.Text = "ͻ����ʾ";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnExport1
            // 
            this.btnExport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport1.Location = new System.Drawing.Point(152, 191);
            this.btnExport1.Name = "btnExport1";
            this.btnExport1.Size = new System.Drawing.Size(99, 23);
            this.btnExport1.TabIndex = 5;
            this.btnExport1.Text = "������";
            this.btnExport1.UseVisualStyleBackColor = true;
            this.btnExport1.Click += new System.EventHandler(this.btnExport1_Click);
            // 
            // chkZlqy
            // 
            this.chkZlqy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkZlqy.AutoSize = true;
            this.chkZlqy.Location = new System.Drawing.Point(85, 195);
            this.chkZlqy.Name = "chkZlqy";
            this.chkZlqy.Size = new System.Drawing.Size(72, 16);
            this.chkZlqy.TabIndex = 4;
            this.chkZlqy.Text = "������ҵ";
            this.chkZlqy.UseVisualStyleBackColor = true;
            // 
            // chkYdqy
            // 
            this.chkYdqy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkYdqy.AutoSize = true;
            this.chkYdqy.Location = new System.Drawing.Point(16, 195);
            this.chkYdqy.Name = "chkYdqy";
            this.chkYdqy.Size = new System.Drawing.Size(72, 16);
            this.chkYdqy.TabIndex = 3;
            this.chkYdqy.Text = "�õ���ҵ";
            this.chkYdqy.UseVisualStyleBackColor = true;
            // 
            // btnPrint1
            // 
            this.btnPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint1.Location = new System.Drawing.Point(533, 188);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(86, 26);
            this.btnPrint1.TabIndex = 6;
            this.btnPrint1.Text = "��ӡ";
            this.btnPrint1.UseVisualStyleBackColor = true;
            this.btnPrint1.Visible = false;
            // 
            // btnPosition1
            // 
            this.btnPosition1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPosition1.Location = new System.Drawing.Point(413, 190);
            this.btnPosition1.Name = "btnPosition1";
            this.btnPosition1.Size = new System.Drawing.Size(72, 23);
            this.btnPosition1.TabIndex = 2;
            this.btnPosition1.Text = "�ռ䶨λ";
            this.btnPosition1.UseVisualStyleBackColor = true;
            this.btnPosition1.Click += new System.EventHandler(this.btnPosition1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 6);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvT2_11);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvT2_12);
            this.splitContainer2.Size = new System.Drawing.Size(644, 183);
            this.splitContainer2.SplitterDistance = 375;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvT2_11
            // 
            this.dgvT2_11.AllowUserToAddRows = false;
            this.dgvT2_11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_11.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column11,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column23,
            this.Column21,
            this.Column22,
            this.Column24,
            this.Column56});
            this.dgvT2_11.ContextMenuStrip = this.cmsLtdDetailInfo;
            this.dgvT2_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvT2_11.Location = new System.Drawing.Point(0, 0);
            this.dgvT2_11.Name = "dgvT2_11";
            this.dgvT2_11.RowTemplate.Height = 23;
            this.dgvT2_11.Size = new System.Drawing.Size(375, 183);
            this.dgvT2_11.TabIndex = 0;
            this.dgvT2_11.Click += new System.EventHandler(this.dgvT2_11_Click);
            this.dgvT2_11.DoubleClick += new System.EventHandler(this.dgvT2_11_DoubleClick);
            // 
            // Column12
            // 
            this.Column12.HeaderText = "��λ";
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column12.Width = 40;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "DKBH";
            this.Column11.HeaderText = "�ؿ���";
            this.Column11.Name = "Column11";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NSRSBH";
            this.Column1.HeaderText = "��˰��ʶ���";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "YDQYMC";
            this.Column2.HeaderText = "�õ���ҵ����";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TDZL";
            this.Column3.HeaderText = "��������";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ZCLX";
            this.Column4.HeaderText = "ע������";
            this.Column4.Name = "Column4";
            this.Column4.Width = 110;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "ZCSJ";
            this.Column13.HeaderText = "ע��ʱ��";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "JYFW";
            this.Column14.HeaderText = "��Ӫ��Χ";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "HYDL";
            this.Column15.HeaderText = "��ҵ����";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "FZMJ_";
            this.Column16.HeaderText = "��֤���";
            this.Column16.Name = "Column16";
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "ZDMJ";
            this.Column17.HeaderText = "ռ�����";
            this.Column17.Name = "Column17";
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "JZZDMJ";
            this.Column18.HeaderText = "����ռ�����";
            this.Column18.Name = "Column18";
            this.Column18.Width = 110;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "JZMJ";
            this.Column19.HeaderText = "�������";
            this.Column19.Name = "Column19";
            this.Column19.Width = 110;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "QSXZ";
            this.Column20.HeaderText = "Ȩ������";
            this.Column20.Name = "Column20";
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "TDYT";
            this.Column23.HeaderText = "������;";
            this.Column23.Name = "Column23";
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "HGDM";
            this.Column21.HeaderText = "���ش���";
            this.Column21.Name = "Column21";
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "TDZH";
            this.Column22.HeaderText = "����֤��";
            this.Column22.Name = "Column22";
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "SFWZLQY";
            this.Column24.HeaderText = "�Ƿ�Ϊ������ҵ";
            this.Column24.Name = "Column24";
            // 
            // Column56
            // 
            this.Column56.DataPropertyName = "SZDWMC";
            this.Column56.HeaderText = "���ⵥλ����";
            this.Column56.Name = "Column56";
            // 
            // cmsLtdDetailInfo
            // 
            this.cmsLtdDetailInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ϸ��ϢToolStripMenuItem});
            this.cmsLtdDetailInfo.Name = "cmsLtdDetailInfo";
            this.cmsLtdDetailInfo.Size = new System.Drawing.Size(125, 26);
            // 
            // ��ϸ��ϢToolStripMenuItem
            // 
            this.��ϸ��ϢToolStripMenuItem.Name = "��ϸ��ϢToolStripMenuItem";
            this.��ϸ��ϢToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.��ϸ��ϢToolStripMenuItem.Text = "��ϸ��Ϣ";
            this.��ϸ��ϢToolStripMenuItem.Click += new System.EventHandler(this.��ϸ��ϢToolStripMenuItem_Click);
            // 
            // dgvT2_12
            // 
            this.dgvT2_12.AllowUserToAddRows = false;
            this.dgvT2_12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT2_12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_12.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column27,
            this.Column57,
            this.dataGridViewTextBoxColumn122,
            this.dataGridViewTextBoxColumn123,
            this.dataGridViewTextBoxColumn124,
            this.dataGridViewTextBoxColumn125,
            this.dataGridViewTextBoxColumn127,
            this.dataGridViewTextBoxColumn128,
            this.dataGridViewTextBoxColumn132,
            this.dataGridViewTextBoxColumn133});
            this.dgvT2_12.ContextMenuStrip = this.cmdLtdDetailInfo_zl;
            this.dgvT2_12.Location = new System.Drawing.Point(3, 3);
            this.dgvT2_12.Name = "dgvT2_12";
            this.dgvT2_12.RowTemplate.Height = 23;
            this.dgvT2_12.Size = new System.Drawing.Size(262, 175);
            this.dgvT2_12.TabIndex = 13;
            this.dgvT2_12.Click += new System.EventHandler(this.dgvT2_12_Click);
            this.dgvT2_12.DoubleClick += new System.EventHandler(this.dgvT2_12_DoubleClick);
            // 
            // Column27
            // 
            this.Column27.HeaderText = "ѡ��";
            this.Column27.Name = "Column27";
            this.Column27.Width = 40;
            // 
            // Column57
            // 
            this.Column57.DataPropertyName = "DKBH";
            this.Column57.HeaderText = "�ؿ���";
            this.Column57.Name = "Column57";
            // 
            // dataGridViewTextBoxColumn122
            // 
            this.dataGridViewTextBoxColumn122.DataPropertyName = "OBJECTID";
            this.dataGridViewTextBoxColumn122.HeaderText = "objid";
            this.dataGridViewTextBoxColumn122.Name = "dataGridViewTextBoxColumn122";
            this.dataGridViewTextBoxColumn122.Visible = false;
            // 
            // dataGridViewTextBoxColumn123
            // 
            this.dataGridViewTextBoxColumn123.DataPropertyName = "DKBH";
            this.dataGridViewTextBoxColumn123.HeaderText = "�ؿ���";
            this.dataGridViewTextBoxColumn123.Name = "dataGridViewTextBoxColumn123";
            this.dataGridViewTextBoxColumn123.Visible = false;
            // 
            // dataGridViewTextBoxColumn124
            // 
            this.dataGridViewTextBoxColumn124.DataPropertyName = "NSRSBH";
            this.dataGridViewTextBoxColumn124.HeaderText = "��˰��ʶ���";
            this.dataGridViewTextBoxColumn124.Name = "dataGridViewTextBoxColumn124";
            this.dataGridViewTextBoxColumn124.Width = 110;
            // 
            // dataGridViewTextBoxColumn125
            // 
            this.dataGridViewTextBoxColumn125.DataPropertyName = "ZLQYMC_";
            this.dataGridViewTextBoxColumn125.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn125.Name = "dataGridViewTextBoxColumn125";
            this.dataGridViewTextBoxColumn125.Width = 110;
            // 
            // dataGridViewTextBoxColumn127
            // 
            this.dataGridViewTextBoxColumn127.DataPropertyName = "SZDWMC";
            this.dataGridViewTextBoxColumn127.HeaderText = "���ⵥλ����";
            this.dataGridViewTextBoxColumn127.Name = "dataGridViewTextBoxColumn127";
            this.dataGridViewTextBoxColumn127.Width = 110;
            // 
            // dataGridViewTextBoxColumn128
            // 
            this.dataGridViewTextBoxColumn128.DataPropertyName = "PZYT";
            this.dataGridViewTextBoxColumn128.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn128.Name = "dataGridViewTextBoxColumn128";
            // 
            // dataGridViewTextBoxColumn132
            // 
            this.dataGridViewTextBoxColumn132.DataPropertyName = "TDZH";
            this.dataGridViewTextBoxColumn132.HeaderText = "����֤��";
            this.dataGridViewTextBoxColumn132.Name = "dataGridViewTextBoxColumn132";
            // 
            // dataGridViewTextBoxColumn133
            // 
            this.dataGridViewTextBoxColumn133.DataPropertyName = "CYLX";
            this.dataGridViewTextBoxColumn133.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn133.Name = "dataGridViewTextBoxColumn133";
            // 
            // cmdLtdDetailInfo_zl
            // 
            this.cmdLtdDetailInfo_zl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.cmdLtdDetailInfo_zl.Name = "cmsLtdDetailInfo";
            this.cmdLtdDetailInfo_zl.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem3.Text = "��ϸ��Ϣ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button5);
            this.tabPage7.Controls.Add(this.button4);
            this.tabPage7.Controls.Add(this.button3);
            this.tabPage7.Controls.Add(this.button2);
            this.tabPage7.Controls.Add(this.button1);
            this.tabPage7.Controls.Add(this.checkBox1);
            this.tabPage7.Controls.Add(this.dgvT2_21);
            this.tabPage7.Location = new System.Drawing.Point(14, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(668, 226);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "2";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(1350, 189);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "��ӡ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(423, 467);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "����";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(381, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "�޸���ע";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(261, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "��ע";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(107, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "����";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 189);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "ȫ��";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // dgvT2_21
            // 
            this.dgvT2_21.AllowUserToAddRows = false;
            this.dgvT2_21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT2_21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_21.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvT2_21.Location = new System.Drawing.Point(6, 3);
            this.dgvT2_21.Name = "dgvT2_21";
            this.dgvT2_21.RowTemplate.Height = 23;
            this.dgvT2_21.Size = new System.Drawing.Size(1533, 170);
            this.dgvT2_21.TabIndex = 1;
            this.dgvT2_21.Click += new System.EventHandler(this.dgvT2_21_Click);
            this.dgvT2_21.DoubleClick += new System.EventHandler(this.dgvT2_21_DoubleClick);
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "����������";
            this.dataGridViewTextBoxColumn13.HeaderText = "����������";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn14.HeaderText = "�鴦���";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn15.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "�鴦����";
            this.dataGridViewTextBoxColumn16.HeaderText = "�鴦����";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "����";
            this.Column5.HeaderText = "����";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "�鴦��ʼ����";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "�鴦��ʼ����";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "�鴦��ֹ����";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "�鴦��ֹ����";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "��ע����";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column8.HeaderText = "��ע����";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "��������";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column9.HeaderText = "��������";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "�鴦��ע����";
            this.Column10.HeaderText = "�鴦��ע����";
            this.Column10.Name = "Column10";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.button6);
            this.tabPage8.Controls.Add(this.button8);
            this.tabPage8.Controls.Add(this.dgvT2_31);
            this.tabPage8.Location = new System.Drawing.Point(14, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(668, 226);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "3";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(1330, 191);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "��ӡ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.Location = new System.Drawing.Point(100, 188);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "����";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // dgvT2_31
            // 
            this.dgvT2_31.AllowUserToAddRows = false;
            this.dgvT2_31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT2_31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_31.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column25,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.dgvT2_31.Location = new System.Drawing.Point(3, 3);
            this.dgvT2_31.Name = "dgvT2_31";
            this.dgvT2_31.RowTemplate.Height = 23;
            this.dgvT2_31.Size = new System.Drawing.Size(1431, 179);
            this.dgvT2_31.TabIndex = 2;
            this.dgvT2_31.Click += new System.EventHandler(this.dgvT2_31_Click);
            this.dgvT2_31.DoubleClick += new System.EventHandler(this.dgvT2_31_DoubleClick);
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "�ؿ���";
            this.Column25.HeaderText = "�ؿ���";
            this.Column25.Name = "Column25";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "��������������";
            this.dataGridViewTextBoxColumn17.HeaderText = "����������";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 200;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "�õص�λ����";
            this.dataGridViewTextBoxColumn18.HeaderText = "�õص�λ����";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 300;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "�ֳ�����";
            this.dataGridViewTextBoxColumn19.HeaderText = "�ֳ�����";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 300;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn20.HeaderText = "���";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(689, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 619);
            this.panel1.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 619);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.dgvQycc);
            this.tabPage14.Controls.Add(this.btnSaveQyfw);
            this.tabPage14.Controls.Add(this.button11);
            this.tabPage14.Controls.Add(this.button9);
            this.tabPage14.Controls.Add(this.dgvQyxx);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(322, 593);
            this.tabPage14.TabIndex = 12;
            this.tabPage14.Text = "��ҵ��Ϣ";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // dgvQycc
            // 
            this.dgvQycc.AllowUserToAddRows = false;
            this.dgvQycc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQycc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQycc.ColumnHeadersVisible = false;
            this.dgvQycc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34});
            this.dgvQycc.Location = new System.Drawing.Point(279, 518);
            this.dgvQycc.Name = "dgvQycc";
            this.dgvQycc.RowHeadersVisible = false;
            this.dgvQycc.RowTemplate.Height = 23;
            this.dgvQycc.Size = new System.Drawing.Size(36, 33);
            this.dgvQycc.TabIndex = 8;
            this.dgvQycc.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "key";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn33.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn33.HeaderText = "������";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "value";
            dataGridViewCellStyle6.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn34.HeaderText = "����";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // btnSaveQyfw
            // 
            this.btnSaveQyfw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveQyfw.Location = new System.Drawing.Point(17, 563);
            this.btnSaveQyfw.Name = "btnSaveQyfw";
            this.btnSaveQyfw.Size = new System.Drawing.Size(71, 23);
            this.btnSaveQyfw.TabIndex = 7;
            this.btnSaveQyfw.Text = "����";
            this.btnSaveQyfw.UseVisualStyleBackColor = true;
            this.btnSaveQyfw.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button11.Location = new System.Drawing.Point(107, 562);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(95, 23);
            this.button11.TabIndex = 6;
            this.button11.Text = "��ҵ�鴦��Ϣ";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(198, 561);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "������ҵ��ϸ";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dgvQyxx
            // 
            this.dgvQyxx.AllowUserToAddRows = false;
            this.dgvQyxx.AllowUserToDeleteRows = false;
            this.dgvQyxx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQyxx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQyxx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32});
            this.dgvQyxx.Location = new System.Drawing.Point(8, 8);
            this.dgvQyxx.Name = "dgvQyxx";
            this.dgvQyxx.RowHeadersVisible = false;
            this.dgvQyxx.RowTemplate.Height = 23;
            this.dgvQyxx.Size = new System.Drawing.Size(312, 546);
            this.dgvQyxx.TabIndex = 3;
            this.dgvQyxx.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQyxx_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn31.Frozen = true;
            this.dataGridViewTextBoxColumn31.HeaderText = "������";
            this.dataGridViewTextBoxColumn31.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn31.Width = 130;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn32.HeaderText = "ֵ";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnSaveFW);
            this.tabPage5.Controls.Add(this.dgvFW);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(322, 593);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "���ݽ���";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnSaveFW
            // 
            this.btnSaveFW.Location = new System.Drawing.Point(151, 562);
            this.btnSaveFW.Name = "btnSaveFW";
            this.btnSaveFW.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFW.TabIndex = 5;
            this.btnSaveFW.Text = "����";
            this.btnSaveFW.UseVisualStyleBackColor = true;
            this.btnSaveFW.Visible = false;
            this.btnSaveFW.Click += new System.EventHandler(this.btnSaveFW_Click);
            // 
            // dgvFW
            // 
            this.dgvFW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvFW.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvFW.Location = new System.Drawing.Point(0, 0);
            this.dgvFW.Name = "dgvFW";
            this.dgvFW.RowHeadersVisible = false;
            this.dgvFW.RowTemplate.Height = 23;
            this.dgvFW.Size = new System.Drawing.Size(322, 556);
            this.dgvFW.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "������";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn2.HeaderText = "ֵ";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 179;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 179;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvCSGH);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(322, 593);
            this.tabPage3.TabIndex = 6;
            this.tabPage3.Text = "���й滮";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvCSGH
            // 
            this.dgvCSGH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCSGH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgvCSGH.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvCSGH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCSGH.Location = new System.Drawing.Point(0, 0);
            this.dgvCSGH.Name = "dgvCSGH";
            this.dgvCSGH.RowHeadersVisible = false;
            this.dgvCSGH.RowTemplate.Height = 23;
            this.dgvCSGH.Size = new System.Drawing.Size(322, 593);
            this.dgvCSGH.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "������";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 130;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn8.HeaderText = "ֵ";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(1019, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1, 619);
            this.splitter3.TabIndex = 14;
            this.splitter3.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 619);
            this.splitter2.TabIndex = 13;
            this.splitter2.TabStop = false;
            // 
            // Column26
            // 
            this.Column26.HeaderText = "ѡ��";
            this.Column26.Name = "Column26";
            this.Column26.Width = 40;
            // 
            // cmsOrg
            // 
            this.cmsOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.�����Ա�ToolStripMenuItem,
            this.ͼ�����ToolStripMenuItem});
            this.cmsOrg.Name = "cmsOrg";
            this.cmsOrg.Size = new System.Drawing.Size(137, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�������ToolStripMenuItem,
            this.�õط�ΧToolStripMenuItem,
            this.���ݽ���ToolStripMenuItem,
            this.Χǽդ��ToolStripMenuItem,
            this.�ⲿ�豸ToolStripMenuItem,
            this.��������ToolStripMenuItem,
            this.��ͨ·��ToolStripMenuItem,
            this.��·����ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "��ʾ���Ա�";
            // 
            // �������ToolStripMenuItem
            // 
            this.�������ToolStripMenuItem.Name = "�������ToolStripMenuItem";
            this.�������ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.�������ToolStripMenuItem.Text = "�������";
            // 
            // �õط�ΧToolStripMenuItem
            // 
            this.�õط�ΧToolStripMenuItem.Name = "�õط�ΧToolStripMenuItem";
            this.�õط�ΧToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.�õط�ΧToolStripMenuItem.Text = "�õط�Χ";
            // 
            // ���ݽ���ToolStripMenuItem
            // 
            this.���ݽ���ToolStripMenuItem.Name = "���ݽ���ToolStripMenuItem";
            this.���ݽ���ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.���ݽ���ToolStripMenuItem.Text = "���ݽ���";
            // 
            // Χǽդ��ToolStripMenuItem
            // 
            this.Χǽդ��ToolStripMenuItem.Name = "Χǽդ��ToolStripMenuItem";
            this.Χǽդ��ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.Χǽդ��ToolStripMenuItem.Text = "Χǽդ��";
            // 
            // �ⲿ�豸ToolStripMenuItem
            // 
            this.�ⲿ�豸ToolStripMenuItem.Name = "�ⲿ�豸ToolStripMenuItem";
            this.�ⲿ�豸ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.�ⲿ�豸ToolStripMenuItem.Text = "�ⲿ�豸";
            // 
            // ��������ToolStripMenuItem
            // 
            this.��������ToolStripMenuItem.Name = "��������ToolStripMenuItem";
            this.��������ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.��������ToolStripMenuItem.Text = "��������";
            // 
            // ��ͨ·��ToolStripMenuItem
            // 
            this.��ͨ·��ToolStripMenuItem.Name = "��ͨ·��ToolStripMenuItem";
            this.��ͨ·��ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.��ͨ·��ToolStripMenuItem.Text = "��ͨ·��";
            // 
            // ��·����ToolStripMenuItem
            // 
            this.��·����ToolStripMenuItem.Name = "��·����ToolStripMenuItem";
            this.��·����ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.��·����ToolStripMenuItem.Text = "��·����";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "���ݵ���";
            // 
            // �����Ա�ToolStripMenuItem
            // 
            this.�����Ա�ToolStripMenuItem.Name = "�����Ա�ToolStripMenuItem";
            this.�����Ա�ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.�����Ա�ToolStripMenuItem.Text = "�����Ա�";
            // 
            // ͼ�����ToolStripMenuItem
            // 
            this.ͼ�����ToolStripMenuItem.Name = "ͼ�����ToolStripMenuItem";
            this.ͼ�����ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ͼ�����ToolStripMenuItem.Text = "ͼ�����";
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1276, 28);
            this.axToolbarControl1.TabIndex = 3;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            this.axToolbarControl1.OnItemClick += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnItemClickEventHandler(this.axToolbarControl1_OnItemClick);
            // 
            // chkImage
            // 
            this.chkImage.AutoSize = true;
            this.chkImage.Location = new System.Drawing.Point(890, 28);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(15, 14);
            this.chkImage.TabIndex = 10;
            this.chkImage.UseVisualStyleBackColor = true;
            this.chkImage.Visible = false;
            this.chkImage.CheckedChanged += new System.EventHandler(this.chkImage_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLtnInfo
            // 
            this.btnLtnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLtnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLtnInfo.Location = new System.Drawing.Point(506, 28);
            this.btnLtnInfo.Name = "btnLtnInfo";
            this.btnLtnInfo.Size = new System.Drawing.Size(23, 23);
            this.btnLtnInfo.TabIndex = 13;
            this.btnLtnInfo.Text = "��";
            this.btnLtnInfo.UseVisualStyleBackColor = true;
            this.btnLtnInfo.Click += new System.EventHandler(this.btnLtnInfo_Click);
            this.btnLtnInfo.MouseEnter += new System.EventHandler(this.btnLtnInfo_MouseEnter);
            this.btnLtnInfo.Move += new System.EventHandler(this.btnLtnInfo_Move);
            // 
            // button15
            // 
            this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(534, 28);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(23, 23);
            this.button15.TabIndex = 14;
            this.button15.Text = "��";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(563, 28);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(23, 23);
            this.button16.TabIndex = 15;
            this.button16.Text = "��";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(606, 28);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(23, 23);
            this.button17.TabIndex = 16;
            this.button17.Text = "��";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(635, 28);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(23, 23);
            this.button18.TabIndex = 17;
            this.button18.Text = "��";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(704, 28);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(64, 23);
            this.button19.TabIndex = 18;
            this.button19.Text = "��ҵ��Ƭ";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(666, 28);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(21, 23);
            this.button20.TabIndex = 19;
            this.button20.Text = "��";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(774, 28);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(64, 23);
            this.button21.TabIndex = 20;
            this.button21.Text = "��ȫ���";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click_1);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "�õص�λ����";
            this.dataGridViewTextBoxColumn3.HeaderText = "�õ���ҵ����";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "��������������";
            this.dataGridViewTextBoxColumn4.HeaderText = "����������";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "���ط�֤���";
            this.dataGridViewTextBoxColumn5.HeaderText = "���ط�֤���";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ȩ������";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ȩ������";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn9.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn10.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 110;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "��������������";
            this.dataGridViewTextBoxColumn11.HeaderText = "����������";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 110;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn12.HeaderText = "�����õ���ҵ";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 110;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn21.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Visible = false;
            this.dataGridViewTextBoxColumn21.Width = 110;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "��������������";
            this.dataGridViewTextBoxColumn22.HeaderText = "����������";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Width = 110;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "�õ���ҵ����";
            this.dataGridViewTextBoxColumn23.HeaderText = "�����õ���ҵ";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Width = 110;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "��׼��;";
            this.dataGridViewTextBoxColumn24.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Width = 110;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "ʵ����;";
            this.dataGridViewTextBoxColumn25.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn26.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Width = 120;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn27.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn28.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "����������";
            this.dataGridViewTextBoxColumn29.HeaderText = "����������";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn30.HeaderText = "�鴦���";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "��׼��;";
            dataGridViewCellStyle7.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn35.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Visible = false;
            this.dataGridViewTextBoxColumn35.Width = 319;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "ʵ����;";
            dataGridViewCellStyle8.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn36.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 160;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle9.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn37.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Width = 159;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "��ҵ����������";
            dataGridViewCellStyle10.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn38.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Visible = false;
            this.dataGridViewTextBoxColumn38.Width = 120;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle11.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn39.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 300;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle12.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn40.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Visible = false;
            this.dataGridViewTextBoxColumn40.Width = 300;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle13.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn41.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn41.HeaderText = "���";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Visible = false;
            this.dataGridViewTextBoxColumn41.Width = 159;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn42.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            this.dataGridViewTextBoxColumn42.Width = 160;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle14.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn43.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn43.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Visible = false;
            this.dataGridViewTextBoxColumn43.Width = 159;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn44.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle15.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn44.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn44.Frozen = true;
            this.dataGridViewTextBoxColumn44.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn44.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Visible = false;
            this.dataGridViewTextBoxColumn44.Width = 160;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn45.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle16.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn45.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn45.Frozen = true;
            this.dataGridViewTextBoxColumn45.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn45.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn45.Visible = false;
            this.dataGridViewTextBoxColumn45.Width = 159;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn46.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn46.Frozen = true;
            this.dataGridViewTextBoxColumn46.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn46.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn46.Visible = false;
            this.dataGridViewTextBoxColumn46.Width = 160;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn47.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn47.Frozen = true;
            this.dataGridViewTextBoxColumn47.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            this.dataGridViewTextBoxColumn47.Visible = false;
            this.dataGridViewTextBoxColumn47.Width = 159;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn48.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn48.Frozen = true;
            this.dataGridViewTextBoxColumn48.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            this.dataGridViewTextBoxColumn48.Visible = false;
            this.dataGridViewTextBoxColumn48.Width = 160;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn49.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn49.Frozen = true;
            this.dataGridViewTextBoxColumn49.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.ReadOnly = true;
            this.dataGridViewTextBoxColumn49.Width = 159;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn50.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn50.Frozen = true;
            this.dataGridViewTextBoxColumn50.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            this.dataGridViewTextBoxColumn50.Width = 160;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn51.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.ReadOnly = true;
            this.dataGridViewTextBoxColumn51.Width = 159;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn52.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            this.dataGridViewTextBoxColumn52.Width = 160;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn53.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            this.dataGridViewTextBoxColumn53.Visible = false;
            this.dataGridViewTextBoxColumn53.Width = 159;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn54.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.ReadOnly = true;
            this.dataGridViewTextBoxColumn54.Width = 160;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle17.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn55.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn55.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.ReadOnly = true;
            this.dataGridViewTextBoxColumn55.Width = 159;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle18.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn56.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn56.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.ReadOnly = true;
            this.dataGridViewTextBoxColumn56.Width = 160;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle19.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn57.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn57.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.ReadOnly = true;
            this.dataGridViewTextBoxColumn57.Width = 159;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle20.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn58.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn58.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.ReadOnly = true;
            this.dataGridViewTextBoxColumn58.Width = 160;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle21.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn59.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn59.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            this.dataGridViewTextBoxColumn59.ReadOnly = true;
            this.dataGridViewTextBoxColumn59.Width = 159;
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle22.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn60.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn60.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.ReadOnly = true;
            this.dataGridViewTextBoxColumn60.Visible = false;
            this.dataGridViewTextBoxColumn60.Width = 160;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn61.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            this.dataGridViewTextBoxColumn61.ReadOnly = true;
            this.dataGridViewTextBoxColumn61.Width = 159;
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.DataPropertyName = "key";
            dataGridViewCellStyle23.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn62.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn62.HeaderText = "������";
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            this.dataGridViewTextBoxColumn62.ReadOnly = true;
            this.dataGridViewTextBoxColumn62.Visible = false;
            this.dataGridViewTextBoxColumn62.Width = 160;
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.DataPropertyName = "value";
            dataGridViewCellStyle24.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn63.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn63.HeaderText = "����";
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            this.dataGridViewTextBoxColumn63.ReadOnly = true;
            this.dataGridViewTextBoxColumn63.Visible = false;
            this.dataGridViewTextBoxColumn63.Width = 159;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle25.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn64.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn64.HeaderText = "������";
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.ReadOnly = true;
            this.dataGridViewTextBoxColumn64.Width = 160;
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle26.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn65.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn65.HeaderText = "ֵ";
            this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            this.dataGridViewTextBoxColumn65.ReadOnly = true;
            this.dataGridViewTextBoxColumn65.Visible = false;
            this.dataGridViewTextBoxColumn65.Width = 159;
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn66.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn66.Frozen = true;
            this.dataGridViewTextBoxColumn66.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn66.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            this.dataGridViewTextBoxColumn66.ReadOnly = true;
            this.dataGridViewTextBoxColumn66.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn66.Width = 159;
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn67.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn67.Frozen = true;
            this.dataGridViewTextBoxColumn67.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn67.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            this.dataGridViewTextBoxColumn67.ReadOnly = true;
            this.dataGridViewTextBoxColumn67.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn67.Width = 150;
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn68.DataPropertyName = "��������������";
            this.dataGridViewTextBoxColumn68.HeaderText = "����������";
            this.dataGridViewTextBoxColumn68.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            this.dataGridViewTextBoxColumn68.ReadOnly = true;
            this.dataGridViewTextBoxColumn68.Width = 159;
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn69.HeaderText = "�����õ���ҵ";
            this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            this.dataGridViewTextBoxColumn69.ReadOnly = true;
            this.dataGridViewTextBoxColumn69.Visible = false;
            this.dataGridViewTextBoxColumn69.Width = 110;
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.DataPropertyName = "��׼��;";
            this.dataGridViewTextBoxColumn70.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            this.dataGridViewTextBoxColumn70.Width = 319;
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.DataPropertyName = "ʵ����;";
            this.dataGridViewTextBoxColumn71.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            this.dataGridViewTextBoxColumn71.ReadOnly = true;
            this.dataGridViewTextBoxColumn71.Width = 160;
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn72.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            this.dataGridViewTextBoxColumn72.Width = 159;
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn73.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            this.dataGridViewTextBoxColumn73.ReadOnly = true;
            this.dataGridViewTextBoxColumn73.Width = 120;
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn74.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            this.dataGridViewTextBoxColumn74.Width = 159;
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn75.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            this.dataGridViewTextBoxColumn75.ReadOnly = true;
            this.dataGridViewTextBoxColumn75.Width = 319;
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.DataPropertyName = "OBJECTID";
            this.dataGridViewTextBoxColumn76.HeaderText = "objid";
            this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            this.dataGridViewTextBoxColumn76.Visible = false;
            this.dataGridViewTextBoxColumn76.Width = 159;
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.DataPropertyName = "�ؿ����";
            this.dataGridViewTextBoxColumn77.HeaderText = "�ؿ����";
            this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            this.dataGridViewTextBoxColumn77.ReadOnly = true;
            this.dataGridViewTextBoxColumn77.Visible = false;
            this.dataGridViewTextBoxColumn77.Width = 160;
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn78.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            this.dataGridViewTextBoxColumn78.Width = 319;
            // 
            // dataGridViewTextBoxColumn79
            // 
            this.dataGridViewTextBoxColumn79.DataPropertyName = "������ҵ����";
            dataGridViewCellStyle27.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn79.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn79.FillWeight = 68.96552F;
            this.dataGridViewTextBoxColumn79.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            this.dataGridViewTextBoxColumn79.ReadOnly = true;
            this.dataGridViewTextBoxColumn79.Width = 110;
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.DataPropertyName = "��������������";
            dataGridViewCellStyle28.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn80.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn80.FillWeight = 131.0345F;
            this.dataGridViewTextBoxColumn80.HeaderText = "����������";
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            this.dataGridViewTextBoxColumn80.Width = 209;
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.DataPropertyName = "��ҵ����������";
            dataGridViewCellStyle29.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn81.DefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTextBoxColumn81.FillWeight = 68.96552F;
            this.dataGridViewTextBoxColumn81.HeaderText = "�����õ���ҵ";
            this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            this.dataGridViewTextBoxColumn81.ReadOnly = true;
            this.dataGridViewTextBoxColumn81.Width = 110;
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.DataPropertyName = "��׼��;";
            dataGridViewCellStyle30.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn82.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn82.FillWeight = 131.0345F;
            this.dataGridViewTextBoxColumn82.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
            this.dataGridViewTextBoxColumn82.Width = 209;
            // 
            // dataGridViewTextBoxColumn83
            // 
            this.dataGridViewTextBoxColumn83.DataPropertyName = "ʵ����;";
            this.dataGridViewTextBoxColumn83.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
            this.dataGridViewTextBoxColumn83.ReadOnly = true;
            this.dataGridViewTextBoxColumn83.Width = 319;
            // 
            // dataGridViewTextBoxColumn84
            // 
            this.dataGridViewTextBoxColumn84.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn84.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
            this.dataGridViewTextBoxColumn84.Visible = false;
            this.dataGridViewTextBoxColumn84.Width = 159;
            // 
            // dataGridViewTextBoxColumn85
            // 
            this.dataGridViewTextBoxColumn85.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn85.FillWeight = 75.23511F;
            this.dataGridViewTextBoxColumn85.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
            this.dataGridViewTextBoxColumn85.ReadOnly = true;
            this.dataGridViewTextBoxColumn85.Width = 120;
            // 
            // dataGridViewTextBoxColumn86
            // 
            this.dataGridViewTextBoxColumn86.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn86.FillWeight = 124.7649F;
            this.dataGridViewTextBoxColumn86.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
            this.dataGridViewTextBoxColumn86.Visible = false;
            this.dataGridViewTextBoxColumn86.Width = 199;
            // 
            // dataGridViewTextBoxColumn87
            // 
            this.dataGridViewTextBoxColumn87.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle31.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn87.DefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridViewTextBoxColumn87.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            this.dataGridViewTextBoxColumn87.ReadOnly = true;
            this.dataGridViewTextBoxColumn87.Width = 33;
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.DataPropertyName = "OBJECTID";
            dataGridViewCellStyle32.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn88.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridViewTextBoxColumn88.HeaderText = "objid";
            this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
            this.dataGridViewTextBoxColumn88.ReadOnly = true;
            this.dataGridViewTextBoxColumn88.Visible = false;
            this.dataGridViewTextBoxColumn88.Width = 16;
            // 
            // dataGridViewTextBoxColumn89
            // 
            this.dataGridViewTextBoxColumn89.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn89.DataPropertyName = "�ؿ����";
            dataGridViewCellStyle33.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn89.DefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridViewTextBoxColumn89.Frozen = true;
            this.dataGridViewTextBoxColumn89.HeaderText = "�ؿ����";
            this.dataGridViewTextBoxColumn89.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
            this.dataGridViewTextBoxColumn89.ReadOnly = true;
            this.dataGridViewTextBoxColumn89.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn89.Visible = false;
            this.dataGridViewTextBoxColumn89.Width = 160;
            // 
            // dataGridViewTextBoxColumn90
            // 
            this.dataGridViewTextBoxColumn90.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle34.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn90.DefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridViewTextBoxColumn90.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
            this.dataGridViewTextBoxColumn90.ReadOnly = true;
            this.dataGridViewTextBoxColumn90.Width = 319;
            // 
            // dataGridViewTextBoxColumn91
            // 
            this.dataGridViewTextBoxColumn91.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn91.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
            this.dataGridViewTextBoxColumn91.Width = 110;
            // 
            // dataGridViewTextBoxColumn92
            // 
            this.dataGridViewTextBoxColumn92.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn92.DataPropertyName = "��������������";
            this.dataGridViewTextBoxColumn92.Frozen = true;
            this.dataGridViewTextBoxColumn92.HeaderText = "����������";
            this.dataGridViewTextBoxColumn92.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
            this.dataGridViewTextBoxColumn92.ReadOnly = true;
            this.dataGridViewTextBoxColumn92.Width = 150;
            // 
            // dataGridViewTextBoxColumn93
            // 
            this.dataGridViewTextBoxColumn93.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn93.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn93.HeaderText = "�����õ���ҵ";
            this.dataGridViewTextBoxColumn93.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
            this.dataGridViewTextBoxColumn93.Width = 150;
            // 
            // dataGridViewTextBoxColumn94
            // 
            this.dataGridViewTextBoxColumn94.DataPropertyName = "��׼��;";
            this.dataGridViewTextBoxColumn94.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
            this.dataGridViewTextBoxColumn94.ReadOnly = true;
            this.dataGridViewTextBoxColumn94.Visible = false;
            // 
            // dataGridViewTextBoxColumn95
            // 
            this.dataGridViewTextBoxColumn95.DataPropertyName = "ʵ����;";
            this.dataGridViewTextBoxColumn95.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
            this.dataGridViewTextBoxColumn95.Width = 319;
            // 
            // dataGridViewTextBoxColumn96
            // 
            this.dataGridViewTextBoxColumn96.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn96.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
            this.dataGridViewTextBoxColumn96.ReadOnly = true;
            this.dataGridViewTextBoxColumn96.Width = 160;
            // 
            // dataGridViewTextBoxColumn97
            // 
            this.dataGridViewTextBoxColumn97.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn97.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
            this.dataGridViewTextBoxColumn97.Width = 120;
            // 
            // dataGridViewTextBoxColumn98
            // 
            this.dataGridViewTextBoxColumn98.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn98.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
            this.dataGridViewTextBoxColumn98.ReadOnly = true;
            this.dataGridViewTextBoxColumn98.Width = 160;
            // 
            // dataGridViewTextBoxColumn99
            // 
            this.dataGridViewTextBoxColumn99.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn99.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
            this.dataGridViewTextBoxColumn99.Width = 159;
            // 
            // dataGridViewTextBoxColumn100
            // 
            this.dataGridViewTextBoxColumn100.DataPropertyName = "����������";
            this.dataGridViewTextBoxColumn100.HeaderText = "����������";
            this.dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
            this.dataGridViewTextBoxColumn100.ReadOnly = true;
            this.dataGridViewTextBoxColumn100.Width = 160;
            // 
            // dataGridViewTextBoxColumn101
            // 
            this.dataGridViewTextBoxColumn101.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn101.HeaderText = "�鴦���";
            this.dataGridViewTextBoxColumn101.Name = "dataGridViewTextBoxColumn101";
            this.dataGridViewTextBoxColumn101.Width = 159;
            // 
            // dataGridViewTextBoxColumn102
            // 
            this.dataGridViewTextBoxColumn102.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn102.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn102.Name = "dataGridViewTextBoxColumn102";
            this.dataGridViewTextBoxColumn102.ReadOnly = true;
            this.dataGridViewTextBoxColumn102.Width = 160;
            // 
            // dataGridViewTextBoxColumn103
            // 
            this.dataGridViewTextBoxColumn103.DataPropertyName = "�鴦����";
            this.dataGridViewTextBoxColumn103.HeaderText = "�鴦����";
            this.dataGridViewTextBoxColumn103.Name = "dataGridViewTextBoxColumn103";
            this.dataGridViewTextBoxColumn103.Width = 159;
            // 
            // dataGridViewTextBoxColumn104
            // 
            this.dataGridViewTextBoxColumn104.DataPropertyName = "����";
            dataGridViewCellStyle35.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn104.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewTextBoxColumn104.HeaderText = "����";
            this.dataGridViewTextBoxColumn104.Name = "dataGridViewTextBoxColumn104";
            this.dataGridViewTextBoxColumn104.ReadOnly = true;
            this.dataGridViewTextBoxColumn104.Width = 160;
            // 
            // dataGridViewTextBoxColumn105
            // 
            this.dataGridViewTextBoxColumn105.DataPropertyName = "�鴦��ʼ����";
            dataGridViewCellStyle36.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn105.DefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridViewTextBoxColumn105.HeaderText = "�鴦��ʼ����";
            this.dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
            this.dataGridViewTextBoxColumn105.Width = 159;
            // 
            // dataGridViewTextBoxColumn106
            // 
            this.dataGridViewTextBoxColumn106.DataPropertyName = "�鴦��ֹ����";
            dataGridViewCellStyle37.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn106.DefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridViewTextBoxColumn106.HeaderText = "�鴦��ֹ����";
            this.dataGridViewTextBoxColumn106.Name = "dataGridViewTextBoxColumn106";
            this.dataGridViewTextBoxColumn106.ReadOnly = true;
            this.dataGridViewTextBoxColumn106.Width = 160;
            // 
            // dataGridViewTextBoxColumn107
            // 
            this.dataGridViewTextBoxColumn107.DataPropertyName = "��ע����";
            dataGridViewCellStyle38.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn107.DefaultCellStyle = dataGridViewCellStyle38;
            this.dataGridViewTextBoxColumn107.HeaderText = "��ע����";
            this.dataGridViewTextBoxColumn107.Name = "dataGridViewTextBoxColumn107";
            this.dataGridViewTextBoxColumn107.Width = 159;
            // 
            // dataGridViewTextBoxColumn108
            // 
            this.dataGridViewTextBoxColumn108.DataPropertyName = "��������";
            dataGridViewCellStyle39.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn108.DefaultCellStyle = dataGridViewCellStyle39;
            this.dataGridViewTextBoxColumn108.HeaderText = "��������";
            this.dataGridViewTextBoxColumn108.Name = "dataGridViewTextBoxColumn108";
            this.dataGridViewTextBoxColumn108.ReadOnly = true;
            this.dataGridViewTextBoxColumn108.Width = 160;
            // 
            // dataGridViewTextBoxColumn109
            // 
            this.dataGridViewTextBoxColumn109.DataPropertyName = "�鴦��ע����";
            this.dataGridViewTextBoxColumn109.HeaderText = "�鴦��ע����";
            this.dataGridViewTextBoxColumn109.Name = "dataGridViewTextBoxColumn109";
            this.dataGridViewTextBoxColumn109.Width = 159;
            // 
            // dataGridViewTextBoxColumn110
            // 
            this.dataGridViewTextBoxColumn110.DataPropertyName = "OBJECTID";
            this.dataGridViewTextBoxColumn110.HeaderText = "objid";
            this.dataGridViewTextBoxColumn110.Name = "dataGridViewTextBoxColumn110";
            this.dataGridViewTextBoxColumn110.ReadOnly = true;
            this.dataGridViewTextBoxColumn110.Visible = false;
            this.dataGridViewTextBoxColumn110.Width = 160;
            // 
            // dataGridViewTextBoxColumn111
            // 
            this.dataGridViewTextBoxColumn111.DataPropertyName = "�ؿ����";
            this.dataGridViewTextBoxColumn111.HeaderText = "�ؿ����";
            this.dataGridViewTextBoxColumn111.Name = "dataGridViewTextBoxColumn111";
            this.dataGridViewTextBoxColumn111.ReadOnly = true;
            this.dataGridViewTextBoxColumn111.Width = 319;
            // 
            // dataGridViewTextBoxColumn112
            // 
            this.dataGridViewTextBoxColumn112.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn112.FillWeight = 30.30302F;
            this.dataGridViewTextBoxColumn112.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn112.Name = "dataGridViewTextBoxColumn112";
            this.dataGridViewTextBoxColumn112.ReadOnly = true;
            this.dataGridViewTextBoxColumn112.Width = 5;
            // 
            // dataGridViewTextBoxColumn113
            // 
            this.dataGridViewTextBoxColumn113.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn113.FillWeight = 169.697F;
            this.dataGridViewTextBoxColumn113.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn113.Name = "dataGridViewTextBoxColumn113";
            this.dataGridViewTextBoxColumn113.ReadOnly = true;
            this.dataGridViewTextBoxColumn113.Width = 28;
            // 
            // dataGridViewTextBoxColumn114
            // 
            this.dataGridViewTextBoxColumn114.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn114.DataPropertyName = "�ֶ���";
            this.dataGridViewTextBoxColumn114.Frozen = true;
            this.dataGridViewTextBoxColumn114.HeaderText = "������";
            this.dataGridViewTextBoxColumn114.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn114.Name = "dataGridViewTextBoxColumn114";
            this.dataGridViewTextBoxColumn114.ReadOnly = true;
            this.dataGridViewTextBoxColumn114.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn114.Width = 130;
            // 
            // dataGridViewTextBoxColumn115
            // 
            this.dataGridViewTextBoxColumn115.DataPropertyName = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn115.HeaderText = "ֵ";
            this.dataGridViewTextBoxColumn115.Name = "dataGridViewTextBoxColumn115";
            this.dataGridViewTextBoxColumn115.ReadOnly = true;
            this.dataGridViewTextBoxColumn115.Width = 179;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "��������";
            this.Column28.HeaderText = "��������";
            this.Column28.Name = "Column28";
            // 
            // Column29
            // 
            this.Column29.DataPropertyName = "�������������";
            this.Column29.HeaderText = "�������������";
            this.Column29.Name = "Column29";
            // 
            // Column30
            // 
            this.Column30.DataPropertyName = "��������������";
            this.Column30.HeaderText = "��������������";
            this.Column30.Name = "Column30";
            // 
            // Column31
            // 
            this.Column31.DataPropertyName = "�������������";
            this.Column31.HeaderText = "�������������";
            this.Column31.Name = "Column31";
            // 
            // Column32
            // 
            this.Column32.DataPropertyName = "��������������";
            this.Column32.HeaderText = "��������������";
            this.Column32.Name = "Column32";
            // 
            // Column33
            // 
            this.Column33.DataPropertyName = "�ؿ鸽���������";
            this.Column33.HeaderText = "�ؿ鸽���������";
            this.Column33.Name = "Column33";
            // 
            // Column34
            // 
            this.Column34.DataPropertyName = "�ؿ鸽������ռ�����";
            this.Column34.HeaderText = "�ؿ鸽������ռ�����";
            this.Column34.Name = "Column34";
            // 
            // Column35
            // 
            this.Column35.DataPropertyName = "����ʹ��������";
            this.Column35.HeaderText = "����ʹ��������";
            this.Column35.Name = "Column35";
            // 
            // dataGridViewTextBoxColumn116
            // 
            this.dataGridViewTextBoxColumn116.DataPropertyName = "��׼��;";
            this.dataGridViewTextBoxColumn116.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn116.Name = "dataGridViewTextBoxColumn116";
            // 
            // dataGridViewTextBoxColumn117
            // 
            this.dataGridViewTextBoxColumn117.DataPropertyName = "ʵ����;";
            this.dataGridViewTextBoxColumn117.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn117.Name = "dataGridViewTextBoxColumn117";
            // 
            // Column36
            // 
            this.Column36.DataPropertyName = "����֤��";
            this.Column36.HeaderText = "����֤��";
            this.Column36.Name = "Column36";
            // 
            // Column37
            // 
            this.Column37.DataPropertyName = "���ط�֤���";
            this.Column37.HeaderText = "���ط�֤���";
            this.Column37.Name = "Column37";
            // 
            // Column38
            // 
            this.Column38.DataPropertyName = "ʵ��ռ�����";
            this.Column38.HeaderText = "ʵ��ռ�����";
            this.Column38.Name = "Column38";
            // 
            // Column39
            // 
            this.Column39.DataPropertyName = "�õ���ҵ����";
            this.Column39.HeaderText = "�õ���ҵ����";
            this.Column39.Name = "Column39";
            // 
            // Column40
            // 
            this.Column40.DataPropertyName = "�Ƿ�Ϊ���������ʲ���ҵ";
            this.Column40.HeaderText = "�Ƿ����������ʲ���ҵ";
            this.Column40.Name = "Column40";
            // 
            // dataGridViewTextBoxColumn119
            // 
            this.dataGridViewTextBoxColumn119.DataPropertyName = "��ҵ����������";
            this.dataGridViewTextBoxColumn119.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn119.Name = "dataGridViewTextBoxColumn119";
            this.dataGridViewTextBoxColumn119.Width = 120;
            // 
            // dataGridViewTextBoxColumn120
            // 
            this.dataGridViewTextBoxColumn120.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn120.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn120.Name = "dataGridViewTextBoxColumn120";
            // 
            // Column41
            // 
            this.Column41.DataPropertyName = "ע���ʱ�";
            this.Column41.HeaderText = "ע���ʱ�";
            this.Column41.Name = "Column41";
            // 
            // Column42
            // 
            this.Column42.DataPropertyName = "���˴���";
            this.Column42.HeaderText = "���˴���";
            this.Column42.Name = "Column42";
            // 
            // Column43
            // 
            this.Column43.DataPropertyName = "��ϵ�绰";
            this.Column43.HeaderText = "��ϵ�绰";
            this.Column43.Name = "Column43";
            // 
            // Column44
            // 
            this.Column44.DataPropertyName = "��������";
            this.Column44.HeaderText = "��������";
            this.Column44.Name = "Column44";
            // 
            // Column45
            // 
            this.Column45.DataPropertyName = "ͨѶ��ַ";
            this.Column45.HeaderText = "ͨѶ��ַ";
            this.Column45.Name = "Column45";
            // 
            // dataGridViewTextBoxColumn121
            // 
            this.dataGridViewTextBoxColumn121.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn121.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn121.Name = "dataGridViewTextBoxColumn121";
            // 
            // Column46
            // 
            this.Column46.DataPropertyName = "�ܺ�";
            this.Column46.HeaderText = "�ܺ�";
            this.Column46.Name = "Column46";
            // 
            // Column47
            // 
            this.Column47.DataPropertyName = "��ֵ";
            this.Column47.HeaderText = "��ֵ";
            this.Column47.Name = "Column47";
            // 
            // Column48
            // 
            this.Column48.DataPropertyName = "˰��";
            this.Column48.HeaderText = "˰��";
            this.Column48.Name = "Column48";
            // 
            // Column49
            // 
            this.Column49.DataPropertyName = "���";
            this.Column49.HeaderText = "���";
            this.Column49.Name = "Column49";
            // 
            // Column50
            // 
            this.Column50.DataPropertyName = "�������";
            this.Column50.HeaderText = "�������";
            this.Column50.Name = "Column50";
            // 
            // Column51
            // 
            this.Column51.DataPropertyName = "��ҵ����";
            this.Column51.HeaderText = "��ҵ����";
            this.Column51.Name = "Column51";
            // 
            // Column52
            // 
            this.Column52.DataPropertyName = "��������";
            this.Column52.HeaderText = "��������";
            this.Column52.Name = "Column52";
            // 
            // Column53
            // 
            this.Column53.DataPropertyName = "�ʲ�����";
            this.Column53.HeaderText = "�ʲ�����";
            this.Column53.Name = "Column53";
            // 
            // Column54
            // 
            this.Column54.DataPropertyName = "�������";
            this.Column54.HeaderText = "�������";
            this.Column54.Name = "Column54";
            // 
            // Column55
            // 
            this.Column55.DataPropertyName = "��Ѻ���";
            this.Column55.HeaderText = "��Ѻ���";
            this.Column55.Name = "Column55";
            // 
            // ����ֲ���ʾToolStripMenuItem
            // 
            this.����ֲ���ʾToolStripMenuItem.Name = "����ֲ���ʾToolStripMenuItem";
            this.����ֲ���ʾToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.����ֲ���ʾToolStripMenuItem.Text = "����ֲ���ʾ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 694);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.btnLtnInfo);
            this.Controls.Add(this.chkImage);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "�⽭���ü�����������ҵ��Ϣ����ϵͳ���1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_11)).EndInit();
            this.cmsLtdDetailInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_12)).EndInit();
            this.cmdLtdDetailInfo_zl.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_21)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_31)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQycc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQyxx)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFW)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSGH)).EndInit();
            this.cmsOrg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem Maptrans;
        private System.Windows.Forms.ToolStripMenuItem ͼ�����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��ѯToolStripMenuItem1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ToolStripMenuItem �ۺϲ�ѯToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsOrg;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem �������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �õط�ΧToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ݽ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Χǽդ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �ⲿ�豸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ͨ·��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��·����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����Ա�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ͼ�����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsslScale;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripMenuItem ͼ�δ���ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshMap;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �û�����ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem �û�����ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem �����޸�ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboLayerName;
        private System.Windows.Forms.CheckBox chkImage;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��Ϣά��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ͼToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        public ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvFW;
        private System.Windows.Forms.Button btnSaveFW;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvCSGH;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��ѯ��ϢToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��ѯ��ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ҵ���Ʋ�ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ҵ��ѯ��ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ͼ�����������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ǰ���巶Χ��ӡͼ��ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgvT2_11;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dgvT2_21;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView dgvT2_31;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnPrint1;
        private System.Windows.Forms.Button btnExport1;
        private System.Windows.Forms.CheckBox chkZlqy;
        private System.Windows.Forms.CheckBox chkYdqy;
        private System.Windows.Forms.Button btnPosition1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.DataGridView dgvQyxx;
        private System.Windows.Forms.Button btnSaveQyfw;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvQycc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ComboBox cboTransp;
        private System.Windows.Forms.ComboBox cboLayerFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn101;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn109;
        private System.Windows.Forms.DataGridView dgvT2_12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn110;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn112;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn113;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn116;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn117;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column36;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column37;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column38;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column39;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn119;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn120;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column42;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column43;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column44;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn121;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column46;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column47;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column48;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column49;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column50;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column51;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column52;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column53;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column54;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn114;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn115;
        //private controls.ucdgvQyxx ucdgvQyxx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem ����ҵ�ۺ���Ϣ��ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ҵ���Ͳ�ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �˶�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �Ʊ�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Ҷ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ѶToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ͳ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ڱ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �Ľ̷���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ڴ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ҵ��ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��������ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����ѯ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ȫ�ۺϲ�ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ݵ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ݵ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������״����ToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnLtnInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.ToolStripMenuItem ר��ͼ���1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��Ϣ�޸�ToolStripMenuItem;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn122;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn123;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn124;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn125;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn127;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn128;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn132;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn133;
        private System.Windows.Forms.ToolStripMenuItem ����ҵ����ͳ��ToolStripMenuItem;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column56;
        private System.Windows.Forms.ToolStripMenuItem ͳ��ɸѡToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLtdDetailInfo;
        private System.Windows.Forms.ToolStripMenuItem ��ϸ��ϢToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ͳ��ɸѡToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ����ɸѡToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ũ��ʳƷ�ӹ�ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ͨ���豸����ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��������ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �ǽ���������ƷҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ҽҩ����ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������е����������ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ֽ��ֽ��ƷҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����Ǳ�����ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ӡˢ�ͼ�¼ý�鸴��ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ƷҵToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmdLtdDetailInfo_zl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ�ϱ�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �������ݵ���ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem ����ֲ���ʾToolStripMenuItem;
    }
}

