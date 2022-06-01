using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class stockImageAndStockDiscuss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 437, DateTimeKind.Local).AddTicks(2435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 963, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 434, DateTimeKind.Local).AddTicks(4552),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 960, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 469, DateTimeKind.Local).AddTicks(820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 8, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 466, DateTimeKind.Local).AddTicks(8572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 6, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 467, DateTimeKind.Local).AddTicks(2166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 6, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 464, DateTimeKind.Local).AddTicks(8384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 3, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 455, DateTimeKind.Local).AddTicks(6416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 991, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 460, DateTimeKind.Local).AddTicks(4036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 998, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 462, DateTimeKind.Local).AddTicks(7204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 1, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 451, DateTimeKind.Local).AddTicks(8784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 988, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 449, DateTimeKind.Local).AddTicks(8624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 985, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 446, DateTimeKind.Local).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 981, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 429, DateTimeKind.Local).AddTicks(9421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 953, DateTimeKind.Local).AddTicks(2016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 445, DateTimeKind.Local).AddTicks(351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 979, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 443, DateTimeKind.Local).AddTicks(2048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 976, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 441, DateTimeKind.Local).AddTicks(8371),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 973, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 438, DateTimeKind.Local).AddTicks(8396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 967, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 440, DateTimeKind.Local).AddTicks(4008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 970, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 433, DateTimeKind.Local).AddTicks(625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 958, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 431, DateTimeKind.Local).AddTicks(8384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 956, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 428, DateTimeKind.Local).AddTicks(3477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 950, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 426, DateTimeKind.Local).AddTicks(6239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 947, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 424, DateTimeKind.Local).AddTicks(9658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 944, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 420, DateTimeKind.Local).AddTicks(6990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 939, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 419, DateTimeKind.Local).AddTicks(3008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 418, DateTimeKind.Local).AddTicks(1053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 935, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 416, DateTimeKind.Local).AddTicks(5772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 933, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 408, DateTimeKind.Local).AddTicks(7977),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 919, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.CreateTable(
                name: "StockDiscusses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteByUserId = table.Column<int>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IntranetUserId = table.Column<int>(nullable: true),
                    StockId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDiscusses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockDiscusses_Users_IntranetUserId",
                        column: x => x.IntranetUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockDiscusses_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 447, DateTimeKind.Local).AddTicks(5175)),
                    UpdateByUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteByUserId = table.Column<int>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    StockId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockImages_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockDiscusses_IntranetUserId",
                table: "StockDiscusses",
                column: "IntranetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDiscusses_StockId",
                table: "StockDiscusses",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockImages_StockId",
                table: "StockImages",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockDiscusses");

            migrationBuilder.DropTable(
                name: "StockImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 963, DateTimeKind.Local).AddTicks(9933),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 437, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 960, DateTimeKind.Local).AddTicks(1356),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 434, DateTimeKind.Local).AddTicks(4552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 8, DateTimeKind.Local).AddTicks(9591),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 469, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 6, DateTimeKind.Local).AddTicks(2220),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 466, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 6, DateTimeKind.Local).AddTicks(5908),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 467, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 3, DateTimeKind.Local).AddTicks(8925),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 464, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 991, DateTimeKind.Local).AddTicks(5653),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 455, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 998, DateTimeKind.Local).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 460, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 55, 1, DateTimeKind.Local).AddTicks(7463),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 462, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 988, DateTimeKind.Local).AddTicks(227),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 451, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 985, DateTimeKind.Local).AddTicks(7435),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 449, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 981, DateTimeKind.Local).AddTicks(8105),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 446, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 953, DateTimeKind.Local).AddTicks(2016),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 429, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 979, DateTimeKind.Local).AddTicks(5225),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 445, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 976, DateTimeKind.Local).AddTicks(166),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 443, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 973, DateTimeKind.Local).AddTicks(1989),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 441, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 967, DateTimeKind.Local).AddTicks(6240),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 438, DateTimeKind.Local).AddTicks(8396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 970, DateTimeKind.Local).AddTicks(4048),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 440, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 958, DateTimeKind.Local).AddTicks(2454),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 433, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 956, DateTimeKind.Local).AddTicks(5127),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 431, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 950, DateTimeKind.Local).AddTicks(5098),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 428, DateTimeKind.Local).AddTicks(3477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 947, DateTimeKind.Local).AddTicks(5654),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 426, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 944, DateTimeKind.Local).AddTicks(8951),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 424, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 939, DateTimeKind.Local).AddTicks(1046),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 420, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1958),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 419, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 935, DateTimeKind.Local).AddTicks(6092),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 418, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryNews",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 933, DateTimeKind.Local).AddTicks(2644),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 416, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 31, 14, 50, 54, 919, DateTimeKind.Local).AddTicks(4224),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 40, 25, 408, DateTimeKind.Local).AddTicks(7977));
        }
    }
}
