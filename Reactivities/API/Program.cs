using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. here order doesn't matter

builder.Services.AddControllers();
builder.Services.AddLogging();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline. in other words, what happens when Http request comes in
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers(); // maps the controllers to the application

//create the intial database with scope so that the scope will be later disposed.
using IServiceScope scope = app.Services.CreateScope();
IServiceProvider serviceProvider = scope.ServiceProvider;

try
{
	DataContext dbContext = serviceProvider.GetRequiredService<DataContext>();
    await dbContext.Database.MigrateAsync();
    await Seed.SeedData(dbContext);
}
catch(Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError("Exception occured: " + ex.Message);
}

app.Run();
