using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Proyectofinal.Model
{
    public class RegisterModel : INotifyPropertyChanged
    {
        private string Nombre;

        private string email;

        private string password;

        private string cedula;

        private string carrera;

        public string Nombre1
        {
            get { return Nombre; }
            set
            {
                Nombre = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Cedula
        {
            get { return cedula; }
            set
            {
                cedula = value;
                OnPropertyChanged();
            }
        }

        public string Carrera
        {
            get { return carrera; }
            set
            {
                carrera = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
