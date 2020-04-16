
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CancerPortal.View;
using CancerPortal.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using CancerPortal.ViewModel;

namespace CancerPortal.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {

        protected Application CurrentApplication => Application.Current;
        public ViewModelBase PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as CustomNavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }
        public   Task InitializeAsync()
        {
            try
            {
               
                    
                  
                    return NavigateToAsync<MasterMainViewModel>();
               
            }
            catch (Exception ex)
            {

                throw;
            }
    }


        public async Task NavigateBackAsync()
        {

            if (CurrentApplication.MainPage is MasterMainPage)
            {
                var mainPage = CurrentApplication.MainPage as MasterMainPage;
                await mainPage.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }

        }
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }
        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationPage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }
            return Task.FromResult(true);
        }
        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationPage;


            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }
        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            try
            {
                Page page = CreatePage(viewModelType, parameter);
                if (page is MasterMainPage)
                {
                    Application.Current.MainPage = new CustomNavigationPage(page);
                }
                else
                {
                    var navigationPage = Application.Current.MainPage as CustomNavigationPage;
                    if (navigationPage != null)
                    {
                     

                        //var masterMainPage = Startup.ServiceProvider?.GetService<MasterMainPage>();
                        //masterMainPage.Detail = new NavigationPage(new MileagePage());
                        await navigationPage.PushAsync(page);

                    }
                    else
                    {
                        Application.Current.MainPage = new CustomNavigationPage(page);
                    }
                }
                await (page.BindingContext as ViewModelBase).OnAppearing(parameter);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            string viewName;
            string helperName = "CancerPortal.View";
            viewName = viewModelType.FullName;
            StringBuilder sb = new StringBuilder(viewName);
            sb.Replace("Model", string.Empty);
            sb.Replace("View", "Page");
            sb.Replace("CancerPortal.Page", string.Empty);
            sb.Insert(0, helperName);
            viewName = sb.ToString();
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }
            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }


        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Startup.ServiceProvider.GetRequiredService(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }
    }
}
