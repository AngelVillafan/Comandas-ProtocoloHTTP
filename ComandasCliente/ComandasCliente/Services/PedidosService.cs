using Newtonsoft.Json;
using System;
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
        
        public async Task PedidoPOST(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var response = await cliente.PostAsync("pedidorecibido",
                new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}