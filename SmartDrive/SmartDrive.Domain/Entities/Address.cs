using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDrive.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Pincode { get; set; }

        public string MapData { get; set; }

        public string GetShortAddress()
        {
            return Address1 + " " + Address2;
        }

        public string GetLongAddress()
        {
            return Address1 + " " + Address2 + "\n" + City + "\n" + State + "\n" + Country + "-" + Pincode;
        }
    }
}
