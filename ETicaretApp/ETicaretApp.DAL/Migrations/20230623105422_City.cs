using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class City : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RegisterDate", "Role", "State" },
                values: new object[] { 1, "admin@gmail.com", "123456", new DateTime(2023, 6, 23, 12, 45, 24, 395, DateTimeKind.Local).AddTicks(4584), "Admin", true });
        }
    }
}
