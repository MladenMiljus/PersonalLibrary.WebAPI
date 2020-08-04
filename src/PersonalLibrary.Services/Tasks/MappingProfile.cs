using AutoMapper;
using PersonalLibrary.DataModels;
using PersonalLibrary.Services.Common.DTOs;
using PersonalLibrary.Services.Tasks.Commands;

namespace PersonalLibrary.Services.Tasks
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLocationCommand, Locations>();
            CreateMap<UpdateLocationCommand, Locations>();
            CreateMap<Locations, LocationDTO>();
        }
    }
}
