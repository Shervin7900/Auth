using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required ")]
        public string Username { get; set; }



        [Required(ErrorMessage = "Email is required ")]
        public string Email { get; set; }
    }
}