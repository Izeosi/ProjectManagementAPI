namespace ProjectManagementAPI.Models.DTOs
{
    public class TaskResponseDTO
    {
        public int TaskId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
