using System.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Data;

public class Database(DbContextOptions<Database> options):DbContext(options)
{
     public DbSet<Authors> Authors { get; set; }
     public DbSet<Books> Books { get; set; }
     public DbSet<Genres> Genres { get; set;}
}