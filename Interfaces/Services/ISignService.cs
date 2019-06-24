using DependencyInjection.Entities;

namespace DependencyInjection.Interfaces.Services
{
	public interface ISignService
	{
		User SignUp(string email, string password);
		
		User SignIn(string email, string password);
	}
}