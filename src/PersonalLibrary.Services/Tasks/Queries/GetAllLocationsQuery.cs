using MediatR;
using PersonalLibrary.DataModels;
using PersonalLibrary.Services.Common.DTOs;
using System.Collections.Generic;

namespace PersonalLibrary.Services.Tasks.Queries
{
    public class GetAllLocationsQuery : IRequest<List<LocationDTO>>
    {
    }
}
