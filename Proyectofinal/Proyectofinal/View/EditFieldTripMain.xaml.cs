using Proyectofinal.Model;
using Proyectofinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditFieldTripMain : ContentPage
	{
        private readonly EditViewModel _viewModel;
        public EditFieldTripMain (FieldTrip selectedFieldTrip)
		{
			InitializeComponent ();
            _viewModel = new EditViewModel();
            _viewModel.FieldTrip = selectedFieldTrip;
            BindingContext = _viewModel;
        }
	}
}