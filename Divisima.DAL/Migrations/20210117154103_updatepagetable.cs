using Microsoft.EntityFrameworkCore.Migrations;

namespace Divisima.DAL.Migrations
{
    public partial class updatepagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "MenuPages",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "MenuPages");
        }
    }
}
