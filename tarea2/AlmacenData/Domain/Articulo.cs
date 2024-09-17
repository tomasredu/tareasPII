﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool EsActivo { get; set; }

        public override string ToString()
        {
            return Codigo + " - " + Nombre + " $" + Precio.ToString();
        }
    }
}
