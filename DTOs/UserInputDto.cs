﻿using System.ComponentModel.DataAnnotations;

namespace OutsourcingSystem.DTOs
{
  

    public class UserInputDto
    {


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Nmae cannot more than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }



        [Required(ErrorMessage = "Role is Required ")]

        public string role { get; set; }   //"client " , "Developer" , "Admin"


        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}