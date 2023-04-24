using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal.ViewModel
{
    class FieldTripRepoViewModel : INotifyPropertyChanged
    {
        private string _codigo;

        private List<string> _fieldTripsCodigos;
        private FieldTripRepository Repository { get; set; }

        public FieldTripRepoViewModel()
        {
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            Repository = new FieldTripRepository();
            FieldTripsCodigos = Repository.GetAllFieldTripCodigos();            
        }

        public List<string> FieldTripsCodigos
        {
            get => _fieldTripsCodigos;
            set
            {
                _fieldTripsCodigos = value;
                OnPropertyChanged();
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


        //INTERFACE
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
