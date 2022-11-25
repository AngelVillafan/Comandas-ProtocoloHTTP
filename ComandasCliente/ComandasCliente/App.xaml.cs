using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ComandasCliente.Views;

namespace ComandasCliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new VentanaComanda();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
