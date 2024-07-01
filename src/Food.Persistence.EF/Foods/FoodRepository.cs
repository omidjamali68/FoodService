using Food.Application.Foods;

namespace Food.Persistence.EF.Foods
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.Foods.Food food)
        {
            await _context.Foods.AddAsync(food);
        }
    }
}
