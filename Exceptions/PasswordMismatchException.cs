using System;

namespace DependencyInjection.Exceptions
{
	public sealed class PasswordMismatchException : Exception
	{
		public PasswordMismatchException() : base("Invalid password") { }
	}
}