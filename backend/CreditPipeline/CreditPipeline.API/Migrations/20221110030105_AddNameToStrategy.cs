using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditPipeline.API.Migrations
{
    public partial class AddNameToStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Strategies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Strategies");
        }
    }
}
