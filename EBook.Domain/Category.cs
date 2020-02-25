namespace EBook.Domain
{
    using System.Collections.Generic;
    
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Book> EBooks { get; set; }

        public Category() => EBooks = new List<Book>();
    }
}
