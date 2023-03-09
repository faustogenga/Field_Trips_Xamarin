
using Proyectofinal.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal
{
    public partial class Login : ContentPage
    {
        private readonly string _dbPath;
            
        public Login()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            _dbPath = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "TodoList.db3");
        }
    }
}
