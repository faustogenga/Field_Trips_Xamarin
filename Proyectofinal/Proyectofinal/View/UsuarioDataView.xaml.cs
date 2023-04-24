using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioDataView : ContentPage
    {
        private readonly UsuarioDataViewViewModel _viewModel;
        public UsuarioDataView(Usuario UserLogin)
        {
            InitializeComponent();
            _viewModel = new UsuarioDataViewViewModel();
            _viewModel.User = UserLogin;
            BindingContext = _viewModel;


        }
    }
}