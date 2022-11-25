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
          new Platillo{ NombrePlatillo="SushiUno", UrlImagen="sushiuno", Comentarios="", Cantidad=0 },
          new Platillo{ NombrePlatillo="SushiDos", UrlImagen="sushidos", Comentarios="", Cantidad=0 },
          new Platillo{ NombrePlatillo="SushiTres", UrlImagen="sushidos", Comentarios="", Cantidad=0 }
        };
        public ObservableCollection<Bebida> bebidasdefinidas = new ObservableCollection<Bebida>()
        {
          new Bebida{ NombreBebida="BobaUno", UrlImagen="bobauno", Comentarios="", Cantidad=0},
          new Bebida{ NombreBebida="BobaDos", UrlImagen="bobados", Comentarios="", Cantidad=0},
          new Bebida{ NombreBebida="BobaTres", UrlImagen="bobatres", Comentarios="", Cantidad=0}
        };
        //
        public ICommand OrdenarCommand { get; set; }
        public Orden Ordencita { get; set; }
        public PrincipalViewModelcs()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("platillosdefinidos"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("bebidasdefinidas"));
            OrdenarCommand = new Command(Ordenar);
        }

        private async void Ordenar()
        {
            try
            {
                foreach (var item in platillosdefinidos)
                {
                    if (item.Cantidad > 0)
                    {
                        Ordencita.platillos.NombrePlatillo = item.NombrePlatillo;
                        Ordencita.platillos.Cantidad = item.Cantidad;
                        Ordencita.platillos.Comentarios = item.Comentarios;
                    }
                }
                foreach (var item in bebidasdefinidas)
                {
                    if (item.Cantidad > 0)
                    {
                        Ordencita.bebidas.NombreBebida = item.NombreBebida;
                        Ordencita.bebidas.Cantidad = item.Cantidad;
                        Ordencita.bebidas.Comentarios = item.Comentarios;
                    }
                }

                await cliente.PedidoPOST(Ordencita);

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}