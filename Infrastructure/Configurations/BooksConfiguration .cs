using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        builder.Property(x=>x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.Publishedyear).IsRequired();
        builder.Property(x=>x.Totalcopies).IsRequired();
        builder.HasOne(x=>x.Author).WithMany(x=>x.Books).HasForeignKey(x=>x.AuthorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x=>x.Genre).WithMany(x=>x.Books).HasForeignKey(x=>x.GenreId).OnDelete(DeleteBehavior.Restrict);
    }
}
