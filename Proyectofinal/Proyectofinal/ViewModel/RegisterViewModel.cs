using Proyectofinal.DAL;
using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public bool isRegisterButtonEnabled;

        private readonly UsuarioDatabaseContext MyDal;

        public string ErrorMessage { get; set; }

        public RegisterModel Register { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            Register = new RegisterModel();

            MyDal = new UsuarioDatabaseContext();

            RegisterCommand = new Command(() =>
            {
                ValidateRegisterInputFields();

                if (IsRegisterButtonEnabled)
                {
                    // Perform register logic
                    bool isSuccess = RegisterVoid(Register.Nombre, Register.Email, Register.Password, Register.Cedula, Register.Carrera);

                    if (isSuccess)
                    {
                        App.Current.MainPage = new Login();
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ValidateRegisterInputFields()
        {
            if (string.IsNullOrEmpty(Register.Nombre) || string.IsNullOrEmpty(Register.Email) || string.IsNullOrEmpty(Register.Password) || string.IsNullOrEmpty(Register.Cedula) || string.IsNullOrEmpty(Register.Carrera))
            {
                IsRegisterButtonEnabled = false;
                ErrorMessage = "Entries cannot be empty";
            }
            else if (Register.Password.Length < 6)
            {
                IsRegisterButtonEnabled = false;
                ErrorMessage = "Password must be at least 6 characters";
            }
            else
            {
                IsRegisterButtonEnabled = true;
            }
        }

        private bool RegisterVoid(string nombre, string email, string password, string cedula, string carrera)
        {

            if (MyDal.RegisterEmailValidation(email) != null || MyDal.RegisterCedulaValidation(cedula) != null)
            {
                // email or cedula already exists
                ErrorMessage = "Email or Cedula area already taken";
                return false;
            }

            // register new user
            Usuario nuevo = new Usuario
            {
                Nombre = nombre,
                Email = email,
                Password = password,
                Cedula = cedula,
                Carrera = carrera
            };

            if (MyDal.RegisterModel(nuevo) > 0)
            {
                return true;
            }
            else
            {
                ErrorMessage = "Error, No se pudo Registrar";
                return false;

            }
        }
    }

}

