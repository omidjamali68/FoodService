using Food.Application.Foods.Queries.GetAll;
using Food.Application.Interfaces;

namespace Food.Application.UserFoods.Queries.GetAll
{
    public sealed record GetUserFoodsQuery(string NidUser, string? searchKey, int page) : IQuery<GetFoodsResponse>;
}
