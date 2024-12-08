using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Divisima.DAL.Migrations
{
    /// <inheritdoc />
    public partial class siteinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Info2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Info3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Info4 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Info5 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Info6 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    ESiteInfo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteInfo", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2024, 11, 21, 13, 10, 14, 995, DateTimeKind.Local).AddTicks(117));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteInfo");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2024, 11, 19, 10, 33, 10, 990, DateTimeKind.Local).AddTicks(328));
        }
    }
}
