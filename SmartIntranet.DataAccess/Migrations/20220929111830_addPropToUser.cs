using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class addPropToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomePhoneNumber",
                schema: "Membership",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoneNumber",
                schema: "Membership",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 29, 15, 18, 29, 981, DateTimeKind.Local).AddTicks(1725),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 29, 11, 38, 13, 841, DateTimeKind.Local).AddTicks(146));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePhoneNumber",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonalPhoneNumber",
                schema: "Membership",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 29, 11, 38, 13, 841, DateTimeKind.Local).AddTicks(146),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 9, 29, 15, 18, 29, 981, DateTimeKind.Local).AddTicks(1725));
        }
    }
}
