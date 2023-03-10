using BuberDiner.Application.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BuberDiner.Application.Commands
{
	public class RegisterCommand : IRequest<AuthenticationResult>
	{
		public RegisterCommand(string userID, string password, string email)
		{
			UserID = userID;
			Password = password;
			Email = email;
		}

		public string UserID { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		
	}

	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
	{
		public Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			AuthenticationResult result = new AuthenticationResult();

			result.Email = request.Email;
			result.Name = request.Password;
			result.Token = Guid.NewGuid().ToString();

			return Task.FromResult(result);
		}
	}
}
