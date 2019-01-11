using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SmartDrive.Application.Users.Commands
{
    public class DeleteUserCommand:IRequest
    {
        public int Id { get; set; }
    }
}
