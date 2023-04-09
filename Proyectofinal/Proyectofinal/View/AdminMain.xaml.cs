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
    public partial class AdminMain : ContentPage
    {
        private readonly AdminViewModel _viewModel;
        public AdminMain()
        {
            InitializeComponent();
            _viewModel = new AdminViewModel();
            BindingContext = _viewModel;
        }
    }
}