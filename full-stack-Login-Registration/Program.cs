using Dapper;
using System.Data.SqlClient;

namespace full_stack_Login_Registration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration["connectionString"];
            var app = builder.Build();

            app.MapGet("/user", () =>
            {
                // This endpoint is for development testing only, will probaly delete later.
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "SELECT * FROM [User]";
                    var usersFromDb = connection.Query<User>(sql);

                    return usersFromDb.Select(
                        user => new { user.Id, user.Username, user.Password });
                }
            });

            app.MapPost("/register", (User user) =>
            {
                var inputValidation = new InputValidation(user);

                if (!inputValidation.HasValidInputsForRegistration())
                {
                    return Results.StatusCode(403);
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    var dbOperation = new DbOperation(connection);
                    dbOperation.InsertIntoUser(user);

                    return Results.StatusCode(201);
                }
            });

            app.UseStaticFiles();

            app.Run();
        }
    }
}