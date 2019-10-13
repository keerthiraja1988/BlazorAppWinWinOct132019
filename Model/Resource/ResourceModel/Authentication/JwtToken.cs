using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.Authentication
{
    public class JwtToken
    {
        public bool IsUserAuthenticated { get; set; }

        public Int64 UserId { get; set; }

        public string UserName { get; set; }

        public DateTime ExpireOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public String Token { get; set; }

    }

}
