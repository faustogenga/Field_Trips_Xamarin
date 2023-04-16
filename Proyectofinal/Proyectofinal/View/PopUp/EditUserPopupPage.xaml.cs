using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly EditViewModel _viewModel;
        public EditUserPopupPage()
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            BindingContext = _viewModel;
        }
    }
}