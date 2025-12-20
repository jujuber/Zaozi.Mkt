using Synyi.Framework.Wpf;
using Synyi.Framework.Wpf.Controls;
using Synyi.Framework.Wpf.Mvvm;
using Synyi.Framework.Wpf.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.BLL;

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
            LoginBll = new LoginBLL();
            return Task.CompletedTask;
        }
        private ILoginBLL LoginBll;
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginViewModel()
        {
            this.CloseCommand = new ActionCommand(this.ExecuteCloseCommand);
            this.LoginCommand = new ActionCommand(this.ExecuteLoginCommand);
        }

        public ActionCommand CloseCommand { get; }

        private void ExecuteCloseCommand()
        {
            this.Finish(true, null);
        }

        public ActionCommand LoginCommand { get; }

        private void ExecuteLoginCommand()
        {
            var result = LoginBll.UserLogin(UserName, Password);
            WpfFacade.Plugin.Navigate(Regions.MainRegion, MainPluginIds.NavigateView,
                NavigationParameters.Create().SetWindowState(NavigateWindowState.Maximized).SetKeepAlive(true)
                );
        }
    }
}
