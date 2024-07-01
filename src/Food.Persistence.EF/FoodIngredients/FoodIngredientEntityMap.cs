using Food.Domain.FoodIngredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Persistence.EF.FoodIngredients
{
    internal class FoodIngredientEntityMap : IEntityTypeConfiguration<FoodIngredient>
    {
        public void Configure(EntityTypeBuilder<FoodIngredient> builder)
        {
            builder.HasKey(x => new {x.FoodId, x.IngredientUnitId});

            builder.Property(x => x.Quantity)
                .HasConversion(
                    x => x.Value, 
                    x => Domain.FoodIngredients.ValueObjects.Quantity.Create(x).Value!);

            builder.Property(x => x.IngredientTitle);

            builder.Property(x => x.UnitTitle);

            builder.HasOne(x => x.Food)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.FoodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
