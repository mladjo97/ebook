namespace EBook.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public int PublicationYear { get; set; }

        public File File { get; set; }        
        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
