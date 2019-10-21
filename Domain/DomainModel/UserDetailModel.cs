namespace DomainModel
{
    using System;

    public class UserDetailModel
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int UserType { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedByUserId { get; set; }

        public string CreatedByUserName { get; set; }

        public string CreatedByFullName { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedByUserId { get; set; }

        public string ModifiedByUserName { get; set; }

        public string ModifiedByFullName { get; set; }
    }
}