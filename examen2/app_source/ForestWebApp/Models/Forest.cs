using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForestWebApp.Models;

/// <summary>
///     a Forest information
/// </summary>
public class Forest
{
    /// <summary>
    ///     An unique identifier
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    ///     The forest's name
    /// </summary>
    [Required(ErrorMessage = "El nombre del bosque es obligatorio.")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "La longitud del nombre debe estar entre 1 y 60 caracteres.")]
    [Display(Name = "Nombre")]
    public string Name { get; set; } = "";

    /// <summary>
    ///     The country where the forest is located
    /// </summary>
    [Required(ErrorMessage = "El país de origen es obligatorio.")]
    [StringLength(60, MinimumLength = 1,
        ErrorMessage = "La longitud del país de origen debe estar entre 1 y 60 caracteres.")]
    [Display(Name = "País de Origen")]
    public string CountryOfOrigin { get; set; } = "";

    /// <summary>
    ///     The Forest's vegetation type
    /// </summary>
    [Required(ErrorMessage = "El tipo de vegetación es obligatorio.")]
    [StringLength(60, MinimumLength = 1,
        ErrorMessage = "La longitud del tipo de vegetación debe estar entre 1 y 60 caracteres.")]
    [Display(Name = "Tipo de Vegetación")]
    public string TypeOfVegetation { get; set; } = "";

    /// <summary>
    ///     The forest's area in square kilometers
    /// </summary>
    [Required(ErrorMessage = "El área en kilómetros cuadrados es obligatoria.")]
    [Display(Name = "Área (Km²)")]
    public int AreaKm2 { get; set; } = 0;

    /// <summary>
    ///     Indicates
    /// </summary>
    [Required(ErrorMessage = "Es necesario indicar si es un bosque primario.")]
    [Display(Name = "Bosque Primario")]
    public bool OldGrowthForest { get; set; } = true;
}