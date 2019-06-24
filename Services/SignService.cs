using System.Reflection.Metadata.Ecma335;
using DependencyInjection.Entities;
using DependencyInjection.Exceptions;
using DependencyInjection.Extensions;
using DependencyInjection.Interfaces.Repositories;
using DependencyInjection.Interfaces.Services;

namespace DependencyInjection.Services
{
	public sealed class SignService : ISignService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordHasher _passwordHasher;

		public SignService(IUserRepository userRepository, IPasswordHasher passwordHasher)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
		}

		public User SignUp(string email, string password)
		{
			if (_userRepository.EmailTaken(email))
			{
				throw new EmailAlreadyTakenException(email);
			}

			var user = new User
			{
				Email        = email,
				PasswordHash = _passwordHasher.Hash(password)
			};
			
			_userRepository.Add(user);

			return user;
		}

		public User SignIn(string email, string password)
		{
			var user = _userRepository.GetByEmail(email);

			if (user == null)
			{
				throw new UserNotFoundException(email);
			}

			if (!_passwordHasher.Verify(user.PasswordHash, password))
			{
				throw new PasswordMismatchException();
			}

			return user;
		}
	}
}