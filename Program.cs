using System;
using DependencyInjection.Controllers;
using DependencyInjection.Interfaces.Repositories;
using DependencyInjection.Interfaces.Services;
using DependencyInjection.Repositories;
using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
	class Program
	{
		private static readonly IServiceProvider _serviceProvider;

		static Program()
		{
			var containerBuilder = new ServiceCollection();

			containerBuilder.AddSingleton<IPasswordHasher, PasswordHasher>()
							.AddScoped<ISignService, SignService>()
							.AddSingleton<IUserRepository, UserRepository>()
							.AddScoped<SignController>();

			_serviceProvider = containerBuilder.BuildServiceProvider();
		}

		static void Main(string[] args)
		{
			while (true)
			{
				using (var scope = _serviceProvider.CreateScope())
				{
					var controller = scope.ServiceProvider.GetRequiredService<SignController>();

					controller.Run();
				}
			}
		}
	}
}