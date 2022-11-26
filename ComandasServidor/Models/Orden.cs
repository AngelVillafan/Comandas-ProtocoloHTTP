using ComandasServidor.Models;
using System;
using System.Collections.Generic;

namespace ComandasCliente.Droid.Models
{
    public class Orden
    {
        public string Mesero { get; set; } = "Luis Miguel";
        public int Mesa { get; set; } = 0;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Platillo platillos { get; set; } = new Platillo();
        public Bebida bebidas { get; set; } = new Bebida();
    }
}