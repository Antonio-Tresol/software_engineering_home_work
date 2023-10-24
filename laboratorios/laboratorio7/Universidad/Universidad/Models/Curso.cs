using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Curso")]
public partial class Curso
{
    [Key]
    [StringLength(8)]
    [Unicode(false)]
    public string Sigla { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public byte Creditos { get; set; }

    [InverseProperty("SiglaCursoNavigation")]
    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
    public virtual ICollection<Carrera> Carreras { get; set; } = new HashSet<Carrera>();
}
