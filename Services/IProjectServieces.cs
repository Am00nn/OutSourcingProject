using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IProjectServieces
    {
       void AddProject(int id, ProjectRequestInputDto project);
        Project GetProjectByClientId(int id);
        Project GetProjectById(int id);
        bool SoftDeleteClient(int id);
        void UpdateProject(int id, UpdateProjectDto project);
    }
}