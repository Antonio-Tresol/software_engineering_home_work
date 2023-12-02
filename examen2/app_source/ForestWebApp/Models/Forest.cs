using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForestWebApp.Models;

/// <summary>
///   a Forest information
/// </summary>
public class Forest
{
    /// <summary>
    ///    An unique identifier
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    /// <summary>
    ///     The forest's name
    /// </summary>
    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string Name { get; set; }

    /// <summary>
    ///     The country where the forest is located
    /// </summary>
    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string CountryOfOrigin { get; set; }

    /// <summary>
    ///     The Forest's vegetation type
    /// </summary>
    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string TypeOfVegetation { get; set; }

    /// <summary>
    ///     The forest's area in square kilometers
    /// </summary>
    [Required]
    public int AreaKm2 { get; set; } = 0;

    /// <summary>
    ///     Indicates
    /// </summary>
    [Required]
    public bool OldGrowthForest { get; set; } = true;
}