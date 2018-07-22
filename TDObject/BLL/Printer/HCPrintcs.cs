using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;


namespace TDObject.BLL.Printer
{

    public class PrintInfo {
        public PrintInfo() {
            this.dataHead = "打印标题";
            this.headFont = new Font("黑体", 18, FontStyle.Bold);
            this.dataTip = "打印日期：" + DateTime.Now.ToShortDateString();
            this.tipFont = new Font("宋体", 10);
            this.dataFont = new Font("宋体", 10);
            this.landscape = false;
            this.autoWidth = true;
        }
        ///
        /// 获取设置标题头
        ///
        public String dataHead { set; get; }
        ///
        /// 获取或设置标题格式
        ///
        public Font headFont { set; get; }
        ///
        /// 获取或设置附加信息（打印时间等）
        ///
        public String dataTip { set; get; }
        ///
        /// 获取或设置附加信息字体格式（打印时间等）
        ///
        public Font tipFont { set; get; }
        ///
        /// 获取或设置数据字体格式
        ///
        public Font dataFont { set; get; }
        ///
        /// 获取或设置每列的宽度,当无设置或设置列数不正确时，列宽平均分配
        ///
        public int[] widths { set; get; }
        ///
        /// 设定是否是横向打印
        ///
        public Boolean landscape { set; get; }
        ///
        /// 是否根据比例自动调整至可打印宽度。默认自动调整。
        ///
        public Boolean autoWidth{ set; get; }
    }

    public class HCPrintcs
    {
        int countNum = 0;//整体打印的条数
        DataTable printDt;
        PrintInfo pInfo;
        public void printDataTable(DataTable dt,PrintInfo p) {
            this.printDt = dt;
            this.pInfo = p;
            PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            PrinterSettings pss = new System.Drawing.Printing.PrinterSettings();
            pss.DefaultPageSettings.Landscape = pInfo.landscape;
            pd.PrinterSettings = pss;

            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            if (printDt == null)
            {
                MessageBox.Show("出错", "没有可以打印的数据", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ppd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pd.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出错", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;//获取绘图对象
            int linesPerPage = 0;//页面行号
            int yPosition = 0;//绘制字符串的纵向位置
            int xPosition = 0;//绘制字符串的横向位置
            int leftMargin = e.MarginBounds.Left;//左边距
            int topMargin = e.MarginBounds.Top;//上边距
            string line = string.Empty;//读取的行字符串
            int currentPageLine = 0;//当前页读取的行数
            SolidBrush brush = new SolidBrush(Color.Black);//刷子
            //首先打印标题
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            Rectangle rect = new Rectangle(leftMargin, topMargin, e.MarginBounds.Width, e.MarginBounds.Height);
            graphic.DrawString(pInfo.dataHead, pInfo.headFont, brush, rect, sf);
            topMargin += 35;

            //首先打印说明
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            Rectangle rect2 = new Rectangle(leftMargin, topMargin, e.MarginBounds.Width, e.MarginBounds.Height);
            graphic.DrawString(pInfo.dataTip, pInfo.tipFont, brush, rect2, sf);
            topMargin += 25;

            linesPerPage = (int)((e.MarginBounds.Height -60) / (pInfo.dataFont.GetHeight(graphic) + 2));//每页可打印的行数

            //判断宽度是否有效，无效的话，重新平均定义
            if (pInfo.widths == null ||pInfo.widths.Length != printDt.Columns.Count)
            {
                int[] newit = new int[printDt.Columns.Count];
                for (int i = 0; i < printDt.Columns.Count;i++ )
                {
                    newit[i] = e.MarginBounds.Width / printDt.Columns.Count;
                }
                pInfo.widths = newit;
            }
            //判断是否要自动增加宽度
            if(pInfo.autoWidth){
                int[] newit = new int[printDt.Columns.Count];
                int s = pInfo.widths.Sum();
                for (int i = 0; i < printDt.Columns.Count; i++)
                {
                    newit[i] = pInfo.widths[i] * e.MarginBounds.Width / s;
                }
                pInfo.widths = newit;
            }
            //下面开始画表格
            Point ptS;
            Point ptE;
            int ti = leftMargin;//先画竖道
            //先判断要打印的数据（包括字段名称）是否多于每页可打印的行数，如果多则按每页可打印的行数算，否则按数据量算
            float ft = (printDt.Rows.Count - countNum + 1 > linesPerPage ? linesPerPage : (printDt.Rows.Count - countNum + 1)) * (pInfo.dataFont.GetHeight(graphic) + 2);//内容占的高度
            for (int j = 0; j <= printDt.Columns.Count; j++)
            {
                if (j > 0)
                {//如果是第一条竖线，开始点不变
                    ti += pInfo.widths[j - 1];
                }
                ptS = new Point(ti, topMargin);
                ptE = new Point(ti, topMargin + ((int)Math.Round(ft, 0)));
                graphic.DrawLine(Pens.Black, ptS, ptE);
            }
            //然后画上面封顶的横道。
            ptS = new Point(leftMargin, topMargin);
            ptE = new Point(ti, topMargin);
            graphic.DrawLine(Pens.Black, ptS, ptE);
            //然后，填入绘字段名称行
            xPosition = leftMargin;
            yPosition = topMargin;
            for (int j = 0; j < printDt.Columns.Count; j++)
            {
                line = printDt.Columns[j].ColumnName;
                graphic.DrawString(line, pInfo.dataFont, brush, xPosition, yPosition + 1, new StringFormat());
                xPosition += pInfo.widths[j];
            }
            topMargin = topMargin + ((int)Math.Round(pInfo.dataFont.GetHeight(graphic) + 2, 0));
            ptS = new Point(leftMargin, topMargin);
            ptE = new Point(xPosition, topMargin);
            graphic.DrawLine(Pens.Black, ptS, ptE);
            linesPerPage--;//因为已经画了标题栏，所以每页可画的条数少1
            //countNum记录全局行数，currentPageLine记录当前打印页行数。
            while (countNum < printDt.Rows.Count)
            {
                if (currentPageLine < linesPerPage)
                {
                    xPosition = leftMargin;
                    ft = currentPageLine * (pInfo.dataFont.GetHeight(graphic) + 2);//前面行数占的高度
                    yPosition = topMargin + ((int)Math.Round(ft, 0));
                    //绘制当前行
                    for (int j = 0; j < printDt.Columns.Count; j++)
                    {
                        line = printDt.Rows[countNum][j].ToString();
                        graphic.DrawString(line, pInfo.dataFont, brush, xPosition, yPosition + 1, new StringFormat());
                        xPosition += pInfo.widths[j];
                    }

                    countNum++;
                    currentPageLine++;
                    //然后画下面的横道
                    ft = currentPageLine * (pInfo.dataFont.GetHeight(graphic) + 2);//前面行数占的高度
                    yPosition = topMargin + ((int)Math.Round(ft, 0));
                    ptS = new Point(leftMargin, yPosition);
                    ptE = new Point(xPosition, yPosition);
                    graphic.DrawLine(Pens.Black, ptS, ptE);
                }
                else
                {
                    line = null;
                    break;
                }
            }
            //一页显示不完时自动重新调用此方法
            if (line == null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            //每次打印完后countNum清0;
            if (countNum >= printDt.Rows.Count)
            {
                countNum = 0;
            }
        }

    }
}