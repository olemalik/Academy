using System.Data.SQLite;


namespace Academy.Infrastructure.DAL
{
    public static class DatabaseCreation
    {
        public static void InitializeDatabase(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Students (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    DateOfBirth TEXT NOT NULL,
                    Email TEXT NOT NULL
                );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
