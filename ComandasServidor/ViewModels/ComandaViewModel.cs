using ComandasServidor.Models;
using ComandasServidor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandasServidor.ViewModels
{
    public class ComandaViewModel : INotifyPropertyChanged
    {
        PedidoService server = new PedidoService();
        public ObservableCollection<Platillo> platillos = new ObservableCollection<Platillo>();
        public ObservableCollection<Bebida> bebidas = new ObservableCollection<Bebida>();
        public ComandaViewModel()
        {
            Iniciar();
            server.BebidaRecibida += Server_BebidaRecibida;
            server.PlatilloRecibido += Server_PlatilloRecibido;
        }

        private void Server_PlatilloRecibido(Models.Platillo obj)
        {
            //Falta validar, o validamos aqui o validamos en el service
            platillos.Add(obj);
            Actualizar();
        }

        private void Server_BebidaRecibida(Models.Bebida obj)
        {
            //Falta validar, o validamos aqui o validamos en el service
            bebidas.Add(obj);
            Actualizar();
        }

        private void Iniciar()
        {
            server.Iniciar();
            Actualizar();
        }

        private void Actualizar(string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
