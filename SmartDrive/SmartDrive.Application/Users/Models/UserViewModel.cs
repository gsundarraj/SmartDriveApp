using System;
using System.Collections.Generic;
using System.Text;
using SmartDrive.Domain.Enumerations;

namespace SmartDrive.Application.Users.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public int? AddressId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string UserName { get; set; }

        public bool IsActived { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsFavourite { get; set; }

        public bool IsSuperAdmin { get; set; }

        public DataStatus Status { get; set; }
    }
}
