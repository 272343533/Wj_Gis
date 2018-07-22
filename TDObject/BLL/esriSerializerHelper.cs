using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TDObject.BLL
{
    public static class esriSerializerHelper
    {
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
    }
}
