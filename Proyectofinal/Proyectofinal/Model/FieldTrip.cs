using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Proyectofinal.Model
{
    public class FieldTrip : INotifyPropertyChanged
    {
        private int _id;
        private string _codigo;
        private string _organizacion;
        private string _ubicacion;
        private string _fecha;
        private string _horaSalida;
        private string _horaRegreso;
        private string _descripcion;
        private int _valor;
        private int _precio;
        private string _link;
        private string _imgURL;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string Codigo
        {
            get => _codigo;
            set
            {
                if (_codigo != value)
                {
                    _codigo = value;
                    OnPropertyChanged(nameof(Codigo));
                }
            }
        }
        public string Organizacion
        {
            get => _organizacion;
            set
            {
                if (_organizacion != value)
                {
                    _organizacion = value;
                    OnPropertyChanged(nameof(Organizacion));
                }
            }
        }

        public string Ubicacion
        {
            get => _ubicacion;
            set
            {
                if (_ubicacion != value)
                {
                    _ubicacion = value;
                    OnPropertyChanged(nameof(Ubicacion));
                }
            }
        }

        public string Fecha
        {
            get => _fecha;
            set
            {
                if (_fecha != value)
                {
                    _fecha = value;
                    OnPropertyChanged(nameof(Fecha));
                }
            }
        }

        public string HoraSalida
        {
            get => _horaSalida;
            set
            {
                if (_horaSalida != value)
                {
                    _horaSalida = value;
                    OnPropertyChanged(nameof(HoraSalida));
                }
            }
        }

        public string HoraRegreso
        {
            get => _horaRegreso;
            set
            {
                if (_horaRegreso != value)
                {
                    _horaRegreso = value;
                    OnPropertyChanged(nameof(HoraRegreso));
                }
            }
        }

        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }

        public int Valor
        {
            get => _valor;
            set
            {
                if (_valor != value)
                {
                    _valor = value;
                    OnPropertyChanged(nameof(Valor));
                }
            }
        }

        public int Precio
        {
            get => _precio;
            set
            {
                if (_precio != value)
                {
                    _precio = value;
                    OnPropertyChanged(nameof(Precio));
                }
            }
        }

        public string Link
        {
            get => _link;
            set
            {
                if (_link != value)
                {
                    _link = value;
                    OnPropertyChanged(nameof(Link));
                }
            }
        }

        public string ImgURL
        {
            get => _imgURL;
            set
            {
                if (_imgURL != value)
                {
                    _imgURL = value;
                    OnPropertyChanged(nameof(ImgURL));
                }
            }
        }


        //Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
