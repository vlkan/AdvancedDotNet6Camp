﻿using Application.Features.Auths.DTOs;
using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto  UserForRegisterDto { get; set; }
        public string IPAddress { get; set; }

        public class UserForRegisterDtoHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;

            public Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
