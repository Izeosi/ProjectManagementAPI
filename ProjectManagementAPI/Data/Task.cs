namespace ProjectManagementAPI.Data
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed,
        Canceled,
    }

    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string? CreatedBy { get; set; }
        public ApplicationUser User { get; set; }
    }
}
