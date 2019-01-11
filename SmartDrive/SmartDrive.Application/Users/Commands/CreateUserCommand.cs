using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SmartDrive.Application.Users.Commands
{
    public class CreateUserCommand : IRequest
    {        
        public int OrganizationId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string UserName { get; set; }

        public bool IsActived { get; set; }

        public bool IsPrimary { get; set; }

        public UserAddressDetail Address { get; set; }
       
    }

    public class UserAddressDetail
    {        

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Pincode { get; set; }

        public string MapData { get; set; }
    }
 
}
