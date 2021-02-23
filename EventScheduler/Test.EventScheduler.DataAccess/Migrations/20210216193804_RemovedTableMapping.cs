using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.EventScheduler.DataAccess.Migrations
{
    public partial class RemovedTableMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_OrganizerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendee_Event_EventId",
                table: "EventAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendee_User_UserId",
                table: "EventAttendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAttendee",
                table: "EventAttendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "EventAttendee",
                newName: "EventAttendees");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendee_UserId",
                table: "EventAttendees",
                newName: "IX_EventAttendees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_OrganizerId",
                table: "Events",
                newName: "IX_Events_OrganizerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAttendees",
                table: "EventAttendees",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Events_EventId",
                table: "EventAttendees",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Users_UserId",
                table: "EventAttendees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Events_EventId",
                table: "EventAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Users_UserId",
                table: "EventAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_OrganizerId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAttendees",
                table: "EventAttendees");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "EventAttendees",
                newName: "EventAttendee");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OrganizerId",
                table: "Event",
                newName: "IX_Event_OrganizerId");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendees_UserId",
                table: "EventAttendee",
                newName: "IX_EventAttendee_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAttendee",
                table: "EventAttendee",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_OrganizerId",
                table: "Event",
                column: "OrganizerId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendee_Event_EventId",
                table: "EventAttendee",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendee_User_UserId",
                table: "EventAttendee",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
