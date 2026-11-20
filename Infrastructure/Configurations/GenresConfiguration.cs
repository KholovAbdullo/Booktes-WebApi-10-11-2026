using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GenresConfiguration : IEntityTypeConfiguration<Genres>
{
    public void Configure(EntityTypeBuilder<Genres> builder)
    {
        builder.ToTable("Genres");
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
        builder.HasMany(x=>x.Books).WithOne(x=>x.Genre).HasForeignKey(x=>x.GenreId).OnDelete(DeleteBehavior.Restrict);
    }
}
