using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SmartDrive.Application.Users.Commands;

namespace SmartDrive.Application.Users.CommandsValidator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.OrganizationId).GreaterThan(0);
            RuleFor(x => x.RoleId).GreaterThan(0);        
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email Address is not correct");
            RuleFor(x => x.Mobile).NotEmpty().MaximumLength(12);
        }
    }
}
