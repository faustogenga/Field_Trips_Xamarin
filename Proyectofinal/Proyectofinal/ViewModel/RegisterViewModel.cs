using Proyectofinal.DAL;
using Proyectofinal.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public bool isRegisterButtonEnabled;

        private readonly UsuarioDatabaseContext MyDal;

        public RegisterModel Register { get; set; }

        public CarreraViewModel Carrera { get; set; }

        public string ErrorMessage { get; set; }

        private List<string> _carreras;
        private string _selectedCarrera { get; set; }

        public ICommand RegisterCommand { get; set; }

        public ICommand SigninCommand { get; set; }
        

        public RegisterViewModel()
        {
            Register = new RegisterModel();

            MyDal = new UsuarioDatabaseContext();

            Carrera = new CarreraViewModel();

            Carreras = Carrera.CarrerasNombres;

            RegisterCommand = new Command(() =>
            {

                ValidateRegisterInputFields();

                if (IsRegisterButtonEnabled)
                {
                    // Perform register logic
                    bool isSuccess = RegisterVoid(Register.Nombre, Register.Email, Register.Password, Register.Cedula, SelectedCarrera);

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

            SigninCommand = new Command(() =>
            {
                App.Current.MainPage = new Login();

            });            

        }
        public List<string> Carreras
        {
            get => _carreras;
            set
            {
                _carreras = value;
                OnPropertyChanged();
            }
        }
        public string SelectedCarrera
        {
            get => _selectedCarrera;
            set 
            {
                _selectedCarrera = value;
                OnPropertyChanged();
            }
        }

        public string Nombre
        {
            get { return Register.Nombre; }
            set
            {
                Register.Nombre = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return Register.Email; }
            set
            {
                Register.Email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return Register.Password; }
            set
            {
                Register.Password = value;
                OnPropertyChanged();
            }
        }

        public string Cedula
        {
            get { return Register.Cedula; }
            set
            {
                Register.Cedula = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ValidateRegisterInputFields()
        {
            if (string.IsNullOrEmpty(Register.Nombre) || string.IsNullOrEmpty(Register.Email) || string.IsNullOrEmpty(Register.Password) || string.IsNullOrEmpty(Register.Cedula))
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
                Carrera = carrera,
                Role = "User"
            };

            if (MyDal.RegisterUsuario(nuevo) > 0)
            {
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Email}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Id}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Nombre}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Cedula}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Carrera}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Role}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"reg", "OK");
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

