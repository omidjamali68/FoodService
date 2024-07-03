using Food.Application.Interfaces;
using Food.Common;
using Food.Domain.Foods;
using Food.Domain.SeedWork;

namespace Food.Application.Foods.Commands.Update
{
    internal class UpdateFoodCommandHandler : ICommandHandler<UpdateFoodCommand>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _foodRepository.FindById(request.Id);

            if (food == null)
                return FoodErrors.NotExist;

            food.Update(request.Dto.Title, request.Dto.Image);

            if (request.Dto.ingredients != null)
            {
                request.Dto.ingredients.ForEach(x =>
                    food.AddIngredient(x.Quantity, x.IngredientUnitId, x.IngredientTitle, x.UnitTitle));
            }                

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
