namespace EBook.API.Mapper.Profiles
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Domain;
    using EBook.Services.Models;

    public class EBookProfile : Profile
    {
        public EBookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForPath(dest => dest.File.Filename, opts => opts.MapFrom(src => src.File.Filename))
                .ForPath(dest => dest.File.Mime, opts => opts.MapFrom(src => src.File.Mime))
                .ForPath(dest => dest.File.Path, opts => opts.MapFrom(src => src.File.Path));

            CreateMap<PostBookDto, Book>()
                .ForPath(dest => dest.File.Filename, opts => opts.MapFrom(src => src.File.FileName))
                .ForPath(dest => dest.File.Mime, opts => opts.MapFrom(src => src.File.ContentType));

            CreateMap<HighlightableEBook, HighlightableBookDto>();
            CreateMap<EBookElasticQueryable, EBookElasticQueryableDto>();
        }
    }
}
