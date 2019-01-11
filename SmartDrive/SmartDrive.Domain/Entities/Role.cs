using System;
using System.Collections.Generic;
using System.Text;
using SmartDrive.Domain.Enumerations;

namespace SmartDrive.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            RoleDetails = new HashSet<RoleDetail>();
        }
        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DataStatus Status { get; set; }

        public ICollection<RoleDetail> RoleDetails { get; set; }

    }
}
