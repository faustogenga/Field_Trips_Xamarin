using Proyectofinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackView : ContentPage
    {
        public FeedbackView()
        {
            InitializeComponent();
            this.BindingContext = new AddFeedbackViewModel();
        }
    }
}