namespace EBook.Services.Contracts.Query
{
    public interface ISpecification<T> where T : class
    {
        // ISearchRequest<T> ?
        // but then Nest would be installed on this lib
        T IsSatisfiedBy();
    }
}
