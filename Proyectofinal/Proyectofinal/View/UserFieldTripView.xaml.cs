using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserFieldTripView : ContentPage
    {
        private readonly EditViewModel _viewModel;
        public UserFieldTripView(Usuario User)
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            _viewModel.User = User;
            BindingContext = _viewModel;
        }
    }
}