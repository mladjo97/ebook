namespace EBook.Services.Models
{
    using EBook.Services.Contracts.Query;
    using System.Collections.Generic;

    public abstract class ElasticQueryable<T> : IElasticQueryable<T> where T : class
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
