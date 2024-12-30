using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface ITeamRepository
    {
        int AddTeam(Team team);
        void DeleteTeam(Team team);
        List<Team> GetAllTeams();
        Team GetTeamByID(int ID);
        void UpdateTeam(Team team);
    }
}