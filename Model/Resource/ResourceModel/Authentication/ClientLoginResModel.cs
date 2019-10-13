using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.Authentication
{
    public class ClientLoginResModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "UserName is too long.")]
        public string UserName{ get; set; }

        [Required]
        public string Password { get; set; }

    }
   
}
