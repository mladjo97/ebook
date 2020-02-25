// Added DTO objects in API project for simplicity

namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;
    
    public class LanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<BookViewModel> EBooks { get; set; }

        public LanguageViewModel() => EBooks = new List<BookViewModel>();
    }
}
