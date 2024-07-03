using Food.Application.Interfaces;

namespace Food.Application.Foods.Queries.GetById
{
    public record GetFoodByIdQuery(Guid ID) : IQuery<GetFoodByIdDto>;
}
