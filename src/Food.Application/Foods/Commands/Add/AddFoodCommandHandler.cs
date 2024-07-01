using Food.Application.Interfaces;
using Food.Common;
using Food.Domain.SeedWork;

namespace Food.Application.Foods.Commands.Add
{
    internal class AddFoodCommandHandler : ICommandHandler<AddFoodCommand, Guid>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(AddFoodCommand request, CancellationToken cancellationToken)
        {            
            var food = Domain.Foods.Food.Create(request.Title, request.Image);

            if (food.IsFailure)
                return Result.Failure<Guid>(food.Error);

            request.FoodIngredients.ForEach(i => 
                food.Value!.AddIngredient(i.quantity, i.ingredientUnitId, i.ingredientTitle, i.unitTitle));

            await _foodRepository.Add(food.Value!);

            await _unitOfWork.SaveChangeAsync();

            return food.Value!.Id;
        }
    }
}
