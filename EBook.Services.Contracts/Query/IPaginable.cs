namespace EBook.Services.Contracts.Query
{
    using System.Collections.Generic;

    public interface IPaginable<T> where T : class
    {
        int Total { get; set; }
        int Page { get; set; }
        int Size { get; set; }

        IEnumerable<T> Items { get; set; }
    }
}
