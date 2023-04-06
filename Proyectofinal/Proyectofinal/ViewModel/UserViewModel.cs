using Proyectofinal.DAL;
using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext _databaseContext;
        public ICommand DeleteUserCommand { get; private set; }

        private ObservableCollection<Usuario> _users { get; set; }

        public UserViewModel()
        {
            _databaseContext = new UsuarioDatabaseContext();
            Users = new ObservableCollection<Usuario>(_databaseContext.GetAllUsuarios());
            DeleteUserCommand = new Command<Usuario>(OnDeleteUser);
        }

        public ObservableCollection<Usuario> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        private async void OnDeleteUser(Usuario user)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Confirm Deletion", $"Are you sure you want to delete user \n {user.Nombre}?", "Yes", "No");
            if (answer)
            {
                await DeleteUser(user.Id);
                Refresh();
            }
        }

        public async Task DeleteUser(int id)
        {
            var userToDelete = _databaseContext.GetUsuarioById(id);

            if (userToDelete != null)
            {
                _databaseContext.DeleteUsuario(userToDelete);

                // Remove the user from the collection
                Users.Remove(userToDelete);
            }
        }

        public void Refresh()
        {
            Users.Clear();
            var users = _databaseContext.GetAllUsuarios();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public void LoginView()
        {
            App.Current.MainPage = new Login();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
