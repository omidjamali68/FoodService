namespace Food.Application.Foods.Queries.GetAll
{
    public sealed record GetFoodsDto()
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
