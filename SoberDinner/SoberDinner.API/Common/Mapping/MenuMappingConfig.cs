using Mapster;
using SoberDinner.Application.Menus.Commands.CreateMenu;
using SoberDinner.Contracts.Menus;
using SoberDinner.Domain.MenuAggregate;

using MenuSection = SoberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = SoberDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace SoberDinner.API.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, Guid HostId), CreateMenuCommand > ()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request); 

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
