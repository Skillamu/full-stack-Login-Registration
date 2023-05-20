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

        public User? SelectUserWithId(Guid userId)
        {
            var parameters = new { Id = userId };
            var sql = "SELECT * FROM [User] WHERE Id = @Id";
            var userFromDb = _connection.QuerySingleOrDefault<User>(sql, parameters);

            return userFromDb is not null ? userFromDb : null;
        }

        public void InsertIntoUser(User user)
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
    }
}
