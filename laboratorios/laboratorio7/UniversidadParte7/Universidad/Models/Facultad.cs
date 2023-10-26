﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

public partial class Facultad
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Codigo { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; }

    [InverseProperty("CodFacultadNavigation")]
    public virtual ICollection<Escuela> Escuela { get; set; } = new List<Escuela>();
}