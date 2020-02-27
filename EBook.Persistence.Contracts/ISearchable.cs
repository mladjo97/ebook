namespace EBook.Persistence.Contracts
{
    using Nest;
    using System.Threading.Tasks;

    public interface ISearchable<T> where T : class
    {
        Task<ISearchResponse<T>> Search(ISearchRequest<T> query);
    }
}
