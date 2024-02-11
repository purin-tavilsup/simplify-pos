using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SQLite;

namespace SimplifyPos.Infrastructure.Data.Sqlite;

public class AppDbContext
{
	private readonly string _connectionString;

	public AppDbContext(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("SqliteDb") ?? string.Empty;
	}

	public IDbConnection CreateConnection() => new SQLiteConnection(_connectionString);
}