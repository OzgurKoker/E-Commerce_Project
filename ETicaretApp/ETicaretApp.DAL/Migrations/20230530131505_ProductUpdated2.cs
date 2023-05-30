using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<double>(
                name: "DiscountedPrice",
                table: "Products",
                type: "float",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountedPrice",
                table: "Products",
                type: "int",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
