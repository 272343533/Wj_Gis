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
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("��ҵ��Ƭ");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("��ȫ���");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("���ƾ���");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("���ƾ���");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("������");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("������");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("���й滮");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("��ҵ��Χ");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("���ݽ���");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("����");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("��·");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("����ͼ��", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.������ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ά��ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.����ɸѡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ֲ���ʾToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����ѯ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ȫ�ۺϲ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�δ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excel���ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ݵ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ҵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��Ϣ�޸�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������Ϣά��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m1��������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�����������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ǰ���巶Χ��ӡͼ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ר��ͼ���1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ͼToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ��ѯ��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ִ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Maptrans = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ҵ�ϱ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.scFillExtent = new System.Windows.Forms.SplitContainer();
            this.cboLayerFact = new System.Windows.Forms.ComboBox();
            this.btnRefreshMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvGlqs = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvLayers = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.cboLayerName = new System.Windows.Forms.ComboBox();
            this.cboTransp = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
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
            this.scBottomView = new System.Windows.Forms.SplitContainer();
            this.dgvT2_11 = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsLtdDetailInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.��ϸ��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvT2_12 = new System.Windows.Forms.DataGridView();
            this.Column27 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn118 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn122 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn123 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn124 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn125 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn126 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsShortKey = new System.Windows.Forms.ToolStrip();
            this.tsbLtd = new System.Windows.Forms.ToolStripButton();
            this.tsbFang = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCheng = new System.Windows.Forms.ToolStripButton();
            this.tsbRed = new System.Windows.Forms.ToolStripButton();
            this.tsbYellow = new System.Windows.Forms.ToolStripButton();
            this.tsbCheck = new System.Windows.Forms.ToolStripButton();
            this.tsbPhoto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbM1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbCancelLtdZhuantitu = new System.Windows.Forms.ToolStripButton();
            this.scForm = new System.Windows.Forms.SplitContainer();
            this.axTbCMap = new ESRI.ArcGIS.Controls.AxToolbarControl();
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
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scFillExtent)).BeginInit();
            this.scFillExtent.Panel1.SuspendLayout();
            this.scFillExtent.Panel2.SuspendLayout();
            this.scFillExtent.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.scBottomView)).BeginInit();
            this.scBottomView.Panel1.SuspendLayout();
            this.scBottomView.Panel2.SuspendLayout();
            this.scBottomView.SuspendLayout();
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
            this.tsShortKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scForm)).BeginInit();
            this.scForm.Panel1.SuspendLayout();
            this.scForm.Panel2.SuspendLayout();
            this.scForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTbCMap)).BeginInit();
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
            this.����ҵ����ͳ��ToolStripMenuItem});
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
            // ������ѯToolStripMenuItem
            // 
            this.������ѯToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ά��ToolStripMenuItem1,
            this.����ɸѡToolStripMenuItem,
            this.����ֲ���ʾToolStripMenuItem});
            this.������ѯToolStripMenuItem.Name = "������ѯToolStripMenuItem";
            this.������ѯToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.������ѯToolStripMenuItem.Text = "��������";
            // 
            // ����ά��ToolStripMenuItem1
            // 
            this.����ά��ToolStripMenuItem1.Name = "����ά��ToolStripMenuItem1";
            this.����ά��ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.����ά��ToolStripMenuItem1.Text = "����ά��";
            this.����ά��ToolStripMenuItem1.Click += new System.EventHandler(this.ͳ��ɸѡToolStripMenuItem_Click);
            // 
            // ����ɸѡToolStripMenuItem
            // 
            this.����ɸѡToolStripMenuItem.Name = "����ɸѡToolStripMenuItem";
            this.����ɸѡToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.����ɸѡToolStripMenuItem.Text = "����ɸѡ";
            this.����ɸѡToolStripMenuItem.Click += new System.EventHandler(this.����ɸѡToolStripMenuItem_Click);
            // 
            // ����ֲ���ʾToolStripMenuItem
            // 
            this.����ֲ���ʾToolStripMenuItem.Name = "����ֲ���ʾToolStripMenuItem";
            this.����ֲ���ʾToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.����ֲ���ʾToolStripMenuItem.Text = "����ֲ���ʾ";
            // 
            // ������ҵ��ѯ��ͳ��ToolStripMenuItem
            // 
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�����ѯ����ToolStripMenuItem,
            this.��ȫ�ۺϲ�ѯToolStripMenuItem});
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Name = "������ҵ��ѯ��ͳ��ToolStripMenuItem";
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Text = "��ȫ����";
            this.������ҵ��ѯ��ͳ��ToolStripMenuItem.Visible = false;
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
            this.��ȫ�ۺϲ�ѯToolStripMenuItem.Visible = false;
            this.��ȫ�ۺϲ�ѯToolStripMenuItem.Click += new System.EventHandler(this.��ȫ�ۺϲ�ѯToolStripMenuItem_Click);
            // 
            // ͼ�δ���ToolStripMenuItem
            // 
            this.ͼ�δ���ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excel���ݵ���ToolStripMenuItem,
            this.���ݵ���ToolStripMenuItem,
            this.�������ݵ���ToolStripMenuItem,
            this.���ݵ���ToolStripMenuItem,
            this.������ҵToolStripMenuItem,
            this.��ҵ��Ϣ�޸�ToolStripMenuItem,
            this.������Ϣά��ToolStripMenuItem,
            this.m1��������ToolStripMenuItem});
            this.ͼ�δ���ToolStripMenuItem.Name = "ͼ�δ���ToolStripMenuItem";
            this.ͼ�δ���ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.ͼ�δ���ToolStripMenuItem.Text = "������Ϣ����";
            // 
            // excel���ݵ���ToolStripMenuItem
            // 
            this.excel���ݵ���ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�������ݵ���ToolStripMenuItem,
            this.������ݵ���ToolStripMenuItem,
            this.�������ݵ���ToolStripMenuItem});
            this.excel���ݵ���ToolStripMenuItem.Name = "excel���ݵ���ToolStripMenuItem";
            this.excel���ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.excel���ݵ���ToolStripMenuItem.Text = "Excel���ݵ���";
            this.excel���ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.excel���ݵ���ToolStripMenuItem_Click);
            // 
            // �������ݵ���ToolStripMenuItem
            // 
            this.�������ݵ���ToolStripMenuItem.Name = "�������ݵ���ToolStripMenuItem";
            this.�������ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.�������ݵ���ToolStripMenuItem.Text = "�¶����ݵ���";
            this.�������ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.�������ݵ���ToolStripMenuItem_Click);
            // 
            // ������ݵ���ToolStripMenuItem
            // 
            this.������ݵ���ToolStripMenuItem.Name = "������ݵ���ToolStripMenuItem";
            this.������ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.������ݵ���ToolStripMenuItem.Text = "������ݵ���";
            this.������ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.������ݵ���ToolStripMenuItem_Click);
            // 
            // �������ݵ���ToolStripMenuItem
            // 
            this.�������ݵ���ToolStripMenuItem.Name = "�������ݵ���ToolStripMenuItem";
            this.�������ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.�������ݵ���ToolStripMenuItem.Text = "�������ݵ���";
            this.�������ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.�������ݵ���ToolStripMenuItem_Click);
            // 
            // ���ݵ���ToolStripMenuItem
            // 
            this.���ݵ���ToolStripMenuItem.Name = "���ݵ���ToolStripMenuItem";
            this.���ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.���ݵ���ToolStripMenuItem.Text = "�о־��������ݵ���";
            this.���ݵ���ToolStripMenuItem.Visible = false;
            this.���ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.���ݵ���ToolStripMenuItem_Click);
            // 
            // �������ݵ���ToolStripMenuItem
            // 
            this.�������ݵ���ToolStripMenuItem.Name = "�������ݵ���ToolStripMenuItem";
            this.�������ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.�������ݵ���ToolStripMenuItem.Text = "�������ݵ���";
            this.�������ݵ���ToolStripMenuItem.Visible = false;
            this.�������ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.�������ݵ���ToolStripMenuItem_Click);
            // 
            // ���ݵ���ToolStripMenuItem
            // 
            this.���ݵ���ToolStripMenuItem.Name = "���ݵ���ToolStripMenuItem";
            this.���ݵ���ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.���ݵ���ToolStripMenuItem.Text = "���ݵ���";
            this.���ݵ���ToolStripMenuItem.Click += new System.EventHandler(this.���ݵ���ToolStripMenuItem_Click);
            // 
            // ������ҵToolStripMenuItem
            // 
            this.������ҵToolStripMenuItem.Name = "������ҵToolStripMenuItem";
            this.������ҵToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.������ҵToolStripMenuItem.Text = "������ҵ1";
            this.������ҵToolStripMenuItem.Visible = false;
            this.������ҵToolStripMenuItem.Click += new System.EventHandler(this.������ҵToolStripMenuItem_Click);
            // 
            // ��ҵ��Ϣ�޸�ToolStripMenuItem
            // 
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Name = "��ҵ��Ϣ�޸�ToolStripMenuItem";
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Text = "��ҵ��Ϣ�޸�";
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Visible = false;
            this.��ҵ��Ϣ�޸�ToolStripMenuItem.Click += new System.EventHandler(this.��ҵ��Ϣ�޸�ToolStripMenuItem_Click);
            // 
            // ������Ϣά��ToolStripMenuItem
            // 
            this.������Ϣά��ToolStripMenuItem.Name = "������Ϣά��ToolStripMenuItem";
            this.������Ϣά��ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.������Ϣά��ToolStripMenuItem.Text = "������ҵ";
            this.������Ϣά��ToolStripMenuItem.Click += new System.EventHandler(this.������Ϣά��ToolStripMenuItem_Click);
            // 
            // m1��������ToolStripMenuItem
            // 
            this.m1��������ToolStripMenuItem.Name = "m1��������ToolStripMenuItem";
            this.m1��������ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.m1��������ToolStripMenuItem.Text = "M1�ⲿ��ҵ��������";
            this.m1��������ToolStripMenuItem.Visible = false;
            this.m1��������ToolStripMenuItem.Click += new System.EventHandler(this.m1��������ToolStripMenuItem_Click);
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
            this.��ҵ��ѯ��ϢToolStripMenuItem,
            this.���ִ���ToolStripMenuItem});
            this.��ͼToolStripMenuItem.Name = "��ͼToolStripMenuItem";
            this.��ͼToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.��ͼToolStripMenuItem.Text = "��ͼ";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.����ToolStripMenuItem.Text = "����������Ϣ";
            this.����ToolStripMenuItem.Visible = false;
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ��ҵ��ѯ��ϢToolStripMenuItem
            // 
            this.��ҵ��ѯ��ϢToolStripMenuItem.Name = "��ҵ��ѯ��ϢToolStripMenuItem";
            this.��ҵ��ѯ��ϢToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.��ҵ��ѯ��ϢToolStripMenuItem.Text = "��ҵ��ѯ��Ϣ ";
            this.��ҵ��ѯ��ϢToolStripMenuItem.Click += new System.EventHandler(this.��ҵ��ѯ��ϢToolStripMenuItem_Click);
            // 
            // ���ִ���ToolStripMenuItem
            // 
            this.���ִ���ToolStripMenuItem.Name = "���ִ���ToolStripMenuItem";
            this.���ִ���ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.���ִ���ToolStripMenuItem.Text = "���ִ���";
            this.���ִ���ToolStripMenuItem.Visible = false;
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
            // ��ҵ�ϱ�ToolStripMenuItem
            // 
            this.��ҵ�ϱ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�⽭����ҵ��ҵ��Դ��Լ��������ϱ�ToolStripMenuItem});
            this.��ҵ�ϱ�ToolStripMenuItem.Name = "��ҵ�ϱ�ToolStripMenuItem";
            this.��ҵ�ϱ�ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.��ҵ�ϱ�ToolStripMenuItem.Text = "��ҵ�ϱ�";
            this.��ҵ�ϱ�ToolStripMenuItem.Visible = false;
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
            // scFillExtent
            // 
            this.scFillExtent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFillExtent.Location = new System.Drawing.Point(0, 0);
            this.scFillExtent.Name = "scFillExtent";
            // 
            // scFillExtent.Panel1
            // 
            this.scFillExtent.Panel1.Controls.Add(this.cboLayerFact);
            this.scFillExtent.Panel1.Controls.Add(this.btnRefreshMap);
            this.scFillExtent.Panel1.Controls.Add(this.label1);
            this.scFillExtent.Panel1.Controls.Add(this.groupBox1);
            this.scFillExtent.Panel1.Controls.Add(this.groupBox2);
            this.scFillExtent.Panel1.Controls.Add(this.splitter1);
            this.scFillExtent.Panel1.Controls.Add(this.panel2);
            this.scFillExtent.Panel1.Controls.Add(this.cboLayerName);
            this.scFillExtent.Panel1.Controls.Add(this.cboTransp);
            // 
            // scFillExtent.Panel2
            // 
            this.scFillExtent.Panel2.Controls.Add(this.panel3);
            this.scFillExtent.Panel2.Controls.Add(this.panel1);
            this.scFillExtent.Panel2.Controls.Add(this.splitter3);
            this.scFillExtent.Panel2.Controls.Add(this.splitter2);
            this.scFillExtent.Panel2.Cursor = System.Windows.Forms.Cursors.No;
            this.scFillExtent.Size = new System.Drawing.Size(1276, 613);
            this.scFillExtent.SplitterDistance = 271;
            this.scFillExtent.TabIndex = 8;
            // 
            // cboLayerFact
            // 
            this.cboLayerFact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLayerFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayerFact.FormattingEnabled = true;
            this.cboLayerFact.Items.AddRange(new object[] {
            "���й滮"});
            this.cboLayerFact.Location = new System.Drawing.Point(94, 169);
            this.cboLayerFact.Name = "cboLayerFact";
            this.cboLayerFact.Size = new System.Drawing.Size(40, 20);
            this.cboLayerFact.TabIndex = 16;
            this.cboLayerFact.Visible = false;
            // 
            // btnRefreshMap
            // 
            this.btnRefreshMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMap.Location = new System.Drawing.Point(223, 167);
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.tvGlqs);
            this.groupBox1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 206);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������";
            // 
            // tvGlqs
            // 
            this.tvGlqs.BackColor = System.Drawing.SystemColors.Control;
            this.tvGlqs.CheckBoxes = true;
            this.tvGlqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGlqs.Font = new System.Drawing.Font("����", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvGlqs.ForeColor = System.Drawing.Color.Blue;
            this.tvGlqs.FullRowSelect = true;
            this.tvGlqs.Location = new System.Drawing.Point(3, 22);
            this.tvGlqs.Name = "tvGlqs";
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
            treeNode3.Tag = "WJKFQ05";
            treeNode3.Text = "���Ṥҵ��";
            treeNode4.Checked = true;
            treeNode4.Name = "�ڵ�5";
            treeNode4.Tag = "WJKFQ06";
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
            this.tvGlqs.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tvGlqs.Size = new System.Drawing.Size(260, 181);
            this.tvGlqs.TabIndex = 0;
            this.tvGlqs.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvGlqs_AfterCheck);
            this.tvGlqs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGlqs_AfterSelect);
            this.tvGlqs.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvGlqs_NodeMouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.tvLayers);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 201);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ͼ����ʾ����";
            // 
            // tvLayers
            // 
            this.tvLayers.BackColor = System.Drawing.SystemColors.Control;
            this.tvLayers.CheckBoxes = true;
            this.tvLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLayers.ForeColor = System.Drawing.Color.Blue;
            this.tvLayers.Location = new System.Drawing.Point(3, 22);
            this.tvLayers.Name = "tvLayers";
            treeNode10.Name = "�ڵ�4";
            treeNode10.Text = "��ҵ��Ƭ";
            treeNode11.Name = "�ڵ�3";
            treeNode11.Text = "��ȫ���";
            treeNode12.Name = "�ڵ�1";
            treeNode12.Text = "���ƾ���";
            treeNode13.Name = "�ڵ�2";
            treeNode13.Text = "���ƾ���";
            treeNode14.Checked = true;
            treeNode14.Name = "�ڵ�0";
            treeNode14.Text = "������";
            treeNode15.Checked = true;
            treeNode15.Name = "�ڵ�1";
            treeNode15.Text = "������";
            treeNode16.Name = "�ڵ�0";
            treeNode16.Text = "���й滮";
            treeNode17.Checked = true;
            treeNode17.Name = "�ڵ�2";
            treeNode17.Text = "��ҵ��Χ";
            treeNode18.Checked = true;
            treeNode18.Name = "�ڵ�3";
            treeNode18.Text = "���ݽ���";
            treeNode19.Checked = true;
            treeNode19.Name = "�ڵ�5";
            treeNode19.Text = "����";
            treeNode20.Checked = true;
            treeNode20.Name = "�ڵ�0";
            treeNode20.Text = "��·";
            treeNode21.Name = "�ڵ�1";
            treeNode21.Text = "����ͼ��";
            this.tvLayers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode21});
            this.tvLayers.Size = new System.Drawing.Size(253, 176);
            this.tvLayers.TabIndex = 1;
            this.tvLayers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvLayers_AfterCheck);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 163);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(271, 3);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.axMapControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 163);
            this.panel2.TabIndex = 7;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl2.Location = new System.Drawing.Point(0, 0);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(271, 163);
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
            this.cboLayerName.Size = new System.Drawing.Size(102, 20);
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
            this.cboTransp.Location = new System.Drawing.Point(172, 169);
            this.cboTransp.Name = "cboTransp";
            this.cboTransp.Size = new System.Drawing.Size(47, 20);
            this.cboTransp.TabIndex = 6;
            this.cboTransp.Text = "60";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 613);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(667, 613);
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
            this.panel5.Size = new System.Drawing.Size(667, 613);
            this.panel5.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.axMapControl1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(667, 375);
            this.panel7.TabIndex = 2;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(667, 375);
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
            this.splitter4.Location = new System.Drawing.Point(0, 375);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(667, 4);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 379);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(667, 234);
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
            this.tabControl2.Size = new System.Drawing.Size(667, 234);
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
            this.tabPage6.Controls.Add(this.scBottomView);
            this.tabPage6.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage6.Location = new System.Drawing.Point(14, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(649, 226);
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
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
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
            this.btnPrint1.Location = new System.Drawing.Point(514, 188);
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
            // scBottomView
            // 
            this.scBottomView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scBottomView.Location = new System.Drawing.Point(6, 6);
            this.scBottomView.Name = "scBottomView";
            // 
            // scBottomView.Panel1
            // 
            this.scBottomView.Panel1.Controls.Add(this.dgvT2_11);
            // 
            // scBottomView.Panel2
            // 
            this.scBottomView.Panel2.Controls.Add(this.dgvT2_12);
            this.scBottomView.Size = new System.Drawing.Size(625, 183);
            this.scBottomView.SplitterDistance = 363;
            this.scBottomView.TabIndex = 1;
            // 
            // dgvT2_11
            // 
            this.dgvT2_11.AllowUserToAddRows = false;
            this.dgvT2_11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_11.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column11,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19});
            this.dgvT2_11.ContextMenuStrip = this.cmsLtdDetailInfo;
            this.dgvT2_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvT2_11.Location = new System.Drawing.Point(0, 0);
            this.dgvT2_11.Name = "dgvT2_11";
            this.dgvT2_11.RowTemplate.Height = 23;
            this.dgvT2_11.Size = new System.Drawing.Size(363, 183);
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
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "�ؿ���";
            this.Column2.HeaderText = "�ؿ���";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "���";
            this.Column3.HeaderText = "���";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "���";
            this.Column4.HeaderText = "���";
            this.Column4.Name = "Column4";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "�·�";
            this.Column11.HeaderText = "�·�";
            this.Column11.Name = "Column11";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "��λ����";
            this.Column13.HeaderText = "��λ����";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "��λ";
            this.Column14.HeaderText = "��λ";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "����";
            this.Column15.HeaderText = "����";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "����";
            this.Column16.HeaderText = "����";
            this.Column16.Name = "Column16";
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "��Ӫ��״";
            this.Column17.HeaderText = "��Ӫ��״";
            this.Column17.Name = "Column17";
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "�Ƿ�ҵ";
            this.Column18.HeaderText = "�Ƿ�ҵ";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "�ȼ�";
            this.Column19.HeaderText = "�ȼ�";
            this.Column19.Name = "Column19";
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
            this.dataGridViewTextBoxColumn118,
            this.Column57,
            this.dataGridViewTextBoxColumn122,
            this.dataGridViewTextBoxColumn123,
            this.dataGridViewTextBoxColumn124,
            this.dataGridViewTextBoxColumn125,
            this.dataGridViewTextBoxColumn126,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24});
            this.dgvT2_12.ContextMenuStrip = this.cmdLtdDetailInfo_zl;
            this.dgvT2_12.Location = new System.Drawing.Point(3, 3);
            this.dgvT2_12.Name = "dgvT2_12";
            this.dgvT2_12.RowTemplate.Height = 23;
            this.dgvT2_12.Size = new System.Drawing.Size(255, 175);
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
            // dataGridViewTextBoxColumn118
            // 
            this.dataGridViewTextBoxColumn118.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn118.HeaderText = "Id";
            this.dataGridViewTextBoxColumn118.Name = "dataGridViewTextBoxColumn118";
            this.dataGridViewTextBoxColumn118.Visible = false;
            // 
            // Column57
            // 
            this.Column57.DataPropertyName = "�ؿ���";
            this.Column57.HeaderText = "�ؿ���";
            this.Column57.Name = "Column57";
            this.Column57.Width = 80;
            // 
            // dataGridViewTextBoxColumn122
            // 
            this.dataGridViewTextBoxColumn122.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn122.HeaderText = "���";
            this.dataGridViewTextBoxColumn122.Name = "dataGridViewTextBoxColumn122";
            this.dataGridViewTextBoxColumn122.Width = 40;
            // 
            // dataGridViewTextBoxColumn123
            // 
            this.dataGridViewTextBoxColumn123.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn123.HeaderText = "���";
            this.dataGridViewTextBoxColumn123.Name = "dataGridViewTextBoxColumn123";
            this.dataGridViewTextBoxColumn123.Width = 40;
            // 
            // dataGridViewTextBoxColumn124
            // 
            this.dataGridViewTextBoxColumn124.DataPropertyName = "�·�";
            this.dataGridViewTextBoxColumn124.HeaderText = "�·�";
            this.dataGridViewTextBoxColumn124.Name = "dataGridViewTextBoxColumn124";
            this.dataGridViewTextBoxColumn124.Width = 40;
            // 
            // dataGridViewTextBoxColumn125
            // 
            this.dataGridViewTextBoxColumn125.DataPropertyName = "��λ����";
            this.dataGridViewTextBoxColumn125.HeaderText = "��λ����";
            this.dataGridViewTextBoxColumn125.Name = "dataGridViewTextBoxColumn125";
            // 
            // dataGridViewTextBoxColumn126
            // 
            this.dataGridViewTextBoxColumn126.DataPropertyName = "��λ";
            this.dataGridViewTextBoxColumn126.HeaderText = "��λ";
            this.dataGridViewTextBoxColumn126.Name = "dataGridViewTextBoxColumn126";
            this.dataGridViewTextBoxColumn126.Width = 150;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "����";
            this.Column20.HeaderText = "����";
            this.Column20.Name = "Column20";
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "����";
            this.Column21.HeaderText = "����";
            this.Column21.Name = "Column21";
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "��Ӫ��״";
            this.Column22.HeaderText = "��Ӫ��״";
            this.Column22.Name = "Column22";
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "�Ƿ�ҵ";
            this.Column23.HeaderText = "�Ƿ�ҵ";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "�ȼ�";
            this.Column24.HeaderText = "�ȼ�";
            this.Column24.Name = "Column24";
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
            this.tabPage7.Size = new System.Drawing.Size(649, 226);
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
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "���";
            this.dataGridViewTextBoxColumn14.HeaderText = "�鴦���";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "������ҵ����";
            this.dataGridViewTextBoxColumn15.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 40;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "�鴦����";
            this.dataGridViewTextBoxColumn16.HeaderText = "�鴦����";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 40;
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
            this.tabPage8.Size = new System.Drawing.Size(649, 226);
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
            this.panel1.Location = new System.Drawing.Point(670, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 613);
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
            this.tabControl1.Size = new System.Drawing.Size(330, 613);
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
            this.tabPage14.Size = new System.Drawing.Size(322, 587);
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
            this.dgvQycc.Location = new System.Drawing.Point(279, 512);
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
            this.btnSaveQyfw.Location = new System.Drawing.Point(17, 557);
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
            this.button11.Location = new System.Drawing.Point(107, 556);
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
            this.button9.Location = new System.Drawing.Point(198, 555);
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
            this.dgvQyxx.Size = new System.Drawing.Size(312, 540);
            this.dgvQyxx.TabIndex = 3;
            this.dgvQyxx.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQyxx_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle7.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn31.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.tabPage5.Size = new System.Drawing.Size(322, 587);
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
            this.dgvFW.Size = new System.Drawing.Size(322, 522);
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
            this.dataGridViewTextBoxColumn1.Visible = false;
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
            this.tabPage3.Size = new System.Drawing.Size(322, 587);
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
            this.dgvCSGH.Size = new System.Drawing.Size(322, 587);
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
            this.splitter3.Location = new System.Drawing.Point(1000, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1, 613);
            this.splitter3.TabIndex = 14;
            this.splitter3.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 613);
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
            this.cmsOrg.Name = "cmsOrg";
            this.cmsOrg.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tsShortKey
            // 
            this.tsShortKey.Dock = System.Windows.Forms.DockStyle.None;
            this.tsShortKey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLtd,
            this.tsbFang,
            this.toolStripSeparator1,
            this.tsbCheng,
            this.tsbRed,
            this.tsbYellow,
            this.tsbCheck,
            this.tsbPhoto,
            this.toolStripSeparator2,
            this.tsbM1,
            this.toolStripLabel1,
            this.tsbCancelLtdZhuantitu});
            this.tsShortKey.Location = new System.Drawing.Point(479, 3);
            this.tsShortKey.Name = "tsShortKey";
            this.tsShortKey.Size = new System.Drawing.Size(223, 25);
            this.tsShortKey.TabIndex = 0;
            this.tsShortKey.Text = "toolStrip1";
            // 
            // tsbLtd
            // 
            this.tsbLtd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLtd.Image = ((System.Drawing.Image)(resources.GetObject("tsbLtd.Image")));
            this.tsbLtd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLtd.Name = "tsbLtd";
            this.tsbLtd.Size = new System.Drawing.Size(24, 22);
            this.tsbLtd.Tag = "��ҵ��Χ";
            this.tsbLtd.Text = "��";
            this.tsbLtd.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbLtd.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // tsbFang
            // 
            this.tsbFang.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFang.Image = ((System.Drawing.Image)(resources.GetObject("tsbFang.Image")));
            this.tsbFang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFang.Name = "tsbFang";
            this.tsbFang.Size = new System.Drawing.Size(24, 22);
            this.tsbFang.Tag = "���ݽ���";
            this.tsbFang.Text = "��";
            this.tsbFang.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbFang.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCheng
            // 
            this.tsbCheng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCheng.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheng.Image")));
            this.tsbCheng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheng.Name = "tsbCheng";
            this.tsbCheng.Size = new System.Drawing.Size(24, 22);
            this.tsbCheng.Tag = "���й滮";
            this.tsbCheng.Text = "��";
            this.tsbCheng.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbCheng.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // tsbRed
            // 
            this.tsbRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRed.Image = ((System.Drawing.Image)(resources.GetObject("tsbRed.Image")));
            this.tsbRed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRed.Name = "tsbRed";
            this.tsbRed.Size = new System.Drawing.Size(24, 22);
            this.tsbRed.Tag = "���ƾ����λ��";
            this.tsbRed.Text = "��";
            this.tsbRed.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbRed.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // tsbYellow
            // 
            this.tsbYellow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbYellow.Image = ((System.Drawing.Image)(resources.GetObject("tsbYellow.Image")));
            this.tsbYellow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbYellow.Name = "tsbYellow";
            this.tsbYellow.Size = new System.Drawing.Size(24, 22);
            this.tsbYellow.Tag = "���ƾ����λ��";
            this.tsbYellow.Text = "��";
            this.tsbYellow.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbYellow.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // tsbCheck
            // 
            this.tsbCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCheck.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheck.Image")));
            this.tsbCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheck.Name = "tsbCheck";
            this.tsbCheck.Size = new System.Drawing.Size(24, 22);
            this.tsbCheck.Tag = "��ȫ����λ��";
            this.tsbCheck.Text = "��";
            this.tsbCheck.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbCheck.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // tsbPhoto
            // 
            this.tsbPhoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPhoto.Image = ((System.Drawing.Image)(resources.GetObject("tsbPhoto.Image")));
            this.tsbPhoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPhoto.Name = "tsbPhoto";
            this.tsbPhoto.Size = new System.Drawing.Size(24, 22);
            this.tsbPhoto.Tag = "��ҵ��Ƭ��λ��";
            this.tsbPhoto.Text = "��";
            this.tsbPhoto.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbPhoto.Click += new System.EventHandler(this.tsbFang_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbM1
            // 
            this.tsbM1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbM1.Image = ((System.Drawing.Image)(resources.GetObject("tsbM1.Image")));
            this.tsbM1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbM1.Name = "tsbM1";
            this.tsbM1.Size = new System.Drawing.Size(31, 22);
            this.tsbM1.Tag = "��ҵ��Χ";
            this.tsbM1.Text = "M1";
            this.tsbM1.CheckedChanged += new System.EventHandler(this.tsbLtd_CheckedChanged);
            this.tsbM1.Click += new System.EventHandler(this.tsbFang_Click);
            this.tsbM1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbM1_MouseDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel1.Text = "��";
            this.toolStripLabel1.Visible = false;
            this.toolStripLabel1.Click += new System.EventHandler(this.chkImage_CheckedChanged);
            // 
            // tsbCancelLtdZhuantitu
            // 
            this.tsbCancelLtdZhuantitu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancelLtdZhuantitu.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelLtdZhuantitu.Image")));
            this.tsbCancelLtdZhuantitu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelLtdZhuantitu.Name = "tsbCancelLtdZhuantitu";
            this.tsbCancelLtdZhuantitu.Size = new System.Drawing.Size(23, 22);
            this.tsbCancelLtdZhuantitu.Text = "/";
            this.tsbCancelLtdZhuantitu.ToolTipText = "��ҵͼ��ȡ������ר����ʾ";
            this.tsbCancelLtdZhuantitu.Visible = false;
            this.tsbCancelLtdZhuantitu.Click += new System.EventHandler(this.tsbCancelLtdZhuantitu_Click);
            // 
            // scForm
            // 
            this.scForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scForm.IsSplitterFixed = true;
            this.scForm.Location = new System.Drawing.Point(0, 25);
            this.scForm.Name = "scForm";
            this.scForm.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scForm.Panel1
            // 
            this.scForm.Panel1.Controls.Add(this.axTbCMap);
            this.scForm.Panel1.Controls.Add(this.tsShortKey);
            // 
            // scForm.Panel2
            // 
            this.scForm.Panel2.Controls.Add(this.scFillExtent);
            this.scForm.Size = new System.Drawing.Size(1276, 647);
            this.scForm.SplitterDistance = 30;
            this.scForm.TabIndex = 22;
            // 
            // axTbCMap
            // 
            this.axTbCMap.Location = new System.Drawing.Point(0, 0);
            this.axTbCMap.Name = "axTbCMap";
            this.axTbCMap.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTbCMap.OcxState")));
            this.axTbCMap.Size = new System.Drawing.Size(476, 28);
            this.axTbCMap.TabIndex = 3;
            this.axTbCMap.OnItemClick += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnItemClickEventHandler(this.axToolbarControl1_OnItemClick);
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
            this.dataGridViewTextBoxColumn25.Visible = false;
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
            this.dataGridViewTextBoxColumn27.Width = 40;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "��ҵ����";
            this.dataGridViewTextBoxColumn28.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Width = 40;
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
            dataGridViewCellStyle9.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn30.HeaderText = "�鴦���";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "��׼��;";
            dataGridViewCellStyle10.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn35.HeaderText = "��׼��;";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Visible = false;
            this.dataGridViewTextBoxColumn35.Width = 319;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "ʵ����;";
            dataGridViewCellStyle11.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn36.HeaderText = "ʵ����;";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 160;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle12.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn37.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Visible = false;
            this.dataGridViewTextBoxColumn37.Width = 159;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "��ҵ����������";
            dataGridViewCellStyle13.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn38.HeaderText = "��ҵ����������";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Visible = false;
            this.dataGridViewTextBoxColumn38.Width = 120;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle14.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn39.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Visible = false;
            this.dataGridViewTextBoxColumn39.Width = 300;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "��ҵ����";
            dataGridViewCellStyle15.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn40.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Visible = false;
            this.dataGridViewTextBoxColumn40.Width = 300;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle16.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn41.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn41.HeaderText = "���";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Visible = false;
            this.dataGridViewTextBoxColumn41.Width = 159;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn42.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle17.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn42.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn42.Frozen = true;
            this.dataGridViewTextBoxColumn42.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn42.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn42.Visible = false;
            this.dataGridViewTextBoxColumn42.Width = 160;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle18.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn43.DefaultCellStyle = dataGridViewCellStyle18;
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
            dataGridViewCellStyle19.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn44.DefaultCellStyle = dataGridViewCellStyle19;
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
            dataGridViewCellStyle20.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn45.DefaultCellStyle = dataGridViewCellStyle20;
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
            this.dataGridViewTextBoxColumn47.MinimumWidth = 130;
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
            this.dataGridViewTextBoxColumn48.MinimumWidth = 179;
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            this.dataGridViewTextBoxColumn48.Visible = false;
            this.dataGridViewTextBoxColumn48.Width = 179;
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
            dataGridViewCellStyle21.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn55.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn55.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.ReadOnly = true;
            this.dataGridViewTextBoxColumn55.Width = 159;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle22.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn56.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn56.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.ReadOnly = true;
            this.dataGridViewTextBoxColumn56.Width = 160;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle23.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn57.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn57.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.ReadOnly = true;
            this.dataGridViewTextBoxColumn57.Width = 159;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle24.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn58.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn58.HeaderText = "�ֶ���";
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.ReadOnly = true;
            this.dataGridViewTextBoxColumn58.Width = 160;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle25.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn59.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn59.HeaderText = "�ֶ�ֵ";
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            this.dataGridViewTextBoxColumn59.ReadOnly = true;
            this.dataGridViewTextBoxColumn59.Width = 159;
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle26.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn60.DefaultCellStyle = dataGridViewCellStyle26;
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
            dataGridViewCellStyle27.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn62.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn62.HeaderText = "������";
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            this.dataGridViewTextBoxColumn62.ReadOnly = true;
            this.dataGridViewTextBoxColumn62.Visible = false;
            this.dataGridViewTextBoxColumn62.Width = 160;
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.DataPropertyName = "value";
            dataGridViewCellStyle28.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn63.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn63.HeaderText = "����";
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            this.dataGridViewTextBoxColumn63.ReadOnly = true;
            this.dataGridViewTextBoxColumn63.Visible = false;
            this.dataGridViewTextBoxColumn63.Width = 159;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.DataPropertyName = "�ֶ���";
            dataGridViewCellStyle29.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn64.DefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTextBoxColumn64.HeaderText = "������";
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.ReadOnly = true;
            this.dataGridViewTextBoxColumn64.Width = 160;
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.DataPropertyName = "�ֶ�ֵ";
            dataGridViewCellStyle30.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn65.DefaultCellStyle = dataGridViewCellStyle30;
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
            dataGridViewCellStyle31.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn79.DefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridViewTextBoxColumn79.FillWeight = 68.96552F;
            this.dataGridViewTextBoxColumn79.HeaderText = "������ҵ����";
            this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            this.dataGridViewTextBoxColumn79.ReadOnly = true;
            this.dataGridViewTextBoxColumn79.Width = 110;
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.DataPropertyName = "��������������";
            dataGridViewCellStyle32.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn80.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridViewTextBoxColumn80.FillWeight = 131.0345F;
            this.dataGridViewTextBoxColumn80.HeaderText = "����������";
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            this.dataGridViewTextBoxColumn80.Width = 209;
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.DataPropertyName = "��ҵ����������";
            dataGridViewCellStyle33.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn81.DefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridViewTextBoxColumn81.FillWeight = 68.96552F;
            this.dataGridViewTextBoxColumn81.HeaderText = "�����õ���ҵ";
            this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            this.dataGridViewTextBoxColumn81.ReadOnly = true;
            this.dataGridViewTextBoxColumn81.Width = 110;
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.DataPropertyName = "��׼��;";
            dataGridViewCellStyle34.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn82.DefaultCellStyle = dataGridViewCellStyle34;
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
            dataGridViewCellStyle35.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn87.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewTextBoxColumn87.HeaderText = "��ҵ����";
            this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            this.dataGridViewTextBoxColumn87.ReadOnly = true;
            this.dataGridViewTextBoxColumn87.Width = 33;
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.DataPropertyName = "OBJECTID";
            dataGridViewCellStyle36.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn88.DefaultCellStyle = dataGridViewCellStyle36;
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
            dataGridViewCellStyle37.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn89.DefaultCellStyle = dataGridViewCellStyle37;
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
            dataGridViewCellStyle38.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn90.DefaultCellStyle = dataGridViewCellStyle38;
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
            dataGridViewCellStyle39.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn104.DefaultCellStyle = dataGridViewCellStyle39;
            this.dataGridViewTextBoxColumn104.HeaderText = "����";
            this.dataGridViewTextBoxColumn104.Name = "dataGridViewTextBoxColumn104";
            this.dataGridViewTextBoxColumn104.ReadOnly = true;
            this.dataGridViewTextBoxColumn104.Width = 160;
            // 
            // dataGridViewTextBoxColumn105
            // 
            this.dataGridViewTextBoxColumn105.DataPropertyName = "�鴦��ʼ����";
            dataGridViewCellStyle40.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn105.DefaultCellStyle = dataGridViewCellStyle40;
            this.dataGridViewTextBoxColumn105.HeaderText = "�鴦��ʼ����";
            this.dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
            this.dataGridViewTextBoxColumn105.Width = 159;
            // 
            // dataGridViewTextBoxColumn106
            // 
            this.dataGridViewTextBoxColumn106.DataPropertyName = "�鴦��ֹ����";
            dataGridViewCellStyle41.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn106.DefaultCellStyle = dataGridViewCellStyle41;
            this.dataGridViewTextBoxColumn106.HeaderText = "�鴦��ֹ����";
            this.dataGridViewTextBoxColumn106.Name = "dataGridViewTextBoxColumn106";
            this.dataGridViewTextBoxColumn106.ReadOnly = true;
            this.dataGridViewTextBoxColumn106.Width = 160;
            // 
            // dataGridViewTextBoxColumn107
            // 
            this.dataGridViewTextBoxColumn107.DataPropertyName = "��ע����";
            dataGridViewCellStyle42.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn107.DefaultCellStyle = dataGridViewCellStyle42;
            this.dataGridViewTextBoxColumn107.HeaderText = "��ע����";
            this.dataGridViewTextBoxColumn107.Name = "dataGridViewTextBoxColumn107";
            this.dataGridViewTextBoxColumn107.Width = 159;
            // 
            // dataGridViewTextBoxColumn108
            // 
            this.dataGridViewTextBoxColumn108.DataPropertyName = "��������";
            dataGridViewCellStyle43.Format = "yyyy-MM-dd";
            this.dataGridViewTextBoxColumn108.DefaultCellStyle = dataGridViewCellStyle43;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 694);
            this.Controls.Add(this.scForm);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "�⽭���ü�����������ҵ��Ϣ����ϵͳ���1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.scFillExtent.Panel1.ResumeLayout(false);
            this.scFillExtent.Panel1.PerformLayout();
            this.scFillExtent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFillExtent)).EndInit();
            this.scFillExtent.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
            this.scBottomView.Panel1.ResumeLayout(false);
            this.scBottomView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBottomView)).EndInit();
            this.scBottomView.ResumeLayout(false);
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
            this.tsShortKey.ResumeLayout(false);
            this.tsShortKey.PerformLayout();
            this.scForm.Panel1.ResumeLayout(false);
            this.scForm.Panel1.PerformLayout();
            this.scForm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scForm)).EndInit();
            this.scForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTbCMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.SplitContainer scFillExtent;
        private System.Windows.Forms.ToolStripMenuItem Maptrans;
        private System.Windows.Forms.ToolStripMenuItem ͼ�����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��ѯToolStripMenuItem1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ToolStripMenuItem �ۺϲ�ѯToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsOrg;
        private System.Windows.Forms.ToolStripStatusLabel tsslScale;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripMenuItem ͼ�δ���ToolStripMenuItem;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshMap;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �û�����ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem �û�����ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem �����޸�ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboLayerName;
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
        private System.Windows.Forms.SplitContainer scBottomView;
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
        private System.Windows.Forms.ToolStripMenuItem ������״����ToolStripMenuItem;
        private System.Windows.Forms.TreeView tvGlqs;
        private System.Windows.Forms.TreeView tvLayers;
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
        private System.Windows.Forms.ToolStripMenuItem ר��ͼ���1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ҵToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ҵ��Ϣ�޸�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ҵ����ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLtdDetailInfo;
        private System.Windows.Forms.ToolStripMenuItem ��ϸ��ϢToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ά��ToolStripMenuItem1;
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
        private System.Windows.Forms.ToolStripMenuItem excel���ݵ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �������ݵ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �������ݵ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ������Ϣά��ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn118;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn122;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn123;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn124;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn125;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn126;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.ToolStripMenuItem ������ݵ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsShortKey;
        private System.Windows.Forms.ToolStripButton tsbLtd;
        private System.Windows.Forms.ToolStripButton tsbFang;
        private System.Windows.Forms.ToolStripButton tsbCheng;
        private System.Windows.Forms.ToolStripButton tsbRed;
        private System.Windows.Forms.ToolStripButton tsbYellow;
        private System.Windows.Forms.ToolStripButton tsbCheck;
        private System.Windows.Forms.ToolStripButton tsbPhoto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer scForm;
        private ESRI.ArcGIS.Controls.AxToolbarControl axTbCMap;
        private System.Windows.Forms.ToolStripMenuItem ���ִ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbM1;
        private System.Windows.Forms.ToolStripButton tsbCancelLtdZhuantitu;
        private System.Windows.Forms.ToolStripMenuItem m1��������ToolStripMenuItem;
    }
}

