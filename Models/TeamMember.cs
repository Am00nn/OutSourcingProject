using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutsourcingSystem.Models
{
    public class TeamMember
    {
        [Key]
        
        [ForeignKey(nameof(Team))]
        public int TeamID { get; set; }
        public Team Team { get; set; }

        //[Key]
      
        //[ForeignKey(nameof(Developer))]
        //public int DeveloperID { get; set; }
        //public Developer Developer { get; set; }

        [Required(ErrorMessage = "Join date is required.")]
        public DateTime JoinedAt { get; set; } = DateTime.Now;
    }
}
