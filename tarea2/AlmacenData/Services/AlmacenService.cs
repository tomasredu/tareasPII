using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Data;
using Almacen.Data.Implementations;
using Almacen.Domain;
using AlmacenData.Services;

namespace Almacen.Services
{
    public class AlmacenService : IAlmacenService
    {
        private ConnectionFactory _factory;
        private DataContext _dataContext;

        private FacturaRepository _facturaRepository;
        private ArticuloRepository _articuloRepository;
        private FormaPagoRepository _formaPagoRepository;

        public AlmacenService()
        {
            _factory = new ConnectionFactory();
            _dataContext = new DataContext(_factory);

            _facturaRepository = new FacturaRepository(_dataContext);
            _articuloRepository = new ArticuloRepository(_dataContext);
            _formaPagoRepository = new FormaPagoRepository(_dataContext);
        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            return _facturaRepository.GetAll();
        }

        public Factura GetFacturaById(int id)
        {
            return _facturaRepository.GetById(id);
        }

        public IEnumerable<Articulo> GetAllArticulos()
        {
            return _articuloRepository.GetAll();
        }

        public IEnumerable<FormaPago> GetAllFormasPagos()
        {
            return _formaPagoRepository.GetAll();
        }

        public void AddFactura(Factura factura)
        {
            _facturaRepository.Create(factura);
        }

        public void AddArticulo(Articulo articulo)
        {
            _articuloRepository.Create(articulo);
        }
        public void AddFormaPago(FormaPago formaPago)
        {
            _formaPagoRepository.Create(formaPago);
        }

        public void DeleteFactura(int id)
        {
            _facturaRepository.Delete(id);
        }

        public void DeleteArticulo(int id)
        {
            _articuloRepository.Delete(id);
        }

        public void DeleteFormaPago(int id)
        {
            _formaPagoRepository.Delete(id);
        }

        public void UpdateFactura(Factura factura)
        {
            _facturaRepository.Update(factura);
        }

        public void UpdateArticulo(Articulo articulo)
        {
            _articuloRepository.Update(articulo);
        }

        public void UpdatePrices(double aumento)
        {
            _articuloRepository.UpdatePrice(aumento);
        }
        public void UpdateFormaPago(FormaPago formaPago)
        {
            _formaPagoRepository.Update(formaPago);
        }

        public DataContext GetContext()
        {
            return _dataContext;
        }

        public Articulo GetArticuloById(int id)
        {
            return _articuloRepository.GetById(id);
        }
    }
}
