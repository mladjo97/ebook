namespace EBook.Services
{
    using EBook.Services.Contracts;

    public class EBookServicesWrapper : IEBookServicesWrapper
    {
        public IEBooksSearchService SearchService { get; private set; }
        public IEBooksFilterService FilterService { get; private set; }

        public EBookServicesWrapper(
            IEBooksSearchService searchService,
            IEBooksFilterService filterService
            )
        {
            SearchService = searchService;
            FilterService = filterService;
        }

    }
}
