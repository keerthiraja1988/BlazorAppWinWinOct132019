namespace ResourceModel.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class JwtToken
    {
        public bool IsUserAuthenticated { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public DateTime ExpireOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Token { get; set; }
    }
}