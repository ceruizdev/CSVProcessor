using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSVApplication.DataAccess.Migrations
{
    public partial class Delimiter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Delimiter",
                table: "CSVBody",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delimiter",
                table: "CSVBody");
        }
    }
}
