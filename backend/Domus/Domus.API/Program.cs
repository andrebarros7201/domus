using Domus.API.Data;
using Domus.API.Repositories.Implementations;
using Domus.API.Repositories.Interfaces;
using Domus.API.Services.Implementations;
using Domus.API.Services.Interfaces;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace Domus.API;

public class Program {
    public static void Main(string[] args) {
        // Load env variables
        Env.Load();

        var builder = WebApplication.CreateBuilder(args);


        builder.Configuration.AddEnvironmentVariables();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Domus.API", Version = "v1" }); }
        );
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<TokenService>();

        builder.Services.AddCors(options => {
            options.AddPolicy("AllowFrontend", builder => builder
            .WithOrigins(Configuration.FRONTEND_URL)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            );
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Domus.API v1");
                c.RoutePrefix = "";
            });
        }
        // Allow requests from frontend
        app.UseCors("AllowFrontend");

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}