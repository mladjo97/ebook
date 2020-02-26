namespace EBook.API.Mapper.Profiles
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Domain;

    public class EBookProfile : Profile
    {
        public EBookProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
