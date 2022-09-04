using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 17, 26, 28, 963, DateTimeKind.Local).AddTicks(3831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 3, 13, 51, 23, 604, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEnd",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Settings",
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
                    TicketMail = table.Column<string>(nullable: true),
                    TicketPassword = table.Column<string>(nullable: true),
                    TicketHost = table.Column<string>(nullable: true),
                    TicketPort = table.Column<int>(nullable: false),
                    HrMail = table.Column<string>(nullable: true),
                    HrPassword = table.Column<string>(nullable: true),
                    HrHost = table.Column<string>(nullable: true),
                    HrPort = table.Column<int>(nullable: false),
                    BaseUrl = table.Column<string>(nullable: true),
                    CompanyLogo = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyEmail = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    CompanyPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 3, 13, 51, 23, 604, DateTimeKind.Local).AddTicks(887),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 29, 17, 26, 28, 963, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEnd",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
