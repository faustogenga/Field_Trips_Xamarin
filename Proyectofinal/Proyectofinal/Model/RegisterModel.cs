using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Proyectofinal.Model
{
    public class RegisterModel : INotifyPropertyChanged
    {
        public string nombre;
        public string email;
        public string password;
        public string cedula;
        public string carrera;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
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
