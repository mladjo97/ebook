namespace EBook.API.Models.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public int PublicationYear { get; set; }
        public string Filename { get; set; }
        public string Mime { get; set; }

        public CategoryDto Category { get; set; }
        public LanguageDto Language { get; set; }
    }
}
