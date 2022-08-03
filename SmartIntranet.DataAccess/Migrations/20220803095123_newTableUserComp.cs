using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartIntranet.DataAccess.Migrations
{
    public partial class newTableUserComp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 3, 13, 51, 23, 604, DateTimeKind.Local).AddTicks(887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 10, 15, 16, 295, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.CreateTable(
                name: "UserComps",
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
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComps_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComps_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComps_CompanyId",
                table: "UserComps",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComps_UserId",
                table: "UserComps",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserComps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 10, 15, 16, 295, DateTimeKind.Local).AddTicks(6001),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 3, 13, 51, 23, 604, DateTimeKind.Local).AddTicks(887));
        }
    }
}
