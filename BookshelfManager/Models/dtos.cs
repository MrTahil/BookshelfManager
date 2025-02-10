using System.ComponentModel.DataAnnotations;

namespace BookshelfManager.Modelsűusing 

{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Meg kell adnod egy Címet!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Meg kell adnod egy Szerzőt!")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Meg kell adnod egy szerzési évet!")]
        [Range(typeof(DateTime), "01-01-01", "2025-12-31", ErrorMessage = "A dátumnak 01 és 2025 között kell lennie.")]
        public int PublishedYear { get; set; }
        public string? Genre { get; set; }
        public decimal? Price { get; set; }
    }

    public class EditBook
    {
        [Required(ErrorMessage = "Nem teheted üressé a címeet!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Nem teheted üressé a szerzőt!")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Nem lehet üres a kiadási év!")]
        [Range(typeof(DateTime), "01-01-01", "2025-12-31", ErrorMessage = "A dátumnak 01 és 2025 között kell lennie.")]
        public int PublishedYear { get; set; }
        public string? Genre { get; set; }
        public decimal? Price { get; set; }
    }
}
