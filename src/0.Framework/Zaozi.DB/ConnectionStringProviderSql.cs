using Synyi.Framework.Data;
using Synyi.Framework.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.DB
{
    public class ConnectionStringProviderSql : ConnectionStringProviderBase
    {
        protected override string DoGetConnectionString(string name)
        {
            return "";
        }

        protected override DatabaseType DoGetDatabaseType(string name)
        {
            return DatabaseType.MSSQL;
        }
    }
}
