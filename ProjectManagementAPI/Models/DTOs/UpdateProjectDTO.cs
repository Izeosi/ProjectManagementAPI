namespace ProjectManagementAPI.Models.DTOs
{
    public class UpdateProjectDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;  
    }
}
