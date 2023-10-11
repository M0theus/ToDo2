using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings;

public class AssignmentListMapping : IEntityTypeConfiguration<AssignmentList>
{
    public void Configure(EntityTypeBuilder<AssignmentList> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .Property(c => c.UserId)
            .IsRequired();

        builder
            .HasMany(c => c.Assignments)
            .WithOne(a => a.AssignmentList)
            .OnDelete(DeleteBehavior.Restrict);
    }
}