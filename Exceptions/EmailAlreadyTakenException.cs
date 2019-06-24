using System;

namespace DependencyInjection.Exceptions
{
	public sealed class EmailAlreadyTakenException : Exception
	{
		public string Email { get; }

		public EmailAlreadyTakenException(string email) : base($"Email '{email}' is already taken")
		{
			Email = email;
		}
	}
}