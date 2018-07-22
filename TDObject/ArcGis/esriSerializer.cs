using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TDObject.MapControl;

namespace TDObject.BLL
{
    public static class esriSerializerHelper
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(" TDObject.BLL esriSerializerHelper");

        public static string esriSerializer(object obj)
        {
            IXMLSerializer xmlSerializer = new XMLSerializerClass();
            string xmlstring = xmlSerializer.SaveToString(obj, null, null);
            return xmlstring;
        }

        public static object esriDeserializer(string str)
        {
            IXMLSerializer xmlSerializer = new XMLSerializerClass();
            return xmlSerializer.LoadFromString(str, null, null);
        }
        public static IRecordSet2 ConvertToRecordset(IFeatureClass fc)
        {
            IRecordSet recSet = new RecordSetClass();
            IRecordSetInit recSetInit = recSet as IRecordSetInit;
            recSetInit.SetSourceTable(fc as ITable, null);

            return (IRecordSet2)recSetInit;
        }
        public static void StoreToFile(IFeatureClass fc, string filePath)
        {
            XElement xdoc = StoreAsXml(fc);

            XElement el = new XElement("FeatureClass", new XAttribute("name", fc.AliasName),
                                        xdoc);

            el.Save(filePath);
        }
        public static XElement StoreAsXml(IFeatureClass fc)
        {
            // Can't serialize a feature class directly, so convert
            //  to recordset first.
            IRecordSet2 recordset = ConvertToRecordset(fc);

            IXMLSerializer xmlSer = new XMLSerializerClass();
            string sXml = xmlSer.SaveToString(recordset, null, null);

            return XElement.Parse(sXml);
        }

        public static IFeatureLayer RetreiveFromFile(string filepath)
        {
            XElement xdoc = XElement.Load(filepath);
            string sName = xdoc.FirstAttribute.Value;
            XNode recordset = xdoc.FirstNode;

            return RetreiveFromXml(recordset, sName);
        }
        public static IFeatureLayer RetreiveFromXml(XElement xdoc)
        {
          //  XElement xdoc = XElement.Load(filepath);
            string sName = xdoc.FirstAttribute.Value;
            XNode recordset = xdoc.FirstNode;

            return RetreiveFromXml(recordset, sName);
        }
        public static IFeatureLayer RetreiveFromXml(XNode node, string sName)
        {
            IXMLSerializer xmlDeSer = new XMLSerializerClass();
            IRecordSet2 recordset = (IRecordSet2)xmlDeSer.LoadFromString(node.ToString(), null, null);

            return ConvertToFeatureClass(recordset, sName);
        }
        /// <summary>
        /// IRecordSet2转FeatureClass
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        private static IFeatureLayer ConvertToFeatureClass(IRecordSet2 rs, string sName)
        {
            IWorkspaceFactory pWSFact = new ShapefileWorkspaceFactory();

            string sTempPath = Path.GetTempPath();
            IFeatureWorkspace pFWS = (IFeatureWorkspace)pWSFact.OpenFromFile(sTempPath, 0);
            
            // Will fail (COM E_FAIL) if the dataset already exists
            DeleteExistingDataset(pFWS, sName);

            IFeatureClass pFeatClass = null;
            pFeatClass = pFWS.CreateFeatureClass(sName, rs.Fields, null, null, esriFeatureType.esriFTSimple,
                                                 "SHAPE", "");

            // Copy incoming record set table to new feature class's table
            ITable table = (ITable)pFeatClass;
            table = rs.Table;

            IFeatureClass result = table as IFeatureClass;

            // It will probably work OK without this, but it makes the XML match more closely
            IClassSchemaEdit3 schema = result as IClassSchemaEdit3;
            schema.AlterAliasName(sName);
            //schema.AlterFieldAliasName("FID", "");
            //schema.AlterFieldModelName("FID", "");
            schema.AlterFieldAliasName("Shape", "");
            schema.AlterFieldModelName("Shape", "");

            // If individual fields need to be edited, do something like this:
            //      int nFieldIndex = result.Fields.FindField("Shape");
            //      IFieldEdit2 field = (IFieldEdit2)result.Fields.get_Field(nFieldIndex);

            // Cleanup 
            DeleteExistingDataset(pFWS, sName);
           
            return ConvertToFeatureLayer(table as IFeatureClass);
        }
        public static IFeatureLayer ConvertToFeatureLayer(IFeatureClass pFeatureClass) {

            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
            if (pFeatureClass != null)
            {
                //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载

                m_FeatureLayer.FeatureClass = pFeatureClass;
                m_FeatureLayer.Name = pFeatureClass.AliasName;
                m_FeatureLayer.Selectable = false;
            }
            return m_FeatureLayer;
        }
        public static void DeleteExistingDataset(IFeatureWorkspace pFWS, string sDatasetName)
        {
            IWorkspace pWS = (IWorkspace)pFWS;
            IEnumDatasetName pEDSN = pWS.get_DatasetNames(esriDatasetType.esriDTFeatureClass);
            bool bDatasetExists = false;
            pEDSN.Reset();
            IDatasetName pDSN = pEDSN.Next();
            while (pDSN != null)
            {
                if (pDSN.Name == sDatasetName)
                {
                    bDatasetExists = true;
                    break;
                }
                pDSN = pEDSN.Next();
            }
            if (bDatasetExists)
            {
                IFeatureClass pFC = pFWS.OpenFeatureClass(sDatasetName);
                IDataset pDataset = (IDataset)pFC;
                pDataset.Delete();
            }
        }
        public static byte[] BinarySerializer(object obj)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    var data = ms.ToArray();
                    return data;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        public static object BinaryDeserializer(byte[] bt)
        {
            object obj = null;
            try
            {
                using (var ms = new MemoryStream(bt))
                {
                    var formatter = new BinaryFormatter();
                    obj = formatter.Deserialize(ms);
                }
            }
            catch (InvalidOperationException)
            {

            }
            return obj;
        }





        /// <summary>
        /// 序列化AE对象为字符串，在线程间传递
        /// </summary>
        public static string SerialsAEObject(IWorkspace pWorkspace)
        {
            try
            {
                IXMLStream pStream = new XMLStreamClass();
                IXMLWriter pWriter = new XMLWriterClass();
                pWriter.WriteTo(pStream as IStream);

                IXMLSerializer pSerializer = new XMLSerializerClass();

                //pWorkspace不能序列化，会报错
                pSerializer.WriteObject(pWriter, null, null, "", "", pWorkspace.ConnectionProperties);
                return pStream.SaveToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "";
            }
        }


        public static IWorkspace DeSerialsAEObject(string strObj, string PassWord)
        {
            try
            {
                IXMLStream pStream = new XMLStreamClass();
                pStream.LoadFromString(strObj);
                IXMLReader pReader = new XMLReaderClass();
                pReader.ReadFrom(pStream as IStream);
                IXMLSerializer pSerializer = new XMLSerializerClass();

                IPropertySet pPropSet = pSerializer.ReadObject(pReader, null, null) as IPropertySet;
                pPropSet.SetProperty("PASSWORD", PassWord);//反序列化后密码是空，需要重新赋值，要不会弹出连接参数界面
                IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();
                IWorkspace pWS = workspaceFactory.Open(pPropSet, 0);
                return pWS;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

    }
}
