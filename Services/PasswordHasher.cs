using System.Linq;
using DependencyInjection.Interfaces.Services;

namespace DependencyInjection.Services
{
	public sealed class PasswordHasher : IPasswordHasher
	{
		public string Hash(string value)
		{
			return new string(value.Reverse().ToArray());
		}

		public bool Verify(string hash, string givenPassword)
		{
			return hash == Hash(givenPassword);
		}
	}
}