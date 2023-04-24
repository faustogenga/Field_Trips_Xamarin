using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserFieldTripView : ContentPage
    {
        public UserFieldTripView()
        {
            InitializeComponent();
            this.BindingContext = new FieldTripViewModel();
        }
    }
}