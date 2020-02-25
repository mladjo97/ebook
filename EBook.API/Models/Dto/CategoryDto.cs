namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<BookDto> EBooks { get; set; }

        public CategoryDto() => EBooks = new List<BookDto>();
    }
}
