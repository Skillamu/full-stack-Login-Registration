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
                var registerValidation = new RegisterValidation(user);

                if (!registerValidation.HasValidInputs())
                {
                    return Results.StatusCode(403);
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    var dbOperation = new DbOperation(connection);
                    try
                    {
                        dbOperation.CreateUser(user);
                        return Results.StatusCode(201);
                    }
                    catch
                    {
                        return Results.StatusCode(409);
                    }
                }
            });

            app.MapPost("/login", (User user) =>
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var dbOperation = new DbOperation(connection);
                    var loginAuthentication = new LoginAuthentication(dbOperation, user);

                    if (!loginAuthentication.WasSuccessful())
                    {
                        return Results.StatusCode(401);
                    }

                    return Results.StatusCode(200);
                }
            });

            app.UseStaticFiles();

            app.Run();
        }
    }
}