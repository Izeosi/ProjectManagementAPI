namespace ProjectManagementAPI.Data
{
    public enum ProjectStatus
    {
        Planning,
        InProgress,
        Completed,
        Canceled,
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public ApplicationUser User { get; set; }
    }
}
