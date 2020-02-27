namespace EBook.API.Mapper.Profiles
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Domain;

    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, LanguageDto>().ReverseMap();
        }
    }
}
