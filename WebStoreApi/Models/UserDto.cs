using System.ComponentModel.DataAnnotations;

namespace WebStoreApi.Models
{
    public class UserDto
    {
        [Required]
        public string Firstname { get; set; } = "";
        [Required(ErrorMessage = "Last name is required")]
        public string Lastname { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        [Required]
        [MinLength(5, ErrorMessage = "The address should be at least 5 characters")]
        [MaxLength(1000, ErrorMessage ="The address must be less then 1000 characters")]
        public string Address { get; set; } = "";
    }
}
