using System;
using DependencyInjection.Interfaces.Services;

namespace DependencyInjection.Controllers
{
	public sealed class SignController
	{
		private readonly ISignService _signService;

		public SignController(ISignService signService)
		{
			_signService = signService;
		}

		public void Run()
		{
			var command = RequestPrompt("Sign in/Sign up? (in/up)");

			switch (command)
			{
				case "in":
				{
					SignIn();
					break;
				}

				case "up":
				{
					SignUp();
					break;
				}

				default:
				{
					Console.WriteLine("Invalid command");
					break;
				}
			}
		}

		private void SignIn()
		{
			var email    = RequestPrompt("Enter email");
			var password = RequestPrompt("Enter password");

			try
			{
				var user = _signService.SignIn(email, password);

				Console.WriteLine($"Success sign in! {user.Email}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void SignUp()
		{
			var email    = RequestPrompt("Enter email");
			var password = RequestPrompt("Enter password");

			try
			{
				var user = _signService.SignUp(email, password);

				Console.WriteLine($"Success sign up! {email}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private string RequestPrompt(string prompt)
		{
			Console.Write($"{prompt}: ");

			return Console.ReadLine();
		}
	}
}