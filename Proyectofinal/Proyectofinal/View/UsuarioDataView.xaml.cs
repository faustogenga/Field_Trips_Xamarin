using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainView : ContentPage
    {
        
        public UserMainView()
        {
            InitializeComponent();
            this.BindingContext = new UsuarioDataViewViewModel();


        }
    }
}