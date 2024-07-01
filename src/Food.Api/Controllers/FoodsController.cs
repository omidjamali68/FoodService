using Food.Application.Foods.Commands.Add;
using Food.Application.Foods.Commands.Add.Dtos;
using Food.Application.Foods.Queries.GetAll;
using Food.Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<Guid>> Add(AddFoodDto dto)
        {
            return await _mediator.Send(new AddFoodCommand(dto.Title, dto.Image, dto.FoodIngredients));
        }

        [HttpGet]
        public async Task<Result<GetFoodsResponse>> GetAll(string? search, int page = 1)
        {
            return await _mediator.Send(new GetFoodsQuery(search, page));
        }
    }
}
