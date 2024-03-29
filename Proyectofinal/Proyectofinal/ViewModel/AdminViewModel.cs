﻿using Proyectofinal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        public ICommand EditUsersCommand { get; set; }

        public ICommand EditCareersCommand { get; set; }
        public ICommand EditTripsCommand { get; set; }

        public ICommand EditFeedbackCommand { get; set; }

        public ICommand SignOutCommand { get; set; }

        public AdminViewModel()
        {
            EditUsersCommand = new Command(() =>
            {
                // Perform edit users logic
                App.Current.MainPage = new AdminUsers();
            });

            EditCareersCommand = new Command(() =>
            {
                App.Current.MainPage = new AdminCareers();
            });
            EditTripsCommand = new Command(() =>
            {
                App.Current.MainPage = new AdminFieldTrip();
            });

            SignOutCommand = new Command(() =>
            {
                App.Current.MainPage = new Login();
            });

            EditFeedbackCommand = new Command(() =>
            {
                App.Current.MainPage = new AdminFeedback();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
