using ComandasCliente.Droid.Models;
using ComandasServidor.Models;
using ComandasServidor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ComandasServidor.ViewModels
{
    public class ComandaViewModel : INotifyPropertyChanged
    {
        PedidoService server = new PedidoService();
        private Platillo? platillos;

        public Platillo? Platillos
        {
            get { return platillos; }
            set
            {
                platillos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Platillos)));
            }
        }
        private Bebida? bebidas;

        public Bebida? Bebidas
        {
            get { return bebidas; }
            set
            {
                bebidas = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bebidas)));
            }
        }
        private Orden? orden;

        public Orden? Ordencita
        {
            get { return orden; }
            set
            {
                orden = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ordencita)));
            }
        }
        Dispatcher dispatcher;
        public ObservableCollection<Orden> Ordenes { get; set; } = new ObservableCollection<Orden>();
        public ComandaViewModel()
        {
            Iniciar();
            dispatcher=Dispatcher.CurrentDispatcher;
            //server.BebidaRecibida += Server_BebidaRecibida;
            server.PlatilloRecibido += Server_PlatilloRecibido;
        }

        private void Server_PlatilloRecibido(Orden obj)
        {
            //Falta validar, o validamos aqui o validamos en el service

            dispatcher.BeginInvoke(() =>
            {
                Platillos = obj.platillos;
                Bebidas = obj.bebidas;
                Actualizar();
            });
        }

        //private void Server_BebidaRecibida(Models.Bebida obj)
        //{
        //    //Falta validar, o validamos aqui o validamos en el service
        //    dispatcher.BeginInvoke(() =>
        //    {
        //        Bebidas = obj;
        //        Actualizar();
        //    });
        //}

        private void Iniciar()
        {
            server.Iniciar();
            Actualizar();
        }

        private void Actualizar(string? name = null)
        {
            
            Ordenes.Add(new Orden { platillos = Platillos, bebidas = Bebidas });
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ordenes)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
