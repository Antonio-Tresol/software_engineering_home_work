using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models;

[Table("Empadronado_en")]
public partial class EmpadronadoEn
{
    [Key]
    [StringLength(10)]
    [Column("CedEstudiante")]
    [ForeignKey(nameof(Estudiante))]
    public string CedEstudiante { get; set; } = null!;

    [Key]
    [StringLength(10)]
    [Column("CodCarrera")]
    [ForeignKey(nameof(Carrera))]
    public string CodCarrera { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime? FechaIngreso { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaGraduacion { get; set; }

    [InverseProperty("EmpadronadoEns")]
    public virtual Estudiante EstudianteNavigation { get; set; } = null!;

    [InverseProperty("EmpadronadoEns")]
    public virtual Carrera CarreraNavigation { get; set; } = null!;
}
