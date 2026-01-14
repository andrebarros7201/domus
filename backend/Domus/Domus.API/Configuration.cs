namespace Domus.API;

static class Configuration {
    internal static string JWT_SECRET { get; } = Environment.GetEnvironmentVariable("JWT_SECRET");
    internal static string FRONTEND_URL { get; } = Environment.GetEnvironmentVariable("FRONTEND_URL");
}