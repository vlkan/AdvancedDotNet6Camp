﻿using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.DTOs;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto) 
        {
            RegisterCommand registerCommand = new RegisterCommand()
            {
                UserForRegisterDto = userForRegisterDto,
                IPAddress = GetIpAddress(),
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetReflestTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetReflestTokenToCookie(RefreshToken refreshToken) 
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshTokne", refreshToken.Token, cookieOptions);
        }
    }
}
