using CancerPortal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using CancerPortal.View;

namespace CancerPortal.ViewModel
{
   public class MasterMainViewModel : ViewModelBase
    {
 
        private bool _isFirstRun = false;
        public  MasterMainViewModel()
        {
         
        }
        public override async Task OnAppearing(object navigationData)
        {
            try
            {
         
         
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async void SelectedItemCommand(MasterMainPageMasterMenuItem item)
        {
            try
            {


                if (item.Title != null)
                {
                   
                     if (item.Title == "AboutLabel")
                    {
                        await NavigationService.NavigateToAsync<AboutViewModel>();
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }


        private bool _isRunning = false;
        public bool IsRunning { get { return _isRunning; } set { _isRunning = value; RaisePropertyChanged(() => IsRunning); } }
    }
}
