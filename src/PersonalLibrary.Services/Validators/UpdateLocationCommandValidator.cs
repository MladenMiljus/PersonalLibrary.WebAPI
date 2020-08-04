using FluentValidation;
using PersonalLibrary.Services.Tasks.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalLibrary.Services.Validators
{
    class UpdateLocationCommandValidator: AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(t => t.ID).NotNull();
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
