using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Escuela")]
public partial class Escuela
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string CodFacultad { get; set; } = null!;

    [InverseProperty("CodEscuelaNavigation")]
    public virtual ICollection<Carrera> Carreras { get; set; } = new List<Carrera>();

    [ForeignKey("CodFacultad")]
    [InverseProperty("Escuelas")]
    public virtual Facultad CodFacultadNavigation { get; set; } = null!;
}
