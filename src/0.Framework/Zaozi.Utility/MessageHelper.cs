using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaozi.Utility;
/// <summary>
/// 消息提示类
/// </summary>
public class MessageHelper
{
    #region 显示Tip提示信息
    /// <summary>
    /// 显示Tip提示信息
    /// </summary>
    /// <param name="ctl"></param>
    /// <param name="err"></param>
    /// <param name="title"></param>
    /// <param name="tooltiptype"></param>
    /// <param name="tooltiplocation"></param>
    //public static void ShowToolTip(Control ctl, string err, string title, ToolTipIconType tooltiptype, ToolTipLocation tooltiplocation)
    //{
        //using ToolTipController _ToolTip = new ToolTipController();
        //_ToolTip.ShowBeak = true;
        //_ToolTip.ShowShadow = true;
        //_ToolTip.Rounded = true;
        //_ToolTip.RoundRadius = 7;
        //_ToolTip.AutoPopDelay = 3000;
        //_ToolTip.IconSize = ToolTipIconSize.Small;
        //_ToolTip.Active = true;
        //ToolTipControllerShowEventArgs args = _ToolTip.CreateShowArgs();
        //args.IconType = tooltiptype;
        //args.Title = string.IsNullOrEmpty(title) ? "提示" : title;
        //args.ToolTip = err;
        //args.ToolTipLocation = tooltiplocation;
        ////_ToolTip.ShowHint(err, "提示", ctl, ToolTipLocation.BottomRight);
        //_ToolTip.ShowHint(args, ctl);
   // }
    #endregion

    #region 显示一般的提示信息
    /// <summary>
    /// 显示一般的提示信息
    /// </summary>
    /// <param name="message">提示信息</param>
    public static DialogResult ShowTips(string message)
    {
        return MessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    #endregion

    #region 显示警告信息
    /// <summary>
    /// 显示警告信息
    /// </summary>
    /// <param name="message">警告信息</param>
    public static DialogResult ShowWarning(string message)
    {
        return MessageBox.Show(message, "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    #endregion

    #region 显示错误信息
    /// <summary>
    /// 显示错误信息
    /// </summary>
    /// <param name="message">错误信息</param>
    public static DialogResult ShowError(string message)
    {
        return MessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    #endregion

    #region 显示错误信息,并记录日志
    /// <summary>
    /// 显示错误信息,并记录日志
    /// </summary>
    /// <param name="message">弹框提示错误信息</param>
    /// <param name="strLog">日志信息</param>
    /// <returns></returns>
    public static DialogResult ShowError(string message, object strLog)
    {
        //if (strLog != null)
        //{
        //    WpfFacade.GetLogger<MessageHelper>().LogError($"{message}\r\n{strLog}");
        //}
        return MessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    #endregion

    #region 显示询问用户信息，并显示错误标志
    /// <summary>
    /// 显示询问用户信息，并显示错误标志
    /// </summary>
    /// <param name="message">错误信息</param>
    public static DialogResult ShowYesNoAndError(string message)
    {
        return MessageBox.Show(message, "错误信息", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
    }
    #endregion

    #region 显示询问用户信息，并显示提示标志
    /// <summary>
    /// 显示询问用户信息，并显示提示标志
    /// </summary>
    /// <param name="message">错误信息</param>
    public static DialogResult ShowYesNoAndTips(string message)
    {
        return MessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    }
    #endregion

    #region 显示询问用户信息，并显示警告标志
    /// <summary>
    /// 显示询问用户信息，并显示警告标志
    /// </summary>
    /// <param name="message">警告信息</param>
    public static DialogResult ShowYesNoAndWarning(string message)
    {
        return MessageBox.Show(message, "警告信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    }
    #endregion

    #region 显示询问用户信息，并显示提示标志
    /// <summary>
    /// 显示询问用户信息，并显示提示标志
    /// </summary>
    /// <param name="message">错误信息</param>
    public static DialogResult ShowYesNoCancelAndTips(string message)
    {
        return MessageBox.Show(message, "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
    }
    #endregion

    #region 显示一个YesNo选择对话框
    /// <summary>
    /// 显示一个YesNo选择对话框
    /// </summary>
    /// <param name="prompt">对话框的选择内容提示信息</param>
    /// <returns>如果选择Yes则返回true，否则返回false</returns>
    public static bool ConfirmYesNo(string prompt)
    {
        return MessageBox.Show(prompt, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
    #endregion

    #region 显示一个YesNoCancel选择对话框
    /// <summary>
    /// 显示一个YesNoCancel选择对话框
    /// </summary>
    /// <param name="prompt">对话框的选择内容提示信息</param>
    /// <returns>返回选择结果的的DialogResult值</returns>
    public static DialogResult ConfirmYesNoCancel(string prompt)
    {
        return MessageBox.Show(prompt, "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    }
    #endregion


    #region 显示一个OKCancel选择对话框
    /// <summary>
    /// 显示一个OKCancel选择对话框
    /// </summary>
    /// <param name="prompt">对话框的选择内容提示信息</param>
    /// <returns>如果选择Yes则返回true，否则返回false</returns>
    public static bool ConfirmOKCancel(string prompt)
    {
        return MessageBox.Show(prompt, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
    }
    #endregion



}
