using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
   
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        //[HttpPost]
        //public IActionResult RegisterClient([FromBody] ClientDTO clientDto)
        //{
        //    // Validate the input DTO to ensure it is not null
        //    if (clientDto == null)
        //        return BadRequest("Client data cannot be null."); // Return a 400 Bad Request response with an error message

        //    try
        //    {

        //        _clientService.RegisterClient(clientDto);

        //        // Return a 200 OK response with a success message
        //        return Ok("Client registered successfully.");
        //    }
        //    catch (Exception ex)
        //    {

        //        // Return a 500 Internal Server Error response with the exception message
        //        return StatusCode(500, $"An error occurred while registering the client: {ex.Message}");
        //    }
        //}



       // Update  client data

        [HttpPut("UpdateClient")]
        [Authorize(Roles = "Client")]
        public IActionResult UpdateClient([FromBody] UpdateClientData clientDto)
        {
            // Check if the provided client data is null a
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (clientDto == null)
                return BadRequest("Updated client data cannot be null.");

            try
            {
                // update the client using the service

                _clientService.UpdateClient(int.Parse(id), clientDto);

                // Return a 200 e if the update is successful

                return Ok("Client updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                // Return a 404 Not Found  if the client ID is not found

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response 
                return StatusCode(500, $"An error occurred while updating the client: {ex.Message}");
            }
        }



        //Delete client data

        [HttpDelete("DeleteClient")]
        [Authorize(Roles = "Client")]
        public IActionResult SoftDeleteClient()
        {
            try
            {
                //  softdelete the client using the service
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _clientService.SoftDeleteClient(int.Parse(id));

                // Return a 200  if is successful
                return Ok("Client soft-deleted successfully.");
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
       
        
        [HttpGet("GetClientBy")]

     //   [Authorize(Roles = "Developer, Admin")]
        public IActionResult GetAllClients(
         string name,
         [FromQuery] string industry,
         [FromQuery] decimal? rating,
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

                var clients = _clientService.GetAllClients(name,industry, rating, pageNumber, pageSize);

                // Return a 200 with the list of clients


                return Ok(clients);
            }
            catch (ArgumentException ex)
            {
                // Handle specific argument errors and return a 400 Bad Request response
                return BadRequest($"Invalid input: {ex.Message}");
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"An error occurred while retrieving clients: {ex.Message}");
            }
        }

        [HttpGet("GetClientById")]
      //  [Authorize(Roles = "Developer, Admin")]
        public IActionResult GetClientById()
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var client = _clientService.GetClientById(int.Parse(id));

                return Ok(client);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the client: {ex.Message}");
            }
        }


        [HttpGet("by-industry")]
       // [Authorize(Roles = "Developer, Admin")]
        public IActionResult GetClientsByIndustry([FromQuery] string industry)
        {
            if (string.IsNullOrEmpty(industry))

                return BadRequest("Industry cannot be null or empty.");

            try
            {
                var clients = _clientService.GetClientsByIndustry(industry);

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving clients by industry: {ex.Message}");
            }
        }

       


        [HttpGet("by-rating")]
        //[Authorize(Roles = "Developer, Admin")]
        public IActionResult GetClientsByRating([FromQuery] decimal rating)
        {
            if (rating < 0)
                return BadRequest("Rating must be greater than or equal to zero.");

            try
            {
                var clients = _clientService.GetClientsByRating(rating);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving clients by rating: {ex.Message}");
            }
        }


    }

}
