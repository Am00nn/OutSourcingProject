using System.ComponentModel.DataAnnotations;

namespace OutsourcingSystem.DTOs
{
    public class TeamUpdateDTO
    {
        [MaxLength(100, ErrorMessage = "Team name cannot exceed 100 characters.")]
        public string? TeamName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Team capacity must be at least 1.")]
        public int? TeamCapacity { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Hourly rate must be a non-negative value.")]
        public decimal? HourlyRate { get; set; }

    }
}
