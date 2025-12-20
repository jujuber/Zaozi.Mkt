using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.BLL
{
    public abstract class ILoginBLL
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="LogUser"></param>
        /// <param name="LogPassWord"></param>
        /// <returns></returns>
        public abstract bool UserLogin(string LogUser, string LogPassWord);
    }
}
