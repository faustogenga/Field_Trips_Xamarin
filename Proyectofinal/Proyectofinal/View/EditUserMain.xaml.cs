using Proyectofinal.Model;
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
    public partial class EditUserMain : ContentPage
    {
        private readonly EditViewModel _viewModel;
        public EditUserMain(Usuario selectedUser)
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            _viewModel.User = selectedUser;
            BindingContext = _viewModel;
        }
    }
}