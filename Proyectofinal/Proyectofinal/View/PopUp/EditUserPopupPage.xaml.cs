using Proyectofinal.DAL;
using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly EditViewModel _viewModel;


        public EditUserPopupPage(Usuario selectedUser)
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            _viewModel.User = selectedUser;
            BindingContext = _viewModel;
        }
    }
}