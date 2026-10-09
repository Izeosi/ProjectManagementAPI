namespace ProjectManagementAPI.Models.DTOs
{
    public class ProjectTeamResponseDTO
    {
        public int ProjectTeamId { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
    }
}
