namespace EBook.API.Mapper.Profiles
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Domain;

    public class EBookProfile : Profile
    {
        public EBookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<PostBookDto, Book>()
                .ForPath(dest => dest.File.Filename, opts => opts.MapFrom(src => src.File.FileName))
                .ForPath(dest => dest.File.Mime, opts => opts.MapFrom(src => src.File.ContentType));
        }
    }
}
