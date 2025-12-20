using Synyi.Framework.Wpf.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaozi.Main.Navigate.ViewModels
{
    [Plugin(MainPluginIds.NavigateView,"导航界面", "导航界面")]
    public class NavigateViewModel : PluginViewModelBase
    {
        protected override Task DoOnNavigatedTo(NavigationContext context)
        {
            return Task.CompletedTask;
        }
    }
}
