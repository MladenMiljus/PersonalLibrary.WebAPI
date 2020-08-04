using AutoMapper;
using MediatR;
using PersonalLibrary.Services.Interfaces;
using PersonalLibrary.Services.Tasks.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.Tasks.Handlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Delete(request.ID);
            return result;
        }
    }
}
