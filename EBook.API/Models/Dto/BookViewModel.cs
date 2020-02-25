// Added DTO objects in API project for simplicity

namespace EBook.API.Models.Dto
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public int PublicationYear { get; set; }
        public string Filename { get; set; }
        public string Mime { get; set; }

        public CategoryViewModel Category { get; set; }
        public LanguageViewModel Language { get; set; }
    }
}
