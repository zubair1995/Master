
using CancerPortal.Services.Navigation;
using CancerPortal.View;
using CancerPortal.ViewModel;
using Master;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace CancerPortal
{
    public class Startup
    {

        public static IServiceProvider ServiceProvider { get; set; }
        public static void Init()
        {
          
            var a = Assembly.GetExecutingAssembly();
            var stream = a.GetManifestResourceStream("Master.appsettings.json");
     
            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                    c.AddJsonStream(stream);
                })
                .ConfigureServices((c, x) => ConfigureServices(c, x))
                .ConfigureLogging(l => l.AddConsole(o =>
                {
                    o.DisableColors = true;
                }))
                .Build();

            ServiceProvider = host.Services;
        }
        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            try
            {
                services.AddHttpClient();

                services.AddSingleton<MasterMainPage>();
                services.AddSingleton<MasterMainPageMaster>();
                services.AddSingleton<MasterMainViewModel>();
                services.AddSingleton<AboutViewModel>();
                services.AddSingleton<AboutViewModel>();
                services.AddSingleton<App>();

                services.AddSingleton<INavigationService, NavigationService>();
             
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
  

    }

}
