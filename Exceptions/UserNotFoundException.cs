using System;

namespace DependencyInjection.Exceptions
{
	public class UserNotFoundException : Exception
	{
		public string Email { get; }

		public UserNotFoundException(string email) : base($"User with '{email}' email not found")
		{
			Email = email;
		}
	}
}