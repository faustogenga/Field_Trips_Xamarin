using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFeedback : ContentPage
    {
        public AddFeedback()
        {
            InitializeComponent();
            this.BindingContext = new AddFeedbackViewModel();
        }
    }
}