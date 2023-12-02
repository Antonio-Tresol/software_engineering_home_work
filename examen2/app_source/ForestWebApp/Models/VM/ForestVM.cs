using System.ComponentModel.DataAnnotations;

namespace ForestWebApp.Models.VM;

public class ForestViewModel
{
    
    [Required(ErrorMessage = "El nombre del bosque es obligatorio.")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "La longitud del nombre debe estar entre 1 y 60 caracteres.")]
    [Display(Name = "Nombre")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El país de origen es obligatorio.")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "La longitud del país de origen debe estar entre 1 y 60 caracteres.")]
    [Display(Name = "País de Origen")]
    public string CountryOfOrigin { get; set; }

    [Required(ErrorMessage = "El tipo de vegetación es obligatorio.")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "La longitud del tipo de vegetación debe estar entre 1 y 60 caracteres.")]
    [Display(Name = "Tipo de Vegetación")]
    public string TypeOfVegetation { get; set; }

    [Required(ErrorMessage = "El área en kilómetros cuadrados es obligatoria.")]
    [Display(Name = "Área (Km²)")]
    public int AreaKm2 { get; set; }

    [Required(ErrorMessage = "Es necesario indicar si es un bosque primario.")]
    [Display(Name = "Bosque Primario")]
    public bool OldGrowthForest { get; set; }
    
    public ForestViewModel(Forest forest)
    {
        Name = forest.Name;
        CountryOfOrigin = forest.CountryOfOrigin;
        TypeOfVegetation = forest.TypeOfVegetation;
        AreaKm2 = forest.AreaKm2;
        OldGrowthForest = forest.OldGrowthForest;
    }
}