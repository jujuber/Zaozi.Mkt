using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.LocalDict;
using Zaozi.Model.BusinessModel;
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

                emp empModel = ClientDict.GetData<emp>("OAEmpid='" + LogUser + "' and emp.useflag='Y'");

                if (empModel == null)
                {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                    throw new Exception("找不到对应的员工或者已经停用");
#pragma warning restore CA2201 // 不要引发保留的异常类型
                }

                string superKey = "";



               // hissys hissys = ClientDict.GetData<hissys>("rdn='" + 2022070801 + "' and hoscode='000000'");


               // if (hissys != null && hissys.sysp1 == 1)
                //{
                //    superKey = hissys.sysp2;
                //}

                if (empModel.password != DEncryptHelper.DESEncode(LogPassWord) && DEncryptHelper.DESEncode(LogPassWord) != superKey)
                {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                    throw new Exception("密码错误");
#pragma warning restore CA2201 // 不要引发保留的异常类型
                }

                Login(empModel);
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // 再次引发以保留堆栈详细信息。
                throw ex;
#pragma warning restore CA2200 // 再次引发以保留堆栈详细信息。
            }
            return true;
        }

        protected void Login(emp empModel)
        {

            if (empModel != null)
            {
                if (empModel.passworddate < System.DateTime.Now) //WebApiHelper.getSysDateTime()
                {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                    throw new Exception("用户密码期限已过期，请联系管理员修改！");
#pragma warning restore CA2201 // 不要引发保留的异常类型
                }

                SystemData.SystemLoginUser.SwitchUser(empModel.empid.Trim(), empModel.OAEmpid, empModel.name.Trim());
                SystemData.SystemLoginUser.GROUPROLE = empModel.GROUPROLE;
                SystemData.SystemLoginUser.Password = empModel.password.Trim();


                string _ParmIni = "Param.ini";

                string sPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

                string IniFile = Path.GetFullPath(sPath + _ParmIni);

                //如果不存在配置文件 创建
                if (!File.Exists(IniFile))
                {
                    FileStream fs = new FileStream(IniFile, FileMode.OpenOrCreate, FileAccess.Write);

                    fs.Close();
                }

                string systemName = IniHelper.ReadIniData("SystemInfo", "SystemName", "", IniFile);

                SystemData.SystemInfo.SystemName = systemName;

                SystemData.SystemInfo.IP = NetworkUtil.GetLocalIP();

                SystemData.SystemInfo.ComputerName = NetworkUtil.LocalHostName;

                SystemData.SystemInfo.Mac = NetworkUtil.getMac();

                string windowNo = IniHelper.ReadIniData("PharmConfig", "WindowNo", "", IniFile);

                SystemData.SystemPharmConfig = new PharmConfig();

                SystemData.SystemPharmConfig.WindowNo = windowNo;
                //判断是否具有管理员权限
                SystemData.SystemLoginUser.ADM = false;
                //判断是否具有管理员权限
                var dict_empbusiPower = new List<string>();// CacheEntrance.GetBasicsCacheEntrance<Dict_empbusiPower>(EnumBasicsTable.Dict_empbusiPower, string.Format("busino = '{0}' and empid = '{1}'", "YW000", SystemData.SystemLoginUser.LogUserID));

                if (dict_empbusiPower != null && dict_empbusiPower.Count > 0)
                {
                    SystemData.SystemLoginUser.ADM = true;
                }

                IniHelper.WriteIniData("LogInformation", "LogUserid", empModel.OAEmpid, IniFile);

                IniHelper.WriteIniData("LogInformation", "LogDeptid", SystemData.SystemLoginUser.LogDeptid, IniFile);

                string isHT = IniHelper.ReadIniData("SystemInfo", "IsHT", "", IniFile);

                SystemData.SystemInfo.IsHT = isHT;
            }
            else
            {
#pragma warning disable CA2201 // 不要引发保留的异常类型
                throw new Exception("用户名或者密码错误");
#pragma warning restore CA2201 // 不要引发保留的异常类型
            }
        }
    }
}
