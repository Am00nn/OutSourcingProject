using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;
using System.ComponentModel.DataAnnotations;

namespace OutsourcingSystem.Services
{
    public class DeveloperServices : IDeveloperServices
    {
        private readonly IDeveloperRepositry _developerRepositry;
        private readonly IUserRepositry _userRepositry;

        public DeveloperServices(IDeveloperRepositry developerRepositry, IUserRepositry userRepositry)
        {

            _userRepositry = userRepositry;
            _developerRepositry = developerRepositry;


        }
        public void RegisterDeveloper(UserDeveloperInputDto input)
        {
            // Validate the input DTO
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input data cannot be null.");

            // Validate Name
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentException("Name is required.");
            if (input.Name.Length > 100)
                throw new ArgumentException("Name cannot exceed 100 characters.");

            // Validate Email
            if (string.IsNullOrWhiteSpace(input.Email))
                throw new ArgumentException("Email is required.");
            if (!new EmailAddressAttribute().IsValid(input.Email))
                throw new ArgumentException("Invalid email format.");

            // Validate Password
            if (string.IsNullOrWhiteSpace(input.Password))
                throw new ArgumentException("Password is required.");
            if (input.Password.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters long.");

            // Validate Role
            if (string.IsNullOrWhiteSpace(input.role))
                throw new ArgumentException("Role is required.");
            var validRoles = new[] { "Developer", "Admin", "Client" };
            if (!validRoles.Contains(input.role))
                throw new ArgumentException("Invalid role. Allowed roles are: Developer, Admin, Client.");

            // Validate Age
            if (input.Age < 18 || input.Age > 120)
                throw new ArgumentException("Age must be between 18 and 120.");

            // Validate Specialization
            if (string.IsNullOrWhiteSpace(input.Specialization))
                throw new ArgumentException("Specialization is required.");

            // Validate Years of Experience
            if (input.YearsOfExperience < 0)
                throw new ArgumentException("Years of experience must be a non-negative number.");

            // Validate Hourly Rate
            if (input.HourlyRate <= 0)
                throw new ArgumentException("Hourly rate must be greater than zero.");

            // Validate Career Summary
            if (!string.IsNullOrEmpty(input.CareerSummary) && input.CareerSummary.Length > 1000)
                throw new ArgumentException("Career summary cannot exceed 1000 characters.");

            // Validate Document Link
            if (!string.IsNullOrEmpty(input.DocumentLink) &&
                !Uri.IsWellFormedUriString(input.DocumentLink, UriKind.Absolute))
                throw new ArgumentException("Invalid URL format for Document Link.");

            // Validate Completed Projects
            //if (input.CompletedProjects < 0)
            //    throw new ArgumentException("Completed projects must be a non-negative number.");

            // Validate CanBePartOfTeam
            //if (input.CanBePartOfTeam != true && input.CanBePartOfTeam != false)
            //    throw new ArgumentException("CanBePartOfTeam is required and must be true or false.");

            // Create and add User entity
            var user = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(input.Password),
                role = input.role,
                CreatedAt = input.CreatedAt,
            };

            int userID = _userRepositry.AddUserInt(user);

            // Create and add Developer entity
            var developer = new Developer
            {
                UserID = userID,
                Age = input.Age,
                Specialization = input.Specialization,
                YearsOfExperience = input.YearsOfExperience,
                HourlyRate = input.HourlyRate,
               // AvailabilityStatus = input.AvailabilityStatus,
                CareerSummary = input.CareerSummary,
              //  CompletedProjects = input.CompletedProjects,
               // CanBePartOfTeam = input.CanBePartOfTeam,
                DocumentLink = input.DocumentLink,
            };

            _developerRepositry.Add(developer);
        }



    }
}
