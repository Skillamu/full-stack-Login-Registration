using System.Data.SqlClient;

namespace full_stack_Login_Registration.Endpoints
{
    public class LoginEndpoint
    {
        private readonly string _connectionString;

        public LoginEndpoint(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IResult Login(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var dbOperation = new DbOperation(connection);
            var login = new Login(user, dbOperation);

            var loggedInUser = login.AuthenticateUser();

            return loggedInUser is not null ? Results.Ok(loggedInUser.Username) : Results.StatusCode(401);
        }
    }
}
