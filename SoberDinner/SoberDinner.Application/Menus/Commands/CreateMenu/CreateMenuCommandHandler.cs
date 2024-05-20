﻿using ErrorOr;
using MediatR;
using SoberDinner.Application.Common.Interfaces.Persistence;
using SoberDinner.Domain.HostAggregate.ValueObjects;
using SoberDinner.Domain.MenuAggregate;
using SoberDinner.Domain.MenuAggregate.Entities;

namespace SoberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1.Create Menu
            Menu menu = Menu.Create(
                hostId: HostId.Create(request.HostId),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description)))));

            _menuRepository.Add(menu);


            return menu;
        }

       
    }
}
