using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class updateSettingProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 14, 56, 3, 423, DateTimeKind.Local).AddTicks(393),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 11, 15, 13, 508, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.AddColumn<string>(
                name: "CompanySite",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanySite",
                table: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 11, 15, 13, 508, DateTimeKind.Local).AddTicks(4313),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 30, 14, 56, 3, 423, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
