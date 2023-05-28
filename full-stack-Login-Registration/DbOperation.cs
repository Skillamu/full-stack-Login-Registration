using Dapper;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace full_stack_Login_Registration
{
    public class DbOperation
    {
        private SqlConnection _connection;

        public DbOperation(SqlConnection connection)
        {
            _connection = connection;
        }

        public void CreateUserInDb(User user)
        {
            user.Id = Guid.NewGuid();
            user.Salt = RandomNumberGenerator.GetBytes(16);

            var parameters = new
            {
                user.Id,
                user.Username,
                Password = PBKDF2.HashPassword(user.Password, user.Salt),
                user.Salt
            };
            var sql = "INSERT INTO [User] VALUES (@Id, @Username, @Password, @Salt)";
            _connection.Execute(sql, parameters);
        }

        public User? GetUserInDb(User user)
        {
            var saltFromUserInDb = GetSaltFromUserInDb(user);
            if (saltFromUserInDb is null) return null;

            var parameters = new
            {
                user.Username,
                Password = PBKDF2.HashPassword(user.Password, saltFromUserInDb)
            };
            var sql = "SELECT Username FROM [User] WHERE Username = @Username AND Password = @Password";
            var userFromDb = _connection.QuerySingleOrDefault<User>(sql, parameters);

            return userFromDb;
        }

        public byte[]? GetSaltFromUserInDb(User user)
        {
            var parameters = new
            {
                user.Username,
            };
            var sql = "SELECT Salt FROM [User] WHERE Username = @Username";
            var saltFromUserInDb = _connection.QuerySingleOrDefault<byte[]>(sql, parameters);

            return saltFromUserInDb;
        }
    }
}