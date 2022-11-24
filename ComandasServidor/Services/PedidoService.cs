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
            listener.Prefixes.Add("http://*:4999/pedidos");
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
        public event Action<Platillo>? PlatilloRecibido;

        private void Context(IAsyncResult ar)
        {
            var context = listener.EndGetContext(ar);
            listener.BeginGetContext(Context, null);
            if (context.Request.Url != null)
                if (context.Request.HttpMethod == "POST" && context.Request.Url.LocalPath == "/pedidos/pedidorecibido")
                {
                    var stream = new StreamReader(context.Request.InputStream);
                    var json = stream.ReadToEnd();
                    Platillo? platillo = JsonConvert.DeserializeObject<Platillo>(json);
                    Bebida? bebida = JsonConvert.DeserializeObject<Bebida>(json);
                    context.Response.StatusCode = 200;
                    if (platillo != null)
                        PlatilloRecibido?.Invoke(platillo);
                    if (bebida != null)
                        BebidaRecibida?.Invoke(bebida);
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
