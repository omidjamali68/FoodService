using Food.Domain.SeedWork;
using MediatR;

namespace Food.Application.Interfaces
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
