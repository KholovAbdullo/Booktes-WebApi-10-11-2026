using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AuthorsConfiguration : IEntityTypeConfiguration<Authors>
{
    public void Configure(EntityTypeBuilder<Authors> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        builder.Property(x=>x.Fullname).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.Country).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.Birthyear).IsRequired();
        builder.HasMany(x=>x.Books).WithOne(x=>x.Author).HasForeignKey(x=>x.AuthorId).OnDelete(DeleteBehavior.Restrict);
    }
}
