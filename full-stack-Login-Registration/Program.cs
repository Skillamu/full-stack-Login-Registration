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

            var registrationEndpoint = new RegistrationEndpoint(connectionString);
            var loginEndpoint = new LoginEndpoint(connectionString);

            app.MapPost("/register", registrationEndpoint.Registration);

            app.MapPost("/login", loginEndpoint.Login);

            var options = new FileServerOptions();
            options.DefaultFilesOptions.DefaultFileNames.Clear();
            options.DefaultFilesOptions.DefaultFileNames.Add("/html/index.html");
            app.UseFileServer(options);

            app.Run();
        }
    }
}