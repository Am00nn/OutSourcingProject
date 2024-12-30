namespace OutsourcingSystem.DTOs
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public string RequestedFor { get; set; } // "Developer" or "Team"
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } // "Pending", "Accepted", "Rejected"


    }
}
