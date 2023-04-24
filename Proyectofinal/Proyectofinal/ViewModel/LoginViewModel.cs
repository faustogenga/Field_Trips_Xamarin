using Proyectofinal.DAL;
using Proyectofinal.Model;
using Proyectofinal.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext MyDal;

        public LoginModel Login;

        public bool isLoginButtonEnabled;
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public LoginViewModel()
        {
            Login = new LoginModel();

            MyDal = new UsuarioDatabaseContext();

            LoginCommand = new Command(async () =>
            {
                ValidateLoginInputFields();

                if (IsLoginButtonEnabled)
                {
                    bool isAdmin = LoginAdminVoid(Login.Username.ToLower(), Login.Password);
                    // Perform login logic
                    if (isAdmin)
                    {
                        App.Current.MainPage = new AdminMain();
                    }
                    else
                    {
                        bool isUser = LoginVoid(Login.Username, Login.Password);

                        if (isUser)
                        {
                            await App.Current.MainPage.DisplayAlert("Bien", "User login successful", "OK");
                            App.Current.MainPage = new UsuarioMainView();
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK");
                        }

                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Username and password cannot be empty", "OK");
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

        private bool LoginVoid(string email, string password)
        {
            var user = MyDal.LoginUsuario(email, password);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        private bool LoginAdminVoid(string email, string password)
        {
            var user = MyDal.LoginAdminUsuario(email, password);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
