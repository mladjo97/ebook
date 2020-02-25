// @TODO:
// - Create custom exceptions for elasticsearch
// - Do we use elastic as a db in this project or ?

namespace EBook.Persistence
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using Microsoft.Extensions.Configuration;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersRepository : IUsersRepository
    {
        private const string ElasticsearchSectionKey = "elasticsearch";
        private const string UsersIndexKey = "usersIndex";

        private readonly IElasticClient _client;
        private readonly IConfiguration _config;

        public UsersRepository(IElasticClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task<User> Create(User entity)
        {
            var response = await _client.CreateAsync(
                entity,
                s => s.Index(GetIndex())
                );
           
            if (!response.IsValid)
                throw new Exception(response.DebugInformation, response.OriginalException);

            // @TODO:
            // - Check how to get newly created user
            return entity; 
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(int primaryKey)
        {
            var response = await _client.SearchAsync<User>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .Match(m => m
                                .Field(f => f.Id)
                                .Query(primaryKey.ToString())
                            )
                        )
                    )
                )
            );

            if (!response.IsValid)
                throw new Exception(response.DebugInformation, response.OriginalException);

            return response.Documents.FirstOrDefault();
        }

        public async Task<User> GetByUsername(string username)
        { 
            var response = await _client.SearchAsync<User>(s => s
                .Index(GetIndex())
                .Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .Match(m => m
                                .Field(f => f.Username)
                                .Query(username)
                            )
                        )
                    )
                )
            );

            if (!response.IsValid)
                throw new Exception(response.DebugInformation, response.OriginalException);

            return response.Documents.FirstOrDefault();
        }

        public Task<User> Update(int primaryKey, User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int primaryKey)
        {
            throw new NotImplementedException();
        }

        private string GetIndex() => _config.GetSection(ElasticsearchSectionKey).GetValue<string>(UsersIndexKey);

    }
}
