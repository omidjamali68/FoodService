using Food.Application.Foods.Queries.GetAll;
using Food.Application.UserFoods.Commands.Add;
using Food.Application.UserFoods.Queries.GetAll;
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

        [HttpGet]
        public async Task<Result<GetFoodsResponse>> GetAll(string? searchKey, int page = 1)
        {
            return await _mediator.Send(new GetUserFoodsQuery("1", searchKey, page));
        }
    }
}
