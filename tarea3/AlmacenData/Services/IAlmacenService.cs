using Almacen.Data;
using Almacen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenData.Services
{
    public interface IAlmacenService
    {
        public IEnumerable<Factura> GetAllFacturas();
        public Factura GetFacturaById(int id);
        public IEnumerable<Articulo> GetAllArticulos();
        public IEnumerable<FormaPago> GetAllFormasPagos();
        public void AddFactura(Factura factura);
        public void AddArticulo(Articulo articulo);
        public void AddFormaPago(FormaPago formaPago);
        public void DeleteFactura(int id);
        public void DeleteArticulo(int id);
        public void DeleteFormaPago(int id);
        public void UpdateFactura(Factura factura);
        public void UpdateArticulo(Articulo articulo);
        public void UpdatePrices(double aumento);
        public void UpdateFormaPago(FormaPago formaPago);
        public DataContext GetContext();
        public IEnumerable<Factura> GetFacturas(int? idForma, DateTime? fecha);
    }
}
