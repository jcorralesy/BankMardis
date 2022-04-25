using Microsoft.EntityFrameworkCore;
using ModelBD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connDB = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ContextDB>(options => options.UseSqlServer(connDB));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
