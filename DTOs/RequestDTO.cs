namespace OutsourcingSystem.DTOs
{
    public class RequestDTO
    {
        public int RequestID { get; set; } 
        public int ClientID { get; set; } 
        public string RequestType { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public string Status { get; set; } //(Pending, Approved, Rejected)
        public string ClientEmail { get; set; }
        public string AdminEmail { get; set; } 


    }
}
