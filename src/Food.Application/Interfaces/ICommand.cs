using Food.Domain.SeedWork;
using MediatR;

namespace Food.Application.Interfaces
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
