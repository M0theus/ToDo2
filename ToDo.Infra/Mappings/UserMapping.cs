using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .Property(c => c.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .Property(c => c.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .HasMany(c => c.Assignments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(c => c.AssignmentLists)
            .WithOne(al => al.User)
            .OnDelete(DeleteBehavior.Restrict);
    }
}