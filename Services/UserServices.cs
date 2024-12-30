using OutsourcingSystem.DTOs;
using OutsourcingSystem.Migrations;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;
using System.Security.Claims;

namespace OutsourcingSystem.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositry _userrepo;

        // Constructor to inject the IUserRepo dependency
        public UserServices(IUserRepositry userrepo)
        {
            // Assigning the injected IUserRepo instance to the private field
            _userrepo = userrepo;
        }

        public void AddUser(UserInputDto user)
        {
            try
            {
                // Validate the user's name
                if (user.Name == null)
                {
                    throw new ArgumentException("The name is required.");
                }

                // Check if a user with the same email already exists
                var existingUserByEmail = _userrepo.GetUserByEmail(user.Email);
                if (existingUserByEmail != null)
                {
                    throw new ArgumentException("A user with this email already exists.");
                }

                // Check for duplicate password
                var existingUserByPassword = _userrepo.GetUserByPassword(user.Password);
                if (existingUserByPassword != null)
                {
                    throw new ArgumentException("A user with this password already exists. Please choose a different password.");
                }

                // Hash the password
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                // Create a new user object
                var completeUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                     role = user.role,
                    CreatedAt = user.CreatedAt,
                };

                // Calls the AddUser method of the IUserRepo implementation
                _userrepo.AddUser(completeUser);
            }
            catch (ArgumentException ex)
            {
                // Handle specific argument exceptions
                throw new ArgumentException($"Error adding user: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }
       

        public User Login(string email, string password)
        {
            try
            {
                var user = _userrepo.GetUserByEmail(email);
                if (user == null)
                {
                    throw new ArgumentException("Invalid email or password.");
                }
                if (user.IsDeleted == true)
                {
                    throw new ArgumentException("This account is not activated.");
                }

                // Verify the password against the hashed password
                if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid credentials.");
                }

                return user; // Return the user if login is successful
            }
            catch (ArgumentException ex)
            {
                // Handle specific argument exceptions
                throw new ArgumentException($"Error during login: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle unauthorized access exceptions
                throw new UnauthorizedAccessException($"Login failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public List<User> GetAllUsers(int userid)
        {
            try
            {
                // Fetch all users from the repository
                return _userrepo.GetAllUsers(userid);
            }
            catch (Exception ex)
            {
                // Handle any errors related to fetching users
                throw new Exception($"Error retrieving all users: {ex.Message}");
            }
        }

        public User GetUserByID(int ID, ClaimsPrincipal user)
        {
            try
            {
                var isAdmin = user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Admin");
                if (!isAdmin)
                {
                    throw new UnauthorizedAccessException("Only admin users can get user details by ID.");
                }

                return _userrepo.GetUserById(ID);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle unauthorized access exceptions
                throw new UnauthorizedAccessException($"Error getting user by ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public bool DeleteUser(string role, int userIdFromToken)
        {
            try
            {
                if (role == "Admin" || role == "NormalUser")
                {
                    var userToDelete = _userrepo.GetUserById(userIdFromToken);
                    if (userToDelete == null)
                        throw new Exception("User not found.");

                    userToDelete.IsDeleted = true;
                    _userrepo.Update(userToDelete);
                    return true;
                }
                throw new UnauthorizedAccessException("You do not have permission to delete this user.");
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle unauthorized access exceptions
                throw new UnauthorizedAccessException($"Error deleting user: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                throw new Exception($"An unexpected error occurred while deleting the user: {ex.Message}");
            }
        }

        public bool UpdateUser(int userIdFromToken, UserUpdateDto updateRequest)
        {
            try
            {
                var userToUpdate = _userrepo.GetUserById(userIdFromToken);

                if (userToUpdate == null)
                {
                    throw new Exception("User not found.");
                }

                if (userToUpdate.IsDeleted==true)
                {
                    throw new Exception("Cannot update a deleted account. Please log out.");
                }

                // Validate if any update fields are provided
                bool isUpdated = false;

                // Update only allowed fields
                if (!string.IsNullOrEmpty(updateRequest.Name))
                {
                    userToUpdate.Name = updateRequest.Name;
                    isUpdated = true;
                }

                if (!string.IsNullOrEmpty(updateRequest.Email))
                {
                    userToUpdate.Email = updateRequest.Email;
                    isUpdated = true;
                }

                // If no updates are provided, throw an error
                if (!isUpdated)
                {
                    throw new Exception("No update fields provided. Please provide at least one field to update.");
                }

                // Update the timestamp
                userToUpdate.UpdatedAt = DateTime.Now;

                // Save changes
                _userrepo.Update(userToUpdate);
                return true;
            }
            catch (Exception ex)
            {
                // Handle any errors related to updating the user
                throw new Exception($"Error updating user: {ex.Message}");
            }
        }

    }
}
