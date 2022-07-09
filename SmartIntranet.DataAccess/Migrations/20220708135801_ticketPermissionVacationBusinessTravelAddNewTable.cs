using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class ticketPermissionVacationBusinessTravelAddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 8, 17, 58, 0, 913, DateTimeKind.Local).AddTicks(5057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 29, 10, 2, 5, 492, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.CreateTable(
                name: "BusinessTravels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteByUserId = table.Column<int>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Transport = table.Column<bool>(nullable: false),
                    Accommodation = table.Column<bool>(nullable: false),
                    Staylength = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    CauseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTravels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTravels_Causes_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Causes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessTravels_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessTravels_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteByUserId = table.Column<int>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Reason = table.Column<string>(type: "ntext", nullable: false),
                    PermissionCreateDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteByUserId = table.Column<int>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    VacationKind = table.Column<byte>(nullable: false),
                    Vacationlength = table.Column<int>(nullable: false),
                    VacationCreateDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationLeaves_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTravels_CauseId",
                table: "BusinessTravels",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTravels_PlaceId",
                table: "BusinessTravels",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTravels_TicketId",
                table: "BusinessTravels",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_TicketId",
                table: "Permissions",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacationLeaves_TicketId",
                table: "VacationLeaves",
                column: "TicketId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessTravels");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "VacationLeaves");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 10, 2, 5, 492, DateTimeKind.Utc).AddTicks(3033),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 7, 8, 17, 58, 0, 913, DateTimeKind.Local).AddTicks(5057));
        }
    }
}
