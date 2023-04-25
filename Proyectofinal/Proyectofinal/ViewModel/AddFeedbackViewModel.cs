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
        public FieldTripRepository Repository { get; set; }


        private List<string> _fieldtrips;
        public Usuario _User;
        public string _FeedbackInfo { get; set; }

        private string _selectedFieldTrip { get; set; }
        //Register Feedback
        public ICommand AddFeedbackCommand { get; set; }

        public bool isRegisterButtonEnabled;
        public string ErrorMessage { get; set; }
        //Other
        public ICommand BackMainFeedbackCommand { get; set; }
        public ICommand NewFeedbackCommand { get; set; }
        public ICommand BackMainCommand { get; set; }

        public AddFeedbackViewModel()
        {

            MyDal = new UsuarioDatabaseContext();

            Repository = new FieldTripRepository();

            FieldTrips = Repository.GetAllFieldTripOrganizacion();

            AddFeedbackCommand = new Command(() =>
            {
                ValidateRegisterInputFields();

                if (IsRegisterButtonEnabled)
                {
                    var CodigoFieldTrip = Repository.GetFieldTripByOrganizacion(SelectedFieldTrip);

                    bool isSuccess = RegisterVoid(SelectedFieldTrip, CodigoFieldTrip, FeedbackInfo);

                    if (isSuccess)
                    {
                        App.Current.MainPage = new FeedbackView(User);
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
                App.Current.MainPage = new FeedbackView(User);
            });
            NewFeedbackCommand = new Command(() =>
            {
                App.Current.MainPage = new AddFeedback(User);
            });

        }

        public Usuario User
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged();
            }
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

        public string FeedbackInfo
        {
            get => _FeedbackInfo;
            set
            {
                _FeedbackInfo = value;
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
            if (string.IsNullOrEmpty(SelectedFieldTrip) || string.IsNullOrEmpty(FeedbackInfo) )
            {
                IsRegisterButtonEnabled = false;
                ErrorMessage = "Entries cannot be empty";
            }
            else
            {
                IsRegisterButtonEnabled = true;
            }
        }

        private bool RegisterVoid(string organizacion, string codigoFieldTrip, string feedbackInfo)
        {
            // register
            Feedback nuevo = new Feedback
            {
                OrganizacionFieldTrip = organizacion,
                CodigoFieldTrip = codigoFieldTrip,
                FeedbackInfo = feedbackInfo
            };

            if (MyDal.RegisterFeedback(nuevo) > 0)
            {
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
