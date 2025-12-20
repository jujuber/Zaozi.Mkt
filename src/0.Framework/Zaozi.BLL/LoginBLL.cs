using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.LocalDict;
using Zaozi.Model.DataBaseModel;
using Zaozi.Utility;

namespace Zaozi.BLL
{
    public class LoginBLL : ILoginBLL
    {
        public override bool UserLogin(string LogUser, string LogPassWord)
        {
            try
            {
               // CheckKeyWords(LogUser, LogPassWord);

                emp empModel = ClientDict.GetData<emp>("empid='" + LogUser + "' and emp.useflag='Y'");

                if (empModel == null)
                {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                    throw new Exception("找不到对应的员工或者已经停用");
#pragma warning restore CA2201 // 不要引发保留的异常类型
                }


                if (empModel.password != DEncryptHelper.DESEncode(LogPassWord))
                {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                    throw new Exception("密码错误");
#pragma warning restore CA2201 // 不要引发保留的异常类型
                }

               // SystemData.LoginMode = "1";

              //  Login(empModel);
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // 再次引发以保留堆栈详细信息。
                throw ex;
#pragma warning restore CA2200 // 再次引发以保留堆栈详细信息。
            }
            return true;
        }
    }
}
