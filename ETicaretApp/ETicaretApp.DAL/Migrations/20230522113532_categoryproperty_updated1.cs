using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class categoryproperty_updated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Property1",
                table: "CategoryProperties");

            migrationBuilder.DropColumn(
                name: "Property2",
                table: "CategoryProperties");

            migrationBuilder.DropColumn(
                name: "Property3",
                table: "CategoryProperties");

            migrationBuilder.DropColumn(
                name: "Property4",
                table: "CategoryProperties");

            migrationBuilder.RenameColumn(
                name: "Property5",
                table: "CategoryProperties",
                newName: "Property");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Property",
                table: "CategoryProperties",
                newName: "Property5");

            migrationBuilder.AddColumn<string>(
                name: "Property1",
                table: "CategoryProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Property2",
                table: "CategoryProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Property3",
                table: "CategoryProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Property4",
                table: "CategoryProperties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
