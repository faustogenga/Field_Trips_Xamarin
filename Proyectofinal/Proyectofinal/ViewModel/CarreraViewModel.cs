using Proyectofinal.Model;
using Proyectofinal.View;
using Proyectofinal.View.PopUp;
using Rg.Plugins.Popup.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class CarreraViewModel : INotifyPropertyChanged
    {
        private string _nombre;

        private List<string> _carrerasnombres;

        public ICommand AddCareerCommand { get; private set; }

        public ICommand OnCancelCommand { get; private set; }
        private CarreraRepository Repository { get; set; }

        public CarreraViewModel()
        {
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            Repository = new CarreraRepository();
            CarrerasNombres = Repository.GetAllCarreraNombres();

            AddCareerCommand = new Command(async () =>
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

            OnCancelCommand = new Command(async () =>
            {
                // Close the popup
            });
        }


        public List<string> CarrerasNombres
        {
            get => _carrerasnombres;
            set
            {
                _carrerasnombres = value;
                OnPropertyChanged();
            }
        }


        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
