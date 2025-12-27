using Synyi.Framework.Kernel;
using Synyi.Framework.Wpf;
using Synyi.Framework.Wpf.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Model.BusinessModel
{
    public class UserInfo
    {
        /// <summary>
        /// 切换用户
        /// </summary>
        /// <param name="logUserID">用户代码</param>
        /// <param name="oAEmpID">工号</param>
        /// <param name="logUserName">登录名</param>
        public void SwitchUser(string logUserID, string oAEmpID, string logUserName)
        {
            this.LogUserID = logUserID;
            this.OAEmpID = oAEmpID;
            this.LogUserName = logUserName;

            if (WpfFacade.Context.Account != null && WpfFacade.Context.Account.Id == logUserID && WpfFacade.Context.Account.AccessToken.IsNullOrWhiteSpace() == false)
            {
                //从outp诊间预约进入的患者不能切换账户
                //var userCode = WpfFacade.Context.Account.Code;
                //var userName = WpfFacade.Context.Account.Name;
            }
            else
            {
                WpfFacade.Context.SwitchAccount(
                new WpfAccount(
                this.LogUserID,
                this.OAEmpID,
                this.LogUserName)
                {
                    //先固定一个token
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc3lueWkuY29tL3NlY3VyaXR5L2FjY291bnQvY2xhaW1zL2lkIjoiYWRtaW4iLCJodHRwOi8vc3lueWkuY29tL3NlY3VyaXR5L2FjY291bnQvY2xhaW1zL2NvZGUiOiJhZG1pbiIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvbmFtZSI6Iui2hee6p-euoeeQhuWRmCIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvaWQiOiJOWDAwMSIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvbmFtZSI6IuWGheS5oeWOv-WMu-WFseS9k-WnlOWRmOS8miIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvZGlzdHJpY3QvaWQiOiJOWDAwMDExMSIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvZGlzdHJpY3QvbmFtZSI6IuajruS6v-aZuuaFp-WMu-mZoiIsIm5iZiI6MTY3NjI3OTY4MywiZXhwIjoxNjc2MzY2MDgzLCJpc3MiOiJzeW55aS5jb20iLCJhdWQiOiJzeW55aS5jb20ifQ.4SNAzpdZP3hhEkQtub-EdAtH5pCvgDHYwd4ycREeiIU"
                });
            }
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        /// <param name="logUserID">用户代码</param>
        /// <param name="oAEmpID">工号</param>
        /// <param name="logUserName">登录名</param>
        /// <param name="orgId">院区代码</param>
        /// <param name="orgName">院区名称</param>
        public void SwitchUser(string logUserID, string oAEmpID, string logUserName, string orgId, string orgName)
        {
            this.LogUserID = logUserID;
            this.OAEmpID = oAEmpID;
            this.LogUserName = logUserName;

            if (WpfFacade.Context.Account != null && WpfFacade.Context.Account.Id == logUserID && WpfFacade.Context.Account.AccessToken.IsNullOrWhiteSpace() == false)
            {
                //从outp诊间预约进入的患者不能切换账户
                //var userCode = WpfFacade.Context.Account.Code;
                //var userName = WpfFacade.Context.Account.Name;
            }
            else
            {
                WpfFacade.Context.SwitchAccount(
                new WpfAccount(
                    orgId,
                    orgName,
                    this.LogUserID,
                    this.OAEmpID,
                    this.LogUserName)
                {
                    //先固定一个token
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc3lueWkuY29tL3NlY3VyaXR5L2FjY291bnQvY2xhaW1zL2lkIjoiYWRtaW4iLCJodHRwOi8vc3lueWkuY29tL3NlY3VyaXR5L2FjY291bnQvY2xhaW1zL2NvZGUiOiJhZG1pbiIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvbmFtZSI6Iui2hee6p-euoeeQhuWRmCIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvaWQiOiJOWDAwMSIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvbmFtZSI6IuWGheS5oeWOv-WMu-WFseS9k-WnlOWRmOS8miIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvZGlzdHJpY3QvaWQiOiJOWDAwMDExMSIsImh0dHA6Ly9zeW55aS5jb20vc2VjdXJpdHkvYWNjb3VudC9jbGFpbXMvaG9zcGl0YWwvZGlzdHJpY3QvbmFtZSI6IuajruS6v-aZuuaFp-WMu-mZoiIsIm5iZiI6MTY3NjI3OTY4MywiZXhwIjoxNjc2MzY2MDgzLCJpc3MiOiJzeW55aS5jb20iLCJhdWQiOiJzeW55aS5jb20ifQ.4SNAzpdZP3hhEkQtub-EdAtH5pCvgDHYwd4ycREeiIU"
                });
            }
        }

        /// <summary>
        /// 获取声明
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>返回声明</returns>
        private string GetClaim(string type)
        {
            var result = WpfFacade.Context.Account.GetClaim(type)?.Value;
            return result;
        }
        /// <summary>
        /// 设置声明
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="value">值</param>
        private void SetClaim(string type, string value)
        {
            WpfFacade.Context.Account.SetClaim(type, value);
        }
        /// <summary>
        /// 登陆科室
        /// </summary>
        private string logDeptid;
        /// <summary>
        /// 登陆科室
        /// </summary>
        public string LogDeptid
        {
            get { return this.logDeptid; }
            set
            {
                this.logDeptid = value;
                this.SetClaim(nameof(LogDeptid), value);
            }
        }
        /// <summary>
        /// 登陆科室名称
        /// </summary>
        private string logDeptName;
        /// <summary>
        /// 登陆科室名称
        /// </summary>
        public string LogDeptName
        {
            get { return this.logDeptName; }
            set
            {
                this.logDeptName = value;
                this.SetClaim(nameof(LogDeptName), value);
            }
        }
        /// <summary>
        /// 医生组号
        /// </summary>
        private string logMedGroupID;
        /// <summary>
        /// 医生组号
        /// </summary>
        public string LogMedGroupID
        {
            get { return this.logMedGroupID; }
            set
            {
                this.logMedGroupID = value;
                this.SetClaim(nameof(LogMedGroupID), value);
            }
        }
        /// <summary>
        /// 权限
        /// </summary>
        private string logNpower;
        /// <summary>
        /// 权限
        /// </summary>
        public string LogNpower
        {
            get { return this.logNpower; }
            set
            {
                this.logNpower = value;
                this.SetClaim(nameof(LogNpower), value);
            }
        }
        /// <summary>
        /// 管理员权限
        /// </summary>
        private bool adm;
        /// <summary>
        /// 管理员权限
        /// </summary>
        public bool ADM
        {
            get { return this.adm; }
            set
            {
                this.adm = value;
                this.SetClaim(nameof(ADM), value.ToString());
            }
        }
        /// <summary>
        /// 手术权限
        /// </summary>
        private string logOpower;
        /// <summary>
        /// 手术权限
        /// </summary>
        public string LogOpower
        {
            get { return this.logOpower; }
            set
            {
                this.logOpower = value;
                this.SetClaim(nameof(LogOpower), value);
            }
        }
        /// <summary>
        /// 角色
        /// </summary>
        private string logRole;
        /// <summary>
        /// 角色
        /// </summary>
        public string LogRole
        {
            get { return this.logRole; }
            set
            {
                this.LogRole = value;
                this.SetClaim(nameof(LogRole), value);
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string LogUserName { get; private set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string LogUserID { get; private set; }
        /// <summary>
        /// 员工类别
        /// </summary>
        private string domain;
        /// <summary>
        /// 员工类别，1主任医生，2副主任医生 3 主治医生 4实习生/研究生
        /// </summary>
        public string Domain
        {
            get { return this.domain; }
            set
            {
                this.domain = value;
                this.SetClaim(nameof(Domain), value);
            }
        }
        /// <summary>
        /// GROUPROLEID
        /// </summary>
        private string groupRole;
        /// <summary>
        /// GROUPROLEID
        /// </summary>
        public string GROUPROLE
        {
            get { return this.groupRole; }
            set
            {
                this.groupRole = value;
                this.SetClaim(nameof(GROUPROLE), value);
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.SetClaim(nameof(Password), value);
            }
        }

        /// <summary>
        /// 打开的系统
        /// </summary>
        private string openExe;
        /// <summary>
        /// 打开的系统
        /// </summary>
        public string OPENEXE
        {
            get { return this.openExe; }
            set
            {
                this.openExe = value;
                this.SetClaim(nameof(OPENEXE), value);
            }
        }
        /// <summary>
        /// 打开的系统名称
        /// </summary>
        private string openExeName;
        /// <summary>
        /// 打开的系统名称
        /// </summary>
        public string OPENEXENAME
        {
            get { return this.openExeName; }
            set
            {
                this.openExeName = value;
                this.SetClaim(nameof(OPENEXENAME), value);
            }
        }
        /// <summary>
        /// 单点登入打开的系统编号
        /// </summary>
        private string _sysid;
        /// <summary>
        /// 单点登入打开的系统编号
        /// </summary>
        public string sysid
        {
            get { return this._sysid; }
            set
            {
                this._sysid = value;
                this.SetClaim(nameof(sysid), value);
            }
        }
        /// <summary>
        /// 公卫免登录token
        /// </summary>
        private string publicSecurity_Token;
        /// <summary>
        /// 公卫免登录token
        /// </summary>
        public string strPublicSecurity_Token
        {
            get { return this.publicSecurity_Token; }
            set
            {
                this.publicSecurity_Token = value;
                this.SetClaim(nameof(strPublicSecurity_Token), value);
            }
        }
        /// <summary>
        /// 登录人身份证
        /// </summary>
        private string logPcid;
        /// <summary>
        /// 登录人身份证
        /// </summary>
        public string LogPcid
        {
            get { return this.logPcid; }
            set
            {
                this.logPcid = value;
                this.SetClaim(nameof(LogPcid), value);
            }
        }
        /// <summary>
        /// 操作员OA工号
        /// </summary>
        public string OAEmpID { get; private set; }

        private string emrWriteLevel;

        public string EMRWriteLevel
        {
            get { return this.emrWriteLevel; }
            set
            {
                this.emrWriteLevel = value;
                this.SetClaim(nameof(EMRWriteLevel), value);
            }
        }

        private string yQCode;

        public string YQCode
        {
            get { return this.yQCode; }
            set
            {
                this.yQCode = value;
                this.SetClaim(nameof(YQCode), value);
            }
        }

        private string pwd;
        /// <summary>
        /// 单点登入MD5加密的密码
        /// </summary>
        public string PWD
        {
            get { return this.pwd; }
            set
            {
                this.pwd = value;
                this.SetClaim(nameof(PWD), value);
            }
        }

        /// <summary>
        /// 业务权限列表
        /// </summary>
        public List<UserBusiPower> UserBusiPowerList { get; set; }

        public string AccessToken { get; set; }

        public string OrgId { get; set; }
    }
}
