using AutoMapper;
using DatingApp.API.Database.entities;
using DatingApp.API.ViewModels;

namespace DatingApp.API.Mapping
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherVM>().ReverseMap();
        }
    }
}
