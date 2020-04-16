using CancerPortal.Services;
using CancerPortal.Services.Navigation;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CancerPortal.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
  
        protected readonly INavigationService NavigationService;

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewModelBase()
        {
            NavigationService = Startup.ServiceProvider?.GetService<INavigationService>();
          
        }
        public virtual void Subscribe() { }
        public virtual Task OnAppearing(object navigationData)
        {
            return Task.FromResult(false);
        }
     
        private bool _isUpdate = false;
        public bool IsUpdate { get { return _isUpdate; } set { _isUpdate = value; RaisePropertyChanged(() => IsUpdate); } }

        private bool _isRefresh = false;
        public bool IsRefresh { get { return _isRefresh; } set { _isRefresh = value; RaisePropertyChanged(() => IsRefresh); } }
    }

}