using Proyectofinal.DAL;
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

        public Model.Carrera Carrera { get; set; }
        public string ErrorMessage { get; set; }
        public bool statusEntryCareer;

        private readonly UsuarioDatabaseContext MyDal;


        public CarreraViewModel()
        {
            Carrera = new Model.Carrera();
            MyDal = new UsuarioDatabaseContext();
            Repository = new CarreraRepository();
            CarrerasNombres = Repository.GetAllCarreraNombres();


            AddCareerCommand = new Command(async () =>
            {
                ValidateInputFields();
                if (statusEntryCareer)
                {
                    bool isSuccess = EntryVoid(Nombre);
                    if (isSuccess)
                    {
                        await App.Current.MainPage.Navigation.PopPopupAsync();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", $"{ErrorMessage}", "OK");
                        await App.Current.MainPage.Navigation.PopPopupAsync();
                    }
                }
            });

            OnCancelCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopPopupAsync();
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

        private void ValidateInputFields()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                statusEntryCareer = false;
                ErrorMessage = "Empty entries, please fill in required spaces";
            }
            else
            {
                statusEntryCareer = true;
            }
        }

        private bool EntryVoid(string Nombre)
        {
            //Validation ID
            if (MyDal.CareerValidation(Nombre) != null)
            {
                ErrorMessage = "Career already taken";
                return false;
            }

            //Insert
            Model.Carrera nuevo = new Model.Carrera
            {
                Nombre = Nombre,
            };

            if (MyDal.InsertCareer(nuevo) > 0)
            {
                App.Current.MainPage.DisplayAlert("registrado", $"{nuevo.Nombre}", "OK");
                return true;
            }
            else
            {
                ErrorMessage = "Error, please review in required spaces";
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
