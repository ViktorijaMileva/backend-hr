using Microsoft.EntityFrameworkCore.Migrations;

namespace Hr_management_system.Migrations
{
    public partial class another2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Embg",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Embg",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
