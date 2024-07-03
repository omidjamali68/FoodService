using Food.Application.Interfaces;

namespace Food.Application.Foods.Commands.Delete
{
    public sealed record DeleteFoodCommand(Guid Id) : ICommand;
}
