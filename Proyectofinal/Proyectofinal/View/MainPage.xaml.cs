using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectofinal
{
    public partial class MainPage : ContentPage
    {

        public ICommand TapCommand => new Command<string>(OpenBrowser);

        public MainPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        public void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
