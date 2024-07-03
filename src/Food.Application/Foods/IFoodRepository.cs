using Food.Application.Foods.Queries.GetAll;
using Food.Application.Foods.Queries.GetById;
using Food.Application.Interfaces;

namespace Food.Application.Foods
{
    public interface IFoodRepository : IRepository
    {
        Task Add(Domain.Foods.Food food);
        Task<GetFoodsResponse> GetAll(string? searchKey, int page);
        Task<GetFoodByIdDto?> GetById(Guid id);
    }
}
