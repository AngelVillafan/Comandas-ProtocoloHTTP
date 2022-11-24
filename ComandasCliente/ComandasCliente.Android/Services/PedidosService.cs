using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComandasCliente.Droid.Services
{
    public class PedidosService
    {
        HttpClient cliente = new HttpClient();
        public PedidosService()
        {
            cliente.BaseAddress = new Uri("http://localhost:4999/pedidos/");
        }
        /* Falta por terminar ViewModel del apartado del cliente*/
        public async Task PedidoPOST(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var response = await cliente.PostAsync("pedidorecibido",
                new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}