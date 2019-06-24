namespace DependencyInjection.Interfaces.Services
{
	public interface IPasswordHasher
	{
		string Hash(string value);

		bool Verify(string hash, string givenPassword);
	}
}