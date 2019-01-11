using System;
using System.Collections.Generic;
using System.Text;
using SmartDrive.Domain.Enumerations;

namespace SmartDrive.Domain.Entities
{
    public class RoleDetail
    {
        public int RoleDetailId { get; set; }

        public int RoleId { get; set; }

        public string ModuleName { get; set; }

        public string Permissions { get; set; }

        public DataStatus Status { get; set; }

        public Role Role { get; set; }
       

    }
}
