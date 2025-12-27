using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Model.BusinessModel
{
    public class SystemInfo
    {

        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName
        {
            get;
            set;
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP
        {
            get;
            set;
        }

        /// <summary>
        /// mac地址
        /// </summary>
        public string Mac { get; set; }


        /// <summary>
        /// 计算机名称
        /// </summary>
        public string ComputerName { get; set; }


        /// <summary>
        /// 版本
        /// </summary>
        public string Version
        {

            get;
            set;
        }

        /// <summary>
        /// 是否后台
        /// </summary>
        public string IsHT
        {

            get;

            set;
        }

        /// <summary>
        /// 是否演示环境
        /// </summary>
        public string IsDemoEnvironment
        {
            get;
            set;
        }

        /// <summary>
        /// 登入模式 1 多系统模式 2 单系统模式
        /// </summary>
        public string LoginSystemMode { get; set; }

        /// <summary>
        /// 护士站主班电脑设置
        /// </summary>
        public string NurinfoZbdn { get; set; }
        /// <summary>
        /// 消息提示框是否已创建
        /// </summary>
        public bool isShownurmsg { get; set; }
    }
}
