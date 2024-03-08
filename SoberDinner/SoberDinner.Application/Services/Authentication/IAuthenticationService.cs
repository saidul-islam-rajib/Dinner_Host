﻿using OneOf;
using SoberDinner.Application.Common.Errors;

namespace SoberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);
    }
}
