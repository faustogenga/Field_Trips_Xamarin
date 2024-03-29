﻿using Proyectofinal.Model;
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
    public partial class EditFeedbackMain : ContentPage
    {
        private readonly EditViewModel _viewModel;
        public EditFeedbackMain(Feedback SelectedFeedback)
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            _viewModel.Feedback = SelectedFeedback;
            BindingContext = _viewModel;
        }
    }
}