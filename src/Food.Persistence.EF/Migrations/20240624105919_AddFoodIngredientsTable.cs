using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodIngredientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodIngredients",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientUnitId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIngredients", x => new { x.FoodId, x.IngredientUnitId });
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodIngredients");
        }
    }
}
