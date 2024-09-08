using Almacen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data.Interfaces
{
    public interface IFacturaRepository
    {
        void Create(Factura f);
        void Update(Factura f);
        void Delete(int id);
        IEnumerable<Factura> GetAll();
        Factura GetById(int id);

    }
}
