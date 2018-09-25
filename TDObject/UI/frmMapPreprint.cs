using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using ESRI.ArcGIS.SystemUI;
using TDObject.DrawLayer;
using ESRI.ArcGIS.Controls;
using QyTech.Core.BLL;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;

using ESRI.ArcGIS.Output;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;


namespace TDObject.UI
{
    public partial class frmMapPreprint : QyTech.SkinForm.qyFormWithTitle
    {
        public AxMapControl _axMap;


        internal PrintPreviewDialog printPreviewDialog1;
        internal PrintDialog printDialog1;
        internal PageSetupDialog pageSetupDialog1;

        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        
        private short m_CurrentPrintPage;

        private Size _size;

        public frmMapPreprint(AxMapControl axMap)
        {
            InitializeComponent();

            _axMap = axMap;
        }

        private void frmMapPreprint_Load(object sender, EventArgs e)
        {

            //_axMap.Refresh();
            try
            {
                Copy();
                VH();
                //axPageLayoutControl1.ActiveView.ShowRulers = true;
                //axPageLayoutControl1.ActiveView.ShowScrollBars = true;
                //axPageLayoutControl1.ActiveView.ShowSelection = true;

                //IPageLayout pageLayout = axPageLayoutControl1.ActiveView as IPageLayout;
                // AddMapSurround(pageLayout, _axMap.ActiveView);
                ////AddNorthArrow(pageLayout, _axMap.ActiveView as IMap);
                //// AddMapSurround(axPageLayoutControl1.PageLayout, this._axMap.ActiveView);
                ////AxPageLayoutControl pPageLayout = axPageLayoutControl1;

                //axPageLayoutControl1.ZoomToWholePage();
                //axPageLayoutControl1.ActiveView.FocusMap = _axMap.Map;

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void VH()
        {
            IMap pMap = axPageLayoutControl1.ActiveView.FocusMap;

            IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)axPageLayoutControl1.PageLayout;

            IMapFrame pMapFrame = (IMapFrame)pGraphicsContainer.FindFrame(pMap);

            ISymbolBorder pSymborder = new SymbolBorderClass();

            pSymborder.CornerRounding = 0;

            IBorder pBorder = pSymborder;

            pMapFrame.Border = pBorder;

            pMapFrame.ExtentType = esriExtentTypeEnum.esriExtentBounds;

            IElement pElement = (IElement)pMapFrame;

            IEnvelope pEnvelop = new EnvelopeClass();

            pEnvelop.PutCoords(0.5, 0.5, 29.2, 20.5);  //这里设置mapframe的大小

            IGeometry pGeometry = pEnvelop;

            pElement.Geometry = pGeometry;

            IPage pPage = axPageLayoutControl1.Page;

            pPage.Orientation = 1;

            pPage.PutCustomSize(29.7, 21.0);  //这里设置page的大小

            axPageLayoutControl1.ActiveView.Refresh();
        }

        private void Copy()
        {
            try
            {
                IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
                IDisplayTransformation displayTransformation = activeView.ScreenDisplay.DisplayTransformation;
                //根据MapControl的视图范围,确定PageLayoutControl的视图范围
                displayTransformation.VisibleBounds = _axMap.FullExtent;
                axPageLayoutControl1.Extent = _axMap.FullExtent; 
                axPageLayoutControl1.ActiveView.Refresh();

                object toOverwriteMap = axPageLayoutControl1.ActiveView.FocusMap;
                IObjectCopy objectCopy = new ObjectCopyClass();
                //object toCopyMap = _axMap.Map;
                //object copiedMap = objectCopy.Copy(toCopyMap);
                objectCopy.Overwrite(_axMap.ActiveView, ref toOverwriteMap);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        public void AddMapSurround(IPageLayout pageLayout, IActiveView activeView)
        {
            try
            {
                IMap map = activeView.FocusMap;
                IGraphicsContainer graphicsContainer = pageLayout as IGraphicsContainer;
                IFrameElement frameElement = graphicsContainer.FindFrame(map);
                IMapFrame mapFrame = (IMapFrame)frameElement;
                IMapSurroundFrame mapSurroundFrame = new MapSurroundFrameClass();
                UID elementUID = new UIDClass();

                //The value determines the type of MapSurroundFrame being added.
                elementUID.Value = "esriCarto.Legend";

                //The CreateSurroundFrame method takes the UID of the element and an optional style.
                mapSurroundFrame = mapFrame.CreateSurroundFrame(elementUID, null);
                mapSurroundFrame.MapSurround.Name = "Legend";

                //Cast the MapSurroundFrame as an element so it can be inserted into the page layout.
                IElement doc_Element = mapSurroundFrame as IElement;
                IElement mainMap_Element = mapFrame as IElement;
                IGeometry geometry = mainMap_Element.Geometry;
                IEnvelope mainMap_Envelope = geometry.Envelope;
                IEnvelope envelope = new EnvelopeClass();
                double xMin = mainMap_Envelope.XMax + 1.5;
                double yMin = mainMap_Envelope.YMin + 1.5;
                double xMax = mainMap_Envelope.XMax - 1.5;
                double yMax = mainMap_Envelope.YMax - 1.5;
                envelope.PutCoords(xMin, yMin, xMax, yMax);

                doc_Element.Geometry = envelope as IGeometry;
                doc_Element.Activate(activeView.ScreenDisplay);
                graphicsContainer.AddElement(doc_Element, 0);

                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void AddNorthArrow(ESRI.ArcGIS.Carto.IPageLayout pageLayout, ESRI.ArcGIS.Carto.IMap map)
        {
            try
            {
                if (pageLayout == null || map == null)
                {
                    return;
                }
                ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
                envelope.PutCoords(0.2, 0.2, 5, 5); //  Specify the location and size of the north arrow

                ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
                uid.Value = "esriCarto.MarkerNorthArrow";

                // Create a Surround. Set the geometry of the MapSurroundFrame to give it a location
                // Activate it and add it to the PageLayout's graphics container
                ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pageLayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
                ESRI.ArcGIS.Carto.IActiveView activeView = pageLayout as ESRI.ArcGIS.Carto.IActiveView; // Dynamic Cast
                ESRI.ArcGIS.Carto.IFrameElement frameElement = graphicsContainer.FindFrame(map);
                ESRI.ArcGIS.Carto.IMapFrame mapFrame = frameElement as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
                ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null); // Dynamic Cast
                ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
                element.Geometry = envelope;
                element.Activate(activeView.ScreenDisplay);
                graphicsContainer.AddElement(element, 0);
                ESRI.ArcGIS.Carto.IMapSurround mapSurround = mapSurroundFrame.MapSurround;

                // Change out the default north arrow
                ESRI.ArcGIS.Carto.IMarkerNorthArrow markerNorthArrow = mapSurround as ESRI.ArcGIS.Carto.IMarkerNorthArrow; // Dynamic Cast
                ESRI.ArcGIS.Display.IMarkerSymbol markerSymbol = markerNorthArrow.MarkerSymbol;
                ESRI.ArcGIS.Display.ICharacterMarkerSymbol characterMarkerSymbol = markerSymbol as ESRI.ArcGIS.Display.ICharacterMarkerSymbol; // Dynamic Cast
                characterMarkerSymbol.CharacterIndex = 200; // change the symbol for the North Arrow
                markerNorthArrow.MarkerSymbol = characterMarkerSymbol;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                AxPageLayoutControl pPageLayout = axPageLayoutControl1;
                if (pPageLayout.Printer != null)
                {
                    ESRI.ArcGIS.Output.IPrinter pPrinter = pPageLayout.Printer;
                    if (pPrinter.Paper.Orientation != pPageLayout.Page.Orientation)
                    {
                        pPrinter.Paper.Orientation = pPageLayout.Page.Orientation;
                    }
                    pPageLayout.PrintPageLayout(1, 0, 0);
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
       
            ////////allow the user to choose the page range to be printed
            //////printDialog1.AllowSomePages = true;
            ////////show the help button.
            //////printDialog1.ShowHelp = true;

            ////////set the Document property to the PrintDocument for which the PrintPage Event 
            ////////has been handled. To display the dialog, either this property or the 
            ////////PrinterSettings property must be set 
            //////printDialog1.Document = document;

            ////////show the print dialog and wait for user input
            //////DialogResult result = printDialog1.ShowDialog();

            //////// If the result is OK then print the document.
            //////if (result == DialogResult.OK) document.Print();
           


        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //this code will be called when the PrintPreviewDialog.Show method is called
                //set the PageToPrinterMapping property of the Page. This specifies how the page 
                //is mapped onto the printer page. By default the page will be tiled 
                //get the selected mapping option
                //string sPageToPrinterMapping = (string)this.cboPageToPrinterMapping.SelectedItem;
                //if (sPageToPrinterMapping == null)
                //if no selection has been made the default is tiling
                this.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
                //else if (sPageToPrinterMapping.Equals("2: Tile"))
                //    this.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
                //else if (sPageToPrinterMapping.Equals("0: Crop"))
                //    this.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingCrop;
                //else if (sPageToPrinterMapping.Equals("1: Scale"))
                //    this.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
                //else
                //    this.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;

                //get the resolution of the graphics device used by the print preview (including the graphics device)


                //m_CurrentPrintPage = 0;

                ////check if a document is loaded into PageLayout	control
                //if (axPageLayoutControl1.DocumentFilename == null) return;
                ////set the name of the print preview document to the name of the mxd doc
                //document.DocumentName = axPageLayoutControl1.DocumentFilename;

                ////set the PrintPreviewDialog.Document property to the PrintDocument object selected by the user
                //printPreviewDialog1.Document = document;

                ////show the dialog - this triggers the document's PrintPage event
                //printPreviewDialog1.ShowDialog();

                ////TDObject.BLL.Printer.MapPrint.PrintView(this.axMapControl1.ActiveView);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                short dpi = 1000;
                //MessageBox.Show(dpi.ToString());
                //envelope for the device boundaries
                IEnvelope devBounds = new EnvelopeClass();
                //get page
                IPage page = this.axPageLayoutControl1.Page;

                //the number of printer pages the page will be printed on
                short printPageCount;
                printPageCount = this.axPageLayoutControl1.get_PrinterPageCount(0);
                m_CurrentPrintPage++;

                //the currently selected printer
                IPrinter printer = this.axPageLayoutControl1.Printer;
                //get the device bounds of the currently selected printer
                page.GetDeviceBounds(printer, m_CurrentPrintPage, 0, dpi, devBounds);

                //structure for the device boundaries
                tagRECT deviceRect;
                //Returns the coordinates of lower, left and upper, right corners
                double xmin, ymin, xmax, ymax;
                devBounds.QueryCoords(out xmin, out ymin, out xmax, out ymax);
                //initialize the structure for the device boundaries
                deviceRect.bottom = (int)ymax;
                deviceRect.left = (int)xmin;
                deviceRect.top = (int)ymin;
                deviceRect.right = (int)xmax;

                //determine the visible bounds of the currently printed page
                IEnvelope visBounds = new EnvelopeClass();
                page.GetPageBounds(printer, m_CurrentPrintPage, 0, visBounds);

                //get a handle to the graphics device that the print preview will be drawn to
                IntPtr hdc = e.Graphics.GetHdc();

                //print the page to the graphics device using the specified boundaries 
                ITrackCancel m_TrackCancel = new CancelTrackerClass();
                this.axPageLayoutControl1.ActiveView.Output(hdc.ToInt32(), dpi, ref deviceRect, visBounds, m_TrackCancel);

                //release the graphics device handle
                e.Graphics.ReleaseHdc(hdc);

                //check if further pages have to be printed
                if (m_CurrentPrintPage < printPageCount)
                    e.HasMorePages = true; //document_PrintPage event will be called again
                else
                    e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMapPreprint_MouseMove(object sender, MouseEventArgs e)
        {
            //QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
             SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "JPEG Files|*.jpg";
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    string filename = sfd.FileName;
                    bool ret = CreateJPEGFromActiveView(axPageLayoutControl1.ActiveView, filename);
                    if (ret)
                        MessageBox.Show("保存为图片成功!");
                    else
                        MessageBox.Show("保存为图片失败!");
                }

        }


        ///<summary>Creates a .jpg (JPEG) file from IActiveView. Default values of 96 DPI are used for the image creation.</summary>
        ///
        ///<param name="activeView">An IActiveView interface</param>
        ///<param name="pathFileName">A System.String that the path and filename of the JPEG you want to create. Example: "C:\temp\test.jpg"</param>
        /// 
        ///<returns>A System.Boolean indicating the success</returns>
        /// 
        ///<remarks></remarks>
        public System.Boolean CreateJPEGFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            //parameter check
            if (activeView == null || !(pathFileName.EndsWith(".jpg")))
            {
                return false;
            }
            ESRI.ArcGIS.Output.IExport export = new ESRI.ArcGIS.Output.ExportJPEGClass();
            export.ExportFileName = pathFileName;

            // Microsoft Windows default DPI resolution
            export.Resolution = 192;//96 ;
            tagRECT exportRECT = activeView.ExportFrame;
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            //envelope = activeView.Extent.Envelope;
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);


            tagRECT exportRect = new tagRECT();
            exportRect.left = exportRect.top = 0;
            exportRect.right = exportRECT.right - exportRect.left;//.Width;
            exportRect.bottom = (int)(exportRect.right * activeView.Extent.Envelope.Height / activeView.Extent.Envelope.Width);
            //输出范围
            envelope.PutCoords(exportRect.left, exportRect.top, exportRect.right, exportRect.bottom);
            export.PixelBounds = envelope;





            export.PixelBounds = envelope;
            System.Int32 hDC = export.StartExporting();

            activeView.Output(hDC, (System.Int32)export.Resolution, ref exportRECT, null, null);
             
            // Finish writing the export file and cleanup any intermediate files
            export.FinishExporting();
            export.Cleanup();

            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Copy();
        }
    }
}
