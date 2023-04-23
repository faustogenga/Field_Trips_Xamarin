using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class UsuarioDataViewViewModel : INotifyPropertyChanged
    {
        public ICommand BackMainCommand { get; set; }

        public UsuarioDataViewViewModel()
        {
            BackMainCommand = new Command(() =>
            {
                App.Current.MainPage = new View.UsuarioMainView();

            });
        }

        //Interface

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
