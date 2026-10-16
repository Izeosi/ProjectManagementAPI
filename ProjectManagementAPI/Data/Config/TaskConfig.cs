using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagementAPI.Data.Config
{
    public class TaskConfig: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.TaskId);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
            builder.Property(t => t.Status).HasConversion<string>().HasMaxLength(30);

            builder.HasOne(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectId)
                .HasConstraintName("FK_Tasks_Projects_ProjectId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.CreatedBy)
                .HasConstraintName("FK_Tasks_Users_CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}