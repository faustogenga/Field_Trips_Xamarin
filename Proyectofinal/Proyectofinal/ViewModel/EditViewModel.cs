using Proyectofinal.DAL;
using Proyectofinal.Model;
using Proyectofinal.View;
using Proyectofinal.View.PopUp;
using Rg.Plugins.Popup.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal.ViewModel
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext _databaseContext;

        public ICommand ItemTappedCommandUser { get; set; }

        public ICommand ItemTappedCommandCareer { get; set; }
        public ICommand DeleteUserCommand { get; private set; }

        public ICommand EditUserCommand { get; private set; }

        public ICommand EditCareerCommand { get; private set; }

        public ICommand DeleteCareerCommand { get; private set; }

        public ICommand DeleteTripCommand { get; private set; }

        public ICommand SignOutCommand { get; private set; }

        public ICommand ShowAddCareerPopupCommand { get; private set; }

        public ICommand OnCancelCommand { get; private set; }

        private ObservableCollection<Usuario> _users { get; set; }
        private ObservableCollection<Carrera> _carrera { get; set; }

        private ObservableCollection<Usuario> _trip { get; set; }

        private Usuario _User;

        private Carrera _Career;

        private Usuario _selectedUser;

        private Carrera _selectedCareer;

        private Usuario _selectedTrip;





        public EditViewModel()
        {
           
            _databaseContext = new UsuarioDatabaseContext();

            Users = new ObservableCollection<Usuario>(_databaseContext.GetAllUsuarios());
            Carreras = new ObservableCollection<Carrera>(_databaseContext.GetAllCarreras());

            DeleteUserCommand = new Command<Usuario>(OnDeleteUser);

            EditUserCommand = new Command(async () => await OnEditUser());

            EditCareerCommand = new Command(async () => await OnEditCarreer());

            DeleteCareerCommand = new Command<Carrera>(OnDeleteCareer);

            SignOutCommand = new Command(OnSignOut);
            OnCancelCommand = new Command(OnClose);

            ItemTappedCommandUser = new Command(async () =>
            {
                App.Current.MainPage = new EditUserMain(SelectedUser);
            });

            ItemTappedCommandCareer = new Command(async () =>
            {
                App.Current.MainPage = new EditCareerMain(SelectedCareer);
            });


            ShowAddCareerPopupCommand = new Command(async () =>
            {
                var addCareerPopupPage = new AddCareerPopupPage();
                await App.Current.MainPage.Navigation.PushPopupAsync(addCareerPopupPage);
            });

        }
        public Usuario User
        {
            get { return _User; }
            set
            {
                if (_User != value)
                {
                    _User = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public Carrera Career
        {
            get { return _Career; }
            set
            {
                if (_Career != value)
                {
                    _Career = value;
                    OnPropertyChanged(nameof(Career));
                }
            }
        }

        public Usuario SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                    if (_selectedUser != null)
                    {
                        ItemTappedCommandUser.Execute(SelectedUser);
                    }
                }
            }
        }

        public Carrera SelectedCareer
        {
            get { return _selectedCareer; }
            set
            {
                if (_selectedCareer != value)
                {
                    _selectedCareer = value;
                    OnPropertyChanged(nameof(SelectedCareer));
                    ItemTappedCommandCareer.Execute(_selectedCareer);
                }
            }
        }
        

        public ObservableCollection<Carrera> Carreras
        {
            get { return _carrera; }
            set
            {
                if (_carrera != value)
                {
                    _carrera = value;
                    OnPropertyChanged(nameof(Carreras));
                }
            }
        }

        public ObservableCollection<Usuario> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        private async void OnDeleteUser(Usuario user)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Confirm Deletion", $"Are you sure you want to delete user \n {user.Nombre}?", "Yes", "No");
            if (answer)
            {
                await DeleteUser(user.Id);
                Refresh();
            }
        }
        public async Task OnEditUser()
        {
            _databaseContext.UpdateUsuario(User);
            OnClose();
        }

        public async Task OnEditCarreer()
        {
            _databaseContext.UpdateCarrera(Career);
            OnClose();
        }

        private async void OnDeleteCareer(Carrera carrera)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Confirm Deletion", $"Are you sure you want to delete career \n {carrera.Nombre}?", "Yes", "No");
            if (answer)
            {
                await DeleteCareer(carrera.Id);
                Refresh();
            }
        }

        private void OnSignOut()
        {
            App.Current.MainPage = new Login();
        }

        private async void OnClose()
        {
            if (App.Current.MainPage is EditUserMain editUserPage)
            {
                SelectedUser = null;
                App.Current.MainPage = new AdminUsers();
            }
            if (App.Current.MainPage is EditCareerMain editCareerPage)
            {
                SelectedCareer= null;
                App.Current.MainPage = new AdminCareers();
            }
        }


        public async Task DeleteUser(int id)
        {
            var userToDelete = _databaseContext.GetUsuarioById(id);

            if (userToDelete != null)
            {
                _databaseContext.DeleteUsuario(userToDelete);

                // Remove the user from the collection
                Users.Remove(userToDelete);
            }
        }

        public async Task DeleteCareer(int id)
        {
            var careerToDelete = _databaseContext.GetCarreraById(id);

            if (careerToDelete != null)
            {
                _databaseContext.DeleteCarrera(careerToDelete);

                // Remove the user from the collection
                Carreras.Remove(careerToDelete);
            }
        }

        public void Refresh()
        {
            Carreras.Clear();
            Users.Clear();
            var users = _databaseContext.GetAllUsuarios();
            var careers = _databaseContext.GetAllCarreras();
            foreach (var user in users)
            {
                Users.Add(user);
            }
            foreach (var career in careers)
            {
                Carreras.Add(career);
            }
        }

        public void AdminMainView()
        {
            App.Current.MainPage = new AdminMain();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
