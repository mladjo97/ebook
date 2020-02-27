namespace EBook.API.Elasticsearch.Index
{
    using EBook.Domain;
    using Microsoft.Extensions.Configuration;
    using Nest;

    public static class DefaultIndexConfiguration
    {
        public static ConnectionSettings ConfigureDefaultTypeIndexes(this ConnectionSettings settings, IConfiguration config)
        {
            var elasticsearchConfigSection = config.GetSection(ConfigurationSettings.ElasticsearchSectionKey);
            var defaultIndex = elasticsearchConfigSection.GetValue<string>(ConfigurationSettings.DefaultIndexKey);
            var eBooksIndex = elasticsearchConfigSection.GetValue<string>(ConfigurationSettings.EBooksIndexKey);
            var usersIndex = elasticsearchConfigSection.GetValue<string>(ConfigurationSettings.UsersIndexKey);

            settings.DefaultIndex(defaultIndex);
            settings.DefaultMappingFor<Book>(m => m.IndexName(eBooksIndex));
            settings.DefaultMappingFor<User>(m => m.IndexName(usersIndex));

            return settings;
        }

    }
}
