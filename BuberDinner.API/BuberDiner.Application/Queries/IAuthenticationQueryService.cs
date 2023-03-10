using BuberDiner.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuberDiner.Application.Queries
{
	public interface IAuthenticationQueryService
	{
		AuthenticationResult Login(string username, string password);
	}
}
