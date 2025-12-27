using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Model.DataBaseModel
{
    public class hissys
    {

        /// <summary>
        /// rdn
        /// </summary>		
        private int _rdn;
        public int rdn
        {
            get { return _rdn; }
            set { _rdn = value; }
        }
        /// <summary>
        /// sysp1
        /// </summary>		
        private int _sysp1;
        public int sysp1
        {
            get { return _sysp1; }
            set { _sysp1 = value; }
        }
        /// <summary>
        /// sysp2
        /// </summary>		
        private string _sysp2;
        public string sysp2
        {
            get { return _sysp2 == null ? "" : _sysp2.Trim(); }
            set { _sysp2 = value; }
        }
        /// <summary>
        /// sysp3
        /// </summary>		
        private DateTime? _sysp3;
        public DateTime? sysp3
        {
            get { return _sysp3; }
            set { _sysp3 = value; }
        }
        /// <summary>
        /// sysp4
        /// </summary>		
        private decimal? _sysp4;
        public decimal? sysp4
        {
            get { return _sysp4; }
            set { _sysp4 = value; }
        }
        /// <summary>
        /// remark
        /// </summary>		
        private string _remark;
        public string remark
        {
            get { return _remark == null ? "" : _remark.Trim(); }
            set { _remark = value; }
        }
        /// <summary>
        /// hoscode
        /// </summary>		
        private string _hoscode;
        public string hoscode
        {
            get { return _hoscode == null ? "" : _hoscode.Trim(); }
            set { _hoscode = value; }
        }

        /// <summary>
        /// 输入框类型
        /// </summary>
        public string inputtype { get; set; }

        /// <summary>
        /// 参数归类
        /// </summary>
        public string parametertype { get; set; }


        /// <summary>
        /// 是否上线必须
        /// </summary>
        public string onlineneed { get; set; }

        /// <summary>
        /// 使用菜单
        /// </summary>
        public string usemenu { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string explain { get; set; }

        /// <summary>
        /// 下拉标识
        /// </summary>
        public string dropitem { get; set; }


        /// <summary>
        /// 生效标志
        /// </summary>
        public string effectiveall { get; set; }

    }
}
