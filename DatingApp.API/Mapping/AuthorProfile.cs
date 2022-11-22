using AutoMapper;
using DatingApp.API.Database.entities;
using DatingApp.API.ViewModels;

namespace DatingApp.API.Mapping
{
    public class AuthorProfile : Profile 
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorVM>().ReverseMap();
        }
    }
}
