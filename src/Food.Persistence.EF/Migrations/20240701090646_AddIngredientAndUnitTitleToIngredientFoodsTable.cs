using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientAndUnitTitleToIngredientFoodsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientTitle",
                table: "FoodIngredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitTitle",
                table: "FoodIngredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientTitle",
                table: "FoodIngredients");

            migrationBuilder.DropColumn(
                name: "UnitTitle",
                table: "FoodIngredients");
        }
    }
}
