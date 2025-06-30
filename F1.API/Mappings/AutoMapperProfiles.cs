using AutoMapper;
using F1.API.Models.Domains;
using F1.API.Models.DTOs;

namespace F1.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Team, AddTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();
            CreateMap<Driver, DriverDto>().ReverseMap();
            CreateMap<Driver, AddDriverDto>().ReverseMap();
            CreateMap<Driver, UpdateDriverDto>().ReverseMap();  
        }
    }
}
