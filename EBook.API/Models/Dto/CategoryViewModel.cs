namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<BookViewModel> EBooks { get; set; }

        public CategoryViewModel() => EBooks = new List<BookViewModel>();
    }
}
