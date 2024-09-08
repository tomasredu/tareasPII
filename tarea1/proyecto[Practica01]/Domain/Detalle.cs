using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain
{
    public class Detalle
    {
        public int Codigo { get; set; }
        public Articulo Articulo { get; set; }
        public int cantidad { get; set; }

        public double SubTotal()
        {
            return cantidad * Articulo.Precio;
        }

        public override string ToString()
        {
            return Articulo.ToString() + " x " + cantidad;
        }

    }
}
