using Proyectofinal.DAL;
using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext _databaseContext;

        private ObservableCollection<Usuario> _users { get; set; }

        public UserViewModel()
        {
            _databaseContext = new UsuarioDatabaseContext();
            Users = new ObservableCollection<Usuario>(_databaseContext.GetAllUsuarios());
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

        public void Refresh()
        {
            Users.Clear();
            var users = _databaseContext.GetAllUsuarios();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
