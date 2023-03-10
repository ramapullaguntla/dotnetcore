using BuberDiner.Application.Commands;
using BuberDiner.Application.Services;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
	[Route("auth")]
	public class AuthenticationController : ControllerBase
	{
		
		IMediator _mediatr = null;
		public	AuthenticationController(IMediator mediator)
		{
			
			_mediatr = mediator;
		}

		[Route("register")]
		[HttpPost]
		public IActionResult Register([FromBody] LoginRequest loginRequest)
		{
			RegisterCommand command = new RegisterCommand(loginRequest.UserName, loginRequest.Email, loginRequest.Password);

			Task<AuthenticationResult> res = _mediatr.Send(command);
			//var result = _authService.Register(loginRequest.UserName, loginRequest.Email, loginRequest.Password);

			return Ok(res.Result);
		}

		[Route("login")]
		[HttpPost]
		public IActionResult Login([FromBody] LoginRequest loginRequest)
		{
			//var result = _authService.Login(loginRequest.UserName, loginRequest.Password);
			return Ok();			
		}
	}
}
