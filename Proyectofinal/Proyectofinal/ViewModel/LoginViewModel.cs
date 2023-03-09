using Proyectofinal.Model;
using Proyectofinal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginModel Login { get; set; }

        public bool isLoginButtonEnabled;
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public LoginViewModel()
        {
            Login = new LoginModel();

            LoginCommand = new Command (async () =>
            {
                ValidateLoginInputFields();

                if (IsLoginButtonEnabled)
                {
                    // Perform login logic
                    bool isSuccess = await LoginVoid(Login.Username, Login.Password);

                    if (isSuccess)
                    {
                        // Navigate to home page
                    }
                    else
                    {
                        // Display error message
                    }
                }
                else
                {
                    // Display error message for invalid input fields
                }

            });

            RegisterCommand = new Command(() =>
            {
                App.Current.MainPage = new Register();
            });

            ForgotPasswordCommand = new Command(() =>
            {
                /* App.Current.MainPage = new ForgotPasswordPage(); */
            });
        }


        public string Username
        {
            get { return Login.Username; }
            set
            {
                Login.Username = value;
                OnPropertyChanged();

            }
        }

        public string Password
        {
            get { return Login.Password; }
            set
            {
                Login.Password = value;
                OnPropertyChanged();

            }
        }

        public bool IsLoginButtonEnabled
        {
            get { return isLoginButtonEnabled; }
            set
            {
                isLoginButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ValidateLoginInputFields()
        {
            // username and password no esten vacios
            if (!string.IsNullOrWhiteSpace(Login.Username) && !string.IsNullOrWhiteSpace(Login.Password))
            {
                IsLoginButtonEnabled = true;
            }
            else
            {
                IsLoginButtonEnabled = false;
            }
        }

        private async Task<bool> LoginVoid(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
