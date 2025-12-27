using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Model.BusinessModel
{
    public class UserBusiPower
    {

        /// <summary>
        /// 业务号
        /// </summary>		
        private string _busino;
        public string busino
        {
            get { return _busino; }
            set { _busino = value; }
        }

        private string _businame;

        /// <summary>
        /// 业务名称
        /// </summary>
        public string Businame
        {
            get { return _businame; }
            set { _businame = value; }
        }

        /// <summary>
        /// 归类代码 busicode.ctcode
        /// </summary>		
        private string _ctcode;
        public string ctcode
        {
            get { return _ctcode; }
            set { _ctcode = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

    }
}
