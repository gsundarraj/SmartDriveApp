using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmartDrive.Application.Roles.Commands;

namespace SmartDrive.Application.Roles.Commands
{
    public class UpdateRoleCommand:IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<UpdateRoleDetail> RoleDetails { get; set; }
    }
    public class UpdateRoleDetail
    {
        public int Id { get; set; }

        public string ModuleName { get; set; }

        public string Permissions { get; set; }

    }

}
