using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.DAL.Migrations
{
    public partial class DeletedDateTimeToUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "Users");
        }
    }
}
