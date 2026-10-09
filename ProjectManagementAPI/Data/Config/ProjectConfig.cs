using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagementAPI.Data.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.ProjectId);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(30);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.CreatedBy)
                .HasConstraintName("FK_Projects_Users_CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
