using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalLibrary.Api.Helper;
using PersonalLibrary.Services.Common.DTOs;
using PersonalLibrary.Services.Tasks.Commands;
using PersonalLibrary.Services.Tasks.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalLibrary.Api.Controllers
{
    [Produces(OutputProducts.Json)]
    [ApiController]
    [Route(Route.Value)]
    public class LocationsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateLocationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationDTO>>> GetAll()
        {
            return await Mediator.Send(new GetAllLocationsQuery());
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<LocationDTO>> Get(int id)
        {
            return await Mediator.Send(new GetLocationByIdQuery { Id = id });
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update(UpdateLocationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await Mediator.Send(new DeleteLocationCommand { ID = id });
        }
    }
}
