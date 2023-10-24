using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Carrera")]
public partial class Carrera
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime? AnnoCreacion { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string CodEscuela { get; set; } = null!;

    [ForeignKey("CodEscuela")]
    [InverseProperty("Carreras")]
    public virtual Escuela CodEscuelaNavigation { get; set; } = null!;

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new HashSet<Estudiante>();

    public virtual ICollection<Curso> Cursos { get; set; } = new HashSet<Curso>();
}
