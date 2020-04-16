using CancerPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CancerPortal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMainPageMaster : ContentPage
    {
       
        public ListView ListView;
        public Image Image;
        public MasterMainPageMaster()
        {
            try
            {
                InitializeComponent();
             


            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}