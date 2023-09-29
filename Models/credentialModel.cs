using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataManagementSystem.Models
{
    // A model class to represent user credentials
    public class credentialModel
    {
        // Required attribute for mandatory input; represents the username
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        // Required attribute for mandatory input; represents the password
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?!.*\s).{8,}$", ErrorMessage = "Enter strong password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
