using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmartDrive.Application.Users.Commands;

namespace SmartDrive.Application.Users.Commands
{
    public class UpdateUserCommand:IRequest
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int RoleId { get; set; }

        public int? AddressId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string UserName { get; set; }

        public bool IsActived { get; set; }

        public bool IsPrimary { get; set; }

        public UserAddressDetail Address { get; set; }
      
    }    

}
