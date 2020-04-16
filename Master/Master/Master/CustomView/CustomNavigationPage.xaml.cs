using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CancerPortal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CustomNavigationPage(Page root) : base(root)
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {

                throw;
            }
        }

     
        public bool IgnoreLayoutChange { get; set; } = false;

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    if (!IgnoreLayoutChange)
        //        base.OnSizeAllocated(width, height);
        //}
    }
}