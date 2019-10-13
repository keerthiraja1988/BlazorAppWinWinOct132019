using System;

namespace DomainModel
{
    public class UserDetailModel
    {
        public Int64 UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int UserType { get; set; }

        public DateTime CreatedOn { get; set; }

        public Int64 CreatedBy { get; set; }

        public DateTime ModifidOn { get; set; }

        public Int64 ModifiedBy { get; set; }

    }
}
