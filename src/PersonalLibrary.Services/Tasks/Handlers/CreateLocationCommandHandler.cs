using AutoMapper;
using MediatR;
using PersonalLibrary.DataModels;
using PersonalLibrary.Services.Interfaces;
using PersonalLibrary.Services.Tasks.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.Tasks.Handlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Add(_mapper.Map<Locations>(request));
            return result;
        }
    }
}
