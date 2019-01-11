using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SmartDrive.Application.Roles.Commands;

namespace SmartDrive.Application.Roles.CommandsValidator
{
    public class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(10).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(50);
        }
    }
}
