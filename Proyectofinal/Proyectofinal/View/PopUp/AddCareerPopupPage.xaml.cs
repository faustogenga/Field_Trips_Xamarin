using Proyectofinal.ViewModel;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCareerPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly CarreraViewModel _viewModel;
        public AddCareerPopupPage()
        {
            InitializeComponent();
            _viewModel = new CarreraViewModel();
            BindingContext = _viewModel;
        }
    }
}