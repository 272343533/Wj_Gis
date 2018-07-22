using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDObject.ArcGis
{
    class XmlSerializeHelper
    {
      static  log4net.ILog log = log4net.LogManager.GetLogger(" TDObject.ArcGis XmlSerializeHelper");

        /// <summary>
        /// ArcGIS对象序列化成二进制
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static byte[] ReadObjectToBytes(object pObject)
        {
            byte[] defaultBytes = null;
            if (pObject is IPersistStream)
            {
                IPersistStream persistStream = pObject as IPersistStream;
                IObjectStream pObjStream = new ObjectStreamClass();
                IMemoryBlobStream pBlobStream = new MemoryBlobStreamClass();
                pObjStream.Stream = pBlobStream;
                persistStream.Save(pObjStream, 0);

                int n = (int)pBlobStream.Size;
                defaultBytes = new byte[n];
                object obj2 = null;
                IMemoryBlobStreamVariant pBlobVariant = pBlobStream as IMemoryBlobStreamVariant;
                pBlobVariant.ExportToVariant(out obj2);
                defaultBytes = (byte[])obj2;
            }
            return defaultBytes;
        }

        /// <summary>
        /// 二进制反序列化成ArcGIS对象
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="pObject"></param>
        public static void ReadObjectFromBytes(byte[] bytes, object pObject)
        {
            if (pObject is IPersistStream)
            {
                IPersistStream pPersistStream = pObject as IPersistStream;
                IMemoryBlobStream2 pBlobStream = new MemoryBlobStreamClass();
                pBlobStream.ImportFromMemory(ref bytes[0], (uint)bytes.Length);
                IObjectStream pObjStream = new ObjectStreamClass();
                pObjStream.Stream = pBlobStream;
                pPersistStream.Load(pObjStream);
            }
        }

        /// <summary>
        /// 读取ArcGIS BLOB类型属性到byte数组
        /// </summary>
        /// <param name="blobValue">字段值</param>
        /// <returns></returns>
        public static byte[] ReadEsriBlobToBytes(object blobValue)
        {
            if (blobValue == null || blobValue == DBNull.Value)
            {
                return null;
            }

            IMemoryBlobStream2 pBlobStream = new MemoryBlobStreamClass();
            pBlobStream = (IMemoryBlobStream2)blobValue;
            int n = (int)pBlobStream.Size;
            byte[] bytes = new byte[n];
            object obj = null;
            IMemoryBlobStreamVariant pBlobVariant = pBlobStream as IMemoryBlobStreamVariant;
            pBlobVariant.ExportToVariant(out obj);
            bytes = (byte[])obj;

            return bytes;
        }


        /// <summary>
        /// 将AE中实现了IPersistStream接口的对象序列化为二进制文件
        /// </summary>
        /// <param name="FilePath">如C:\file.blb</param>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static bool WriteObj(string FilePath, object pObject)
        {
            bool result = false;
            if (pObject is IPersistStream)
            {
                IPersistStream persistStream = pObject as IPersistStream;
                IObjectStream pObjStream = new ObjectStreamClass();
                IMemoryBlobStream pBlobStream = new MemoryBlobStreamClass();
                pObjStream.Stream = pBlobStream;
                persistStream.Save(pObjStream, 0);
                try
                {
                    pBlobStream.SaveToFile(FilePath);
                    result = true;
                }
                catch { }
            }
            return result;
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
