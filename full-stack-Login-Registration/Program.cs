using full_stack_Login_Registration.Endpoints;

namespace full_stack_Login_Registration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration["connectionString"];
            var app = builder.Build();

            var registerEndpoint = new RegisterEndpoint(connectionString);
            var loginEndpoint = new LoginEndpoint(connectionString);

            app.MapPost("/register", registerEndpoint.Register);

            app.MapPost("/login", loginEndpoint.Login);

            app.UseStaticFiles();

            app.Run();
        }
    }
}