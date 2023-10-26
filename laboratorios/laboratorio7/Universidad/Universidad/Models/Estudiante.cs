﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

[Index("Email", Name = "UQ__Estudian__A9D105343151A142", IsUnique = true)]
public partial class Estudiante
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Cedula { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [StringLength(15)]
    [Unicode(false)]
    public string NombreP { get; set; }

    [Required]
    [StringLength(15)]
    [Unicode(false)]
    public string Apellido1 { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Apellido2 { get; set; }

    [Required]
    [StringLength(1)]
    [Unicode(false)]
    public string Sexo { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaNac { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Direccion { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string Teléfono { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Carne { get; set; }

    [Required]
    [StringLength(8)]
    [Unicode(false)]
    public string Estado { get; set; }

    [InverseProperty("CedulaNavigation")]
    public virtual Asistente Asistente { get; set; }

    [InverseProperty("CedEstudianteNavigation")]
    public virtual ICollection<Empadronado_en> Empadronado_en { get; set; } = new List<Empadronado_en>();

    [InverseProperty("CedEstudianteNavigation")]
    public virtual ICollection<Lleva> Lleva { get; set; } = new List<Lleva>();
}