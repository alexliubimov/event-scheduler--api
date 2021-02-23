using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.EventScheduler.DataAccess.Migrations
{
    public partial class ChangeNameColumnToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "Name");
        }
    }
}
