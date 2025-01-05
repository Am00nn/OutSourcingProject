using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface IProjectRepositry
    {
        void Addprojetc(Project project);
        bool DeleteProject(Project pro);
        Project GetProjectByID(int pid);
        Project GetProjectByIDClient(int clientid);
        void UpdateProject(Project pro);
    }
}