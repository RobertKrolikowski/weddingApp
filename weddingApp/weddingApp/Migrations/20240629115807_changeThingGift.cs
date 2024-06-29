using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weddingApp.Migrations
{
    /// <inheritdoc />
    public partial class changeThingGift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_Gifts_GiftId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_GiftId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "GiftId",
                table: "Things");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Things",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gifts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ThingId",
                table: "Gifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_ThingId",
                table: "Gifts",
                column: "ThingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Things_ThingId",
                table: "Gifts",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Things_ThingId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_ThingId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "ThingId",
                table: "Gifts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Things",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftId",
                table: "Things",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gifts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Things_GiftId",
                table: "Things",
                column: "GiftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Gifts_GiftId",
                table: "Things",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
