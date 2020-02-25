namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;
    
    public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<BookDto> EBooks { get; set; }

        public LanguageDto() => EBooks = new List<BookDto>();
    }
}
