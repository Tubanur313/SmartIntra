using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class multiplaceBusnessTripTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BusinessTravels_TicketId",
                table: "BusinessTravels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 14, 30, 9, 136, DateTimeKind.Local).AddTicks(4339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 14, 56, 3, 423, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTravels_TicketId",
                table: "BusinessTravels",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BusinessTravels_TicketId",
                table: "BusinessTravels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 14, 56, 3, 423, DateTimeKind.Local).AddTicks(393),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 31, 14, 30, 9, 136, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTravels_TicketId",
                table: "BusinessTravels",
                column: "TicketId",
                unique: true);
        }
    }
}
