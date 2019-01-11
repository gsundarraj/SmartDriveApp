using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmartDrive.Application.Roles.Models;

namespace SmartDrive.Application.Roles.Queries
{
    public class GetRoleQuery : IRequest<RoleViewModel>
    {
        public int Id { get; set; }
    }
}
