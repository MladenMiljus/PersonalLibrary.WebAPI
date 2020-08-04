using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalLibrary.Services.Tasks.Commands
{
    public class DeleteLocationCommand : IRequest<int>
    {
        public int ID { get; set; }
    }
}
