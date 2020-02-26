namespace EBook.Services.Contracts
{
    using EBook.Domain;
    using EBook.Services.Contracts.Query;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEBooksSearchService
    {
        Task<IEnumerable<Book>> Search(IEBookSearchOptions options);
        Task<IEnumerable<Book>> FuzzySearch(IEBookSearchOptions options);
    }
}
