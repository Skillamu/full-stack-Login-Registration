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

            app.MapPost("/user", async (User user) =>
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new {
                        Id = user.Id,
                        Username = user.Username,
                        Password = user.Password
                    };

                    var parametersTest = new { Id = user.Id };
                    var sqlTest = "SELECT * FROM [User] WHERE Id = @Id";
                    var users = await connection.QueryAsync<User>(sqlTest, parametersTest);

                    if (users.Count() != 0)
                    {
                        return Results.Conflict();
                    }
                    else
                    {
                        var sql = "INSERT INTO [User] VALUES (@Id, @Username, @Password)";
                        connection.Execute(sql, parameters);
                        return Results.Created("Successfully created a new user.", user);
                    }
                }
            });

            app.Run();
        }
    }
}