using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface ITeamMemberService
    {
        string AddTeamMember(int teamID, int developerID);
        int DeleteTeamMember(int TeamID, int DeveloperID);
        List<TeamMember> GetAllTeamMembers(int Page, int PageSize, int? developerID, int? teamID);
        int UpdateTeamMember(int teamID, int developerID);
        int GetNoTakenSlots(int TeamID);
        bool CheckTMinTeam(int TeamID, int devID);
        List<TeamMember> GetTeamMemberByTeamID(int TeamID);
    }
}