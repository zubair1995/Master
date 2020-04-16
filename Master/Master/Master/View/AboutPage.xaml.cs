using CancerPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
namespace CancerPortal.View
{
    public partial class AboutPage : ContentPage
    {
        private AboutViewModel viewModel = null;
        public AboutPage()
        {
            try
            {
                InitializeComponent();
                viewModel = Startup.ServiceProvider?.GetService<AboutViewModel>();
                BindingContext = viewModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
