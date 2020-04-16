using CancerPortal.Services.Navigation;
using CancerPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace CancerPortal.View
{
    [Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
    public partial class MasterMainPage : MasterDetailPage
    {
        private bool _isFirstRun = false;
        private MasterMainViewModel ViewModel = null;
        public MasterMainPage()
        {
            try
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);
                masterPage.listView.ItemSelected += OnItemSelected;
                masterPage.MasterBackButton.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        IsPresented = false;
                    }),
                    NumberOfTapsRequired = 1,
                });
              
                
                if (Device.RuntimePlatform == Device.UWP)
                {
                    MasterBehavior = MasterBehavior.Popover;
                }
                BindingContext = ViewModel = Startup.ServiceProvider?.GetService<MasterMainViewModel>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
         
                var item = e.SelectedItem as MasterMainPageMasterMenuItem;
                if (item != null)
                {
                    //like that i navigate in all pages now check drawer not opening when i navigate with viewmoel
                    ViewModel.SelectedItemCommand(item);
                    masterPage.listView.SelectedItem = null;
                    IsPresented = false;
                }
                this.IsPresented = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           
         
        }
    }
}