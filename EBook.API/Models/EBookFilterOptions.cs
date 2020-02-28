namespace EBook.API.Models
{
    using EBook.Services.Contracts.Filter;

    public class EBookFilterOptions : IEBookFilterOptions
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }
}
