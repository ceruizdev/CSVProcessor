using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSVApplication.DataAccess.Migrations
{
    public partial class FileAsBase64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "CSVBody",
                newName: "FileAsBase64");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileAsBase64",
                table: "CSVBody",
                newName: "Body");
        }
    }
}
