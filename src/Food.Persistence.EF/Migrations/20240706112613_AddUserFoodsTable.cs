using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFoodsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NidUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFoods_Foods_Id",
                        column: x => x.Id,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFoods");
        }
    }
}
