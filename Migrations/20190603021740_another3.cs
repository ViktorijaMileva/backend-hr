using Microsoft.EntityFrameworkCore.Migrations;

namespace Hr_management_system.Migrations
{
    public partial class another3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Embg",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Embg",
                table: "AspNetUsers");
        }
    }
}
