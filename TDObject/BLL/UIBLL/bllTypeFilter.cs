using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SunMvcExpress.Dao;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;

using TDObject.MapControl;


namespace TDObject.BLL.UIBLL
{
    public class bllTypeFilter
    {
        public Dictionary<string, bsDynCondition> menus = new Dictionary<string, bsDynCondition>();
        ILayer pLayer;
        List<IFeature> pGeos = new List<IFeature>();//用于高亮
        IEnvelope newdisp = (IEnvelope)new Envelope();//用于定位
        List<IGeometry> Geos = new List<IGeometry>();

        public bllTypeFilter(AxMapControl map)
        {
            //menus.Add("2000万以上", "2000万以上|1|2000,3000万以上|1|3000,5000万以上|1|5000,1亿 以上|1|10000");
            //menus.Add("安全生产标准话企业", "一级|2|=,二级|2|=,三级|2|=");
            //menus.Add("上市企业", "台资拟上市|131|,三版挂牌|132|,主板后备|133|");
            //menus.Add("历年清洁生产企业", "2018年度|4|2018,2017年度|4|2017,2016年度|4|2016");
            //menus.Add("智能制造示范企业", " 智能设计|5|=,智能生产|5|=,智能制造|5|=,供应链管理|5|=,生产性电商|5|=");
            //menus.Add("新地标计划培育企业", "超1亿元|6|=,超5亿元|6|=,超10亿元|6|=,超20亿元|6|=");
            //menus.Add("智能车间企业", "2018年度|7|2018,2017年度|7|2017,2016年度|7|2016");
            //menus.Add("闲置土地盘活计划", "10亩以上|8|10,20亩以上|8|20,50亩以上|8|30,100亩以上|8|100");
            //menus.Add("企业技术中心台账", "市级|9|=,省级级|9|=,国家级|9|=");

            List<bsDynCondition> conds = TDObject.DAOBLL.RoleRelBll.GetRightItem();
            for (int i = 0; i < conds.Count; i++) {
                if (conds[i].compType!=null)
                {
                    menus.Add(conds[i].condName, conds[i]);
                }
            }
            pLayer = GlobalVariables.GetOverviewLayer(map, "企业范围");
        }

        //public void GetIndexAndCondtinoValue(string ptext, string text, out int index, out string value)
        //{
        //    index = 1;
        //    value = "";
        //    string[] values = menus[ptext].Split(new char[] { ',', '|' });
        //    for (int i = 0; i < values.Length; i += 3)
        //    {
        //        string val = values[i];
        //        if (val == text)
        //        {
        //            index = Convert.ToInt32(values[i + 1]);
        //            if (values[i + 2] == "=")
        //                value = values[i];
        //            else
        //                value = values[i + 2];
        //        }
        //    }
        //}


        private void ManageWhereOrderby(int refreshflag, string value, ref string sqlwhere, ref string sqlOrderby)
        {
            try
            {
                sqlwhere = "";
                sqlOrderby = "序号";

                if (refreshflag == 1)
                {
                    sqlOrderby = "序号";
                    sqlwhere += " or 累计销售额合计>=" + value;

                }
                else if (refreshflag == 2)
                {
                    sqlOrderby = "序号";
                    sqlwhere += " or 标准化级别='" + value + "'";
                }
                else if (refreshflag == 131 || refreshflag == 3)
                {
                    sqlOrderby = "序号";
                }
                else if (refreshflag == 132)
                {
                    sqlOrderby = "序号";
                }
                else if (refreshflag == 133)
                {
                    sqlOrderby = "序号";
                }
                else if (refreshflag == 4)
                {
                    sqlwhere += " or 年度=" + value;
                }
                else if (refreshflag == 5)
                {
                    sqlwhere += " or 所属环节='" + value + "'";

                }
                else if (refreshflag == 6)
                {
                    sqlwhere += " or 目标='" + value + "'";
                }
                else if (refreshflag == 7)
                {
                    sqlwhere += " or 获评年份=" + value;
                }
                else if (refreshflag == 8)
                {
                    sqlwhere += " or 土地面积>=" + value;

                }
                else if (refreshflag == 9)
                {
                    sqlOrderby = " Convert(int,序号)";
                    sqlwhere += " or 级别='" + value + "'";

                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 按照企业范围的过滤条件高亮地图显示
        /// </summary>
        /// <param name="cond"></param>
        public void RefreshData(string cond) {
            List<企业范围> objs = MainForm.EM.GetListNoPaging<企业范围>(cond, "");
            string dkbhs = "";

            foreach (企业范围 obj in objs)
            {
                if (obj.DKBH != null && obj.DKBH != "")
                {
                    dkbhs += "," + obj.DKBH;
                }
            }
            pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);


            if (Geos.Count > 0)
                LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, Geos);

        }

        //public void RefreshData(int refreshflag, string value)
        //{
        //    try
        //    {
        //        string dkbhs = "";

        //        string sqlwhere = "";
        //        string sqlOrderby = "";
        //        ManageWhereOrderby(refreshflag, value, ref sqlwhere, ref sqlOrderby);

        //        if (sqlwhere.Length > 0)
        //            sqlwhere = sqlwhere.Substring(4);
        //        else if (refreshflag < 130)
        //        {
        //            return;
        //        }
        //        if (refreshflag == 1)
        //        {
        //            List<t开发区2000万企业> objs = MainForm.EM.GetListNoPaging<t开发区2000万企业>(sqlwhere, sqlOrderby);
        //            foreach (t开发区2000万企业 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }
        //        }
        //        else if (refreshflag == 2)
        //        {
        //            List<t标准化级别> objs = MainForm.EM.GetListNoPaging<t标准化级别>(sqlwhere, sqlOrderby);
        //            foreach (t标准化级别 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 131 || refreshflag == 3)
        //        {
        //            List<t同里镇开发区上市企业台帐台资> objs = MainForm.EM.GetListNoPaging<t同里镇开发区上市企业台帐台资>(sqlwhere, sqlOrderby);
        //            foreach (t同里镇开发区上市企业台帐台资 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 132)
        //        {
        //            List<t同里镇开发区上市企业台帐三板> objs = MainForm.EM.GetListNoPaging<t同里镇开发区上市企业台帐三板>(sqlwhere, sqlOrderby);
        //            foreach (t同里镇开发区上市企业台帐三板 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 133)
        //        {
        //            List<t同里镇开发区上市企业台帐主版后备> objs = MainForm.EM.GetListNoPaging<t同里镇开发区上市企业台帐主版后备>(sqlwhere, sqlOrderby);
        //            foreach (t同里镇开发区上市企业台帐主版后备 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 4)
        //        {
        //            List<t清洁生产历年> objs = MainForm.EM.GetListNoPaging<t清洁生产历年>(sqlwhere, sqlOrderby);
        //            foreach (t清洁生产历年 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 5)
        //        {
        //            List<t吴江区智能制造示范试点企业名单> objs = MainForm.EM.GetListNoPaging<t吴江区智能制造示范试点企业名单>(sqlwhere, sqlOrderby);
        //            foreach (t吴江区智能制造示范试点企业名单 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 6)
        //        {
        //            List<t新地标计划企业名单> objs = MainForm.EM.GetListNoPaging<t新地标计划企业名单>(sqlwhere, sqlOrderby);
        //            foreach (t新地标计划企业名单 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 7)
        //        {
        //            List<t智能车间> objs = MainForm.EM.GetListNoPaging<t智能车间>(sqlwhere, sqlOrderby);
        //            foreach (t智能车间 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 8)
        //        {
        //            List<t闲置土地盘活计划表> objs = MainForm.EM.GetListNoPaging<t闲置土地盘活计划表>(sqlwhere, sqlOrderby);
        //            foreach (t闲置土地盘活计划表 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        else if (refreshflag == 9)
        //        {
        //            List<t企业技术中心台账> objs = MainForm.EM.GetListNoPaging<t企业技术中心台账>(sqlwhere, sqlOrderby);
        //            foreach (t企业技术中心台账 obj in objs)
        //            {
        //                if (obj.地块编号 != null && obj.地块编号 != "")
        //                {
        //                    dkbhs += "," + obj.地块编号;
        //                }
        //            }

        //        }
        //        pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);


        //        if (Geos.Count > 0)
        //            LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, Geos);
        //    }
        //    catch (Exception ex)
        //    {
        //        //log.Error(this.Name + ":" + ex.Message);
        //        //MessageBox.Show(ex.Message);
        //    }

        //}

        public void ExDisplayOneLtdFeature(string dkbh)
        {
            pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbh, ",", ref newdisp, ref Geos);

            if (Geos.Count > 0)
                LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, Geos);
        }

        public void ExPostionOneLtdFeature(string dkbh)
        {
            pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbh, ",", ref newdisp, ref Geos);
            if (Geos.Count > 0)
                LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp);
        }

        public void ExPositionAndDisply(string dkbh)
        {
            pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbh, ",", ref newdisp, ref Geos);
            if (Geos.Count > 0)
            {
                LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp);
                //GlobalVariables.axMapControl.Refresh(esriViewDrawPhase.esriViewAll, null, newdisp);
                //System.Threading.Thread.Sleep(5000);
                LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, Geos);

            }
        }
    
    }
}
