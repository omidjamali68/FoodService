using Food.Application.Foods.Queries.GetAll;
using Food.Application.Interfaces;
using Food.Domain.SeedWork;

namespace Food.Application.UserFoods.Queries.GetAll
{
    internal class GetUserFoodsQueryHandler : IQueryHandler<GetUserFoodsQuery, GetFoodsResponse>
    {
        private readonly IUserFoodRepository _userFoodRepository;

        public GetUserFoodsQueryHandler(IUserFoodRepository userFoodRepository)
        {
            _userFoodRepository = userFoodRepository;
        }

        public async Task<Result<GetFoodsResponse>> Handle(GetUserFoodsQuery request, CancellationToken cancellationToken)
        {
            return await _userFoodRepository.GetAll(request.NidUser, request.searchKey, request.page);
        }
    }
}
