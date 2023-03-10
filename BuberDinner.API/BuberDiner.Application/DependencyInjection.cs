using BuberDiner.Application.Commands;
using BuberDiner.Application.Queries;
using BuberDiner.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace BuberDiner.Application
{
	public static class DependencyInjection
	{
		public static void AddAuthServices(this IServiceCollection servicesCollection)
		{
			//servicesCollection.AddScoped<IAuthenticationService, AuthenticationService>();
			//servicesCollection.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
			//servicesCollection.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

			servicesCollection.AddMediatR(typeof(DependencyInjection).Assembly);
		}
	}
}
