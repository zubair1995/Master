using CancerPortal;
using CancerPortal.Services.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitNavigation();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private Task InitNavigation()
        {
            var navigationService = Startup.ServiceProvider?.GetService<INavigationService>();
            return navigationService.InitializeAsync();
        }
    }
}
