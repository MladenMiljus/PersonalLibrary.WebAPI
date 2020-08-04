using MediatR;
using PersonalLibrary.DataModels;
using PersonalLibrary.Services.Common.DTOs;

namespace PersonalLibrary.Services.Tasks.Queries
{
    public class GetLocationByIdQuery : IRequest<LocationDTO>
    {
        public int Id { get; set; }
    }
}
