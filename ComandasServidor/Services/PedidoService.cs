using ComandasCliente.Droid.Models;
using ComandasServidor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComandasServidor.Services
{
    public class PedidoService
    {
        HttpListener listener = new HttpListener();

        public PedidoService()
        {
            listener.Prefixes.Add("http://*:7777/pedidos/");
        }
        public void Iniciar()
        {
            if (!listener.IsListening)
            {
                listener.Start();
                listener.BeginGetContext(Context, null);
            }
        }
        public event Action<Bebida>? BebidaRecibida;
        public event Action<Orden>? PlatilloRecibido;

        private void Context(IAsyncResult ar)
        {
            var context = listener.EndGetContext(ar);
            listener.BeginGetContext(Context, null);
            if (context.Request.Url != null)
                if (context.Request.HttpMethod == "POST" && context.Request.Url.LocalPath == "/pedidos/pedidorecibido")
                {
                    var stream = new StreamReader(context.Request.InputStream);
                    var json = stream.ReadToEnd();
                    Orden? ordencita = JsonConvert.DeserializeObject<Orden>(json);
                    context.Response.StatusCode = 200;
                    if (ordencita.platillos != null)
                        PlatilloRecibido?.Invoke(ordencita);
                    //if (ordencita.bebidas != null)
                    //    BebidaRecibida?.Invoke(ordencita.bebidas);
                    context.Response.Close();
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Close();
                }
        }
    }
}
