namespace EBook.API.Elasticsearch.Index
{
    using EBook.Domain;
    using Microsoft.Extensions.Configuration;
    using Nest;

    public static class DefaultIndexConfiguration
    {
        private const string ElasticsearchSectionKey = "elasticsearch";
        private const string DefaultIndexKey = "defaultIndex";
        private const string EBooksIndexKey = "ebooksIndex";
        private const string UsersIndexKey = "usersIndex";

        public static ConnectionSettings ConfigureDefaultTypeIndexes(this ConnectionSettings settings, IConfiguration config)
        {
            var elasticsearchConfigSection = config.GetSection(ElasticsearchSectionKey);
            var defaultIndex = elasticsearchConfigSection.GetValue<string>(DefaultIndexKey);
            var eBooksIndex = elasticsearchConfigSection.GetValue<string>(EBooksIndexKey);
            var usersIndex = elasticsearchConfigSection.GetValue<string>(UsersIndexKey);

            settings.DefaultIndex(defaultIndex);
            settings.DefaultMappingFor<Book>(m => m.IndexName(eBooksIndex));
            settings.DefaultMappingFor<User>(m => m.IndexName(usersIndex));

            return settings;
        }

    }
}
