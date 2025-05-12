using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TaskManagerContext>(opt => opt.UseInMemoryDatabase("TaskManager")); // InMemory database

// builder.Services.AddDbContext<TaskManagerContext>(opt => 
//     opt.UseSqlServer(
//         builder.Configuration.GetConnectionString("AzureConnection"),
//         providerOptions => providerOptions.EnableRetryOnFailure()
//     )
// );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateAsyncScope()) 
{
   var dbContext = scope.ServiceProvider.GetRequiredService<TaskManagerContext>();
   dbContext.Database.EnsureCreated();// in memory scenario
//    dbContext.Database.Migrate(); // This will apply migrations if any are pending.
}

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
