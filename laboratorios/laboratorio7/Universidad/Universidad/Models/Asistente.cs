using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Asistente")]
public partial class Asistente
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Cedula { get; set; } = null!;

    public byte? NumHoras { get; set; }

    [ForeignKey("Cedula")]
    [InverseProperty("Asistente")]
    public virtual Estudiante CedulaNavigation { get; set; } = null!;

    [InverseProperty("CedAsistNavigation")]
    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
}
