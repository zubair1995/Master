using CancerPortal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CancerPortal.Services.Navigation
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();
        Task RefressToken();
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();
        Task NavigateBackAsync();
        Task RemoveBackStackAsync();
        Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : ViewModelBase;
    }
}
