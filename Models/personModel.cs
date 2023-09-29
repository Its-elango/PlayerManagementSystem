using System.ComponentModel.DataAnnotations;

namespace DataManagementSystem.Models
{
    public class personModel
    {
        // Display attribute for the PersonID property
        [Display(Name = "Player ID")]
        public int PersonID { get; set; }

        // Display attribute for the SurName property
        [Display(Name = "Name")]
        // Regular expression validation for alphabetic characters only
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please enter only alphabetic characters.")]
        // Required attribute for mandatory input
        [Required(ErrorMessage = "Player name is required.")]
        public string SurName { get; set; }

        // Required attribute for mandatory input
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        // Regular expression validation for a valid email address
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
         ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Regular expression validation for a 10-digit contact number
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a 10-digit contact number.")]
        // Maximum length validation for contact number
        [MaxLength(10, ErrorMessage = "Contact number should not exceed 10 digits.")]
        [Required(ErrorMessage = "Contact is required.")]
        public string Contact { get; set; }

        // Required attribute for mandatory input
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        // Required attribute for mandatory input
        [Required(ErrorMessage = "Picture is required.")]
        public byte[] Picture { get; set; }

    }
}
