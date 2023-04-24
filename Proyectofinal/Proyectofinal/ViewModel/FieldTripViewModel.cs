using Proyectofinal.DAL;
using Proyectofinal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
                    bool isSuccess = EntryVoid(
                        FieldTrip.Codigo,
                        FieldTrip.Organizacion, 
                        FieldTrip.Ubicacion, 
                        FieldTrip.Fecha, 
                        FieldTrip.HoraSalida, 
                        FieldTrip.HoraRegreso,
                        FieldTrip.Descripcion,
                        FieldTrip.Valor, 
                        FieldTrip.Precio, 
                        FieldTrip.Link, 
                        FieldTrip.ImgURL);
                    if (isSuccess)
                    {
                        App.Current.MainPage = new AdminFieldTrip();
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Error", $"{ErrorMessage}", "OK");
                    }
                }
            });

        }

        //Get and Set
        public int Id
        {
            get { return FieldTrip.Id; }
            set
            {
                FieldTrip.Id = value;
                OnPropertyChanged();
            }
        }

        public string Organizacion
        {
            get { return FieldTrip.Organizacion; }
            set
            {
                FieldTrip.Organizacion = value;
                OnPropertyChanged();
            }
        }

        public string Ubicacion
        {
            get { return FieldTrip.Ubicacion; }
            set
            {
                FieldTrip.Ubicacion = value;
                OnPropertyChanged();
            }
        }

        public string Fecha
        {
            get { return FieldTrip.Fecha; }
            set
            {
                FieldTrip.Fecha = value;
                OnPropertyChanged();
            }
        }

        public string HoraSalida
        {
            get { return FieldTrip.HoraSalida; }
            set
            {
                FieldTrip.HoraSalida = value;
                OnPropertyChanged();
            }
        }

        public string HoraRegreso
        {
            get { return FieldTrip.HoraRegreso; }
            set
            {
                FieldTrip.HoraRegreso = value;
                OnPropertyChanged();
            }
        }

        public string Descripcion
        {
            get { return FieldTrip.Descripcion; }
            set
            {
                FieldTrip.Descripcion = value;
                OnPropertyChanged();
            }
        }

        public int Valor
        {
            get { return FieldTrip.Valor; }
            set
            {
                FieldTrip.Valor = value;
                OnPropertyChanged();
            }
        }

        public int Precio
        {
            get { return FieldTrip.Precio; }
            set
            {
                FieldTrip.Precio = value;
                OnPropertyChanged();
            }
        }

        public string Link
        {
            get { return FieldTrip.Link; }
            set
            {
                FieldTrip.Link = value;
                OnPropertyChanged();
            }
        }

        public string ImgURL
        {
            get { return FieldTrip.ImgURL; }
            set
            {
                FieldTrip.ImgURL = value;
                OnPropertyChanged();
            }
        }



        //Validation fields
        private void ValidateInputFields()
        {
            if (string.IsNullOrEmpty(FieldTrip.Organizacion) &
                string.IsNullOrEmpty(FieldTrip.Ubicacion) &
                string.IsNullOrEmpty(FieldTrip.Fecha) &
                string.IsNullOrEmpty(FieldTrip.HoraSalida) &
                string.IsNullOrEmpty(FieldTrip.HoraRegreso) &
                string.IsNullOrEmpty(FieldTrip.Descripcion) &
                FieldTrip.Valor == default(int) &
                FieldTrip.Valor > 0 &
                FieldTrip.Precio == default(int) &
                FieldTrip.Precio > 0 &
                string.IsNullOrEmpty(FieldTrip.Link) &
                string.IsNullOrEmpty(FieldTrip.ImgURL))
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
        private bool EntryVoid(
            string Codigo,
            string Organizacion,
            string Ubicacion, 
            string Fecha, 
            string HoraSalida,
            string HoraRegreso,
            string Descripcion,
            int Valor, 
            int Precio, 
            string Link,
            string ImgURL)
        {
            //Validation ID
            if (MyDal.FieldTripIdValidation(Codigo) != null)
            {
                ErrorMessage = "Field trip ID already taken";
                return false;
            }

            //Insert
            Model.FieldTrip nuevo = new Model.FieldTrip
            {
                Codigo = Codigo,
                Organizacion = Organizacion,
                Ubicacion = Ubicacion,
                Fecha = Fecha,
                HoraSalida = HoraSalida,
                HoraRegreso = HoraRegreso,
                Descripcion = Descripcion,
                Valor = Valor,
                Precio = Precio,
                Link = Link,
                ImgURL = ImgURL
            };

            if (MyDal.InsertFieldTrip(nuevo) > 0)
            {
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Organizacion}", "OK");
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
