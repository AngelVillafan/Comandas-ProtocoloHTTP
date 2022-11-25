using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandasServidor.Models
{
    public class Bebida
    {
        public string NombreBebida{ get; set; } = "";
        public string UrlImagen { get; set; } = "";
        public int Cantidad { get; set; } = 0;
        public string Comentarios { get; set; } = "";
    }
}
