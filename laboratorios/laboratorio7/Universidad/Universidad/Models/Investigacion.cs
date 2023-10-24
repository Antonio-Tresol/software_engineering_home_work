using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Investigacion")]
public partial class Investigacion
{
    [Key]
    [StringLength(15)]
    [Unicode(false)]
    public string NumProy { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Area { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaInicio { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaFin { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }
}
