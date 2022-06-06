using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class deleteStockStatusProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Stocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 187, DateTimeKind.Local).AddTicks(3485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 696, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 178, DateTimeKind.Local).AddTicks(5290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 692, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkGraphics",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 225, DateTimeKind.Local).AddTicks(3426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 721, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkCalendars",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 223, DateTimeKind.Local).AddTicks(8513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 720, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 222, DateTimeKind.Local).AddTicks(1757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 719, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 220, DateTimeKind.Local).AddTicks(792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 718, DateTimeKind.Local).AddTicks(836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 220, DateTimeKind.Local).AddTicks(1966),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 718, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 218, DateTimeKind.Local).AddTicks(2496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 716, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 210, DateTimeKind.Local).AddTicks(6034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 710, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 215, DateTimeKind.Local).AddTicks(1323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 714, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 216, DateTimeKind.Local).AddTicks(7351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 715, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 207, DateTimeKind.Local).AddTicks(9080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 708, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 206, DateTimeKind.Local).AddTicks(3090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 707, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockImages",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 203, DateTimeKind.Local).AddTicks(8448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 706, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 202, DateTimeKind.Local).AddTicks(4181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 704, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 172, DateTimeKind.Local).AddTicks(52),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 689, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 201, DateTimeKind.Local).AddTicks(3362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 704, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Places",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 199, DateTimeKind.Local).AddTicks(4555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 702, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 197, DateTimeKind.Local).AddTicks(6246),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 701, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 195, DateTimeKind.Local).AddTicks(7210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 700, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NonWorkingYears",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 193, DateTimeKind.Local).AddTicks(6610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 699, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 190, DateTimeKind.Local).AddTicks(2805),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 697, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 192, DateTimeKind.Local).AddTicks(2843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 699, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 176, DateTimeKind.Local).AddTicks(8121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 175, DateTimeKind.Local).AddTicks(330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 690, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 169, DateTimeKind.Local).AddTicks(7321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 688, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 167, DateTimeKind.Local).AddTicks(1459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 687, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contracts",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 164, DateTimeKind.Local).AddTicks(8629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 686, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 161, DateTimeKind.Local).AddTicks(8263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 684, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 156, DateTimeKind.Local).AddTicks(441),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 681, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clauses",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 154, DateTimeKind.Local).AddTicks(1084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 680, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 152, DateTimeKind.Local).AddTicks(4352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 680, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Causes",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 150, DateTimeKind.Local).AddTicks(8072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 679, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 148, DateTimeKind.Local).AddTicks(2167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 678, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 136, DateTimeKind.Local).AddTicks(587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 673, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BusinessTrips",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 131, DateTimeKind.Local).AddTicks(1942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 670, DateTimeKind.Local).AddTicks(5808));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 696, DateTimeKind.Local).AddTicks(9020),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 187, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 692, DateTimeKind.Local).AddTicks(2747),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 178, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkGraphics",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 721, DateTimeKind.Local).AddTicks(7909),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 225, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkCalendars",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 720, DateTimeKind.Local).AddTicks(7349),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 223, DateTimeKind.Local).AddTicks(8513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 719, DateTimeKind.Local).AddTicks(6592),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 222, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 718, DateTimeKind.Local).AddTicks(836),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 220, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 718, DateTimeKind.Local).AddTicks(1610),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 220, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 716, DateTimeKind.Local).AddTicks(8809),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 218, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 710, DateTimeKind.Local).AddTicks(8058),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 210, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 714, DateTimeKind.Local).AddTicks(5434),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 215, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 715, DateTimeKind.Local).AddTicks(7809),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 216, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 708, DateTimeKind.Local).AddTicks(8901),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 207, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 707, DateTimeKind.Local).AddTicks(7223),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 206, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockImages",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 706, DateTimeKind.Local).AddTicks(247),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 203, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 704, DateTimeKind.Local).AddTicks(9737),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 202, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 689, DateTimeKind.Local).AddTicks(4873),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 172, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 704, DateTimeKind.Local).AddTicks(2143),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 201, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Places",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 702, DateTimeKind.Local).AddTicks(9401),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 199, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 701, DateTimeKind.Local).AddTicks(8346),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 197, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 700, DateTimeKind.Local).AddTicks(8719),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 195, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NonWorkingYears",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 699, DateTimeKind.Local).AddTicks(8798),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 193, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 697, DateTimeKind.Local).AddTicks(9221),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 190, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 699, DateTimeKind.Local).AddTicks(862),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 192, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(4682),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 176, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 690, DateTimeKind.Local).AddTicks(6777),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 175, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 688, DateTimeKind.Local).AddTicks(4354),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 169, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 687, DateTimeKind.Local).AddTicks(2033),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 167, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 686, DateTimeKind.Local).AddTicks(1237),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 164, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 684, DateTimeKind.Local).AddTicks(6424),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 161, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 681, DateTimeKind.Local).AddTicks(7996),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 156, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clauses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 680, DateTimeKind.Local).AddTicks(8394),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 154, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 680, DateTimeKind.Local).AddTicks(340),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 152, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Causes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 679, DateTimeKind.Local).AddTicks(2997),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 150, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 678, DateTimeKind.Local).AddTicks(5160),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 148, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 673, DateTimeKind.Local).AddTicks(3893),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 136, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BusinessTrips",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 10, 59, 10, 670, DateTimeKind.Local).AddTicks(5808),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 48, 20, 131, DateTimeKind.Local).AddTicks(1942));
        }
    }
}
