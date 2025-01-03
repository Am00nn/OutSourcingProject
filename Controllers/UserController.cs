﻿using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Services;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OutsourcingSystem.Controllers
{
   
        [Authorize]
        [ApiController]
        [Route("api/[Controller]")]
        public class UserController : ControllerBase
        {
            private readonly IUserServices _userService;
            private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;
        private readonly IDeveloperServices _developerServices; 


            public UserController(IUserServices userService, IConfiguration configuration, IClientService clientService , IDeveloperServices developerServices)
            {
            _clientService=clientService;
              _userService = userService;
                _configuration = configuration;
             _developerServices = developerServices;

            }
        [AllowAnonymous]
        [HttpPost("AddAdmin")]
        public IActionResult AddUser(AdminInputDto user)
        {
            try
            {
                var userId = _userService.AddUserAdmin(user); // Assume AddUser returns the newly created UserId.
                return Ok(new
                {
                    Message = "User added successfully.",
                    UserId = userId // Returning UserId to be used for adding client details.
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("AddClient")]
        public IActionResult AddClient(UserInputDto client)
        {
            try
            {
                // Validate that the UserId exists in the User table.
                //var userExists = _userService.UserExists(clienet.userid); // Check if UserId is valid.
                //if (!userExists)
                //{
                //    return BadRequest(new { Error = "Invalid UserId. User does not exist." });
                //}
                // Add client details to the database.
                //_userService.AddUser(user);
                _clientService.RegisterClient(client);

                return Ok("Client details added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("RegisterDeveloper")]
        public IActionResult AddDeveloper(UserDeveloperInputDto developer)
        {
            try
            {
                _developerServices.RegisterDeveloper( developer);

                return Ok(" Developer added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        //[HttpGet("GetUnapprovedDeveloper")]
        //public IActionResult GetUnapproveDeveloper()
        //{
        //    try
        //    {
        //        var unapproveddeveloper = _userService.GetUnapprovedDeveloper(User);
        //        return Ok(unapproveddeveloper);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}
        //[HttpPost("ApproveDeveloper")]
        //public IActionResult ApproveDeveloper(ApproveDeveloper approval)
        //{
        //    try
        //    {
        //        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //        _userService.Approvedeveloper(approval, User, int.Parse(userId));
        //        return Ok("develope approval status updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}











        //[HttpGet("GetUnapprovedClients")]
        //public IActionResult GetUnapprovedClients()
        //{
        //    try
        //    {
        //        var unapprovedClients = _userService.GetUnapprovedClients(User);
        //        return Ok(unapprovedClients);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}
        //[HttpPost("ApproveClient")]
        //public IActionResult ApproveClient(ApprovalDto approval)
        //{
        //    try
        //    {
        //        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //        _userService.ApproveClient(approval,User, int.Parse(userId));
        //        return Ok("Client approval status updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}

        [AllowAnonymous]
            [HttpPost("Login")]
            [ProducesResponseType(StatusCodes.Status200OK)] // For successful login
            [ProducesResponseType(StatusCodes.Status400BadRequest)] // For invalid credentials
            [ProducesResponseType(StatusCodes.Status401Unauthorized)] // For unauthorized access
            [ProducesResponseType(StatusCodes.Status500InternalServerError)] // For unexpected errors
        public IActionResult Login(string email, string password)
        {
            try
            {
                //var role = User.FindFirst(ClaimTypes.Role)?.Value;
                //if (string.IsNullOrEmpty(role))
                //{
                //    return BadRequest(new { Error = "Role is required." });
                //}

                var user = _userService.Login(email, password);

                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UID.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.role),
                new Claim("UID", user.UID.ToString())
            };

                    string token = GenerateJwtToken(claims);
                    return Ok(new
                    {
                        Token = token,
                        Role = user.role,
                        Message = "Login successful."
                    });
                }

                return BadRequest(new { Error = "Invalid credentials." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "An unexpected error occurred.",
                    Details = ex.Message
                });
            }
        }

        // [Authorize]
        [HttpGet("GetDetailsUser")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status403Forbidden)]
            public IActionResult GetAllUsers()
            {
                try
                {
                    // Extract claims from the token
                    //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    //var userRole = User.FindFirst(ClaimTypes.Role.ToString())?.Value;

                    //if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userRole))
                    //{
                    //    return Forbid("Access denied. Unable to retrieve user details.");
                    //}

                    // Call the service to retrieve all users
                    var users = _userService.GetAllUsers(User);

                    return Ok(users);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Error = ex.Message });
                }
            }

        [HttpGet("GetUserByID")]
        public IActionResult GetUserByID(int userid)
        {
            try
            {
                // Extract claims from the token
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

                //if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userRole))
                //{
                //    return Forbid("Access denied. Unable to retrieve user details.");
                //}

                // Call the service to retrieve all users
                var users = _userService.GetUserByID(userid,User);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        [HttpDelete("DELETE")]
        public IActionResult SoftDeleteUser()
        {
            try
            {
                // Extract role and user ID from the token
                var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role.ToString())?.Value;
                var userIdFromToken = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

                // Call the service with extracted values
                var result = _userService.DeleteUser(userIdFromToken);

                return Ok(new { success = result, message = "User deleted successfully." });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
       // [Authorize]
        [HttpPut("update")]
        public IActionResult SoftUpdateUser([FromBody] UserUpdateDto updateRequest)
        {
            try
            {
                // Extract role and user ID from the token
                //  var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                var userIdFromToken = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

                // Call the service with extracted values
                var result = _userService.UpdateUser(userIdFromToken, updateRequest);

                return Ok(new { success = result, message = "User updated successfully." });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [NonAction]
            public string GenerateJwtToken(IEnumerable<Claim> claims)
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];

                // Generate security key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Create the token
                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
                    signingCredentials: creds
                );

                // Return the serialized token
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

       
    }
    }
