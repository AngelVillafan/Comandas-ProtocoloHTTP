using ComandasServidor.Models;
using System;

namespace ComandasCliente.Droid.Models
{
    public class Orden
    {
        public string Mesero { get; set; } = "Hector Padilla";
        public int Mesa { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;
        public Bebida? bebidas { get; set; }
        public Platillo? platillos { get; set; }
    }
}