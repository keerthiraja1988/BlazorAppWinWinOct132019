namespace ResourceModel.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserResModel
    {
        [Required]
        [MinLength(6)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string LastName { get; set; }

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