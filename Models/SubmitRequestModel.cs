namespace OutsourcingSystem.Models
{
    public class SubmitRequestModel
    {
        public string RequestType { get; set; } // "Developer" or "Team"
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DeveloperID { get; set; } 
        public int? TeamID { get; set; } 
    }
}
