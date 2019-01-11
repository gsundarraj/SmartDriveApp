using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SmartDrive.Application.Roles.Commands
{
    public class DeleteRoleCommand:IRequest
    {
        public int Id { get; set; }
    }
}
