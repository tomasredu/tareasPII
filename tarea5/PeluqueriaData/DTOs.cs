using PeluqueriaData.Models;

namespace PeluqueriaData.DTOs;

public record TurnoDTO
(
    int IdTurno,
    DateTime Fecha,
    string Cliente,
    DateTime? FechaBaja,
    string? MotivoBaja,
    List<DetalleTurnoDTO> Detalles
);
public record CreateTurnoDTO
(
    DateTime Fecha,
    string Cliente,
    List<CreateDetalleTurnoDTO> Detalles
);
public record UpdateTurnoDTO
(
    int IdTurno,
    DateTime Fecha,
    string Cliente,
    DateTime? FechaBaja,
    string? MotivoBaja,
    List<UpdateDetalleTurnoDTO> Detalles
);

public record ServicioDTO
(
    int IdServicio,
    string Nombre,
    double Costo,
    bool EnPromocion,
    DateTime? FechaBaja,
    string MotivoBaja
);
public record CreateServicioDTO
(
    string Nombre,
    double Costo,
    bool EnPromocion
);
public record UpdateServicioDTO
(
    int IdServicio,
    string Nombre,
    double Costo,
    bool EnPromocion,
    DateTime? FechaBaja,
    string MotivoBaja
);

public record DetalleTurnoDTO(
    int IdTurno,
    int IdServicio,
    string Observaciones,
    ServicioDTO Servicio
);
public record CreateDetalleTurnoDTO(

    int IdServicio,
    string Observaciones
);
public record UpdateDetalleTurnoDTO(
    int IdServicio,
    string Observaciones
);