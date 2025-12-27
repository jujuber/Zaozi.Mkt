using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.LocalDict;
using Zaozi.Model.DataBaseModel;

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
        public static void CheckKeyWords(string LogUser, string LogPassWord)
        {
            //关键字
            hissys hissys = ClientDict.GetData<hissys>("rdn='" + 20201119 + "' and hoscode='000000'");

            if (hissys == null)
            {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                throw new Exception("数据库屏蔽关键字未设置rdn为" + 20201119);
#pragma warning restore CA2201 // 不要引发保留的异常类型
            }

            //拆分关键字
            string[] keyWords = hissys.sysp2.Split('|');

            if (keyWords != null)
            {
                foreach (string key in keyWords)
                {
                    if (LogUser.Contains(key))
                    {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                        throw new Exception("用户名含有非法关键字");
#pragma warning restore CA2201 // 不要引发保留的异常类型

                    }
                }

                foreach (string key in keyWords)
                {
                    if (LogPassWord.Contains(key))
                    {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                        throw new Exception("密码含有非法关键字");
#pragma warning restore CA2201 // 不要引发保留的异常类型

                    }
                }
            }
        }
    }
}
