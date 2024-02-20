using Domain.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiClassLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(
    op =>
    {
        op.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"), npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
    }
);


builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    }
    );
builder.Services.AddControllers();
builder.Services.AddTransient<IDateTimeServiceProvider, DateTimeService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(c =>
         {
        c.RouteTemplate = "/swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.MapControllers();
app.Run();
