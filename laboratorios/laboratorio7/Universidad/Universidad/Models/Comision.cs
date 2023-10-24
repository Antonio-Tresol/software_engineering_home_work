using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Comision")]
public partial class Comision
{
    [Key]
    [StringLength(40)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Observ { get; set; }
}
