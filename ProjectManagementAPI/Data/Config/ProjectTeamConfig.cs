using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagementAPI.Data.Config
{
    public class ProjectTeamConfig : IEntityTypeConfiguration<ProjectTeam>
    {
        public void Configure(EntityTypeBuilder<ProjectTeam> builder)
        {
            builder.HasKey(pt => pt.ProjectTeamId);

            builder.HasOne(pt => pt.Project)
                .WithMany()
                .HasForeignKey(pt => pt.ProjectId)
                .HasConstraintName("FK_ProjectTeams_Projects_ProjectId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId)
                .HasConstraintName("FK_ProjectTeams_Users_UserId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.CreatedByUser)
                .WithMany()
                .HasForeignKey(pt => pt.CreatedBy)
                .HasConstraintName("FK_ProjectTeams_Users_CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pt => new { pt.ProjectId, pt.UserId })
                .IsUnique();
        }
    }
}
