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
    public partial class Admin : ContentPage
    {
        private readonly UserViewModel _viewModel;
        public Admin()
        {
            InitializeComponent();
            _viewModel = new UserViewModel();
            BindingContext = _viewModel;
        }

        private void OnRefreshClicked(object sender, System.EventArgs e)
        {
            _viewModel.Refresh();
        }

        private void LoginView(object sender, EventArgs e)
        {
            _viewModel.LoginView();
        }
    }
}