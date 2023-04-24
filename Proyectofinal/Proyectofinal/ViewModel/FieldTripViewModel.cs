using Proyectofinal.DAL;
using Proyectofinal.Model;
using Proyectofinal.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    class FieldTripViewModel : INotifyPropertyChanged
    {
        public bool statusEntryFieldTrip;
        private readonly UsuarioDatabaseContext MyDal;
        public Model.FieldTrip FieldTrip { get; set; }
        public string ErrorMessage { get; set; }
        public ICommand EntryTripCommand { get; set; }

        public FieldTripViewModel()
        {
            FieldTrip = new Model.FieldTrip();
            MyDal = new UsuarioDatabaseContext();

            EntryTripCommand = new Command(() =>
            {
                ValidateInputFields();
                if (statusEntryFieldTrip)
                {
                    bool isSuccess = EntryVoid(FieldTrip.GiraId, FieldTrip.GiraOrganizacion, FieldTrip.GiraUbicacion, FieldTrip.GiraFecha, FieldTrip.GiraHoraSalida, FieldTrip.GiraHoraRegreso,
                        FieldTrip.GiraDescripcion, FieldTrip.GiraRequisitos, FieldTrip.GiraValor, FieldTrip.GiraPrecio, FieldTrip.GiraLink, FieldTrip.GiraImgURL);
                    if (isSuccess)
                    {
                        App.Current.MainPage = new FieldTripListView();
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Error", $"{ErrorMessage}", "OK");
                    }
                }
            });

        }

        //Get and Set
        public int GiraId
        {
            get { return FieldTrip.GiraId; }
            set
            {
                FieldTrip.GiraId = value;
                OnPropertyChanged();
            }
        }

        public string GiraOrganizacion
        {
            get { return FieldTrip.GiraOrganizacion; }
            set
            {
                FieldTrip.GiraOrganizacion = value;
                OnPropertyChanged();
            }
        }

        public string GiraUbicacion
        {
            get { return FieldTrip.GiraUbicacion; }
            set
            {
                FieldTrip.GiraUbicacion = value;
                OnPropertyChanged();
            }
        }

        public string GiraFecha
        {
            get { return FieldTrip.GiraFecha; }
            set
            {
                FieldTrip.GiraFecha = value;
                OnPropertyChanged();
            }
        }

        public string GiraHoraSalida
        {
            get { return FieldTrip.GiraHoraSalida; }
            set
            {
                FieldTrip.GiraHoraSalida = value;
                OnPropertyChanged();
            }
        }

        public string GiraHoraRegreso
        {
            get { return FieldTrip.GiraHoraRegreso; }
            set
            {
                FieldTrip.GiraHoraRegreso = value;
                OnPropertyChanged();
            }
        }

        public string GiraDescripcion
        {
            get { return FieldTrip.GiraDescripcion; }
            set
            {
                FieldTrip.GiraDescripcion = value;
                OnPropertyChanged();
            }
        }

        public string GiraRequisitos
        {
            get { return FieldTrip.GiraRequisitos; }
            set
            {
                FieldTrip.GiraRequisitos = value;
                OnPropertyChanged();
            }
        }

        public int GiraValor
        {
            get { return FieldTrip.GiraValor; }
            set
            {
                FieldTrip.GiraValor = value;
                OnPropertyChanged();
            }
        }

        public int GiraPrecio
        {
            get { return FieldTrip.GiraPrecio; }
            set
            {
                FieldTrip.GiraPrecio = value;
                OnPropertyChanged();
            }
        }

        public string GiraLink
        {
            get { return FieldTrip.GiraLink; }
            set
            {
                FieldTrip.GiraLink = value;
                OnPropertyChanged();
            }
        }

        public string GiraImgURL
        {
            get { return FieldTrip.GiraImgURL; }
            set
            {
                FieldTrip.GiraImgURL = value;
                OnPropertyChanged();
            }
        }



        //Validation fields
        private void ValidateInputFields()
        {
            if (string.IsNullOrEmpty(FieldTrip.GiraOrganizacion) || 
                string.IsNullOrEmpty(FieldTrip.GiraUbicacion) || 
                string.IsNullOrEmpty(FieldTrip.GiraFecha) ||
                string.IsNullOrEmpty(FieldTrip.GiraHoraSalida) ||
                string.IsNullOrEmpty(FieldTrip.GiraHoraRegreso) ||
                string.IsNullOrEmpty(FieldTrip.GiraDescripcion) ||
                string.IsNullOrEmpty(FieldTrip.GiraRequisitos) ||
                FieldTrip.GiraValor == default(int) ||
                FieldTrip.GiraPrecio == default(int) ||
                string.IsNullOrEmpty(FieldTrip.GiraLink) ||
                string.IsNullOrEmpty(FieldTrip.GiraImgURL))
            {
                statusEntryFieldTrip = false;
                ErrorMessage = "Empty entries, please fill in required spaces";
            }
            else
            {
                statusEntryFieldTrip = true;
            }
        }

        //Register New User
        private bool EntryVoid(int giraId, string giraOrganizacion, string giraUbicacion, string giraFecha, string giraHoraSalida, string giraHoraRegreso, 
            string giraDescripcion, string giraRequisitos, int giraValor, int giraPrecio, string giraLink, string giraImgURL)
        {
            //Validation ID
            if (MyDal.FieldTripIdValidation(giraId)!= null)
            {
                ErrorMessage = "Field trip ID already taken";
                return false;
            }

            //Insert
            Model.FieldTrip nuevo = new Model.FieldTrip
            {
                GiraId = giraId,
                GiraOrganizacion = giraOrganizacion,
                GiraUbicacion = giraUbicacion,
                GiraFecha = giraFecha,
                GiraHoraSalida = giraHoraSalida,
                GiraHoraRegreso = giraHoraRegreso,
                GiraDescripcion = giraDescripcion,
                GiraRequisitos = giraRequisitos,
                GiraValor = giraValor,
                GiraPrecio = giraPrecio,
                GiraLink = giraLink,
                GiraImgURL = giraImgURL
            };

            if (MyDal.InsertFieldTrip(nuevo) > 0)
            {
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraId}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraOrganizacion}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraUbicacion}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraFecha}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraHoraSalida}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraHoraRegreso}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraDescripcion}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraRequisitos}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraValor}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraPrecio}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraLink}", "OK");
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.GiraImgURL}", "OK");
                return true;
            }
            else
            {
                ErrorMessage = "Error, please review in required spaces";
                return false;

            }
        }

        //INTERFACE
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
