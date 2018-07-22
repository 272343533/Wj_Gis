using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Output;

using System.Drawing.Printing;


using ESRI.ArcGIS.SystemUI;
using TDObject.DrawLayer;
using ESRI.ArcGIS.Controls;
using QyTech.Core.BLL;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;


using System.Windows.Forms;

namespace TDObject.BLL.Printer
{
    public class MapPrint
    {
        public static void PrintView(IActiveView pActiveView)
        {
            IPaper pPaper = new Paper();
            IPrinter pPrinter = new EmfPrinterClass();
            PrintDocument sysPrintDocumentDocument = new PrintDocument();
            pPaper.PrinterName = sysPrintDocumentDocument.PrinterSettings.PrinterName;
            pPrinter.Paper = pPaper;
            int Resolution = pPrinter.Resolution;
            double w, h;
            IEnvelope PEnvelope = pActiveView.Extent;
            w = PEnvelope.Width;
            h = PEnvelope.Height;
            double pw, ph;//纸张
            pPrinter.QueryPaperSize(out pw, out ph);
            tagRECT userRECT = pActiveView.ExportFrame;
            userRECT.left = (int)(pPrinter.PrintableBounds.XMin * Resolution);
            userRECT.top = (int)(pPrinter.PrintableBounds.YMin * Resolution);
            if ((w / h) > (pw / ph))//以宽度来调整高度
            {
                userRECT.right = userRECT.left + (int)(pPrinter.PrintableBounds.Width * Resolution);
                userRECT.bottom = userRECT.top + (int)((pPrinter.PrintableBounds.Width * Resolution) * h / w);
            }
            else
            {
                userRECT.bottom = userRECT.top + (int)(pPrinter.PrintableBounds.Height * Resolution);
                userRECT.right = userRECT.left + (int)(pPrinter.PrintableBounds.Height * Resolution * w / h);
            }
            IEnvelope pDriverBounds = new EnvelopeClass();
            pDriverBounds.PutCoords(userRECT.left, userRECT.top, userRECT.right, userRECT.bottom);
            ITrackCancel pCancel = new CancelTrackerClass();
            int hdc = pPrinter.StartPrinting(pDriverBounds, 0);
            pActiveView.Output(hdc, pPrinter.Resolution,
            ref userRECT, pActiveView.Extent, pCancel);



            pPrinter.FinishPrinting();
        }


        public static void PrintPreView(PrintPreviewDialog ppd,IActiveView pActiveView)
        {
            IPaper pPaper = new Paper();
            IPrinter pPrinter = new EmfPrinterClass();
            PrintDocument sysPrintDocumentDocument = new PrintDocument();
           
            
            pPaper.PrinterName = sysPrintDocumentDocument.PrinterSettings.PrinterName;
            pPrinter.Paper = pPaper;
            int Resolution = pPrinter.Resolution;
            double w, h;
            IEnvelope PEnvelope = pActiveView.Extent;
            w = PEnvelope.Width;
            h = PEnvelope.Height;
            double pw, ph;//纸张
            pPrinter.QueryPaperSize(out pw, out ph);
            tagRECT userRECT = pActiveView.ExportFrame;
            userRECT.left = (int)(pPrinter.PrintableBounds.XMin * Resolution);
            userRECT.top = (int)(pPrinter.PrintableBounds.YMin * Resolution);
            if ((w / h) > (pw / ph))//以宽度来调整高度
            {
                userRECT.right = userRECT.left + (int)(pPrinter.PrintableBounds.Width * Resolution);
                userRECT.bottom = userRECT.top + (int)((pPrinter.PrintableBounds.Width * Resolution) * h / w);
            }
            else
            {
                userRECT.bottom = userRECT.top + (int)(pPrinter.PrintableBounds.Height * Resolution);
                userRECT.right = userRECT.left + (int)(pPrinter.PrintableBounds.Height * Resolution * w / h);
            }
           

            ppd.Document = sysPrintDocumentDocument;

            //show the dialog - this triggers the document's PrintPage event
            ppd.ShowDialog();

        }
    }
}
