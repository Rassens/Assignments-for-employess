using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINAL.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfEnd",
                table: "Projects",
                newName: "DateOfPresumedEnd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfPresumedEnd",
                table: "Projects",
                newName: "DateOfEnd");
        }
    }
}
