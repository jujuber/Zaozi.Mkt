using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.DAL;
using Zaozi.Utility;

namespace Zaozi.LocalDict
{
    public partial class ClientDict
    {
        public static T GetData<T>(string strWhere = "", string dbtype = "his")
        {
            string tableName = typeof(T).Name;

            if (tableName == "hissys")
            {
                if (ClientDict.tableHisSys.Rows.Count > 0 && !strWhere.Contains("like"))
                {
                    DataRow[] drs = ClientDict.tableHisSys.Select(strWhere);

                    if (drs.Count() > 0)
                    {
                        return DataTableHelper.DataRowToModel<T>(drs[0]);
                    }
                }

                // 开关表需要查询试图
                tableName = "VI_Hissys";
            }

            DataTable result_dt = Public_Dal.Instance.GetList(tableName, strWhere, dbtype);

            List<T> result_List = DataTableHelper.DataTableToList<T>(result_dt);

            if (result_List.Count == 0)
            {
                return default(T);
            }

            return result_List[0];
        }
    }
}
