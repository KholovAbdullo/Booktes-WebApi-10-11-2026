using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class Database
{
     private string ConnectionString="Host=localhost;Port=5432;Database=HomeTask;Username=postgres;Password=1234";
     public IDbConnection Connection()=>new NpgsqlConnection(ConnectionString);
}