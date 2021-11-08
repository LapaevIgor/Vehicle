using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.DAL.Migrations
{
    public partial class AddCarBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteCarBrand",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCarBrandId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoriteCarBrandId",
                table: "Users",
                column: "FavoriteCarBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CarBrands_FavoriteCarBrandId",
                table: "Users",
                column: "FavoriteCarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CarBrands_FavoriteCarBrandId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavoriteCarBrandId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavoriteCarBrandId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCarBrand",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
