using System.ComponentModel.DataAnnotations;

namespace laboratorio4.Models {
    public class Song {
        public int Id { get; set; }
        [Required, StringLength(60, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(60, MinimumLength = 1)]
        public string Singer { get; set; } = string.Empty;
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(30)]
        public string Genre { get; set; } = string.Empty;
    }
}
