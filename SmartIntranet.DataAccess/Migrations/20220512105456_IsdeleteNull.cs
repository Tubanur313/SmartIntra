using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class IsdeleteNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Membership",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 979, DateTimeKind.Local).AddTicks(5737),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 307, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 981, DateTimeKind.Local).AddTicks(9173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 309, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Watchers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 19, DateTimeKind.Local).AddTicks(9501),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 344, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 940, DateTimeKind.Local).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 276, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vacancies",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 946, DateTimeKind.Local).AddTicks(6054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 278, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserContractFiles",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 954, DateTimeKind.Local).AddTicks(5631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 286, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 6, DateTimeKind.Local).AddTicks(7889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 332, DateTimeKind.Local).AddTicks(5242));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 15, DateTimeKind.Local).AddTicks(6557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 339, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TicketOrders",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 24, DateTimeKind.Local).AddTicks(1595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 349, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TicketCheckLists",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 17, DateTimeKind.Local).AddTicks(8456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 341, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SMTPEmailSettings",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 973, DateTimeKind.Local).AddTicks(1759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 299, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 993, DateTimeKind.Local).AddTicks(1354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 319, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 1, DateTimeKind.Local).AddTicks(2482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 328, DateTimeKind.Local).AddTicks(3361));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 22, DateTimeKind.Local).AddTicks(1227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 346, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 958, DateTimeKind.Local).AddTicks(4340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 289, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "News",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 960, DateTimeKind.Local).AddTicks(429),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 290, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 956, DateTimeKind.Local).AddTicks(4212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 287, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Entrances",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 999, DateTimeKind.Local).AddTicks(1388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 325, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Discussions",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 996, DateTimeKind.Local).AddTicks(4494),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 322, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 989, DateTimeKind.Local).AddTicks(6365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 316, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ConfirmTicketUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 987, DateTimeKind.Local).AddTicks(941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 313, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 984, DateTimeKind.Local).AddTicks(1594),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 311, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CheckLists",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 975, DateTimeKind.Local).AddTicks(2218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 301, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CategoryTickets",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 969, DateTimeKind.Local).AddTicks(3383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 297, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CategoryNews",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdateByUserId",
                table: "CategoryNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteDate",
                table: "CategoryNews",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeleteByUserId",
                table: "CategoryNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 967, DateTimeKind.Local).AddTicks(2675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "CategoryNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 961, DateTimeKind.Local).AddTicks(6695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 292, DateTimeKind.Local).AddTicks(930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Membership",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 307, DateTimeKind.Local).AddTicks(1872),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 979, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 309, DateTimeKind.Local).AddTicks(6246),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 981, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Watchers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 344, DateTimeKind.Local).AddTicks(2683),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 19, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 276, DateTimeKind.Local).AddTicks(3317),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 940, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 278, DateTimeKind.Local).AddTicks(5232),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 946, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserContractFiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 286, DateTimeKind.Local).AddTicks(394),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 954, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 332, DateTimeKind.Local).AddTicks(5242),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 6, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 339, DateTimeKind.Local).AddTicks(4091),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 15, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TicketOrders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 349, DateTimeKind.Local).AddTicks(2488),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 24, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TicketCheckLists",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 341, DateTimeKind.Local).AddTicks(9582),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 17, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SMTPEmailSettings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 299, DateTimeKind.Local).AddTicks(7286),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 973, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 319, DateTimeKind.Local).AddTicks(6299),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 993, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Photos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 328, DateTimeKind.Local).AddTicks(3361),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 1, DateTimeKind.Local).AddTicks(2482));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 346, DateTimeKind.Local).AddTicks(3021),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 56, 22, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 289, DateTimeKind.Local).AddTicks(2261),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 958, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 290, DateTimeKind.Local).AddTicks(6731),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 960, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 287, DateTimeKind.Local).AddTicks(5917),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 956, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Entrances",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 325, DateTimeKind.Local).AddTicks(9621),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 999, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Discussions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 322, DateTimeKind.Local).AddTicks(6296),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 996, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 316, DateTimeKind.Local).AddTicks(197),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 989, DateTimeKind.Local).AddTicks(6365));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ConfirmTicketUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 313, DateTimeKind.Local).AddTicks(8759),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 987, DateTimeKind.Local).AddTicks(941));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 311, DateTimeKind.Local).AddTicks(4843),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 984, DateTimeKind.Local).AddTicks(1594));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CheckLists",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 301, DateTimeKind.Local).AddTicks(9712),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 975, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CategoryTickets",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 297, DateTimeKind.Local).AddTicks(7357),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 969, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CategoryNews",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdateByUserId",
                table: "CategoryNews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteDate",
                table: "CategoryNews",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeleteByUserId",
                table: "CategoryNews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 967, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "CategoryNews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 10, 15, 25, 19, 292, DateTimeKind.Local).AddTicks(930),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 14, 54, 55, 961, DateTimeKind.Local).AddTicks(6695));
        }
    }
}
