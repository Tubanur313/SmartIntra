using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class doubleMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 0, 21, 24, 872, DateTimeKind.Local).AddTicks(927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 6, 23, 59, 56, 489, DateTimeKind.Local).AddTicks(1740));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 23, 59, 56, 489, DateTimeKind.Local).AddTicks(1740),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 11, 7, 0, 21, 24, 872, DateTimeKind.Local).AddTicks(927));
        }
    }
}
