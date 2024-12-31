using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    //This server is one that combines the use of more than one table, it was created to avoid cycle errors
    public class JointService : IJointService
    {
        private readonly ITeamService _teamService;
        private readonly ITeamMemberService _teamMemberService;
        // private readonly IDeveloperService _developerService;
        public JointService(ITeamService teamService, ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
            _teamService = teamService;
        }

        public string AddTeamMemberToTeam(int developerID, int teamID)
        {
            //check team exists
            bool teamExists = _teamService.CheckTeamByID(teamID);


            if (teamExists)
            {
                //check team has capacity for team 
                var team = _teamService.GetTeamByID(teamID);

                //Get how many slots used 
                int Taken = _teamMemberService.GetNoTakenSlots(teamID);
                int remaining = team.TeamCapacity - Taken;

                if (remaining > 0)
                {
                    //--waiting on developer--
                    //check developer exists [developer service]
                    //check developer active [developer service]
                    //check that developer canBePartOfTeam [developer service]

                    //Add team member 
                    _teamMemberService.AddTeamMember(teamID, developerID);
                    return "Team member added sucessfully!";
                }

                else return "<!>Team does not have sufficient cappacity<!>";
            }
            else return "<!>Invalid team<!>";
        }

        public string RemoveTeamMemberFromTeam(int developerID, int teamID)
        {
            //check team exists and developer is part of team [teamMember]
            bool teamTMExists = _teamMemberService.CheckTMinTeam(teamID, developerID);

            if (teamTMExists)
            {
                //remove team member from team [teammemberservice]
                _teamMemberService.DeleteTeamMember(teamID, developerID);

                return "Team member removed!";
            }

            else return "<!>Team does not exist<!>";
        }

        public List<TeamMember> GetTeamMemberByTeamID(int teamID)
        {
            return _teamMemberService.GetTeamMemberByTeamID(teamID);
        }
    }
}
