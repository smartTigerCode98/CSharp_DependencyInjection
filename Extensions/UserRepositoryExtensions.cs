using DependencyInjection.Interfaces.Repositories;

namespace DependencyInjection.Extensions
{
	public static class UserRepositoryExtensions
	{
		public static bool EmailTaken(this IUserRepository userRepository, string email)
		{
			return userRepository.GetByEmail(email) != null;
		}
	}
}