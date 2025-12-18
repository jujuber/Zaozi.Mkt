using Microsoft.Extensions.Hosting;
using Synyi.Framework.Data.Hosting;
using Synyi.Framework.Wpf.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaozi.DB;
using Zaozi.Main;

namespace Zaozi.Pc
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(p => p
                 .AddBootPluginId(MainPluginIds.LoginView)
                 .AddBootPluginWindowState(Synyi.Framework.Wpf.Controls.NavigateWindowState.SizeToContent)
                 .AddBootUserSystem(new Synyi.Framework.Wpf.Security.UserSystem("0", "枣子系统", "枣子系统"))
                 )
               .ConfigureWpf<ModuleCatalog>()
               .ConfigureData<ConnectionStringProviderSql>()
               .Build();

            host.Run();
        }
    }
}
