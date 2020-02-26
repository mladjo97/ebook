namespace EBook.API.Mapper.Profiles
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Domain;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
