using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace weddingApp.Migrations
{
    /// <inheritdoc />
    public partial class new_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Couples_CoupleId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Couples_CoupleId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Couples_CoupleId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropIndex(
                name: "IX_Events_CoupleId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "WeddingServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WeddingServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "WeddingDate",
                table: "Couples");

            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "WeddingServices",
                newName: "WeddingEventId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guests",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CoupleId",
                table: "Guests",
                newName: "WeddingEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_CoupleId",
                table: "Guests",
                newName: "IX_Guests_WeddingEventId");

            migrationBuilder.RenameColumn(
                name: "CoupleId",
                table: "Gifts",
                newName: "WeddingEventID");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_CoupleId",
                table: "Gifts",
                newName: "IX_Gifts_WeddingEventID");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "WeddingDate");

            migrationBuilder.RenameColumn(
                name: "CoupleId",
                table: "Events",
                newName: "Budget");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "WeddingServices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "WeddingServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "WeddingServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AccompanyingPerson",
                table: "Guests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Guests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "InviteSended",
                table: "Guests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Guests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WeddingEventId",
                table: "Couples",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WeddingServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_WeddingServices_WeddingServiceId",
                        column: x => x.WeddingServiceId,
                        principalTable: "WeddingServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    GiftId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Things_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeddingServices_WeddingEventId",
                table: "WeddingServices",
                column: "WeddingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Couples_WeddingEventId",
                table: "Couples",
                column: "WeddingEventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_WeddingServiceId",
                table: "Services",
                column: "WeddingServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Things_GiftId",
                table: "Things",
                column: "GiftId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Things");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_WeddingServices_WeddingEventId",
                table: "WeddingServices");

            migrationBuilder.DropIndex(
                name: "IX_Couples_WeddingEventId",
                table: "Couples");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "WeddingServices");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "WeddingServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "WeddingServices");

            migrationBuilder.DropColumn(
                name: "AccompanyingPerson",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "InviteSended",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "WeddingEventId",
                table: "Couples");

            migrationBuilder.RenameColumn(
                name: "WeddingEventId",
                table: "WeddingServices",
                newName: "ServiceType");

            migrationBuilder.RenameColumn(
                name: "WeddingEventId",
                table: "Guests",
                newName: "CoupleId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Guests",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_WeddingEventId",
                table: "Guests",
                newName: "IX_Guests_CoupleId");

            migrationBuilder.RenameColumn(
                name: "WeddingEventID",
                table: "Gifts",
                newName: "CoupleId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_WeddingEventID",
                table: "Gifts",
                newName: "IX_Gifts_CoupleId");

            migrationBuilder.RenameColumn(
                name: "WeddingDate",
                table: "Events",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Events",
                newName: "CoupleId");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "WeddingServices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WeddingServices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "WeddingDate",
                table: "Couples",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoupleId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Couples_CoupleId",
                        column: x => x.CoupleId,
                        principalTable: "Couples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CoupleId",
                table: "Events",
                column: "CoupleId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CoupleId",
                table: "Budgets",
                column: "CoupleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Couples_CoupleId",
                table: "Events",
                column: "CoupleId",
                principalTable: "Couples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Couples_CoupleId",
                table: "Gifts",
                column: "CoupleId",
                principalTable: "Couples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Couples_CoupleId",
                table: "Guests",
                column: "CoupleId",
                principalTable: "Couples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
