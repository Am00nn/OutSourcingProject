using OutsourcingSystem.DTOs;

namespace OutsourcingSystem.Services
{
    public interface ITeamService
    {
        int AddTeam(int adminID, TeamInDTO input);
        int DeleteTeam(int TeamID);
        List<TeamOutDTO> GetAllTeams(int Page, int PageSize, bool? active, int? completedProjects, int? rating, int? hourlyRate);
        int ReactivateTeam(int TeamID);
        int UpdateTeam(int TeamID, int AdminID, TeamInDTO team);
    }
}