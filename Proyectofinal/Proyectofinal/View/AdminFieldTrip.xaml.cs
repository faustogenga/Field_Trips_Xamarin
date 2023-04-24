using Proyectofinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminFieldTrip : ContentPage
	{
        private readonly EditViewModel _viewModel;
        public AdminFieldTrip ()
		{
			InitializeComponent ();
            _viewModel = new EditViewModel();
            BindingContext = _viewModel;
        }
        private void OnRefreshClicked(object sender, System.EventArgs e)
        {
            _viewModel.Refresh();
        }

        private void AdminMainView(object sender, EventArgs e)
        {
            _viewModel.AdminMainView();
        }
    }
}