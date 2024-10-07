using PeluqueriaData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Models
{
    public static class EntityExtensions
    {
        public static ServicioDTO ToDto(this TServicio servicio)
        {
            return new ServicioDTO(
                servicio.IdServicio,
                servicio.Nombre,
                servicio.Costo,
                servicio.EnPromocion,
                servicio.FechaBaja,
                servicio.MotivoBaja
            );
        }
        public static TurnoDTO ToDto(this TTurno turno)
        {
            return new TurnoDTO(
                turno.IdTurno,
                turno.Fecha,
                turno.Cliente,
                turno.FechaBaja,
                turno.MotivoBaja,
                turno.TDetallesTurnos.Select(dt => dt.ToDto()).ToList()
            );
        }

        public static DetalleTurnoDTO ToDto(this TDetalleTurno detalle)
        {
            return new DetalleTurnoDTO(
                detalle.IdTurno,
                detalle.IdServicio,
                detalle.Observaciones,
                detalle.IdServicioNavigation.ToDto()
            );
        }

        public static bool IsValid(this CreateServicioDTO servicio)
        {
            return servicio.Costo > 0 && !string.IsNullOrEmpty(servicio.Nombre);
        }
        public static bool IsValid(this CreateDetalleTurnoDTO detalle)
        {
            return !string.IsNullOrEmpty(detalle.Observaciones);
        }

        public static bool IsValid(this CreateTurnoDTO turno)
        {
            List<int> list = new List<int>();
            bool hasRepeatService = false;
            foreach( CreateDetalleTurnoDTO det in turno.Detalles)
            {
                if(list.Any(i => i.Equals(det.IdServicio)))
                {
                    hasRepeatService = true;
                    break;
                }
                list.Add(det.IdServicio);
            }
            return turno.Detalles.Count > 0 
                && turno.Detalles.Where(d => d.IsValid()).Any()
                && turno.Fecha.Date > DateTime.Now.Date && turno.Fecha <= DateTime.Now.AddDays(45).Date
                && !hasRepeatService;
        }

        public static bool IsValid(this UpdateTurnoDTO turno)
        {
            List<int> list = new List<int>();
            bool hasRepeatService = false;
            foreach (UpdateDetalleTurnoDTO det in turno.Detalles)
            {
                if (list.Select(i => i.Equals(det.IdServicio)).Any())
                {
                    hasRepeatService = true;
                    break;
                }
                list.Add(det.IdServicio);
            }
            return turno.Detalles.Count > 0
                && turno.Detalles.Where(d => !string.IsNullOrEmpty(d.Observaciones)).Any()
                && turno.Fecha.Date > DateTime.Now.Date && turno.Fecha <= DateTime.Now.AddDays(45).Date
                && !hasRepeatService;
        }

    }
}
