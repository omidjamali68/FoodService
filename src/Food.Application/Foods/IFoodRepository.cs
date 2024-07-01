using Food.Application.Foods.Queries.GetAll;
using Food.Application.Interfaces;
using Food.Domain.SeedWork;

namespace Food.Application.Foods
{
    public interface IFoodRepository : IRepository
    {
        Task Add(Domain.Foods.Food food);
        Task<Result<GetFoodsResponse>> GetAll(string? searchKey, int page);
    }
}
