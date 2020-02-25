namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBooksService : IEBooksService
    {
        private readonly IEBooksRepository _eBooksRepository;

        public EBooksService(IEBooksRepository eBooksRepository)
            => _eBooksRepository = eBooksRepository;

        public async Task<IEnumerable<Book>> SearchByTitle(string title)
        {
            var searchByTitleQuery = new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Title)
                        .Query(title)
                    )
                );

            try
            {
                var eBooks = await _eBooksRepository.Search(searchByTitleQuery);
                return eBooks;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
