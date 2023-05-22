using Dapper;
using System.Data.SqlClient;

namespace full_stack_Login_Registration
{
    public class DbOperation
    {
        private SqlConnection _connection;

        public DbOperation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void CreateUser(User user)
        {
            var parameters = new
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
            var sql = "INSERT INTO [User] VALUES (@Id, @Username, @Password)";
            _connection.Execute(sql, parameters);
        }

        public User? FindUser(User user)
        {
            var parameters = new { Username = user.Username, Password = user.Password };
            var sql = "SELECT Username FROM [User] WHERE Username = @Username AND Password = @Password";
            var userFromDb = _connection.QuerySingleOrDefault<User>(sql, parameters);

            return userFromDb;
        }
    }
}