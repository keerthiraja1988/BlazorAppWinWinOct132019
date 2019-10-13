using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.Authentication
{
    public class RegisterUserResModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "UserName is too long.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }

}
