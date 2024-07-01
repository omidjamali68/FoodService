using Food.Application.Interfaces;
using Food.Domain.SeedWork;

namespace Food.Application.Foods.Queries.GetAll
{
    internal class GetFoodsQueryHandler : IQueryHandler<GetFoodsQuery, GetFoodsResponse>
    {
        private readonly IFoodRepository _foodRepository;

        public GetFoodsQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Result<GetFoodsResponse>> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
        {
            return await _foodRepository.GetAll(request.searchKey, request.page);
        }
    }
}
