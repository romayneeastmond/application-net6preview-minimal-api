public static class Application
{
    public static void AddRoutesApplication(this WebApplication app)
    {
        app.MapGet("/", HelloWorld);

        static string HelloWorld()
        {
            return "Hello World demonstration of .NET 6 Preview and Minimal Api.";
        };
    }
}