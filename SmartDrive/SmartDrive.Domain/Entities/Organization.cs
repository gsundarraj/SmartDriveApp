using System;
using System.Collections.Generic;
using System.Text;
using SmartDrive.Domain.Enumerations;

namespace SmartDrive.Domain.Entities
{
     public class Organization
    {
        public int OrganizationId { get; set; }

        public string Code { get; set; }       

        public string Name { get; set; }

        public string Description { get; set; }        

        public int? AddressId { get; set; }       

        public DataStatus Status { get; set; }

        public bool IsFavourite { get; set; }

        

        public Address Address { get; set; }
    }
}
