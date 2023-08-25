using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace laboratorio4.Models {
    public class Movie {
        public int Id { get; set; }
        // the question mark after the data type means attribute is nullable
        public string? Title { get; set; }
        // The [Display] attribute specifies the display name of a field. In the preceding code, Release Date instead of ReleaseDate.
        [Display(Name = "Release Date")]
        // The [DataType] attribute specifies the type of the data (Date). The time information stored in the field isn't displayed.
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }

        // data annotation enables Entity Framework Core to correctly map Price to currency in the database.
        [Column(TypeName = "decimals(18, 2")]
        public decimal Price { get; set; }
    }
}
