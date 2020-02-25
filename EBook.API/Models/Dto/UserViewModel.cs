// Added DTO objects in API project for simplicity

namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;
    
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }

        public CategoryViewModel Category { get; set; }
        public IEnumerable<BookViewModel> EBooks { get; set; }

        public UserViewModel() => EBooks = new List<BookViewModel>();
    }
}
