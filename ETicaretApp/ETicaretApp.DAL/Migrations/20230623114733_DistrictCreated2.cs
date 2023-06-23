using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DistrictCreated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 23, 14, 47, 33, 157, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Districts_CityId",
                table: "Districts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 23, 14, 39, 46, 50, DateTimeKind.Local).AddTicks(3873));
        }
    }
}
