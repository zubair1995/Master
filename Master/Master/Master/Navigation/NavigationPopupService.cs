using CancerPortal.Services.Navigation;
using CancerPortal.View;
using CancerPortal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace CancerPortal.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {
        public Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : ViewModelBase => NavigateToPopupAsync<TViewModel>(null, animate);

        public async Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : ViewModelBase
        {

        }
        public async Task RefressToken()
        {
        }
    }
}
