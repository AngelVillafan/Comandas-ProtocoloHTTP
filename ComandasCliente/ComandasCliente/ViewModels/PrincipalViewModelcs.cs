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
        public ObservableCollection<Platillo> Platillosdefinidos { get; set; } = new ObservableCollection<Platillo>()
        {
          new Platillo{ NombrePlatillo="SushiUno", UrlImagen="sushiuno.jpg", Comentarios="", Cantidad=0 },
          new Platillo{ NombrePlatillo="SushiDos", UrlImagen="sushidos.jpg", Comentarios="", Cantidad=0 },
          new Platillo{ NombrePlatillo="SushiTres", UrlImagen="sushidos.jpg", Comentarios="", Cantidad=0 }
        };
        public ObservableCollection<Bebida> Bebidasdefinidas { get; set; } = new ObservableCollection<Bebida>() 
        {
          new Bebida{ NombreBebida="BobaUno", UrlImagen="bobauno", Comentarios="", Cantidad=0},
          new Bebida{ NombreBebida="BobaDos", UrlImagen="bobados", Comentarios="", Cantidad=0},
          new Bebida{ NombreBebida="BobaTres", UrlImagen="bobatres", Comentarios="", Cantidad=0}
        };

        


        //
        public ICommand OrdenarCommand { get; set; }
        public Orden Ordencita { get; set; } = new Orden();

        public PrincipalViewModelcs()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Platillosdefinidos)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("bebidasdefinidas"));


            OrdenarCommand = new Command(Ordenar);
        }

        private async void Ordenar()
        {
            try
            {
                
                foreach (var item in Platillosdefinidos)
                {
                    
                    if (item.Cantidad > 0)
                    {
                        
                        Ordencita.platillos.NombrePlatillo = item.NombrePlatillo;
                        Ordencita.platillos.Cantidad = item.Cantidad;
                        Ordencita.platillos.Comentarios = item.Comentarios;
                    }
                }
                foreach (var item in Bebidasdefinidas)
                {
                    if (item.Cantidad > 0)
                    {
                        Ordencita.bebidas.NombreBebida = item.NombreBebida;
                        Ordencita.bebidas.Cantidad = item.Cantidad;
                        Ordencita.bebidas.Comentarios = item.Comentarios;
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ordencita)));
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