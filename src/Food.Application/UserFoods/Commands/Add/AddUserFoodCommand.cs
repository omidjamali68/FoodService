using Food.Application.Interfaces;

namespace Food.Application.UserFoods.Commands.Add
{
    public sealed record AddUserFoodCommand(string NidUser, AddUserFoodDto Dto) : ICommand<Guid>;
}
