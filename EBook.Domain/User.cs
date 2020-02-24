namespace EBook.Domain
{
    using System.Collections.Generic;
    
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public Category? Category { get; set; }
        public IEnumerable<Book> EBooks { get; set; }

        public User() => EBooks = new List<Book>();
    }
}
