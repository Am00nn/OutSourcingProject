using Microsoft.EntityFrameworkCore;
using OutsourcingSystem.Models;

namespace OutsourcingSystem
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }






        public DbSet<User> Users { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientRequestDeveloper> ClientRequestDeveloper { get; set; }
        public DbSet<ClientRequestTeam> ClientRequestTeam { get; set; }
        public DbSet<ClientReviewDeveloper> ClientReviewDeveloper { get; set; }
        public DbSet<ClientReviewTeam> ClientReviewTeam { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<DeveloperSkill> DeveloperSkill { get; set; }
        public DbSet<FeedbackOnClient> FeedbackOnClient { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }



    }
}
