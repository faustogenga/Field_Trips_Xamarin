﻿using Proyectofinal.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminUsers : ContentPage
    {
        private readonly EditViewModel _viewModel;
        public AdminUsers()
        {
            InitializeComponent();
            _viewModel = new EditViewModel();
            BindingContext = _viewModel;
        }

        private void OnRefreshClicked(object sender, System.EventArgs e)
        {
            _viewModel.Refresh();
        }

        private void AdminMainView(object sender, EventArgs e)
        {
            _viewModel.AdminMainView();
        }
    }
}