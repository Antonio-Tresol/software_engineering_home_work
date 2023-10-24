using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[PrimaryKey("SiglaCurso", "NumGrupo", "Semestre", "Anno")]
[Table("Grupo")]
public partial class Grupo
{
    [Key]
    [StringLength(8)]
    [Unicode(false)]
    public string SiglaCurso { get; set; } = null!;

    [Key]
    public byte NumGrupo { get; set; }

    [Key]
    public byte Semestre { get; set; }

    [Key]
    public int Anno { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string CedProf { get; set; } = null!;

    public byte Carga { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CedAsist { get; set; }

    [ForeignKey("CedAsist")]
    [InverseProperty("Grupos")]
    public virtual Asistente? CedAsistNavigation { get; set; }

    [ForeignKey("CedProf")]
    [InverseProperty("Grupos")]
    public virtual Profesor CedProfNavigation { get; set; } = null!;

    [ForeignKey("SiglaCurso")]
    [InverseProperty("Grupos")]
    public virtual Curso SiglaCursoNavigation { get; set; } = null!;
}
