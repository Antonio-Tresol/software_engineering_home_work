using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Estudiante")]
[Index("Email", Name = "UQ__Estudian__A9D105343151A142", IsUnique = true)]
public partial class Estudiante
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Cedula { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string NombreP { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Apellido1 { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? Apellido2 { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Sexo { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime FechaNac { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? Teléfono { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Carne { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [InverseProperty("CedulaNavigation")]
    public virtual Asistente? Asistente { get; set; }

    public virtual ICollection<Carrera> Carreras { get; set; } = new HashSet<Carrera>();

}
