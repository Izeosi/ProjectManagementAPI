namespace ProjectManagementAPI.Models.DTOs
{
    public class CreateTaskDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
    }
}
