namespace EBook.API.Models.Dto
{
    using Microsoft.AspNetCore.Http;

    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public int PublicationYear { get; set; }

        public FileDto File { get; set; }
        public CategoryDto Category { get; set; }
        public LanguageDto Language { get; set; }
    }

    // for testing pdf upload - not the actual model
    public class PostBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public int PublicationYear { get; set; }
        public CategoryDto Category { get; set; }
        public LanguageDto Language { get; set; }
        public IFormFile File { get; set; }
    }
}
