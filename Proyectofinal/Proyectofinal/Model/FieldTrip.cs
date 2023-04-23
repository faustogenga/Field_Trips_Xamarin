using SQLite;
using System.ComponentModel;

namespace Proyectofinal.Model
{    
    public class FieldTrip : INotifyPropertyChanged
    {        
        private int _giraId;
        private string _giraOrganizacion;
        private string _giraUbicacion;
        private string _giraFecha;
        private string _giraHoraSalida;
        private string _giraHoraRegreso;
        private string _giraDescripcion;
        private string _giraRequisitos;
        private int _giraValor;
        private int _giraPrecio;
        private string _giraLink;
        private string _giraImgURL;

        [PrimaryKey, AutoIncrement]
        public int GiraId
        {
            get => _giraId;
            set
            {
                if (_giraId != value)
                {
                    _giraId = value;
                    OnPropertyChanged(nameof(GiraId));
                }
            }
        }

        public string GiraOrganizacion
        {
            get => _giraOrganizacion;
            set
            {
                if (_giraOrganizacion != value)
                {
                    _giraOrganizacion = value;
                    OnPropertyChanged(nameof(GiraOrganizacion));
                }
            }
        }

        public string GiraUbicacion
        {
            get => _giraUbicacion;
            set
            {
                if (_giraUbicacion != value)
                {
                    _giraUbicacion = value;
                    OnPropertyChanged(nameof(GiraUbicacion));
                }
            }
        }

        public string GiraFecha
        {
            get => _giraFecha;
            set
            {
                if (_giraFecha != value)
                {
                    _giraFecha = value;
                    OnPropertyChanged(nameof(GiraFecha));
                }
            }
        }

        public string GiraHoraSalida
        {
            get => _giraHoraSalida;
            set
            {
                if (_giraHoraSalida != value)
                {
                    _giraHoraSalida = value;
                    OnPropertyChanged(nameof(GiraHoraSalida));
                }
            }
        }

        public string GiraHoraRegreso
        {
            get => _giraHoraRegreso;
            set
            {
                if (_giraHoraRegreso != value)
                {
                    _giraHoraRegreso = value;
                    OnPropertyChanged(nameof(GiraHoraRegreso));
                }
            }
        }

        public string GiraDescripcion
        {
            get => _giraDescripcion;
            set
            {
                if (_giraDescripcion != value)
                {
                    _giraDescripcion = value;
                    OnPropertyChanged(nameof(GiraDescripcion));
                }
            }
        }

        public string GiraRequisitos
        {
            get => _giraRequisitos;
            set
            {
                if (_giraRequisitos != value)
                {
                    _giraRequisitos = value;
                    OnPropertyChanged(nameof(GiraRequisitos));
                }
            }
        }

        public int GiraValor
        {
            get => _giraValor;
            set
            {
                if (_giraValor != value)
                {
                    _giraValor = value;
                    OnPropertyChanged(nameof(GiraValor));
                }
            }
        }

        public int GiraPrecio
        {
            get => _giraPrecio;
            set
            {
                if (_giraPrecio != value)
                {
                    _giraPrecio = value;
                    OnPropertyChanged(nameof(GiraPrecio));
                }
            }
        }

        public string GiraLink
        {
            get => _giraLink;
            set
            {
                if (_giraLink != value)
                {
                    _giraLink = value;
                    OnPropertyChanged(nameof(GiraLink));
                }
            }
        }

        public string GiraImgURL
        {
            get => _giraImgURL;
            set
            {
                if (_giraImgURL != value)
                {
                    _giraImgURL = value;
                    OnPropertyChanged(nameof(GiraImgURL));
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
