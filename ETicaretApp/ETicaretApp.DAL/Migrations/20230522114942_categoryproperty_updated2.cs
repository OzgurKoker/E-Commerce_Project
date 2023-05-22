using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class categoryproperty_updated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryProperties_CategoryPropertyId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryPropertyId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryPropertyId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CategoryProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProperties_CategoryId",
                table: "CategoryProperties",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProperties_Categories_CategoryId",
                table: "CategoryProperties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProperties_Categories_CategoryId",
                table: "CategoryProperties");

            migrationBuilder.DropIndex(
                name: "IX_CategoryProperties_CategoryId",
                table: "CategoryProperties");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CategoryProperties");

            migrationBuilder.AddColumn<int>(
                name: "CategoryPropertyId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryPropertyId",
                table: "Categories",
                column: "CategoryPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryProperties_CategoryPropertyId",
                table: "Categories",
                column: "CategoryPropertyId",
                principalTable: "CategoryProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
