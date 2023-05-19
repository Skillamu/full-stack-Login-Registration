using Dapper;
using System.Data.SqlClient;

namespace full_stack_Login_Registration
{
    public class DbOperation
    {
        public SqlConnection _connection;

        public DbOperation(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>?> SelectUserWithId(Guid userId)
        {
            var parameters = new { Id = userId };
            var sql = "SELECT * FROM [User] WHERE Id = @Id";

            var users = await _connection.QueryAsync<User>(sql, parameters);

            return users.Count() > 0 ? users : null;
        }
    }
}
