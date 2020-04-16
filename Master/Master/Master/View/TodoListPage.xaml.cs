using CancerPortal.ViewModel;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace CancerPortal.View
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage ()
		{
			InitializeComponent ();
			BindingContext  = Startup.ServiceProvider?.GetService<TodoListViewModel>();
		}
	}
}

