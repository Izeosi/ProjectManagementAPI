namespace ProjectManagementAPI.Models.DTOs
{
    public class UpdateTaskDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ProjectId { get; set; }
    }
}
