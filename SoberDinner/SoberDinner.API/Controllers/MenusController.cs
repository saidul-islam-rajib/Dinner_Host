using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoberDinner.Application.Menus.Commands.CreateMenu;
using SoberDinner.Application.Menus.Queries.MenuQueries;
using SoberDinner.Contracts.Menus;

namespace SoberDinner.API.Controllers
{
    
    
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenusController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("hosts/{hostId}/menus")]
        public async Task<IActionResult> CreateMenu(
            CreateMenuRequest request,
            Guid hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await _mediator.Send(command);

            var response = createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));

            return response;
        }

        [HttpGet]
        [Route("get-all-menus")]
        public async Task<IActionResult> GetAllMenus()
        {
            var query = new GetAllMenusQuery();
            var menus = await _mediator.Send(query);

            var response = _mapper.Map<IEnumerable<MenuResponse>>(menus);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMenuById(Guid id)
        {
            var query = new GetMenuByIdQuery(id);
            var menu = await _mediator.Send(query);

            if (menu is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<MenuResponse>(menu);
            return Ok(response);
        }
    }
}
