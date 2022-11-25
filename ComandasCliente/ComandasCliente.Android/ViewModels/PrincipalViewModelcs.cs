using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ComandasCliente.Droid.Models;
using ComandasCliente.Droid.Services;
using ComandasServidor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ComandasCliente.Droid.ViewModels
{
    public class PrincipalViewModelcs : INotifyPropertyChanged
    {
        PedidosService cliente = new PedidosService();
        public string Error = "";
        public ObservableCollection<Platillo> platillosdefinidos = new ObservableCollection<Platillo>()
        {
          new Platillo{ NombrePlatillo="Hot Dog", UrlImagen="/source/limoncito", Comentarios=""},
          new Platillo{ NombrePlatillo="Pizza", UrlImagen="/source/pizza", Comentarios=""},
        };
        //
        public ICommand OrdenarCommand { get; set; }
        public Orden Ordencita { get; set; }
        public PrincipalViewModelcs()
        {
            OrdenarCommand = new Command<Orden>(Ordenar);
        }

        private async void Ordenar(Orden obj)
        {
            try
            {
                await cliente.PedidoPOST(obj);

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}