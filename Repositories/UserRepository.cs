using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Entities;
using DependencyInjection.Interfaces.Repositories;

namespace DependencyInjection.Repositories
{
	public sealed class UserRepository : IUserRepository
	{
		private readonly IList<User> _users;
		private          int         _nextId;

		private int NextId => ++_nextId;

		public UserRepository()
		{
			_users = new List<User>
			{
				new User
				{
					Id           = NextId,
					Email        = "topkek@gmail.com",
					PasswordHash = "233"
				}
			};
		}

		public void Add(User user)
		{
			user.Id = NextId;
			_users.Add(user);
		}

		public void Delete(User user)
		{
			_users.Remove(user);
		}

		public User GetByEmail(string email)
		{
			return _users.FirstOrDefault(u => u.Email == email);
		}
	}
}