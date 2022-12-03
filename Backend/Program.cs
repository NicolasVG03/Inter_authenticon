namespace authenticon;

using Microsoft.EntityFrameworkCore;
using authenticon.Models;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors();
        builder.Services.AddControllers();

        builder.Services.AddCors(option =>
            option.AddPolicy(name: "MyAllowSpecificOrigins",
            builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));


        builder.Services.AddDbContext<DBauthenticon>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DBauthenticon")));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("MyAllowSpecificOrigins");

        app.MapControllers();

        app.Run();

    }
}