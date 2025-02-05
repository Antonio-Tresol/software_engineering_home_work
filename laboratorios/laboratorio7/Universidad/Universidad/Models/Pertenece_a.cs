﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[PrimaryKey("SiglaCurso", "CodCarrera")]
public partial class Pertenece_a
{
    [Key]
    [StringLength(8)]
    [Unicode(false)]
    public string SiglaCurso { get; set; }

    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string CodCarrera { get; set; }

    public byte? NivelPlanEstudios { get; set; }

    [ForeignKey("CodCarrera")]
    [InverseProperty("Pertenece_a")]
    public virtual Carrera CodCarreraNavigation { get; set; }

    [ForeignKey("SiglaCurso")]
    [InverseProperty("Pertenece_a")]
    public virtual Curso SiglaCursoNavigation { get; set; }
}