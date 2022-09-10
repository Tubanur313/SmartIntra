using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class PersonalContractDelReverse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 10, 21, 0, 1, 64, DateTimeKind.Local).AddTicks(4358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 10, 20, 40, 27, 575, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.AddColumn<int>(
                name: "LastDepartmentId",
                table: "PersonalContracts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LastIsMainPlace",
                table: "PersonalContracts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastPositionId",
                table: "PersonalContracts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastSalary",
                table: "PersonalContracts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDepartmentId",
                table: "PersonalContracts");

            migrationBuilder.DropColumn(
                name: "LastIsMainPlace",
                table: "PersonalContracts");

            migrationBuilder.DropColumn(
                name: "LastPositionId",
                table: "PersonalContracts");

            migrationBuilder.DropColumn(
                name: "LastSalary",
                table: "PersonalContracts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 10, 20, 40, 27, 575, DateTimeKind.Local).AddTicks(6756),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 9, 10, 21, 0, 1, 64, DateTimeKind.Local).AddTicks(4358));
        }
    }
}
