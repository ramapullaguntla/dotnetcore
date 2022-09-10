using ECommerce.Application.Services;
using ECommerce.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfraServices(this IServiceCollection services)
		{
			return services.AddScoped<IProductService, ProductDBContext>();
		}
	}
}
