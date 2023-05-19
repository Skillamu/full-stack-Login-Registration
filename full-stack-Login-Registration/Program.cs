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
            // Delete later^ Just for testing atm.

            app.MapPost("/register", async (User user) =>
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var dbOperation = new DbOperation(connection);

                    var usersFromDb = await dbOperation.SelectUserWithId(user.Id);

                    if (usersFromDb != null) return Results.Conflict();

                    var parameters = new
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Password = user.Password
                    };
                    var sql = "INSERT INTO [User] VALUES (@Id, @Username, @Password)";
                    connection.Execute(sql, parameters);
                    return Results.Created("Successfully created a new user.", user);
                    // Make method for this code in DbOperation class^
                }
            });

            app.UseStaticFiles();

            app.Run();
        }
    }
}