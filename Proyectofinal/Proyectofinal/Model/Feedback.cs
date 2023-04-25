using SQLite;
using System.ComponentModel;

namespace Proyectofinal.Model
{
    public class Feedback : INotifyPropertyChanged
    {
        private int _id;
        private string _codigoFieldTrip;
        private string _feedbackInfo;
        private string _OrganizacionFieldTrip;

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

        public string OrganizacionFieldTrip
        {
            get => _OrganizacionFieldTrip;
            set
            {
                if (_OrganizacionFieldTrip != value)
                {
                    _OrganizacionFieldTrip = value;
                    OnPropertyChanged(nameof(OrganizacionFieldTrip));
                }
            }
        }

        public string CodigoFieldTrip
        {
            get => _codigoFieldTrip;
            set
            {
                if (_codigoFieldTrip != value)
                {
                    _codigoFieldTrip = value;
                    OnPropertyChanged(nameof(CodigoFieldTrip));
                }
            }
        }

        public string FeedbackInfo
        {
            get => _feedbackInfo;
            set
            {
                if (_feedbackInfo != value)
                {
                    _feedbackInfo = value;
                    OnPropertyChanged(nameof(FeedbackInfo));
                }
            }
        }

        //Inteface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
