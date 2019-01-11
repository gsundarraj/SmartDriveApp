using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDrive.Domain.Entities
{
    public class UserPassword
    {
        public int UserPasswordId { get; set; }

        public int UserId { get; set; }

        public string Password { get; set; }

        public string Hint { get; set; }

        public int RetryCount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsLocked { get; set; }

        public User User { get; set; }
    }
}
