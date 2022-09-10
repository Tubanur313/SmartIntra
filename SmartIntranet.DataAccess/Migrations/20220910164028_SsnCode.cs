using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class SsnCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SsnCode",
                schema: "Membership",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 10, 20, 40, 27, 575, DateTimeKind.Local).AddTicks(6756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 4, 22, 49, 22, 595, DateTimeKind.Local).AddTicks(8774));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SsnCode",
                schema: "Membership",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 4, 22, 49, 22, 595, DateTimeKind.Local).AddTicks(8774),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 9, 10, 20, 40, 27, 575, DateTimeKind.Local).AddTicks(6756));
        }
    }
}
