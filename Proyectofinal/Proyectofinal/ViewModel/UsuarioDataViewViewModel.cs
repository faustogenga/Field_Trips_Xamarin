using Proyectofinal.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class UsuarioDataViewViewModel : INotifyPropertyChanged
    {
        public ICommand BackMainCommand { get; set; }


        public Usuario _User;
        public UsuarioDataViewViewModel()
        {
            BackMainCommand = new Command(() =>
            {
                App.Current.MainPage = new View.UsuarioMainView(User);

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
