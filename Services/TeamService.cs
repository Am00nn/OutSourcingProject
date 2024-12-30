﻿using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamrepo)
        {
            _teamRepository = teamrepo;
        }

        //Adds team using input from user 
        public int AddTeam(int adminID, TeamInDTO input)
        {
            //mapping TeamInDTO to team 
            var team = new Team
            {
                TeamName = input.TeamName,
                Description = input.Description,
                TeamCapacity = input.TeamCapacity,
                HourlyRate = input.HourlyRate,
                ModifiedBy = adminID
                //other values will be set to their defualts
            };

            return _teamRepository.AddTeam(team);
        }

        //Soft deleting team
        public int DeleteTeam(int TeamID)
        {
            try
            {
                var team = _teamRepository.GetTeamByID(TeamID);

                //Checking if the team exists
                if (team != null)
                {
                    team.Active = false; //deactivating team

                    _teamRepository.UpdateTeam(team);

                    return 0; //if everything went well then 1 will be returned 
                }

                else return 1; //team not found
            }
            catch { return 2; } //an error occured when trying to save
        }

        //Reactivating after soft delete
        public int ReactivateTeam(int TeamID)
        {
            try
            {
                var team = _teamRepository.GetTeamByID(TeamID);

                //Checking if the team exists
                if (team != null)
                {
                    team.Active = true; //reactivating team

                    _teamRepository.UpdateTeam(team);

                    return 0; //if everything went well then 1 will be returned 
                }

                else return 1; //team not found
            }
            catch { return 2; } //an error occured when trying to save
        }


        //Adds team using input from user 
        public int UpdateTeam(int TeamID, int AdminID, TeamInDTO team)
        {
            var oldTeam = _teamRepository.GetTeamByID(TeamID);

            if (oldTeam != null)
            {
                //mapping TeamInDTO to team 
                oldTeam.TeamName = team.TeamName;
                oldTeam.Description = team.Description;
                oldTeam.TeamCapacity = team.TeamCapacity;
                oldTeam.HourlyRate = team.HourlyRate;
                oldTeam.ModifiedAt = DateTime.Now;
                oldTeam.ModifiedBy = AdminID;


                _teamRepository.UpdateTeam(oldTeam);
                return 0; //no errors 
            }

            else return 1; //team not found 
        }


        public List<TeamOutDTO> GetAllTeams(int Page, int PageSize, bool? active, int? completedProjects, int? rating, int? hourlyRate)
        {
            var teams = _teamRepository.GetAllTeams();

            // Filters by if active if provided 
            if (active.HasValue)
            {
                teams = teams.Where(t => t.Active == active).ToList();
            }

            // Filters by completedProjects at if provided 
            if (completedProjects.HasValue)
            {
                teams = teams.Where(t => t.CompletedProjects >= completedProjects).ToList();
            }

            // Filters by rating at if provided 
            if (rating.HasValue)
            {
                teams = teams.Where(t => t.Rating >= rating).ToList();
            }

            // Filters by hourlyRate at if provided 
            if (hourlyRate.HasValue)
            {
                teams = teams.Where(t => t.HourlyRate <= hourlyRate).ToList();
            }


            //Mapping team to TeamOutDTO
            var OutTeams = new List<TeamOutDTO>();
            //Only outputing specific information to the user
            foreach (var team in teams)
            {
                var t = new TeamOutDTO
                {
                    TeamID = team.TeamID,
                    TeamName = team.TeamName,
                    Rating = team.Rating,
                    Description = team.Description,
                    TeamCapacity = team.TeamCapacity,
                    HourlyRate = team.HourlyRate,
                    CompletedProjects = team.CompletedProjects,
                    Active = team.Active,
                };
                OutTeams.Add(t);
            }

            // Paginating results and returning 
            int number = PageSize * Page;
            return OutTeams.OrderByDescending(t => t.TeamName).Skip(number).Take(PageSize).ToList();
        }
    }
}
