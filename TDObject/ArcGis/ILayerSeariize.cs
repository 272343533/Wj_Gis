using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Dynamic;
using System.Text;
using log4net;

using TDObject.BLL;
using ESRI.ArcGIS.Geodatabase;
using TDObject.MapControl;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using QyTech.Json;
using System.Threading;

using SunMvcExpress.Dao;
using TDObject.UI;
using ESRI.ArcGIS.SystemUI;
using TDObject.DrawLayer;
using ESRI.ArcGIS.Controls;
using QyTech.Core.BLL;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;

using QyTech.ArcGis;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Xml.Linq;


namespace TDObject.ArcGis
{
    class ILayerSeariize
    {

          // 函数一：将Ilayer转换为Byte数组
/// <summary>
/// 将Layer序列化成byte数组
/// </summary>
/// <param name="pLayer">需序列化的图层</param>
/// <returns>LOB值 ,为byte数组 </returns>
public static byte[] CreateByteFromLayer(ILayer pLayer)
 {
     try
     {

        //Engine中的BlobStream对象
        IMemoryBlobStream pBlobStream = new MemoryBlobStream();

        IPersistStream pPerStreamout = (IPersistStream)pLayer;

        //存入BlobStream
        pPerStreamout.Save(pBlobStream, 0);

        //转换为Variant类型           
       IMemoryBlobStreamVariant pVar = (IMemoryBlobStreamVariant) pBlobStream;

       object pobj = new object();

      //转入Object对象

      pVar.ExportToVariant(out pobj);

      //强制转换为Byte数组，并返回

      return pobj as byte[];
      }
      catch (Exception excp)
      {
        throw new Exception( "将Layer转换为二进制数组出错,"+ excp.Message);  
       }  
   }

  // 函数二:将 Byte数组转换为ILayer对象（此函数需根据不同的Layer类型，用不同的Layer对象转换)

/// <summary>
/// 将byte数组解析为ILayer
/// </summary>
/// <param name="pByte">bLob字段值  </param>

/// <param name="iLayerType">Layer的类型 ,0 is featurelayer, 1 is rastercataloglayer,2 is rasterlayer,3 is grouplayer</param>
/// <returns>转换后的layer</returns>
public static ILayer GetLayerFromByte(byte[] pByte,int iLayerType)
{            
    IMemoryBlobStream pBlobStream = new MemoryBlobStreamClass();

    try
    {

       //与BlobSream指向的内存
       IMemoryBlobStreamVariant pVar = (IMemoryBlobStreamVariant)pBlobStream;

       object pobj = pByte as object;

       //从Byte数据读取数据

       pVar.ImportFromVariant(pobj);

       //根所Layer类型转换为不同的Layer对象

       IPersistStream pPerStreamout = null;

       if (iLayerType == 0) //featurelayer
       {
           pPerStreamout = new FeatureLayerClass();
       }
       else if (iLayerType == 1)//rasterlayer
       {
           pPerStreamout = new RasterLayerClass();

       }
       else if (iLayerType == 2)//grouplayer
       {
           pPerStreamout = new GroupLayerClass();

       }
       else if (iLayerType == 3)//rastercataloglayer
       {
           pPerStreamout = new RasterCatalogLayerClass();

       }
       else
       {
            return null;
       }

       //载入数据，并强制转换为ILayer类型

       pPerStreamout.Load(pBlobStream);

       return pPerStreamout as ILayer;
    }
    catch (Exception excp)
    {
       throw new Exception("将二进制转换为layer出错," + excp.Message);
     }  
 }  

   // 这两个函数的调用比较简单，在需要保存的地方，获取ILayer对象，调用CreateByteFromLayer函数，得到Byte数组后，将Byte数组存入大二进制字段中，如下为示例代码：

//取Map控件中的第一个图层

//byte[] pData = LayerFunction.CreateByteFromLayer(axMapControl1.get_Layer(0));
////用oracleClient方式实现存储
// OracleCommand cmd = new OracleCommand("Insert into meta_layer_data (layername,layerdata,layertype) values (:LAYERNAME,:DATA, :TYPE)", currentConnection);

////表名

//cmd.Parameters.Add(":LAYERNAME", OracleType.VarChar, 50).Value = axMapControl1.get_Layer(0).Name;

////具体数据Blob类型
//cmd.Parameters.Add(":DATA", OracleType.Blob).Value = pData;

////图层类型
//cmd.Parameters.Add(":TYPE", OracleType.Int16, 50).Value = 0;

////执行存储语句
//cmd.ExecuteNonQuery();

 

//    在需要读取数据库表中图层信息的地方，从 blob字段中读取数据至Byte数组，再调用GetLayerFromByte函数，将Byte数组转换为ILayer对象，具体示例代码如下：

////查询语句，读取表中所有的图层

//string strSQL = "select LAYERDATA,LAYERTYPE from META_LAYER_DATA";

//OracleDataAdapter pOracleDataAdapter = new OracleDataAdapter(strSQL, currentConnection);

////执行查询，并将结果存入DataTable中        
//DataTable pTable =  new DataTable("test");
//pOracleDataAdapter.Fill(pTable);

////读取每一条记录，转换为图层后，加入Map按件

// for (int i = 0; i < pTable.Rows.Count; i++)
// {
//     byte[] pData = pTable.Rows[i][0] as byte[];

//     //需要根据不同的Layer类型，给定不同的参数，此处示例默认为图层都为IFeatureLayer类型（矢量图层）
//     ILayer pLayer = LayerFunction.GetLayerFromByte(pData, 0);

//     axMapControl2.AddLayer(pPerStreamout as ILayer);

//}
    }
}
