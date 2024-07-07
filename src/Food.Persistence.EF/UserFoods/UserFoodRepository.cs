using Food.Application.Foods.Queries.GetAll;
using Food.Application.UserFoods;
using Food.Common;
using Food.Domain.UserFoods;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GetFoodsResponse> GetAll(string nidUser, string? searchKey, int page)
        {
            var foods = _context.UserFoods
                .Where(x => x.NidUser.Equals(nidUser))
                .AsNoTracking();

            if (searchKey != null)
                foods = foods.Where(x => ((string)x.Title).Contains(searchKey));

            var result = foods.Select(x => new 
                GetFoodsDto { Id = x.Id, Title = x.Title.Value, Image = x.Image });

            var rows = 0;
            var data = await result.ToPaged(page, 20, out rows).ToListAsync();

            return new GetFoodsResponse
            {
                Rows = rows,
                Data = data
            };
        }
    }
}
