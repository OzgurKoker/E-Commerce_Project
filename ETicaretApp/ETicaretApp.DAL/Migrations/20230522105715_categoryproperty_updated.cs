using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class categoryproperty_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProperties", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryProperties_CategoryPropertyId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryProperties");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryPropertyId",
                table: "Categories");
        }
    }
}
