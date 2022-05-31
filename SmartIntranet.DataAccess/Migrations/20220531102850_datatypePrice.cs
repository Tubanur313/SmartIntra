using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class datatypePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 577, DateTimeKind.Local).AddTicks(2945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 345, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 574, DateTimeKind.Local).AddTicks(7091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 340, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 630, DateTimeKind.Local).AddTicks(1569),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 403, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 624, DateTimeKind.Local).AddTicks(1668),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 398, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 625, DateTimeKind.Local).AddTicks(225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 399, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 621, DateTimeKind.Local).AddTicks(7940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 395, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 607, DateTimeKind.Local).AddTicks(5111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 379, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 617, DateTimeKind.Local).AddTicks(6319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 388, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 619, DateTimeKind.Local).AddTicks(8582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 391, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 600, DateTimeKind.Local).AddTicks(4545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 373, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Stocks",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 595, DateTimeKind.Local).AddTicks(2904),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 370, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 590, DateTimeKind.Local).AddTicks(1342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 364, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 569, DateTimeKind.Local).AddTicks(3586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 331, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 588, DateTimeKind.Local).AddTicks(3034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 361, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 585, DateTimeKind.Local).AddTicks(8468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 357, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 583, DateTimeKind.Local).AddTicks(5441),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 354, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 578, DateTimeKind.Local).AddTicks(9145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 348, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 580, DateTimeKind.Local).AddTicks(7425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 351, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 573, DateTimeKind.Local).AddTicks(2017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 337, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 571, DateTimeKind.Local).AddTicks(7711),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 335, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 567, DateTimeKind.Local).AddTicks(1426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 327, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 564, DateTimeKind.Local).AddTicks(7808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 323, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 562, DateTimeKind.Local).AddTicks(8707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 320, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 557, DateTimeKind.Local).AddTicks(9147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 312, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 556, DateTimeKind.Local).AddTicks(4041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 310, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 555, DateTimeKind.Local).AddTicks(310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 307, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 552, DateTimeKind.Local).AddTicks(8817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 305, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 540, DateTimeKind.Local).AddTicks(7262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 292, DateTimeKind.Local).AddTicks(2965));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 345, DateTimeKind.Local).AddTicks(4264),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 577, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 340, DateTimeKind.Local).AddTicks(5917),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 574, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 403, DateTimeKind.Local).AddTicks(1736),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 630, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 398, DateTimeKind.Local).AddTicks(9841),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 624, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 399, DateTimeKind.Local).AddTicks(7118),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 625, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 395, DateTimeKind.Local).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 621, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 379, DateTimeKind.Local).AddTicks(4680),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 607, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 388, DateTimeKind.Local).AddTicks(3375),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 617, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 391, DateTimeKind.Local).AddTicks(9481),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 619, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 373, DateTimeKind.Local).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 600, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 370, DateTimeKind.Local).AddTicks(1146),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 595, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 364, DateTimeKind.Local).AddTicks(2973),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 590, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 331, DateTimeKind.Local).AddTicks(4257),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 569, DateTimeKind.Local).AddTicks(3586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 361, DateTimeKind.Local).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 588, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 357, DateTimeKind.Local).AddTicks(8910),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 585, DateTimeKind.Local).AddTicks(8468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 354, DateTimeKind.Local).AddTicks(8206),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 583, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 348, DateTimeKind.Local).AddTicks(4853),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 578, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 351, DateTimeKind.Local).AddTicks(7059),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 580, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 337, DateTimeKind.Local).AddTicks(8656),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 573, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 335, DateTimeKind.Local).AddTicks(4431),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 571, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 327, DateTimeKind.Local).AddTicks(9123),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 567, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 323, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 564, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 320, DateTimeKind.Local).AddTicks(347),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 562, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 312, DateTimeKind.Local).AddTicks(6114),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 557, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 310, DateTimeKind.Local).AddTicks(352),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 556, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 307, DateTimeKind.Local).AddTicks(9646),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 555, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 305, DateTimeKind.Local).AddTicks(2470),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 552, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 292, DateTimeKind.Local).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 28, 49, 540, DateTimeKind.Local).AddTicks(7262));
        }
    }
}
