using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoberDinner.Application.Menus.Commands.CreateMenu;
using SoberDinner.Contracts.Menus;

namespace SoberDinner.API.Controllers
{
    [Route("hosts/{hostId}/menus")]
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

            //if (createMenuResult.IsError)
            //{
            //    return BadRequest(createMenuResult.Errors);
            //}
            //var createdMenu = createMenuResult.Value;
            //return Ok(createdMenu);
        }
    }
}
