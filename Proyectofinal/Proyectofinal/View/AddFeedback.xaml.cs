using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFeedback : ContentPage
    {
        private readonly AddFeedbackViewModel _viewModel;
        public AddFeedback(Usuario UserLogin)
        {
            InitializeComponent();
            _viewModel = new AddFeedbackViewModel();
            _viewModel.User = UserLogin;
            BindingContext = _viewModel;
        }
    }
}