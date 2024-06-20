using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Persistence.EF.Foods
{
    internal class FoodEntityMap : IEntityTypeConfiguration<Domain.Foods.Food>
    {
        public void Configure(EntityTypeBuilder<Domain.Foods.Food> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Image);

            builder.Property(x => x.Title)
                .HasConversion(x => x.Value, x => Domain.ShareKernel.ValueObjects.Title.Create(x).Value!);
        }
    }
}
