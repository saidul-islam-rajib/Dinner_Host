﻿using ErrorOr;
using FluentResults;
using SoberDinner.Application.Services.Authentication.Common;

namespace SoberDinner.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    }
}
