namespace EBook.Persistence
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using Microsoft.Extensions.Configuration;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBooksRepository : IEBooksRepository
    {
        private const string ElasticsearchSectionKey = "elasticsearch";
        private const string EBooksIndexKey = "ebooksIndex";

        private readonly IElasticClient _client;
        private readonly IConfiguration _config;

        public EBooksRepository(IElasticClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task<IEnumerable<Book>> Search(ISearchRequest<Book> query)
        {
            var response = await _client.SearchAsync<Book>(query);

            if (!response.IsValid)
                throw new Exception(response.DebugInformation, response.OriginalException);

            return response.Documents;
        }

        public Task<Book> Create(Book entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int primaryKey)
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> Get(int primaryKey)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new System.NotImplementedException();
        }


        public Task<Book> Update(int primaryKey, Book entity)
        {
            throw new System.NotImplementedException();
        }

        private string GetIndex() => _config.GetSection(ElasticsearchSectionKey).GetValue<string>(EBooksIndexKey);
    }
}
