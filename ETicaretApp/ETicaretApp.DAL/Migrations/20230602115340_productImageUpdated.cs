using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class productImageUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductImages",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ProductImages",
                newName: "Name");
        }
    }
}
