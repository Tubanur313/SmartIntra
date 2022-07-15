using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class VacationDateRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromWorkYearDate",
                table: "VacationContracts");

            migrationBuilder.DropColumn(
                name: "ToWorkYearDate",
                table: "VacationContracts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 16, 16, 57, 570, DateTimeKind.Local).AddTicks(9906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 9, 51, 52, 568, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.CreateTable(
                name: "VacationContractDates",
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
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    CalendarDay = table.Column<int>(nullable: false),
                    VacationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationContractDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationContractDates_VacationContracts_VacationId",
                        column: x => x.VacationId,
                        principalTable: "VacationContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationContractDates_VacationId",
                table: "VacationContractDates",
                column: "VacationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationContractDates");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromWorkYearDate",
                table: "VacationContracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToWorkYearDate",
                table: "VacationContracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 9, 51, 52, 568, DateTimeKind.Local).AddTicks(8760),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 7, 9, 16, 16, 57, 570, DateTimeKind.Local).AddTicks(9906));
        }
    }
}
