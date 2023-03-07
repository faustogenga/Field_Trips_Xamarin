using Proyectofinal.Model;
using Proyectofinal.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class LoginViewModel
    {
        public LoginModel Login { get; set; }
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public LoginViewModel()
        {
            Login = new LoginModel();

            var uno = new double[0];

            LoginCommand = new Command(() =>
            {
                if (Login.Username == "admin" && Login.Password == "admin")
                {
                    App.Current.MainPage.DisplayAlert("exito", "Usuario correcto", "OK");
                    App.Current.MainPage = new Login();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
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
    }
}
