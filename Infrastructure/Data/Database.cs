using System.Data;
using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Data;

public class Database(DbContextOptions<Database> options):DbContext(options)
{
     public DbSet<Authors> Authors { get; set; }
     public DbSet<Books> Books { get; set; }
     public DbSet<Genres> Genres { get; set;}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         modelBuilder.ApplyConfiguration(new AuthorsConfiguration());
         modelBuilder.ApplyConfiguration(new BooksConfiguration());
         modelBuilder.ApplyConfiguration(new GenresConfiguration()); 
     }
}