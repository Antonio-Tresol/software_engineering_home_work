using System.ComponentModel.DataAnnotations;

namespace laboratorio4.Models {
    public class Movie {
        public int Id { get; set; }
        // the question mark after the data type means attribute is nullable
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
