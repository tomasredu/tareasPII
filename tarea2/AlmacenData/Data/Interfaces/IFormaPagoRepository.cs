using Almacen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data.Interfaces
{
    public interface IFormaPagoRepository
    {
        void Create(FormaPago f);
        void Update(FormaPago f);
        void Delete(int id);
        IEnumerable<FormaPago> GetAll();
    }
}
