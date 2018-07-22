using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDObject.BLL
{
    public class FieldsRef
    {
        public string LayerName { get; set; }
        public string TotalType { get; set; }
        public string FieldsName { get; set; }
        public KeyValuePair<string, string>[] FieldsValue { get; set; }
        List<IFeature> FeatureList { get; set; }
        public FieldsRef(string layername, string totaltype, string fieldsname, KeyValuePair<string, string>[] fieldsvalue)
        {
            LayerName = layername;
            FieldsName = fieldsname;
            FieldsValue = fieldsvalue;
            TotalType = totaltype;
        }
    }
}
