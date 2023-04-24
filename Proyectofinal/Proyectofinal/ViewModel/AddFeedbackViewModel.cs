using Proyectofinal.DAL;
using Proyectofinal.Model;
using Proyectofinal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    class AddFeedbackViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext MyDal;
        public FieldTripRepoViewModel FieldTrip { get; set; }
        private List<string> _fieldtrips;
        private string _selectedFieldTrip { get; set; }
        //Register
        public ICommand AddFeedbackCommand { get; set; }
        public Feedback Register { get; set; }
        public bool isRegisterButtonEnabled;
        public string ErrorMessage { get; set; }
        //Other
        public ICommand BackMainFeedbackCommand { get; set; }
        public ICommand NewFeedbackCommand { get; set; }
        public ICommand BackMainCommand { get; set; }

        public AddFeedbackViewModel()
        {
            MyDal = new UsuarioDatabaseContext();

            FieldTrip = new FieldTripRepoViewModel();

            FieldTrips = FieldTrip.FieldTripsCodigos;

            AddFeedbackCommand = new Command(() =>
            {
                ValidateRegisterInputFields();

                if (IsRegisterButtonEnabled)
                {
                    // Perform register logic
                    bool isSuccess = RegisterVoid(Register.CodigoFieldTrip, Register.FeedbackInfo);

                    if (isSuccess)
                    {
                        App.Current.MainPage = new FeedbackView();
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Error", $"{ErrorMessage}", "OK");
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Error", $"{ErrorMessage}", "OK");
                }
            });

            BackMainFeedbackCommand = new Command(() =>
            {
                App.Current.MainPage = new FeedbackView();
            });
            NewFeedbackCommand = new Command(() =>
            {
                App.Current.MainPage = new AddFeedback();
            });
            BackMainCommand = new Command(() =>
            {
                App.Current.MainPage = new UsuarioMain();
            });

        }
        public List<string> FieldTrips
        {
            get => _fieldtrips;
            set
            {
                _fieldtrips = value;
                OnPropertyChanged();
            }
        }
        public string SelectedFieldTrip
        {
            get => _selectedFieldTrip;
            set
            {
                _selectedFieldTrip = value;
                OnPropertyChanged();
            }
        }
        public bool IsRegisterButtonEnabled
        {
            get { return isRegisterButtonEnabled; }
            set
            {
                isRegisterButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        private void ValidateRegisterInputFields()
        {
            if (string.IsNullOrEmpty(Register.CodigoFieldTrip) || string.IsNullOrEmpty(Register.FeedbackInfo) )
            {
                IsRegisterButtonEnabled = false;
                ErrorMessage = "Entries cannot be empty";
            }
            else
            {
                IsRegisterButtonEnabled = true;
            }
        }

        private bool RegisterVoid(string codigoFieldTrip, string feedbackInfo)
        {
            // register
            Feedback nuevo = new Feedback
            {
                CodigoFieldTrip = codigoFieldTrip,
                FeedbackInfo = feedbackInfo
            };

            if (MyDal.RegisterFeedback(nuevo) > 0)
            {
                App.Current.MainPage.DisplayAlert("registerd", "Succesfully", "OK");
                return true;
            }
            else
            {
                ErrorMessage = "Error, cant register";
                return false;

            }
        }
        

        //Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
