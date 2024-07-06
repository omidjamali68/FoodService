using Food.Application.UserFoods;
using Food.Domain.UserFoods;

namespace Food.Persistence.EF.UserFoods
{
    internal class UserFoodRepository : IUserFoodRepository
    {
        private AppDbContext _context;

        public UserFoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(UserFood userFood)
        {
            await _context.UserFoods.AddAsync(userFood);
        }
    }
}
