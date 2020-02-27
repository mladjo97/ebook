namespace EBook.Persistence
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBooksRepository : IEBooksRepository
    {
        private readonly IElasticClient _client;

        public EBooksRepository(IElasticClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Book>> Search(ISearchRequest<Book> query)
        {
            var response = await _client.SearchAsync<Book>(query);

            if (!response.IsValid)
                throw new Exception(response.DebugInformation, response.OriginalException);

            return response.Documents;
        }

        public async Task<Book> Create(Book entity)
        {
            var response = await _client.CreateAsync(
                    entity,
                    s => s
                );

            if (!response.IsValid)
                throw new Exception(response.DebugInformation, response.OriginalException);

            // @TODO:
            // - Check how to get newly created ebook
            return entity;
        }

        public Task<int> Delete(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task<Book> Update(int primaryKey, Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
