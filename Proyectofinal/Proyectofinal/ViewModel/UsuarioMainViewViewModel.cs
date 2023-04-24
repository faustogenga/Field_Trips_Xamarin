using Proyectofinal.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class UsuarioMainViewViewModel : INotifyPropertyChanged
    {
        public ICommand FieldTripCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand FeedbackCommand { get; set; }

        public Usuario _User;

        public UsuarioMainViewViewModel()
        {
            FieldTripCommand = new Command(() =>
            {
                App.Current.MainPage = new View.UserFieldTripView();

            });

            UserCommand = new Command(() =>
            {
                App.Current.MainPage = new View.UsuarioDataView(User);

            });
            FeedbackCommand = new Command(() =>
            {
                App.Current.MainPage = new View.FeedbackMain();

            });
            
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


        //Interface

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
}
