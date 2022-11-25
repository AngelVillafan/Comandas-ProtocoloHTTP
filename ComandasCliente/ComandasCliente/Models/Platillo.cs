using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandasServidor.Models
{
    public class Platillo
    {
        public string NombrePlatillo { get; set; } = "";
        public string Comentarios { get; set; } = "";
        public string UrlImagen { get; set; }
        public int Cantidad { get; set; }
    }
}
