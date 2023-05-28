using System.Data.SqlClient;

namespace full_stack_Login_Registration.Endpoints
{
    public class RegisterEndpoint
    {
        private readonly string _connectionString;

        public RegisterEndpoint(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IResult Register(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var dbOperation = new DbOperation(connection);
            var register = new Register(user, dbOperation);
            try
            {
                var registeredUser = register.ConfirmAndCreateUser();

                return registeredUser is not null ? Results.StatusCode(201) : Results.StatusCode(403);
            }
            catch (SqlException)
            {
                return Results.StatusCode(409);
            }
        }
    }
}
