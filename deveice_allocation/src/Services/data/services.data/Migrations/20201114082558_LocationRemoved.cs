using Microsoft.EntityFrameworkCore.Migrations;

namespace services.data.Migrations
{
    public partial class LocationRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "assetsummaries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "assetsummaries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
