using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaozi.Utility;
/// <summary>
/// 正则表达式类
/// </summary>
public class RegexHelper
{
    public static bool Validated(Control con)
    {
        if ((con.Text.Trim() == "") || con.Text == "")
        {
           // MessageHelper.ShowToolTip(con, "该项目不能为空！", "", ToolTipIconType.Information, ToolTipLocation.BottomCenter);
            con.Focus();
            return false;
        }

        return true;
    }

    public static bool Validated(List<Control> lstControl)
    {
        foreach (Control con in lstControl)
        {
            if ((con.Text.Trim() == "") || con.Text == "")
            {
               // MessageHelper.ShowToolTip(con, "该项目不能为空！", "", ToolTipIconType.Information, ToolTipLocation.BottomCenter);
                con.Focus();
                return false;
            }
        }
        return true;
    }

    #region 是否整型数字字符串
    /// <summary>
    /// 是否整型数字字符串
    /// </summary>
    /// <param name="strInput">输入字符串</param>
    /// <returns></returns>
    public static bool IsNumber(string strInput)
    {
        Regex RegInteger = new Regex("^[0-9]+$");
        return RegInteger.Match(strInput).Success;
    }
    #endregion

    #region 是否整型数字字符串(带附号)
    /// <summary>
    /// 是否整型数字字符串(带附号)
    /// </summary>
    /// <param name="strInput">输入字符串</param>
    /// <returns></returns>
    public static bool IsInteger(string strInput)
    {
        Regex RegInteger = new Regex("^[+-]?[0-9]+$");
        return RegInteger.Match(strInput).Success;
    }
    #endregion

    #region 是否数字或字母字符串
    /// <summary>
    /// 是否数字或字母字符串
    /// </summary>
    /// <param name="strInput">输入字符串</param>
    /// <returns></returns>
    public static bool IsNumOrLetter(string strInput)
    {
        Regex RegNumAndLetter = new Regex("^[A-Za-z0-9_]+$");
        return RegNumAndLetter.Match(strInput).Success;
    }
    #endregion

    #region 是否为纯字母字符串
    /// <summary>
    /// 是否为纯字母字符串
    /// </summary>
    /// <param name="strInput">输入字符串</param>
    /// <returns></returns>
    public static bool IsLetter(string strInput)
    {
        Regex RegNumAndLetter = new Regex("^[A-Za-z_]+$");
        return RegNumAndLetter.Match(strInput).Success;
    }
    #endregion

    #region 是否浮点数
    /// <summary>
    /// 是否是浮点数
    /// </summary>
    /// <param name="strInput">输入字符串</param>
    /// <returns></returns>
    public static bool IsDecimal(string strInput)
    {
        Regex RegDecimal = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        return RegDecimal.Match(strInput).Success;
    }
    #endregion

    #region 邮件地址验证
    /// <summary> 
    /// 邮件地址验证 
    /// </summary> 
    /// <param name="inputData">输入字符串</param> 
    /// <returns></returns> 
    public static bool IsEmail(string inputData)
    {
        Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.[\\w-]");
        return RegEmail.Match(inputData).Success;
    }
    #endregion

    #region 检测是否有中文字符
    /// <summary> 
    /// 检测是否有中文字符 
    /// </summary> 
    /// <param name="inputData"></param> 
    /// <returns></returns> 
    public static bool IsHasCHZN(string inputData)
    {
        Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        return RegCHZN.Match(inputData).Success;
    }
    #endregion

    #region 检测固定号码
    /// <summary>
    /// 检测固定号码
    /// </summary>
    /// <param name="strInput"></param>
    /// <returns></returns>
    public static bool IsTelephone(string strInput)
    {
        Regex RegTelephone = new Regex("^0[0-9]{11}$|^0[0-9]{10}$");
        return RegTelephone.Match(strInput).Success;
    }
    #endregion

    #region 检测手机号
    /// <summary>
    /// 检测手机号
    /// </summary>
    /// <param name="strInput"></param>
    /// <returns></returns>
    public static bool IsMobile(string strInput)
    {
        Regex RegMobile = new Regex("^13[0-9]{1}[0-9]{8}$|^15[0-9]{1}[0-9]{8}$|^18[0-9]{1}[0-9]{8}$");
        return RegMobile.Match(strInput).Success;
    }
    #endregion

    #region 检测是否固定号码或手机号
    /// <summary>
    /// 检测是否固定号码或手机号
    /// </summary>
    /// <param name="strInput"></param>
    /// <returns></returns>
    public static bool IsTelOrMobile(string strInput)
    {
        Regex RegInput = new Regex("^13[0-9]{1}[0-9]{8}$|^15[0-9]{1}[0-9]{8}$|^18[0-9]{1}[0-9]{8}$|^0[0-9]{11}$|^0[0-9]{10}$");
        return RegInput.Match(strInput).Success;
    }
    #endregion

    #region 是否为金额
    /// <summary>
    /// 是否为金额
    /// </summary>
    /// <param name="strInput">输入字符串</param>
    /// <returns></returns>
    public static bool IsMoeny(string strInput)
    {
        Regex RegMoeny = new Regex("^[0-9]+[.]?[0-9]+$|^[0-9]+$");
        return RegMoeny.Match(strInput).Success;
    }
    #endregion

    #region 检察是否都是数字,支持负数和小数
    /// <summary>
    /// 检察是否都是数字,支持负数和小数
    /// </summary>
    /// <param name="InPut"></param>
    /// <param name="AllowNegative"></param>
    /// <param name="AllowDecimal"></param>
    /// <returns></returns>
    public static bool IsNumeric(string InPut, bool AllowNegative, bool AllowDecimal)
    {
        if (InPut == null)
        {
            return false;
        }
        else
        {
            string pattern = "^(";
            if (AllowNegative == true)
                pattern += "-?";
            pattern += "\\d+)";
            if (AllowDecimal == true)
                pattern += "(\\.\\d+)";
            pattern += "$";
            return new Regex(pattern).IsMatch(InPut);
        }
    }
    #endregion

    #region 异常查询是否正确日期类型
    /// <summary>
    /// 是否为正确的日期函数
    /// </summary>
    /// <param name="Input"></param>
    /// <returns></returns>
    public static bool IsDateTime(string Input)
    {
        try
        {
            DateTime.Parse(Input);
        }
        catch
        {
            return false;
        }
        return true;
    }
    #endregion

    #region 是否是SQL语句
    /// <summary>
    /// 是否是SQL语句
    /// </summary>
    /// <param name="str">要检查的字串</param>
    /// <returns>bool</returns>
    public static bool IsSQL(string InPut)
    {
        //Regex reg = new Regex(@"\?|select%20|select\s+|insert%20|insert\s+|delete%20|delete\s+|count\(|drop%20|drop\s+|update%20|update\s+|declare%20|declare\s+", RegexOptions.IgnoreCase);
        Regex reg = new Regex(@"insert%20|insert\s+|delete%20|delete\s+|count\(|drop%20|drop\s+|update%20|update\s+|declare%20|declare\s+", RegexOptions.IgnoreCase);

        return reg.IsMatch(InPut);
    }
    #endregion

    #region 验证IP
    /// <summary>
    /// 判断IP
    /// </summary>
    /// <param name="addr">IP</param>
    /// <returns></returns>
    public static bool IsValidIP(string addr)
    {
        string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
        Regex check = new Regex(pattern);
        bool valid = false;
        if (addr == "")
        {
            valid = false;
        }
        else
        {
            valid = check.IsMatch(addr, 0);
        }
        return valid;
    }
    #endregion
}