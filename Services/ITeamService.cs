using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface ITeamService
    {
        int AddTeam(int adminID, TeamInDTO input);
        int DeleteTeam(int TeamID);
        bool CheckTeamByID(int TeamID);
        Team GetTeamByID(int TeamID);
        List<TeamOutDTO> GetAllTeams(int Page, int PageSize, bool? active, int? completedProjects, int? rating, int? hourlyRate);
        int ReactivateTeam(int TeamID);
        int UpdateTeam(int TeamID, int AdminID, TeamUpdateDTO team);
    }
}