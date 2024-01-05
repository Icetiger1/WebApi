using Domain.Service;
using Microsoft.EntityFrameworkCore;
using WebApiClassLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(
    op =>
    {
        op.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDateTimeServiceProvider, DateTimeService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
