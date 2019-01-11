using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDrive.Application.Roles.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<RoleDetailViewModel> RoleDetails { get; set; }
    }

    public class RoleDetailViewModel
    {
        public int Id { get; set; }

        public string Permissions { get; set; }

        public string ModuleName { get; set; }

    }
}
