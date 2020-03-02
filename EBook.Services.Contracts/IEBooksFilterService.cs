namespace EBook.Services.Contracts
{
    using EBook.Services.Contracts.Filter;
    using EBook.Services.Contracts.Query;
    using System.Threading.Tasks;

    public interface IEBooksFilterService
    {
        Task<IEBookElasticQueryable> Filter(IEBookFilterOptions options);
        Task<IEBookElasticQueryable> FuzzyFilter(IEBookFilterOptions options);
    }
}
