using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutsourcingSystem.Models
{
    public class Developer
    {
        [Key]
        public int DeveloperID { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User User { get; set; }


        [Required(ErrorMessage = "Specialization is required.")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Years of experience is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Years of experience must be a non-negative number.")]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be greater than zero.")]
        public decimal HourlyRate { get; set; }

        [Required(ErrorMessage = "Availability status is required.")]
        public bool AvailabilityStatus { get; set; }

        [MaxLength(1000, ErrorMessage = "Career summary cannot exceed 1000 characters.")]
        public string CareerSummary { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Completed projects must be a non-negative number.")]
        public int CompletedProjects { get; set; } = 0;

        [Required(ErrorMessage = "CanBePartOfTeam is required.")]
        public bool CanBePartOfTeam { get; set; } = true;

        public virtual ICollection<DeveloperSkill> DeveloperSkills { get; set; }

        public virtual ICollection<ClientReviewDeveloper> ClientReviewDeveloper { get; set; }

        public virtual ICollection<FeedbackOnClient> FeedbackOnClient { get; set; }

        public virtual ICollection<Project> Project { get; set; }


    }
}
