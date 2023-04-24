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
using FieldTrip = Proyectofinal.Model.FieldTrip;

namespace Proyectofinal.ViewModel
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioDatabaseContext _databaseContext;

        //selected item command
        public ICommand ItemTappedCommandUser { get; set; }
        public ICommand ItemTappedCommandCareer { get; set; }
        public ICommand ItemTappedCommandFieldTrip { get; set; }

        //ADD COMMANDS

        public ICommand ShowAddCareerPopupCommand { get; private set; }

        public ICommand ShowAddFieldTripPopupCommand { get; private set; }

        //delete command
        public ICommand DeleteUserCommand { get; private set; }
        public ICommand DeleteCareerCommand { get; private set; }
        public ICommand DeleteFieldTripCommand { get; private set; }

        //edit command
        public ICommand EditUserCommand { get; private set; }

        public ICommand EditCareerCommand { get; private set; }

        public ICommand EditFieldTripCommand { get; private set; }

        //others
        public ICommand SignOutCommand { get; private set; }

        public ICommand OnCancelCommand { get; private set; }

        public ICommand BackMainCommand { get; set; }

        //lists

        private ObservableCollection<Usuario> _users { get; set; }
        private ObservableCollection<Carrera> _carrera { get; set; }
        private ObservableCollection<FieldTrip> _fieldtrip { get; set; }

        //All Objects

        private Usuario _User;

        private Carrera _Career;

        private FieldTrip _FieldTrip;


        //Selected from list view
        private Usuario _selectedUser;

        private Carrera _selectedCareer;

        private FieldTrip _selectedFieldTrip;


        public EditViewModel()
        {
            //sqllite connection
            _databaseContext = new UsuarioDatabaseContext();

            //fill lists
            Users = new ObservableCollection<Usuario>(_databaseContext.GetAllUsuarios());
            Carreras = new ObservableCollection<Carrera>(_databaseContext.GetAllCarreras());
            FieldTrips = new ObservableCollection<FieldTrip>(_databaseContext.GetAllFieldTrips());

            //Deletes
            DeleteUserCommand = new Command<Usuario>(OnDeleteUser);
            DeleteCareerCommand = new Command<Carrera>(OnDeleteCareer);
            DeleteFieldTripCommand = new Command<FieldTrip>(OnDeleteFieldTrip);

            //Edits
            EditUserCommand = new Command(async () => await OnEditUser());
            EditCareerCommand = new Command(async () => await OnEditCarreer());
            EditFieldTripCommand = new Command(async () => await OnEditFieldTrip());

            //others
            SignOutCommand = new Command(OnSignOut);
            OnCancelCommand = new Command(OnClose);
            BackMainCommand = new Command(() => { App.Current.MainPage = new View.UsuarioMainView(User); });

            //selected item command
            ItemTappedCommandUser = new Command(async () =>
            {
                App.Current.MainPage = new EditUserMain(SelectedUser);
            });

            ItemTappedCommandCareer = new Command(async () =>
            {
                App.Current.MainPage = new EditCareerMain(SelectedCareer);
            });

            ItemTappedCommandFieldTrip = new Command(async () =>
            {
                App.Current.MainPage = new EditFieldTripMain(SelectedFieldTrip);
            });

            //Add Command

            ShowAddCareerPopupCommand = new Command(async () =>
            {
                var addCareerPopupPage = new AddCareerPopupPage();
                await App.Current.MainPage.Navigation.PushPopupAsync(addCareerPopupPage);
            });

            ShowAddFieldTripPopupCommand = new Command(async () =>
            {
                App.Current.MainPage = new AddFieldTrip();
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

        public FieldTrip FieldTrip
        {
            get { return _FieldTrip; }
            set
            {
                if (_FieldTrip != value)
                {
                    _FieldTrip = value;
                    OnPropertyChanged(nameof(FieldTrip));
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
                        ItemTappedCommandUser.Execute(_selectedUser);
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

        public FieldTrip SelectedFieldTrip
        {
            get { return _selectedFieldTrip; }
            set
            {
                if (_selectedFieldTrip != value)
                {
                    _selectedFieldTrip = value;
                    OnPropertyChanged(nameof(SelectedFieldTrip));
                    ItemTappedCommandFieldTrip.Execute(_selectedFieldTrip);
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

        public ObservableCollection<FieldTrip> FieldTrips
        {
            get { return _fieldtrip; }
            set
            {
                if (_fieldtrip != value)
                {
                    _fieldtrip = value;
                    OnPropertyChanged(nameof(FieldTrips));
                }
            }
        }

        private async void OnDeleteFieldTrip(FieldTrip fieldTrip)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Confirm Deletion", $"Are you sure you want to delete field trip \n {fieldTrip.Organizacion}?", "Yes", "No");
            if (answer)
            {
                await DeleteFieldTrip(fieldTrip.Id);
                Refresh();
            }
        }

        public async Task DeleteFieldTrip(int id)
        {
            var fieldTripToDelete = _databaseContext.GetFieldTripById(id);

            if (fieldTripToDelete != null)
            {
                _databaseContext.DeleteFieldTrip(fieldTripToDelete);

                // Remove the user from the collection
                FieldTrips.Remove(fieldTripToDelete);
            }
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

        private async void OnDeleteUser(Usuario user)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Confirm Deletion", $"Are you sure you want to delete user \n {user.Nombre}?", "Yes", "No");
            if (answer)
            {
                await DeleteUser(user.Id);
                Refresh();
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

        public async Task OnEditFieldTrip()
        {
            _databaseContext.UpdateFieldTrip(FieldTrip);
            OnClose();
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
            if (App.Current.MainPage is EditFieldTripMain editFieldTripPage)
            {
                SelectedFieldTrip = null;
                App.Current.MainPage = new AdminFieldTrip();
            }
        }

        public void Refresh()
        {
            Carreras.Clear();
            Users.Clear();
            FieldTrips.Clear();
            var users = _databaseContext.GetAllUsuarios();
            var careers = _databaseContext.GetAllCarreras();
            var fieldTrips = _databaseContext.GetAllFieldTrips();
            foreach (var user in users)
            {
                Users.Add(user);
            }
            foreach (var career in careers)
            {
                Carreras.Add(career);
            }
            foreach (var fieldTrip in fieldTrips)
            {
                FieldTrips.Add(fieldTrip);
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
