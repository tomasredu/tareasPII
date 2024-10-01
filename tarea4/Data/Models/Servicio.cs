using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Servicio
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public double Costo { get; set; }
        
        public bool EnPromocion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string? MotivoBaja { get; set; }
    }
}
