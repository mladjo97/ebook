namespace EBook.Services.Contracts
{
    using EBook.Domain;
    using EBook.Services.Contracts.Filter;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEBooksFilterService
    {
        Task<IEnumerable<Book>> Filter(IEBookFilterOptions options);
        Task<IEnumerable<Book>> FuzzyFilter(IEBookFilterOptions options);
    }
}
