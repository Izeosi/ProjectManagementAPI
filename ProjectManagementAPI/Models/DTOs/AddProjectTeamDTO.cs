namespace ProjectManagementAPI.Models.DTOs
{
    public class AddProjectTeamDTO
    {
        public int ProjectId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
