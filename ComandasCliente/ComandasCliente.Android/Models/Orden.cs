using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ComandasServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComandasCliente.Droid.Models
{
    public class Orden
    {
        public string Mesero { get; set; } = "Hector Padilla";
        public int Mesa { get; set; }
        public Bebida bebidas { get; set; }
        public Platillo platillos { get; set; }
    }
}