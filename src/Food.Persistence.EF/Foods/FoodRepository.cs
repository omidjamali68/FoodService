using Food.Application.Foods;
using Food.Application.Foods.Queries.GetAll;
using Food.Application.Foods.Queries.GetById;
using Food.Common;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GetFoodsResponse> GetAll(string? searchKey, int page)
        {
            var foods = _context.Foods.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                foods = foods.Where(x => ((string)x.Title).Contains(searchKey));
            }

            var reult = foods.Select(x => new GetFoodsDto
            {
                Id = x.Id,
                Title = x.Title.Value
            }).AsNoTracking();

            var rows = 0;
            var data = await reult.ToPaged(page, 20, out rows).ToListAsync();

            return new GetFoodsResponse
            {
                Rows = rows,
                Data = data
            };
        }

        public async Task<GetFoodByIdDto?> GetById(Guid id)
        {
            return await _context.Foods
                .Include(x => x.Ingredients)
                .Select(x => 
                    new GetFoodByIdDto
                    {
                        Id = x.Id,
                        Title = x.Title.Value,
                        ingredients = x.Ingredients.Select(i =>
                            new FoodIngredientDto(
                                i.IngredientTitle,
                                i.UnitTitle,
                                i.Quantity.Value))
                        .ToHashSet()
                    })
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
