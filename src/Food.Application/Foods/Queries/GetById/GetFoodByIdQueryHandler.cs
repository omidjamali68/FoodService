using Food.Application.Interfaces;
using Food.Domain.Foods;
using Food.Domain.SeedWork;

namespace Food.Application.Foods.Queries.GetById
{
    internal class GetFoodByIdQueryHandler : IQueryHandler<GetFoodByIdQuery, GetFoodByIdDto>
    {
        private readonly IFoodRepository _foodRepository;

        public GetFoodByIdQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Result<GetFoodByIdDto>> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            var food = await _foodRepository.GetById(request.ID);

            if (food == null)
                return Result.Failure<GetFoodByIdDto>(FoodErrors.NotExist.Error);

            return food;
        }
    }
}
