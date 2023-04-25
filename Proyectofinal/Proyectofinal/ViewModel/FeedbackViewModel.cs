using Proyectofinal.DAL;
using Proyectofinal.View;
using Proyectofinal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace Proyectofinal.ViewModel
{
    class FeedbackViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext MyDal;
        public FieldTripRepository Repository { get; set; }

        private string _selectedFieldTrip;
        public Usuario _User;
                private List<string> _fieldtrips;
        //Register
        public ICommand AddFeedbackCommand { get; set; }
        public bool isFeedbackButtonEnabled = true;
        public string ErrorMessage { get; set; }

        //List
        private ObservableCollection<Feedback> _feedbackList { get; set; }
        private ObservableCollection<FieldTrip> _fieldTripList { get; set; }
        //Other
        public ICommand NewFeedbackCommand { get; set; }
        public ICommand BackMainCommand { get; set; }

        public ICommand AllCommand { get; set; }
        //Delete
        public ICommand DeleteFeedbackCommand { get; private set; }

        public FeedbackViewModel()
        {
            MyDal = new UsuarioDatabaseContext();
            Repository = new FieldTripRepository();

            //fill lists

            Feedbacks = new ObservableCollection<Feedback>(MyDal.GetAllFeedbacks());
            FieldTrips = Repository.GetAllFieldTripOrganizacion();


            NewFeedbackCommand = new Command(() =>
            {
                App.Current.MainPage = new AddFeedback(User);
            });
            BackMainCommand = new Command(() =>
            {
                App.Current.MainPage = new UsuarioMainView(User);
            });
            AllCommand = new Command(() =>
            {
                All();
            });

        }

        public string SelectedFieldTrip
        {
            get { return _selectedFieldTrip; }
            set
            {
                _selectedFieldTrip = value;
                OnPropertyChanged();
                if(_selectedFieldTrip != null)
                {
                    Feedbacks.Clear();
                    var feedbacks = MyDal.GetAllFeedbacks();
                    foreach (var feedback in feedbacks)
                    {
                        if (feedback.OrganizacionFieldTrip == _selectedFieldTrip)
                        {
                            Feedbacks.Add(feedback);
                        }
                    }
                }

            }
        }
        public Usuario User
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged();
            }
        }


        //Refresh

        public void All()
        {
            SelectedFieldTrip = null;
            Feedbacks.Clear();
            var feedbacks = MyDal.GetAllFeedbacks();
            foreach (var feedback in feedbacks)
            {
                Feedbacks.Add(feedback);
            }
        }

        
        public ObservableCollection<Feedback> Feedbacks
        {
            get { return _feedbackList; }
            set
            {
                if (_feedbackList != value)
                {
                    _feedbackList = value;
                    OnPropertyChanged(nameof(Feedbacks));
                }
            }
        }

        public List<string> FieldTrips
        {
            get => _fieldtrips;
            set
            {
                _fieldtrips = value;
                OnPropertyChanged();
            }
        }


        //Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
