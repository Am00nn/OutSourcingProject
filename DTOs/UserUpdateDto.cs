using System.ComponentModel.DataAnnotations;

namespace OutsourcingSystem.DTOs
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Nmae cannot more than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
