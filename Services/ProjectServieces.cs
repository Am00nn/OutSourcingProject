using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    public class ProjectServieces
    {
        private readonly IProjectRepositry _projectRepositry  ;
    

        public ProjectServieces(IProjectRepositry projectRepositry)
        {

             _projectRepositry = projectRepositry;

        }

        public void AddProject(ProjectInputDto project )
        {

            var projectIn = new Project
            {
                ClientID = project.ClientIDinproject,
                DeveloperID = project.DeveloperIDinproject,
                 Description = project.Description,
                 TeamID = project.TeamIDinproject,
                 StartAt = project.StartAtinproject,
                 EndAt = project.EndAtinproject,
                 Status = project.Status,
                 DailyHoursNeeded = project.DailyHoursNeeded,

            };

            _projectRepositry.Addprojetc(projectIn);
        }

        public Project GetProjectById(int id)
        {
            try
            {
                if (id == null)

                    throw new UnauthorizedAccessException("it null id  .");
                var project = _projectRepositry.GetProjectByID(id);
                if (project == null)
                {
                    throw new UnauthorizedAccessException("it null project  .");
                }

                return project;
            }
           catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }


        }

        public Project GetProjectByClientId(int id)
        {
            try
            {
                if (id == null)

                    throw new UnauthorizedAccessException("it null id  .");
                var project = _projectRepositry.GetProjectByIDClient(id);
                if (project == null)
                {
                    throw new UnauthorizedAccessException("it null project  .");
                }

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }


        }

        
    }
}
