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
        private readonly IReviewTeamService _reviewTeamService;
        private readonly IReviewDeveloperService _reviewDevService;
        private readonly IFeedBackOnClientService _feedbackService;
        //private readonly IDeveloperService _developerService;
        public JointService(ITeamService teamService, ITeamMemberService teamMemberService,
            IReviewTeamService reviewteamservice, IReviewDeveloperService reviewDeveloperService,
            IFeedBackOnClientService feedback)
        {
            _teamMemberService = teamMemberService;
            _teamService = teamService;
            _reviewTeamService = reviewteamservice;
            _reviewDevService = reviewDeveloperService;
            _feedbackService = feedback;
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

        //this validates the input then calls the teamservice repo to do the actual calculations 
        public int AddReviewTeam(int ClientID, ClientReviewInDTO input)
        {
            //check valid team id 
            bool validTeam = _teamService.CheckTeamByID(input.ID);

            //*************************Add these validation when project added********************
            //check that this client  actually worked with this team 
            //bool eligibleToReview = _projectService.GetProjectByClientTeamIDs;//will get this from projects table
           //check project completed 

            if (validTeam)
            {
                return _reviewTeamService.AddReviewTeam(ClientID, input);
            }
            else return -1; //invalid team found
        }

        //this validates the input then calls the developerservice repo to do the actual calculations 
        public int AddReviewDeveloper(int DevID, ClientReviewInDTO input)
        {
            //************************Add this when developer added*************
            //check valid team id 
            //bool validDev = _devService.CheckDevByID(input.ID);

            //*************************Add these validation when project added********************
            //check that this client  actually worked with this team 
            //bool eligibleToReview = _projectService.GetProjectByClientTeamIDs;//will get this from projects table
            //check project completed 

            //if (validDev)
            //{
            //  return _developerService.AddReviewDev(DevID, input);
            //}
            //else return -1; //invalid team found

            return 1;
        }

        public int UpdateReviewDeveloper(int ClientID, ClientReviewInDTO review)
        {
            return _reviewDevService.UpdateDevReview(ClientID, review);
        }

        public int UpdateReviewTeam(int ClientID, ClientReviewInDTO review)
        {
            return _reviewTeamService.UpdateTeamReview(ClientID, review);
        }

        public List<ClientReviewDeveloper> GetDeveloperReviews(int Page, int PageSize, int? Rating, int? DevID)
        {
            return _reviewDevService.GetAllDevReviews(Page, PageSize, Rating, DevID );
        }

        public List<ClientReviewTeam> GetTeamReviews(int Page, int PageSize, int? Rating, int? TeamID)
        {
            return _reviewTeamService.GetAllTeamReviews(Page, PageSize, Rating, TeamID);
        }

        public string DeleteTeamReview(int ClientID, int TeamID)
        {
            //check that client is team relation exists 
            bool exists = _reviewTeamService.CheckReviewByTeamIDAndClientID(ClientID, TeamID);

            //Delete 
            if (exists)
            {
                var teamRev = _reviewTeamService.GetRevTeamByTeamIDAndClientID(TeamID, ClientID);
                _reviewTeamService.DeleteTeamReview(teamRev);
                return "Team review deleted!";
            }

            else return "<!>This review does not exist<!>";
        }

        public string DeleteDeveloperReview(int ClientID, int DevID)
        {
            //check that client is team relation exists 
            bool exists = _reviewDevService.CheckReviewByDevIDandTeamID(ClientID, DevID);

            //Delete 
            if (exists)
            {
                var teamRev = _reviewDevService.GetByDevIDandTeamID(ClientID, DevID);
                _reviewDevService.DeleteDeveloperReview(teamRev);
                return "Developer review deleted!";
            }

            else return "<!>This review does not exist<!>";
        }

        //Checks if client is on team and if team worked on a project with this client 
        public int FeedbackValidation(int DevID, FeedBackOnClientDTO feedback)
        {
            int OnTeam = _teamMemberService.IsDevInTeam(DevID);

            //Add a check to see if this team worked on a project with this client 
            //Can't add it now because project is not complete but will add later on 

           return _feedbackService.AddFeedbackOnClient(DevID, feedback, OnTeam);
        }

        public int UpdateFeebackOnClient(int DevID,FeedBackOnClientDTO feedback)
        {
            return _feedbackService.UpdateFeedback(DevID, feedback);
        }

        public string DeleteFeedbackOnClient(int DevID, int clientID)
        {
            return _feedbackService.DeleteFeedback(clientID, DevID);
        }

        public List<FeedbackOnClient> GetClientFeedback(int Page, int PageSize, int? Rating, int? ClientID)
        {
            return _feedbackService.GetAllFeedbacks(Page, PageSize, Rating, ClientID);
        }
    }
}
