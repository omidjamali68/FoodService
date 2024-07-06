using Food.Domain.UserFoods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Persistence.EF.UserFoods
{
    internal class UserFoodEntityMap : IEntityTypeConfiguration<UserFood>
    {
        public void Configure(EntityTypeBuilder<UserFood> builder)
        {
                        
        }
    }
}
