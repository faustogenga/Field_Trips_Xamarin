using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioMainView : ContentPage
    {
        private readonly UsuarioMainViewViewModel _viewModel;
        public UsuarioMainView(Usuario UserLogin)
        {
            InitializeComponent();
            _viewModel = new UsuarioMainViewViewModel();
            _viewModel.User = UserLogin;
            BindingContext = _viewModel;
        }
    }
}