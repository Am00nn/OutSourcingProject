using OutsourcingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutsourcingSystem.DTOs
{
    public class ProjectInputDto
    {
     
        public int ClientID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

   
        public int ProjectID { get; set; }

        public int ClientIDinproject { get; set; }
  

        public int? TeamIDinproject { get; set; }


        [Required(ErrorMessage = "Project name is required.")]
        [MaxLength(100, ErrorMessage = "Project name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public DateTime StartAtinproject { get; set; }

        public DateTime? EndAtinproject { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Statusinproject { get; set; } // Pending, Ongoing, Completed


        public int? DeveloperIDinproject { get; set; }
    

        [Required(ErrorMessage = "Daily hours needed is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Daily hours needed must be at least 1.")]
        public int DailyHoursNeeded { get; set; }
    }
}
