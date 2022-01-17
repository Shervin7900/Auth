﻿using System.ComponentModel.DataAnnotations;

namespace Lib.Models.Dto.Requests
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
