using Food.Application.Interfaces;
using Food.Domain.Foods;
using Food.Domain.SeedWork;

namespace Food.Application.Foods.Commands.Delete
{
    internal class DeleteFoodCommandHandler : ICommandHandler<DeleteFoodCommand>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _foodRepository.FindById(request.Id);

            if (food == null)
                return FoodErrors.NotExist;

            _foodRepository.Delete(food);

            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
