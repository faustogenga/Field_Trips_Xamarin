using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserFieldTripView : ContentPage
    {
        private readonly EditViewModel _viewModel;
        public UserFieldTripView()
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            BindingContext = _viewModel;
        }
    }
}