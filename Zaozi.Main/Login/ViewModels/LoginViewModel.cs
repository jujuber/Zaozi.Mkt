using Synyi.Framework.Wpf.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Main.Login.ViewModels
{
    /// <summary>
    /// 系统登录
    /// </summary>
    [Plugin(MainPluginIds.LoginView, "系统登录", "系统登录")]
    public class LoginViewModel : PluginViewModelBase
    {
        protected override Task DoOnNavigatedTo(NavigationContext context)
        {
            return Task.CompletedTask;
        }
    }
}
