using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weddingApp.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couples_Events_WeddingEventId",
                table: "Couples");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Events_WeddingEventID",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Events_WeddingEventId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingServices_Events_WeddingEventId",
                table: "WeddingServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "WeddingEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingEvents",
                table: "WeddingEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Couples_WeddingEvents_WeddingEventId",
                table: "Couples",
                column: "WeddingEventId",
                principalTable: "WeddingEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_WeddingEvents_WeddingEventID",
                table: "Gifts",
                column: "WeddingEventID",
                principalTable: "WeddingEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_WeddingEvents_WeddingEventId",
                table: "Guests",
                column: "WeddingEventId",
                principalTable: "WeddingEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingServices_WeddingEvents_WeddingEventId",
                table: "WeddingServices",
                column: "WeddingEventId",
                principalTable: "WeddingEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couples_WeddingEvents_WeddingEventId",
                table: "Couples");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_WeddingEvents_WeddingEventID",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_WeddingEvents_WeddingEventId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingServices_WeddingEvents_WeddingEventId",
                table: "WeddingServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingEvents",
                table: "WeddingEvents");

            migrationBuilder.RenameTable(
                name: "WeddingEvents",
                newName: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Couples_Events_WeddingEventId",
                table: "Couples",
                column: "WeddingEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Events_WeddingEventID",
                table: "Gifts",
                column: "WeddingEventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Events_WeddingEventId",
                table: "Guests",
                column: "WeddingEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingServices_Events_WeddingEventId",
                table: "WeddingServices",
                column: "WeddingEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
