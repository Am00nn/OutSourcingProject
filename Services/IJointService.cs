using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IJointService
    {
        string AddTeamMemberToTeam(int developerID, int teamID);
        List<TeamMember> GetTeamMemberByTeamID(int teamID);
        string RemoveTeamMemberFromTeam(int developerID, int teamID);
    }
}