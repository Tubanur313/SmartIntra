using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class AddCompanyToClause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 25, 18, 41, 43, 896, DateTimeKind.Local).AddTicks(3868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 12, 11, 49, 44, 513, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Clauses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clauses_CompanyId",
                table: "Clauses",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clauses_Companies_CompanyId",
                table: "Clauses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clauses_Companies_CompanyId",
                table: "Clauses");

            migrationBuilder.DropIndex(
                name: "IX_Clauses_CompanyId",
                table: "Clauses");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clauses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 11, 49, 44, 513, DateTimeKind.Local).AddTicks(4560),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 9, 25, 18, 41, 43, 896, DateTimeKind.Local).AddTicks(3868));
        }
    }
}
