using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Repositories;
using OutsourcingSystem.Services;
using System.Security.Claims;

namespace OutsourcingSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class ProjectController:ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IProjectServieces _projectServieces;


        public ProjectController(IProjectServieces projectServieces, IConfiguration configuration)
        {

             _configuration = configuration;
             _projectServieces = projectServieces;

        }



        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteproject")]

        public IActionResult SoftDeleteProject()
        {
            try
            {
                //  softdelete the client using the service
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _projectServieces.SoftDeleteClient(int.Parse(id));

                // Return a 200  if is successful
                return Ok("project soft-deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                // Return a 404 if the client ID is not found
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while soft-deleting the project: {ex.Message}");
            }
        }
          [HttpPut("Updateproject")]
        [Authorize(Roles = "Admin")]
        public IActionResult Updateproject([FromBody] UpdateProjectDto projectdto)
        {
            // Check if the provided client data is null a
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (projectdto == null)
                return BadRequest("Updated project data cannot be null.");

            try
            {
                // update the client using the service

                _projectServieces.UpdateProject(int.Parse(id), projectdto);

                // Return a 200 e if the update is successful

                return Ok("Project updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                // Return a 404 Not Found  if the client ID is not found

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response 
                return StatusCode(500, $"An error occurred while updating the project: {ex.Message}");
            }
        }

        [Authorize(Roles = "Client")]
        [HttpGet("GetProjectByClientId")]
        public IActionResult ProjectByClient( )
        {
            

            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var Project = _projectServieces.GetProjectByClientId(int.Parse(id));

                return Ok(Project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving : {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetProjectById")]
        public IActionResult GetProject(int id)
        {


            try
            {
               
                var Project = _projectServieces.GetProjectById(id);

                return Ok(Project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving : {ex.Message}");
            }
        }

    }
}
