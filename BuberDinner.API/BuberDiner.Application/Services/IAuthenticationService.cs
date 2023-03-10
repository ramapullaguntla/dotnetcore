namespace BuberDiner.Application.Services
{
	public interface IAuthenticationService
	{
		AuthenticationResult Register(string username, string password, string email);

		AuthenticationResult Login(string username, string password);
	}

	public class AuthenticationResult
	{
		public string UserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}
