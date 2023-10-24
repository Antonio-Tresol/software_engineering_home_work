using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Table("Profesor")]
[Index("Email", Name = "UQ__Profesor__A9D105348BF7A04A", IsUnique = true)]
[Index("Email", Name = "UQ__Profesor__A9D10534BB63E052", IsUnique = true)]
public partial class Profesor
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

    [StringLength(20)]
    [Unicode(false)]
    public string? Categoria { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaNomb { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Titulo { get; set; }

    public byte? Oficina { get; set; }

    [InverseProperty("CedProfNavigation")]
    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
}
