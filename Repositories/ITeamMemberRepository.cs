using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public interface ITeamMemberRepository
    {
        string AddTeamMember(TeamMember teamMember);
        void DeleteTeamMemebr(int teamID, int developerID);
        List<TeamMember> GetAllTeamMembers();
        TeamMember GetTeamByDeveloperID(int DevID);
        TeamMember GetTeamByTeamID(int TeamID);
        void UpdateTeamMember(TeamMember teamMember);
        int GetNoTakenSlots(int TeamID);
        List<TeamMember> GetTeamMemberByTeamID(int TeamID);
        bool CheckTMinTeam(int TeamID, int devID);
    }
}