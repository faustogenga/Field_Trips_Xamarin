using Proyectofinal.DAL;
using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Proyectofinal.ViewModel
{
    public class CarreraViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private ObservableCollection<string> _carreras { get; set; }


        private readonly UsuarioDatabaseContext _databaseContext;

        public CarreraViewModel()
        {
            _databaseContext = new UsuarioDatabaseContext();
            Carreras= new ObservableCollection<string>(_databaseContext.GetAllCarreras());
        }

        public ObservableCollection<String> Carreras
        {
            get { return _carreras; }
            set
            {
                if (_carreras != value)
                {
                    _carreras = value;
                    OnPropertyChanged(nameof(Carreras));
                }
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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
