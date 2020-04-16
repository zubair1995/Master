using CancerPortal.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CancerPortal.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel()

        {
            
        }
        public override async Task OnAppearing(object navigationData)
        {
            //check on this view the drawer not opning becaouse it not becomming child of master page
          

           
        }
    }
}
