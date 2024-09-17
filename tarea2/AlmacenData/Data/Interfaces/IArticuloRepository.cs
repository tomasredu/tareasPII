using Almacen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data.Interfaces
{
    public interface IArticuloRepository
    {
        void Create(Articulo a);
        void Update(Articulo a);
        void Delete(int id);
        IEnumerable<Articulo> GetAll();
        
    }
}
