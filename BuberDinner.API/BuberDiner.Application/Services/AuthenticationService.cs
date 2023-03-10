using System;
using System.Collections.Generic;
using System.Text;

namespace BuberDiner.Application.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		public AuthenticationResult Login(string username, string password)
		{
			AuthenticationResult result = new AuthenticationResult();

			result.UserID = username;
			result.Name = username;
			result.Token = Guid.NewGuid().ToString();

			return result;
		}

		public AuthenticationResult Register(string username, string password, string email)
		{
			AuthenticationResult result = new AuthenticationResult();

			result.Email = email;
			result.Name = username;
			result.Token = Guid.NewGuid().ToString();

			return result;
		}
	}
}
