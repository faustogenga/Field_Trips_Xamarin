﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FieldTrip : ContentPage
	{
		public FieldTrip ()
		{
			InitializeComponent ();
            this.BindingContext = new FieldTripViewModel();
        }
	}
}