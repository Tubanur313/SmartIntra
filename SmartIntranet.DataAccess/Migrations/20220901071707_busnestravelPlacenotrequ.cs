using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class busnestravelPlacenotrequ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTravels_Places_PlaceId",
                table: "BusinessTravels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 11, 17, 7, 373, DateTimeKind.Local).AddTicks(7566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 14, 30, 9, 136, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "BusinessTravels",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTravels_Places_PlaceId",
                table: "BusinessTravels",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTravels_Places_PlaceId",
                table: "BusinessTravels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 14, 30, 9, 136, DateTimeKind.Local).AddTicks(4339),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 9, 1, 11, 17, 7, 373, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "BusinessTravels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTravels_Places_PlaceId",
                table: "BusinessTravels",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
