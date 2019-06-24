using DependencyInjection.Entities;

namespace DependencyInjection.Interfaces.Repositories
{
	public interface IUserRepository
	{
		void Add(User user);

		void Delete(User user);

		User GetByEmail(string email);
	}
}