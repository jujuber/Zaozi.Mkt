using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zaozi.Utility
{
    /// <summary>
    /// DataTable帮助类
    /// </summary>
    public class DataTableHelper
    {
        #region 给DataTable增加一个自增列
        /// <summary>
        /// 给DataTable增加一个自增列
        /// 如果DataTable 存在 identityid 字段  则 直接返回DataTable 不做任何处理
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>返回Datatable 增加字段 identityid </returns>
        public static DataTable AddIdentityColumn(DataTable dt)
        {
            if (!dt.Columns.Contains("identityid"))
            {
                dt.Columns.Add("identityid");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["identityid"] = (i + 1).ToString();
                }
            }
            return dt;
        }
        #endregion

        #region 检查DataTable 是否有数据行
        /// <summary>
        /// 检查DataTable 是否有数据行
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static bool IsHaveRows(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
                return true;

            return false;
        }
        #endregion

        #region DataTable转换成实体列表
        /// <summary>
        /// DataTable转换成实体列表
        /// </summary>
        /// <typeparam name="T">实体 T </typeparam>
        /// <param name="table">datatable</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable table)
        {
            if (!IsHaveRows(table))
                return new List<T>();

            List<T> list = new List<T>();
            T model = default(T);

            #region 获取类属性名与数据库字段名对照字典

            Dictionary<string, string> dict_Columns = new Dictionary<string, string>();

            Type model_type = Activator.CreateInstance<T>().GetType();

            foreach (var item in model_type.GetProperties())
            {
                foreach (DataColumn dc in table.Columns)
                {
                    if (item.Name.ToUpper() == dc.ColumnName.ToUpper())
                    {
                        dict_Columns.Add(dc.ColumnName, item.Name);
                    }
                }
            }

            #endregion

            foreach (DataRow dr in table.Rows)
            {

                model = Activator.CreateInstance<T>();

                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object drValue = dr[dc.ColumnName];

                    if (!dict_Columns.ContainsKey(dc.ColumnName))
                    {
                        continue;
                    }

                    PropertyInfo pi = model.GetType().GetProperty(dict_Columns[dc.ColumnName]);

                    if (pi != null && pi.CanWrite && (drValue != null && !Convert.IsDBNull(drValue)))
                    {
                        #region 可空类型获取真实类型
                        var t = pi.PropertyType;

                        if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            t = Nullable.GetUnderlyingType(t);
                        }
                        #endregion

                        //根据字段类型转换
                        var realValue = Convert.ChangeType(drValue, t);

                        pi.SetValue(model, realValue, null);
                    }
                }

                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// DataTable转换成实体列表
        /// </summary>
        /// <typeparam name="T">实体 T </typeparam>
        /// <param name="table">datatable</param>
        /// <returns></returns>
        public static List<T> DataTableToListNotToUpper<T>(DataTable table)
        {
            if (!IsHaveRows(table))
                return new List<T>();

            List<T> list = new List<T>();
            T model = default(T);

            #region 获取类属性名与数据库字段名对照字典

            Dictionary<string, string> dict_Columns = new Dictionary<string, string>();

            Type model_type = Activator.CreateInstance<T>().GetType();

            foreach (var item in model_type.GetProperties())
            {
                foreach (DataColumn dc in table.Columns)
                {
                    if (item.Name == dc.ColumnName)
                    {
                        dict_Columns.Add(dc.ColumnName, item.Name);
                    }
                }
            }

            #endregion

            foreach (DataRow dr in table.Rows)
            {

                model = Activator.CreateInstance<T>();

                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object drValue = dr[dc.ColumnName];

                    if (!dict_Columns.ContainsKey(dc.ColumnName))
                    {
                        continue;
                    }

                    PropertyInfo pi = model.GetType().GetProperty(dict_Columns[dc.ColumnName]);

                    if (pi != null && pi.CanWrite && (drValue != null && !Convert.IsDBNull(drValue)))
                    {
                        #region 可空类型获取真实类型
                        var t = pi.PropertyType;

                        if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            t = Nullable.GetUnderlyingType(t);
                        }
                        #endregion

                        //根据字段类型转换
                        var realValue = Convert.ChangeType(drValue, t);

                        pi.SetValue(model, realValue, null);
                    }
                }

                list.Add(model);
            }
            return list;
        }
        #endregion

        #region DataRow转换成实体
        /// <summary>
        /// DataTable转换成实体列表
        /// </summary>
        /// <typeparam name="T">实体 T </typeparam>
        /// <param name="DataRow">DataRow</param>
        /// <returns></returns>
        public static T DataRowToModel<T>(DataRow dataRow)
        {
            T model = default(T);

            model = Activator.CreateInstance<T>();

            foreach (DataColumn dc in dataRow.Table.Columns)
            {
                object drValue = dataRow[dc.ColumnName];
                PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);

                if (pi != null && pi.CanWrite && (drValue != null && !Convert.IsDBNull(drValue)))
                {
                    #region 可空类型获取真实类型
                    var t = pi.PropertyType;

                    if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        t = Nullable.GetUnderlyingType(t);
                    }
                    #endregion

                    //根据字段类型转换
                    var realValue = Convert.ChangeType(drValue, t);

                    pi.SetValue(model, realValue, null);
                }
            }

            return model;
        }
        #endregion

        #region 实体列表转换成DataTable
        /// <summary>
        /// 实体列表转换成DataTable
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="list"> 实体列表</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> list)
            where T : class
        {
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int length = myPropertyInfo.Length;
            for (int i = 0; i < length; i++)
            {
                PropertyInfo pi = myPropertyInfo[i];
                string name = pi.Name.ToUpper();
                Type columnType = pi.PropertyType;

                //如果类型为Nullable则转为原始类型
                if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    columnType = pi.PropertyType.GetGenericArguments()[0];
                }

                column = new DataColumn(name, columnType);
                dt.Columns.Add(column);
            }

            if (list == null || list.Count <= 0)
            {
                return dt;
            }

            try
            {
                foreach (T t in list)
                {
                    if (t == null)
                    {
                        continue;
                    }

                    row = dt.NewRow();
                    for (int i = 0; i < length; i++)
                    {
                        PropertyInfo pi = myPropertyInfo[i];
                        string name = pi.Name.ToUpper();
                        Type columnType = pi.PropertyType;
                        try
                        {
                            object oValue = pi.GetValue(t, null);
                            if (oValue == null)
                            {
                                row[name] = DBNull.Value;
                            }
                            else
                            {
                                if (pi.PropertyType.IsGenericType)
                                {
                                    row[name] = pi.GetValue(t, null).ToString().Trim();
                                }
                                else
                                {
                                    row[name] = pi.GetValue(t, null);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        #endregion

        #region 将泛型集合类转换成DataTable
        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);
        }
        #endregion

        #region 将泛型集合类转换成DataTable
        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);

            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        try
                        {
                            result.Columns.Add(pi.Name, pi.PropertyType);
                        }
                        catch
                        {
                            result.Columns.Add(pi.Name);
                        }
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                        {
                            try
                            {
                                result.Columns.Add(pi.Name, pi.PropertyType);
                            }
                            catch
                            {
                                result.Columns.Add(pi.Name);
                            }
                        }
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        #endregion

        #region 根据nameList里面的字段创建一个表格,返回该表格的DataTable
        /// <summary>
        /// 根据nameList里面的字段创建一个表格,返回该表格的DataTable
        /// </summary>
        /// <param name="nameList">包含字段信息的列表</param>
        /// <returns>DataTable</returns>
        public static DataTable CreateTable(List<string> nameList)
        {
            if (nameList.Count <= 0)
                return null;

            DataTable myDataTable = new DataTable();
            foreach (string columnName in nameList)
            {
                myDataTable.Columns.Add(columnName, typeof(string));
            }
            return myDataTable;
        }
        #endregion

        #region 通过字符列表创建表字段
        /// <summary>
        /// 通过字符列表创建表字段，字段格式可以是：
        /// 1) a,b,c,d,e
        /// 2) a|int,b|string,c|bool,d|decimal
        /// </summary>
        /// <param name="nameString"></param>
        /// <returns></returns>
        public static DataTable CreateTable(string nameString)
        {
            string[] nameArray = nameString.Split(new char[] { ',', ';' });
            List<string> nameList = new List<string>();
            DataTable dt = new DataTable();
            foreach (string item in nameArray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] subItems = item.Split('|');
                    if (subItems.Length == 2)
                    {
                        dt.Columns.Add(subItems[0], ConvertType(subItems[1]));
                    }
                    else
                    {
                        dt.Columns.Add(subItems[0]);
                    }
                }
            }
            return dt;
        }

        private static Type ConvertType(string typeName)
        {
            typeName = typeName.ToLower().Replace("system.", "");
            Type newType = typeof(string);
            switch (typeName)
            {
                case "boolean":
                case "bool":
                    newType = typeof(bool);
                    break;
                case "int16":
                case "short":
                    newType = typeof(short);
                    break;
                case "int32":
                case "int":
                    newType = typeof(int);
                    break;
                case "long":
                case "int64":
                    newType = typeof(long);
                    break;
                case "uint16":
                case "ushort":
                    newType = typeof(ushort);
                    break;
                case "uint32":
                case "uint":
                    newType = typeof(uint);
                    break;
                case "uint64":
                case "ulong":
                    newType = typeof(ulong);
                    break;
                case "single":
                case "float":
                    newType = typeof(float);
                    break;

                case "string":
                    newType = typeof(string);
                    break;
                case "guid":
                    newType = typeof(Guid);
                    break;
                case "decimal":
                    newType = typeof(decimal);
                    break;
                case "double":
                    newType = typeof(double);
                    break;
                case "datetime":
                    newType = typeof(DateTime);
                    break;
                case "byte":
                    newType = typeof(byte);
                    break;
                case "char":
                    newType = typeof(char);
                    break;
            }
            return newType;
        }
        #endregion

        #region 获得从DataRowCollection转换成的DataRow数组
        /// <summary>
        /// 获得从DataRowCollection转换成的DataRow数组
        /// </summary>
        /// <param name="drc">DataRowCollection</param>
        /// <returns></returns>
        public static DataRow[] GetDataRowArray(DataRowCollection drc)
        {
            int count = drc.Count;
            DataRow[] drs = new DataRow[count];
            for (int i = 0; i < count; i++)
            {
                drs[i] = drc[i];
            }
            return drs;
        }
        #endregion

        #region 将DataRow数组转换成DataTable
        /// <summary>
        /// 将DataRow数组转换成DataTable，注意行数组的每个元素须具有相同的数据结构，
        /// 否则当有元素长度大于第一个元素时，抛出异常
        /// </summary>
        /// <param name="rows">行数组</param>
        /// <returns></returns>
        public static DataTable GetTableFromRows(DataRow[] rows)
        {
            if (rows.Length <= 0)
            {
                return new DataTable();
            }
            DataTable dt = rows[0].Table.Clone();
            dt.DefaultView.Sort = rows[0].Table.DefaultView.Sort;
            for (int i = 0; i < rows.Length; i++)
            {
                dt.LoadDataRow(rows[i].ItemArray, true);
            }
            return dt;
        }
        #endregion

        #region 排序表的视图
        /// <summary>
        /// 排序表的视图
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sorts"></param>
        /// <returns></returns>
        public static DataTable SortedTable(DataTable dt, params string[] sorts)
        {
            if (dt.Rows.Count > 0)
            {
                string tmp = "";
                for (int i = 0; i < sorts.Length; i++)
                {
                    tmp += sorts[i] + ",";
                }
                dt.DefaultView.Sort = tmp.TrimEnd(',');
            }
            return dt;
        }
        #endregion

        #region 根据条件过滤表的内容
        /// <summary>
        /// 根据条件过滤表的内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable FilterDataTable(DataTable dt, string condition)
        {
            if (condition.Trim() == "")
            {
                return dt;
            }
            else
            {
#pragma warning disable CA2000 // 丢失范围之前释放对象
                DataTable newdt = new DataTable();
#pragma warning restore CA2000 // 丢失范围之前释放对象
                newdt = dt.Clone();
                DataRow[] dr = dt.Select(condition);
                for (int i = 0; i < dr.Length; i++)
                {
                    newdt.ImportRow((DataRow)dr[i]);
                }
                return newdt;
            }
        }
        #endregion

        #region XmlNodeList转DataTable
        /// <summary>
        ///  XmlNodeList转DataTable
        /// </summary>
        /// <param name="xnl">XmlNodeList</param>
        /// <param name="IsEncrypt">是否加密</param>
        /// <returns></returns>
        public static DataTable XmlNodeListToDataTable(XmlNodeList xnl, bool IsEncrypt)
        {
            DataTable dt = new DataTable();
            //表结构
            foreach (XmlElement XEL in xnl)
            {
                for (int i = 0; i < XEL.Attributes.Count; i++)
                {
#pragma warning disable CA2000 // 丢失范围之前释放对象
                    DataColumn dc = new DataColumn(XEL.Attributes[i].Name, System.Type.GetType("System.String"));
#pragma warning restore CA2000 // 丢失范围之前释放对象
                    if (!dt.Columns.Contains(XEL.Attributes[i].Name))
                    {
                        dt.Columns.Add(dc);
                    }
                }
            }

            int ColumnsCount = dt.Columns.Count;
            for (int i = 0; i < xnl.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (IsEncrypt)
                    {
                        object oValue = xnl.Item(i).Attributes[j].Value;
                        if (oValue == null || oValue.ToString() == "")
                        {
                            dr[j] = DBNull.Value;
                        }
                        else
                        {
                            dr[j] = DEncryptHelper.Decrypt(oValue.ToString());
                        }
                    }
                    else
                    {
                        dr[j] = xnl.Item(i).Attributes[j].Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region 根据实体类得到表结构
        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static DataTable CreateData<T>(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.Name != "CTimestamp")//些字段为oracle中的Timesstarmp类型
                {
                    dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
                }
                else
                {
                    dataTable.Columns.Add(new DataColumn(propertyInfo.Name, typeof(DateTime)));
                }
            }
            return dataTable;
        }
        #endregion

        #region 深度复制实体类
        /// <summary>
        /// 深度复制实体类，用于该表复制出来的实体类的值不影响原有实体类的值
        /// </summary>
        /// <typeparam name="T">泛型实体类</typeparam>
        /// <param name="RealObject">需要复制的实体类</param>
        /// <returns>返回新的实体类，内存另起</returns>
        public static T Clone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }
        #endregion

        #region 通过一个Databel 过滤另外一个DataTable
        public static DataTable FiteaParentDataTableByNodeTable(DataTable dtNode, string nodeColomnName, DataTable dtParent, string parentColomnName)
        {
            DataTable temp = dtNode.DefaultView.ToTable(true, nodeColomnName);

            DataTable dtTemp = dtParent;

            string searchKey = "";

            if (temp.Rows.Count > 0)
            {
                foreach (DataRow dr in temp.Rows)
                {
                    searchKey += "'" + dr[0].ToString() + "',";
                }

                searchKey = searchKey.Substring(0, searchKey.Length - 1);

                dtTemp = DataTableHelper.FilterDataTable(dtParent, "" + parentColomnName + " in(" + searchKey + ") ");
            }


            return dtTemp;
        }
        #endregion

        #region DataTable数据清空格

        public static void DataTableTrim(DataTable dt)
        {
            if (IsHaveRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        dr[dc.ColumnName] = dr[dc.ColumnName].ToString().Trim();
                    }
                }
            }
        }

        #endregion

        #region 实体列表转换成DataTable
        /// <summary>
        /// 实体列表转换成DataTable
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="list"> 实体列表</param>
        /// <returns></returns>
        public static DataTable ListToDataTableNotToUpper<T>(IList<T> list)
            where T : class
        {
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int length = myPropertyInfo.Length;
            for (int i = 0; i < length; i++)
            {
                PropertyInfo pi = myPropertyInfo[i];
                string name = pi.Name;
                Type columnType = pi.PropertyType;

                //如果类型为Nullable则转为原始类型
                if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    columnType = pi.PropertyType.GetGenericArguments()[0];
                }

                column = new DataColumn(name, columnType);
                dt.Columns.Add(column);
            }

            if (list == null || list.Count <= 0)
            {
                return dt;
            }

            try
            {
                foreach (T t in list)
                {
                    if (t == null)
                    {
                        continue;
                    }

                    row = dt.NewRow();
                    for (int i = 0; i < length; i++)
                    {
                        PropertyInfo pi = myPropertyInfo[i];
                        string name = pi.Name;
                        Type columnType = pi.PropertyType;
                        try
                        {
                            object oValue = pi.GetValue(t, null);
                            if (oValue == null)
                            {
                                row[name] = DBNull.Value;
                            }
                            else
                            {
                                if (pi.PropertyType.IsGenericType)
                                {
                                    row[name] = pi.GetValue(t, null).ToString().Trim();
                                }
                                else
                                {
                                    row[name] = pi.GetValue(t, null);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        #endregion
    }
}
