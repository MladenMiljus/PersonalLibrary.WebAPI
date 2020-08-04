using MediatR;

namespace PersonalLibrary.Services.Tasks.Commands
{
    public class CreateLocationCommand : IRequest<int>
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCity { get; set; }
        public short LocationCountryID { get; set; }
        public bool Active { get; set; }
    }
}
