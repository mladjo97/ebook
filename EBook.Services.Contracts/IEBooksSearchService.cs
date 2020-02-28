namespace EBook.Services.Contracts
{
    using EBook.Services.Contracts.Query;
    using System.Threading.Tasks;

    public interface IEBooksSearchService
    {
        Task<IEBookElasticQueryable> Search(IEBookSearchOptions options);
        Task<IEBookElasticQueryable> FuzzySearch(IEBookSearchOptions options);
    }
}
