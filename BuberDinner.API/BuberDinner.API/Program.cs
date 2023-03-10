using BuberDiner.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthServices();

var app = builder.Build();
{
	app.UseHttpsRedirection();
	app.MapControllers();

	app.Run();
}
