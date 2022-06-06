using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class stockinventary_add_user_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Users_IntranetUserId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_IntranetUserId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "IntranetUserId",
                table: "Stocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 345, DateTimeKind.Local).AddTicks(4264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 466, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 340, DateTimeKind.Local).AddTicks(5917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 463, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 403, DateTimeKind.Local).AddTicks(1736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 507, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 398, DateTimeKind.Local).AddTicks(9841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 504, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 399, DateTimeKind.Local).AddTicks(7118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 504, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 395, DateTimeKind.Local).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 500, DateTimeKind.Local).AddTicks(1908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 379, DateTimeKind.Local).AddTicks(4680),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 489, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 388, DateTimeKind.Local).AddTicks(3375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 495, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 391, DateTimeKind.Local).AddTicks(9481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 498, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 373, DateTimeKind.Local).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 485, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 370, DateTimeKind.Local).AddTicks(1146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 482, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 364, DateTimeKind.Local).AddTicks(2973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 479, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 331, DateTimeKind.Local).AddTicks(4257),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 457, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 361, DateTimeKind.Local).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 478, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 357, DateTimeKind.Local).AddTicks(8910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 475, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 354, DateTimeKind.Local).AddTicks(8206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 473, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 348, DateTimeKind.Local).AddTicks(4853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 468, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 351, DateTimeKind.Local).AddTicks(7059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 471, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 337, DateTimeKind.Local).AddTicks(8656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 461, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 335, DateTimeKind.Local).AddTicks(4431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 459, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 327, DateTimeKind.Local).AddTicks(9123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 454, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 323, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 451, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 320, DateTimeKind.Local).AddTicks(347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 449, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 312, DateTimeKind.Local).AddTicks(6114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 444, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 310, DateTimeKind.Local).AddTicks(352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 442, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 307, DateTimeKind.Local).AddTicks(9646),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 440, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 305, DateTimeKind.Local).AddTicks(2470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 438, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 292, DateTimeKind.Local).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 427, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_IntranerUserId",
                table: "Stocks",
                column: "IntranerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_IntranerUserId",
                table: "Stocks",
                column: "IntranerUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Users_IntranerUserId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_IntranerUserId",
                table: "Stocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 466, DateTimeKind.Local).AddTicks(3668),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 345, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 463, DateTimeKind.Local).AddTicks(1595),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 340, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 507, DateTimeKind.Local).AddTicks(5747),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 403, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 504, DateTimeKind.Local).AddTicks(2638),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 398, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 504, DateTimeKind.Local).AddTicks(9670),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 399, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 500, DateTimeKind.Local).AddTicks(1908),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 395, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 489, DateTimeKind.Local).AddTicks(5566),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 379, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 495, DateTimeKind.Local).AddTicks(6770),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 388, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 498, DateTimeKind.Local).AddTicks(113),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 391, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 485, DateTimeKind.Local).AddTicks(1696),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 373, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 482, DateTimeKind.Local).AddTicks(8978),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 370, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.AddColumn<int>(
                name: "IntranetUserId",
                table: "Stocks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 479, DateTimeKind.Local).AddTicks(8152),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 364, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 457, DateTimeKind.Local).AddTicks(2087),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 331, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 478, DateTimeKind.Local).AddTicks(2330),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 361, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 475, DateTimeKind.Local).AddTicks(5687),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 357, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 473, DateTimeKind.Local).AddTicks(5297),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 354, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 468, DateTimeKind.Local).AddTicks(3545),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 348, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 471, DateTimeKind.Local).AddTicks(2709),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 351, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 461, DateTimeKind.Local).AddTicks(2561),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 337, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 459, DateTimeKind.Local).AddTicks(7238),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 335, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 454, DateTimeKind.Local).AddTicks(9943),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 327, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 451, DateTimeKind.Local).AddTicks(8341),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 323, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 449, DateTimeKind.Local).AddTicks(7421),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 320, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 444, DateTimeKind.Local).AddTicks(9097),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 312, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 442, DateTimeKind.Local).AddTicks(9448),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 310, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 440, DateTimeKind.Local).AddTicks(8932),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 307, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 438, DateTimeKind.Local).AddTicks(1732),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 305, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 30, 16, 13, 29, 427, DateTimeKind.Local).AddTicks(7372),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 30, 20, 28, 16, 292, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_IntranetUserId",
                table: "Stocks",
                column: "IntranetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_IntranetUserId",
                table: "Stocks",
                column: "IntranetUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
