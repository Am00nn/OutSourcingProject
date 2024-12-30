using OutsourcingSystem.Models;

namespace OutsourcingSystem.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Adds a new team [returns team id]
        public int AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team.TeamID;
        }

        //Update team details also used for soft delete[does not return anything]
        public void UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }

        //Hard deleting team
        public void DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
        }

        //Gets all teams [returns list of teams]
        public List<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        //Get by ID [returns team by ID]
        public Team GetTeamByID(int ID)
        {
            return _context.Teams.FirstOrDefault(t => t.TeamID == ID);
        }
    }
}
