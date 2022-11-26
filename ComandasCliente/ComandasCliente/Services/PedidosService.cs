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
            cliente.BaseAddress = new Uri("https://c98c-187-209-229-220.ngrok.io/pedidos/");
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