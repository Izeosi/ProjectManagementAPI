namespace ProjectManagementAPI.Data
{
    public class ProjectTeam
    {
        public int ProjectTeamId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public ApplicationUser CreatedByUser { get; set; }
    }
}
