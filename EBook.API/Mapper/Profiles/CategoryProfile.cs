namespace EBook.API.Mapper.Profiles
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Domain;

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
