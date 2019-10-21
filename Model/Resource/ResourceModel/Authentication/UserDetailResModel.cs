namespace ResourceModel.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserDetailResModel
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int UserType { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifidOn { get; set; }

        public long ModifiedBy { get; set; }

        public JwtToken JwtToken { get; set; } = new JwtToken();
    }
}