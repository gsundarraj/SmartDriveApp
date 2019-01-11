using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SmartDrive.Application.Users.Commands;

namespace SmartDrive.Application.Users.CommandsValidator
{
    public class CreateUserPasswordCommandValidator:AbstractValidator<CreateUserPasswordCommand>
    {
        public CreateUserPasswordCommandValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.Password).NotEmpty();            
        }
    }
}
