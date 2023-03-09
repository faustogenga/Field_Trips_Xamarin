using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel { 
    class RegisterViewModel
    {
        public RegisterModel Register { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            Register = new RegisterModel();

            RegisterCommand = new Command(() =>
            {
                    App.Current.MainPage.DisplayAlert("exito",
                         $"hola : {Register.Nombre} \n" +
                         $"{Register.Cedula} \n" +
                         $"{Register.Carrera} \n" +
                          $"{Register.Email} \n" +
                          $"{Register.Password} \n",
                        "OK");
            });

        }
    }

}

