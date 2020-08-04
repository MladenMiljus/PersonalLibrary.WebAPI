using FluentValidation;
using PersonalLibrary.Services.Tasks.Commands;

namespace PersonalLibrary.Services.Validators
{
    public class CreateLocationCommandValidator: AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            /*RuleFor(t => t.Active).;
            RuleFor(t => t.GroupID).NotEmpty();
            RuleFor(t => t.LocationAddress).NotNull();
            RuleFor(t => t.LocationCity).NotNull();
            RuleFor(t => t.LocationCountryID).NotNull();
            RuleFor(t => t.LocationDescription).NotNull();*/
            RuleFor(t => t.LocationName).NotEmpty();
            //RuleFor(t => t.UserID).NotEmpty();
        }
    }
}
