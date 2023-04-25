using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackView : ContentPage
    {
        private readonly FeedbackViewModel _viewModel;
        public FeedbackView(Usuario UserLogin)
        {
            InitializeComponent();
            _viewModel = new FeedbackViewModel();
            _viewModel.User = UserLogin;
            BindingContext = _viewModel;
        }
    }
}