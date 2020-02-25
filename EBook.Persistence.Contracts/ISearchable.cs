namespace EBook.Persistence.Contracts
{
    using Nest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchable<T> where T : class
    {
        Task<IEnumerable<T>> Search(ISearchRequest<T> query);
    }
}
