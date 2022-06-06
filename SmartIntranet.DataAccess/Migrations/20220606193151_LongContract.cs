using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class LongContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 57, DateTimeKind.Local).AddTicks(145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 42, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 40, DateTimeKind.Local).AddTicks(8376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 35, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkGraphics",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 135, DateTimeKind.Local).AddTicks(7635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 81, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkCalendars",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 132, DateTimeKind.Local).AddTicks(6390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 79, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 128, DateTimeKind.Local).AddTicks(5876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 77, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 123, DateTimeKind.Local).AddTicks(9993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 75, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 124, DateTimeKind.Local).AddTicks(2151),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 75, DateTimeKind.Local).AddTicks(5651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 120, DateTimeKind.Local).AddTicks(8024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 73, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 103, DateTimeKind.Local).AddTicks(6385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 64, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 113, DateTimeKind.Local).AddTicks(1851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 69, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 116, DateTimeKind.Local).AddTicks(9767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 71, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 97, DateTimeKind.Local).AddTicks(9154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 61, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 94, DateTimeKind.Local).AddTicks(2609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 59, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockImages",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 89, DateTimeKind.Local).AddTicks(524),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 57, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 86, DateTimeKind.Local).AddTicks(493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 54, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 29, DateTimeKind.Local).AddTicks(1078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 31, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 83, DateTimeKind.Local).AddTicks(3031),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 53, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Places",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 78, DateTimeKind.Local).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 51, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 74, DateTimeKind.Local).AddTicks(3622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 49, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 70, DateTimeKind.Local).AddTicks(7116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 48, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NonWorkingYears",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 67, DateTimeKind.Local).AddTicks(6495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 46, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 59, DateTimeKind.Local).AddTicks(8541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 43, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 63, DateTimeKind.Local).AddTicks(8181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 45, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 37, DateTimeKind.Local).AddTicks(3925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 34, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 34, DateTimeKind.Local).AddTicks(87),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 32, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 25, DateTimeKind.Local).AddTicks(8828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 29, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 22, DateTimeKind.Local).AddTicks(8019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 27, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contracts",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 19, DateTimeKind.Local).AddTicks(9740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 25, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 15, DateTimeKind.Local).AddTicks(729),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 23, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 5, DateTimeKind.Local).AddTicks(5840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 17, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clauses",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 2, DateTimeKind.Local).AddTicks(4319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 16, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 999, DateTimeKind.Local).AddTicks(7017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 14, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Causes",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 997, DateTimeKind.Local).AddTicks(453),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 12, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 994, DateTimeKind.Local).AddTicks(3632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 11, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 981, DateTimeKind.Local).AddTicks(5135),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 2, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BusinessTrips",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 975, DateTimeKind.Local).AddTicks(4885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 11, 1, 54, 998, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.CreateTable(
                name: "LongContracts",
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
                    UserId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LongContracts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LongContractFiles",
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
                    FilePath = table.Column<string>(nullable: true),
                    ClauseId = table.Column<int>(nullable: true),
                    LongContractId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongContractFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LongContractFiles_Clauses_ClauseId",
                        column: x => x.ClauseId,
                        principalTable: "Clauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LongContractFiles_LongContracts_LongContractId",
                        column: x => x.LongContractId,
                        principalTable: "LongContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LongContractFiles_ClauseId",
                table: "LongContractFiles",
                column: "ClauseId");

            migrationBuilder.CreateIndex(
                name: "IX_LongContractFiles_LongContractId",
                table: "LongContractFiles",
                column: "LongContractId");

            migrationBuilder.CreateIndex(
                name: "IX_LongContracts_UserId",
                table: "LongContracts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LongContractFiles");

            migrationBuilder.DropTable(
                name: "LongContracts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 42, DateTimeKind.Local).AddTicks(1206),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 57, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Membership",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 35, DateTimeKind.Local).AddTicks(3940),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 40, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkGraphics",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 81, DateTimeKind.Local).AddTicks(195),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 135, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkCalendars",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 79, DateTimeKind.Local).AddTicks(2622),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 132, DateTimeKind.Local).AddTicks(6390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Watchers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 77, DateTimeKind.Local).AddTicks(6188),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 128, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 75, DateTimeKind.Local).AddTicks(4625),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 123, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 75, DateTimeKind.Local).AddTicks(5651),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 124, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserContractFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 73, DateTimeKind.Local).AddTicks(5659),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 120, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 64, DateTimeKind.Local).AddTicks(4635),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 103, DateTimeKind.Local).AddTicks(6385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 69, DateTimeKind.Local).AddTicks(8312),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 113, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketOrders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 71, DateTimeKind.Local).AddTicks(8649),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 116, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TicketCheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 61, DateTimeKind.Local).AddTicks(5503),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 97, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stocks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 59, DateTimeKind.Local).AddTicks(7533),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 94, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockImages",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 57, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 89, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "StockCategories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 54, DateTimeKind.Local).AddTicks(9690),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 86, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SMTPEmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 31, DateTimeKind.Local).AddTicks(612),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 29, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 53, DateTimeKind.Local).AddTicks(4878),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 83, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Places",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 51, DateTimeKind.Local).AddTicks(3948),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 78, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 49, DateTimeKind.Local).AddTicks(7072),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 74, DateTimeKind.Local).AddTicks(3622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 48, DateTimeKind.Local).AddTicks(1684),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 70, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NonWorkingYears",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 46, DateTimeKind.Local).AddTicks(6031),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 67, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsFiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 43, DateTimeKind.Local).AddTicks(6184),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 59, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 45, DateTimeKind.Local).AddTicks(2993),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 63, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 34, DateTimeKind.Local).AddTicks(1699),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 37, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entrances",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 32, DateTimeKind.Local).AddTicks(9022),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 34, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Discussions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 29, DateTimeKind.Local).AddTicks(3669),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 25, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 27, DateTimeKind.Local).AddTicks(3126),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 22, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 25, DateTimeKind.Local).AddTicks(6445),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 19, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ConfirmTicketUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 23, DateTimeKind.Local).AddTicks(909),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 15, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 17, DateTimeKind.Local).AddTicks(9939),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 5, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clauses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 16, DateTimeKind.Local).AddTicks(810),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 51, 2, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CheckLists",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 14, DateTimeKind.Local).AddTicks(4554),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 999, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Causes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 12, DateTimeKind.Local).AddTicks(9236),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 997, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryTickets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 11, DateTimeKind.Local).AddTicks(3677),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 994, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 55, 2, DateTimeKind.Local).AddTicks(7941),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 981, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BusinessTrips",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 6, 6, 11, 1, 54, 998, DateTimeKind.Local).AddTicks(8716),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 6, 6, 23, 31, 50, 975, DateTimeKind.Local).AddTicks(4885));
        }
    }
}
