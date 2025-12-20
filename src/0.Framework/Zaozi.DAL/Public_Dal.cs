using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.DB.DBUtility.Sql;

namespace Zaozi.DAL
{
    public class Public_Dal
    {
        private static Public_Dal instance = null;
        public static Public_Dal Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Public_Dal();
                }

                return instance;
            }
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strTableName, string strWhere, string dbtype = "his")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) as cu from {0}", strTableName);
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Exists(dbtype, strSql.ToString(), null);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strTableName, string strWhere, string dbtype = "his")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.AppendFormat(" FROM {0} (nolock) ", strTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(dbtype, strSql.ToString()).Tables[0];
        }
    }
}
