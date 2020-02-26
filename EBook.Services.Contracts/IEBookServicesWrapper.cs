namespace EBook.Services.Contracts
{
    public interface IEBookServicesWrapper
    {
        IEBooksSearchService SearchService { get; }
        IEBooksFilterService FilterService { get; }
    }
}
