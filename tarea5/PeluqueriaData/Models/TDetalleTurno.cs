﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PeluqueriaData.Models;

public partial class TDetalleTurno
{
    public int IdTurno { get; set; }

    public int IdServicio { get; set; }

    public string Observaciones { get; set; }

    public virtual TServicio IdServicioNavigation { get; set; }
    [JsonIgnore]
    public virtual TTurno IdTurnoNavigation { get; set; }
}