using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace QyTech.SQLDA
{
    /// <summary>
    ///     数据表转换类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbTableConvertor<T> where T : new()
    {
        /// <summary>
        ///     将DataTable转换为实体列表
        ///     作者: oldman
        ///     创建时间: 2015年9月13日
        /// </summary>
        /// <param name="dt">待转换的DataTable</param>
        /// <returns></returns>
        public List<T> ConvertToList(DataTable dt)
        {
            // 定义集合  
            var list = new List<T>();
            try
            {
                if (0 == dt.Rows.Count)
                {
                    return list;
                }

                // 获得此模型的可写公共属性  
                IEnumerable<PropertyInfo> propertys = new T().GetType().GetProperties().Where(u => u.CanWrite);
                list = ConvertToEntity(dt, propertys);
            }
            catch (Exception ex)
            {

            }

            return list;
        }


        /// <summary>
        ///     将DataTable的某行转换为实体
        /// </summary>
        /// <param name="dt">待转换的DataTable</param>
        /// <param name="rowIndex">从0开始的索引</param>
        /// <returns></returns>
        /// 
        public T ConvertToEntity(DataTable dt,int rowIndex)
        {
            if (dt.Rows.Count<=rowIndex)
                return default(T);
            try
            {
                DataTable dtTable = dt.Clone();
                dtTable.Rows.Add(dt.Rows[rowIndex].ItemArray);
                List<T> list = ConvertToList(dtTable);
                return list[0];
            }
            catch(Exception ex)
            {
                return default(T);
            }
          
        }


        private List<T> ConvertToEntity(DataTable dt, IEnumerable<PropertyInfo> propertys)
        {
            var list = new List<T>();
            try
            {
                //遍历DataTable中所有的数据行  
                foreach (DataRow dr in dt.Rows)
                {
                    var entity = new T();

                    //遍历该对象的所有属性  
                    foreach (PropertyInfo p in propertys)
                    {
                        //将属性名称赋值给临时变量
                        string tmpName = p.Name;

                        //检查DataTable是否包含此列（列名==对象的属性名）    
                        if (!dt.Columns.Contains(tmpName)) continue;
                        //取值  
                        object value = dr[tmpName];
                        //如果非空，则赋给对象的属性  
                        if (value != DBNull.Value)
                        {
                            p.SetValue(entity, value, null);
                        }
                    }
                    //对象添加到泛型集合中  
                    list.Add(entity);
                }
                return list;
            }
            catch (Exception ex) { return null; }
        }





        //private Type getEntity(string typeName)
        //{
        //    Assembly ass = Assembly.LoadFrom(@"SunMvcExpress.Dao.dll");
        //    Type type = ass.GetType("SunMvcExpress.Dao." + typeName);
        //    return type;
        //    //object obj_ = Activator.CreateInstance(type);

        //    //var workPath = AppDomain.CurrentDomain.BaseDirectory;
        //    //string[] files = Directory.GetFiles(workPath, "SunMvcExpress.Dao.dll", SearchOption.TopDirectoryOnly);
        //    //foreach (string file in files)
        //    //{
        //    //    string ext = file.Substring(file.LastIndexOf("."));
        //    //    if (ext != ".dll") continue;
        //    //    try
        //    //    {
        //    //        Assembly asm = Assembly.LoadFile(file);
        //    //        Type[] allTypes = asm.GetTypes();
        //    //        foreach (Type t in allTypes)
        //    //        {
        //    //            if (t.IsSubclassOf(typeof(XXDataRecord)))
        //    //            {
        //    //                if (t.Name.ToUpper().IsSame(typeName.ToUpper()))
        //    //                    return t;
        //    //            }
        //    //        }
        //    //    }
        //    //    catch
        //    //    {
        //    //        return null;
        //    //    }
        //    //}
        //    //return null;
        //}

        //private void A()
        //{
        //    var obj = new GenerateDataHelper(_Param);
        //    Type myGenericClassType = obj.GetType();
        //    //MakeGenericMethod 设置泛型参数类型
        //    MethodInfo mi = myGenericClassType.GetMethod("BuildDataMemoryPattern").MakeGenericMethod(typeEntity);
        //    int count = 0;
        //    //设置调用方法参数
        //    object[] invokeArgs = new object[] { zb, id, count };
        //    //调用
        //    var dt = (DataTable)mi.Invoke(obj, invokeArgs);
        //    //获取回返数据
        //    recordCount = (int)invokeArgs[9];
        //}
    }
}