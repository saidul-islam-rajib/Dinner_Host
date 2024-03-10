﻿using FluentValidation;

namespace SoberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator
        : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
        }
    }
}
