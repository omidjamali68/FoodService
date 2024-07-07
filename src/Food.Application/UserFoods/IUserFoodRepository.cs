using Food.Application.Foods.Queries.GetAll;
using Food.Application.Interfaces;
using Food.Domain.UserFoods;

namespace Food.Application.UserFoods
{
    public interface IUserFoodRepository : IRepository
    {
        Task Add(UserFood userFood);
        Task<GetFoodsResponse> GetAll(string nidUser, string? searchKey, int page);
    }
}
