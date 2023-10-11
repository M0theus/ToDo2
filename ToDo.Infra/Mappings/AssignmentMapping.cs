using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings;

public class AssignmentMapping : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Description)
            .IsRequired()
            .HasColumnType("VARCHAR(255)");

        builder
            .Property(c => c.UserId)
            .IsRequired();

        builder
            .Property(c => c.AssignmentListId)
            .IsRequired(false);

        builder
            .Property(c => c.DeadLine)
            .HasColumnType("DATETIME")
            .IsRequired(false);

        builder
            .Property(c => c.Conclued)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnType("TINYINT");
    }
}