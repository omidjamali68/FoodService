using Food.Application.Interfaces;

namespace Food.Application.Foods.Queries.GetAll
{
    public sealed record GetFoodsQuery(string? searchKey, int page) : IQuery<GetFoodsResponse>;
}
