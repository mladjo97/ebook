namespace EBook.API.Mapper
{
    using AutoMapper;
    using EBook.API.Mapper.Profiles;
    using System;

    public class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<LanguageProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<EBookProfile>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        });

        /// <summary>
        /// Mapper for usage in class libraries
        /// </summary>
        public static IMapper Mapper => Lazy.Value;
    }
}
