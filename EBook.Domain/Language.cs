namespace EBook.Domain
{
    using System.Collections.Generic;
    
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Book> EBooks { get; set; }

        public Language() => EBooks = new List<Book>();
    }
}
