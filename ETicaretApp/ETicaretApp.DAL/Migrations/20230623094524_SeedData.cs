using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RegisterDate", "Role", "State" },
                values: new object[] { 1, "admin@gmail.com", "123456", new DateTime(2023, 6, 23, 12, 45, 24, 395, DateTimeKind.Local).AddTicks(4584), "Admin", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
