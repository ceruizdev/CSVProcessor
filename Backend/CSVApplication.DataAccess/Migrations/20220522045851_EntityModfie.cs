using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSVApplication.DataAccess.Migrations
{
    public partial class EntityModfie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CSVBody",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CSVBody");
        }
    }
}
