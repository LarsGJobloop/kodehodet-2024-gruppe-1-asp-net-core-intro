internal class Program
{
  private static void Main(string[] args)
  {
    // Builder Pattern
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    // Middleware for serving static files from the "wwwroot" directory
    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.MapGet("/health", () =>
    {
      return "Server OK!";
    });

    app.MapPost("/api/v1/todos", () =>
    {
      return "Recived a POST Request to '/'";
    });

    app.Run();
  }
}