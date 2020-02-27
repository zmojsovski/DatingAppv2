using System.Linq;
using AutoMapper;
using DatingApp2.Dtos;
using DatingApp2.Models;

namespace DatingApp2.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url))
            .ForMember(dest => dest.Age, opt => 
            opt.MapFrom(src => src.DateOfBirth.CalculateAge())); //Custom Metoda vo Extensions klasata za presmetka na godini
            CreateMap<User,UserForDetailedDto>()
                 .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url))
            .ForMember(dest => dest.Age, opt => 
            opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            
            CreateMap<Photo,PhotosForDetailedDto>();
        }
    }
}