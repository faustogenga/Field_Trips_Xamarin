using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel { 
    class RegisterViewModel
    {
        public RegisterModel RegisterModel { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterModel = new RegisterModel();

            RegisterCommand = new Command(() =>
            {
                    App.Current.MainPage.DisplayAlert("exito",
                         $"{RegisterModel.Nombre1} \n" +
                         $"{RegisterModel.Cedula} \n" +
                         $"{RegisterModel.Carrera} \n" +
                          $"{RegisterModel.Email} \n" +
                          $"{RegisterModel.Password} \n"
                         ,
                        "OK");
            });

        }
    }

}

