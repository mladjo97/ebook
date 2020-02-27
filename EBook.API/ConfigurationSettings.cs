namespace EBook.API
{
    public static class ConfigurationSettings
    {
        /// <summary>
        /// Elasticsearch configuration sections
        /// </summary>
        public const string ElasticsearchSectionKey = "elasticsearch";
        public const string UrlKey = "url";
        public const string DefaultIndexKey = "defaultIndex";
        public const string EBooksIndexKey = "ebooksIndex";
        public const string UsersIndexKey = "usersIndex";

        /// <summary>
        /// JWT configuration sections
        /// </summary>
        public static string JwtConfigKey = "jwt";
        public static string IssuerConfigKey = "issuer";
        public static string SecretConfigKey = "secret";
        public static string AudienceConfigKey = "audience";
    }
}
