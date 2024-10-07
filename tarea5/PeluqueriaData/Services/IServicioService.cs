using PeluqueriaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Services
{
    public interface IServicioService
    {
        Task<bool> Cancelar(int id, string motivo);
        Task<bool> Agregar(TServicio servicio);
        Task<List<TServicio>> GetServicios();
        Task<List<TServicio>> GetServiciosCosto(int costo);
        Task<List<TServicio>> GetServiciosNombre(string nombre);
        Task<List<TServicio>> GetServiciosBaja(int dias);
        Task<TServicio?> GetServicio(int id);
        Task<bool> Modificar(TServicio servicio);
    }
}
