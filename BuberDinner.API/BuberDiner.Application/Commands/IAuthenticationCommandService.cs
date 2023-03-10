using BuberDiner.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuberDiner.Application.Commands
{
	public interface IAuthenticationCommandService
	{
		AuthenticationResult Register(string username, string password, string email);
	}
}
