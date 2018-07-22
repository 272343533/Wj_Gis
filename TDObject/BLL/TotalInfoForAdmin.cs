using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTGeoWeb.BLLForAdmin
{

    public class IntersectTotalInfo
    {
        public string LayerName { get; set; }//层名称
        public string ObjCode { get; set; }//地块编码（选择的）
        public string ObjName { get; set; }//地块名称（选择的）
        public List<TotalLayerInfo> totalLayers { get; set; }
    }

    /// <summary>
    /// 每层的统计信息
    /// </summary>
    public class TotalLayerInfo
    {
        public int ItemNo { get; set; }//序号
        public string ItemName { get; set; }//统计名称，相交层名，分类名称
        public decimal RegionArea { get; set; }//地块面积
        public int RegionCount { get; set; }//地块数量
        public decimal BuildingArea { get; set; }//建筑面积
        public decimal FloorArea { get; set; }//建筑占地面积

        public List<TotalTypeInfo> totalTypes { get; set; }//分类统计数据
    }

    /// <summary>
    /// 每层的分类的统计信息
    /// </summary>
    public class TotalTypeInfo
    {
        public int ItemNo { get; set; }//序号
        public string ItemName { get; set; }//统计名称，相交层名，分类名称
        public decimal RegionArea { get; set; }//地块面积
        public int RegionCount { get; set; }//地块数量
        public decimal BuildingArea { get; set; }//建筑面积
        public decimal FloorArea { get; set; }//建筑占地面积
        public string RegionCodes { get; set; }//逗号分隔的地块列表，房屋不会分割成多块
        public List<TotalLtdInfo> totalLtds { get; set; }//土地现状中包含的每个地块的企业单位数据

    }

    /// <summary>
    /// 每个分类的企业统计信息
    /// </summary>
    public class TotalLtdInfo
    {
        public int LtdNo { get; set; }
        public string LtdName { get; set; }
        public string RegionCode { get; set; }
        public decimal RegionArea { get; set; }
        public decimal BuildingArea { get; set; }//建筑面积
        public decimal FloorArea { get; set; }//建筑占地面积

    }

    /// <summary>
    /// 企业的详细信息
    /// </summary>
    public class LtdInfo
    {
        public string Name;//企业名称
        public string DKBM;//地块编码
        public string DLMC;//地类名称
        public string PreName;//原企业名称
        public string YDDMWC;//用地单位名称
        public string TDZLQYMC;//土地租赁企业名称
        public string SSXZCMC;//所属行政村名称
        public string KFSMC;//开发商名称
        public decimal ZDMJ;//占地面积
        public decimal DKFUJZZDMJ;//地块附属建筑占地面积
        public decimal DMFSJZMJ;//地块附属建筑面积

    }


}