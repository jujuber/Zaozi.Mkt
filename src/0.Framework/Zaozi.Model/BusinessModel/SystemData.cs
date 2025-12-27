using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Model.BusinessModel
{
    public class SystemData
    {
        private static UserInfo _LoginUser = new UserInfo();

        private static SystemInfo _SystemInfo = new SystemInfo();

        public static UserInfo SystemLoginUser
        {
            get { return _LoginUser; }
        }

        /// <summary>
        /// 系统信息
        /// </summary>
        public static SystemInfo SystemInfo
        {

            get { return _SystemInfo; }
            set { _SystemInfo = value; }
        }

        public static PharmConfig SystemPharmConfig { get; set; }
    }
}
