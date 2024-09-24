using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain
{
    public class FormaPago
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public FormaPago()
        {
            
        }
        public FormaPago(int id)
        {
            Codigo = id;
        }

        public override string ToString()
        {
            return Codigo +"-"+Nombre;
        }
    }
}
