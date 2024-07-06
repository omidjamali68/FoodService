using Food.Application.UserFoods.Commands.Add;
using Food.Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserFoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<Guid>> Add(AddUserFoodDto dto)
        {
            return await _mediator.Send(new AddUserFoodCommand("1", dto));
        }
    }
}
