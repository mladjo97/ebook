namespace EBook.Services.Models
{
    using EBook.Domain;
    using EBook.Services.Contracts.Query;
    using System.Collections.Generic;

    public class EBookElasticQueryable : IEBookElasticQueryable
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public IEnumerable<Book> Items { get; set; }
    }
}
