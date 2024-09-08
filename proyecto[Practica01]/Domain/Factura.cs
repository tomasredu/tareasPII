using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain
{
    public class Factura
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public string Cliente { get; set; }

        public IEnumerable<Detalle> Detalles { get; set; }
        public Factura() { }

        public override string ToString()
        {
            string total = string.Empty;
            total += "Factura " + Codigo + " - " + Fecha + " - " + Cliente + "\n";
            foreach (var detalle in Detalles)
            {
                total += detalle.ToString() + "\n";
            }
            total += "IMPORTE TOTAL: $" + GetTotal() + "\n";

            return total;
        }

        public double GetTotal()
        {
            double aux = 0;
            foreach (var item in Detalles)
            {
                aux += item.SubTotal();
            }
            return aux;
        }

    }
}
