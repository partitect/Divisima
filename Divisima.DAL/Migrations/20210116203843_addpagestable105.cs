using Microsoft.EntityFrameworkCore.Migrations;

namespace Divisima.DAL.Migrations
{
    public partial class addpagestable105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "MenuPages",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MenuPages");
        }
    }
}
