using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Academy.Infrastructure.DAL
{
    public class ApplicationDbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext()
        {
              _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IDbConnection CreateConnection()
        {

            return new SQLiteConnection(_connectionString);
        }

        public void InitializeDatabase()
        {
            if (!DoesStudentsTableExist())
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();

                    var createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        DateOfBirth TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        QRCode TEXT NULL
                    );
                    INSERT INTO Students (FirstName, LastName, DateOfBirth, Email) VALUES
                    ('John', 'Doe', '2000-01-15', 'john.doe@example.com'),
                    ('Jane', 'Smith', '1999-05-22', 'jane.smith@example.com'),
                    ('Emily', 'Jones', '2001-08-30', 'emily.jones@example.com'),
                    ('Michael', 'Brown', '2000-12-12', 'michael.brown@example.com'),
                    ('Olivia', 'Davis', '1998-07-04', 'olivia.davis@example.com');

                   ";


                    using (var command = new SQLiteCommand(createTableQuery, (SQLiteConnection)connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public bool DoesStudentsTableExist()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                // Query to check if the Students table exists
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='Students';";
                using (var checkCmd = new SQLiteCommand(checkTableQuery, (SQLiteConnection)connection))
                {
                    var result = checkCmd.ExecuteScalar();

                    // If result is not null, the table exists
                    return result != null;
                }
            }
        }

    }
}
