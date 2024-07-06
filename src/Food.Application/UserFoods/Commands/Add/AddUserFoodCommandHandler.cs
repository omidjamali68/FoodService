using Food.Application.Interfaces;
using Food.Domain.SeedWork;
using Food.Domain.UserFoods;

namespace Food.Application.UserFoods.Commands.Add
{
    internal class AddUserFoodCommandHandler : ICommandHandler<AddUserFoodCommand, Guid>
    {
        private readonly IUserFoodRepository _userFoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserFoodCommandHandler(IUserFoodRepository userFoodRepository, IUnitOfWork unitOfWork)
        {
            _userFoodRepository = userFoodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(AddUserFoodCommand request, CancellationToken cancellationToken)
        {
            var userFood = UserFood.Create(request.NidUser, request.Dto.Title, request.Dto.Image);
            if (userFood.IsFailure)
                return Result.Failure<Guid>(userFood.Error);

            await _userFoodRepository.Add(userFood.Value!);

            await _unitOfWork.SaveChangeAsync();

            return userFood.Value!.Id;
        }
    }
}
