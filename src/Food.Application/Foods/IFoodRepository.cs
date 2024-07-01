using Food.Application.Interfaces;

namespace Food.Application.Foods
{
    public interface IFoodRepository : IRepository
    {
        Task Add(Domain.Foods.Food food);
    }
}
