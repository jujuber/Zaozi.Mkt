using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Model.DataBaseModel
{
    public class emp
    {

        /// <summary>
        /// empid
        /// </summary>		
        private string _empid;
        public string empid
        {
            get { return _empid == null ? "" : _empid.Trim().ToLower(); }
            set { _empid = value; }
        }
        /// <summary>
        /// name
        /// </summary>		
        private string _name;
        public string name
        {
            get { return _name == null ? "" : _name.Trim(); }
            set { _name = value; }
        }
        /// <summary>
        /// 获取或者设置指导医生
        /// </summary>
        private string _zdys;
        public string zdys
        {
            get { return _zdys == null ? "" : _zdys.Trim(); }
            set { _zdys = value; }
        }
        /// <summary>
        /// password
        /// </summary>		
        private string _password;
        public string password
        {
            get { return _password == null ? "" : _password.Trim(); }
            set { _password = value; }
        }
        /// <summary>
        /// sex
        /// </summary>		
        private string _sex;
        public string sex
        {
            get { return _sex == null ? "" : _sex.Trim(); }
            set { _sex = value; }
        }
        /// <summary>
        /// deptid
        /// </summary>		
        private string _deptid;
        public string deptid
        {
            get { return _deptid == null ? "" : _deptid.Trim(); }
            set { _deptid = value; }
        }
        /// <summary>
        /// status
        /// </summary>		
        private string _status;
        public string status
        {
            get { return _status == null ? "" : _status.Trim(); }
            set { _status = value; }
        }


        /// <summary>
        /// title
        /// </summary>		
        private string _title;
        public string title
        {
            get { return _title == null ? "" : _title.Trim(); }
            set { _title = value; }
        }
        /// <summary>
        /// domain
        /// </summary>		
        private string _domain;
        public string domain
        {
            get { return _domain == null ? "" : _domain.Trim(); }
            set { _domain = value; }
        }
        /// <summary>
        /// dpower
        /// </summary>		
        private string _dpower;
        public string dpower
        {
            get { return _dpower == null ? "" : _dpower.Trim(); }
            set { _dpower = value; }
        }
        /// <summary>
        /// apower
        /// </summary>		
        private string _apower;
        public string apower
        {
            get { return _apower == null ? "" : _apower.Trim(); }
            set { _apower = value; }
        }
        /// <summary>
        /// opower
        /// </summary>		
        private string _opower;
        public string opower
        {
            get { return _opower == null ? "" : _opower.Trim(); }
            set { _opower = value; }
        }
        /// <summary>
        /// useflag
        /// </summary>		
        private string _useflag;
        public string useflag
        {
            get { return _useflag == null ? "" : _useflag.Trim(); }
            set { _useflag = value; }
        }
        /// <summary>
        /// birthday
        /// </summary>		
        private DateTime _birthday;
        public DateTime birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        /// <summary>
        /// npower
        /// </summary>		
        private string _npower;
        public string npower
        {
            get { return _npower == null ? "" : _npower.Trim(); }
            set { _npower = value; }
        }
        /// <summary>
        /// opflag
        /// </summary>		
        private string _opflag;
        public string opflag
        {
            get { return _opflag == null ? "" : _opflag.Trim(); }
            set { _opflag = value; }
        }
        /// <summary>
        /// regfee
        /// </summary>		
        private decimal _regfee;
        public decimal regfee
        {
            get { return _regfee; }
            set { _regfee = value; }
        }
        /// <summary>
        /// amtotal
        /// </summary>		
        private decimal _amtotal;
        public decimal amtotal
        {
            get { return _amtotal; }
            set { _amtotal = value; }
        }
        /// <summary>
        /// amadd
        /// </summary>		
        private decimal _amadd;
        public decimal amadd
        {
            get { return _amadd; }
            set { _amadd = value; }
        }
        /// <summary>
        /// amappoint
        /// </summary>		
        private decimal _amappoint;
        public decimal amappoint
        {
            get { return _amappoint; }
            set { _amappoint = value; }
        }
        /// <summary>
        /// pmtotal
        /// </summary>		
        private decimal _pmtotal;
        public decimal pmtotal
        {
            get { return _pmtotal; }
            set { _pmtotal = value; }
        }
        /// <summary>
        /// pmadd
        /// </summary>		
        private decimal _pmadd;
        public decimal pmadd
        {
            get { return _pmadd; }
            set { _pmadd = value; }
        }
        /// <summary>
        /// pmappoint
        /// </summary>		
        private decimal _pmappoint;
        public decimal pmappoint
        {
            get { return _pmappoint; }
            set { _pmappoint = value; }
        }
        /// <summary>
        /// nttotal
        /// </summary>		
        private decimal _nttotal;
        public decimal nttotal
        {
            get { return _nttotal; }
            set { _nttotal = value; }
        }
        /// <summary>
        /// ntadd
        /// </summary>		
        private decimal _ntadd;
        public decimal ntadd
        {
            get { return _ntadd; }
            set { _ntadd = value; }
        }
        /// <summary>
        /// ntappoint
        /// </summary>		
        private decimal _ntappoint;
        public decimal ntappoint
        {
            get { return _ntappoint; }
            set { _ntappoint = value; }
        }
        /// <summary>
        /// py
        /// </summary>		
        private string _py;
        public string py
        {
            get { return _py == null ? "" : _py.Trim(); }
            set { _py = value; }
        }
        /// <summary>
        /// spareid
        /// </summary>		
        private string _spareid;
        public string spareid
        {
            get { return _spareid == null ? "" : _spareid.Trim(); }
            set { _spareid = value; }
        }
        /// <summary>
        /// apass
        /// </summary>		
        private string _apass;
        public string apass
        {
            get { return _apass == null ? "" : _apass.Trim(); }
            set { _apass = value; }
        }
        /// <summary>
        /// newpassword
        /// </summary>		
        private string _newpassword;
        public string newpassword
        {
            get { return _newpassword == null ? "" : _newpassword.Trim(); }
            set { _newpassword = value; }
        }
        /// <summary>
        /// newdo
        /// </summary>		
        private string _newdo;
        public string newdo
        {
            get { return _newdo == null ? "" : _newdo.Trim(); }
            set { _newdo = value; }
        }
        /// <summary>
        /// icount
        /// </summary>		
        private int _icount;
        public int icount
        {
            get { return _icount; }
            set { _icount = value; }
        }
        /// <summary>
        /// zc
        /// </summary>		
        private string _zc;
        public string zc
        {
            get { return _zc == null ? "" : _zc.Trim(); }
            set { _zc = value; }
        }
        /// <summary>
        /// medgroup
        /// </summary>		
        private string _medgroup;
        public string medgroup
        {
            get { return _medgroup == null ? "" : _medgroup.Trim(); }
            set { _medgroup = value; }
        }
        /// <summary>
        /// regfcode
        /// </summary>		
        private string _regfcode;
        public string regfcode
        {
            get { return _regfcode == null ? "" : _regfcode.Trim(); }
            set { _regfcode = value; }
        }
        /// <summary>
        /// workAuth
        /// </summary>		
        private string _workauth;
        public string workAuth
        {
            get { return _workauth == null ? "" : _workauth.Trim(); }
            set { _workauth = value; }
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
        /// hostrandt
        /// </summary>		
        private DateTime _hostrandt;
        public DateTime hostrandt
        {
            get { return _hostrandt; }
            set { _hostrandt = value; }
        }
        /// <summary>
        /// hostranflag
        /// </summary>		
        private string _hostranflag;
        public string hostranflag
        {
            get { return _hostranflag == null ? "" : _hostranflag.Trim(); }
            set { _hostranflag = value; }
        }
        /// <summary>
        /// cacertno
        /// </summary>		
        private string _cacertno;
        public string cacertno
        {
            get { return _cacertno == null ? "" : _cacertno.Trim(); }
            set { _cacertno = value; }
        }
        /// <summary>
        /// 用于控制用户菜单权限 
        /// </summary>		
        private int _kpower;
        public int Kpower
        {
            get { return _kpower; }
            set { _kpower = value; }
        }
        /// <summary>
        /// passworddate
        /// </summary>		
        private DateTime _passworddate;
        public DateTime passworddate
        {
            get { return _passworddate; }
            set { _passworddate = value; }
        }
        /// <summary>
        /// deptidmz
        /// </summary>		
        private string _deptidmz;
        public string deptidmz
        {
            get { return _deptidmz == null ? "" : _deptidmz.Trim(); }
            set { _deptidmz = value; }
        }
        /// <summary>
        /// qcpower
        /// </summary>		
        private string _qcpower;
        public string qcpower
        {
            get { return _qcpower == null ? "" : _qcpower.Trim(); }
            set { _qcpower = value; }
        }
        /// <summary>
        /// ppower
        /// </summary>		
        private string _ppower;
        public string ppower
        {
            get { return _ppower == null ? "" : _ppower.Trim(); }
            set { _ppower = value; }
        }
        /// <summary>
        /// remark1
        /// </summary>		
        private string _remark1;
        public string remark1
        {
            get { return _remark1 == null ? "" : _remark1.Trim(); }
            set { _remark1 = value; }
        }
        /// <summary>
        /// remark2
        /// </summary>		
        private string _remark2;
        public string remark2
        {
            get { return _remark2 == null ? "" : _remark2.Trim(); }
            set { _remark2 = value; }
        }
        /// <summary>
        /// insudrcode
        /// </summary>		
        private string _insudrcode;
        public string insudrcode
        {
            get { return _insudrcode == null ? "" : _insudrcode.Trim(); }
            set { _insudrcode = value; }
        }
        /// <summary>
        /// UserTypeCode
        /// </summary>		
        private string _usertypecode;
        public string UserTypeCode
        {
            get { return _usertypecode == null ? "" : _usertypecode.Trim(); }
            set { _usertypecode = value; }
        }
        /// <summary>
        /// EnterTime
        /// </summary>		
        private DateTime _entertime;
        public DateTime EnterTime
        {
            get { return _entertime; }
            set { _entertime = value; }
        }
        /// <summary>
        /// limits
        /// </summary>		
        private int _limits;
        public int limits
        {
            get { return _limits; }
            set { _limits = value; }
        }
        /// <summary>
        /// regflag
        /// </summary>		
        private string _regflag;
        public string regflag
        {
            get { return _regflag == null ? "" : _regflag.Trim(); }
            set { _regflag = value; }
        }
        /// <summary>
        /// GROUPROLE
        /// </summary>		
        private string _grouprole;
        public string GROUPROLE
        {
            get { return _grouprole == null ? "" : _grouprole.Trim(); }
            set { _grouprole = value; }
        }
        /// <summary>
        /// temperatureSheet
        /// </summary>		
        private string _temperaturesheet;
        public string temperatureSheet
        {
            get { return _temperaturesheet == null ? "" : _temperaturesheet.Trim(); }
            set { _temperaturesheet = value; }
        }
        /// <summary>
        /// pcid
        /// </summary>		
        private string _pcid;
        public string pcid
        {
            get { return _pcid == null ? "" : _pcid.Trim(); }
            set { _pcid = value; }
        }

        private string _certificateNo;
        public string certificateNo
        {
            get { return _certificateNo == null ? "" : _certificateNo.Trim(); }
            set { _certificateNo = value; }
        }

        /// <summary>
        /// 是否是组长
        /// </summary>
        private string _isMedgroup;
        public string isMedgroup
        {
            get { return _isMedgroup == null ? "" : _isMedgroup.Trim(); }
            set { _isMedgroup = value; }
        }

        /// <summary>
        /// OA员工编号
        /// </summary>
        public string OAEmpid
        {

            get;
            set;
        }

        public string isOurHos { get; set; }


        /// <summary>
        /// 使用开始日期
        /// </summary>
        public DateTime UseSdate { get; set; }

        /// <summary>
        /// 医保医师代码
        /// </summary>
        public string ybysdm { get; set; }

        /// <summary>
        /// 执业地点
        /// </summary>
        public string zydd { get; set; }

        /// <summary>
        /// 来院时间
        /// </summary>
        public DateTime lysj { get; set; }

        /// <summary>
        /// 医保护士代码
        /// </summary>
        public string ybhsdm { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        public string UseTime { get; set; }
    }
}
