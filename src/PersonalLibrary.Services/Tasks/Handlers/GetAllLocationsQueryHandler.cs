using AutoMapper;
using MediatR;
using PersonalLibrary.Services.Common.DTOs;
using PersonalLibrary.Services.Interfaces;
using PersonalLibrary.Services.Tasks.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.Tasks.Handlers
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, List<LocationDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLocationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LocationDTO>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.GetAll();
            return _mapper.Map<List<LocationDTO>>(result.ToList());
        }
    }
}
