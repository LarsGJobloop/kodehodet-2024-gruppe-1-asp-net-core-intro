internal class Program
{
  private static void Main(string[] args)
  {
    // The web server is a complex piece of software
    // So it's constructed in a two step process
    // called the builder pattern
    // https://en.wikipedia.org/wiki/Builder_pattern
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    // Middleware for serving "index.html" at "/", rather then "/index.html"
    app.UseDefaultFiles();
    // Middleware for serving static files from the "wwwroot" directory
    app.UseStaticFiles();

    // You can setup individual functions here
    // that should be executed when called and return som value

    // GET localhost:xxxx/health -> "Server OK"
    app.MapGet("/health", () =>
    {
      return "Server OK!";
    });

    // POST localhost:xxxx/api/v1/todoes -> "Recievd a POST Request to '/api/v1/todoes'"
    app.MapPost("/api/v1/todos", () =>
    {
      return "Recived a POST Request to '/api/v1/todoes'";
    });

    // After configuration, then start the application
    app.Run();
  }
}