using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.Authentication
{
    public class ClientLoginResModel
    {
        [MinLength(6)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}