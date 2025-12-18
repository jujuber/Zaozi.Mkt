using Synyi.Framework.Wpf.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaozi.Main.Login.ViewModels;
using Zaozi.Main.Login.Views;

namespace Zaozi.Main
{
    public class MainWpfModule : WpfModuleBase
    {
        protected override void RegisterPluginViewModel(PluginRegistrar registrar)
        {
            registrar.Register<LoginView, LoginViewModel>();
        }
    }
}
