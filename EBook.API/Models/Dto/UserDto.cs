namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;
    
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }

        public CategoryDto Category { get; set; }
        public IEnumerable<BookDto> EBooks { get; set; }

        public UserDto() => EBooks = new List<BookDto>();
    }
}
