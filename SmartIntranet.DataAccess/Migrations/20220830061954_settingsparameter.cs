using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class settingsparameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 10, 19, 54, 313, DateTimeKind.Local).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 29, 17, 26, 28, 963, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 17, 26, 28, 963, DateTimeKind.Local).AddTicks(3831),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 30, 10, 19, 54, 313, DateTimeKind.Local).AddTicks(4972));
        }
    }
}
