using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SmartDrive.Application.Roles.Commands
{
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<AddRoleDetail> RoleDetails {get;set;}
    }
    public class AddRoleDetail
    {   
        public string ModuleName { get; set; }

        public string Permissions { get; set; }

    }
}
