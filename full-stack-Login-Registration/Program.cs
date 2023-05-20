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

            app.MapGet("/user", async () =>
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "SELECT * FROM [User]";
                    var users = await connection.QueryAsync<User>(sql);
                    return users;
                }
            });
            // For testing purposes, will delete later i think^.

            app.MapPost("/register", (User user) =>
            {
                if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.ConfirmPassword))
                {
                    // Move the logic for validation into InputValidator class^.
                    return Results.StatusCode(403);
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    var dbOperation = new DbOperation(connection);

                    var userFromDb = dbOperation.SelectUserWithId(user.Id);
                    if (userFromDb != null) return Results.StatusCode(409);

                    dbOperation.InsertIntoUser(user);
                    return Results.StatusCode(201);
                }
            });

            app.UseStaticFiles();

            app.Run();
        }
    }
}