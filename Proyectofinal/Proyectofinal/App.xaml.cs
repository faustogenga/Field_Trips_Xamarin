using Proyectofinal.View;
using System;
using Rg.Plugins.Popup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectofinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Login();
        }

        protected override void OnStart()
        {
            base.OnStart();


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
