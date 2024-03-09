﻿using ErrorOr;
using FluentValidation;
using MediatR;
using SoberDinner.Application.Authentication.Commands.Register;
using SoberDinner.Application.Authentication.Common;

namespace SoberDinner.Application.Common.Behaviors
{
    public class ValidationRegisterCommandBehavior
        : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidationRegisterCommandBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));


            return errors;
        }
    }
}
