namespace EBook.Services.Queries
{
    using EBook.Services.Contracts.Query;
    using Nest;

    public abstract class SearchRequestSpecification<T> : ISpecification<ISearchRequest<T>> where T : class
    {
        public abstract ISearchRequest<T> IsSatisfiedBy();
    }
}
