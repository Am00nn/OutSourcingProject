using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
 
        [Authorize]
        [ApiController]
        [Route("api/[Controller]")]
        public class DeveloperController : ControllerBase
        {
            private readonly IConfiguration _configuration;

            private readonly IDeveloperServices _developerServices;


            public DeveloperController(IUserServices userService, IConfiguration configuration, IClientService clientService, IDeveloperServices developerServices)
            {

                _configuration = configuration;
                _developerServices = developerServices;

            }

            [Authorize(Roles = "Developer,Admin")]
            [HttpPut("UpdateDeveloper")]
            public IActionResult UpdateDeveloper([FromBody] UpdateDeveInput developerupdate)
            {
                // Check if the provided client data is null a
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (developerupdate == null)
                    return BadRequest("Updated developer data cannot be null.");

                try
                {
                    // update the client using the service

                    _developerServices.UpdateDeveloper(int.Parse(id), developerupdate);

                    // Return a 200 e if the update is successful

                    return Ok("developer updated successfully.");
                }
                catch (KeyNotFoundException ex)
                {
                    // Return a 404 Not Found  if the client ID is not found

                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    // Return a 500 Internal Server Error response 
                    return StatusCode(500, $"An error occurred while updating the developer: {ex.Message}");
                }
            }



        //Delete developer data
        [Authorize(Roles = "Developer,Admin")]
        [HttpDelete("deleteDeveloper")]

            public IActionResult SoftDeleteClient()
            {
                try
                {
                    //  softdelete the client using the service
                    var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    _developerServices.SoftDeleteClient(int.Parse(id));

                    // Return a 200  if is successful
                    return Ok("developer soft-deleted successfully.");
                }
                catch (KeyNotFoundException ex)
                {
                    // Return a 404 if the client ID is not found
                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"An error occurred while soft-deleting the client: {ex.Message}");
                }
            }
        [Authorize(Roles = "Client,Admin")]
        [HttpGet("GetDeveloperBy")]

            //   [Authorize(Roles = "Developer, Admin")]
            public IActionResult GetAllDeveloper(
         string name,
         [FromQuery] string speclization,
         [FromQuery] decimal? rating,
         [FromQuery] bool? availiabilty,
         [FromQuery] int pageNumber = 1,
         [FromQuery] int pageSize = 10)
            {
                try
                {
                    // Validate pagination parameters
                    if (pageNumber <= 0)

                        return BadRequest("Page number must be greater than 0.");

                    if (pageSize <= 0)

                        return BadRequest("Page size must be greater than 0.");

                    // get  clients using the service with  filter 

                    var developer = _developerServices.GetAlldeveloper(name, speclization, rating, availiabilty, pageNumber, pageSize);

                    // Return a 200 with the list of clients


                    return Ok(developer);
                }
                catch (ArgumentException ex)
                {
                    // Handle specific argument errors and return a 400 Bad Request response
                    return BadRequest($"Invalid input: {ex.Message}");
                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"An error occurred while retrieving : {ex.Message}");
                }
            }


        [Authorize(Roles = "Client,Admin")]
        [HttpGet("ByName")]
            public IActionResult ByName([FromQuery] string name)
            {
                if (string.IsNullOrEmpty(name))

                    return BadRequest("name of developer cannot be null or empty.");

                try
                {
                         var developer =_developerServices.GetName(name);

                    return Ok(developer);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while retrieving : {ex.Message}");
                }
            }

        [Authorize(Roles = "Client,Admin")]
        [HttpGet("ByAvailabilty")]
            public IActionResult ByAvailabilty([FromQuery] bool ave)
            {
                if (ave==null)

                    return BadRequest("name of developer cannot be null or empty.");

                try
                {
                          var dev =_developerServices.GetByAvailability(ave);

                    return Ok(dev);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while retrieving : {ex.Message}");
                }
            }
        [Authorize(Roles = "Client,Admin")]
        [HttpGet("BySpecilization")]
            public IActionResult BySpecilization([FromQuery] string spe)
            {
                if (string.IsNullOrEmpty(spe))

                    return BadRequest("name of developer cannot be null or empty.");

                try
                {
                       var dev =_developerServices.GetSpecilization(spe);

                    return Ok(dev);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while retrieving: {ex.Message}");
                }
            }

        [Authorize(Roles = "Client,Admin")]
        [HttpGet("Byrating")]
            public IActionResult Byrating([FromQuery] decimal rate)
            {
                if (rate==null)

                    return BadRequest("name of developer cannot be null or empty.");

                try
                {
                       var dev =_developerServices.Getrate(rate);

                    return Ok(dev);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while retrieving: {ex.Message}");
                }
            }


           


        }
    }

