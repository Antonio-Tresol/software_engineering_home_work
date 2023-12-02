﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[PrimaryKey("CedEstudiante", "SiglaCurso", "NumGrupo", "Semestre", "Anno")]
public partial class Lleva
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string CedEstudiante { get; set; }

    [Key]
    [StringLength(8)]
    [Unicode(false)]
    public string SiglaCurso { get; set; }

    [Key]
    public byte NumGrupo { get; set; }

    [Key]
    public byte Semestre { get; set; }

    [Key]
    public int Anno { get; set; }

    public double? Nota { get; set; }

    [ForeignKey("CedEstudiante")]
    [InverseProperty("Lleva")]
    public virtual Estudiante CedEstudianteNavigation { get; set; }

    [ForeignKey("SiglaCurso, NumGrupo, Semestre, Anno")]
    [InverseProperty("Lleva")]
    public virtual Grupo Grupo { get; set; }
}