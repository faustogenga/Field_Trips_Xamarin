using Proyectofinal.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Proyectofinal.ViewModel
{
    public class CarreraViewModel : INotifyPropertyChanged
    {
        private string _nombre;

        private List<string> _carrerasnombres;


        private CarreraRepository Repository { get; set; }

        public CarreraViewModel()
        {
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            Repository = new CarreraRepository();
            CarrerasNombres = Repository.GetAllCarreraNombres();
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
